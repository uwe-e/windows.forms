using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.BO;
using BSE.CoverFlow.WPFLib.Input;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class NewAlbumsViewModel : EnvironmentViewModel
    {
        #region FieldsPrivate
        private BSE.CoverFlow.WPFLib.Input.RelayCommand m_controlLoadedCommand;
        private List<Album> m_albums;
        private Album m_newestAlbum;
        private RelayCommand m_selectionChangedCommand;
        #endregion

        #region Properties
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
        public System.Windows.Input.ICommand SelectionChangedCommand
        {
            get
            {
                if (this.m_selectionChangedCommand == null)
                {
                    this.m_selectionChangedCommand = new RelayCommand(
                        this.SelectionChanged);

                }
                return this.m_selectionChangedCommand;
            }
        }
        public List<Album> Albums
        {
            get
            {
                return this.m_albums;
            }
            set
            {
                this.m_albums = value;
                this.OnPropertyChanged("Albums");
            }
        }
        public Album NewestAlbum
        {
            get
            {
                return this.m_newestAlbum;
            }
            set
            {
                this.m_newestAlbum = value;
                this.OnPropertyChanged("NewestAlbum");
            }
        }
        #endregion

        #region MethodsPublic
        public NewAlbumsViewModel()
        {
        }
        public NewAlbumsViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
           Mediator.Register(this);
            this.LoadAlbums();
        }
        #endregion

        #region MethodsPrivate
        private void ControlLoaded(object parameter)
        {
        }

        private void SelectionChanged(object parameter)
        {
            Album selectedAlbum = parameter as Album;
            if (selectedAlbum != null)
            {
                this.InvokeAsynchronously(() =>
                    {
                        selectedAlbum = this.GetAlbumById(selectedAlbum.AlbumId);
                        Mediator.NotifyColleagues<Album>(MediatorMessages.MessageCurrentAlbumChanged, selectedAlbum);
                    });
            }
        }
        private void LoadAlbums()
        {
            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
            try
            {
                this.Invoke(() =>
                    {
                        
                        Album[] albumsWithCovers = tunesBusinessObject.GetNewestAlbumsWithCovers(7);
                        if (albumsWithCovers != null)
                        {
                            List<Album> albums = albumsWithCovers.ToList();
                            this.NewestAlbum = albums.FirstOrDefault();
                            albums.Remove(this.NewestAlbum);
                            this.Albums = albums;
                            
                        }
                    });
            }
            catch (Exception exception)
            {
            }
        }
        #endregion

    }
}
