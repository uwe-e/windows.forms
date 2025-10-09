using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    public class PlaylistSelectionChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private int m_iPlaylistPosition;

        #endregion

        #region Properties

        public int PlaylistPosition
        {
            get { return this.m_iPlaylistPosition; }
            set { this.m_iPlaylistPosition = value; }
        }

        #endregion

        #region MethodsOublic
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public PlaylistSelectionChangeEventArgs(int iPlaylistPosition)
        {
            this.m_iPlaylistPosition = iPlaylistPosition;
        }

        #endregion
    }
}
