using System;
using System.Collections.Generic;
using System.Text;
using BSE.Platten.BO;

namespace BSE.Platten.Audio
{
    public class PlayerManager
    {
        #region Events
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> TrackChanged;
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> SongFinished;
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerStarted;
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerStopped;
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerPlays;
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerPaused;
        public static event EventHandler<PlayerManagerStatusChangedEventArgs> PlayerClosed;
        public static event EventHandler<EventArgs> TrackCollectionChanged;
        #endregion

        #region FieldsPrivate
        private static CPlayerManager m_playerManager;
        #endregion

        #region Properties
        public static bool IsNextTrackAvailable
        {
            get
            {
                return m_playerManager.IsNextTrackAvailable;
            }
        }
        public static bool IsPreviousTrackAvailable
        {
            get
            {
                return m_playerManager.IsPreviousTrackAvailable;
            }
        }
        public static bool HasPlayerStarted
        {
            get
            {
                return m_playerManager.HasPlayerStarted;
            }
        }
        public static int Count
        {
            get
            {
                return m_playerManager.Count;
            }
        }
        public static TrackCollection TrackCollection
        {
            get
            {
                return m_playerManager.TrackCollection;
            }
        }
        public static TrackCollection RandomTracks
        {
            get
            {
                return m_playerManager.RandomTracks;
            }
        }
        public static PlayMode PlayMode
        {
            get
            {
                return m_playerManager.PlayMode;
            }
            set
            {
                m_playerManager.PlayMode = value;
            }
        }
        public static PlayState PlayState
        {
            get
            {
                return m_playerManager.PlayState;
            }
        }
        #endregion

        #region MethodsPublic
        public static void LoadPlayer()
        {
            m_playerManager.LoadPlayer();
        }

        public static void LoadPlayer(BSE.Configuration.Configuration configuration)
        {
            m_playerManager.LoadPlayer(configuration);
        }

        public static void Stop()
        {
            m_playerManager.Stop();
        }

        public static void Pause()
        {
            m_playerManager.Pause();
        }

        public static void Play()
        {
            m_playerManager.Play();
        }

        public static void Close()
        {
            m_playerManager.Close();
        }

        public static void PlayNextTrack(PlayMode playMode)
        {
            m_playerManager.PlayNextTrack(playMode);
        }

        public static void PlayPreviousTrack(PlayMode playMode)
        {
            m_playerManager.PlayPreviousTrack(playMode);
        }

        public static void SetRandomTracks(TrackCollection trackCollection)
        {
            m_playerManager.SetRandomTracks(trackCollection);
        }

        public static void InitializeTracks(TrackCollection trackCollection)
        {
            SetRandomTracks(trackCollection);
            m_playerManager.TrackCollection = trackCollection;
        }
        public static void PlayTrack(BSE.Platten.BO.CTrack trackToPlay, BSE.Platten.Audio.PlayMode playMode)
        {
            m_playerManager.PlayTrack(trackToPlay, playMode);
        }
        public static void PlayTracks()
        {
            m_playerManager.PlayTracks();
        }
        public static void PlayTracks(TrackCollection trackCollection, BSE.Platten.Audio.PlayMode playMode)
        {
            m_playerManager.PlayTracks(trackCollection, playMode);
        }

        public static int GetPlaylistPosition()
        {
            return m_playerManager.GetPlaylistPosition();
        }

        public static void SetPlaylistPosition(int iPosition)
        {
            m_playerManager.SetPlaylistPosition(iPosition);
        }

        public static void SetTrackPosition(int iCurrentPostion)
        {
            m_playerManager.SetTrackPosition(iCurrentPostion);
        }

        public static int GetTrackPosition()
        {
            return m_playerManager.GetTrackPosition();
        }

        public static string GetTrackDurationAsString(int iTrackLength)
        {
            return CPlayerManager.GetTrackDurationAsString(iTrackLength);
        }

        public static int GetTrackLength()
        {
            return m_playerManager.GetTrackLength();
        }
        public static string GetSongTitle()
        {
            return m_playerManager.GetSongTitle();
        }
        public static void OnPlayerClosed(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (PlayerClosed != null)
            {
                PlayerClosed(sender, e);
            }
        }

        public static void OnTrackChanged(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (TrackChanged != null)
            {
                TrackChanged(sender, e);
            }
        }
        public static void OnPlayerPaused(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (PlayerPaused != null)
            {
                PlayerPaused(sender, e);
            }
        }
        public static void OnPlayerPlays(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (PlayerPlays != null)
            {
                PlayerPlays(sender, e);
            }
        }
        public static void OnSongFinished(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (SongFinished != null)
            {
                SongFinished(sender, e);
            }
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        static PlayerManager()
        {
            m_playerManager = new CPlayerManager();
            m_playerManager.PlayerManagerTrackChanged += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnTrackChanged);
            m_playerManager.PlayerManagerClosed += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerClosed);
            m_playerManager.PlayerManagerPaused += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerPaused);
            m_playerManager.PlayerManagerPlays += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerPlays);
            m_playerManager.PlayerManagerSongFinished += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnSongFinished);
            m_playerManager.PlayerManagerStopped += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerStopped);
            m_playerManager.PlayerStarted += new EventHandler<PlayerManagerStatusChangedEventArgs>(OnPlayerStarted);
            m_playerManager.TrackCollectionChanged += new EventHandler<EventArgs>(OnTrackCollectionChanged);
        }

        static void OnTrackCollectionChanged(object sender, EventArgs e)
        {
            if (TrackCollectionChanged != null)
            {
                TrackCollectionChanged(sender, e);
            }
        }

        static void OnPlayerStarted(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (PlayerStarted != null)
            {
                PlayerStarted(sender, e);
            }
        }

        public static void OnPlayerStopped(object sender, PlayerManagerStatusChangedEventArgs e)
        {
            if (PlayerStopped != null)
            {
                PlayerStopped(sender, e);
            }
        }
        #endregion

    }
}
