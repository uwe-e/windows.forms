using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Security.Permissions;
using System.IO;
using System.Globalization;

namespace BSE.RemovableDrives
{
    public partial class RemovableDeviceController : Control
    {
        #region Events
        public event EventHandler<DriveChangeEventArgs> DriveChanges;
		public event EventHandler<DriveChangeEventArgs> DriveAdded;
		public event EventHandler<DriveChangeEventArgs> DriveRemoved;
        #endregion

        #region FieldsPrivate
        private Image m_image;
        private Image m_disabledImage;
		private Collection<RemovableDrive> m_removableDrives;
		private Collection<RemovableDrive> m_backupDrives;
        private bool m_bHasUsbDevices;
        private DeviceController m_deviceChangeController;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the image that is displayed on a <see cref="RemovableDeviceController"/>.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.Drawing.Image"/>
        /// The <see cref="Image"/> to be displayed.
        /// </value>
        public Image Image
        {
            get { return this.m_image; }
            set
            {
                if (value != this.m_image)
                {
                    this.m_image = value;
                    this.m_disabledImage = null;
                    if (this.m_image == null)
                    {
                        this.m_image = Properties.Resources.Portable_Media_Devices;
                    }
                    this.Invalidate();
                }
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the RemovableDeviceController class.
        /// </summary>
        public RemovableDeviceController()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            this.m_image = Properties.Resources.Portable_Media_Devices;
            this.BackColor = Color.Transparent;
			this.m_removableDrives = new Collection<RemovableDrive>();
			FindUsbDevices();
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the HandleCreated event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                this.m_deviceChangeController = new DeviceController(parentForm);
                this.m_deviceChangeController.DeviceChanges += new EventHandler<EventArgs>(ControllerDeviceChanged);
            }
            base.OnHandleCreated(e);
        }
        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = e.Graphics)
            {
                Rectangle imageRectangle = this.ClientRectangle;
                imageRectangle.Width -= 1;
                imageRectangle.Height -= 1;
                if (this.m_bHasUsbDevices == true)
                {
                    graphics.DrawImage(this.m_image, imageRectangle);
                }
                else
                {
                    if (this.m_disabledImage == null)
                    {
                        Bitmap bitmap = new Bitmap(this.m_image);
                        this.m_disabledImage = Scale(bitmap, imageRectangle.Width, imageRectangle.Height);
                    }

                    ControlPaint.DrawImageDisabled(graphics, this.m_disabledImage, imageRectangle.Top, imageRectangle.Left, Color.Transparent);
                }
            }
            base.OnPaint(e);
        }

        #endregion

        #region MethodsPrivate

        private static Bitmap Scale(Bitmap bitmap, int iScaleWidth, int iScaleHeight)
        {
            Bitmap scaledBitmap = new Bitmap(iScaleWidth, iScaleHeight);
            // Scale the bitmap in high quality mode.
            using (Graphics graphics = Graphics.FromImage(scaledBitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                graphics.DrawImage(bitmap, new Rectangle(0, 0, iScaleWidth, iScaleHeight), new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
            }

            return scaledBitmap;
        }
        
        private void FindUsbDevices()
        {
            this.m_bHasUsbDevices = false;
            this.m_ctxUsb.Items.Clear();
			string[] logicalDrives = Environment.GetLogicalDrives();
			if (logicalDrives != null)
			{
				this.m_removableDrives.Clear();
				foreach (string drive in logicalDrives)
				{
					DriveInfo driveInfo = new DriveInfo(drive);
                    if ((driveInfo != null) && (driveInfo.DriveType == DriveType.Removable))
                    {
                        if (driveInfo.IsReady == true)
                        {
                            RemovableDrive removableDrive = new RemovableDrive();
                            removableDrive.VolumeLabel = driveInfo.VolumeLabel;
                            if (string.IsNullOrEmpty(removableDrive.VolumeLabel) == true)
                            {
                                removableDrive.VolumeLabel = Properties.Resources.IDS_RemovableDisk;
                            }
                            removableDrive.DriveInfo = driveInfo;

                            StringBuilder stringBuilder = new StringBuilder(1024);

                            NativeMethods.GetVolumeNameForVolumeMountPoint(driveInfo.Name, stringBuilder, stringBuilder.Capacity);
                            if (stringBuilder.Length > 0)
                            {
                                removableDrive.VolumeName = stringBuilder.ToString();
                            }
                            string strVolume = string.Format(CultureInfo.InvariantCulture,
                                "{0} ({1})",
                                removableDrive.VolumeLabel,
                                removableDrive.Name);
                            ToolStripMenuItem menuItem = new ToolStripMenuItem(strVolume);
                            menuItem.Click += new EventHandler(ContextMenuClick);
                            menuItem.Image = this.m_image;
                            menuItem.Tag = removableDrive;
                            this.m_ctxUsb.Items.Add(menuItem);
                            this.m_removableDrives.Add(removableDrive);
                        }
                        else
                        {
                            Timer timer = new Timer();
                            timer.Interval = 1000;
                            timer.Start();
                            EventHandler eventHandler = null;
                            eventHandler = new EventHandler(delegate
                                {
                                    Trace.WriteLine("timer tick: " + DateTime.Now);
                                    if (driveInfo.IsReady == true)
                                    {
                                        timer.Tick -= eventHandler;
                                        timer.Stop();
                                        timer.Dispose();
                                        ControllerDeviceChanged(this, EventArgs.Empty);
                                    }
                                });
                            if (timer != null)
                            {
                                timer.Tick += eventHandler;
                            }
                        }
                    }
				}
			}
			
			if (this.m_removableDrives.Count > 0)
			{
				this.m_bHasUsbDevices = true;
			}

			if (this.m_backupDrives == null)
			{
				this.m_backupDrives = new Collection<RemovableDrive>();
				foreach (RemovableDrive removableDrive in this.m_removableDrives)
				{
					this.m_backupDrives.Add(removableDrive);
				}
			}
			else
			{
				if (this.m_removableDrives.Count > this.m_backupDrives.Count)
				{
					foreach (RemovableDrive removableDrive in this.m_removableDrives)
					{
						if (this.m_backupDrives.Contains(removableDrive) == false)
						{
							this.m_backupDrives.Clear();
							foreach (RemovableDrive tmpRemovableDrive in this.m_removableDrives)
							{
								this.m_backupDrives.Add(tmpRemovableDrive);
							}
							if (this.DriveAdded != null)
							{
								this.DriveAdded(this, new DriveChangeEventArgs(removableDrive));
							}
							return;
						}
					}
				}
				if (this.m_removableDrives.Count < this.m_backupDrives.Count)
				{
					foreach (RemovableDrive removableDrive in this.m_backupDrives)
					{
						if (this.m_removableDrives.Contains(removableDrive) == false)
						{
							this.m_backupDrives.Clear();
							foreach (RemovableDrive tmpRemovableDrive in this.m_removableDrives)
							{
								this.m_backupDrives.Add(tmpRemovableDrive);
							}

							if (this.DriveRemoved != null)
							{
								this.DriveRemoved(this, new DriveChangeEventArgs(removableDrive));
							}
							return;
						}
					}
				}
			}
			this.Invalidate();
        }

        private void UsbControlMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.m_ctxUsb.Items.Count > 0)
                {
                    this.m_ctxUsb.Show(this, new Point(e.X, e.Y));
                }
            }
        }
        private void ContextMenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
				RemovableDrive removableDrive = menuItem.Tag as RemovableDrive;
				if (removableDrive != null)
				{
					if (this.DriveChanges != null)
					{
						this.DriveChanges(this, new DriveChangeEventArgs(removableDrive));
					}
				}
            }
        }

        private void ControllerDeviceChanged(object sender, EventArgs e)
        {
            FindUsbDevices();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        internal class DeviceController : NativeWindow
        {
            #region Events
            public event EventHandler<EventArgs> DeviceChanges;
            #endregion

            #region FieldsPrivate
            private Form m_parentForm;
            #endregion

            #region MethodsPublic
            public DeviceController(Form parentForm)
            {
                this.m_parentForm = parentForm;
                this.AssignHandle(this.m_parentForm.Handle);
                this.m_parentForm.HandleDestroyed += new EventHandler(this.ParentFormHandleDestroyed);
            }
            #endregion

            #region MethodsProtected
            /// <summary>
            /// Invokes the default window procedure associated with this window.
            /// </summary>
            /// <param name="m">A Message that is associated with the current Windows message.</param>
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == NativeMethods.WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case NativeMethods.DBT_DEVICEARRIVAL:
                            break;
                        case NativeMethods.DBT_DEVICEREMOVECOMPLETE:
                            
                            break;
                    }
                    if (this.DeviceChanges != null)
                    {
                        this.DeviceChanges(this, EventArgs.Empty);
                    }
                }
                base.WndProc(ref m);
            }
            #endregion

            #region MethodsPrivate
            private void ParentFormHandleDestroyed(object sender, EventArgs e)
            {
                // Window was destroyed, release hook.
                ReleaseHandle();
            }
            #endregion
        }
        
        #endregion
    }
}
