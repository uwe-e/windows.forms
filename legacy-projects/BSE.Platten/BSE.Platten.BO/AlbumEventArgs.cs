using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Platten.BO
{
    public class AlbumEventArgs : EventArgs
    {
        #region Properties
        public int AlbumId
        {
            get;
            private set;
        }
        #endregion

        #region MethodsPublic
        public AlbumEventArgs(int AlbumId)
        {
            this.AlbumId = AlbumId;
        }
        #endregion
    }
}
