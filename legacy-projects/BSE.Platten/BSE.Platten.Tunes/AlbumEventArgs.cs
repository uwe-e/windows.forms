using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;

namespace BSE.Platten.Tunes
{
    public class AlbumEventArgs : EventArgs
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private Album m_album;
        #endregion

        #region Properties
        public Album Album
        {
            get
            {
                return this.m_album;
            }
        }
        #endregion

        #region MethodsPublic
        public AlbumEventArgs(Album album)
        {
            this.m_album = album;
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        #endregion

    }
}
