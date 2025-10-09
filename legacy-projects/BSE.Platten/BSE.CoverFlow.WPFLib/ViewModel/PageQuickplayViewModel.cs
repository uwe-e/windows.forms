using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Wpf.Windows.Controls.ImageFlow;
using BSE.CoverFlow.WPFLib.ImageFlowPanel;
using System.IO;
using BSE.Platten.BO;
using BSE.CoverFlow.WPFLib.Input;
using System.Windows.Input;
using BSE.CoverFlow.WPFLib.Properties;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    //public class PageQuickplayViewModel : EnvironmentViewModel, IPageable
    public class PageQuickplayViewModel : PageViewModel
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private BSE.Platten.BO.CInterpretData[] m_interpretData;
        private NewAlbumsViewModel m_newAlbumsViewModel;
        private HistoryViewModel m_historyViewModel;
        private CTrack m_currentTrack;
        private System.Collections.IEnumerable m_covers;
        private IImageFlowItem m_selectedImageFlowItem;
        private RelayCommand m_selectedItemCommand;
        //private bool m_bIsVisible;
        #endregion

        #region Properties
        public NewAlbumsViewModel NewAlbumsViewModel
        {
            get
            {
                return this.m_newAlbumsViewModel;
            }
        }
        public HistoryViewModel HistoryViewModel
        {
            get
            {
                return this.m_historyViewModel;
            }
        }
        public BSE.Platten.BO.CInterpretData[] InterpretData
        {
            get
            {
                return this.m_interpretData;
            }
            set
            {
                this.m_interpretData = value;
                base.OnPropertyChanged("InterpretData");
                this.InterpetDataChanged(this, new System.ComponentModel.PropertyChangedEventArgs("InterpretData"));
            }
        }
        public CTrack CurrentTrack
        {
            get
            {
                return this.m_currentTrack;
            }
            set
            {
                this.m_currentTrack = value;
                this.SetSelectedCoverItem();
                base.OnPropertyChanged("CurrentTrack");
            }
        }

        public System.Collections.IEnumerable Covers
        {
            get
            {
                return this.m_covers;
            }
            set
            {
                this.m_covers = value;
                this.OnPropertyChanged("Covers");
            }
        }
        public IImageFlowItem SelectedImageFlowItem
        {
            get
            {
                return this.m_selectedImageFlowItem;
            }
            set
            {
                this.m_selectedImageFlowItem = value;
                base.OnPropertyChanged("SelectedImageFlowItem");
            }
        }
        public DirectoryInfo ImageFlowCache
        {
            get
            {
                return BSE.Platten.BO.Cache.ImageFlowCache.CacheDirectory;
            }
        }
        public ICommand SelectedItemCommand
        {
            get
            {
                if (this.m_selectedItemCommand == null)
                {
                    this.m_selectedItemCommand = new RelayCommand(
                        this.SelectedItem);
                }
                return this.m_selectedItemCommand;
            }
        }
        #endregion

        #region MethodsPublic
        public PageQuickplayViewModel()
        {
        }
        public PageQuickplayViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            this.m_newAlbumsViewModel = new NewAlbumsViewModel(environment);
            this.m_historyViewModel = new HistoryViewModel(environment);
            this.Header = Resources.IDS_PageQuickplayHeader;
            Mediator.Register(this);
        }
        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageInterpretDataChanged, ParameterType = typeof(BSE.Platten.BO.CInterpretData[]))]
        public void SetInterpretData(BSE.Platten.BO.CInterpretData[] interpretData)
        {
            this.InterpretData = interpretData;
        }
        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageCurrentTrackChanged, ParameterType = typeof(BSE.Platten.BO.CTrack))]
        public void SetCurrentTrack(BSE.Platten.BO.CTrack currentTrack)
        {
            this.SetSelectedCoverItem(currentTrack);
        }
        #endregion

        #region MethodsPrivate
        private void InterpetDataChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.InterpretData != null)
            {
                this.InvokeAsynchronouslyInBackground(() =>
                {
                    this.Covers = (from interpret in this.InterpretData
                                   from album in interpret.Albums
                                   select new ImageFlowItemFromDatabase()
                                   {
                                       AlbumId = album.AlbumId,
                                       ConnectionString = this.Environment.GetConnectionString()
                                   }).ToList();
                });
            }
        }
        private void SetSelectedCoverItem(CTrack track)
        {
            if (this.Covers != null && track != null)
            {
                this.InvokeAsynchronously(() =>
                {
                    this.SelectedImageFlowItem = this.Covers
                        .Cast<ImageFlowItemFromDatabase>()
                        .Where(item => item.AlbumId == track.TitelId).FirstOrDefault();
                });
            }
        }
        private void SetSelectedCoverItem()
        {
            if (this.Covers != null && this.CurrentTrack != null)
            {
                this.InvokeAsynchronously(() =>
                {
                    this.SelectedImageFlowItem = this.Covers
                        .Cast<ImageFlowItemFromDatabase>()
                        .Where(item => item.AlbumId == this.CurrentTrack.TitelId).FirstOrDefault();
                });
            }
        }
        private void SelectedItem(object parameter)
        {
            ImageFlowItemFromDatabase imageFlowItem = parameter as ImageFlowItemFromDatabase;
            if (imageFlowItem != null)
            {
                this.Invoke(() =>
                {
                    Album album = this.GetAlbumById(imageFlowItem.AlbumId);
                    this.Mediator.NotifyColleagues<Album>(MediatorMessages.MessageCurrentAlbumChanged, album);
                });
            }
        }
        #endregion

    }
}
