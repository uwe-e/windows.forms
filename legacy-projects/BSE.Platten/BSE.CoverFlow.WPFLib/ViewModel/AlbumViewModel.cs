using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;
using System.Windows.Media;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class AlbumViewModel : TreeViewItemViewModel
    {
        #region FieldsPrivate
        private readonly Album m_album;
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                return this.m_album.Title;
            }
        }
        public int Id
        {
            get
            {
                return this.m_album.AlbumId;
            }
        }
        public ImageSource CoverSource
        {
            get
            {
                return this.m_album.CoverSource;
            }
        }
        public Album Album
        {
            get { return this.m_album; }
        }
        #endregion

        #region MethodsPublic
        public AlbumViewModel(Album album, ArtistViewModel parentInterpret)
            : base(parentInterpret, true)
        {
            this.m_album = album;
        }
        #endregion
    }
}
