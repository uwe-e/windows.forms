using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BSE.Wpf.RemovableDrives
{
    public class DriveChangeEventArgs : RoutedEventArgs
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private readonly RemovableDrive m_removableDrive;
        #endregion

        #region Properties
        public RemovableDrive RemovableDrive
        {
            get
            {
                return this.m_removableDrive;
            }
        }

        #endregion

        #region MethodsPublic
        public DriveChangeEventArgs(RoutedEvent routedEvent, RemovableDrive removableDrive)
            : base(routedEvent)
        {
            this.m_removableDrive = removableDrive;
        }
        #endregion

        #region MethodsProtected
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            DriveChangeEventHandler handler = (DriveChangeEventHandler)genericHandler;
            handler(genericTarget, this);
        }
        #endregion
    }
}
