using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BSE.Platten.Audio;
using System.Windows.Threading;
using System.Globalization;
using System.Windows.Controls.Primitives;
using BSE.Platten.Common;
using BSE.Platten.BO;
using System.Linq;
using BSE.Wpf.RemovableDrives;

namespace BSE.CoverFlow.WPFLib.PlayerPanel
{
	/// <summary>
	/// Interaktionslogik für Player.xaml
	/// </summary>
	public partial class Player : UserControl
    {
        #region Events
        /// <summary>
        /// Identifies the <see cref="RemovableDriveChanged"/> routed event.
        /// </summary>
        public static readonly RoutedEvent RemovableDriveChangedEvent = EventManager.RegisterRoutedEvent(
            "RemovableDriveChanged", RoutingStrategy.Bubble, typeof(DriveChangeEventHandler), typeof(Player));
        /// <summary>
        /// Occurs when a removable drive in a menuitem was selected.
        /// </summary>
        public event DriveChangeEventHandler RemovableDriveChanged
        {
            add { this.AddHandler(Player.RemovableDriveChangedEvent, value, false); }
            remove { this.RemoveHandler(Player.RemovableDriveChangedEvent, value); }
        }
        /// <summary>
        /// Identifies the <see cref="RemovableDriveAdded"/> routed event.
        /// </summary>
        public static readonly RoutedEvent RemovableDriveAddedEvent = EventManager.RegisterRoutedEvent(
            "RemovableDriveAdded", RoutingStrategy.Bubble, typeof(DriveChangeEventHandler), typeof(Player));
        /// <summary>
        /// Occurs when a removable drive in a menuitem was added.
        /// </summary>
        public event DriveChangeEventHandler RemovableDriveAdded
        {
            add { this.AddHandler(Player.RemovableDriveAddedEvent, value, false); }
            remove { this.RemoveHandler(Player.RemovableDriveAddedEvent, value); }
        }
        /// <summary>
        /// Identifies the <see cref="RemovableDriveAdded"/> routed event.
        /// </summary>
        public static readonly RoutedEvent RemovableDriveRemovedEvent = EventManager.RegisterRoutedEvent(
            "RemovableDriveRemoved", RoutingStrategy.Bubble, typeof(DriveChangeEventHandler), typeof(Player));
        /// <summary>
        /// Occurs when a removable drive in a menuitem was added.
        /// </summary>
        public event DriveChangeEventHandler RemovableDriveRemoved
        {
            add { this.AddHandler(Player.RemovableDriveRemovedEvent, value, false); }
            remove { this.RemoveHandler(Player.RemovableDriveRemovedEvent, value); }
        }
        #endregion

        #region Constants
        #endregion

        #region FieldsPublic

        public static readonly DependencyProperty IsHostAvailableProperty = DependencyProperty.Register(
            "IsHostAvailable",
            typeof(bool),
            typeof(Player));

        #endregion


        #region Properties

        public bool IsHostAvailable
        {
            get
            {
                return (bool)this.GetValue(IsHostAvailableProperty);
            }
            set
            {
                this.SetValue(IsHostAvailableProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        public Player()
		{
			this.InitializeComponent();
            DatabaseHostController.HostAvailabilityInitialized += new EventHandler<EventArgs>(OnHostAvailabilityInitialized);
            DatabaseHostController.HostAvailabilityChanged += new EventHandler<HostAvailableEventArgs>(OnHostAvailabilityChanged);
		}
        
        #endregion

        #region MethodsPrivate

        private void OnHostAvailabilityInitialized(object sender, EventArgs e)
        {
            this.IsHostAvailable = DatabaseHostController.IsHostAvailable;
            this.IsEnabled = this.IsHostAvailable;
        }

        private void OnHostAvailabilityChanged(object sender, HostAvailableEventArgs e)
        {
            DatabaseHostAvailability databaseHostavailability = e.DatabaseHostAvailability;
            if (databaseHostavailability != null)
            {
                Dispatcher.Invoke(
                    DispatcherPriority.Normal,
                    (Action)(() =>
                    {
                        this.IsHostAvailable = databaseHostavailability.IsAvailable;
                        this.IsEnabled = this.IsHostAvailable;
                    })
                        );
            }
        }

        private void OnRemovableDriveDriveSelected(object sender, Wpf.RemovableDrives.DriveChangeEventArgs e)
        {
            if (e.RemovableDrive != null)
            {
                DriveChangeEventArgs driveChangeEventArgs = new DriveChangeEventArgs(
                            Player.RemovableDriveChangedEvent,
                            e.RemovableDrive);
                this.RaiseEvent(driveChangeEventArgs);
            }
        }
        
        private void OnRemovableDriveDriveRemoved(object sender, Wpf.RemovableDrives.DriveChangeEventArgs e)
        {
            if (e.RemovableDrive != null)
            {
                DriveChangeEventArgs driveChangeEventArgs = new DriveChangeEventArgs(
                            Player.RemovableDriveRemovedEvent,
                            e.RemovableDrive);
                this.RaiseEvent(driveChangeEventArgs);
            }
        }
        
        private void OnRemovableDriveDriveAdded(object sender, Wpf.RemovableDrives.DriveChangeEventArgs e)
        {
            if (e.RemovableDrive != null)
            {
                DriveChangeEventArgs driveChangeEventArgs = new DriveChangeEventArgs(
                            Player.RemovableDriveAddedEvent,
                            e.RemovableDrive);
                this.RaiseEvent(driveChangeEventArgs);
            }
        }
        #endregion
        
	}
}