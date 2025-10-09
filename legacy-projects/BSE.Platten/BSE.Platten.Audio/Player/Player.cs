using System;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für CPlayers.
	/// </summary>
	public abstract class Player : IPlayer
	{
		
		#region EventsPublic

		public event EventHandler<PlayerEventArgs> PlayerClosed;
        public event EventHandler<PlayerEventArgs> PlayerPaused;
        public event EventHandler<PlayerEventArgs> PlayerPlays;
        public event EventHandler<PlayerEventArgs> PlayerStarted;
        public event EventHandler<PlayerEventArgs> PlayerStopped;
        public event EventHandler<PlayerEventArgs> SongEnded;

		#endregion

        #region FieldsProtected

        private string m_strUnknownTitle = Resources.CPlayerUnknownTitle;

        #endregion

        #region FieldsPrivate

        private UsedPlayer m_eUsedAudioPlayer;
        private string m_strFormatDescription = string.Empty;

        #endregion

        #region Properties

        public string UnknownTitle
        {
            get { return m_strUnknownTitle; }
        }

        public PlayMode Mode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the PlayState for an Audio Player
        /// </summary>
        public PlayState PlayState
        {
            get;
            set;
        }
        public abstract int Count
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        public UsedPlayer UsedAudioPlayer
        {
            get { return this.m_eUsedAudioPlayer; }
            set { this.m_eUsedAudioPlayer = value; }
        }

        public string Description
        {
            get { return this.m_strFormatDescription; }
            set { this.m_strFormatDescription = value; }
        }

		#endregion

		#region MethodsPublic

		protected Player()
		{
		}

		public abstract void Play();
		public abstract void Play(string[] strFiles, BSE.Platten.Audio.PlayMode playMode);
		public abstract void Play(string strFileName, BSE.Platten.Audio.PlayMode playMode);
		public abstract void Load();
		public abstract void Close();
		public abstract void Pause();
		public abstract void Stop();
        public abstract int GetPlaylistPosition();
        public abstract void SetPlaylistPosition(int iPosition);
        public abstract void SetTrackPosition(int iCurrentPostion);
        public abstract int GetTrackPosition();
		public abstract int GetTrackLength();
		public abstract string GetSongTitle();
		public abstract void ClearPlaylist();

		#endregion

		#region MethodsProtected
		
		protected virtual void OnPlayerClosed(object sender, PlayerEventArgs e)
		{
			if (this.PlayerClosed != null)
			{
				this.PlayerClosed(sender, e);
			}
		}

		protected virtual void OnPlayerPaused(object sender, PlayerEventArgs e)
		{
			if (this.PlayerPaused != null)
			{
				this.PlayerPaused(sender, e);
			}
		}

		protected virtual void OnPlayerPlays(object sender, PlayerEventArgs e)
		{
			if (this.PlayerPlays != null)
			{
				this.PlayerPlays(sender, e);
			}
		}

		protected virtual void OnPlayerStarted(object sender, PlayerEventArgs e)
		{
			if (this.PlayerStarted != null)
			{
				this.PlayerStarted(sender, e);
			}
		}

		protected virtual void OnPlayerStopped(object sender, PlayerEventArgs e)
		{
			if (this.PlayerStopped != null)
			{
				this.PlayerStopped(sender, e);
			}
		}

        protected virtual void OnSongEnded(object sender, PlayerEventArgs e)
        {
            if (this.SongEnded != null)
            {
                this.SongEnded(sender, e);
            }
        }
		
		#endregion

	}
}
