using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;
using System.Collections.ObjectModel;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class ArtistTreeViewModel : EnvironmentViewModel
    {
        #region Events
        public EventHandler<BSE.Platten.BO.AlbumEventArgs> AlbumSelectionChanged;
        #endregion

        #region FieldsPrivate
        private CInterpretData[] m_loadMessage;
        private CInterpretData[] m_interpretData;
        private ObservableCollection<ArtistViewModel> m_interprets;
        private bool m_bIsLoading;
        private BSE.CoverFlow.WPFLib.Input.RelayCommand m_controlLoadedCommand;
        private BSE.CoverFlow.WPFLib.Input.RelayCommand m_selectedItemChangedCommand;
        #endregion

        #region Properties
        public bool IsLoading
        {
            get
            {
                return this.m_bIsLoading;
            }
            set
            {
                this.m_bIsLoading = value;
                this.OnPropertyChanged("IsLoading");
            }
        }

        public ObservableCollection<ArtistViewModel> Interprets
        {
            get
            {
                if (this.m_interprets == null)
                {
                    this.m_interprets = new ObservableCollection<ArtistViewModel>();
                }
                return this.m_interprets;
            }
        }
        public CInterpretData[] LoadMessage
        {
            get
            {
                if (this.m_loadMessage == null)
                {
                    this.m_loadMessage = new CInterpretData[] {
                        new CInterpretData{ Interpret = "Load Artists.."}
                    };
                }
                return this.m_loadMessage;
            }
        }

        public CInterpretData[] InterpretData
        {
            get
            {
                return this.m_interpretData;
            }
            set
            {
                this.m_interpretData = value;
                this.OnPropertyChanged("InterpretData");
            }
        }

        public System.Windows.Input.ICommand ControlLoadedCommand
        {
            get
            {
                if (this.m_controlLoadedCommand == null)
                {
                    this.m_controlLoadedCommand = new BSE.CoverFlow.WPFLib.Input.RelayCommand(
                        this.ControlLoaded);
                }
                return this.m_controlLoadedCommand;
            }
        }
        public System.Windows.Input.ICommand SelectedItemChangedCommand
        {
            get
            {
                if (this.m_selectedItemChangedCommand == null)
                {
                    this.m_selectedItemChangedCommand = new BSE.CoverFlow.WPFLib.Input.RelayCommand(
                        this.SelectedItemChanged);
                }
                return this.m_selectedItemChangedCommand;
            }
        }
        #endregion
        
        #region MethodsPublic
        public ArtistTreeViewModel()
        {
        }
        public ArtistTreeViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            Mediator.Register(this);
            this.IsLoading = true;
        }
        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageCurrentAlbumChanged, ParameterType = typeof(Album))]
        public void SetCurrentAlbum(Album album)
        {
            this.CurrentAlbum = album;
            this.SetSelectedAlbum();

        }
        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageInterpretDataChanged, ParameterType = typeof(BSE.Platten.BO.CInterpretData[]))]
        public void SetInterpretData(BSE.Platten.BO.CInterpretData[] interpretData)
        {
            this.InterpretData = interpretData;
            //this.Invoke(() =>
            //    {
            //this.InterpretData = interpretData;
            //this.InterpretData2 = interpretData;
            //this.InterpretData = this.LoadMessage;

            //});
            //this.InvokeAsynchronously(() =>
            //    {
            //        if (interpretData != null)
            //        {
            //            interpretData.ToList().ForEach(interpret =>
            //                {
            //                    if (interpret != null)
            //                    {
            //                        this.Interprets.Add(new InterpretViewModel(interpret));
            //                    }
            //                });
            //        }
            //    });

            //System.Threading.ThreadStart start = delegate()
            //{
            //    System.Windows.Threading.DispatcherOperation op = this.Dispatcher.BeginInvoke(
            //       System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            //           {
            //               if (interpretData != null)
            //               {
            //                   interpretData.ToList().ForEach(interpret =>
            //                {
            //                    if (interpret != null)
            //                    {
            //                        this.Interprets.Add(new InterpretViewModel(interpret));
            //                    }
            //                });
            //               }
            //           }));
            //    op.Completed += (s, e) =>
            //    {
            //        this.IsLoaded = false;
            //    };

            //};
            //this.IsLoaded = true;
            //new System.Threading.Thread(start).Start();

        }
        #endregion

        #region MethodsPrivate
        private void ControlLoaded(object parameter)
        {
            System.Threading.ThreadStart start = delegate()
            {
                System.Windows.Threading.DispatcherFrame frame = new System.Windows.Threading.DispatcherFrame();
                
                System.Windows.Threading.DispatcherOperation op = this.Dispatcher.BeginInvoke(
                   System.Windows.Threading.DispatcherPriority.Background, new Action(() =>
                   {
                       if (this.InterpretData != null)
                       {
                           this.InterpretData.ToList().ForEach(interpret =>
                           {
                               if (interpret != null)
                               {
                                   this.Interprets.Add(new ArtistViewModel(interpret));
                               }
                           });
                           if (this.CurrentAlbum != null)
                           {
                               SetSelectedAlbum();
                           }
                       }
                   }));
                op.Completed += (sender, e) =>
                {
                    this.IsLoading = false;
                    frame.Continue = false;
                };
                System.Windows.Threading.Dispatcher.PushFrame(frame);
            };
            new System.Threading.Thread(start).Start();
        }

        private void SetSelectedAlbum()
        {
            if (this.Interprets != null)
            {
                ArtistViewModel interpretViewModel = this.Interprets.Where(interpret => interpret.Id.Equals(this.CurrentAlbum.InterpretId) == true).FirstOrDefault();
                if (interpretViewModel != null)
                {
                    //interpretViewModel.IsSelected = true;
                    interpretViewModel.IsExpanded = true;
                    IEnumerable<AlbumViewModel> albumViewModels = interpretViewModel.Children.Cast<AlbumViewModel>();
                    if (albumViewModels != null)
                    {
                        AlbumViewModel albumViewModel = albumViewModels.Where(album => album.Id.Equals(this.CurrentAlbum.AlbumId) == true).FirstOrDefault();
                        if (albumViewModel != null)
                        {
                            albumViewModel.IsSelected = true;
                        }
                    }
                }
            }
        }

        private void SelectedItemChanged(object parameter)
        {
            AlbumViewModel albumViewModel = parameter as AlbumViewModel;
            if (albumViewModel != null)
            {
                this.Invoke(() =>
                    {
                        Album selectedAlbum = this.GetAlbumById(albumViewModel.Id);
                        Mediator.NotifyColleagues<Album>(MediatorMessages.MessageCurrentAlbumChanged, selectedAlbum);
                    });
            }
        }
        #endregion
    }
}
