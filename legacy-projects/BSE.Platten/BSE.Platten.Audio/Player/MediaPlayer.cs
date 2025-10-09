using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public class MediaPlayer : Player
    {
        #region FieldsPrivate

        private WMPLib.WindowsMediaPlayer m_mediaPlayer;
        private WMPLib.WMPPlayState m_ePlayState;
        private int m_iTrackPosition;

        #endregion

        #region Properties
        /// <summary>
        /// The count property retrieves the number of media items in the playlist.
        /// </summary>
        public override int Count
        {
            get { return this.m_mediaPlayer.currentPlaylist.count; }
        }
        /// <summary>
        /// Gets the name of the used audioplayer
        /// </summary>
        public override string Name
        {
            get { return "Microsoft MediaPlayer"; }
        }
        #endregion

        #region MethodsPublic

        public MediaPlayer()
        {
            this.m_mediaPlayer = new WMPLib.WindowsMediaPlayer();
            this.m_mediaPlayer.settings.autoStart = false;
            this.m_mediaPlayer.settings.setMode("autoRewind", false);
            this.m_mediaPlayer.settings.playCount = 1;
            this.m_mediaPlayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(PlayStateChange);
        }
        /// <summary>
        /// Causes the media item to start playing.
        /// </summary>
        public override void Play()
        {
            this.m_mediaPlayer.controls.play();
        }
        /// <summary>
        /// Causes the media item to start playing.
        /// </summary>
        /// <param name="strFile">A string containing the full path of the media file</param>
        /// <param name="mode">the mode for playing</param>
        public override void Play(string strFile, BSE.Platten.Audio.PlayMode mode)
        {
            this.Mode = mode;
            ClearPlaylist();
            try
            {
                if (CheckFile.FileExists(strFile) == true)
                {
                    WMPLib.IWMPMedia wmpMedia = this.m_mediaPlayer.newMedia(strFile);
                    this.m_mediaPlayer.currentPlaylist.insertItem(0, wmpMedia);
                    if (this.m_mediaPlayer.currentPlaylist.count > 0)
                    {
                        this.m_mediaPlayer.controls.play();
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw;
            }
        }
        /// <summary>
        /// Causes the media items to start playing.
        /// </summary>
        /// <param name="strFiles">A string[] containing the full path of the media files</param>
        /// <param name="playMode">the mode for playing</param>
        public override void Play(string[] strFiles, BSE.Platten.Audio.PlayMode playMode)
        {
            if (strFiles == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException, "strFiles"));
            }
            this.Mode = playMode;
            int iFileCount = strFiles.Length;
            string[] files = strFiles;

            ClearPlaylist();

            for (int i = 0; i < iFileCount; i++)
            {
                string fileName = files[i];
                try
                {
                    if (CheckFile.FileExists(fileName) == true)
                    {
                        WMPLib.IWMPMedia wmpMedia = this.m_mediaPlayer.newMedia(fileName);
                        this.m_mediaPlayer.currentPlaylist.appendItem(wmpMedia);
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    throw;
                }
            }
            if (this.m_mediaPlayer.currentPlaylist.count > 0)
            {
                this.m_mediaPlayer.controls.play();
            }
        }
        /// <summary>
        /// Not used in Windows Media Player
        /// </summary>
        public override void Load()
        {
        }
        /// <summary>
        /// Releases Windows Media Player resources.
        /// </summary>
        public override void Close()
        {
            this.m_mediaPlayer.PlayStateChange -= new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(PlayStateChange);
            OnPlayerClosed(this,new PlayerEventArgs(this.Mode));
            //this.m_mediaPlayer.close();
        }
        /// <summary>
        /// The pause method pauses playback of the media item.
        /// </summary>
        public override void Pause()
        {
            this.m_mediaPlayer.controls.pause();
        }
        /// <summary>
        /// The stop method stops playback of the media item.
        /// </summary>
        public override void Stop()
        {
            this.Mode = PlayMode.None;
            this.m_mediaPlayer.controls.stop();
        }
        /// <summary>
        /// Gets the new position in the playlist.
        /// </summary>
        /// <returns>current playlist position</returns>
        public override int GetPlaylistPosition()
        {
            int iPlayListPosition = 0;
            int iCount = this.m_mediaPlayer.currentPlaylist.count;
            if (iCount > 0)
            {
                for (int i = 0; i < iCount; i++)
                {
                    WMPLib.IWMPMedia wmpMedia = this.m_mediaPlayer.currentPlaylist.get_Item(i);
                    if (this.m_mediaPlayer.controls.currentItem.get_isIdentical(wmpMedia))
                    {
                        iPlayListPosition = i;
                        break;
                    }
                }
            }
            return iPlayListPosition;
        }
        /// <summary>
        /// Sets the new position in the playlist.
        /// </summary>
        /// <param name="iPosition">new playlist position</param>
        public override void SetPlaylistPosition(int iPosition)
        {
            if (iPosition >= 0 && iPosition < this.Count)
            {
                WMPLib.IWMPMedia wmpMedia = this.m_mediaPlayer.currentPlaylist.get_Item(iPosition);
                this.m_mediaPlayer.controls.playItem(wmpMedia);
            }
        }
        /// <summary>
        /// Removes the content of the playlist
        /// </summary>
        public override void ClearPlaylist()
        {
            this.m_mediaPlayer.currentPlaylist.clear();
        }
        /// <summary>
        /// Sets the current position in the media item in seconds from the beginning.
        /// </summary>
        /// <param name="iCurrentPostion">current position in seconds</param>
        public override void SetTrackPosition(int iCurrentPostion)
        {
            if (iCurrentPostion >= 0)
            {
                double dCurrentPosition = Convert.ToDouble(iCurrentPostion);
                this.m_mediaPlayer.controls.currentPosition = dCurrentPosition;
            }
        }
        /// <summary>
        /// Gets the current position in the media item in seconds from the beginning.
        /// </summary>
        /// <returns>current position in seconds</returns>
        public override int GetTrackPosition()
        {
            try
            {
                if (this.m_ePlayState != WMPLib.WMPPlayState.wmppsTransitioning)
                {
                    this.m_iTrackPosition = Convert.ToInt32(this.m_mediaPlayer.controls.currentPosition);
                }
            }
            catch
            {
                //throw new Exception("MediaPlayer GetTrackPosition Playstate" + this.m_ePlayState.ToString());
            }
            return this.m_iTrackPosition;
        }
        /// <summary>
        /// Gets the duration in seconds of the current media item
        /// </summary>
        /// <returns>the duration in seconds</returns>
        public override int GetTrackLength()
        {
            return Convert.ToInt32(this.m_mediaPlayer.currentMedia.duration);
        }

        public override string GetSongTitle()
        {
            string strAuthor = this.m_mediaPlayer.currentMedia.getItemInfo(WMFSDK.WMFSDKFunctions.g_wszWMAuthor);
            string strTitle = this.m_mediaPlayer.currentMedia.getItemInfo(WMFSDK.WMFSDKFunctions.g_wszWMTitle);
            if ((String.IsNullOrEmpty(strAuthor) == false) && (String.IsNullOrEmpty(strTitle) == false))
            {
                return strAuthor + " - " + strTitle;
            }
            else
            {
                return UnknownTitle;
            }
        }

        #endregion

        #region MethodsPrivate

        private void PlayStateChange(int playState)
        {
            WMPLib.WMPPlayState ePlayState = (WMPLib.WMPPlayState)playState;
            this.m_ePlayState = ePlayState;
            this.PlayState = PlayState.Undefined;
            switch (ePlayState)
            {
                case WMPLib.WMPPlayState.wmppsReady:
                    //Wird keine Playlist (nicht Mode.CD, alle anderen Modi) abgespielt..
                    if ((this.Mode == PlayMode.Playlist) || (this.Mode == PlayMode.Random) || (this.Mode == PlayMode.Song))
                    {
                        //soll der Player weiterlaufen
                        this.m_mediaPlayer.controls.play();
                    }
                    break;
                case WMPLib.WMPPlayState.wmppsMediaEnded:
                    this.PlayState = PlayState.Ended;
                    if (this.Mode != PlayMode.CD)
                    {
                        OnSongEnded(this, new PlayerEventArgs(this.Mode));
                    }
                    else
                    {
                        //Ist der zuletzt beendete Track identisch mit dem letzten Track in
                        //der Playlist wird der Player gestoppt
                        WMPLib.IWMPMedia wmpMedia = this.m_mediaPlayer.currentPlaylist.get_Item(this.Count - 1);
                        if (this.m_mediaPlayer.controls.currentItem.get_isIdentical(wmpMedia) == true)
                        {
                            OnPlayerStopped(this, new PlayerEventArgs(this.Mode));
                        }
                    }
                    break;
                case WMPLib.WMPPlayState.wmppsStopped:
                    this.PlayState = PlayState.Stopped;
                    OnPlayerStopped(this, new PlayerEventArgs(this.Mode));
                    break;
                case WMPLib.WMPPlayState.wmppsPlaying:
                    this.PlayState = PlayState.Playing;
                    OnPlayerPlays(this, new PlayerEventArgs(this.Mode));
                    break;
                case WMPLib.WMPPlayState.wmppsPaused:
                    this.PlayState = PlayState.Paused;
                    OnPlayerPaused(this, new PlayerEventArgs());
                    break;
            }
        }
        
        #endregion
    }
}
