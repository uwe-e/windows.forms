using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using BSE.Platten.BO;
using BSE.Platten.Audio;
using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Tunes.Properties;

namespace BSE.Platten.Tunes
{
    public partial class PlayList : UserControl
    {
        #region Constants

        private const string m_strParentControlCaption = "Wiedergabeliste: ";
        private const string m_strEmptyPlayList = "keine Playliste ausgewählt";

        #endregion

        #region Enums

        public enum PlayListDragDropMode
        {
            Albums,
            PlayList
        }

        #endregion

        #region EventsPublic

        public event EventHandler<PlayListEventArgs> PlayListInserted;
        public event EventHandler<PlayListEventArgs> PlayListChanged;
        public event EventHandler<PlayListEventArgs> PlayListDeleted;

        #endregion
        
        #region FieldsPrivate

        private BSE.Platten.BO.Environment m_environment;
        private Playlist m_currentPlayList;
        private CTrack m_selectedTrack;
        private ToolStripMenuItem m_parentToolStripMenuItem;
        private Control m_parentControl;
        private bool m_bPlayListHasChanged;

        #endregion
        
        #region Properties

        public BSE.Configuration.Configuration Settings
        {
            get { return this.m_settings; }
            set { this.m_settings = value; }
        }

        public BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set
            {
                this.m_environment = value;
            }
        }

        public ToolStripMenuItem ParentToolStripMenuItem
        {
            get { return this.m_parentToolStripMenuItem; }
            set { this.m_parentToolStripMenuItem = value; }
        }

        public object DataContext
        {
            get
            {
                return this.playlist1.DataContext;
            }
            set
            {
                this.playlist1.DataContext = value;
            }
        }

        #endregion

        #region MethodsPublic

        public PlayList()
        {
            InitializeComponent();
            UpdateViewState();
        }

        public void SetPlaylist(int iPlayListId)
        {
            SetCurrentPlayList(iPlayListId);
        }

        public void SetNewPlayList()
        {
            NewPlaylist();
        }

        public void SetDeletePlayList()
        {
            DeletePlaylist();
        }

        public void SetPlayTracks()
        {
            //if (this.playlist1.Items.Count == 0)
            //{
            //    string strMessage = String.Format(
            //        CultureInfo.CurrentUICulture,
            //        Resources.IDS_PlayListEmptyException,
            //        this.m_currentPlayList.Name);
            //    GlobalizedMessageBox.Show(this, strMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //PlayTracks(BSE.Platten.Audio.PlayMode.Playlist);
        }

        public void SetPlayRandomTracks()
        {
            //if (this.playlist1.Items.Count == 0)
            //{
            //    string strMessage = String.Format(
            //        CultureInfo.CurrentUICulture,
            //        Resources.IDS_PlayListEmptyException,
            //        this.m_currentPlayList.Name);
            //    GlobalizedMessageBox.Show(this,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //PlayTracks(BSE.Platten.Audio.PlayMode.Random);
        }
        public void SetPlayLists(BSE.Platten.BO.Playlist[] playLists)
        {
            this.m_btnPlaylists.DropDownItems.Clear();
            if (playLists != null)
            {
                foreach (Playlist playlist in playLists)
                {
                    if (playlist != null)
                    {
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(playlist.Name);
                        menuItem.Tag = playlist;
                        menuItem.Click += new EventHandler(this.MenuItemChangeCurrentPlaylistClick);
                        this.m_btnPlaylists.DropDownItems.Add(menuItem);
                    }
                }
            }

        }
        
        #endregion

        #region MethodsProtected
        

        protected void OnPlayListInserted(PlayListEventArgs e)
        {
            if (PlayListInserted != null)
            {
                PlayListInserted(this, e);
            }
        }

        protected void OnPlayListDeleted(PlayListEventArgs e)
        {
            if (PlayListDeleted != null)
            {
                PlayListDeleted(this, e);
            }
        }

        protected void OnPlayListChanged(PlayListEventArgs e)
        {
            if (PlayListChanged != null)
            {
                PlayListChanged(this, e);
            }
        }

        #endregion

        #region MethodsPrivate
        
        private void MenuItemChangeCurrentPlaylistClick(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedMenuItem = sender as ToolStripMenuItem;
            if (selectedMenuItem != null && selectedMenuItem.Tag != null)
            {
                Playlist selectedPlaylist = selectedMenuItem.Tag as Playlist;
                if (selectedPlaylist != null)
                {
                    this.SetCurrentPlayList(selectedPlaylist.Id);
                }
            }
        }

        private void PlayListLoad(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.FormClosing += new FormClosingEventHandler(PlayListFormClosing);
                //LoadSettings();
            }
            this.m_parentControl = this.Parent;
            if (m_parentControl != null)
            {
                m_parentControl.Text = string.Format(CultureInfo.CurrentUICulture,"{0} {1}", Resources.IDS_PlayListCaptionbarText, Resources.IDS_PlayListCaptionbarTextNoPlaylistSelected);
                m_parentControl.VisibleChanged += new EventHandler(PlayListVisibleChanged);
            }
        }

        private void PlayListFormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveSettings();
        }
        
        private void PlayListVisibleChanged(object sender, EventArgs e)
        {
            if (this.m_parentToolStripMenuItem != null)
            {
                this.m_parentToolStripMenuItem.Checked = this.Visible;
            }
        }
        
        private void NewPlayListClick(object sender, EventArgs e)
        {
            NewPlaylist();
        }
        
        private void SavePlayListClick(object sender, EventArgs e)
        {
            SavePlaylist();
        }

        private void DeletePlayListClick(object sender, EventArgs e)
        {
            DeletePlaylist();
        }
        
        private void PlayTracksClick(object sender, EventArgs e)
        {
            PlayTracks(BSE.Platten.Audio.PlayMode.Playlist);
        }

        private void PlaySelectedTracksClick(object sender, EventArgs e)
        {
            PlaySelectedTracks(BSE.Platten.Audio.PlayMode.Playlist);
        }
        private void PlayRandomClick(object sender, EventArgs e)
        {
            PlayTracks(BSE.Platten.Audio.PlayMode.Random);
        }
        
        private void NewPlayListInserted(object sender, PlayListEventArgs e)
        {
            //if (e.PlayList != null)
            //{
            //    this.playlist1.Items.Clear();
            //    this.m_currentPlayList = e.PlayList;
                
            //    if (this.m_parentControl != null)
            //    {
            //        this.m_parentControl.Text = string.Format(
            //            CultureInfo.CurrentUICulture,
            //            "{0} {1}",
            //            Resources.IDS_PlayListCaptionbarText,
            //            Resources.IDS_PlayListCaptionbarTextNoPlaylistSelected, this.m_currentPlayList.Name);
            //        this.m_parentControl.Refresh();
            //    }
            //    UpdateViewState();
            //    OnPlayListInserted(new PlayListEventArgs(this.m_currentPlayList));
            //}
        }

        private void SetCurrentPlayList(int iPlayListId)
        {
            //this.playlist1.Items.Clear();
            //this.m_bPlayListHasChanged = false;
            //Cursor.Current = Cursors.WaitCursor;
            //if (this.m_environment != null)
            //{
            //    CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.m_environment.GetConnectionString());
            //    try
            //    {
            //        this.m_currentPlayList = tunesBusinessObject.GetPlayListByPlayListId(iPlayListId);
            //        if (this.m_currentPlayList != null)
            //        {
            //            CTrack[] tracks = m_currentPlayList.Tracks;
            //            if (tracks != null)
            //            {
            //                string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.m_environment);
            //                tracks.ToList().ForEach(delegate(CTrack track)
            //                {
            //                    track.FileFullName = strAudioHomeDirectory + track.FileName;
            //                    this.playlist1.Items.Add(track);
            //                });
            //                ((System.Collections.Specialized.INotifyCollectionChanged)playlist1.Items).CollectionChanged +=
            //                    OnItemCollectionChanged;
            //            }
            //            if (this.m_parentControl != null)
            //            {
            //                this.m_parentControl.Text = string.Format(
            //                    CultureInfo.CurrentUICulture,
            //                    "{0} {1}",
            //                    Resources.IDS_PlayListCaptionbarText,
            //                    this.m_currentPlayList.Name);
            //            }
            //            OnPlayListChanged(new PlayListEventArgs(this.m_currentPlayList));
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        string strMessage = string.Format(
            //            CultureInfo.CurrentUICulture,
            //            "{0} {1}",
            //            Resources.IDS_PlayListLoadException + exception.Message);
            //        GlobalizedMessageBox.Show(this,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        UpdateViewState();
            //    }
            //}
            //Cursor.Current = Cursors.Default;
        }

        private void OnItemCollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.m_bPlayListHasChanged = true;
        }

        private void NewPlaylist()
        {
            if (this.m_environment != null)
            {
                using (NewPlayList newPlaylist = new NewPlayList(this.m_environment))
                {
                    newPlaylist.PlayListInserted -= new EventHandler<PlayListEventArgs>(NewPlayListInserted);
                    newPlaylist.PlayListInserted += new EventHandler<PlayListEventArgs>(NewPlayListInserted);
                    newPlaylist.ShowDialog();
                }
            }
        }

        private void SavePlaylist()
        {
            //Cursor.Current = Cursors.WaitCursor;
            //if (this.m_bPlayListHasChanged)
            //{
            //    System.Collections.ArrayList aPlaylistEntries = new System.Collections.ArrayList();
            //    PlaylistEntry[] playListEntries = null;
            //    //-----
            //    if (this.playlist1.Items != null)
            //    {
            //        playListEntries = (from CTrack track in this.playlist1.Items
            //         select new PlaylistEntry
            //         {
            //             Guid = System.Guid.NewGuid(),
            //             EntryId = -1,
            //             LiedId = track.LiedId,
            //             PlayListId = this.m_currentPlayList.Id
            //         }).ToArray();

            //        if (playListEntries != null)
            //        {
            //            this.m_currentPlayList.PlayListEntries = playListEntries;

            //            CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.m_environment.GetConnectionString());
            //            try
            //            {
            //                tunesBusinessObject.SavePlayList(this.m_currentPlayList);
            //            }
            //            catch (Exception exception)
            //            {
            //                string strMessage = string.Format(
            //                    CultureInfo.CurrentUICulture,
            //                    "{0} {1}",
            //                    Resources.IDS_PlayListSaveException, exception.Message);
            //                GlobalizedMessageBox.Show(this, strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            finally
            //            {
            //                UpdateViewState();
            //                Cursor.Current = Cursors.Default;
            //            }
            //        }
            //    }
            //}
        }

        private void DeletePlaylist()
        {
            //string strPlaylistName = this.m_currentPlayList.Name;
            //string strWarning = string.Format(CultureInfo.CurrentUICulture,Resources.IDS_PlayListDeleteWarningException, strPlaylistName);

            //DialogResult dialogResult = GlobalizedMessageBox.Show(
            //    this,strWarning
            //    , MessageBoxButtons.YesNo
            //    , MessageBoxIcon.Warning);

            //if (dialogResult == DialogResult.Yes)
            //{
            //    if (this.m_environment != null)
            //    {
            //        CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.m_environment.GetConnectionString());
            //        try
            //        {
            //            tunesBusinessObject.DeletePlayList(this.m_currentPlayList.Id);
            //        }
            //        catch (Exception exception)
            //        {
            //            string strMessage = string.Format(
            //                CultureInfo.CurrentUICulture,
            //                "{0} {1}", Resources.IDS_PlayListDeleteException, exception.Message); 
            //            GlobalizedMessageBox.Show(this, strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        this.playlist1.Items.Clear();
            //        this.m_currentPlayList = null;
            //        if (this.m_parentControl != null)
            //        {
            //            this.m_parentControl.Text = string.Format(
            //                CultureInfo.CurrentUICulture,
            //                "{0} {1}",
            //                Resources.IDS_PlayListCaptionbarText,
            //                Resources.IDS_PlayListCaptionbarTextNoPlaylistSelected);
            //            this.m_parentControl.Refresh();
            //        }
            //        UpdateViewState();
            //        this.OnPlayListDeleted(new PlayListEventArgs(this.m_currentPlayList));
            //    }
            //}
        }
        
        private void PlayTracks(BSE.Platten.Audio.PlayMode eMode)
        {
            //TrackCollection tracksCollection = null;
            //if (this.playlist1.Items != null)
            //{
            //    tracksCollection = new TrackCollection();
            //    (from CTrack track in this.playlist1.Items
            //     select track).ToList()
            //     .ForEach(delegate(CTrack track)
            //    {
            //        if (track != null)
            //        {
            //            tracksCollection.Add(track);
            //        }
            //    });
            //}
            //if (tracksCollection != null)
            //{
            //    PlayerManager.PlayTracks(tracksCollection, eMode);
            //}
        }

        private void PlaySelectedTracks(BSE.Platten.Audio.PlayMode eMode)
        {
            //TrackCollection tracksCollection = null;
            //if (this.playlist1.SelectedItems != null)
            //{
            //    tracksCollection = new TrackCollection();
            //    (from CTrack track in this.playlist1.SelectedItems
            //     select track).ToList()
            //     .ForEach(delegate(CTrack track)
            //     {
            //         if (track != null)
            //         {
            //             tracksCollection.Add(track);
            //         }
            //     });
            //}
            //if (tracksCollection != null)
            //{
            //    PlayerManager.PlayTracks(tracksCollection, eMode);
            //}
        }

        private void UpdateViewState()
        {
            //if (this.m_currentPlayList != null)
            //{
            //    this.m_btnSave.Enabled = true;
            //    this.m_btnDelete.Enabled = true;
            //}
            //else
            //{
            //    this.m_btnSave.Enabled = false;
            //    this.m_btnDelete.Enabled = false;
            //}
            //if (this.playlist1.Items.Count > 0)
            //{
            //    this.m_btnPlay.Enabled = true;
            //}
            //else
            //{
            //    this.m_btnPlay.Enabled = false;
            //}
        }

        //private void LoadSettings()
        //{
        //    if (this.m_settings != null)
        //    {
        //        PlayListSettingsData playListSettingsData = new PlayListSettingsData();
        //        playListSettingsData = playListSettingsData.LoadSettings(this, this.m_settings, playListSettingsData) as PlayListSettingsData;
        //        if (playListSettingsData != null)
        //        {
        //            //-------------------------------------------------------------------------------
        //            // Spaltenbreiten für die PlayList ListView neu setzen.
        //            //-------------------------------------------------------------------------------
        //            int iSizeLvwPlayList = this.m_lstvPlayList.Columns.Count;
        //            int[] columnWidthsLvwPlayList = playListSettingsData.ColumnWidthsLvwPlayList;
        //            if (columnWidthsLvwPlayList != null)
        //            {
        //                int iSizeIntArray = columnWidthsLvwPlayList.Length;
        //                for (int i = 0; i < iSizeLvwPlayList; ++i)
        //                {
        //                    if (i < iSizeIntArray)
        //                    {
        //                        this.m_lstvPlayList.Columns[i].Width = columnWidthsLvwPlayList[i];
        //                    }
        //                    else
        //                    {
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private void SaveSettings()
        //{
        //    if (this.m_settings != null)
        //    {
        //        PlayListSettingsData playListSettingsData = new PlayListSettingsData();
        //        //-------------------------------------------------------------------------------
        //        // Spaltenbreiten für die PlayList ListView speichern.
        //        //-------------------------------------------------------------------------------
        //        int iSizeLvwPlayList = this.m_lstvPlayList.Columns.Count;
        //        int[] columnWidthsLvwPlayList = new int[iSizeLvwPlayList];
        //        for (int i = 0; i < iSizeLvwPlayList; ++i)
        //        {
        //            columnWidthsLvwPlayList[i] = this.m_lstvPlayList.Columns[i].Width;
        //        }
        //        playListSettingsData.ColumnWidthsLvwPlayList = columnWidthsLvwPlayList;
        //        playListSettingsData.SaveSettings(this, this.m_settings, playListSettingsData);
        //    }
        //}

        #endregion
    }
    
    public class PlayListSettingsData : BaseControlSettingsData
    {
        #region Fields
        /// <summary>
        /// Spaltenbreiten für die PlayList ListView
        /// </summary>
        private int[] m_iarColumnWidthsLvwPlayList;
        #endregion

        #region Properties
        /// <summary>
        /// Spaltenbreiten für die PlayList ListView
        /// </summary>
        public int[] ColumnWidthsLvwPlayList
        {
            get { return this.m_iarColumnWidthsLvwPlayList; }
            set { this.m_iarColumnWidthsLvwPlayList = value; }
        }
        #endregion
    }
}
