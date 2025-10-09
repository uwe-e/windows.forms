using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Tunes
{
    public class AlbumSelectEventArgs : EventArgs
    {
        #region FieldsPrivate

        private int m_iTitelId;

        #endregion

        #region Properties

        public int TitelId
        {
            get { return this.m_iTitelId; }
        }

        #endregion

        #region MethodsPublic

        public AlbumSelectEventArgs(int iTitelId)
        {
            this.m_iTitelId = iTitelId;
        }

        #endregion
    }
}
