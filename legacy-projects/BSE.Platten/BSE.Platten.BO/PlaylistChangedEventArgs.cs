using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Platten.BO
{
    public class PlaylistChangedEventArgs : EventArgs
    {
		#region Properties

        public BSE.Platten.BO.Playlist PlayList
        {
            get;
            private set;
        }
		#endregion

		#region MethodsPublic

		public PlaylistChangedEventArgs(BSE.Platten.BO.Playlist playList)
		{
			this.PlayList = playList;
		}
		#endregion
    }
}
