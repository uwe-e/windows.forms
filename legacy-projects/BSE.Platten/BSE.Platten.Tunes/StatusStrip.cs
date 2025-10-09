using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

using BSE.Platten.Common;
using BSE.Platten.BO;
using System.Globalization;

namespace BSE.Platten.Tunes
{
    /// <summary>
    /// Represents status bar control for the BSEtunes window. 
    /// </summary>
    public partial class StatusStrip : System.Windows.Forms.StatusStrip
    {
        #region Events
        /// <summary>
        /// Occurs when the availability of the database host has changed.
        /// </summary>
        public event EventHandler<HostAvailableEventArgs> HostAvailabilityChanged;
        /// <summary>
        /// Occurs when a removable drive has added.
        /// </summary>
        public event EventHandler<BSE.RemovableDrives.DriveChangeEventArgs> RemovableDriveAdded;
        /// <summary>
        /// Occurs when a removable drive has removed.
        /// </summary>
        public event EventHandler<BSE.RemovableDrives.DriveChangeEventArgs> RemovableDriveRemoved;
        /// <summary>
        /// Occurs when a removable drive has changed.
        /// </summary>
        public event EventHandler<BSE.RemovableDrives.DriveChangeEventArgs> RemovableDriveChanges;
        #endregion

        #region FieldsPrivate

        private CToolStripStatusLabelCheckDB m_lblCheckDb;
        private Image m_imgSong;
        private Image m_imgCD;
        private Image m_imgPlaylist;
        private Image m_imgRandom;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the StatusStrip class.
        /// </summary>
        public StatusStrip()
        {
            InitializeComponent();
            
            this.m_imgSong = Properties.Resources.song;
            this.m_imgCD = Properties.Resources.cd_hoeren;
            this.m_imgPlaylist = Properties.Resources.wiedergabe16;
            this.m_imgRandom = Properties.Resources.Shuffle_icon;
            
            this.m_lblCheckDb = new CToolStripStatusLabelCheckDB();
            this.m_lblCheckDb.HostAvailabilityChanged += new EventHandler<HostAvailableEventArgs>(CheckDbHostAvailabilityChanged);
            this.Items.Add(this.m_lblCheckDb);
        }
        /// <summary>
        /// Checks whether the database host is available.
        /// </summary>
        /// <param name="environment">The <see cref="CEnvironment"/> object.</param>
        /// <returns>True, if the database is available else false.</returns>
        public bool IsHostAvailable(BSE.Platten.BO.Environment environment)
        {
            return this.m_lblCheckDb.IsHostAvailable(environment);
        }
        /// <summary>
        /// Sets the ticker text for the current track into the statusbar
        /// </summary>
        /// <param name="currentTrack"></param>
        /// <param name="playMode"></param>
        public void SetTickerText(CTrack currentTrack, BSE.Platten.Audio.PlayMode playMode)
        {
            CTrack track = currentTrack.Clone() as CTrack;
            if (track != null)
            {
                Image image = null;
                string strTitleText = String.Empty;
                switch (playMode)
                {
                    case BSE.Platten.Audio.PlayMode.Playlist:
                        image = this.m_imgPlaylist;
                        strTitleText = string.Format(
                            CultureInfo.CurrentUICulture,
                            "{0} {1} - {2} - {3}",
                            Properties.Resources.IDS_StatusStripLabelPlayerTitlePlaylist,
                                track.Interpret,
                                track.Album,
                                track.Title);
                        break;
                    case BSE.Platten.Audio.PlayMode.Song:
                        image = this.m_imgSong;
                        strTitleText = string.Format(
                            CultureInfo.CurrentUICulture,
                            "{0} {1} - {2} - {3}",
                            Properties.Resources.IDS_StatusStripLabelPlayerTitleSong,
                                track.Interpret,
                                track.Album,
                                track.Title);
                        break;
                    case BSE.Platten.Audio.PlayMode.CD:
                        image = this.m_imgCD;
                        strTitleText = string.Format(
                            CultureInfo.CurrentUICulture,
                            "{0} {1} - {2}",
                            Properties.Resources.IDS_StatusStripLabelPlayerTitleAlbum,
                                track.Interpret,
                                track.Album);
                        break;
                    case BSE.Platten.Audio.PlayMode.Random:
                        image = this.m_imgRandom;
                        strTitleText = string.Format(
                            CultureInfo.CurrentUICulture,
                            "{0} {1} - {2} - {3}",
                            Properties.Resources.IDS_StatusStripLabelPlayerTitleRandom,
                                track.Interpret,
                                track.Album,
                                track.Title);
                        break;
                }
                if (image != null)
                {
                    this.m_lblPlayerTitle.Image = image;
                }
                this.m_lblPlayerTitle.Text = strTitleText.Replace("&", "&&");
            }
        }
        #endregion

        #region MethodsPrivate

        private void CheckDbHostAvailabilityChanged(object sender, HostAvailableEventArgs e)
        {
            if (HostAvailabilityChanged != null)
            {
                HostAvailabilityChanged(this, e);
            }
        }

        private void RemovableDriveControllerDriveAdded(object sender, BSE.RemovableDrives.DriveChangeEventArgs e)
        {
            if (this.RemovableDriveAdded != null)
            {
                this.RemovableDriveAdded(sender, e);
            }
        }

        private void RemovableDriveControllerDriveChanges(object sender, BSE.RemovableDrives.DriveChangeEventArgs e)
        {
            if (this.RemovableDriveChanges != null)
            {
                this.RemovableDriveChanges(sender, e);
            }
        }
        
        private void RemovableDriveControllerDriveRemoved(object sender, BSE.RemovableDrives.DriveChangeEventArgs e)
        {
            if (this.RemovableDriveRemoved != null)
            {
                this.RemovableDriveRemoved(sender, e);
            }
        }
        #endregion
        
    }
}
