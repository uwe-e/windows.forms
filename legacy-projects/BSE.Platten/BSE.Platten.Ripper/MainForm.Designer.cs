namespace BSE.Platten.Ripper
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
                if (this.m_cdDrive.IsOpened == true)
                {
                    this.m_cdDrive.Close();
                }
                this.m_cboCDDrives.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_tscMain = new System.Windows.Forms.ToolStripContainer();
            this.m_ssMain = new System.Windows.Forms.StatusStrip();
            this.m_lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_splListViews = new BSE.Windows.Forms.Splitter();
            this.m_pnlCopied = new BSE.Windows.Forms.Panel();
            this.m_lstvCopied = new BSE.Windows.Forms.ListView();
            this.m_clmnFileFullName = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_clmnTrackNumber = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_clmnTitle = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_clmnDuration = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_pnlRipper = new BSE.Windows.Forms.Panel();
            this.m_lstvMain = new BSE.Windows.Forms.ListView();
            this.m_lstvcolumnTracks = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_lstvcolumnSize = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_lstvcolumnType = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_lstvcolumnDuration = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_lstvcolumnOutName = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_tsMain = new System.Windows.Forms.ToolStrip();
            this.m_btnBearbeiten_OpenDrive = new System.Windows.Forms.ToolStripButton();
            this.m_cboCDDrives = new System.Windows.Forms.ToolStripComboBox();
            this.m_btnBrowseFreeDb = new System.Windows.Forms.ToolStripButton();
            this.m_lblStartIndex = new System.Windows.Forms.ToolStripLabel();
            this.m_txtStartIndex = new System.Windows.Forms.ToolStripTextBox();
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.m_mnuDatei = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatei_End = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBearbeiten = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBearbeiten_OpenDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuBearbeiten_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuBearbeiten_CopyTracks = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExtras_Optionen = new System.Windows.Forms.ToolStripMenuItem();
            this.m_configuration = new BSE.Configuration.Configuration();
            this.m_settings = new BSE.Configuration.Configuration();
            this.ContentPanel.SuspendLayout();
            this.m_tscMain.BottomToolStripPanel.SuspendLayout();
            this.m_tscMain.ContentPanel.SuspendLayout();
            this.m_tscMain.TopToolStripPanel.SuspendLayout();
            this.m_tscMain.SuspendLayout();
            this.m_ssMain.SuspendLayout();
            this.m_pnlCopied.SuspendLayout();
            this.m_pnlRipper.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_tsMain.SuspendLayout();
            this.m_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.Controls.Add(this.m_tscMain);
            // 
            // m_tscMain
            // 
            resources.ApplyResources(this.m_tscMain, "m_tscMain");
            // 
            // m_tscMain.BottomToolStripPanel
            // 
            resources.ApplyResources(this.m_tscMain.BottomToolStripPanel, "m_tscMain.BottomToolStripPanel");
            this.m_tscMain.BottomToolStripPanel.Controls.Add(this.m_ssMain);
            // 
            // m_tscMain.ContentPanel
            // 
            resources.ApplyResources(this.m_tscMain.ContentPanel, "m_tscMain.ContentPanel");
            this.m_tscMain.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.m_tscMain.ContentPanel.Controls.Add(this.m_splListViews);
            this.m_tscMain.ContentPanel.Controls.Add(this.m_pnlCopied);
            this.m_tscMain.ContentPanel.Controls.Add(this.m_pnlRipper);
            this.m_tscMain.ContentPanel.Controls.Add(this.m_pnlAction);
            // 
            // m_tscMain.LeftToolStripPanel
            // 
            resources.ApplyResources(this.m_tscMain.LeftToolStripPanel, "m_tscMain.LeftToolStripPanel");
            this.m_tscMain.Name = "m_tscMain";
            // 
            // m_tscMain.RightToolStripPanel
            // 
            resources.ApplyResources(this.m_tscMain.RightToolStripPanel, "m_tscMain.RightToolStripPanel");
            // 
            // m_tscMain.TopToolStripPanel
            // 
            resources.ApplyResources(this.m_tscMain.TopToolStripPanel, "m_tscMain.TopToolStripPanel");
            this.m_tscMain.TopToolStripPanel.Controls.Add(this.m_tsMain);
            // 
            // m_ssMain
            // 
            resources.ApplyResources(this.m_ssMain, "m_ssMain");
            this.m_ssMain.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            // m_splListViews
            // 
            resources.ApplyResources(this.m_splListViews, "m_splListViews");
            this.m_splListViews.BackColor = System.Drawing.Color.Transparent;
            this.m_splListViews.Name = "m_splListViews";
            this.m_splListViews.TabStop = false;
            // 
            // m_pnlCopied
            // 
            resources.ApplyResources(this.m_pnlCopied, "m_pnlCopied");
            this.m_pnlCopied.AssociatedSplitter = null;
            this.m_pnlCopied.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlCopied.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlCopied.CaptionHeight = 27;
            this.m_pnlCopied.Controls.Add(this.m_lstvCopied);
            this.m_pnlCopied.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlCopied.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlCopied.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlCopied.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlCopied.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlCopied.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlCopied.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlCopied.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlCopied.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlCopied.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlCopied.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlCopied.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlCopied.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlCopied.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlCopied.Image = null;
            this.m_pnlCopied.Name = "m_pnlCopied";
            this.m_pnlCopied.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.m_pnlCopied.ToolTipTextCloseIcon = null;
            this.m_pnlCopied.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlCopied.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_lstvCopied
            // 
            resources.ApplyResources(this.m_lstvCopied, "m_lstvCopied");
            this.m_lstvCopied.AllowColumnReorder = true;
            this.m_lstvCopied.AllowDrop = true;
            this.m_lstvCopied.AllowSelectAllItems = true;
            this.m_lstvCopied.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvCopied.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstvCopied.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnFileFullName,
            this.m_clmnTrackNumber,
            this.m_clmnTitle,
            this.m_clmnDuration});
            this.m_lstvCopied.DragDropOnlyAsEvent = true;
            this.m_lstvCopied.FitLargestItem = true;
            this.m_lstvCopied.HideSelection = false;
            this.m_lstvCopied.Name = "m_lstvCopied";
            this.m_lstvCopied.UseCompatibleStateImageBehavior = false;
            this.m_lstvCopied.View = System.Windows.Forms.View.Details;
            this.m_lstvCopied.SubItemEndEditing += new System.EventHandler<BSE.Windows.Forms.SubItemEndEditingEventArgs>(this.m_lstvCopied_SubItemEndEditing);
            this.m_lstvCopied.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lstvCopied_DragDrop);
            this.m_lstvCopied.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lstvCopied_KeyUp);
            // 
            // m_clmnFileFullName
            // 
            this.m_clmnFileFullName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnFileFullName, "m_clmnFileFullName");
            // 
            // m_clmnTrackNumber
            // 
            this.m_clmnTrackNumber.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnTrackNumber.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            resources.ApplyResources(this.m_clmnTrackNumber, "m_clmnTrackNumber");
            // 
            // m_clmnTitle
            // 
            this.m_clmnTitle.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_clmnTitle.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnTitle, "m_clmnTitle");
            // 
            // m_clmnDuration
            // 
            this.m_clmnDuration.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Dates;
            resources.ApplyResources(this.m_clmnDuration, "m_clmnDuration");
            // 
            // m_pnlRipper
            // 
            resources.ApplyResources(this.m_pnlRipper, "m_pnlRipper");
            this.m_pnlRipper.AssociatedSplitter = null;
            this.m_pnlRipper.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlRipper.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlRipper.CaptionHeight = 27;
            this.m_pnlRipper.Controls.Add(this.m_lstvMain);
            this.m_pnlRipper.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlRipper.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlRipper.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlRipper.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlRipper.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlRipper.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlRipper.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlRipper.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlRipper.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlRipper.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlRipper.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlRipper.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlRipper.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlRipper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlRipper.Image = null;
            this.m_pnlRipper.Name = "m_pnlRipper";
            this.m_pnlRipper.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.m_pnlRipper.ToolTipTextCloseIcon = null;
            this.m_pnlRipper.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlRipper.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_lstvMain
            // 
            resources.ApplyResources(this.m_lstvMain, "m_lstvMain");
            this.m_lstvMain.AllowColumnReorder = true;
            this.m_lstvMain.AllowDrag = true;
            this.m_lstvMain.AllowSelectAllItems = true;
            this.m_lstvMain.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstvMain.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_lstvcolumnTracks,
            this.m_lstvcolumnSize,
            this.m_lstvcolumnType,
            this.m_lstvcolumnDuration,
            this.m_lstvcolumnOutName});
            this.m_lstvMain.DragDropEffects = System.Windows.Forms.DragDropEffects.Copy;
            this.m_lstvMain.FitLargestItem = true;
            this.m_lstvMain.HideSelection = false;
            this.m_lstvMain.Name = "m_lstvMain";
            this.m_lstvMain.UseCompatibleStateImageBehavior = false;
            this.m_lstvMain.View = System.Windows.Forms.View.Details;
            this.m_lstvMain.SubItemEndEditing += new System.EventHandler<BSE.Windows.Forms.SubItemEndEditingEventArgs>(this.m_lstvMain_SubItemEndEditing);
            this.m_lstvMain.SelectedIndexChanged += new System.EventHandler(this.m_lstvMain_SelectedIndexChanged);
            // 
            // m_lstvcolumnTracks
            // 
            this.m_lstvcolumnTracks.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_lstvcolumnTracks.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_lstvcolumnTracks, "m_lstvcolumnTracks");
            // 
            // m_lstvcolumnSize
            // 
            this.m_lstvcolumnSize.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            resources.ApplyResources(this.m_lstvcolumnSize, "m_lstvcolumnSize");
            // 
            // m_lstvcolumnType
            // 
            this.m_lstvcolumnType.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_lstvcolumnType, "m_lstvcolumnType");
            // 
            // m_lstvcolumnDuration
            // 
            this.m_lstvcolumnDuration.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Dates;
            resources.ApplyResources(this.m_lstvcolumnDuration, "m_lstvcolumnDuration");
            // 
            // m_lstvcolumnOutName
            // 
            this.m_lstvcolumnOutName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_lstvcolumnOutName, "m_lstvcolumnOutName");
            // 
            // m_pnlAction
            // 
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Controls.Add(this.m_btnOK);
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnOK
            // 
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_tsMain
            // 
            resources.ApplyResources(this.m_tsMain, "m_tsMain");
            this.m_tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_tsMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnBearbeiten_OpenDrive,
            this.m_cboCDDrives,
            this.m_btnBrowseFreeDb,
            this.m_lblStartIndex,
            this.m_txtStartIndex});
            this.m_tsMain.Name = "m_tsMain";
            this.m_tsMain.Stretch = true;
            // 
            // m_btnBearbeiten_OpenDrive
            // 
            resources.ApplyResources(this.m_btnBearbeiten_OpenDrive, "m_btnBearbeiten_OpenDrive");
            this.m_btnBearbeiten_OpenDrive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnBearbeiten_OpenDrive.Image = global::BSE.Platten.Ripper.Properties.Resources.media_eject;
            this.m_btnBearbeiten_OpenDrive.Name = "m_btnBearbeiten_OpenDrive";
            this.m_btnBearbeiten_OpenDrive.Click += new System.EventHandler(this.m_mnuBearbeiten_OpenDrive_Click);
            // 
            // m_cboCDDrives
            // 
            resources.ApplyResources(this.m_cboCDDrives, "m_cboCDDrives");
            this.m_cboCDDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCDDrives.Name = "m_cboCDDrives";
            this.m_cboCDDrives.SelectedIndexChanged += new System.EventHandler(this.m_cboCDDrives_SelectedIndexChanged);
            // 
            // m_btnBrowseFreeDb
            // 
            resources.ApplyResources(this.m_btnBrowseFreeDb, "m_btnBrowseFreeDb");
            this.m_btnBrowseFreeDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_btnBrowseFreeDb.Name = "m_btnBrowseFreeDb";
            this.m_btnBrowseFreeDb.Click += new System.EventHandler(this.m_btnBrowseFreeDb_Click);
            // 
            // m_lblStartIndex
            // 
            resources.ApplyResources(this.m_lblStartIndex, "m_lblStartIndex");
            this.m_lblStartIndex.Name = "m_lblStartIndex";
            // 
            // m_txtStartIndex
            // 
            resources.ApplyResources(this.m_txtStartIndex, "m_txtStartIndex");
            this.m_txtStartIndex.Name = "m_txtStartIndex";
            this.m_txtStartIndex.TextChanged += new System.EventHandler(this.m_txtStartIndex_TextChanged);
            // 
            // m_mainMenu
            // 
            resources.ApplyResources(this.m_mainMenu, "m_mainMenu");
            this.m_mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            this.m_mnuDatei_End});
            this.m_mnuDatei.Name = "m_mnuDatei";
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
            this.m_mnuBearbeiten_OpenDrive,
            this.m_mnuBearbeiten_Separator1,
            this.m_mnuBearbeiten_CopyTracks});
            this.m_mnuBearbeiten.Name = "m_mnuBearbeiten";
            // 
            // m_mnuBearbeiten_OpenDrive
            // 
            resources.ApplyResources(this.m_mnuBearbeiten_OpenDrive, "m_mnuBearbeiten_OpenDrive");
            this.m_mnuBearbeiten_OpenDrive.Image = global::BSE.Platten.Ripper.Properties.Resources.media_eject;
            this.m_mnuBearbeiten_OpenDrive.Name = "m_mnuBearbeiten_OpenDrive";
            this.m_mnuBearbeiten_OpenDrive.Click += new System.EventHandler(this.m_mnuBearbeiten_OpenDrive_Click);
            // 
            // m_mnuBearbeiten_Separator1
            // 
            resources.ApplyResources(this.m_mnuBearbeiten_Separator1, "m_mnuBearbeiten_Separator1");
            this.m_mnuBearbeiten_Separator1.Name = "m_mnuBearbeiten_Separator1";
            // 
            // m_mnuBearbeiten_CopyTracks
            // 
            resources.ApplyResources(this.m_mnuBearbeiten_CopyTracks, "m_mnuBearbeiten_CopyTracks");
            this.m_mnuBearbeiten_CopyTracks.Name = "m_mnuBearbeiten_CopyTracks";
            this.m_mnuBearbeiten_CopyTracks.Click += new System.EventHandler(this.m_mnuBearbeiten_CopyTracks_Click);
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
            this.m_mnuExtras_Optionen.Image = global::BSE.Platten.Ripper.Properties.Resources.gearwheel;
            this.m_mnuExtras_Optionen.Name = "m_mnuExtras_Optionen";
            this.m_mnuExtras_Optionen.Click += new System.EventHandler(this.m_mnuExtras_Optionen_Click);
            // 
            // m_configuration
            // 
            this.m_configuration.ApplicationSubDirectory = null;
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
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
            this.m_tscMain.BottomToolStripPanel.ResumeLayout(false);
            this.m_tscMain.BottomToolStripPanel.PerformLayout();
            this.m_tscMain.ContentPanel.ResumeLayout(false);
            this.m_tscMain.TopToolStripPanel.ResumeLayout(false);
            this.m_tscMain.TopToolStripPanel.PerformLayout();
            this.m_tscMain.ResumeLayout(false);
            this.m_tscMain.PerformLayout();
            this.m_ssMain.ResumeLayout(false);
            this.m_ssMain.PerformLayout();
            this.m_pnlCopied.ResumeLayout(false);
            this.m_pnlRipper.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlAction.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei_End;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten;
        private System.Windows.Forms.ToolStrip m_tsMain;
        private System.Windows.Forms.StatusStrip m_ssMain;
        private System.Windows.Forms.ToolStripContainer m_tscMain;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten_OpenDrive;
        private System.Windows.Forms.ToolStripSeparator m_mnuBearbeiten_Separator1;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten_CopyTracks;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExtras;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExtras_Optionen;
        private System.Windows.Forms.ToolStripButton m_btnBearbeiten_OpenDrive;
        private System.Windows.Forms.ToolStripComboBox m_cboCDDrives;
        private System.Windows.Forms.ToolStripButton m_btnBrowseFreeDb;
        private System.Windows.Forms.ToolStripLabel m_lblStartIndex;
        private System.Windows.Forms.ToolStripTextBox m_txtStartIndex;
        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private BSE.Windows.Forms.Splitter m_splListViews;
        private BSE.Windows.Forms.Panel m_pnlCopied;
        private BSE.Windows.Forms.Panel m_pnlRipper;
        private BSE.Windows.Forms.ListView m_lstvMain;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnTracks;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnSize;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnType;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnDuration;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnOutName;
        private BSE.Windows.Forms.ListView m_lstvCopied;
        private BSE.Windows.Forms.ColumnHeader m_clmnFileFullName;
        private BSE.Windows.Forms.ColumnHeader m_clmnTrackNumber;
        private BSE.Windows.Forms.ColumnHeader m_clmnTitle;
        private BSE.Windows.Forms.ColumnHeader m_clmnDuration;
        private BSE.Configuration.Configuration m_configuration;
        private BSE.Configuration.Configuration m_settings;
        private System.Windows.Forms.ToolStripStatusLabel m_lblStatus;
    }
}