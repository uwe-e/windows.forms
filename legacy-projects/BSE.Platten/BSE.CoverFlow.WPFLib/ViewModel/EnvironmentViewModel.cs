using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class EnvironmentViewModel : ViewModelBase
    {
        #region FieldsPrivate
        private Album m_currentAlbum;
        private static readonly Mediator.Mediator m_mediator = new Mediator.Mediator();
        #endregion

        #region Properties
        public Mediator.Mediator Mediator
        {
            get
            {
                return m_mediator;
            }
        }
        public Album CurrentAlbum
        {
            get
            {
                return this.m_currentAlbum;
            }
            set
            {
                this.m_currentAlbum = value;
                base.OnPropertyChanged("CurrentAlbum");
            }
        }
        public BSE.Platten.BO.Environment Environment
        {
            get;
            private set;
        }
        #endregion

        #region MethodsPublic
        public EnvironmentViewModel()
        {
        }
        public EnvironmentViewModel(BSE.Platten.BO.Environment environment) : this()
        {
            this.Environment = environment;
        }
        #endregion

        #region MethodsProtected
        protected Album GetAlbumById(int iAlbumId)
        {
            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
            Album album = tunesBusinessObject.GetAlbumById(iAlbumId);
            if (album != null && album.Tracks != null)
            {
                string strAudioDirectory = Album.GetAudioHomeDirectory(this.Environment);
                if (string.IsNullOrEmpty(strAudioDirectory) == false)
                {
                    List<CTrack> tracks = null;
                    album.Tracks.ToList().ForEach(delegate(CTrack track)
                    {
                        if (track != null)
                        {
                            if (string.IsNullOrEmpty(track.FileFullName) == false && string.IsNullOrEmpty(track.FileName) == false)
                            {
                                if (tracks == null)
                                {
                                    tracks = new List<CTrack>();
                                }
                                track.ThumbNail = album.Thumbnail;
                                track.FileFullName = System.IO.Path.Combine(strAudioDirectory, track.FileName);
                                tracks.Add(track);
                            }
                        }
                    });
                    album.Tracks = tracks.ToArray();
                }
            }
            return album;
        }
        #endregion
    }
}
