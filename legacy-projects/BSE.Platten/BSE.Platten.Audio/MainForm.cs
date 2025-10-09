using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Reflection;
using System.Globalization;
using BSE.Platten.Audio.Properties;

namespace BSE.Platten.Audio
{
    public partial class MainForm : BaseForm, IConfigurationSettings
    {
        #region Constants

        private const string m_strSettingsFileNameSettingsPart = ".Settings";

        #endregion
        
        #region Delegates

        private delegate void DelegateAddAudioItem(string strFileFullName, string strFileName, string strFileExtension);
        private delegate void DelegateAddListViewItem(BSE.Platten.Audio.WinControls.ListView listView, AudioMetadata audioMetaData);
        private delegate void DelegateAddTreeViewNode(System.Windows.Forms.TreeView treeView, System.IO.DirectoryInfo directoryInfo);
        private delegate void DelegateShowAudioFiles(string strDirectoryFullName);
        private delegate void DelegateTreeViewSelectNode();

        #endregion

        #region FieldsPrivate

        private Icon m_imgBSEIcon;
        private AudioImportConfigurationData m_audioImportConfigurationObject;
        private FileConfigurationData m_fileConfigurationObject;
        private bool m_bExternalOutPutConfiguration;
        private string m_strSearchPattern;
        private string m_strTrackName;
        private string m_strHomeDirectory;
        private List<CTrack> m_importTrackCollection;
        private Album m_Album;
        private ReadAudioDirectoriesForm m_readAudioDirectories;
        
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
            get { return ConfigurationFileName + m_strSettingsFileNameSettingsPart; }
        }
        
        #endregion

        public string TrackName
        {
            get { return m_strTrackName; }
            set { m_strTrackName = value; }
        }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Description("external configuration: home directory for audio files")]
        [System.ComponentModel.Category("Appearance")]
        public string HomeDirectory
        {
            get
            {
                return this.m_strHomeDirectory;
            }
            set
            {
                this.m_strHomeDirectory = value;
            }
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
            this.m_mnuExtras_Optionen.ShortcutKeys = Keys.Control | Keys.O;
            this.m_Configuration.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_Configuration.ConfigFileName = this.ConfigurationFileName;

            this.m_settings.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_settings.ConfigFileName = this.SettingsFileName;
            
            this.m_imgBSEIcon = new Icon(this.GetType(), "bse.ico");
            this.Icon = m_imgBSEIcon;
            this.m_audioImportConfigurationObject = new AudioImportConfigurationData();
            this.m_fileConfigurationObject = new FileConfigurationData();
            this.m_lstvHomeDirectory.AlternatingBackColor = BSE.Platten.Common.BSEColors.AlternatingBackColor;
            this.m_lstvImportDirectory.AlternatingBackColor = BSE.Platten.Common.BSEColors.AlternatingBackColor;

            this.m_cboAddress.Control.PreviewKeyDown += new PreviewKeyDownEventHandler(m_cboAddress_PreviewKeyDown);

            this.AllowDrop = true;
            this.KeyPreview = true;
        }

        public MainForm(BSE.Configuration.Configuration configuration, BSE.Platten.BO.Album album)
            : this()
        {
            this.m_Configuration = null;
            this.m_Configuration = configuration;
            this.m_Album = album;
            this.m_bExternalOutPutConfiguration = true;
            this.m_pnlAction.Visible = true;
        }

        #endregion

        #region MethodsProtected

        #endregion

        #region MethodsPrivate

        private void m_cboAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = false;
            if ((e.Control == true) && (e.Alt == true))
            {
                e.IsInputKey = true;
            }
        }
        
        private void m_cboAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(this.m_cboAddress.Text) == false)
                {
                    this.m_btnGotoAddress_Click(this, new EventArgs());
                }
            }
        }
        
        private void m_cboAddress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.m_cboAddress.Text) == true)
            {
                this.m_btnGotoAddress.Enabled = false;
            }
            else
            {
                this.m_btnGotoAddress.Enabled = true;
            }
        }
        
        private void m_btnGotoAddress_Click(object sender, EventArgs e)
        {
            string strPath = this.m_cboAddress.Text;
            this.m_strSearchPattern = null;
            if (String.IsNullOrEmpty(strPath) == false)
            {
                //when the directory not exits..
                if (System.IO.Directory.Exists(strPath) == false)
                {
                    // and there is a wildcard character in the path string
                    if (strPath.IndexOf("*") > 0)
                    {
                        //the path string will splitted into an array 
                        string[] strDirectories = strPath.Split(System.IO.Path.DirectorySeparatorChar);
                        if ((strDirectories != null) && (strDirectories.Length > 0))
                        {
                            int iLength = strDirectories.Length;
                            //the part with the highest index is the search pattern
                            if (strDirectories[iLength - 1].IndexOf("*") > 0)
                            {
                                this.m_strSearchPattern = strDirectories[iLength - 1];
                            }
                            // The array index 0 is the drive
                            string strPathToCombine = strDirectories[0] + System.IO.Path.DirectorySeparatorChar;
                            for (int i = 1; i < strDirectories.Length - 1; i++)
                            {
                                //all the other array parts are path parts
                                strPathToCombine = System.IO.Path.Combine(strPathToCombine, strDirectories[i]);
                            }

                            if (string.IsNullOrEmpty(strPathToCombine) == false)
                            {
                                strPath = strPathToCombine;
                            }
                        }
                    }
                }

                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strPath);
                if (directoryInfo.Exists == false)
                {
                    string strMessage = String.Format(
                        CultureInfo.CurrentUICulture,
                        Resources.IDS_DirectoryNotExistsException, this.m_cboAddress.Text);
                    GlobalizedMessageBox.Show(this,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.m_fldDlgOpenDirectory.SelectedPath = strPath;
                    SearchDirectory(strPath, this.m_strSearchPattern);
                }
            }
        }
        
        private void m_mnuDatei_OpenDirectory_Click(object sender, EventArgs e)
        {
            if (this.m_fldDlgOpenDirectory.ShowDialog() == DialogResult.OK)
            {
                this.m_cboAddress.Text = this.m_fldDlgOpenDirectory.SelectedPath;
                this.m_strSearchPattern = null;
                SearchDirectory(this.m_fldDlgOpenDirectory.SelectedPath, this.m_strSearchPattern);
            }
        }

        private void m_mnuDatei_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void m_mnuBearbeiten_CopyAll_Click(object sender, EventArgs e)
        {
            this.m_mnuBearbeiten_CopyTracks_Click(sender, e);
        }

        private void m_mnuBearbeiten_CopyTracks_Click(object sender, System.EventArgs e)
        {
            int iCountListViewItems = this.m_lstvImportDirectory.SelectedItems.Count;
            if (iCountListViewItems == 0)
            {
                return;
            }
            ListViewItem[] listViewItems = new ListViewItem[iCountListViewItems];
            for (int i = 0; i < iCountListViewItems; i++)
            {
                listViewItems[i] = this.m_lstvImportDirectory.SelectedItems[i];
            }
            if (ImportAudioTracks(listViewItems))
            {
                string strFileFullName = GetFileFullNameByOptionSettings();
                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strFileFullName);
                if (directoryInfo.Exists)
                {
                    ReadAudioDirectoriesAndFiles(directoryInfo, null, this.m_lstvHomeDirectory, null, false);
                }
            }
        }
        
        private void m_mnuBearbeiten_ImportAll_Click(object sender, EventArgs e)
        {
            this.m_mnuBearbeiten_ImportTracks_Click(sender, e);
        }

        private void m_mnuBearbeiten_ImportTracks_Click(object sender, System.EventArgs e)
        {
            bool bIsListViewItemSelected = IsListViewItemSelected(this.m_lstvHomeDirectory);
            if (bIsListViewItemSelected == false)
            {
                return;
            }
            //der Button wird hier enabled damit er beim closing ausgwertet werden kann
            this.m_btnSelectedTracksOK.Enabled = true;
            //Der m_btnOK_Click Event wird ausgeführt, damit die selektierten Files in die Trackliste kommen
            this.ButtonSelectedTracksOKClick(this, new System.EventArgs());
            this.DialogResult = DialogResult.OK;
        }

        private void m_mnuExtras_Optionen_Click(object sender, EventArgs e)
        {
            using (OptionsDialog options = new OptionsDialog(this.m_Configuration))
            {
                options.StartPosition = FormStartPosition.CenterParent;
                options.ConfigurationChanged += new System.EventHandler(this.OptionsChanged);
                options.ShowDialog();
            }
        }
        
        private void ButtonSelectedTracksOKClick(object sender, EventArgs e)
        {
            int iCountTracks = this.m_lstvHomeDirectory.SelectedItems.Count;
            if (iCountTracks > 0)
            {
                if (this.m_importTrackCollection == null)
                {
                    this.m_importTrackCollection = new List<CTrack>();
                }
                this.m_importTrackCollection.Clear();
                
                foreach (ListViewItem listViewItem in this.m_lstvHomeDirectory.SelectedItems)
                {
                    CTrack track = new CTrack();
                    AudioMetadata audioMetaData = (AudioMetadata)listViewItem.Tag;
                    track.FileFullName = audioMetaData.FullName;
                    if (string.IsNullOrEmpty(audioMetaData.WMTrackNumber) == false)
                    {
                        track.TrackNumber = Convert.ToInt32(audioMetaData.WMTrackNumber,CultureInfo.InvariantCulture);
                    }
                    track.Title = audioMetaData.Title;
                    track.Duration = audioMetaData.Duration;
                    this.m_importTrackCollection.Add(track);
                }
            }
        }
        
        private void ButtonAllTracksOk_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listViewItem in this.m_lstvHomeDirectory.Items)
            {
                listViewItem.Selected = true;
            }
            ButtonSelectedTracksOKClick(this, EventArgs.Empty);
            this.DialogResult = DialogResult.OK;
        }
        
        private void m_trvImportDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(e.Node.Text);
            if (directoryInfo.Exists)
            {
                ReadAudioDirectoriesAndFiles(directoryInfo, this.m_strSearchPattern , this.m_lstvImportDirectory, null, false);
            }
        }

        private void m_lstvImportDirectory_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteSelectedItemsInListView(this.m_lstvImportDirectory);
                    break;
            }
        }

        private void m_lstvImportDirectory_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.m_lstvImportDirectory.SelectedItems.Count > 0)
                {
                    Point point = new Point(Cursor.Position.X, Cursor.Position.Y - SystemInformation.CaptionHeight);
                    ContextMenu contextMenu = new ContextMenu(this.mnuCopyFiles());
                    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
                    control.CreateControl();
                    control.ContextMenu = contextMenu;
                    control.ContextMenu.Show(control, point);
                }
            }
        }

        private void m_lstvImportDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_mnuBearbeiten_CopyAll.Enabled = 
                this.m_btnBearbeiten_CopyAll.Enabled = false;
            bool bIsListViewItemSelected = IsListViewItemSelected(this.m_lstvImportDirectory);
            if (bIsListViewItemSelected)
            {
                this.m_mnuBearbeiten_CopyAll.Enabled =
                    this.m_btnBearbeiten_CopyAll.Enabled =  true;
            }
        }

        private void m_lstvImportDirectory_SubItemEndEditing(object sender, BSE.Windows.Forms.SubItemEndEditingEventArgs e)
        {
            BSE.Platten.Audio.WinControls.ListView listView = (BSE.Platten.Audio.WinControls.ListView)sender;
            if (listView != null)
            {
                EditSubItemsInListView(listView, e);
            }
        }
        
        private void m_lstvHomeDirectory_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data is BSE.Windows.Forms.CDataObject)
                {
                    //Get the dataobject
                    BSE.Windows.Forms.CDataObject dataObject = (BSE.Windows.Forms.CDataObject)e.Data;
                    BSE.Windows.Forms.CDraggedListViewObjects draggedListViewObjects = null;
                    //check the overload of the dataobject
                    if (dataObject.GetDataPresent(typeof(BSE.Windows.Forms.CDraggedListViewObjects).ToString()))
                    {
                        draggedListViewObjects
                            = (BSE.Windows.Forms.CDraggedListViewObjects)dataObject.GetData(
                            typeof(BSE.Windows.Forms.CDraggedListViewObjects).ToString());
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
                            int iCountListViewItems = draggedListViewObjects.DragObjects.Count;
                            ListViewItem[] listViewItems = new ListViewItem[iCountListViewItems];
                            draggedListViewObjects.DragObjects.CopyTo(listViewItems);

                            if (ImportAudioTracks(listViewItems))
                            {
                                string strFileFullName = GetFileFullNameByOptionSettings();
                                System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strFileFullName);
                                if (directoryInfo.Exists)
                                {
                                    ReadAudioDirectoriesAndFiles(directoryInfo, null, this.m_lstvHomeDirectory, null, false);
                                    if (this.m_audioImportConfigurationObject.FileOperations == BSE.Shell.FileOperation.FO_MOVE)
                                    {
                                        foreach (ListViewItem listViewItem in draggedListViewObjects.ParentListView.SelectedItems)
                                        {
                                            listViewItem.Remove();
                                        }
                                    }
                                    else
                                    {
                                        foreach (ListViewItem listViewItem in draggedListViewObjects.ParentListView.SelectedItems)
                                        {
                                            listViewItem.Selected = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void m_lstvHomeDirectory_ListViewItemAdded(object sender, EventArgs e)
        {
            if (this.m_lstvHomeDirectory.Items.Count > 0)
            {
                this.m_btnAllTracksOk.Enabled = true;
            }
        }

        private void m_lstvHomeDirectory_ListViewItemRemoved(object sender, EventArgs e)
        {
            if (this.m_lstvHomeDirectory.Items.Count == 0)
            {
                this.m_btnAllTracksOk.Enabled = false;
            }
        }

        private void m_lstvHomeDirectory_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteSelectedItemsInListView(this.m_lstvHomeDirectory);
                    //der Button soll disabled werden, wenn keine ListViewItems mehr vorhanden sind
                    this.m_btnSelectedTracksOK.Enabled = IsListViewItemSelected(this.m_lstvHomeDirectory);
                    break;
            }
        }

        private void m_lstvHomeDirectory_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.m_lstvHomeDirectory.SelectedItems.Count > 0)
                {
                    Point point = new Point(Cursor.Position.X, Cursor.Position.Y - SystemInformation.CaptionHeight);
                    ContextMenu contextMenu = new ContextMenu(this.mnuImportFiles());
                    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
                    control.CreateControl();
                    control.ContextMenu = contextMenu;
                    control.ContextMenu.Show(control, point);
                }
            }
        }

        private void m_lstvHomeDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_btnSelectedTracksOK.Enabled = false;
            this.m_mnuBearbeiten_ImportAll.Enabled =
                this.m_btnBearbeiten_ImportAll.Enabled = false;
            bool bIsListViewItemSelected = IsListViewItemSelected(this.m_lstvHomeDirectory);
            if (bIsListViewItemSelected == true)
            {
                this.m_btnSelectedTracksOK.Enabled = true;
                this.m_mnuBearbeiten_ImportAll.Enabled =
                    this.m_btnBearbeiten_ImportAll.Enabled = true;
            }
        }

        private void m_lstvHomeDirectory_SubItemEndEditing(object sender, BSE.Windows.Forms.SubItemEndEditingEventArgs e)
        {
            BSE.Platten.Audio.WinControls.ListView listView = (BSE.Platten.Audio.WinControls.ListView)sender;
            if (listView != null)
            {
                EditSubItemsInListView(listView, e);
            }
        }
        
        private void CMain_Load(object sender, EventArgs e)
        {
            this.m_audioImportConfigurationObject =
                CAudioImportConfigurationControl.GetConfiguration(this.m_Configuration) as AudioImportConfigurationData;

            this.m_fileConfigurationObject =
                FileConfigurationControl.GetConfiguration(this.m_Configuration) as FileConfigurationData;

            LoadSettings();
            SetRootNodeTreeViewHomeDirectory();
        }

        private void CMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void CMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if ((this.m_importTrackCollection != null) && (this.m_importTrackCollection.Count > 0))
                {
                    foreach (BSE.Platten.BO.CTrack track in this.m_importTrackCollection)
                    {
                        if (track.TrackNumber == 0)
                        {
                            string strMessage = String.Format(
                                CultureInfo.CurrentUICulture,
                                Resources.IDS_NoTrackNumberException,
                                track.FileFullName);
                            GlobalizedMessageBox.Show(this,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.m_btnSelectedTracksOK.Enabled = false;
                            e.Cancel = true;
                            return;
                        }
                    }
                    PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(CTrack));
                    PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find("TrackNumber", false);
                    this.m_importTrackCollection.Sort(new PropertyComparer<CTrack>(propertyDescriptor, ListSortDirection.Ascending));
                }
            }
        }

        private void LoadSettings()
        {
            CAudioSettingsData audioSettingsData = new CAudioSettingsData();
            //-------------------------------------------------------------------------------
            // Default Values
            //-------------------------------------------------------------------------------
            audioSettingsData.HeightPnlImportDirectory = this.m_pnlImportDirectory.Height;
            audioSettingsData.HeightPnlHomeDirectory = this.m_pnlHomeDirectory.Height;
            audioSettingsData.WidthTrvImportDirectory = this.m_trvImportDirectory.Height;
            audioSettingsData.WidthTrvHomeDirectory = this.m_trvHomeDirectory.Height;
            
            audioSettingsData = audioSettingsData.LoadSettings(this, this.m_settings, audioSettingsData) as CAudioSettingsData;
            if (audioSettingsData != null)
            {
                //-------------------------------------------------------------------------------
                // Background Image des Contents
                //-------------------------------------------------------------------------------
                this.ContentPanel.BackgroundImage = audioSettingsData.BackgroundImage;
                if (this.ContentPanel.BackgroundImage != null)
                {
                    this.ContentPanel.BackgroundImageLayout = ImageLayout.Tile;
                }
                //-------------------------------------------------------------------------------
                // Höhe des ImportDirectory Panels
                //-------------------------------------------------------------------------------
                if (audioSettingsData.HeightPnlImportDirectory > 0)
                {
                    this.m_pnlImportDirectory.Height = audioSettingsData.HeightPnlImportDirectory;
                }
                //-------------------------------------------------------------------------------
                // Breite des ImportDirectory Trees
                //-------------------------------------------------------------------------------
                if (audioSettingsData.WidthTrvImportDirectory > 0)
                {
                this.m_trvImportDirectory.Width = audioSettingsData.WidthTrvImportDirectory;
                }
                //-------------------------------------------------------------------------------
                // Höhe des HomeDirectory Panels
                //-------------------------------------------------------------------------------
                if (audioSettingsData.HeightPnlHomeDirectory > 0)
                {
                    this.m_pnlHomeDirectory.Height = audioSettingsData.HeightPnlHomeDirectory;
                }
                //-------------------------------------------------------------------------------
                // Breite des HomeDirectory Trees
                //-------------------------------------------------------------------------------
                if (audioSettingsData.WidthTrvHomeDirectory > 0)
                {
                    this.m_trvHomeDirectory.Width = audioSettingsData.WidthTrvHomeDirectory;
                }
                //-------------------------------------------------------------------------------
                // Spaltenbreite der ListView ImportDirectory neu setzen.
                //-------------------------------------------------------------------------------
                int iSizeImportDirectory = this.m_lstvImportDirectory.Columns.Count;
                int[] columnWidthsImportDirectory = audioSettingsData.ColumnWidthsLvwImportDirectory;
                if (columnWidthsImportDirectory != null)
                {
                    int iSizeIntArray = columnWidthsImportDirectory.Length;
                    for (int i = 0; i < iSizeImportDirectory; ++i)
                    {
                        if (i < iSizeIntArray)
                        {
                            this.m_lstvImportDirectory.Columns[i].Width = columnWidthsImportDirectory[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                //-------------------------------------------------------------------------------
                // Spaltenbreite der ListView HomeDirectory neu setzen.
                //-------------------------------------------------------------------------------
                int iSizeHomeDirectory = this.m_lstvHomeDirectory.Columns.Count;
                int[] columnWidthsHomeDirectory = audioSettingsData.ColumnWidthsLvwHomeDirectory;
                if (columnWidthsHomeDirectory != null)
                {
                    int iSizeIntArray = columnWidthsHomeDirectory.Length;
                    for (int i = 0; i < iSizeHomeDirectory; ++i)
                    {
                        if (i < iSizeIntArray)
                        {
                            this.m_lstvHomeDirectory.Columns[i].Width = columnWidthsHomeDirectory[i];
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
            CAudioSettingsData audioSettingsData = new CAudioSettingsData();

            audioSettingsData.BackgroundImage = this.ContentPanel.BackgroundImage;

            if (this.WindowState == FormWindowState.Normal)
            {
                audioSettingsData.HeightPnlImportDirectory = this.m_pnlImportDirectory.Height;
                audioSettingsData.HeightPnlHomeDirectory = this.m_pnlHomeDirectory.Height;
                audioSettingsData.WidthTrvImportDirectory = this.m_trvImportDirectory.Width;
                audioSettingsData.WidthTrvHomeDirectory = this.m_trvHomeDirectory.Width;
            }
            
            int iSizeImportDirectory = this.m_lstvImportDirectory.Columns.Count;
            int[] columnWidthsImportDirectory = new int[iSizeImportDirectory];
            for (int i = 0; i < iSizeImportDirectory; ++i)
            {
                columnWidthsImportDirectory[i] = this.m_lstvImportDirectory.Columns[i].Width;
            }
            audioSettingsData.ColumnWidthsLvwImportDirectory = columnWidthsImportDirectory;

            int iSizeHomeDirectory = this.m_lstvHomeDirectory.Columns.Count;
            int[] columnWidthsHomeDirectory = new int[iSizeImportDirectory];
            for (int i = 0; i < iSizeHomeDirectory; ++i)
            {
                columnWidthsHomeDirectory[i] = this.m_lstvHomeDirectory.Columns[i].Width;
            }
            audioSettingsData.ColumnWidthsLvwHomeDirectory = columnWidthsHomeDirectory;

            audioSettingsData.SaveSettings(this, this.m_settings, audioSettingsData);
        }

        private void OptionsChanged(object sender, System.EventArgs e)
        {
            OptionsDialog options = sender as OptionsDialog;
            if (options != null)
            {
                options.ConfigurationChanged -= new System.EventHandler(this.OptionsChanged);
            }
            this.m_audioImportConfigurationObject =
                CAudioImportConfigurationControl.GetConfiguration(this.m_Configuration) as AudioImportConfigurationData;

            this.m_fileConfigurationObject =
                FileConfigurationControl.GetConfiguration(this.m_Configuration) as FileConfigurationData;

            SetRootNodeTreeViewHomeDirectory();
        }

        private MenuItem[] mnuCopyFiles()
        {
            MenuItem[] menuItems = new MenuItem[1];
            MenuItem mnuCopyFile = new MenuItem();
            string strFileFullName = GetFileFullNameByOptionSettings();
            if (strFileFullName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                strFileFullName = strFileFullName.Substring(0, strFileFullName.Length - 1);
            }
            mnuCopyFile.Text = String.Format(
                CultureInfo.CurrentUICulture,
                Resources.IDS_MenuCopyFileText,
                strFileFullName);
            mnuCopyFile.Click += new System.EventHandler(this.m_mnuBearbeiten_CopyTracks_Click);

            menuItems[0] = mnuCopyFile;

            return menuItems;
        }

        private MenuItem[] mnuImportFiles()
        {
            MenuItem[] menuItems = new MenuItem[1];
            MenuItem mnuImportFile = new MenuItem();
            mnuImportFile.Text = String.Format(
                CultureInfo.CurrentUICulture,
                Resources.IDS_MenuImportFileText);
            mnuImportFile.Click += new System.EventHandler(this.m_mnuBearbeiten_ImportTracks_Click);

            menuItems[0] = mnuImportFile;

            return menuItems;
        }

        private void FoundDirectory(object sender, ReadDirectoriesEventArgs e)
        {
            this.m_trvImportDirectory.Invoke(new DelegateAddTreeViewNode(this.AddAudioDirectoryToTreeView),
                new object[] { this.m_trvImportDirectory, e.DirectoryInfo });
        }

        private void ReadingComplete(object sender, System.EventArgs e)
        {
            this.m_trvImportDirectory.Invoke(new DelegateTreeViewSelectNode(SelectTreeViewNode));
        }

        private void SelectTreeViewNode()
        {
            int iNodesCounter = this.m_trvImportDirectory.Nodes.Count;
            if (iNodesCounter > 0)
            {
                this.m_trvImportDirectory.SelectedNode = this.m_trvImportDirectory.Nodes[0];
            }
        }

        private void m_lstvMainAddFile(object sender, ReadFilesEventArgs e)
        {
            if (this.m_lstvImportDirectory.InvokeRequired == true)
            {
                this.m_lstvImportDirectory.Invoke(new DelegateAddListViewItem(this.AddAudioMetaDataToListView),
                    new object[] { this.m_lstvImportDirectory, e.AudioMetadata });
            }
        }

        private void m_lstvHomeDirectoryAddFile(object sender, ReadFilesEventArgs e)
        {
            if (this.m_lstvHomeDirectory.InvokeRequired == true)
            {
                this.m_lstvHomeDirectory.Invoke(new DelegateAddListViewItem(this.AddAudioMetaDataToListView),
                    new object[] { this.m_lstvHomeDirectory, e.AudioMetadata });
            }
        }

        private void AddAudioMetaDataToListView(BSE.Platten.Audio.WinControls.ListView listView, AudioMetadata audioMetaData)
        {
            if (audioMetaData != null)
            {
                this.m_lblStatus.Text = audioMetaData.Name;
                ListViewItem listViewItem = new ListViewItem(audioMetaData.FullName);
                try
                {
                    //ist WMTrackNumber keine Zahl..
                    int iTrackNumber = Convert.ToInt32(audioMetaData.WMTrackNumber,CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    if (String.IsNullOrEmpty(audioMetaData.WMTrackNumber) == false)
                    {
                        //Mit iTunes gerippte Tracks haben eine Tracknumber im String Format 1/12.
                        //Diese Tracknummern werden mit IndexOf("/") gefunden und konvertiert
                        int iIndex = audioMetaData.WMTrackNumber.IndexOf("/", StringComparison.OrdinalIgnoreCase);
                        if (iIndex > 0)
                        {
                            try
                            {
                                int iTrackNumber = Convert.ToInt32(
                                    audioMetaData.WMTrackNumber.Substring(0, iIndex),
                                    CultureInfo.InvariantCulture);
                                audioMetaData.WMTrackNumber = string.Format(
                                    CultureInfo.InvariantCulture, iTrackNumber.ToString(CultureInfo.InvariantCulture));
                            }
                            catch (FormatException)
                            {
                                //dann wird es durch string.empty ersetzt
                                audioMetaData.WMTrackNumber = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        //dann wird es durch string.empty ersetzt
                        audioMetaData.WMTrackNumber = string.Empty;
                    }
                }
                listViewItem.SubItems.Add(audioMetaData.WMTrackNumber);
                listViewItem.SubItems.Add(audioMetaData.Author);
                listViewItem.SubItems.Add(audioMetaData.WMAlbumTitle);
                listViewItem.SubItems.Add(audioMetaData.Title);
                listViewItem.SubItems.Add(audioMetaData.Duration.ToString());
                listViewItem.SubItems.Add(audioMetaData.WMGenre);
                listViewItem.SubItems.Add(audioMetaData.WMYear);
                listViewItem.Tag = audioMetaData;

                listView.Items.Add(listViewItem);
                listView.UpdateItem(listViewItem.Index);
                listViewItem.EnsureVisible();

            }

            this.m_lblStatus.Text = string.Empty;
        }

        private void AddAudioDirectoryToTreeView(System.Windows.Forms.TreeView treeView, System.IO.DirectoryInfo directoryInfo)
        {
            string strFullName = directoryInfo.FullName;
            if (treeView.Equals(this.m_trvImportDirectory) == true)
            {
                string strAudioHomeDirectory = GetFileFullNameByOptionSettings();
                if (strAudioHomeDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(),StringComparison.OrdinalIgnoreCase) == true)
                {
                    strAudioHomeDirectory = strAudioHomeDirectory.Substring(0, strAudioHomeDirectory.Length - 1);
                }
                if (strFullName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(),StringComparison.OrdinalIgnoreCase) == true)
                {
                    strFullName = strFullName.Substring(0, strFullName.Length - 1);
                }

                if (String.Equals(strAudioHomeDirectory, strFullName, StringComparison.OrdinalIgnoreCase) == false)
                {
                    TreeNode treeNode = new TreeNode(directoryInfo.FullName);
                    treeNode.ImageIndex = 0;
                    treeView.Nodes.Add(treeNode);
                }
            }
            else
            {
                TreeNode treeNode = new TreeNode(directoryInfo.FullName);
                treeNode.ImageIndex = 0;
                treeView.Nodes.Add(treeNode);
            }
        }

        private void DeleteSelectedItemsInListView(BSE.Platten.Audio.WinControls.ListView listView)
        {
            int iCountTracks = listView.SelectedItems.Count;
            string strFileFullName = string.Empty;
            String[] sourceFiles = new String[iCountTracks];
            for (int i = 0; i < iCountTracks; i++)
            {
                AudioMetadata audioMetaData = (AudioMetadata)listView.SelectedItems[i].Tag;
                strFileFullName = audioMetaData.FullName.Substring(0, audioMetaData.FullName.Length - audioMetaData.Name.Length);
                sourceFiles[i] = audioMetaData.FullName;
            }

            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strFileFullName);

            BSE.Shell.ShellFileOperation shellFileOperation = new BSE.Shell.ShellFileOperation();
            shellFileOperation.Operation = BSE.Shell.FileOperation.FO_DELETE;
            shellFileOperation.SourceFiles = sourceFiles;
            if (shellFileOperation.DoOperation())
            {
                ReadAudioDirectoriesAndFiles(directoryInfo, null, listView, null, false);
            }
        }

        private static bool IsListViewItemSelected(BSE.Platten.Audio.WinControls.ListView listView)
        {
            bool bListViewItemSelected = false;
            int iCountListViewItems = listView.SelectedItems.Count;
            if (iCountListViewItems > 0)
            {
                bListViewItemSelected = true;
            }
            return bListViewItemSelected;
        }

        private void EditSubItemsInListView(BSE.Platten.Audio.WinControls.ListView listView, BSE.Windows.Forms.SubItemEndEditingEventArgs e)
        {
            //bool Die Attribute werden nur bei true geschrieben. Schlägt die Prüfung der Tracknummer fehl -> false
            bool bWriteAttribute = true;
            ListViewItem listViewItem = e.ListViewItem;
            AudioMetadata audioMetaData = (AudioMetadata)listViewItem.Tag;
            WinControls.ColumnHeader columnHeader = (WinControls.ColumnHeader)listView.Columns[e.SubItemIndex];

            System.Reflection.PropertyInfo propertyInfo = audioMetaData.GetType().GetProperty(columnHeader.MetaDataPropertyName.ToString());
            if (e.DisplayText != propertyInfo.GetValue(audioMetaData, null).ToString())
            {
                try
                {
                    switch (columnHeader.AttribValue)
                    {
                        case WMFSDK.WMFSDKFunctions.g_wszWMTrackNumber:
                            int iTrackIndex;
                            if (int.TryParse(e.DisplayText,out iTrackIndex) == false)
                            {
                                string strMessage = string.Format(
                                    CultureInfo.CurrentUICulture,
                                    Resources.IDS_TrackStartIndexEception);
                                GlobalizedMessageBox.Show(this, strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.DisplayText = string.Empty;
                                bWriteAttribute = false;
                            }
                            break;
                    }
                    if (bWriteAttribute)
                    {
                        AudioData audioData = null;

                        if (BSE.Platten.BO.Environment.IsWritableAudioExtension(audioMetaData.Extension) == true)
                        {
                            audioData = new WMFMediaData();
                            audioData.SetAttribute(audioMetaData.FullName, columnHeader.AttribValue
                                , columnHeader.AttribDataType
                                , e.DisplayText);
                        }
                    }
                    //der geänderte Wert wird wieder ins Object zurückgeschrieben
                    propertyInfo.SetValue(audioMetaData, e.DisplayText, null);
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void SearchDirectory(string strPath, string strSearchPattern)
        {
            this.m_trvImportDirectory.Nodes.Clear();
            this.m_lstvImportDirectory.Items.Clear();
            
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strPath);

            string strAudioHomeDirectory = GetFileFullNameByOptionSettings();
            if (strAudioHomeDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase) == true)
            {
                strAudioHomeDirectory = strAudioHomeDirectory.Substring(0, strAudioHomeDirectory.Length - 1);
            }

            string strImportDirectory = directoryInfo.FullName;
            if (strImportDirectory.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase) == true)
            {
                strImportDirectory = strImportDirectory.Substring(0, strImportDirectory.Length - 1);
            }

            if (String.Equals(strAudioHomeDirectory, strImportDirectory, StringComparison.OrdinalIgnoreCase) == true)
            {
                string strMessage = String.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ImportDirectoryEqualsHomeDirectoryException,
                    strImportDirectory);

                GlobalizedMessageBox.Show(this,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ReadAudioDirectoriesAndFiles(directoryInfo, strSearchPattern, null, this.m_trvImportDirectory, true);
            }
        }

        private void ReadAudioDirectoriesAndFiles(
            System.IO.DirectoryInfo directoryInfo,
            string strSearchPattern,
            BSE.Platten.Audio.WinControls.ListView listView,
            System.Windows.Forms.TreeView treeView,
            bool bScanOnlyFolders)
        {
            this.m_readAudioDirectories = new ReadAudioDirectoriesForm(directoryInfo, strSearchPattern, bScanOnlyFolders);
            if (listView != null)
            {
                listView.Items.Clear();
                if (listView.Name == this.m_lstvImportDirectory.Name)
                {
                    this.m_readAudioDirectories.FoundFile -= new EventHandler<ReadFilesEventArgs>(
                        this.m_lstvMainAddFile);
                    this.m_readAudioDirectories.FoundFile += new EventHandler<ReadFilesEventArgs>(
                        this.m_lstvMainAddFile);
                }
                if (listView.Name == this.m_lstvHomeDirectory.Name)
                {
                    this.m_readAudioDirectories.FoundFile -= new EventHandler<ReadFilesEventArgs>(
                        this.m_lstvHomeDirectoryAddFile);
                    this.m_readAudioDirectories.FoundFile += new EventHandler<ReadFilesEventArgs>(
                        this.m_lstvHomeDirectoryAddFile);
                }
            }
            if (treeView != null)
            {
                //damit m_readAudioDirectories auch nach dem Abruch sauber funktioniert, muss der Focus vor
                //Ausführung auf den Toolstrip gelegt werden
                this.m_tsMain.Focus();
                treeView.Nodes.Clear();
                if (treeView.Name == this.m_trvImportDirectory.Name)
                {
                    this.m_readAudioDirectories.FoundDirectory -= new EventHandler<ReadDirectoriesEventArgs>(
                        this.FoundDirectory);
                    this.m_readAudioDirectories.FoundDirectory += new EventHandler<ReadDirectoriesEventArgs>(
                        this.FoundDirectory);
                    this.m_readAudioDirectories.ReadingComplete -= new System.EventHandler(ReadingComplete);
                    this.m_readAudioDirectories.ReadingComplete += new System.EventHandler(ReadingComplete);
                }
            }
            this.m_readAudioDirectories.PanelStyle = this.PanelStyle;
            this.m_readAudioDirectories.PanelColors = this.PanelColors;
            this.m_readAudioDirectories.ProfessionalColorTable = this.ProfessionalColorTable;
            this.m_readAudioDirectories.ShowDialog(this);
        }

        private bool ImportAudioTracks(ListViewItem[] listViewItems)
        {
            string strFileFullName = GetFileFullNameByOptionSettings();
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strFileFullName);
            if (!directoryInfo.Exists)
            {
                try
                {
                    directoryInfo.Create();
                }
                catch (System.UnauthorizedAccessException)
                {
                    throw;
                }
            }

            int iCountListViewItems = listViewItems.Length;
            String[] sourceFiles = new String[iCountListViewItems];
            String[] destinationFiles = new String[iCountListViewItems];

            for (int i = 0; i < iCountListViewItems; i++)
            {
                ListViewItem listViewItem = listViewItems[i];
                AudioMetadata audioMetaData = (AudioMetadata)listViewItem.Tag;
                sourceFiles[i] = audioMetaData.FullName;
                if (string.IsNullOrEmpty(audioMetaData.WMTrackNumber) == true)
                {
                    string strMessage = String.Format(
                        CultureInfo.CurrentUICulture,
                        Resources.IDS_NoTrackNumberException,
                        audioMetaData.FullName);
                    GlobalizedMessageBox.Show(this,strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (this.m_fileConfigurationObject.TitleAsFileName == true)
                {
                    destinationFiles[i] = strFileFullName + audioMetaData.Name;
                }
                else
                {
                    string strTrackIndex = int.Parse(
                        audioMetaData.WMTrackNumber,
                        CultureInfo.InvariantCulture).ToString("00",CultureInfo.InvariantCulture);
                    destinationFiles[i] = strFileFullName + this.m_strTrackName + "_" + strTrackIndex + audioMetaData.Extension;
                }
            }
            BSE.Shell.ShellFileOperation shellFileOperation = new BSE.Shell.ShellFileOperation();
            shellFileOperation.Operation = this.m_audioImportConfigurationObject.FileOperations;
            shellFileOperation.Handle = this.Handle;
            shellFileOperation.SourceFiles = sourceFiles;
            shellFileOperation.DestinationFiles = destinationFiles;

            return shellFileOperation.DoOperation();
        }

        private void SetRootNodeTreeViewHomeDirectory()
        {
            this.m_trvHomeDirectory.Nodes.Clear();
            this.m_lstvHomeDirectory.Items.Clear();
            string strFileFullName = GetFileFullNameByOptionSettings();
            string strRootNode = strFileFullName;
            if (strRootNode.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                strRootNode = strRootNode.Substring(0, strRootNode.Length - 1);
            }
            
            this.m_trvHomeDirectory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																						   new System.Windows.Forms.TreeNode(strRootNode)});
            this.m_trvHomeDirectory.Nodes[0].ImageIndex = 1;
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(strFileFullName);
            if (directoryInfo.Exists)
            {
                ReadAudioDirectoriesAndFiles(directoryInfo, null, this.m_lstvHomeDirectory, null, false);
            }
        }

        private string GetFileFullNameByOptionSettings()
        {
            string strFileFullName = string.Empty;
            string strInterpret = string.Empty;
            string strAlbum = string.Empty;

            string strHomeDirectory = this.HomeDirectory;
            strHomeDirectory = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strHomeDirectory);

            if (this.m_fileConfigurationObject.EachAlbumGetsDirectory == true)
            {
                if (this.m_bExternalOutPutConfiguration)
                {
                    strInterpret = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(this.m_Album.Interpret);
                    strInterpret = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strInterpret);

                    strAlbum = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(this.m_Album.Title);
                    strAlbum = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strAlbum);
                }
            }

            strFileFullName = strHomeDirectory + strInterpret + strAlbum;
            if (String.IsNullOrEmpty(strFileFullName) == false)
            {
                strFileFullName = BSE.Platten.BO.Environment.AppendDirectorySeparatorChar(strFileFullName);
            }

            return strFileFullName;
        }

        #endregion
    }

    public class CAudioSettingsData : BaseFormSettingsData
    {
        #region Properties

        /// <summary>
        /// Spaltenbreiten für ListView ImportDirectory
        /// </summary>
        public int[] ColumnWidthsLvwImportDirectory
        {
            get;
            set;
        }
        /// <summary>
        /// Spaltenbreiten für ListView HomeDirectory
        /// </summary>
        public int[] ColumnWidthsLvwHomeDirectory
        {
            get;
            set;
        }
        /// <summary>
        /// Höhe des ImportDirectory Panels
        /// </summary>
        public int HeightPnlImportDirectory
        {
            get;
            set;
        }
        /// <summary>
        /// Höhe des HomeDirectory Panels
        /// </summary>
        public int HeightPnlHomeDirectory
        {
            get;
            set;
        }
        /// <summary>
        /// Höhe des ImportDirectory Panels
        /// </summary>
        public int WidthTrvImportDirectory
        {
            get;
            set;
        }
        /// <summary>
        /// Höhe des HomeDirectory Panels
        /// </summary>
        public int WidthTrvHomeDirectory
        {
            get;
            set;
        }
        #endregion
    }
}