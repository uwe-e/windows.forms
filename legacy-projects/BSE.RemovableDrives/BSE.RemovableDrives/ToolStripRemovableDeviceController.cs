using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.ComponentModel;

namespace BSE.RemovableDrives
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public class ToolStripRemovableDeviceController : ToolStripControlHost
    {
        #region Events
        public event EventHandler<DriveChangeEventArgs> DriveChanges;
		public event EventHandler<DriveChangeEventArgs> DriveAdded;
		public event EventHandler<DriveChangeEventArgs> DriveRemoved;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the RemovableDeviceController
        /// </summary>
		public RemovableDeviceController RemovableDeviceController
        {
			get { return base.Control as RemovableDeviceController; }
        }
        /// <summary>
        /// Gets or sets the image that is displayed on a <see cref="ToolStripRemovableDeviceController"/>.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.Drawing.Image"/>
        /// The <see cref="Image"/> to be displayed.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Image Image
        {
            get { return RemovableDeviceController.Image; }
            set { RemovableDeviceController.Image = value; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the ToolStripTrackBar class.
        /// </summary>
        public ToolStripRemovableDeviceController()
            : base(CreateControlInstance())
        {
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Gets the default size of the item.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.Drawing.Size"/>
        /// The default Size of the <see cref="ToolStripRemovableDeviceController"/>.
        /// </value>
        protected override Size DefaultSize
        {
            get { return new Size(23, 23); }
        }
        /// <summary>
        /// Gets the spacing between the <see cref="ToolStripRemovableDeviceController"/> and adjacent items.
        /// </summary>
        protected override Padding DefaultMargin
        {
            get
            {
                if ((base.Owner != null) && (base.Owner is StatusStrip))
                {
                    return new Padding(0, 3, 0, 2);
                }
                return new Padding(1, 2, 1, 1);
            }
        }
        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
			RemovableDeviceController removableDeviceController = control as RemovableDeviceController;
            if (removableDeviceController != null)
            {
                removableDeviceController.DriveChanges += new EventHandler<DriveChangeEventArgs>(OnDriveChanges);
				removableDeviceController.DriveAdded += new EventHandler<DriveChangeEventArgs>(OnDriveAdded);
				removableDeviceController.DriveRemoved += new EventHandler<DriveChangeEventArgs>(OnDriveRemoved);
            }
        }
        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
			RemovableDeviceController removableDeviceController = control as RemovableDeviceController;
            if (removableDeviceController != null)
            {
                removableDeviceController.DriveChanges -= new EventHandler<DriveChangeEventArgs>(OnDriveChanges);
				removableDeviceController.DriveAdded -= new EventHandler<DriveChangeEventArgs>(OnDriveAdded);
				removableDeviceController.DriveRemoved -= new EventHandler<DriveChangeEventArgs>(OnDriveRemoved);
            }
        }
        #endregion

        #region MethodsPrivate

		private void OnDriveChanges(object sender, DriveChangeEventArgs e)
        {
            if (this.DriveChanges != null)
            {
                this.DriveChanges(sender, e);
            }
        }

		private void OnDriveAdded(object sender, DriveChangeEventArgs e)
		{
			if (this.DriveAdded != null)
			{
				this.DriveAdded(sender, e);
			}
		}
		
		private void OnDriveRemoved(object sender, DriveChangeEventArgs e)
		{
			if (this.DriveRemoved != null)
			{
				this.DriveRemoved(sender, e);
			}
		}
        private static Control CreateControlInstance()
        {
			RemovableDeviceController removableDeviceController = new RemovableDeviceController();
            removableDeviceController.Size = new Size(22, 16);
            return removableDeviceController;
        }
        #endregion

    }
}
