using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.CDDrives
{
    public class ReadProgressEventArgs : EventArgs
    {
        #region FieldsPrivate
        private uint m_Bytes2Read;
        private uint m_BytesRead;
        private int m_iTrack;
        private uint m_iSeconds2Read;
        #endregion

        #region Properties
        public uint Bytes2Read
        {
            get
            {
                return m_Bytes2Read;
            }
        }
        public uint BytesRead
        {
            get
            {
                return m_BytesRead;
            }
        }

        public uint Seconds2Read
        {
            get
            {
                return m_iSeconds2Read;
            }
        }

        public bool CancelRead
        {
            get;
            set;
        }
        public int Track
        {
            get { return m_iTrack; }
        }
        #endregion

        #region MethodsPublic
        public ReadProgressEventArgs(uint bytes2Read, uint bytesRead, uint seconds2Read, int iTrack)
        {
            this.m_Bytes2Read = bytes2Read;
            this.m_BytesRead = bytesRead;
            this.m_iSeconds2Read = seconds2Read;
            this.m_iTrack = iTrack;
        }
        #endregion
    }
}
