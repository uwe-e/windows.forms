using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.CDDrives;
using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Reflection;
using System.Security.Permissions;
using System.Globalization;
using BSE.Platten.FreeDb.Properties;

namespace BSE.Platten.FreeDb
{
    public partial class MainForm : BaseForm
    {
        #region Constants

        private const string m_strSettingsFileNameSettingsPart = ".Settings";

        #endregion
        
        #region FieldsPrivate

        private CDDrive m_CDDrive;
        private Album m_currentAlbum;
        private List<CTrack> m_importTrackCollection;

        #endregion

        #region Properties

        public string ConfigurationFolder
        {
            get { return this.GetType().Namespace; }
        }

        public string ConfigurationFileName
        {
            get { return this.GetType().Namespace; }
        }

        public string SettingsFileName
        {
            get { return ConfigurationFileName + m_strSettingsFileNameSettingsPart; }
        }

        internal string StatusBarPanelCDText
        {
            set { this.m_ssMain.Text = value; }
        }
        /// <summary>
        /// Gets the tracklist for importing
        /// </summary>
        public List<CTrack> ImportTrackCollection
        {
            get { return this.m_importTrackCollection; }
        }
        #endregion

        #region MethodsPublic

        public MainForm()
        {
            InitializeComponent();
            this.m_lstvMain.AlternatingBackColor = BSEColors.AlternatingBackColor;
            this.m_btnOK.Enabled = false;

            this.m_settings.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_settings.ConfigFileName = this.SettingsFileName;

            this.AllowDrop = true;
            this.KeyPreview = true;
        }

        #endregion

        #region MethodsPrivate

        private void m_btnBearbeiten_OpenDrive_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ClearAllControls();
            if (this.m_CDDrive.EjectCD())
            {
                StatusBarPanelCDText = "CD wird ausgeworfen";
            }
            Cursor.Current = Cursors.Default;
        }

        private void m_mnuDatei_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cboCDDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnBrowseFreeDb.Enabled = false;
            ClearAllControls();
            this.m_cboCDDrives.Enabled = false;
            this.m_CDDrive.Close();
            LoadCD();
            this.m_cboCDDrives.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_btnBrowseFreeDb_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnOK.Enabled = false;
            if (this.m_CDDrive.IsCDReady())
            {
                FreeDb freeDb = new FreeDb();
                try
                {
                    Album album = freeDb.GetMediaDataForCD(m_CDDrive.GetQueryStringOfDisc());
                    if (album != null)
                    {
                        this.m_btnOK.Enabled = true;
                        this.m_currentAlbum = album;
                        this.m_txtMediaId.Text = album.MediaId;
                        this.m_txtArtistName.Text = album.Interpret;
                        this.m_txtAlbumName.Text = album.Title;
                        this.m_txtGenre.Text = album.Genre;
                        this.m_txtYear.Text = album.Year.ToString(CultureInfo.InvariantCulture);

                        LoadCDIntoListView();
                    }
                }
                catch (FreeDBMatchNoneException freeDbMatchNoneException)
                {
                    GlobalizedMessageBox.Show(this,freeDbMatchNoneException.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            if (this.m_currentAlbum != null)
            {
                foreach (ListViewItem listViewItem in this.m_lstvMain.Items)
                {
                    if (this.m_importTrackCollection == null)
                    {
                        this.m_importTrackCollection = new List<CTrack>();
                    }
                    CTrack track = listViewItem.Tag as CTrack;
                    if (track != null)
                    {
                        this.m_importTrackCollection.Add(track);
                    }
                }

                if ((this.m_importTrackCollection != null) && (this.m_importTrackCollection.Count > 0))
                {
                    PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(CTrack));
                    PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find("TrackNumber", false);
                    this.m_importTrackCollection.Sort(new PropertyComparer<CTrack>(propertyDescriptor, ListSortDirection.Ascending));
                }
            }
        }

        private void m_lstvMain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    foreach (ListViewItem listViewItem in this.m_lstvMain.SelectedItems)
                    {
                        this.m_lstvMain.Items.Remove(listViewItem);
                    }
                    break;
            }
        }
        
        private void m_lstvMain_SubItemEndEditing(object sender, BSE.Windows.Forms.SubItemEndEditingEventArgs e)
        {
            if (this.m_currentAlbum != null)
            {
                ListViewItem listViewItem = e.ListViewItem;
                CTrack track = (CTrack)listViewItem.Tag;
                int iTrackIndex = track.Index;
                this.m_currentAlbum.Tracks[iTrackIndex].Title = e.DisplayText;
            }
        }
        
        private void m_txtStartIndex_TextChanged(object sender, EventArgs e)
        {
            GetTrackStartIndex();
            LoadCDIntoListView();
        }
        
        private void m_CDDrive_CDInserted(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.m_CDDrive.Open(char.Parse(this.m_cboCDDrives.Items[this.m_cboCDDrives.SelectedIndex].ToString())))
            {
                LoadCD();
            }
            Cursor.Current = Cursors.Default;
        }

        private void m_CDDrive_CDRemoved(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnBrowseFreeDb.Enabled = false;
            ClearAllControls();
            StatusBarPanelCDText = "CD wurde ausgeworfen";
            Cursor.Current = Cursors.Default;
        }

        private void CMain_Load(object sender, EventArgs e)
        {
            this.m_CDDrive = new CDDrive();
            this.m_CDDrive.CDInserted += new EventHandler(this.m_CDDrive_CDInserted);
            this.m_CDDrive.CDRemoved += new EventHandler(this.m_CDDrive_CDRemoved);
            char[] cdDrives = CDDrive.GetCDDriveLetters();
            foreach (char cdDrive in cdDrives)
            {
                this.m_cboCDDrives.Items.Add(cdDrive.ToString());
            }
            this.m_cboCDDrives.SelectedIndex = 0;

            LoadSettings();
        }
        
        private void CMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_CDDrive.IsOpened)
            {
                this.m_CDDrive.Close();
            }
        }
        
        private void CMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        
        private void ClearAllControls()
        {
            this.m_lstvMain.Items.Clear();
            foreach (Control control in this.m_pnlTop.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = string.Empty;
                }
            }
            if (m_currentAlbum != null)
            {
                this.m_currentAlbum = null;
            }
            StatusBarPanelCDText = string.Empty;
            this.m_btnOK.Enabled = false;
        }

        private void LoadCD()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_cboCDDrives.Enabled = false;
            this.m_btnBrowseFreeDb.Enabled = false;
            this.m_lstvMain.Items.Clear();

            if (this.m_CDDrive.Open(char.Parse(this.m_cboCDDrives.Items[this.m_cboCDDrives.SelectedIndex].ToString())))
            {
                if (this.m_CDDrive.IsCDReady())
                {
                    StatusBarPanelCDText = "CD wird geladen";
                    if (this.m_CDDrive.Refresh())
                    {
                        this.m_btnBrowseFreeDb.Enabled = true;
                        StatusBarPanelCDText = "CD ist bereit";
                    }
                }
                else
                {
                    StatusBarPanelCDText = "CD ist nicht bereit";
                }
            }
            this.m_cboCDDrives.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void LoadCDIntoListView()
        {
            this.m_lstvMain.Items.Clear();

            if (this.m_currentAlbum != null)
            {

                int iTracks = this.m_CDDrive.NumberOfTracks;
                int iTrackIndex = GetTrackStartIndex();
                Album album = this.m_currentAlbum;

                for (int i = 0; i < iTracks; i++)
                {
                    CTrack track = album.Tracks[i];
                    track.Index = i;
                    track.TrackNumber = iTrackIndex;
                    TimeSpan timeSpan = m_CDDrive.GetDuration(i + 1);
                    if (timeSpan > TimeSpan.Zero)
                    {
                        track.Duration = new TimeSpan(
                            timeSpan.Hours,
                            timeSpan.Minutes,
                            timeSpan.Seconds);
                    }
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = track.TrackNumber.ToString(CultureInfo.InvariantCulture);
                    listViewItem.Tag = track;

                    listViewItem.SubItems.AddRange(new string[] {album.Tracks[i].Title,
                        track.Duration.ToString()});

                    this.m_lstvMain.Items.Add(listViewItem);
                    this.m_lstvMain.UpdateItem(listViewItem.Index);
                    iTrackIndex++;
                }
                this.m_lstvMain.Refresh();
            }
        }

        private int GetTrackStartIndex()
        {
            string strException = String.Format(
                CultureInfo.CurrentUICulture,
                Resources.IDS_TrackStartIndexEception,
                this.m_lblStartIndex.Text);
            int iTrackIndex = 1;
            if (int.TryParse(this.m_txtStartIndex.Text,out iTrackIndex) == false)
            {
                GlobalizedMessageBox.Show(this, strException, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_txtStartIndex.Text = string.Format(CultureInfo.InvariantCulture,"1");
            }
            else
            {
                if (iTrackIndex < 1)
                {
                    GlobalizedMessageBox.Show(this, strException, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.m_txtStartIndex.Text = string.Format(CultureInfo.InvariantCulture,"1");
                }
            }
            return iTrackIndex;
        }

        private void LoadSettings()
        {
            if (this.m_settings != null)
            {
                BaseFormSettingsData freeDbSettingsData = new BaseFormSettingsData();
                freeDbSettingsData = freeDbSettingsData.LoadSettings(this, this.m_settings, freeDbSettingsData) as BaseFormSettingsData;
                if (freeDbSettingsData != null)
                {
                    //-------------------------------------------------------------------------------
                    // Background Image des Contents
                    //-------------------------------------------------------------------------------
                    this.ContentPanel.BackgroundImage = freeDbSettingsData.BackgroundImage;
                    if (this.ContentPanel.BackgroundImage != null)
                    {
                        this.ContentPanel.BackgroundImageLayout = ImageLayout.Tile;
                    }
                }
            }
        }

        private void SaveSettings()
        {
            if (this.m_settings != null)
            {
                BaseFormSettingsData freeDbSettingsData = new BaseFormSettingsData();
                freeDbSettingsData.BackgroundImage = this.ContentPanel.BackgroundImage;
                freeDbSettingsData.SaveSettings(this, this.m_settings, freeDbSettingsData);
            }
        }
        #endregion
    }
}