using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.CDDrives
{
    internal class DeviceChangeEventArgs : EventArgs
    {
        #region FieldsPrivate
        private DeviceChangeEventType m_deviceChangeEventType;
        private char m_Drive;
        #endregion

        #region Properties
        public char Drive
        {
            get
            {
                return m_Drive;
            }
        }
        public DeviceChangeEventType DeviceChangeEventType
        {
            get
            {
                return m_deviceChangeEventType;
            }
        }
        #endregion

        #region MethodsPublic
        public DeviceChangeEventArgs(char drive, DeviceChangeEventType deviceChangeEventType)
        {
            this.m_Drive = drive;
            this.m_deviceChangeEventType = deviceChangeEventType;
        }
        #endregion
    }
}
