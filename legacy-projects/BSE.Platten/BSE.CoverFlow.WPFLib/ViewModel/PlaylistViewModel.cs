using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BSE.Platten.BO;
using System.Windows.Input;
using BSE.CoverFlow.WPFLib.Input;
using System.Collections.ObjectModel;
using GongSolutions.Wpf.DragDrop;
using BSE.CoverFlow.WPFLib.Controls;
using BSE.CoverFlow.WPFLib.Properties;
using System.Globalization;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class PlaylistViewModel : ListViewModelBase
    {
        #region FieldsPrivate
        private RelayCommand m_selectPlayListCommand;
        private RelayCommand m_savePlayListCommand;
        private RelayCommand m_openNewPlaylistDialogCommand;
        private RelayCommand m_openDeletePlaylistDialogCommand;
        private bool m_bHasPlaylists;
        private NewPlaylistDialogViewModel m_newPlaylistDialogModel;
        private DeletePlaylistDialogViewModel m_deletePlaylistDialogModel;
        private List<Playlist> m_playlists;
        #endregion

        #region Properties

        public NewPlaylistDialogViewModel NewPlaylistDialogModel
        {
            get
            {
                return this.m_newPlaylistDialogModel;
            }
            set
            {
                this.m_newPlaylistDialogModel = value;
                this.OnPropertyChanged("NewPlaylistDialogModel");
            }
        }
        public DeletePlaylistDialogViewModel DeletePlaylistDialogModel
        {
            get
            {
                return this.m_deletePlaylistDialogModel;
            }
            set
            {
                this.m_deletePlaylistDialogModel = value;
                this.OnPropertyChanged("DeletePlaylistDialogModel");
            }
        }

        public List<Playlist> Playlists
        {
            get
            {
                return this.m_playlists;
            }
            set
            {
                this.m_playlists = value;
                this.OnPropertyChanged("Playlists");
            }
        }
        public bool HasPlaylists
        {
            get
            {
                return this.m_bHasPlaylists;
            }
            set
            {
                this.m_bHasPlaylists = value;
                this.OnPropertyChanged("HasPlaylists");
            }
        }
        public Playlist CurrentPlaylist
        {
            get;
            private set;
        }
        public ICommand SavePlaylistCommand
        {
            get
            {
                if (this.m_savePlayListCommand == null)
                {
                    this.m_savePlayListCommand = new RelayCommand(
                        this.SavePlaylist,
                        this.CanSavePlaylistExecuted);
                }
                return this.m_savePlayListCommand;
            }
        }
        public ICommand OpenNewPlaylistDialogCommand
        {
            get
            {
                if (this.m_openNewPlaylistDialogCommand == null)
                {
                    this.m_openNewPlaylistDialogCommand = new RelayCommand(
                        this.OpenNewPlaylistDialog);
                }
                return this.m_openNewPlaylistDialogCommand;
            }
        }
        public ICommand OpenDeletePlaylistDialogCommand
        {
            get
            {
                if (this.m_openDeletePlaylistDialogCommand == null)
                {
                    this.m_openDeletePlaylistDialogCommand = new RelayCommand(
                        this.OpenDeletePlaylistDialog,
                        this.CanOpenDeletePlaylistDialogExecuted);
                }
                return this.m_openDeletePlaylistDialogCommand;
            }
        }
        public ICommand SelectPlaylistCommand
        {
            get
            {
                if (this.m_selectPlayListCommand == null)
                {
                    this.m_selectPlayListCommand = new RelayCommand(
                        this.SelectPlaylist);
                }
                return this.m_selectPlayListCommand;
            }
        }
        private bool HasModified
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        public PlaylistViewModel(BSE.Platten.BO.Environment environment) : base(environment)
        {
            this.LoadPlaylists();
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        private bool CanSavePlaylistExecuted(object parameter)
        {
            return this.CurrentPlaylist != null;
        }
        private void SavePlaylist(object parameter)
        {
            if (this.HasModified == true && this.Tracks != null)
            {
                this.CurrentPlaylist.PlayListEntries = this.Tracks.Select(item => new PlaylistEntry
                {
                    Guid = System.Guid.NewGuid(),
                    EntryId = -1,
                    LiedId = item.LiedId,
                    PlayListId = this.CurrentPlaylist.Id
                }).ToArray();
                if (this.CurrentPlaylist.PlayListEntries != null)
                {
                    CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
                    try
                    {
                        tunesBusinessObject.SavePlayList(this.CurrentPlaylist);
                        this.LoadPlaylists();
                    }
                    catch (Exception exception)
                    {
                        this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_PlayListExceptionCaption, DialogButton.Ok);
                    }
                }
            }
        }
        private void OpenNewPlaylistDialog(object parameter)
        {
            this.NewPlaylistDialogModel = new NewPlaylistDialogViewModel(this.Environment);
            this.NewPlaylistDialogModel.PlayListAdded += OnNewPlayListAdded;
            this.DialogService.ShowDialog(this, this.NewPlaylistDialogModel);
        }
        private bool CanOpenDeletePlaylistDialogExecuted(object parameter)
        {
            return this.CurrentPlaylist != null;
        }

        private void OpenDeletePlaylistDialog(object parameter)
        {
            this.DeletePlaylistDialogModel = new DeletePlaylistDialogViewModel(this.Environment)
            {
                CurrentPlaylist = this.CurrentPlaylist
            };
            this.DeletePlaylistDialogModel.PlayListDeleted += OnPlaylistDeleted;
            this.DialogService.ShowDialog(this, this.DeletePlaylistDialogModel);
        }
        private void OnNewPlayListAdded(object sender, PlaylistChangedEventArgs e)
        {
            this.SelectPlaylist(e.PlayList);
            this.LoadPlaylists();
        }
        private void OnPlaylistDeleted(object sender, PlaylistChangedEventArgs e)
        {
            this.CurrentPlaylist = e.PlayList;
            this.Tracks = null;
            this.LoadPlaylists();
        }
        private void SelectPlaylist(object parameter)
        {
            if (this.Environment != null)
            {
                Playlist playlist = parameter as Playlist;
                if (playlist != null)
                {
                    CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.Environment.GetConnectionString());
                    try
                    {
                        this.CurrentPlaylist = tunesBusinessObject.GetPlayListByPlayListId(playlist.Id);
                        if (this.CurrentPlaylist != null && this.CurrentPlaylist.Tracks != null)
                        {
                            string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
                            List<CTrack> trackList = this.CurrentPlaylist.Tracks.ToList();
                            trackList.ForEach(delegate(CTrack track)
                            {
                                if (track != null)
                                {
                                    track.FileFullName = strAudioHomeDirectory + track.FileName;
                                }
                            });
                            this.Tracks = new ObservableCollection<CTrack>(trackList);
                            this.HasModified = false;
                            this.Tracks.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(OnTracksCollectionChanged);
                        }
                    }
                    catch (Exception exception)
                    {
                        string strMessage = string.Format(
                        CultureInfo.CurrentUICulture,
                        "{0} {1}",
                        Resources.IDS_PlayListLoadException, exception.Message);
                        this.DialogService.ShowMessageBox(this, strMessage, Resources.IDS_PlayListExceptionCaption, DialogButton.Ok);
                    }
                }
            }
        }

        private void OnTracksCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.HasModified = true;
        }
        private void LoadPlaylists()
        {
            if (this.Environment != null)
            {
                this.InvokeAsynchronously(() =>
                    {
                        string strConnection = this.Environment.GetConnectionString();
                        if (string.IsNullOrEmpty(strConnection) == false)
                        {
                            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(strConnection);
                            try
                            {
                                IList<Playlist> playlists = tunesBusinessObject.GetPlaylistsByUserName(this.Environment.UserName);
                                this.Playlists = playlists != null ? new List<Playlist>(playlists) : null;
                                this.HasPlaylists = this.Playlists != null ? true : false;
                                Mediator.NotifyColleagues<IList<Playlist>>(MediatorMessages.MessagePlaylistsChanged, this.Playlists);
                            }
                            catch (Exception exception)
                            {
                                this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_PlayListExceptionCaption, DialogButton.Ok);
                            }
                        }
                    });
            }
        }
        #endregion
    }
}
