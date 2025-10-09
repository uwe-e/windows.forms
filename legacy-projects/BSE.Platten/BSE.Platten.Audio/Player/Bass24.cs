//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections.ObjectModel;
//using System.Globalization;
//using BSE.Platten.Audio.Properties;
//using Un4seen.Bass;
//using System.Windows.Threading;
//using Un4seen.Bass.AddOn.Tags;

//namespace BSE.Platten.Audio
//{
//    public class Bass24 : Player
//    {
//        #region DependenyProperties
//        #endregion

//        #region Events
//        #endregion

//        #region Constants
//        #endregion

//        #region FieldsPrivate
//        private static readonly string ClassName = "BSEtunes";
//        private int m_iDeviceLatency;
//        private DispatcherTimer m_updateTimer;
//        private int m_iStreamHandle;
//        private ObservableCollection<string> m_currentPlaylist;
//        private string m_strCurrentFile;
//        private string m_strTrackTitle;
//        #endregion

//        #region Properties
//        private ObservableCollection<string> CurrentPlaylist
//        {
//            get
//            {
//                if (this.m_currentPlaylist == null)
//                {
//                    this.m_currentPlaylist = new ObservableCollection<string>();
//                }
//                return this.m_currentPlaylist;
//            }
//        }
//        /// <summary>
//        /// The count property retrieves the number of media items in the playlist.
//        /// </summary>
//        public override int Count
//        {
//            get { return this.CurrentPlaylist.Count; }
//        }
//        /// <summary>
//        /// Gets the name of the used audioplayer
//        /// </summary>
//        public override string Name
//        {
//            get { return "Microsoft MediaPlayer"; }
//        }
//        public bool CanPlay
//        {
//            get
//            {
//                return this.m_iStreamHandle != 0;
//            }
//        }
//        #endregion

//        #region MethodsPublic
//        public Bass24()
//        {
//            this.m_updateTimer = new DispatcherTimer();
//            this.m_updateTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
//            this.m_updateTimer.Tick += new EventHandler(OnUpdateTimerTick);
//        }
//        /// <summary>
//        /// Causes the media item to start playing.
//        /// </summary>
//        /// <param name="strFile">A string containing the full path of the media file</param>
//        /// <param name="mode">the mode for playing</param>
//        public override void Play(string strFile, BSE.Platten.Audio.PlayMode mode)
//        {
//            this.Mode = mode;
//            ClearPlaylist();
//            if (CheckFile.FileExists(strFile) == true)
//            {
//                this.Play(strFile);
//            }
//        }
//        /// <summary>
//        /// Causes the media items to start playing.
//        /// </summary>
//        /// <param name="strFiles">A string[] containing the full path of the media files</param>
//        /// <param name="playMode">the mode for playing</param>
//        public override void Play(string[] strFiles, BSE.Platten.Audio.PlayMode playMode)
//        {
//            if (strFiles == null)
//            {
//                throw new ArgumentNullException(
//                    string.Format(
//                    CultureInfo.InvariantCulture,
//                    Resources.IDS_ArgumentNullException, "strFiles"));
//            }
//            this.Mode = playMode;
//            ClearPlaylist();
//            foreach (string strFileName in strFiles)
//            {
//                if (CheckFile.FileExists(strFileName) == true)
//                {
//                    this.CurrentPlaylist.Add(strFileName);
//                }
//            }
//            string strFile = this.CurrentPlaylist.FirstOrDefault();
//            if (string.IsNullOrEmpty(strFile) == false)
//            {
//                this.Play(strFile);
//            }
//        }
//        /// <summary>
//        /// Causes the media item to start playing.
//        /// </summary>
//        public override void Play()
//        {
//            if (Bass.BASS_ChannelIsActive(this.m_iStreamHandle) == BASSActive.BASS_ACTIVE_PAUSED)
//            {
//                if (Bass.BASS_ChannelPlay(this.m_iStreamHandle, false) == true)
//                {
//                    this.OnPlayerPlays(this, new PlayerEventArgs(this.Mode));
//                    this.m_updateTimer.Start();
//                }
//            }
//        }
//        /// <summary>
//        /// The pause method pauses playback of the media item.
//        /// </summary>
//        public override void Pause()
//        {
//            if (this.CanPlay == true)
//            {
//                Bass.BASS_ChannelPause(this.m_iStreamHandle);
//            }
//        }
//        /// <summary>
//        /// The stop method stops playback of the media item.
//        /// </summary>
//        public override void Stop()
//        {
//            this.Mode = PlayMode.None;
//            this.StopStream();
//        }
//         /// <summary>
//        /// Not used in Windows Media Player
//        /// </summary>
//        public override void Load()
//        {
//            IntPtr hWnd = BSE.Platten.Audio.Winamp.NativeMethods.FindWindow(null, ClassName);
//            if (hWnd.Equals(IntPtr.Zero) == false)
//            {
//                if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_LATENCY, hWnd))
//                {
//                    BASS_INFO info = new BASS_INFO();
//                    Bass.BASS_GetInfo(info);
//                    this.m_iDeviceLatency = info.latency;
//                }
//            }
//        }
//        /// <summary>
//        /// Releases Windows Media Player resources.
//        /// </summary>
//        public override void Close()
//        {
//            Bass.BASS_Stop();
//            Bass.BASS_Free();
//            this.m_updateTimer.Tick -= new EventHandler(OnUpdateTimerTick);
//        }
//        /// <summary>
//        /// Removes the content of the playlist
//        /// </summary>
//        public override void ClearPlaylist()
//        {
//            this.CurrentPlaylist.Clear();
//        }
//        public override string GetSongTitle()
//        {
//            if (this.CanPlay == true)
//            {
//                return string.IsNullOrEmpty(this.m_strTrackTitle) ? string.Empty : this.m_strTrackTitle;
//            }
//            return string.Empty;
//        }
//        /// <summary>
//        /// Gets the duration in seconds of the current media item
//        /// </summary>
//        /// <returns>the duration in seconds</returns>
//        public override int GetTrackLength()
//        {
//            if (this.CanPlay == true)
//            {
//                long trackLength = Bass.BASS_ChannelGetLength(this.m_iStreamHandle);
//                return (int)Bass.BASS_ChannelBytes2Seconds(this.m_iStreamHandle, trackLength);
//            }
//            return 0;
//        }
//        /// <summary>
//        /// Gets the current position in the media item in seconds from the beginning.
//        /// </summary>
//        /// <returns>current position in seconds</returns>
//        public override int GetTrackPosition()
//        {
//            if (this.CanPlay == true)
//            {
//                long trackPosition = Bass.BASS_ChannelGetPosition(this.m_iStreamHandle);
//                return (int)Bass.BASS_ChannelBytes2Seconds(this.m_iStreamHandle, trackPosition);
//            }
//            return 0;
//        }
//        /// <summary>
//        /// Sets the current position in the media item in seconds from the beginning.
//        /// </summary>
//        /// <param name="iCurrentPostion">current position in seconds</param>
//        public override void SetTrackPosition(int iCurrentPostion)
//        {
//            if (this.CanPlay == true)
//            {
//                Bass.BASS_ChannelSetPosition(this.m_iStreamHandle, (double)iCurrentPostion);
//            }
//        }
//        /// <summary>
//        /// Gets the new position in the playlist.
//        /// </summary>
//        /// <returns>current playlist position</returns>
//        public override int GetPlaylistPosition()
//        {
//            int iPosition = 0;
//            if (this.CanPlay == true && string.IsNullOrEmpty(this.m_strCurrentFile) == false)
//            {
//                return this.CurrentPlaylist.IndexOf(this.m_strCurrentFile);
//            }
//            return iPosition;
//        }
//        /// <summary>
//        /// Sets the new position in the playlist.
//        /// </summary>
//        /// <param name="iPosition">new playlist position</param>
//        public override void SetPlaylistPosition(int iPosition)
//        {
//            if (iPosition >= 0 && iPosition < this.Count)
//            {
//                string strFile = this.CurrentPlaylist[iPosition];
//                if (string.IsNullOrEmpty(strFile) == false)
//                {
//                    this.Play(strFile);
//                }
//            }
//        }
//        #endregion

//        #region MethodsPrivate
//        private void Play(string strFile)
//        {
//            this.StopStream();
//            this.m_iStreamHandle = Bass.BASS_StreamCreateFile(strFile, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);
//            if (this.m_iStreamHandle != 0 && Bass.BASS_ChannelPlay(this.m_iStreamHandle, false) == true)
//            {
//                this.m_strCurrentFile = strFile;
//                TAG_INFO tagInfo = new TAG_INFO(strFile);
//                if (BassTags.BASS_TAG_GetFromFile(this.m_iStreamHandle, tagInfo))
//                {
//                    this.m_strTrackTitle = string.Format(CultureInfo.InvariantCulture, "{0} - {1}",
//                        tagInfo.artist, tagInfo.title);
//                }
//                this.m_updateTimer.Start();
//                this.OnPlayerPlays(this, new PlayerEventArgs(this.Mode));
//            }
//        }
//        private void StopStream()
//        {
//            if (this.CanPlay == true)
//            {
//                Bass.BASS_StreamFree(this.m_iStreamHandle);
//                this.m_iStreamHandle = 0;
//                this.m_strCurrentFile = null;
//                this.m_strTrackTitle = null;
//            }
//        }
//        private void OnUpdateTimerTick(object sender, EventArgs e)
//        {
//            long trackPosition = Bass.BASS_ChannelGetPosition(this.m_iStreamHandle); // position in bytes
//            long trackLength = Bass.BASS_ChannelGetLength(this.m_iStreamHandle); // length in bytes
//            switch (Bass.BASS_ChannelIsActive(this.m_iStreamHandle))
//            {
//                case BASSActive.BASS_ACTIVE_STOPPED:
//                    this.m_updateTimer.Stop();
//                    if (trackPosition.Equals(trackLength) == true)
//                    {
//                        this.m_updateTimer.Stop();
//                        if (this.Mode == PlayMode.Playlist || this.Mode == PlayMode.Random || this.Mode == PlayMode.Song)
//                        {
//                            this.PlayState = Audio.PlayState.Ended;
//                            this.OnSongEnded(this, new PlayerEventArgs(this.Mode));
//                        }
//                        else
//                        {
//                            this.OnPlayerStopped(this, new PlayerEventArgs(this.Mode));
//                            if (this.Mode == PlayMode.CD)
//                            {
//                                int iIndex = this.CurrentPlaylist.IndexOf(this.m_strCurrentFile);
//                                if (iIndex != -1)
//                                {
//                                    if (iIndex + 1 >= 0 && iIndex + 1 < this.Count)
//                                    {
//                                        string strFile = this.CurrentPlaylist[iIndex + 1];
//                                        this.Play(strFile);
//                                    }
//                                }
//                            }
//                        }
//                    }
//                    break;
//                case BASSActive.BASS_ACTIVE_PAUSED:
//                    this.m_updateTimer.Stop();
//                    this.OnPlayerPaused(this, new PlayerEventArgs(this.Mode));
//                    break;
//            }
//        }
//        #endregion
//    }
//}
