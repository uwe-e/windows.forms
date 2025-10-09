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
using BSE.Windows.Forms;
using BSE.Shell;
using System.Reflection;
using System.IO;
using System.Collections.ObjectModel;
using BSE.Platten.Ripper.Properties;
using System.Globalization;
using System.Security.Permissions;
using BSE.Platten.FreeDb;

namespace BSE.Platten.Ripper
{
    public partial class MainForm : BaseForm, IConfigurationSettings
    {
        #region Constants

        private const string SettingsFileNameSettingsPart = ".Settings";

        #endregion
        
        #region Delegates

        private delegate void RipTrackHandler(CTrack track);

        #endregion

        #region FieldsPrivate

        private bool m_bExternalOutPutConfiguration;
        private bool m_bWarningIfCancelButtonClicked;
        private RippingOptionsConfigurationData m_rippingOptionsConfigurationObject;
        private FileConfigurationData m_fileConfigurationObject;
        private CDDrive m_cdDrive;
        private Album m_currentAlbum;
        private Album m_albumFromFreeDb;
        private List<CTrack> m_rippedTrackCollection;
        private string m_strHomeDirectory;
        private string m_strTrackName;
        private string m_strInterpret;
        private string m_strAlbum;

        #endregion

        #region Properties

        #region IConfigurationSettings

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
            get { return ConfigurationFileName + SettingsFileNameSettingsPart; }
        }
        #endregion

        [Description("external configuration: home directory for audio files"),
		Category("Appearance")]
		public string HomeDirectory
		{
			get { return this.m_strHomeDirectory; }
			set { this.m_strHomeDirectory = value; }
		}
		
		[Description("external configuration: output- trackname"),
		Category("Appearance")]
		public string TrackName
		{
			get { return this.m_strTrackName; }
			set {this.m_strTrackName = value; }
		}

        public BSE.Platten.BO.Album Album
		{
            get { return this.m_currentAlbum; }
			set
			{
                if (value != null)
                {
                    if (value != this.m_currentAlbum)
                    {
                        this.m_currentAlbum = value;
                        this.m_strInterpret = this.m_currentAlbum.Interpret;
                        if (this.m_strInterpret != null)
                        {
                            this.m_strInterpret = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(this.m_strInterpret);
                            this.m_strInterpret = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(this.m_strInterpret);
                        }
                        this.m_strAlbum = this.m_currentAlbum.Title;
                        if (this.m_strAlbum != null)
                        {
                            this.m_strAlbum = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(this.m_strAlbum);
                            this.m_strAlbum = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(this.m_strAlbum);
                        }
                    }
                }
			}
		}
        /// <summary>
        /// Gets the tracklist for importing
        /// </summary>
        public List<CTrack> ImportTrackCollection
        {
            get { return this.m_rippedTrackCollection; }
        }

        #endregion

        #region MethodsPublic

        public MainForm()
        {
            InitializeComponent();
            this.m_pnlAction.Visible = false;
            this.m_configuration.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_configuration.ConfigFileName = this.ConfigurationFileName;

            this.m_settings.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_settings.ConfigFileName = this.SettingsFileName;

            this.m_lstvMain.AlternatingBackColor = BSE.Platten.Common.BSEColors.AlternatingBackColor;
            this.m_lstvCopied.AlternatingBackColor = BSE.Platten.Common.BSEColors.AlternatingBackColor;

            this.m_rippingOptionsConfigurationObject = new RippingOptionsConfigurationData();
            this.m_fileConfigurationObject = new FileConfigurationData();

            this.m_cdDrive = new CDDrive();
            this.m_cdDrive.CDInserted += new EventHandler(this.m_CDDrive_CDInserted);
            this.m_cdDrive.CDRemoved += new EventHandler(this.m_CDDrive_CDRemoved);

            this.AllowDrop = true;
            this.KeyPreview = true;
        }

        public MainForm(BSE.Configuration.Configuration configuration)
            : this()
        {
            this.m_bExternalOutPutConfiguration = true;
            this.m_configuration = configuration;
            this.m_pnlAction.Visible = true;
        }

        #endregion

        #region MethodsPrivate

        private void m_mnuDatei_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_mnuBearbeiten_OpenDrive_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ClearAllControls();
            if (this.m_cdDrive.EjectCD())
            {
                this.m_lblStatus.Text = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_EjectCD);
            }
            Cursor.Current = Cursors.Default;
        }

        private void m_mnuBearbeiten_CopyTracks_Click(object sender, EventArgs e)
        {
            int iCountTracks = this.m_lstvMain.SelectedItems.Count;
            if (iCountTracks > 0)
            {
                Collection<CTrack> tracksToRipCollection = new Collection<CTrack>();

                for (int i = 0; i < iCountTracks; i++)
                {
                    CTrack track = this.m_lstvMain.SelectedItems[i].Tag as CTrack;
                    if (track != null)
                    {
                        tracksToRipCollection.Add(track);
                    }
                }
                RipTracks(tracksToRipCollection);
            }
        }

        private void MnuHelpShowHelpClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "BSEripper.chm", HelpNavigator.Topic, "HTML/BSEripper5.html");
        }

        private void m_mnuExtras_Optionen_Click(object sender, EventArgs e)
        {
            OptionsDialog options = new OptionsDialog(this.m_configuration);
            options.ConfigurationChanged += new System.EventHandler(this.OptionsChanged);
            options.ShowDialog(this);
        }

        private void OptionsChanged(object sender, System.EventArgs e)
        {
            this.m_rippingOptionsConfigurationObject =
                RippingConfigurationControl.GetConfiguration(this.m_configuration) as RippingOptionsConfigurationData;

            this.m_fileConfigurationObject =
                FileConfigurationControl.GetConfiguration(this.m_configuration) as FileConfigurationData;

            LoadCDIntoListView();
        }

        private void m_cboCDDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnBrowseFreeDb.Enabled = false;
            ClearAllControls();
            this.m_cboCDDrives.Enabled = false;
            this.m_cdDrive.Close();
            LoadCDIntoListView();
            this.m_cboCDDrives.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (this.m_bExternalOutPutConfiguration)
            {
                if (this.m_lstvCopied.Items.Count > 0)
                {
                    this.m_bWarningIfCancelButtonClicked = true;
                }
            }
        }

        private void m_btnBrowseFreeDb_Click(object sender, EventArgs e)
        {
            if (this.m_cdDrive.IsCDReady())
            {
                Cursor.Current = Cursors.WaitCursor;
                BSE.Platten.FreeDb.FreeDb freeDb = new BSE.Platten.FreeDb.FreeDb();
                try
                {
                    this.m_albumFromFreeDb = freeDb.GetMediaDataForCD(this.m_cdDrive.GetQueryStringOfDisc());
                    if (this.m_albumFromFreeDb != null)
                    {
                        //Nur wenn FreeDb Tracks vorhanden sind, wird die ListView neu gebaut
                        if (this.m_albumFromFreeDb.Tracks != null)
                        {
                            LoadCDIntoListView();
                        }
                    }
                }
                catch (FreeDBMatchNoneException freeDbMatchNoneException)
                {
                    GlobalizedMessageBox.Show(this, freeDbMatchNoneException.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void m_txtStartIndex_TextChanged(object sender, EventArgs e)
        {
            GetTrackStartIndex();
            LoadCDIntoListView();
        }

        private void m_lstvCopied_SubItemEndEditing(object sender, BSE.Windows.Forms.SubItemEndEditingEventArgs e)
        {
            ListViewItem listViewItem = e.ListViewItem;
            CTrack track = (CTrack)listViewItem.Tag;
            System.Reflection.PropertyInfo propertyInfo = track.GetType().GetProperty("Title");
            if (e.DisplayText != propertyInfo.GetValue(track, null).ToString())
            {
                track.Title = e.DisplayText;
            }
        }

        private void m_lstvCopied_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    int iCountSelectedItems = this.m_lstvCopied.SelectedItems.Count;
                    int iItemsCounter = 0;
                    string[] aDelete = new String[iCountSelectedItems];
                    foreach (ListViewItem listViewItem in this.m_lstvCopied.SelectedItems)
                    {
                        CTrack trackToRemove = (CTrack)listViewItem.Tag;
                        if (trackToRemove != null)
                        {
                            aDelete[iItemsCounter] = trackToRemove.FileFullName;
                            iItemsCounter++;
                        }
                        this.m_lstvCopied.Items.Remove(listViewItem);
                    }
                    if (this.m_lstvCopied.Items.Count == 0)
                    {
                        this.m_btnOK.Enabled = false;
                    }
                    ShellFileOperation fileOperation = new ShellFileOperation();
                    fileOperation.SourceFiles = aDelete;
                    fileOperation.Operation = FileOperation.FO_DELETE;
                    fileOperation.DoOperation();
                    break;
            }
        }

        private void m_lstvCopied_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is CDataObject)
            {
                //Get the dataobject
                CDataObject dataObject = (CDataObject)e.Data;
                CDraggedListViewObjects draggedListViewObjects = null;
                //check the overload of the dataobject
                if (dataObject.GetDataPresent(typeof(CDraggedListViewObjects).ToString()))
                {
                    draggedListViewObjects
                        = (CDraggedListViewObjects)dataObject.GetData(
                        typeof(CDraggedListViewObjects).ToString());
                    if (draggedListViewObjects.ParentListView == null)
                    {
                        return;
                    }
                }
                if (draggedListViewObjects != null)
                {
                    object dragObject = draggedListViewObjects.DragObjects[0];
                    //Wenn das Object vom Typ ListViewItem ist werden die ListViewItems in die ListView eingefügt
                    if (dragObject.GetType() == typeof(System.Windows.Forms.ListViewItem))
                    {
                        int iCountTracks = draggedListViewObjects.DragObjects.Count;
                        if (iCountTracks > 0)
                        {
                            Collection<CTrack> tracksToRipCollection = new Collection<CTrack>();
                            for (int i = 0; i < iCountTracks; i++)
                            {
                                ListViewItem listViewItem = draggedListViewObjects.DragObjects[i] as ListViewItem;
                                if (listViewItem != null)
                                {
                                    CTrack track = listViewItem.Tag as CTrack;
                                    if (track != null)
                                    {
                                        tracksToRipCollection.Add(track);
                                    }
                                }
                            }
                            RipTracks(tracksToRipCollection);
                        }
                    }
                }
            }
        }

        private void m_lstvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateViewState();
        }

        private void m_lstvMain_SubItemEndEditing(object sender, BSE.Windows.Forms.SubItemEndEditingEventArgs e)
        {
            ListViewItem listViewItem = e.ListViewItem;
            CTrack track = (CTrack)listViewItem.Tag;
            PropertyInfo propertyInfo = track.GetType().GetProperty("Title");
            if (e.DisplayText != propertyInfo.GetValue(track, null).ToString())
            {
                try
                {
                    bool bTitleAsFileName = false;
                    string strTitle = e.DisplayText;
                    string strDirectory = GetFileFullNameByOptionSettings();

                    track.Title = strTitle;

                    if (bTitleAsFileName)
                    {
                        strTitle = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(strTitle);
                        track.FileName = string.Format(
                            CultureInfo.InvariantCulture,
                            "({0}) {1}{2}",
                            track.TrackNumber.ToString("00", CultureInfo.InvariantCulture),
                            strTitle,track.Extension);
                    }

                    //Wenn FreeDb Tracks vorhanden sind..
                    if ((this.m_albumFromFreeDb != null) && (this.m_albumFromFreeDb.Tracks != null))
                    {
                        //wird der geänderte Text in den zugehörenden FreeDb Track geschrieben
                        //damit wird sichergestellt, dass diese Textänderung beim Ändern des Trackindexes nicht
                        //verloren geht
                        this.m_albumFromFreeDb.Tracks[track.Index].Title = e.DisplayText;
                    }
                    track.FileFullName = strDirectory + track.FileName;
                    listViewItem.SubItems[4].Text = track.FileFullName;
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this,exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CMain_Load(object sender, EventArgs e)
        {
            this.m_rippingOptionsConfigurationObject =
                RippingConfigurationControl.GetConfiguration(this.m_configuration) as RippingOptionsConfigurationData;

            this.m_fileConfigurationObject =
                FileConfigurationControl.GetConfiguration(this.m_configuration) as FileConfigurationData;

            char[] cdDrives = CDDrive.GetCDDriveLetters();
            foreach (char cdDrive in cdDrives)
            {
                this.m_cboCDDrives.Items.Add(cdDrive.ToString());
            }
            if (this.m_cboCDDrives.Items.Count > 0)
            {
                this.m_cboCDDrives.SelectedIndex = 0;
            }

            //die Properties der Controls werden gesetzt
            LoadSettings();
        }
        
        private void CMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //die Properties der Controls werden gespeichert
            SaveSettings();
        }
        
        private void CMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_bWarningIfCancelButtonClicked)
            {
                DialogResult dialogResult = GlobalizedMessageBox.Show(
                    this,
                    Resources.IDS_RippingAbortInformation,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.No)
                {
                    //Wenn der Benutzer Nein wählt wird das Formular nicht geschlossen
                    e.Cancel = true;
                    this.m_bWarningIfCancelButtonClicked = false;
                }
            }

            if (this.m_cdDrive.IsOpened)
            {
                this.m_cdDrive.Close();
            }
        }
        
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            int iRippedTrackCounter = this.m_lstvCopied.Items.Count;
            if (iRippedTrackCounter > 0)
            {
                if (this.m_rippedTrackCollection == null)
                {
                    this.m_rippedTrackCollection = new List<CTrack>();
                }
                this.m_rippedTrackCollection.Clear();
                foreach (ListViewItem listViewItem in this.m_lstvCopied.Items)
                {
                    CTrack rippedTrack = listViewItem.Tag as CTrack;
                    if (rippedTrack != null)
                    {
                        this.m_rippedTrackCollection.Add(rippedTrack);
                    }
                }
                if (this.m_rippedTrackCollection != null)
                {
                    PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(CTrack));
                    PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find("TrackNumber", false);
                    this.m_rippedTrackCollection.Sort(new PropertyComparer<CTrack>(propertyDescriptor, ListSortDirection.Ascending));
                }
            }
        }
        
        private void m_CDDrive_CDInserted(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.m_cdDrive.Open(char.Parse(this.m_cboCDDrives.Items[this.m_cboCDDrives.SelectedIndex].ToString())))
            {
                LoadCDIntoListView();
            }
            Cursor.Current = Cursors.Default;
        }

        private void m_CDDrive_CDRemoved(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnBrowseFreeDb.Enabled = false;
            ClearAllControls();
            this.m_lblStatus.Text = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_CDEjected);
            Cursor.Current = Cursors.Default;
        }

        private void ClearAllControls()
        {
            this.m_lstvMain.Items.Clear();
            if (this.m_albumFromFreeDb != null)
            {
                this.m_albumFromFreeDb = null;
            }
            this.m_lblStatus.Text = string.Empty;
            if (this.m_lstvCopied.Items.Count == 0)
            {
                this.m_btnOK.Enabled = false;
            }
        }

        private void UpdateViewState()
        {
            this.m_mnuBearbeiten_CopyTracks.Enabled = false;
            if (this.m_lstvMain.SelectedItems.Count > 0)
            {
                this.m_mnuBearbeiten_CopyTracks.Enabled = true;
            }
        }

        private void LoadCDIntoListView()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_cboCDDrives.Enabled = false;
            this.m_btnBearbeiten_OpenDrive.Enabled = this.m_mnuBearbeiten_OpenDrive.Enabled = false;
            this.m_lstvMain.Items.Clear();
            UpdateViewState();

            if (this.m_cdDrive.Open(char.Parse(this.m_cboCDDrives.Items[this.m_cboCDDrives.SelectedIndex].ToString())))
            {
                if (this.m_cdDrive.IsCDReady())
                {
                    this.m_lblStatus.Text = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_LoadCD);
                    if (this.m_cdDrive.Refresh())
                    {
                        this.m_btnBrowseFreeDb.Enabled = true;
                        int iTracks = this.m_cdDrive.NumberOfTracks;
                        int iTrackIndex = GetTrackStartIndex();

                        if (this.m_albumFromFreeDb == null)
                        {
                            BSE.Platten.FreeDb.FreeDb freeDb = new BSE.Platten.FreeDb.FreeDb(this);
                            try
                            {
                                this.m_albumFromFreeDb = freeDb.GetMediaDataForCD(this.m_cdDrive.GetQueryStringOfDisc());
                            }
                            catch (FreeDBMatchNoneException)
                            {
                            }
                        }
                        for (int i = 0; i < iTracks; i++)
                        {
                            BSE.Platten.BO.CTrack track = new BSE.Platten.BO.CTrack();
                            track.Index = i;
                            track.CDIndex = i + 1;
                            track.TrackNumber = iTrackIndex;
                            track.Title = string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}_{1}",
                                this.TrackName,
                                iTrackIndex.ToString("00", CultureInfo.InvariantCulture));
                            track.Duration = this.m_cdDrive.GetDuration(track.CDIndex);
                            track.TrackSize = this.m_cdDrive.TrackSize(track.CDIndex);
                            track.UsedAudioFormat = this.m_rippingOptionsConfigurationObject.UsedAudioFormat;
                            if (track.UsedAudioFormat == CAudioFormat.AudioFormat.Mp3)
                            {
                                track.Extension = AudioformatExtensions.Mp3;
                            }
                            else if (track.UsedAudioFormat == CAudioFormat.AudioFormat.Wav)
                            {
                                track.Extension = AudioformatExtensions.Wav;
                            }
                            track.FileName = string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}_{1}{2}",
                                this.TrackName,
                                iTrackIndex.ToString("00", CultureInfo.InvariantCulture),
                                track.Extension);
                            string strDirectory = GetFileFullNameByOptionSettings();

                            if (this.m_albumFromFreeDb != null)
                            {
                                if (this.m_albumFromFreeDb.Tracks != null)
                                {
                                    track.Title = this.m_albumFromFreeDb.Tracks[track.Index].Title;
                                    if (this.m_fileConfigurationObject.TitleAsFileName == true)
                                    {
                                        string strTitle = track.Title;
                                        strTitle = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(track.Title);
                                        track.FileName = string.Format(
                                            CultureInfo.InvariantCulture,
                                            "({0}) {1}{2}",
                                            iTrackIndex.ToString("00", CultureInfo.InvariantCulture),
                                            strTitle,
                                            track.Extension);
                                    }
                                }
                            }

                            track.FileFullName = strDirectory + track.FileName;

                            if (this.m_cdDrive.IsAudioTrack(track.CDIndex))
                            {
                                ListViewItem listViewItem = new ListViewItem();
                                listViewItem.Text = track.Title;
                                listViewItem.Tag = track;

                                listViewItem.SubItems.AddRange(new string[] {
                                    track.TrackSize.ToString("N0", CultureInfo.InvariantCulture),
                                    this.m_cdDrive.IsAudioTrack(track.CDIndex) ? "audio" : "data",
                                    track.Duration.ToString(),
                                    track.FileFullName});

                                m_lstvMain.Items.Add(listViewItem);
                                m_lstvMain.UpdateItem(listViewItem.Index);
                            }
                            iTrackIndex++;
                        }
                        //wird benötigt damit die ListView die Items beim neuladen nicht durcheinander bringt
                        this.m_lstvMain.Refresh();
                        this.m_lblStatus.Text = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_CDReady);
                    }
                }
                else
                {
                    this.m_lblStatus.Text = string.Format(CultureInfo.CurrentUICulture, Resources.IDS_CDNotReady);
                    this.m_btnBrowseFreeDb.Enabled = false;
                }
            }
            this.m_cboCDDrives.Enabled = true;
            this.m_btnBearbeiten_OpenDrive.Enabled = this.m_mnuBearbeiten_OpenDrive.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void RipTracks(Collection<CTrack> tracksToRipCollection)
        {
            if (tracksToRipCollection != null)
            {
                if (tracksToRipCollection.Count > 0)
                {
                    string strDirectory = GetFileFullNameByOptionSettings();
                    DirectoryInfo directoryInfo = new DirectoryInfo(strDirectory);
                    if (directoryInfo.Exists == false)
                    {
                        try
                        {
                            directoryInfo.Create();
                        }
                        catch (System.UnauthorizedAccessException unauthorizedAccessException)
                        {
                            GlobalizedMessageBox.Show(
                                this,
                                unauthorizedAccessException.Message,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }

                    RipTracks ripTracks = new RipTracks(this.m_configuration, tracksToRipCollection);
                    ripTracks.Album = this.Album;
                    ripTracks.CDDrive = this.m_cdDrive;
                    ripTracks.ProfessionalColorTable = this.ProfessionalColorTable;
                    ripTracks.PanelStyle = this.PanelStyle;
                    ripTracks.PanelColors = this.PanelColors;
                    ripTracks.RippingComplete -= new System.EventHandler(this.RippingComplete);
                    ripTracks.RippingComplete += new System.EventHandler(this.RippingComplete);
                    ripTracks.TrackRipped -= new EventHandler<TrackRippingEventArgs>(this.TrackRipped);
                    ripTracks.TrackRipped += new EventHandler<TrackRippingEventArgs>(this.TrackRipped);
                    ripTracks.ShowDialog();
                }
            }
        }

        private void RippingComplete(object sender, System.EventArgs e)
        {
            if (this.m_lstvCopied.Items.Count > 0)
            {
                this.m_btnOK.Enabled = true;
            }
            foreach (ListViewItem listViewItem in this.m_lstvMain.SelectedItems)
            {
                listViewItem.Selected = false;
            }
        }

        private void TrackRipped(object sender, TrackRippingEventArgs e)
        {
            this.Invoke(new RipTrackHandler(RippTrackEvent), e.Track);
        }

        private void RippTrackEvent(CTrack rippedTrack)
        {
            if (rippedTrack != null)
            {
                ListViewItem listViewItem = new ListViewItem(rippedTrack.FileFullName);
                listViewItem.SubItems.Add(rippedTrack.TrackNumber.ToString(CultureInfo.InvariantCulture));
                listViewItem.SubItems.Add(rippedTrack.Title);
                listViewItem.SubItems.Add(rippedTrack.Duration.ToString());
                listViewItem.Tag = rippedTrack;
                this.m_lstvCopied.Items.Add(listViewItem);
                //mit EnsureVisible wird sichergestellt, dass das neue ListViewItem sichtbar bleibt
                listViewItem.EnsureVisible();
            }
        }

        private string GetFileFullNameByOptionSettings()
        {
            string strFileFullName = string.Empty;
            string strInterpret = string.Empty;
            string strAlbum = string.Empty;
            if (this.m_fileConfigurationObject.EachAlbumGetsDirectory == true)
            {
                if (this.m_bExternalOutPutConfiguration)
                {
                    strInterpret = this.m_strInterpret;
                    strAlbum = this.m_strAlbum;
                }
                else
                {
                    if (this.m_albumFromFreeDb != null)
                    {
                        strInterpret = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(this.m_albumFromFreeDb.Interpret);
                        strInterpret = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strInterpret);
                        strAlbum = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(this.m_albumFromFreeDb.Title);
                        strAlbum = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strAlbum);
                    }
                }
            }

            string strHomeDirectory = this.HomeDirectory;
            strHomeDirectory = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strHomeDirectory);

            strFileFullName = strHomeDirectory + strInterpret + strAlbum;
            if (string.IsNullOrEmpty(strFileFullName) == false)
            {
                strFileFullName = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strFileFullName);
            }

            return strFileFullName;
        }

        private int GetTrackStartIndex()
        {
            string strException = String.Format(CultureInfo.CurrentUICulture,Resources.IDS_TrackStartIndexEception);
            int iTrackIndex = 1;
            if (int.TryParse(this.m_txtStartIndex.Text, out iTrackIndex) == false)
            {
                GlobalizedMessageBox.Show(this, strException, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_txtStartIndex.Text = string.Format(CultureInfo.InvariantCulture, "1");
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
            RipperSettingsData ripperSettingsData = new RipperSettingsData();
            //-------------------------------------------------------------------------------
            // Default Values
            //-------------------------------------------------------------------------------
            ripperSettingsData.HeightPanelRipper = this.m_pnlRipper.Height;
            ripperSettingsData.HeightPanelCopied = this.m_pnlCopied.Height;
            
            ripperSettingsData = ripperSettingsData.LoadSettings(this, this.m_settings, ripperSettingsData) as RipperSettingsData;
            if (ripperSettingsData != null)
            {
                //-------------------------------------------------------------------------------
                // Background Image des Contents
                //-------------------------------------------------------------------------------
                this.ContentPanel.BackgroundImage = ripperSettingsData.BackgroundImage;
                if (this.ContentPanel.BackgroundImage != null)
                {
                    this.ContentPanel.BackgroundImageLayout = ImageLayout.Tile;
                }
                //-------------------------------------------------------------------------------
                // Höhe des Ripper Panels neu setzen.
                //
                if (ripperSettingsData.HeightPanelRipper > 0)
                {
                    this.m_pnlRipper.Height = ripperSettingsData.HeightPanelRipper;
                }
                //-------------------------------------------------------------------------------
                // Höhe des Copied Panels neu setzen.
                //
                if (ripperSettingsData.HeightPanelCopied > 0)
                {
                    this.m_pnlCopied.Height = ripperSettingsData.HeightPanelCopied;
                }
                //-------------------------------------------------------------------------------
                // Spaltenbreite der ListView Main neu setzen.
                //-------------------------------------------------------------------------------
                int iSizeMain = this.m_lstvMain.Columns.Count;
                int[] columnWidthsMain = ripperSettingsData.ColumnWidthsListviewMain;
                if (columnWidthsMain != null)
                {
                    int iSizeIntArray = columnWidthsMain.Length;
                    for (int i = 0; i < iSizeMain; ++i)
                    {
                        if (i < iSizeIntArray)
                        {
                            this.m_lstvMain.Columns[i].Width = columnWidthsMain[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                //-------------------------------------------------------------------------------
                // Spaltenbreite der ListView Copied neu setzen.
                //-------------------------------------------------------------------------------
                int iSizeLvwCopied = this.m_lstvCopied.Columns.Count;
                int[] columnWidthsLvwCopied = ripperSettingsData.ColumnWidthsListviewCopied;
                if (columnWidthsLvwCopied != null)
                {
                    int iSizeIntArray = columnWidthsLvwCopied.Length;
                    for (int i = 0; i < iSizeLvwCopied; ++i)
                    {
                        if (i < iSizeIntArray)
                        {
                            this.m_lstvCopied.Columns[i].Width = columnWidthsLvwCopied[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void SaveSettings()
        {
            RipperSettingsData ripperSettingsData = new RipperSettingsData();

            ripperSettingsData.BackgroundImage = this.ContentPanel.BackgroundImage;

            if (this.WindowState == FormWindowState.Normal)
            {
                ripperSettingsData.HeightPanelRipper = this.m_pnlRipper.Height;
                ripperSettingsData.HeightPanelCopied = this.m_pnlCopied.Height;
            }

            int iSizeLvwMain = this.m_lstvMain.Columns.Count;
            int[] columnWidthsLvwMain = new int[iSizeLvwMain];
            for (int i = 0; i < iSizeLvwMain; ++i)
            {
                columnWidthsLvwMain[i] = this.m_lstvMain.Columns[i].Width;
            }
            ripperSettingsData.ColumnWidthsListviewMain = columnWidthsLvwMain;

            int iSizeLvwCopied = this.m_lstvCopied.Columns.Count;
            int[] columnWidthsLvwCopied = new int[iSizeLvwCopied];
            for (int i = 0; i < iSizeLvwCopied; ++i)
            {
                columnWidthsLvwCopied[i] = this.m_lstvCopied.Columns[i].Width;
            }
            ripperSettingsData.ColumnWidthsListviewCopied = columnWidthsLvwCopied;

            ripperSettingsData.SaveSettings(this, this.m_settings, ripperSettingsData);
        }

        #endregion

        #region internal class CTrackSorter

        //internal class CTrackSorter<T> : IComparer<T>
        //{
        //    private SortOrder m_sortOrder;

        //    public CTrackSorter(SortOrder sortOrder)
        //    {
        //        this.m_sortOrder = sortOrder;
        //    }
        //    public int Compare(T x, T y)
        //    {
        //        object xValue = value.GetType().GetProperty("TrackNumber");
        //        object yValue = value.GetType().GetProperty("TrackNumber");
        //        IComparable value = x as IComparable;
        //        if (value != null)
        //        {
        //            switch (this.m_sortOrder)
        //            {

        //                case SortOrder.Ascending:
        //                    IComparable value = x as IComparable;
        //                    return x.TrackNumber.CompareTo(((CTrack)y).TrackNumber);
        //                case SortOrder.Descending:
        //                    return ((CTrack)x).TrackNumber.CompareTo(((CTrack)y).TrackNumber);
        //                default:
        //                    return ((CTrack)x).TrackNumber.CompareTo(((CTrack)y).TrackNumber);
        //            }
        //        }
        //    }
        //}

        //internal class CTrackSorter : System.Collections.IComparer
        //{
        //    private SortOrder m_sortOrder;

        //    public CTrackSorter(SortOrder sortOrder)
        //    {
        //        this.m_sortOrder = sortOrder;
        //    }
        //    public int Compare(object x, object y)
        //    {
        //        switch (this.m_sortOrder)
        //        {
        //            case SortOrder.Ascending:
        //                return ((CTrack)x).TrackNumber.CompareTo(((CTrack)y).TrackNumber);
        //            case SortOrder.Descending:
        //                return ((CTrack)x).TrackNumber.CompareTo(((CTrack)y).TrackNumber);
        //            default:
        //                return ((CTrack)x).TrackNumber.CompareTo(((CTrack)y).TrackNumber);
        //        }
        //    }
        //}

        #endregion
        
    }
    /// <summary>
    /// Contains the settings for the <see cref="MainForm"/> object.
    /// </summary>
    public class RipperSettingsData : BaseFormSettingsData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the column widths for the listview lvwMain.
        /// </summary>
        public int[] ColumnWidthsListviewMain
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the column widths for the listview lvwCopied.
        /// </summary>
        public int[] ColumnWidthsListviewCopied
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the height for the panel pnlRipper.
        /// </summary>
        public int HeightPanelRipper
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the height for the panel pnlCopied.
        /// </summary>
        public int HeightPanelCopied
        {
            get;
            set;
        }
        #endregion
    }
}