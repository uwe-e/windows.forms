using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class AlbumPanelViewModel : ListViewModelBase
    {
        #region FieldsPrivate
        private Album m_album;
        #endregion

        #region Properties
        public Album Album
        {
            get
            {
                return m_album;
            }
            set
            {
                this.m_album = value;
                this.OnPropertyChanged("Album");
                if (this.m_album != null)
                {
                    CTrack[] tracks = this.m_album.Tracks;
                    if (tracks != null)
                    {
                        List<CTrack> trackList = tracks.ToList();
                        trackList.ForEach(delegate(CTrack track)
                        {
                            track.Interpret = this.m_album.Interpret;
                            track.Album = this.m_album.Title;
                            track.Genre = this.m_album.Genre;
                        });
                        this.Tracks = new System.Collections.ObjectModel.ObservableCollection<CTrack>(trackList);
                    }
                }
            }
        }
        #endregion

        #region MethodsPublic
        public AlbumPanelViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            this.Mediator.Register(this);
        }
        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageCurrentAlbumChanged, ParameterType = typeof(Album))]
        public void SetCurrentAlbum(Album album)
        {
            this.Album = album;
        } 
        #endregion
    }
}
