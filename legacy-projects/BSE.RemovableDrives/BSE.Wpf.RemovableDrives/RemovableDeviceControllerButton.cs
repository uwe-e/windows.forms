using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows;
using System.Diagnostics;
using System.Windows.Media;
using System.ComponentModel;
using BSE.Wpf.Windows.Controls;
using System.IO;
using System.Globalization;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace BSE.Wpf.RemovableDrives
{
    public class RemovableDeviceControllerButton : DropDownButton
    {
        #region Events
        /// <summary>
        /// Identifies the <see cref="DriveSelected"/> routed event.
        /// </summary>
        public static readonly RoutedEvent DriveSelectedEvent = EventManager.RegisterRoutedEvent(
                    "DriveSelected", RoutingStrategy.Bubble,
                    typeof(DriveChangeEventHandler), typeof(RemovableDeviceControllerButton));

        /// <summary>
        /// Identifies the <see cref="DriveRemoved"/> routed event.
        /// </summary>
        public static readonly RoutedEvent DriveRemovedEvent = EventManager.RegisterRoutedEvent(
                    "DriveRemoved", RoutingStrategy.Bubble,
                    typeof(DriveChangeEventHandler), typeof(RemovableDeviceControllerButton));
        /// <summary>
        /// Identifies the <see cref="DriveAdded"/> routed event.
        /// </summary>
        public static readonly RoutedEvent DriveAddedEvent = EventManager.RegisterRoutedEvent(
                    "DriveAdded", RoutingStrategy.Bubble,
                    typeof(DriveChangeEventHandler), typeof(RemovableDeviceControllerButton));

        /// <summary>
        /// Occurs when a removable drive in a menuitem was selected.
        /// </summary>
        public event DriveChangeEventHandler DriveSelected
        {
            add { this.AddHandler(RemovableDeviceControllerButton.DriveSelectedEvent, value, false); }
            remove { this.RemoveHandler(RemovableDeviceControllerButton.DriveSelectedEvent, value); }
        }
        /// <summary>
        /// Occurs when a removable drive in a menuitem was removed.
        /// </summary>
        public event DriveChangeEventHandler DriveRemoved
        {
            add { this.AddHandler(RemovableDeviceControllerButton.DriveRemovedEvent, value, false); }
            remove { this.RemoveHandler(RemovableDeviceControllerButton.DriveRemovedEvent, value); }
        }
        /// <summary>
        /// Occurs when a removable drive in a menuitem was added.
        /// </summary>
        public event DriveChangeEventHandler DriveAdded
        {
            add { this.AddHandler(RemovableDeviceControllerButton.DriveAddedEvent, value, false); }
            remove { this.RemoveHandler(RemovableDeviceControllerButton.DriveAddedEvent, value); }
        }
        #endregion

        #region FieldsPrivate
        private Collection<RemovableDrive> m_removableDrives;
        private Collection<RemovableDrive> m_backupDrives;
        #endregion

        #region MethodsProtected
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.m_removableDrives = new Collection<RemovableDrive>();
            this.IsEnabled = false;
            this.DropDownContextMenu = new ContextMenu();
            this.Loaded += new RoutedEventHandler(RemovableDeviceController_Loaded);
        }
        #endregion

        #region MethodsPrivate
        private void RemovableDeviceController_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this) == false)
            {
                System.Windows.Forms.Form form = WindowsFormsHelper.FindForm(this);
                if (form != null)
                {
                    DeviceController deviceController = new DeviceController(form.Handle);
                    deviceController.DeviceChanged += new EventHandler<EventArgs>(OnDeviceChanged);
                }
                this.FindUsbDevices();
            }
        }

        private void OnDeviceChanged(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            this.DropDownContextMenu.Items.Clear();
            this.FindUsbDevices();
        }

        private void FindUsbDevices()
        {
            this.m_removableDrives.Clear();
            string[] logicalDrives = Environment.GetLogicalDrives();
            if (logicalDrives != null)
            {
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
                            MenuItem menuItem = new MenuItem();
                            menuItem.Header = strVolume;
                            menuItem.Click += new RoutedEventHandler(OnMenuItemClick);
                            menuItem.DataContext = removableDrive;
                            this.m_removableDrives.Add(removableDrive);
                            this.DropDownContextMenu.Items.Add(menuItem);
                            this.IsEnabled = true;
                        }
                        else
                        {
                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Start();
                            EventHandler eventHandler = null;
                            eventHandler = new EventHandler(delegate
                            {
                                Trace.WriteLine("timer tick: " + DateTime.Now);
                                if (driveInfo.IsReady == true)
                                {
                                    timer.Tick -= eventHandler;
                                    timer.Stop();
                                    timer = null;
                                    OnDeviceChanged(this, EventArgs.Empty);
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
                            DriveChangeEventArgs driveAddedEventArgs = new DriveChangeEventArgs(
                                RemovableDeviceControllerButton.DriveAddedEvent,
                                removableDrive);
                            this.RaiseEvent(driveAddedEventArgs);
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
                            DriveChangeEventArgs driveRemovedEventArgs = new DriveChangeEventArgs(
                                RemovableDeviceControllerButton.DriveRemovedEvent,
                                removableDrive);
                            this.RaiseEvent(driveRemovedEventArgs);
                            return;
                        }
                    }
                }
            }
        }

        private void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                RemovableDrive removableDrive = menuItem.DataContext as RemovableDrive;
                if (removableDrive != null)
                {
                    DriveChangeEventArgs driveChangeEventArgs = new DriveChangeEventArgs(
                        RemovableDeviceControllerButton.DriveSelectedEvent,
                        removableDrive);
                    this.RaiseEvent(driveChangeEventArgs);
                }
            }
        }

        #endregion
    }
}
