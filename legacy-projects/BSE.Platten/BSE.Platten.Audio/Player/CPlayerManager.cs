using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

using BSE.Platten.BO;
using System.Globalization;
using BSE.Platten.Audio.Properties;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für CPlayerManager.
	/// </summary>
	public class CPlayerManager// : Component
	{
		
		#region EventsPublic

		public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerManagerTrackChanged;
        public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerManagerSongFinished;
        public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerStarted;
        public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerManagerStopped;
        public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerManagerPlays;
        public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerManagerPaused;
        public event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerManagerClosed;
        public event EventHandler<EventArgs> TrackCollectionChanged;

		#endregion

		#region FieldsPrivate
		
		private Player m_player;
        private UsedPlayer m_usedPlayer;
        private TrackCollection m_trackCollection;
        private bool m_bHasPlayerStarted;
		
		#endregion

        #region Properties
        /// <summary>
        /// Gets the current played audio <see cref="CTrack"/>.
        /// </summary>
        public CTrack CurrentTrack
        {
            get
            {
                if (this.TrackCollection != null)
                {
                    return this.TrackCollection.CurrentTrack;
                }
                return null;
            }
        }
        /// <summary>
        /// Checks if the next track is available.
        /// </summary>
        public bool IsNextTrackAvailable
        {
            get
            {
                if (this.PlayMode == Audio.PlayMode.CD)
                {
                    return IsNextPlaylistPositionAvailable;
                }
                else if (this.PlayMode == Audio.PlayMode.Song)
                {
                    return false;
                }
                else
                {
                    if (this.TrackCollection != null)
                    {
                        return this.TrackCollection.IsNextTrackAvailable;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// Checks if the next track of the playlist is available.
        /// </summary>
        public bool IsNextPlaylistPositionAvailable
        {
            get
            {
                int iPlayListPosition = this.GetPlaylistPosition();
                if (iPlayListPosition >= 0 && iPlayListPosition < this.Count - 1)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Checks if a previous track is available.
        /// </summary>
        /// <returns></returns>
        public bool IsPreviousTrackAvailable
        {
            get
            {
                if (this.PlayMode == Audio.PlayMode.CD)
                {
                    return this.IsPreviousPlaylistPositionAvailable;
                }
                else if (this.PlayMode == Audio.PlayMode.Song)
                {
                    return false;
                }
                else
                {
                    if (this.TrackCollection != null)
                    {
                        return this.TrackCollection.IsPreviousTrackAvailable;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// Checks if a previous track of the playlist is available.
        /// </summary>
        public bool IsPreviousPlaylistPositionAvailable
        {
            get
            {
                int iPlayListPosition = this.GetPlaylistPosition();
                if (iPlayListPosition > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public bool HasPlayerStarted
        {
            get { return this.m_bHasPlayerStarted; }
            set { this.m_bHasPlayerStarted = value; }
        }

        public UsedPlayer UsedPlayer
        {
            get { return this.m_usedPlayer; }
        }
        /// <summary>
        /// The count property retrieves the number of media items in the playlist.
        /// </summary>
        public int Count
        {
            get
            {
                int iCount = -1;
                if (this.PlayMode == PlayMode.CD)
                {
                    iCount = this.m_player.Count;
                }
                if (this.PlayMode == PlayMode.Playlist)
                {
                    iCount = this.m_trackCollection.Count;
                }
                if (this.PlayMode == PlayMode.Random)
                {
                    iCount = this.m_trackCollection.Count;
                }
                return iCount;
            }
        }

        public TrackCollection TrackCollection
        {
            get { return this.m_trackCollection; }
            set { this.m_trackCollection = value; }
        }

        public TrackCollection RandomTracks
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the PlayMode in which the player plays.
        /// </summary>
        public PlayMode PlayMode
        {
            get;
            //private set;
            set;
        }
        /// <summary>
        /// Gets the PlayState of the used Audio Player.
        /// </summary>
        public PlayState PlayState
        {
            get
            {
                if (this.m_player == null)
                {
                    return PlayState.Closed;
                }
                else
                {
                    return this.m_player.PlayState;
                }
            }
        }
        #endregion

        #region MethodsPublic

        public CPlayerManager()
		{
		}
        public void LoadMediaPlayer()
        {
            
        }
        public void LoadPlayer()
        {
            if (this.m_player == null)
            {
                this.m_player = new MediaPlayer();
                //this.m_player = new Bass24();
                this.m_player.PlayerStarted += new EventHandler<PlayerEventArgs>(this.m_player_PlayerStarted);
                this.m_player.PlayerPlays += new EventHandler<PlayerEventArgs>(this.m_player_PlayerPlays);
                this.m_player.PlayerClosed += new EventHandler<PlayerEventArgs>(this.m_player_PlayerClosed);
                this.m_player.PlayerPaused += new EventHandler<PlayerEventArgs>(this.m_player_PlayerPaused);
                this.m_player.PlayerStopped += new EventHandler<PlayerEventArgs>(this.m_player_PlayerStopped);
                this.m_player.SongEnded += new EventHandler<PlayerEventArgs>(this.m_player_SongEnded);
                this.m_player.Load();
            }
        }
        public void LoadPlayer(BSE.Configuration.Configuration configuration)
        {
            UsedPlayerConfigurationData usedPlayerConfigurationObject =
                CPlayerConfigurationControl.GetConfiguration(configuration) as UsedPlayerConfigurationData;

            if (usedPlayerConfigurationObject != null)
            {
                UsedPlayer eUsedPlayer = usedPlayerConfigurationObject.UsedPlayer;
                if (eUsedPlayer != this.m_usedPlayer)
                {
                    this.Close();
                }

                this.m_usedPlayer = eUsedPlayer;
                switch (this.m_usedPlayer)
                {
                    case UsedPlayer.None:
                        break;
                    case UsedPlayer.MediaPlayer:
                        this.m_player = new MediaPlayer();
                        break;
                    case UsedPlayer.Winamp:
                        this.m_player = new Winamp((WinampConfigurationData)CWinampConfigurationControl.GetConfiguration(configuration));
                        break;
                }
                if (this.m_player != null)
                {
                    this.m_player.PlayerStarted += new EventHandler<PlayerEventArgs>(this.m_player_PlayerStarted);
                    this.m_player.PlayerPlays += new EventHandler<PlayerEventArgs>(this.m_player_PlayerPlays);
                    this.m_player.PlayerClosed += new EventHandler<PlayerEventArgs>(this.m_player_PlayerClosed);
                    this.m_player.PlayerPaused += new EventHandler<PlayerEventArgs>(this.m_player_PlayerPaused);
                    this.m_player.PlayerStopped += new EventHandler<PlayerEventArgs>(this.m_player_PlayerStopped);
                    this.m_player.SongEnded += new EventHandler<PlayerEventArgs>(this.m_player_SongEnded);
                    this.m_player.Load();
                }
            }
        }

		public void Stop()
		{
            if (this.m_player != null)
			{
				this.m_player.Stop();
			}
		}

		public void Pause()
		{
			if (this.m_player != null)
			{
				this.m_player.Pause();
			}
		}

		public void Play()
		{
			if (this.m_player != null)
			{
				this.m_player.Play();
			}
		}
        /// <summary>
        /// Close the player and cleanup the resources
        /// </summary>
		public void Close()
		{
			if (this.m_player != null)
			{
                this.m_player.Close();
			}
		}
        
        /// <summary>
        /// Plays the next track in the current track collection
        /// </summary>
        /// <param name="playMode">The mode in which the tracks have to play</param>
        public void PlayNextTrack(PlayMode playMode)
        {
            if (this.m_trackCollection != null)
            {
                switch (playMode)
                {
                    case PlayMode.Random:
                    case PlayMode.Playlist:
                        if (this.m_trackCollection.MoveNext() == true)
                        {
                            CTrack currentTrack = this.m_trackCollection.CurrentTrack;
                            if (currentTrack != null)
                            {
                                Play(currentTrack, playMode);
                            }
                        }
                        break;
                }
            }
        }
        public void PlayPreviousTrack(PlayMode playMode)
        {
            if (this.m_trackCollection != null)
            {
                switch (playMode)
                {
                    case PlayMode.Random:
                    case PlayMode.Playlist:
                        if (this.m_trackCollection.MovePrevious() == true)
                        {
                            CTrack currentTrack = this.m_trackCollection.CurrentTrack;
                            if (currentTrack != null)
                            {
                                Play(currentTrack, playMode);
                            }
                        }
                    break;
                }
            }
        }
        public void SetRandomTracks(TrackCollection trackCollection)
        {
            if (trackCollection != null && trackCollection.Equals(this.RandomTracks) == false)
            {
                this.RandomTracks = trackCollection;
                if (this.TrackCollectionChanged != null)
                {
                    this.TrackCollectionChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trackToPlay">A track for playing</param>
        /// <param name="playMode">The mode in which the tracks have to play</param>
		public void PlayTrack(BSE.Platten.BO.CTrack trackToPlay,BSE.Platten.Audio.PlayMode playMode)
		{
            if (this.m_player == null)
            {
                throw new ArgumentException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.CPlayerManagerNoPlayerException));
            }
            if (trackToPlay == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,"trackToPlay"));
            }
            this.PlayMode = playMode;
            this.TrackCollection = new TrackCollection();
            this.TrackCollection.Add(trackToPlay);
            this.Play(trackToPlay, playMode);
		}
        public void PlayTracks()
        {
            if (this.m_player == null)
            {
                throw new ArgumentException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.CPlayerManagerNoPlayerException));
            }

            if (this.TrackCollection != null && this.TrackCollection.Count > 0)
            {
                switch (this.PlayMode)
                {
                    case PlayMode.Song:
                    case PlayMode.Playlist:
                    case PlayMode.Random:
                        if (this.m_trackCollection.MoveNext() == true)
                        {
                            CTrack currentTrack = this.m_trackCollection.CurrentTrack;
                            if (currentTrack != null)
                            {
                                this.Play(currentTrack, this.PlayMode);
                            }
                        }
                        break;
                    case PlayMode.CD:
                        var test = (from track in this.m_trackCollection
                                    where string.IsNullOrEmpty(track.FileFullName) == false
                                    select track.FileFullName).ToArray();
                        ArrayList aTracks = new ArrayList();
                        IEnumerator enumerator = this.m_trackCollection.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            CTrack track = enumerator.Current as CTrack;
                            if (track != null)
                            {
                                if (String.IsNullOrEmpty(track.FileFullName) == false)
                                {
                                    aTracks.Add(track.FileFullName);
                                }
                            }
                        }
                        if (aTracks.Count > 0)
                        {
                            String[] strFiles = new String[aTracks.Count];
                            aTracks.CopyTo(strFiles);
                            CTrack track = this.m_trackCollection[0] as CTrack;
                            if (track != null)
                            {
                                this.m_player.Play(strFiles, this.PlayMode);
                                //Wenn der Mode des übergebenen Arrays == Mode.CD
                                //wird der Title des 1. Tracks mit string.Empty überschrieben
                                CTrack tmpTrack = track.Clone() as CTrack;
                                tmpTrack.LiedId = 0;
                                tmpTrack.Title = string.Empty;
                                OnPlayerManagerTrackChanged(new PlayerManagerStatusChangedEventArgs(tmpTrack, this.PlayMode));
                            }
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trackCollection">A collection of tracks for playing</param>
        /// <param name="playMode">The mode in which the tracks have to play</param>
		public void PlayTracks(TrackCollection trackCollection,BSE.Platten.Audio.PlayMode playMode)
		{
			if (this.m_player == null)
            {
                throw new ArgumentException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.CPlayerManagerNoPlayerException));
            }

            if (trackCollection != null)
            {
                this.PlayMode = playMode;
                this.m_trackCollection = trackCollection;

                switch (playMode)
                {
                    case PlayMode.Playlist:
                    case PlayMode.Random:
                        if (this.m_trackCollection.MoveNext() == true)
                        {
                            CTrack currentTrack = this.m_trackCollection.CurrentTrack;
                            if (currentTrack != null)
                            {
                                this.Play(currentTrack, this.PlayMode);
                            }
                        }
                        break;
                    case PlayMode.CD:
                        string[] aFiles = (from track in this.m_trackCollection
                                           where track != null && string.IsNullOrEmpty(track.FileFullName) == false
                                           select track.FileFullName).ToArray();
                        if (aFiles != null && aFiles.Length > 0)
                        {
                            this.m_player.Play(aFiles, this.PlayMode);
                            //If PlayMode == PlayMode.CD than the title of the first track will be overwritten with a string.empty value.
                            //It's the track for the history table
                            CTrack track = this.m_trackCollection[0].Clone() as CTrack;
                            track.LiedId = 0;
                            track.Title = string.Empty;
                            OnPlayerManagerTrackChanged(new PlayerManagerStatusChangedEventArgs(track, this.PlayMode));
                        }
                        break;
                }
            }
		}
        /// <summary>
        /// Gets the new position in the playlist.
        /// </summary>
        /// <returns>current playlist position</returns>
        public int GetPlaylistPosition()
        {
            int iPosition = -1;
            if (this.PlayMode == PlayMode.CD)
            {
                iPosition = this.m_player.GetPlaylistPosition();
            }
            if (this.PlayMode == PlayMode.Playlist)
            {
                iPosition = this.m_trackCollection.Index;
            }
            return iPosition;
        }
        /// <summary>
        /// Sets the new position in the playlist.
        /// </summary>
        /// <param name="iPosition">new playlist position</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void SetPlaylistPosition(int iPosition)
        {
            if (this.m_player != null)
            {
                this.m_player.SetPlaylistPosition(iPosition);
            }
        }
        /// <summary>
        /// Sets the current position in the media item in seconds from the beginning.
        /// </summary>
        /// <param name="iCurrentPostion">current position in seconds</param>
        public void SetTrackPosition(int iCurrentPostion)
        {
            if (this.m_player != null)
            {
                this.m_player.SetTrackPosition(iCurrentPostion);
            }
        }
        /// <summary>
        /// Gets the current position in the media item in seconds from the beginning.
        /// </summary>
        /// <returns>current position in seconds</returns>
        public int GetTrackPosition()
        {
            if (this.m_player != null)
            {
                return this.m_player.GetTrackPosition();
            }
            return -1;
        }
        /// <summary>
        /// Gets the duration in seconds of the current media item in HH:MM:SS format.
        /// </summary>
        /// <param name="iTrackLength">the duration in seconds</param>
        /// <returns>the duration in HH:MM:SS format</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static string GetTrackDurationAsString(int iTrackLength)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, iTrackLength);
            return timeSpan.ToString();
        }
        /// <summary>
        /// Gets the duration in seconds of the current media item
        /// </summary>
        /// <returns>the duration in seconds</returns>
        public int GetTrackLength()
        {
            return this.m_player.GetTrackLength();
        }
        public string GetSongTitle()
        {
            return this.m_player.GetSongTitle();
        }
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static int GetRandomIndex(int iCounter)
		{
			Random random = new Random();
			return random.Next(iCounter);
		}
		#endregion

		#region MethodsProtected

		protected virtual void OnPlayerManagerTrackChanged(PlayerManagerStatusChangedEventArgs e)
		{
			if (this.PlayerManagerTrackChanged != null)
			{
				this.PlayerManagerTrackChanged(this,e);
			}
		}

        protected virtual void OnPlayerManagerSongFinished(PlayerManagerStatusChangedEventArgs e)
        {
            if (this.PlayerManagerSongFinished != null)
            {
                this.PlayerManagerSongFinished(this, e);
            }
        }

		protected virtual void OnPlayerStarted(PlayerManagerStatusChangedEventArgs e)
		{
			if (this.PlayerStarted != null)
			{
				this.PlayerStarted(this,e);
			}
		}

		protected virtual void OnPlayerManagerStopped(PlayerManagerStatusChangedEventArgs e)
		{
			if (this.PlayerManagerStopped != null)
			{
				this.PlayerManagerStopped(this,e);
			}
		}

		protected virtual void OnPlayerManagerPaused(PlayerManagerStatusChangedEventArgs e)
		{
			if (this.PlayerManagerPaused != null)
			{
				this.PlayerManagerPaused(this,e);
			}
		}

		protected virtual void OnPlayerManagerPlays(PlayerManagerStatusChangedEventArgs e)
		{
            if (this.PlayerManagerPlays != null)
			{
				this.PlayerManagerPlays(this,e);
			}
		}

		protected virtual void OnPlayerManagerClosed(PlayerManagerStatusChangedEventArgs e)
		{
			if (this.PlayerManagerClosed != null)
			{
				this.PlayerManagerClosed(this,e);
			}
		}
		
		#endregion

		#region MethodsPrivate
		
		private void m_player_PlayerStarted(object sender, PlayerEventArgs e)
		{
            this.HasPlayerStarted = e.PlayerHasStarted;
            OnPlayerStarted(new PlayerManagerStatusChangedEventArgs(e.PlayerHasStarted));
		}

		private void m_player_PlayerPlays(object sender, PlayerEventArgs e)
		{
			OnPlayerManagerPlays(new PlayerManagerStatusChangedEventArgs(e.PlayMode));
		}

		private void m_player_PlayerStopped(object sender, PlayerEventArgs e)
		{
			try
			{
				switch(e.PlayMode)
				{
					case PlayMode.None:
                    case PlayMode.Song:
					case PlayMode.CD:
                        OnPlayerManagerStopped(new PlayerManagerStatusChangedEventArgs());
						break;
					case PlayMode.Playlist:
                        if (this.m_trackCollection != null)
                        {
                            if (this.m_trackCollection.MoveNext() == true)
                            {
                                CTrack currentTrack = this.m_trackCollection.CurrentTrack;
                                if (currentTrack != null)
                                {
                                    Play(currentTrack, e.PlayMode);
                                }
                            }
                            else
                            {
                                OnPlayerManagerStopped(new PlayerManagerStatusChangedEventArgs());
                            }
                        }
						break;
                    case PlayMode.Random:
                        OnPlayerManagerStopped(new PlayerManagerStatusChangedEventArgs());
                        break;
				}
			}
			catch (Exception)
			{
				throw; 
			}
		}

		private void m_player_PlayerClosed(object sender, PlayerEventArgs e)
		{
			OnPlayerManagerClosed(new PlayerManagerStatusChangedEventArgs(e.PlayMode));
		}

		private void m_player_PlayerPaused(object sender, PlayerEventArgs e)
		{
			OnPlayerManagerPaused(new PlayerManagerStatusChangedEventArgs());
		}

        private void m_player_SongEnded(object sender, PlayerEventArgs e)
        {
            try
            {
                switch (e.PlayMode)
                {
                    case PlayMode.Song:
                        OnPlayerManagerStopped(new PlayerManagerStatusChangedEventArgs(this.PlayMode));
                        break;
                    case BSE.Platten.Audio.PlayMode.Random:
                    case PlayMode.Playlist:
                        OnPlayerManagerSongFinished(new PlayerManagerStatusChangedEventArgs(this.PlayMode));
                        if (this.m_trackCollection != null)
                        {
                            if (this.m_trackCollection.MoveNext() == true)
                            {
                                CTrack currentTrack = this.m_trackCollection.CurrentTrack;
                                if (currentTrack != null)
                                {
                                    Play(currentTrack, e.PlayMode);
                                }
                            }
                            else
                            {
                                //Wenn alle Tracks gespielt wurden wird der Player gestoppt
                                OnPlayerManagerStopped(new PlayerManagerStatusChangedEventArgs(this.PlayMode));
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

		private void Play(BSE.Platten.BO.CTrack track,BSE.Platten.Audio.PlayMode mode)
		{
			this.Stop();
            try
            {
                if (CheckFile.FileExists(track.FileFullName))
                {
                    this.m_player.Play(track.FileFullName, mode);
                    OnPlayerManagerTrackChanged(new PlayerManagerStatusChangedEventArgs(track, mode));
                }
            }
            catch (Exception)
            {
                throw;
            }
		}
 
		#endregion
	}
}
