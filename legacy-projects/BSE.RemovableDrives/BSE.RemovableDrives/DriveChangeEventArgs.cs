using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BSE.RemovableDrives
{
    public class DriveChangeEventArgs : System.EventArgs
    {
        #region FieldsPrivate
		private RemovableDrive m_removableDrive;
        #endregion

        #region Properties
		public RemovableDrive RemovableDrive
        {
			get { return this.m_removableDrive; }
        }
        #endregion

        #region MethodsPublic
		public DriveChangeEventArgs(RemovableDrive removableDrive)
        {
			this.m_removableDrive = removableDrive;
        }
        #endregion
    }
}
