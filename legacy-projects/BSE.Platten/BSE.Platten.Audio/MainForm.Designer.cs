namespace BSE.Platten.Audio
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (this.m_imgBSEIcon != null)
                {
                    this.m_imgBSEIcon.Dispose();
                }
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.m_ssMain = new System.Windows.Forms.StatusStrip();
            this.m_lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_pnlHomeDirectory = new BSE.Windows.Forms.Panel();
            this.m_splHomeDirectory = new BSE.Windows.Forms.Splitter();
            this.m_trvHomeDirectory = new System.Windows.Forms.TreeView();
            this.m_imgMain = new System.Windows.Forms.ImageList(this.components);
            this.m_splListViews = new BSE.Windows.Forms.Splitter();
            this.m_pnlImportDirectory = new BSE.Windows.Forms.Panel();
            this.m_splImportDirectory = new BSE.Windows.Forms.Splitter();
            this.m_trvImportDirectory = new System.Windows.Forms.TreeView();
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnAllTracksOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnSelectedTracksOK = new System.Windows.Forms.Button();
            this.m_tsMain = new System.Windows.Forms.ToolStrip();
            this.m_lblAddress = new System.Windows.Forms.ToolStripLabel();
            this.m_cboAddress = new System.Windows.Forms.ToolStripComboBox();
            this.m_btnGotoAddress = new System.Windows.Forms.ToolStripButton();
            this.m_btnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.m_btnBearbeiten_CopyAll = new System.Windows.Forms.ToolStripButton();
            this.m_btnBearbeiten_ImportAll = new System.Windows.Forms.ToolStripButton();
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.m_mnuDatei = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatei_OpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatei_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuDatei_End = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBearbeiten = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBearbeiten_CopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBearbeiten_ImportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExtras_Optionen = new System.Windows.Forms.ToolStripMenuItem();
            this.m_fldDlgOpenDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.m_Configuration = new BSE.Configuration.Configuration();
            this.m_settings = new BSE.Configuration.Configuration();
            this.m_lstvHomeDirectory = new BSE.Platten.Audio.WinControls.ListView();
            this.m_clmnHome_FileFullName = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_TrackNumber = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_Interpret = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_Album = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_Title = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_Duration = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_Genre = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnHome_Year = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_lstvImportDirectory = new BSE.Platten.Audio.WinControls.ListView();
            this.m_clmnFileFullName = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnTrackNumber = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnInterpret = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnAlbum = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnTitle = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnDuration = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnGenre = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.m_clmnYear = ((BSE.Platten.Audio.WinControls.ColumnHeader)(new BSE.Platten.Audio.WinControls.ColumnHeader()));
            this.ContentPanel.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.m_ssMain.SuspendLayout();
            this.m_pnlHomeDirectory.SuspendLayout();
            this.m_pnlImportDirectory.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_tsMain.SuspendLayout();
            this.m_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.Controls.Add(this.toolStripContainer1);
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.m_ssMain);
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_pnlHomeDirectory);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_splListViews);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_pnlImportDirectory);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_pnlAction);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.m_tsMain);
            // 
            // m_ssMain
            // 
            resources.ApplyResources(this.m_ssMain, "m_ssMain");
            this.m_ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_lblStatus});
            this.m_ssMain.Name = "m_ssMain";
            this.m_ssMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            // 
            // m_lblStatus
            // 
            resources.ApplyResources(this.m_lblStatus, "m_lblStatus");
            this.m_lblStatus.Name = "m_lblStatus";
            // 
            // m_pnlHomeDirectory
            // 
            resources.ApplyResources(this.m_pnlHomeDirectory, "m_pnlHomeDirectory");
            this.m_pnlHomeDirectory.AssociatedSplitter = null;
            this.m_pnlHomeDirectory.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlHomeDirectory.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlHomeDirectory.CaptionHeight = 27;
            this.m_pnlHomeDirectory.Controls.Add(this.m_lstvHomeDirectory);
            this.m_pnlHomeDirectory.Controls.Add(this.m_splHomeDirectory);
            this.m_pnlHomeDirectory.Controls.Add(this.m_trvHomeDirectory);
            this.m_pnlHomeDirectory.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlHomeDirectory.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlHomeDirectory.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlHomeDirectory.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlHomeDirectory.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlHomeDirectory.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlHomeDirectory.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlHomeDirectory.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlHomeDirectory.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlHomeDirectory.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlHomeDirectory.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlHomeDirectory.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlHomeDirectory.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlHomeDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlHomeDirectory.Image = null;
            this.m_pnlHomeDirectory.Name = "m_pnlHomeDirectory";
            this.m_pnlHomeDirectory.ToolTipTextCloseIcon = null;
            this.m_pnlHomeDirectory.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlHomeDirectory.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_splHomeDirectory
            // 
            resources.ApplyResources(this.m_splHomeDirectory, "m_splHomeDirectory");
            this.m_splHomeDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.m_splHomeDirectory.Name = "m_splHomeDirectory";
            this.m_splHomeDirectory.TabStop = false;
            // 
            // m_trvHomeDirectory
            // 
            resources.ApplyResources(this.m_trvHomeDirectory, "m_trvHomeDirectory");
            this.m_trvHomeDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_trvHomeDirectory.ImageList = this.m_imgMain;
            this.m_trvHomeDirectory.Name = "m_trvHomeDirectory";
            this.m_trvHomeDirectory.ShowLines = false;
            // 
            // m_imgMain
            // 
            this.m_imgMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgMain.ImageStream")));
            this.m_imgMain.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgMain.Images.SetKeyName(0, "Folder256.png");
            this.m_imgMain.Images.SetKeyName(1, "FolderOpen256.png");
            // 
            // m_splListViews
            // 
            resources.ApplyResources(this.m_splListViews, "m_splListViews");
            this.m_splListViews.BackColor = System.Drawing.Color.Transparent;
            this.m_splListViews.Name = "m_splListViews";
            this.m_splListViews.TabStop = false;
            // 
            // m_pnlImportDirectory
            // 
            resources.ApplyResources(this.m_pnlImportDirectory, "m_pnlImportDirectory");
            this.m_pnlImportDirectory.AssociatedSplitter = null;
            this.m_pnlImportDirectory.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlImportDirectory.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlImportDirectory.CaptionHeight = 27;
            this.m_pnlImportDirectory.Controls.Add(this.m_lstvImportDirectory);
            this.m_pnlImportDirectory.Controls.Add(this.m_splImportDirectory);
            this.m_pnlImportDirectory.Controls.Add(this.m_trvImportDirectory);
            this.m_pnlImportDirectory.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlImportDirectory.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlImportDirectory.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlImportDirectory.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlImportDirectory.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlImportDirectory.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlImportDirectory.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlImportDirectory.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlImportDirectory.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlImportDirectory.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlImportDirectory.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlImportDirectory.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlImportDirectory.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlImportDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlImportDirectory.Image = null;
            this.m_pnlImportDirectory.Name = "m_pnlImportDirectory";
            this.m_pnlImportDirectory.ToolTipTextCloseIcon = null;
            this.m_pnlImportDirectory.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlImportDirectory.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_splImportDirectory
            // 
            resources.ApplyResources(this.m_splImportDirectory, "m_splImportDirectory");
            this.m_splImportDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.m_splImportDirectory.Name = "m_splImportDirectory";
            this.m_splImportDirectory.TabStop = false;
            // 
            // m_trvImportDirectory
            // 
            resources.ApplyResources(this.m_trvImportDirectory, "m_trvImportDirectory");
            this.m_trvImportDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_trvImportDirectory.ImageList = this.m_imgMain;
            this.m_trvImportDirectory.Name = "m_trvImportDirectory";
            this.m_trvImportDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvImportDirectory_AfterSelect);
            // 
            // m_pnlAction
            // 
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.SystemColors.Control;
            this.m_pnlAction.Controls.Add(this.m_btnAllTracksOk);
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Controls.Add(this.m_btnSelectedTracksOK);
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnAllTracksOk
            // 
            resources.ApplyResources(this.m_btnAllTracksOk, "m_btnAllTracksOk");
            this.m_btnAllTracksOk.Name = "m_btnAllTracksOk";
            this.m_btnAllTracksOk.UseVisualStyleBackColor = true;
            this.m_btnAllTracksOk.Click += new System.EventHandler(this.ButtonAllTracksOk_Click);
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_btnSelectedTracksOK
            // 
            resources.ApplyResources(this.m_btnSelectedTracksOK, "m_btnSelectedTracksOK");
            this.m_btnSelectedTracksOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnSelectedTracksOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnSelectedTracksOK.Name = "m_btnSelectedTracksOK";
            this.m_btnSelectedTracksOK.UseVisualStyleBackColor = true;
            this.m_btnSelectedTracksOK.Click += new System.EventHandler(this.ButtonSelectedTracksOKClick);
            // 
            // m_tsMain
            // 
            resources.ApplyResources(this.m_tsMain, "m_tsMain");
            this.m_tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_tsMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_lblAddress,
            this.m_cboAddress,
            this.m_btnGotoAddress,
            this.m_btnOpenFolder,
            this.m_btnBearbeiten_CopyAll,
            this.m_btnBearbeiten_ImportAll});
            this.m_tsMain.Name = "m_tsMain";
            this.m_tsMain.Stretch = true;
            // 
            // m_lblAddress
            // 
            resources.ApplyResources(this.m_lblAddress, "m_lblAddress");
            this.m_lblAddress.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.m_lblAddress.Name = "m_lblAddress";
            // 
            // m_cboAddress
            // 
            resources.ApplyResources(this.m_cboAddress, "m_cboAddress");
            this.m_cboAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.m_cboAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.m_cboAddress.Name = "m_cboAddress";
            this.m_cboAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboAddress_KeyDown);
            this.m_cboAddress.TextChanged += new System.EventHandler(this.m_cboAddress_TextChanged);
            // 
            // m_btnGotoAddress
            // 
            resources.ApplyResources(this.m_btnGotoAddress, "m_btnGotoAddress");
            this.m_btnGotoAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnGotoAddress.Image = global::BSE.Platten.Audio.Properties.Resources.GoLtrHS;
            this.m_btnGotoAddress.Name = "m_btnGotoAddress";
            this.m_btnGotoAddress.Click += new System.EventHandler(this.m_btnGotoAddress_Click);
            // 
            // m_btnOpenFolder
            // 
            resources.ApplyResources(this.m_btnOpenFolder, "m_btnOpenFolder");
            this.m_btnOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnOpenFolder.Image = global::BSE.Platten.Audio.Properties.Resources.FolderFind;
            this.m_btnOpenFolder.Name = "m_btnOpenFolder";
            this.m_btnOpenFolder.Click += new System.EventHandler(this.m_mnuDatei_OpenDirectory_Click);
            // 
            // m_btnBearbeiten_CopyAll
            // 
            resources.ApplyResources(this.m_btnBearbeiten_CopyAll, "m_btnBearbeiten_CopyAll");
            this.m_btnBearbeiten_CopyAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnBearbeiten_CopyAll.Image = global::BSE.Platten.Audio.Properties.Resources.FillDownHS;
            this.m_btnBearbeiten_CopyAll.Name = "m_btnBearbeiten_CopyAll";
            this.m_btnBearbeiten_CopyAll.Click += new System.EventHandler(this.m_mnuBearbeiten_CopyAll_Click);
            // 
            // m_btnBearbeiten_ImportAll
            // 
            resources.ApplyResources(this.m_btnBearbeiten_ImportAll, "m_btnBearbeiten_ImportAll");
            this.m_btnBearbeiten_ImportAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnBearbeiten_ImportAll.Image = global::BSE.Platten.Audio.Properties.Resources.FillLeftHS;
            this.m_btnBearbeiten_ImportAll.Name = "m_btnBearbeiten_ImportAll";
            this.m_btnBearbeiten_ImportAll.Click += new System.EventHandler(this.m_mnuBearbeiten_ImportAll_Click);
            // 
            // m_mainMenu
            // 
            resources.ApplyResources(this.m_mainMenu, "m_mainMenu");
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatei,
            this.m_mnuBearbeiten,
            this.m_mnuExtras});
            this.m_mainMenu.Name = "m_mainMenu";
            // 
            // m_mnuDatei
            // 
            resources.ApplyResources(this.m_mnuDatei, "m_mnuDatei");
            this.m_mnuDatei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatei_OpenDirectory,
            this.m_mnuDatei_Separator,
            this.m_mnuDatei_End});
            this.m_mnuDatei.Name = "m_mnuDatei";
            // 
            // m_mnuDatei_OpenDirectory
            // 
            resources.ApplyResources(this.m_mnuDatei_OpenDirectory, "m_mnuDatei_OpenDirectory");
            this.m_mnuDatei_OpenDirectory.Image = global::BSE.Platten.Audio.Properties.Resources.FolderFind;
            this.m_mnuDatei_OpenDirectory.Name = "m_mnuDatei_OpenDirectory";
            this.m_mnuDatei_OpenDirectory.Click += new System.EventHandler(this.m_mnuDatei_OpenDirectory_Click);
            // 
            // m_mnuDatei_Separator
            // 
            resources.ApplyResources(this.m_mnuDatei_Separator, "m_mnuDatei_Separator");
            this.m_mnuDatei_Separator.Name = "m_mnuDatei_Separator";
            // 
            // m_mnuDatei_End
            // 
            resources.ApplyResources(this.m_mnuDatei_End, "m_mnuDatei_End");
            this.m_mnuDatei_End.Name = "m_mnuDatei_End";
            this.m_mnuDatei_End.Click += new System.EventHandler(this.m_mnuDatei_End_Click);
            // 
            // m_mnuBearbeiten
            // 
            resources.ApplyResources(this.m_mnuBearbeiten, "m_mnuBearbeiten");
            this.m_mnuBearbeiten.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuBearbeiten_CopyAll,
            this.m_mnuBearbeiten_ImportAll});
            this.m_mnuBearbeiten.Name = "m_mnuBearbeiten";
            // 
            // m_mnuBearbeiten_CopyAll
            // 
            resources.ApplyResources(this.m_mnuBearbeiten_CopyAll, "m_mnuBearbeiten_CopyAll");
            this.m_mnuBearbeiten_CopyAll.Image = global::BSE.Platten.Audio.Properties.Resources.FillDownHS;
            this.m_mnuBearbeiten_CopyAll.Name = "m_mnuBearbeiten_CopyAll";
            this.m_mnuBearbeiten_CopyAll.Click += new System.EventHandler(this.m_mnuBearbeiten_CopyAll_Click);
            // 
            // m_mnuBearbeiten_ImportAll
            // 
            resources.ApplyResources(this.m_mnuBearbeiten_ImportAll, "m_mnuBearbeiten_ImportAll");
            this.m_mnuBearbeiten_ImportAll.Image = global::BSE.Platten.Audio.Properties.Resources.FillLeftHS;
            this.m_mnuBearbeiten_ImportAll.Name = "m_mnuBearbeiten_ImportAll";
            this.m_mnuBearbeiten_ImportAll.Click += new System.EventHandler(this.m_mnuBearbeiten_ImportAll_Click);
            // 
            // m_mnuExtras
            // 
            resources.ApplyResources(this.m_mnuExtras, "m_mnuExtras");
            this.m_mnuExtras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuExtras_Optionen});
            this.m_mnuExtras.Name = "m_mnuExtras";
            // 
            // m_mnuExtras_Optionen
            // 
            resources.ApplyResources(this.m_mnuExtras_Optionen, "m_mnuExtras_Optionen");
            this.m_mnuExtras_Optionen.Image = global::BSE.Platten.Audio.Properties.Resources.OptionsHS;
            this.m_mnuExtras_Optionen.Name = "m_mnuExtras_Optionen";
            this.m_mnuExtras_Optionen.Click += new System.EventHandler(this.m_mnuExtras_Optionen_Click);
            // 
            // m_fldDlgOpenDirectory
            // 
            resources.ApplyResources(this.m_fldDlgOpenDirectory, "m_fldDlgOpenDirectory");
            this.m_fldDlgOpenDirectory.ShowNewFolderButton = false;
            // 
            // m_Configuration
            // 
            this.m_Configuration.ApplicationSubDirectory = null;
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
            // 
            // m_lstvHomeDirectory
            // 
            resources.ApplyResources(this.m_lstvHomeDirectory, "m_lstvHomeDirectory");
            this.m_lstvHomeDirectory.AllowColumnReorder = true;
            this.m_lstvHomeDirectory.AllowDrop = true;
            this.m_lstvHomeDirectory.AllowSelectAllItems = true;
            this.m_lstvHomeDirectory.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvHomeDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstvHomeDirectory.Columns.AddRange(new BSE.Platten.Audio.WinControls.ColumnHeader[] {
            this.m_clmnHome_FileFullName,
            this.m_clmnHome_TrackNumber,
            this.m_clmnHome_Interpret,
            this.m_clmnHome_Album,
            this.m_clmnHome_Title,
            this.m_clmnHome_Duration,
            this.m_clmnHome_Genre,
            this.m_clmnHome_Year});
            this.m_lstvHomeDirectory.DragDropOnlyAsEvent = true;
            this.m_lstvHomeDirectory.FitLargestItem = true;
            this.m_lstvHomeDirectory.HideSelection = false;
            this.m_lstvHomeDirectory.Name = "m_lstvHomeDirectory";
            this.m_lstvHomeDirectory.UseCompatibleStateImageBehavior = false;
            this.m_lstvHomeDirectory.View = System.Windows.Forms.View.Details;
            this.m_lstvHomeDirectory.SubItemEndEditing += new System.EventHandler<BSE.Windows.Forms.SubItemEndEditingEventArgs>(this.m_lstvHomeDirectory_SubItemEndEditing);
            this.m_lstvHomeDirectory.ListViewItemAdded += new System.EventHandler<System.EventArgs>(this.m_lstvHomeDirectory_ListViewItemAdded);
            this.m_lstvHomeDirectory.ListViewItemRemoved += new System.EventHandler<System.EventArgs>(this.m_lstvHomeDirectory_ListViewItemRemoved);
            this.m_lstvHomeDirectory.SelectedIndexChanged += new System.EventHandler(this.m_lstvHomeDirectory_SelectedIndexChanged);
            this.m_lstvHomeDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lstvHomeDirectory_DragDrop);
            this.m_lstvHomeDirectory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lstvHomeDirectory_KeyUp);
            this.m_lstvHomeDirectory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lstvHomeDirectory_MouseUp);
            // 
            // m_clmnHome_FileFullName
            // 
            this.m_clmnHome_FileFullName.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnHome_FileFullName.AttribValue = "";
            this.m_clmnHome_FileFullName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_FileFullName.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.None;
            resources.ApplyResources(this.m_clmnHome_FileFullName, "m_clmnHome_FileFullName");
            // 
            // m_clmnHome_TrackNumber
            // 
            this.m_clmnHome_TrackNumber.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_DWORD;
            this.m_clmnHome_TrackNumber.AttribValue = "WM/TrackNumber";
            this.m_clmnHome_TrackNumber.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnHome_TrackNumber.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            this.m_clmnHome_TrackNumber.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMTrackNumber;
            resources.ApplyResources(this.m_clmnHome_TrackNumber, "m_clmnHome_TrackNumber");
            // 
            // m_clmnHome_Interpret
            // 
            this.m_clmnHome_Interpret.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnHome_Interpret.AttribValue = "Author";
            this.m_clmnHome_Interpret.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnHome_Interpret.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_Interpret.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.Author;
            resources.ApplyResources(this.m_clmnHome_Interpret, "m_clmnHome_Interpret");
            // 
            // m_clmnHome_Album
            // 
            this.m_clmnHome_Album.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnHome_Album.AttribValue = "WM/AlbumTitle";
            this.m_clmnHome_Album.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnHome_Album.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_Album.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMAlbumTitle;
            resources.ApplyResources(this.m_clmnHome_Album, "m_clmnHome_Album");
            // 
            // m_clmnHome_Title
            // 
            this.m_clmnHome_Title.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnHome_Title.AttribValue = "Title";
            this.m_clmnHome_Title.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnHome_Title.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_Title.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.Title;
            resources.ApplyResources(this.m_clmnHome_Title, "m_clmnHome_Title");
            // 
            // m_clmnHome_Duration
            // 
            this.m_clmnHome_Duration.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_QWORD;
            this.m_clmnHome_Duration.AttribValue = "Duration";
            this.m_clmnHome_Duration.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_Duration.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.Duration;
            resources.ApplyResources(this.m_clmnHome_Duration, "m_clmnHome_Duration");
            // 
            // m_clmnHome_Genre
            // 
            this.m_clmnHome_Genre.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnHome_Genre.AttribValue = "WM/Genre";
            this.m_clmnHome_Genre.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_Genre.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMGenre;
            resources.ApplyResources(this.m_clmnHome_Genre, "m_clmnHome_Genre");
            // 
            // m_clmnHome_Year
            // 
            this.m_clmnHome_Year.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnHome_Year.AttribValue = "WM/Year";
            this.m_clmnHome_Year.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnHome_Year.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMYear;
            resources.ApplyResources(this.m_clmnHome_Year, "m_clmnHome_Year");
            // 
            // m_lstvImportDirectory
            // 
            resources.ApplyResources(this.m_lstvImportDirectory, "m_lstvImportDirectory");
            this.m_lstvImportDirectory.AllowColumnReorder = true;
            this.m_lstvImportDirectory.AllowDrag = true;
            this.m_lstvImportDirectory.AllowSelectAllItems = true;
            this.m_lstvImportDirectory.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvImportDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstvImportDirectory.Columns.AddRange(new BSE.Platten.Audio.WinControls.ColumnHeader[] {
            this.m_clmnFileFullName,
            this.m_clmnTrackNumber,
            this.m_clmnInterpret,
            this.m_clmnAlbum,
            this.m_clmnTitle,
            this.m_clmnDuration,
            this.m_clmnGenre,
            this.m_clmnYear});
            this.m_lstvImportDirectory.DragDropEffects = System.Windows.Forms.DragDropEffects.Copy;
            this.m_lstvImportDirectory.FitLargestItem = true;
            this.m_lstvImportDirectory.HideSelection = false;
            this.m_lstvImportDirectory.Name = "m_lstvImportDirectory";
            this.m_lstvImportDirectory.UseCompatibleStateImageBehavior = false;
            this.m_lstvImportDirectory.View = System.Windows.Forms.View.Details;
            this.m_lstvImportDirectory.SubItemEndEditing += new System.EventHandler<BSE.Windows.Forms.SubItemEndEditingEventArgs>(this.m_lstvImportDirectory_SubItemEndEditing);
            this.m_lstvImportDirectory.SelectedIndexChanged += new System.EventHandler(this.m_lstvImportDirectory_SelectedIndexChanged);
            this.m_lstvImportDirectory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lstvImportDirectory_KeyUp);
            this.m_lstvImportDirectory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lstvImportDirectory_MouseUp);
            // 
            // m_clmnFileFullName
            // 
            this.m_clmnFileFullName.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_DWORD;
            this.m_clmnFileFullName.AttribValue = null;
            this.m_clmnFileFullName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnFileFullName.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.None;
            resources.ApplyResources(this.m_clmnFileFullName, "m_clmnFileFullName");
            // 
            // m_clmnTrackNumber
            // 
            this.m_clmnTrackNumber.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnTrackNumber.AttribValue = "WM/TrackNumber";
            this.m_clmnTrackNumber.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnTrackNumber.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            this.m_clmnTrackNumber.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMTrackNumber;
            resources.ApplyResources(this.m_clmnTrackNumber, "m_clmnTrackNumber");
            // 
            // m_clmnInterpret
            // 
            this.m_clmnInterpret.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnInterpret.AttribValue = "Author";
            this.m_clmnInterpret.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnInterpret.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnInterpret.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.Author;
            resources.ApplyResources(this.m_clmnInterpret, "m_clmnInterpret");
            // 
            // m_clmnAlbum
            // 
            this.m_clmnAlbum.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnAlbum.AttribValue = "WM/AlbumTitle";
            this.m_clmnAlbum.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnAlbum.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnAlbum.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMAlbumTitle;
            resources.ApplyResources(this.m_clmnAlbum, "m_clmnAlbum");
            // 
            // m_clmnTitle
            // 
            this.m_clmnTitle.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnTitle.AttribValue = "Title";
            this.m_clmnTitle.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnTitle.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnTitle.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.Title;
            resources.ApplyResources(this.m_clmnTitle, "m_clmnTitle");
            // 
            // m_clmnDuration
            // 
            this.m_clmnDuration.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_QWORD;
            this.m_clmnDuration.AttribValue = "Duration";
            this.m_clmnDuration.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnDuration.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.Duration;
            resources.ApplyResources(this.m_clmnDuration, "m_clmnDuration");
            // 
            // m_clmnGenre
            // 
            this.m_clmnGenre.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnGenre.AttribValue = "WM/Genre";
            this.m_clmnGenre.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnGenre.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMGenre;
            resources.ApplyResources(this.m_clmnGenre, "m_clmnGenre");
            // 
            // m_clmnYear
            // 
            this.m_clmnYear.AttribDataType = BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING;
            this.m_clmnYear.AttribValue = "WM/Year";
            this.m_clmnYear.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnYear.MetaDataPropertyName = BSE.Platten.Audio.MetadataPropertyName.WMYear;
            resources.ApplyResources(this.m_clmnYear, "m_clmnYear");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_mainMenu);
            this.MainMenuStrip = this.m_mainMenu;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CMain_FormClosed);
            this.Load += new System.EventHandler(this.CMain_Load);
            this.Controls.SetChildIndex(this.m_mainMenu, 0);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.m_ssMain.ResumeLayout(false);
            this.m_ssMain.PerformLayout();
            this.m_pnlHomeDirectory.ResumeLayout(false);
            this.m_pnlImportDirectory.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_tsMain.ResumeLayout(false);
            this.m_tsMain.PerformLayout();
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei_OpenDirectory;
        private System.Windows.Forms.ToolStripSeparator m_mnuDatei_Separator;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei_End;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten_CopyAll;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten_ImportAll;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExtras;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExtras_Optionen;
        private System.Windows.Forms.ToolStrip m_tsMain;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip m_ssMain;
        private System.Windows.Forms.ToolStripButton m_btnOpenFolder;
        private BSE.Windows.Forms.Panel m_pnlHomeDirectory;
        private BSE.Windows.Forms.Panel m_pnlImportDirectory;
        private System.Windows.Forms.TreeView m_trvImportDirectory;
        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnSelectedTracksOK;
        private BSE.Windows.Forms.Splitter m_splHomeDirectory;
        private System.Windows.Forms.TreeView m_trvHomeDirectory;
        private BSE.Windows.Forms.Splitter m_splImportDirectory;
        private System.Windows.Forms.Button m_btnCancel;
        private BSE.Platten.Audio.WinControls.ListView m_lstvHomeDirectory;
        private BSE.Platten.Audio.WinControls.ListView m_lstvImportDirectory;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnFileFullName;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnTrackNumber;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_FileFullName;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_TrackNumber;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_Interpret;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_Album;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_Title;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_Duration;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_Genre;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnHome_Year;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnInterpret;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnAlbum;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnTitle;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnDuration;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnGenre;
        private BSE.Platten.Audio.WinControls.ColumnHeader m_clmnYear;
        private System.Windows.Forms.FolderBrowserDialog m_fldDlgOpenDirectory;
        private BSE.Configuration.Configuration m_Configuration;
        private BSE.Windows.Forms.Splitter m_splListViews;
        private System.Windows.Forms.ImageList m_imgMain;
        private BSE.Configuration.Configuration m_settings;
        private System.Windows.Forms.ToolStripButton m_btnBearbeiten_CopyAll;
        private System.Windows.Forms.ToolStripButton m_btnBearbeiten_ImportAll;
        private System.Windows.Forms.ToolStripLabel m_lblAddress;
        private System.Windows.Forms.ToolStripComboBox m_cboAddress;
        private System.Windows.Forms.ToolStripButton m_btnGotoAddress;
        private System.Windows.Forms.Button m_btnAllTracksOk;
        private System.Windows.Forms.ToolStripStatusLabel m_lblStatus;
    }
}