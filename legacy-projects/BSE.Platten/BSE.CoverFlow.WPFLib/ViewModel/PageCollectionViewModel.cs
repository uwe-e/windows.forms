using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.CoverFlow.WPFLib.Input;
using BSE.Platten.BO;
using BSE.CoverFlow.WPFLib.Properties;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    //public class PageCollectionViewModel : EnvironmentViewModel, IPageable
    public class PageCollectionViewModel : PageViewModel
    {
        #region FieldsPrivate
        private BSE.Platten.BO.CInterpretData[] m_interpretData;
        private ArtistTreeViewModel m_artistTreeViewModel;
        private AlbumPanelViewModel m_albumPanelViewModel;
        private PlaylistViewModel m_playlistViewModel;
        #endregion

        #region Properties

        public BSE.Platten.BO.CInterpretData[] InterpretData
        {
            get
            {
                return this.m_interpretData;
            }
            set
            {
                this.Invoke(() =>
                {
                    this.m_interpretData = value;
                    this.m_artistTreeViewModel.InterpretData = value;
                    base.OnPropertyChanged("InterpretData");
                });
            }
        }

        public ArtistTreeViewModel ArtistTreeViewModel
        {
            get
            {
                return this.m_artistTreeViewModel;
            }
        }
        public AlbumPanelViewModel AlbumPanelViewModel
        {
            get
            {
                return this.m_albumPanelViewModel;
            }
        }
        public PlaylistViewModel PlaylistViewModel
        {
            get
            {
                return this.m_playlistViewModel;
            }
        }
        public string TabItemHeaderPlaylists
        {
            get
            {
                return Resources.IDS_TabItemHeaderPlaylists;
            }
        }
        #endregion

        #region MethodsPublic
        public PageCollectionViewModel()
        {
        }
        public PageCollectionViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            this.m_artistTreeViewModel = new ArtistTreeViewModel(environment);
            this.m_albumPanelViewModel = new AlbumPanelViewModel(environment);
            this.m_playlistViewModel = new PlaylistViewModel(environment);
            this.m_artistTreeViewModel.CurrentAlbum = this.CurrentAlbum;
            this.Header = Resources.IDS_PageCollectionHeader;
            Mediator.Register(this);

            //System.Windows.Forms.Application.
            //System.Windows.Application.Current;
        }
        //[BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageInterpretDataChanged, ParameterType = typeof(BSE.Platten.BO.CInterpretData[]))]
        //public void SetInterpretData(BSE.Platten.BO.CInterpretData[] interpretData)
        //{
        //    this.InterpretData = interpretData;
        //}
        #endregion

        #region MethodsPrivate

        private void OnAlbumSelectionChanged(object sender, BSE.Platten.BO.AlbumEventArgs e)
        {
            if (this.CurrentAlbum == null || this.CurrentAlbum.AlbumId.Equals(e.AlbumId) == false)
            {
                this.InvokeAsynchronously(() =>
                {
                    this.CurrentAlbum = this.GetAlbumById(e.AlbumId);
                    this.m_albumPanelViewModel.Album = this.CurrentAlbum;
                });
            }
        }
        #endregion

    }
}
