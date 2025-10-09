using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.CoverFlow.WPFLib.Input;
using System.Windows.Input;
using BSE.Platten.BO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using BSE.CoverFlow.WPFLib.Extension;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class DesktopViewModel : EnvironmentViewModel
    {
        #region FieldsPrivate
        private PageQuickplayViewModel m_quickplayViewModel;
        private PageCollectionViewModel m_collectionViewModel;
        private PlayerManagerViewModel m_playerManagerViewModel;
        //private TrackCollection m_trackCollectionByFilterSettings;
        private ObservableCollection<PageViewModel> m_pages;
        private ObservableCollection<PageViewModel> m_history;
        private ICollectionView m_pagesView;
        //private CTrack m_currentTrack;
        private RelayCommand m_historyBackCommand;
        //private RelayCommand m_switchToQuickplayCommand;
        //private RelayCommand m_switchToCollectionCommand;
        private BSE.Platten.BO.CInterpretData[] m_interpretData;
        #endregion

        #region Properties
        public ICollectionView PagesView
        {
            get
            {
                if (this.m_pagesView == null)
                {
                    this.m_pagesView = CollectionViewSource.GetDefaultView(this.Pages);
                }
                return this.m_pagesView;
            }
        }
        public ObservableCollection<PageViewModel> Pages
        {
            get
            {
                if (m_pages == null)
                {
                    m_pages = new ObservableCollection<PageViewModel>();
                }
                return m_pages;
            }
        }
        public ObservableCollection<PageViewModel> History
        {
            get
            {
                if (this.m_history == null)
                {
                    this.m_history = new ObservableCollection<PageViewModel>();
                }
                return this.m_history;
            }
        }
        public PageQuickplayViewModel QuickplayViewModel
        {
            get
            {
                //return null;
                return this.m_quickplayViewModel;
            }
        }
        public PageCollectionViewModel CollectionViewModel
        {
            get
            {
                //return null;
                return this.m_collectionViewModel;
            }
        }
        public PlayerManagerViewModel PlayerManagerViewModel
        {
            get
            {
                return this.m_playerManagerViewModel;
            }
        }
        public BSE.Platten.BO.CInterpretData[] InterpretData
        {
            get
            {
                //return this.m_quickplayViewModel.InterpretData;
                return this.m_interpretData;
            }
            set
            {
                this.m_interpretData = value;
                Mediator.NotifyColleagues<BSE.Platten.BO.CInterpretData[]>(
                                MediatorMessages.MessageInterpretDataChanged,
                                value);
                //this.m_quickplayViewModel.InterpretData = value;
                //this.m_collectionViewModel.InterpretData = value;
                base.OnPropertyChanged("InterpretData");
            }
        }
        //public bool IsQuickplayViewVisible
        //{
        //    get
        //    {
        //        return false;
        //        //return this.m_quickplayViewModel.IsVisible;
        //    }
        //    set
        //    {
        //        //this.m_quickplayViewModel.IsVisible = value;
        //        base.OnPropertyChanged("IsQuickplayViewVisible");
        //    }
        //}

        //public bool IsCollectionViewVisible
        //{
        //    get
        //    {
        //        return false;
        //        //return this.m_collectionViewModel.IsVisible;
        //    }
        //    set
        //    {
        //        //this.m_collectionViewModel.IsVisible = value;
        //        this.OnPropertyChanged("IsCollectionViewVisible");
        //    }
        //}

        //public TrackCollection TrackCollectionByFilterSettings
        //{
        //    get
        //    {
        //        return this.m_trackCollectionByFilterSettings;
        //    }
        //    set
        //    {
        //        this.m_trackCollectionByFilterSettings = value;
        //        base.OnPropertyChanged("TrackCollectionByFilterSettings");
        //    }
        //}
        //public CTrack CurrentTrack
        //{
        //    get
        //    {
        //        return this.m_currentTrack;
        //    }
        //    set
        //    {
        //        this.m_currentTrack = value;
        //        //this.m_quickplayViewModel.CurrentTrack = value;
        //        base.OnPropertyChanged("CurrentTrack");
        //    }
        //}
        public ICommand HistoryBackCommand
        {
            get
            {
                if (this.m_historyBackCommand == null)
                {
                    this.m_historyBackCommand = new RelayCommand(
                        this.HistoryBackCommandExceute,
                        this.HistoryBackCommandCanExecute);
                }
                return this.m_historyBackCommand;
            }
        }
        //public ICommand SwitchToQuickplayCommand
        //{
        //    get
        //    {
        //        if (this.m_switchToQuickplayCommand == null)
        //        {
        //            this.m_switchToQuickplayCommand = new RelayCommand(
        //                this.SwitchToQuickplay);
        //        }
        //        return this.m_switchToQuickplayCommand;
        //    }
        //}
        //public ICommand SwitchToCollectionCommand
        //{
        //    get
        //    {
        //        if (this.m_switchToCollectionCommand == null)
        //        {
        //            this.m_switchToCollectionCommand = new RelayCommand(
        //                this.SwitchToCollection);
        //        }
        //        return this.m_switchToCollectionCommand;
        //    }
        //}
        #endregion

        #region MethodsPublic
        public DesktopViewModel()
        {
        }
        public DesktopViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            Mediator.Register(this);
            this.m_playerManagerViewModel = new PlayerManagerViewModel(environment);
            //this.m_playerManagerViewModel.CurrentTrackChanged += new EventHandler<EventArgs>(OnCurrentTrackChanged);
            //this.m_quickplayViewModel = new PageQuickplayViewModel(environment);
            //this.m_collectionViewModel = new PageCollectionViewModel(environment);
            //this.IsQuickplayViewVisible = true;

            PageQuickplayViewModel quickplayViewModel = new PageQuickplayViewModel(environment)
            {
                IsPersistent = true
            };
            this.Pages.Add(quickplayViewModel);
            
            PageCollectionViewModel collectionViewModel = new PageCollectionViewModel(environment)
            {
                IsPersistent = true
            };
            this.Pages.Add(collectionViewModel);

this.SetActiveWorkspace(quickplayViewModel);
            //this.m_quickplayViewModel = new PageQuickplayViewModel(environment)
            //{
            //    IsPersistent = true
            //};
            //this.m_collectionViewModel = new PageCollectionViewModel(environment)
            //{
            //    IsPersistent = true
            //};

            this.PagesView.CurrentChanged += OnCurrentPageChanged;
        }

        //[BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageCurrentAlbumChanged, ParameterType = typeof(Album))]
        //public void SetCurrentAlbum(Album album)
        //{
        //    this.CurrentAlbum = album;
        //}
        
        public void SetRandomAlbum()
        {
            if (this.PlayerManagerViewModel.RandomTrackCollection != null)
            {
                this.InvokeAsynchronouslyInBackground(() =>
                    {
                        int iIndex = this.PlayerManagerViewModel.RandomTrackCollection.GetRandomIndex();
                        CTrack currentTrack = this.PlayerManagerViewModel.RandomTrackCollection[iIndex] as CTrack;
                        if (currentTrack != null)
                        {
                            Album album = this.GetAlbumById(currentTrack.TitelId);
                            if (album != null)
                            {
                                Mediator.NotifyColleagues<Album>(
                                    MediatorMessages.MessageCurrentAlbumChanged, album);
                                Mediator.NotifyColleagues<CTrack>(
                                    MediatorMessages.MessageCurrentTrackChanged, currentTrack);
                            }
                        }
                        //this.CurrentTrack = this.PlayerManagerViewModel.RandomTrackCollection[iIndex] as CTrack;
                        //if (this.CurrentTrack != null)
                        //{
                        //    Album album = this.GetAlbumById(this.CurrentTrack.TitelId);
                        //    if (album != null)
                        //    {
                        //        Mediator.NotifyColleagues<Album>(
                        //            MediatorMessages.MessageCurrentAlbumChanged, album);
                        //        Mediator.NotifyColleagues<CTrack>(
                        //            MediatorMessages.MessageCurrentTrackChanged, this.CurrentTrack);
                        //    }
                        //}
                    });
            }
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        //private void SwitchToQuickplay(object parameter)
        //{
        //    this.IsCollectionViewVisible = false;
        //    this.IsQuickplayViewVisible = true;
            
        //}
        //private void SwitchToCollection(object parameter)
        //{
        //    this.IsQuickplayViewVisible = false;
        //    this.IsCollectionViewVisible = true;
        //}
        //private void OnCurrentTrackChanged(object sender, EventArgs e)
        //{
        //    CTrack track = this.m_playerManagerViewModel.CurrentTrack;
        //    if (track != null)
        //    {
        //        this.CurrentTrack = track;
        //    }
        //}
        
        private void SetActiveWorkspace(PageViewModel page)
        {
            this.PagesView.SourceCollection
                    .Cast<PageViewModel>().ForEach(x => x.IsVisible = false);
            page.IsVisible = true;
            this.PagesView.MoveCurrentTo(page);
        }
        
        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            PageViewModel pageViewModel = this.m_pagesView.CurrentItem as PageViewModel;
            if (pageViewModel != null)
            {
                this.PagesView.SourceCollection
                    .Cast<PageViewModel>().ForEach(x => x.IsVisible = false);
                pageViewModel.IsVisible = true;
                this.History.Add(pageViewModel);
            }
        }

        private bool HistoryBackCommandCanExecute(object parameter)
        {
            return this.History.Count > 1;
        }
        private void HistoryBackCommandExceute(object parameter)
        {
            this.PagesView.CurrentChanged -= OnCurrentPageChanged;
            int iLastIndex = this.History.Count - 1;
            if (iLastIndex > 0)
            {
                int iPreLastIndex = iLastIndex - 1;
                PageViewModel lastHistoryPageViewModel = this.History[iLastIndex];
                if (lastHistoryPageViewModel != null)
                {
                    PageViewModel activePageViewMode = this.History[iPreLastIndex];
                    if (activePageViewMode != null)
                    {
                        SetActiveWorkspace(activePageViewMode);
                    }
                    this.History.RemoveAt(iLastIndex);
                }
            }
            this.PagesView.CurrentChanged += OnCurrentPageChanged;
        }
        #endregion

    }
}
