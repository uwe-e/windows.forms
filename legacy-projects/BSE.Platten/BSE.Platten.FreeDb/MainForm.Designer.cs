namespace BSE.Platten.FreeDb
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
                if (this.m_cboCDDrives != null)
                {
                    this.m_cboCDDrives.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.m_ssMain = new System.Windows.Forms.StatusStrip();
            this.m_pnlMain = new BSE.Windows.Forms.Panel();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            this.m_lstvMain = new BSE.Windows.Forms.ListView();
            this.m_lstvcolumnTracks = new BSE.Windows.Forms.ColumnHeader();
            this.m_lstvcolumnLied = new BSE.Windows.Forms.ColumnHeader();
            this.m_lstvcolumnDuration = new BSE.Windows.Forms.ColumnHeader();
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_pnlTop = new System.Windows.Forms.Panel();
            this.m_txtYear = new System.Windows.Forms.TextBox();
            this.m_lblYear = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtGenre = new System.Windows.Forms.TextBox();
            this.m_lblGenre = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtAlbumName = new System.Windows.Forms.TextBox();
            this.m_lblAlbumName = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtArtistName = new System.Windows.Forms.TextBox();
            this.m_lblArtistName = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtMediaId = new System.Windows.Forms.TextBox();
            this.m_lblMediaId = new BSE.Platten.Common.UnchangeableLabel();
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
            this.m_settings = new BSE.Configuration.Configuration();
            this.ContentPanel.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.m_pnlMain.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_pnlTop.SuspendLayout();
            this.m_tsMain.SuspendLayout();
            this.m_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.toolStripContainer1);
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.m_ssMain);
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_pnlMain);
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.m_mainMenu);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.m_tsMain);
            // 
            // m_ssMain
            // 
            resources.ApplyResources(this.m_ssMain, "m_ssMain");
            this.m_ssMain.Name = "m_ssMain";
            this.m_ssMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            // 
            // m_pnlMain
            // 
            this.m_pnlMain.AssociatedSplitter = null;
            this.m_pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlMain.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlMain.CaptionHeight = 27;
            this.m_pnlMain.Controls.Add(this.m_pnlBase);
            this.m_pnlMain.Controls.Add(this.m_pnlAction);
            this.m_pnlMain.Controls.Add(this.m_pnlTop);
            this.m_pnlMain.CustomColors.BorderColor = System.Drawing.Color.Empty;
            this.m_pnlMain.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlMain.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlMain.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlMain.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlMain.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlMain.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlMain.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlMain.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlMain.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlMain.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlMain.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlMain.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_pnlMain, "m_pnlMain");
            this.m_pnlMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlMain.Image = null;
            this.m_pnlMain.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.m_pnlMain.MinimumSize = new System.Drawing.Size(27, 27);
            this.m_pnlMain.Name = "m_pnlMain";
            this.m_pnlMain.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.m_pnlMain.ShowTransparentBackground = false;
            this.m_pnlMain.ToolTipTextCloseIcon = null;
            this.m_pnlMain.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlMain.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_pnlBase
            // 
            this.m_pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBase.Controls.Add(this.m_lstvMain);
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // m_lstvMain
            // 
            this.m_lstvMain.AllowColumnReorder = true;
            this.m_lstvMain.AllowSelectAllItems = true;
            this.m_lstvMain.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lstvMain.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_lstvcolumnTracks,
            this.m_lstvcolumnLied,
            this.m_lstvcolumnDuration});
            resources.ApplyResources(this.m_lstvMain, "m_lstvMain");
            this.m_lstvMain.FitLargestItem = true;
            this.m_lstvMain.FullRowSelect = true;
            this.m_lstvMain.Name = "m_lstvMain";
            this.m_lstvMain.UseCompatibleStateImageBehavior = false;
            this.m_lstvMain.View = System.Windows.Forms.View.Details;
            this.m_lstvMain.SubItemEndEditing += new System.EventHandler<BSE.Windows.Forms.SubItemEndEditingEventArgs>(this.m_lstvMain_SubItemEndEditing);
            this.m_lstvMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lstvMain_KeyUp);
            // 
            // m_lstvcolumnTracks
            // 
            this.m_lstvcolumnTracks.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            resources.ApplyResources(this.m_lstvcolumnTracks, "m_lstvcolumnTracks");
            // 
            // m_lstvcolumnLied
            // 
            this.m_lstvcolumnLied.EmbeddedControlType = BSE.Windows.Forms.EmbeddedControlType.TextBox;
            this.m_lstvcolumnLied.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_lstvcolumnLied, "m_lstvcolumnLied");
            // 
            // m_lstvcolumnDuration
            // 
            this.m_lstvcolumnDuration.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Dates;
            resources.ApplyResources(this.m_lstvcolumnDuration, "m_lstvcolumnDuration");
            // 
            // m_pnlAction
            // 
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Controls.Add(this.m_btnOK);
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnCancel
            // 
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_btnOK
            // 
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_pnlTop
            // 
            this.m_pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlTop.Controls.Add(this.m_txtYear);
            this.m_pnlTop.Controls.Add(this.m_lblYear);
            this.m_pnlTop.Controls.Add(this.m_txtGenre);
            this.m_pnlTop.Controls.Add(this.m_lblGenre);
            this.m_pnlTop.Controls.Add(this.m_txtAlbumName);
            this.m_pnlTop.Controls.Add(this.m_lblAlbumName);
            this.m_pnlTop.Controls.Add(this.m_txtArtistName);
            this.m_pnlTop.Controls.Add(this.m_lblArtistName);
            this.m_pnlTop.Controls.Add(this.m_txtMediaId);
            this.m_pnlTop.Controls.Add(this.m_lblMediaId);
            resources.ApplyResources(this.m_pnlTop, "m_pnlTop");
            this.m_pnlTop.Name = "m_pnlTop";
            // 
            // m_txtYear
            // 
            resources.ApplyResources(this.m_txtYear, "m_txtYear");
            this.m_txtYear.Name = "m_txtYear";
            this.m_txtYear.ReadOnly = true;
            // 
            // m_lblYear
            // 
            resources.ApplyResources(this.m_lblYear, "m_lblYear");
            this.m_lblYear.Name = "m_lblYear";
            // 
            // m_txtGenre
            // 
            resources.ApplyResources(this.m_txtGenre, "m_txtGenre");
            this.m_txtGenre.Name = "m_txtGenre";
            this.m_txtGenre.ReadOnly = true;
            // 
            // m_lblGenre
            // 
            resources.ApplyResources(this.m_lblGenre, "m_lblGenre");
            this.m_lblGenre.Name = "m_lblGenre";
            // 
            // m_txtAlbumName
            // 
            resources.ApplyResources(this.m_txtAlbumName, "m_txtAlbumName");
            this.m_txtAlbumName.Name = "m_txtAlbumName";
            this.m_txtAlbumName.ReadOnly = true;
            // 
            // m_lblAlbumName
            // 
            resources.ApplyResources(this.m_lblAlbumName, "m_lblAlbumName");
            this.m_lblAlbumName.Name = "m_lblAlbumName";
            // 
            // m_txtArtistName
            // 
            resources.ApplyResources(this.m_txtArtistName, "m_txtArtistName");
            this.m_txtArtistName.Name = "m_txtArtistName";
            this.m_txtArtistName.ReadOnly = true;
            // 
            // m_lblArtistName
            // 
            resources.ApplyResources(this.m_lblArtistName, "m_lblArtistName");
            this.m_lblArtistName.Name = "m_lblArtistName";
            // 
            // m_txtMediaId
            // 
            resources.ApplyResources(this.m_txtMediaId, "m_txtMediaId");
            this.m_txtMediaId.Name = "m_txtMediaId";
            this.m_txtMediaId.ReadOnly = true;
            // 
            // m_lblMediaId
            // 
            resources.ApplyResources(this.m_lblMediaId, "m_lblMediaId");
            this.m_lblMediaId.Name = "m_lblMediaId";
            // 
            // m_tsMain
            // 
            resources.ApplyResources(this.m_tsMain, "m_tsMain");
            this.m_tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
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
            this.m_btnBearbeiten_OpenDrive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnBearbeiten_OpenDrive.Image = global::BSE.Platten.FreeDb.Properties.Resources.OpenCD;
            resources.ApplyResources(this.m_btnBearbeiten_OpenDrive, "m_btnBearbeiten_OpenDrive");
            this.m_btnBearbeiten_OpenDrive.Name = "m_btnBearbeiten_OpenDrive";
            this.m_btnBearbeiten_OpenDrive.Click += new System.EventHandler(this.m_btnBearbeiten_OpenDrive_Click);
            // 
            // m_cboCDDrives
            // 
            this.m_cboCDDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCDDrives.Name = "m_cboCDDrives";
            resources.ApplyResources(this.m_cboCDDrives, "m_cboCDDrives");
            this.m_cboCDDrives.SelectedIndexChanged += new System.EventHandler(this.m_cboCDDrives_SelectedIndexChanged);
            // 
            // m_btnBrowseFreeDb
            // 
            this.m_btnBrowseFreeDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.m_btnBrowseFreeDb, "m_btnBrowseFreeDb");
            this.m_btnBrowseFreeDb.Name = "m_btnBrowseFreeDb";
            this.m_btnBrowseFreeDb.Click += new System.EventHandler(this.m_btnBrowseFreeDb_Click);
            // 
            // m_lblStartIndex
            // 
            this.m_lblStartIndex.Name = "m_lblStartIndex";
            resources.ApplyResources(this.m_lblStartIndex, "m_lblStartIndex");
            // 
            // m_txtStartIndex
            // 
            this.m_txtStartIndex.Name = "m_txtStartIndex";
            resources.ApplyResources(this.m_txtStartIndex, "m_txtStartIndex");
            this.m_txtStartIndex.TextChanged += new System.EventHandler(this.m_txtStartIndex_TextChanged);
            // 
            // m_mainMenu
            // 
            resources.ApplyResources(this.m_mainMenu, "m_mainMenu");
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatei,
            this.m_mnuBearbeiten});
            this.m_mainMenu.Name = "m_mainMenu";
            // 
            // m_mnuDatei
            // 
            this.m_mnuDatei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatei_End});
            this.m_mnuDatei.Name = "m_mnuDatei";
            resources.ApplyResources(this.m_mnuDatei, "m_mnuDatei");
            // 
            // m_mnuDatei_End
            // 
            this.m_mnuDatei_End.Name = "m_mnuDatei_End";
            resources.ApplyResources(this.m_mnuDatei_End, "m_mnuDatei_End");
            this.m_mnuDatei_End.Click += new System.EventHandler(this.m_mnuDatei_End_Click);
            // 
            // m_mnuBearbeiten
            // 
            this.m_mnuBearbeiten.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuBearbeiten_OpenDrive});
            this.m_mnuBearbeiten.Name = "m_mnuBearbeiten";
            resources.ApplyResources(this.m_mnuBearbeiten, "m_mnuBearbeiten");
            // 
            // m_mnuBearbeiten_OpenDrive
            // 
            this.m_mnuBearbeiten_OpenDrive.Image = global::BSE.Platten.FreeDb.Properties.Resources.OpenCD;
            this.m_mnuBearbeiten_OpenDrive.Name = "m_mnuBearbeiten_OpenDrive";
            resources.ApplyResources(this.m_mnuBearbeiten_OpenDrive, "m_mnuBearbeiten_OpenDrive");
            this.m_mnuBearbeiten_OpenDrive.Click += new System.EventHandler(this.m_btnBearbeiten_OpenDrive_Click);
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
            // 
            // CMain
            // 
            this.AcceptButton = this.m_btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.MainMenuStrip = this.m_mainMenu;
            this.Name = "CMain";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CMain_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CMain_FormClosing);
            this.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.m_pnlMain.ResumeLayout(false);
            this.m_pnlBase.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlTop.ResumeLayout(false);
            this.m_pnlTop.PerformLayout();
            this.m_tsMain.ResumeLayout(false);
            this.m_tsMain.PerformLayout();
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei_End;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten;
        private System.Windows.Forms.ToolStripMenuItem m_mnuBearbeiten_OpenDrive;
        private System.Windows.Forms.ToolStrip m_tsMain;
        private System.Windows.Forms.ToolStripComboBox m_cboCDDrives;
        private System.Windows.Forms.ToolStripButton m_btnBrowseFreeDb;
        private System.Windows.Forms.ToolStripLabel m_lblStartIndex;
        private System.Windows.Forms.ToolStripTextBox m_txtStartIndex;
        private System.Windows.Forms.StatusStrip m_ssMain;
        private BSE.Windows.Forms.Panel m_pnlMain;
        private System.Windows.Forms.Panel m_pnlBase;
        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Panel m_pnlTop;
        private BSE.Windows.Forms.ListView m_lstvMain;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private BSE.Platten.Common.UnchangeableLabel m_lblMediaId;
        private System.Windows.Forms.TextBox m_txtMediaId;
        private System.Windows.Forms.TextBox m_txtYear;
        private BSE.Platten.Common.UnchangeableLabel m_lblYear;
        private System.Windows.Forms.TextBox m_txtGenre;
        private BSE.Platten.Common.UnchangeableLabel m_lblGenre;
        private System.Windows.Forms.TextBox m_txtAlbumName;
        private BSE.Platten.Common.UnchangeableLabel m_lblAlbumName;
        private System.Windows.Forms.TextBox m_txtArtistName;
        private BSE.Platten.Common.UnchangeableLabel m_lblArtistName;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnTracks;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnLied;
        private BSE.Windows.Forms.ColumnHeader m_lstvcolumnDuration;
        private System.Windows.Forms.ToolStripButton m_btnBearbeiten_OpenDrive;
        private BSE.Configuration.Configuration m_settings;
    }
}