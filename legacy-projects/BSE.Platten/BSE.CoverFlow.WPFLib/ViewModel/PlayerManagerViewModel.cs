using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSE.Platten.Audio;
using System.Windows;
using BSE.Platten.BO;
using BSE.Platten.BO.Extensions;
using BSE.CoverFlow.WPFLib.Input;
using System.Windows.Input;
using System.Windows.Threading;
using System.Globalization;
using BSE.CoverFlow.WPFLib.Controls;
using BSE.CoverFlow.WPFLib.Properties;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class PlayerManagerViewModel : EnvironmentViewModel
    {
        #region Events
        public event EventHandler<EventArgs> CurrentTrackChanged;
        #endregion

        #region FieldsPrivate
        private RelayCommand m_playRandomCommand;
        private RelayCommand m_playPlayListCommand;
        private RelayCommand m_playCDCommand;
        private RelayCommand m_playSongCommand;
        private RelayCommand m_playerStopCommand;
        private RelayCommand m_playerPlayCommand;
        private RelayCommand m_nextTrackCommand;
        private RelayCommand m_previousTrackCommand;
        private RelayCommand m_progressSliderDragStartedCommand;
        private RelayCommand m_progressSliderDragCompletedCommand;
        private TrackCollection m_randomTrackCollection;
        private CTrack m_currentTrack;
        private bool m_bHasPlaylists;
        private List<Playlist> m_playlists;
        private PlayMode m_playMode;
        private bool m_bIsPlaying;
        private bool m_bIsPaused;
        private bool m_bIsStopped;
        private bool m_bIsNextTrackAvailable;
        private bool m_bIsPreviousTrackAvailable;
        private int m_iProgressValue;
        private int m_iProgressMaximumValue;
        private string m_strCurrentTitle;
        private string m_strCurrentProgressTime;
        private DispatcherTimer m_progressTimer;
        #endregion

        #region Properties
        public TrackCollection RandomTrackCollection
        {
            get
            {
                return this.m_randomTrackCollection;
            }
            set
            {
                this.m_randomTrackCollection = value;
                base.OnPropertyChanged("RandomTrackCollection");
            }
        }
        public PlayMode PlayMode
        {
            get
            {
                return this.m_playMode;
            }
            set
            {
                if (value != this.m_playMode)
                {
                    this.m_playMode = value;
                    base.OnPropertyChanged("PlayMode");
                }
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
                base.OnPropertyChanged("Playlists");
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
        public CTrack CurrentTrack
        {
            get
            {
                return this.m_currentTrack;
            }
            set
            {
                this.m_currentTrack = value;
                base.OnPropertyChanged("CurrentTrack");
            }

        }
        public bool IsPlaying
        {
            get { return this.m_bIsPlaying; }
            set
            {
                this.m_bIsPlaying = value;
                base.OnPropertyChanged("IsPlaying");
            }
        }

        public bool IsPaused
        {
            get {
                return this.m_bIsPaused; }
            set
            {
                this.m_bIsPaused = value;
                base.OnPropertyChanged("IsPaused");
            }
        }

        public bool IsStopped
        {
            get
            {
                return this.m_bIsStopped;
            }
            set
            {
                this.m_bIsStopped = value;
                base.OnPropertyChanged("IsStopped");
            }
        }

        public bool IsNextTrackAvailable
        {
            get
            {
                return this.m_bIsNextTrackAvailable;
            }
            set
            {
                this.m_bIsNextTrackAvailable = value;
                base.OnPropertyChanged("IsNextTrackAvailable");
            }
        }

        public bool IsPreviousTrackAvailable
        {
            get
            {
                return this.m_bIsPreviousTrackAvailable;
            }
            set
            {
                this.m_bIsPreviousTrackAvailable = value;
                base.OnPropertyChanged("IsPreviousTrackAvailable");
            }
        }
        public int ProgressValue
        {
            get
            {
                return this.m_iProgressValue;
            }
            set
            {
                if (value != this.m_iProgressValue)
                {
                    this.m_iProgressValue = value;
                    base.OnPropertyChanged("ProgressValue");
                }
            }
        }
        public int ProgressMaximumValue
        {
            get
            {
                return this.m_iProgressMaximumValue;
            }
            set
            {
                if (value != this.m_iProgressMaximumValue)
                {
                    this.m_iProgressMaximumValue = value;
                    base.OnPropertyChanged("ProgressMaximumValue");
                }
            }
        }
        public string CurrentTitle
        {
            get
            {
                return this.m_strCurrentTitle;
            }
            set
            {
                if (string.Compare(value,this.m_strCurrentTitle) != 0)
                {
                    this.m_strCurrentTitle = value;
                    base.OnPropertyChanged("CurrentTitle");
                }
            }
        }
        public string CurrentProgressTime
        {
            get
            {
                return this.m_strCurrentProgressTime;
            }
            set
            {
                if (string.Compare(value,this.m_strCurrentProgressTime) != 0)
                {
                    this.m_strCurrentProgressTime = value;
                    base.OnPropertyChanged("CurrentProgressTime");
                }
            }
        }
        public ICommand PlayRandomCommand
        {
            get
            {
                if (this.m_playRandomCommand == null)
                {
                    this.m_playRandomCommand = new RelayCommand(
                        this.PlayRandom, this.PlayRandomCanExecute);
                }
                return this.m_playRandomCommand;
            }
        }
        public ICommand PlayPlaylistCommand
        {
            get
            {
                if (this.m_playPlayListCommand == null)
                {
                    this.m_playPlayListCommand = new RelayCommand(
                        this.PlayPlaylist);
                }
                return this.m_playPlayListCommand;
            }
        }
        public ICommand PlayCDCommand
        {
            get
            {
                if (this.m_playCDCommand == null)
                {
                    this.m_playCDCommand = new RelayCommand(
                        this.PlayCd, PlayCdCanExecute);
                }
                return this.m_playCDCommand;
            }
        }
        public ICommand PlaySongCommand
        {
            get
            {
                if (this.m_playSongCommand == null)
                {
                    this.m_playSongCommand = new RelayCommand(
                        this.PlaySong);
                }
                return this.m_playSongCommand;
            }
        }
        public ICommand PlayerStopCommand
        {
            get
            {
                if (this.m_playerStopCommand == null)
                {
                    this.m_playerStopCommand = new RelayCommand(
                        this.PlayerStop, this.PlayerStopCanExecute);
                }
                return this.m_playerStopCommand;
            }
        }
        public ICommand PlayerPlayCommand
        {
            get
            {
                if (this.m_playerPlayCommand == null)
                {
                    this.m_playerPlayCommand = new RelayCommand(
                        this.PlayerPlay, this.PlayerPlayCanExecute);
                }
                return this.m_playerPlayCommand;
            }
        }
        public ICommand NextTrackCommand
        {
            get
            {
                if (this.m_nextTrackCommand == null)
                {
                    this.m_nextTrackCommand = new RelayCommand(
                        this.NextTrack, this.NextTrackCanExecute);
                }
                return this.m_nextTrackCommand;
            }
        }
        public ICommand PreviousTrackCommand
        {
            get
            {
                if (this.m_previousTrackCommand == null)
                {
                    this.m_previousTrackCommand = new RelayCommand(
                        this.PreviousTrack, this.PreviousTrackCanExecute);
                }
                return this.m_previousTrackCommand;
            }
        }

        public ICommand ProgressSliderDragStartedCommand
        {
            get
            {
                if (this.m_progressSliderDragStartedCommand == null)
                {
                    this.m_progressSliderDragStartedCommand = new RelayCommand(
                        this.ProgressSliderDragStarted);
                }
                return this.m_progressSliderDragStartedCommand;
            }
        }
        public ICommand ProgressSliderDragCompletedCommand
        {
            get
            {
                if (this.m_progressSliderDragCompletedCommand == null)
                {
                    this.m_progressSliderDragCompletedCommand = new RelayCommand(
                        this.ProgressSliderDragCompleted);
                }
                return this.m_progressSliderDragCompletedCommand;
            }
        }
        #endregion

        #region MethodsPublic
        public PlayerManagerViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
            this.Mediator.Register(this);
            this.PlayMode = Platten.Audio.PlayMode.Random;
            this.IsStopped = true;
            this.IsPlaying = false;
            PlayerManager.TrackChanged += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnTrackChanged);
            PlayerManager.PlayerPlays += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerPlays);
            PlayerManager.PlayerPaused += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerPaused);
            PlayerManager.PlayerStopped += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerStopped);
            PlayerManager.TrackCollectionChanged += OnTrackCollectionChanged;
            this.m_progressTimer = new DispatcherTimer(DispatcherPriority.Background);
            this.m_progressTimer.Tick +=new EventHandler(OnProgressTimerTick);
        }

        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessageCurrentAlbumChanged, ParameterType = typeof(Album))]
        public void SetCurrentAlbum(Album album)
        {
            this.CurrentAlbum = album;
            CommandManager.InvalidateRequerySuggested();
        }
        [BSE.CoverFlow.WPFLib.Mediator.MediatorMessageSink(MediatorMessages.MessagePlaylistsChanged, ParameterType = typeof(IList<Playlist>))]
        public void SetPlaylists(IList<Playlist> playlists)
        {
            this.Playlists = playlists != null ? new List<Playlist>(playlists) : null;
            this.HasPlaylists = playlists != null ? true : false;
        }
        #endregion

        #region MethodsProtected
        protected override void Dispose(bool disposing)
        {
            PlayerManager.Close();
            base.Dispose(disposing);
        }
        #endregion

        #region MethodsPrivate
        private void OnTrackCollectionChanged(object sender, EventArgs e)
        {
            CPlayerManager playerManager = sender as CPlayerManager;
            if (playerManager != null)
            {
                this.RandomTrackCollection = playerManager.RandomTracks;
            }
        }

        private void OnTrackChanged(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (e.CurrentTrack != null)
            {
                this.PlayMode = e.PlayMode;
                this.CurrentTrack = e.CurrentTrack;

                using (UpdateHistoryViewModel updateHistoryViewModel = new UpdateHistoryViewModel(this.Environment))
                {
                    updateHistoryViewModel.UpdateHistory(this.CurrentTrack, this.PlayMode);
                }
                Mediator.NotifyColleagues<CTrack>(
                                MediatorMessages.MessageCurrentTrackChanged,
                                this.CurrentTrack);
                if (this.CurrentTrackChanged != null)
                {
                    this.CurrentTrackChanged(this, EventArgs.Empty);
                }
            }
        }
        private void OnPlayerPlays(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            this.InvokeAsynchronously(() =>
                {
                    this.IsPlaying = true;
                    this.IsPaused = false;
                    this.IsStopped = false;
                    int iTrackLength = PlayerManager.GetTrackLength();
                    this.IsNextTrackAvailable = PlayerManager.IsNextTrackAvailable;
                    this.IsPreviousTrackAvailable = PlayerManager.IsPreviousTrackAvailable;
                    this.ProgressValue = 0;
                    this.ProgressMaximumValue = iTrackLength;
                    this.CurrentTitle = String.Format(CultureInfo.InvariantCulture, "({0}) {1}", PlayerManager.GetTrackDurationAsString(iTrackLength), PlayerManager.GetSongTitle());
                    this.m_progressTimer.Start();

                    CommandManager.InvalidateRequerySuggested();
                });
        }
        private void OnPlayerPaused(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            this.IsPaused = true;
            this.IsPlaying = false;
            this.IsStopped = false;
            this.m_progressTimer.Stop();
        }
        private void OnPlayerStopped(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            this.IsPaused = false;
            this.IsPlaying = false;
            this.IsStopped = true;
            this.PlayMode = Platten.Audio.PlayMode.None;
        }
        private bool PlayRandomCanExecute(object parameter)
        {
            return this.RandomTrackCollection == null ? false : true;
        }
        private void PlayRandom(object parameter)
        {
            this.InvokeAsynchronously(() =>
                {
                    try
                    {
                        TrackCollection trackCollection = TrackCollection.GetRandomCollection(this.RandomTrackCollection);
                        PlayerManager.PlayTracks(trackCollection, Platten.Audio.PlayMode.Random);
                    }
                    catch (Exception exception)
                    {
                        this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_PlayerExceptionCaption, DialogButton.Ok);
                    }
                });
        }

        private void PlayPlaylist(object parameter)
        {
            Playlist playlist = parameter as Playlist;
            if (playlist != null)
            {
                this.InvokeAsynchronously(() =>
                {
                    try
                    {
                        TrackCollection trackCollection = Playlist.GetTrackCollection(playlist, this.Environment);
                        if (trackCollection != null)
                        {
                            PlayerManager.PlayTracks(trackCollection, Platten.Audio.PlayMode.Playlist);
                        }
                    }
                    catch (Exception exception)
                    {
                        this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_ApplicationExceptionCaption, DialogButton.Ok);
                    }
                });
            }
        }
        private bool PlayCdCanExecute(object paramter)
        {
            return this.CurrentAlbum != null;
        }
        private void PlayCd(object parameter)
        {
            Album album = parameter as Album;
            if (album != null)
            {
                this.InvokeAsynchronously(() =>
                     {
                         try
                         {
                             TrackCollection trackCollection = album.ToTrackCollection();
                             if (trackCollection != null)
                             {
                                 PlayerManager.PlayTracks(trackCollection, PlayMode.CD);
                             }
                         }
                         catch (Exception exception)
                         {
                             this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_ApplicationExceptionCaption, DialogButton.Ok);
                         }
                     });
            }
        }
        private void PlaySong(object parameter)
        {
            CTrack track = parameter as CTrack;
            if (track != null)
            {
                this.InvokeAsynchronously(() =>
                    {
                        try
                        {
                            PlayerManager.PlayTrack(track, BSE.Platten.Audio.PlayMode.Song);
                        }
                        catch (Exception exception)
                        {
                            this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_ApplicationExceptionCaption, DialogButton.Ok);
                        }
                    });

            }
        }
        private bool PlayerStopCanExecute(object parameter)
        {
            return this.IsPlaying || this.IsPaused;
        }
        private void PlayerStop(object parameter)
        {
            PlayerManager.Stop();
        }
        private bool PlayerPlayCanExecute(object parameter)
        {
            return true;
        }
        private void PlayerPlay(object parameter)
        {
            try
            {
                if (this.IsPlaying == true)
                {
                    PlayerManager.Pause();
                }
                else if (this.IsPaused == true)
                {
                    PlayerManager.Play();
                }
                else if (this.IsStopped == true)
                {
                    PlayerManager.PlayTracks();
                }
            }
            catch (Exception exception)
            {
                this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_ApplicationExceptionCaption, DialogButton.Ok);
            }
        }
        private bool NextTrackCanExecute(object parameter)
        {
            return this.IsNextTrackAvailable;
        }
        private void NextTrack(object parameter)
        {
            try
            {
                switch (this.PlayMode)
                {
                    case PlayMode.CD:
                        int iPlayListPosition = PlayerManager.GetPlaylistPosition();
                        PlayerManager.SetPlaylistPosition(iPlayListPosition + 1);
                        break;
                    case PlayMode.Playlist:
                    case PlayMode.Random:
                        PlayerManager.PlayNextTrack(this.PlayMode);
                        break;
                }
            }
            catch (Exception exception)
            {
                this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_ApplicationExceptionCaption, DialogButton.Ok);
            }
        }
        private bool PreviousTrackCanExecute(object parameter)
        {
            return this.IsPreviousTrackAvailable;
        }
        private void PreviousTrack(object parameter)
        {
            try
            {
                switch (this.PlayMode)
                {
                    case PlayMode.CD:
                        int iPlayListPosition = PlayerManager.GetPlaylistPosition();
                        PlayerManager.SetPlaylistPosition(iPlayListPosition - 1);
                        break;
                    case PlayMode.Playlist:
                    case PlayMode.Random:
                        PlayerManager.PlayPreviousTrack(this.PlayMode);
                        break;
                }
            }
            catch (Exception exception)
            {
                this.DialogService.ShowMessageBox(this, exception.Message, Resources.IDS_ApplicationExceptionCaption, DialogButton.Ok);
            }
        }
        private void ProgressSliderDragStarted(object parameter)
        {
            this.m_progressTimer.Stop();
        }
        private void ProgressSliderDragCompleted(object parameter)
        {
            if (this.m_progressTimer.IsEnabled == false)
            {
                PlayerManager.SetTrackPosition(Convert.ToInt32(this.ProgressValue));
                this.m_progressTimer.Start();
            }
        }
        private void OnProgressTimerTick(object sender, EventArgs e)
        {
            int iTrackPosition = PlayerManager.GetTrackPosition();
            this.ProgressValue = iTrackPosition;
            this.CurrentProgressTime = PlayerManager.GetTrackDurationAsString(iTrackPosition);
        }
        #endregion

    }
}
