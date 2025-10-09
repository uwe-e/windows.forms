using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.CDDrives
{
    public class DataReadEventArgs : EventArgs
    {
        #region FieldsPrivate
        private byte[] m_Data;
        private uint m_DataSize;
        #endregion

        #region Properties
        public byte[] Data
        {
            get
            {
                return m_Data;
            }
        }
        public uint DataSize
        {
            get
            {
                return m_DataSize;
            }
        }
        #endregion

        #region MethodsPublic
        public DataReadEventArgs(byte[] data, uint size)
        {
            this.m_Data = data;
            this.m_DataSize = size;
        }
        #endregion
    }
}
