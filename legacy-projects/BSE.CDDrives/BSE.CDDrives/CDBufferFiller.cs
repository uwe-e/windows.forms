using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.CDDrives
{
    internal class CDBufferFiller
    {
        #region FieldsPrivate
        private int m_iWritePosition;
        private byte[] m_aBuffer;
        #endregion

        #region MethodsPublic
        public CDBufferFiller(byte[] aBuffer)
        {
            this.m_aBuffer = aBuffer;
        }
        public void OnCDDataRead(object sender, DataReadEventArgs ea)
        {
            Buffer.BlockCopy(ea.Data, 0, this.m_aBuffer, this.m_iWritePosition, (int)ea.DataSize);
            m_iWritePosition += (int)ea.DataSize;
        }
        #endregion
    }
}
