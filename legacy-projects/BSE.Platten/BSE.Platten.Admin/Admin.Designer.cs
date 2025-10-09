namespace BSE.Platten.Admin
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_msAdmin = new System.Windows.Forms.MenuStrip();
            this.m_mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuTools_Bildimport = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuTools_Bildexport = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuTools_Sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuTools_RipCD = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuToolsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuTools_AudioImport = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuToolsSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuTools_WriteTags = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExtras_Optionen = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pnlLeft = new System.Windows.Forms.Panel();
            this.m_pnlCovers = new BSE.Windows.Forms.Panel();
            this.m_Covers = new BSE.Platten.Covers.CoverPanel();
            this.m_sptAdminTop = new BSE.Windows.Forms.Splitter();
            this.m_sptLft = new BSE.Windows.Forms.Splitter();
            this.m_pnlAlbum = new BSE.Windows.Forms.Panel();
            this.m_pnlContent = new System.Windows.Forms.Panel();
            this.m_picCover = new System.Windows.Forms.PictureBox();
            this.m_lblTitelId = new BSE.Platten.Common.UnchangeableLabel();
            this.m_tbcAlbum = new System.Windows.Forms.TabControl();
            this.m_tbpLieder = new System.Windows.Forms.TabPage();
            this.m_grdLieder = new System.Windows.Forms.DataGridView();
            this.m_dgvColumnLiedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnTitelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnTrack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnLied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnDauer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnLiedpfad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvColumnTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_txtTitelId = new System.Windows.Forms.TextBox();
            this.m_txtErschDatum = new System.Windows.Forms.TextBox();
            this.m_lblInterpreten = new BSE.Platten.Common.UnchangeableLabel();
            this.m_lblInterpret = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtInterpret = new System.Windows.Forms.TextBox();
            this.m_vsbPaging = new System.Windows.Forms.VScrollBar();
            this.m_cboInterpreten = new System.Windows.Forms.ComboBox();
            this.m_cboGenre = new System.Windows.Forms.ComboBox();
            this.m_lblErschDatum = new BSE.Platten.Common.UnchangeableLabel();
            this.m_lblTitel = new BSE.Platten.Common.UnchangeableLabel();
            this.m_cboMedium = new System.Windows.Forms.ComboBox();
            this.m_txtTitel = new System.Windows.Forms.TextBox();
            this.m_lblGenre = new BSE.Platten.Common.UnchangeableLabel();
            this.m_lblMedium = new BSE.Platten.Common.UnchangeableLabel();
            this.m_lblMutiert = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtMutationDurch = new System.Windows.Forms.TextBox();
            this.m_btnEditImage = new System.Windows.Forms.Button();
            this.m_btnShowInterprets = new System.Windows.Forms.Button();
            this.m_txtMutationDatum = new System.Windows.Forms.TextBox();
            this.m_txtErstDurch = new System.Windows.Forms.TextBox();
            this.m_txtErstDatum = new System.Windows.Forms.TextBox();
            this.m_lblErstellt = new BSE.Platten.Common.UnchangeableLabel();
            this.m_dataSetAlbum = new BSE.Platten.BO.CDataSetAlbum();
            this.m_configuration = new BSE.Configuration.Configuration();
            this.m_tsTools = new System.Windows.Forms.ToolStrip();
            this.m_btnToolsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnTools_Bildimport = new System.Windows.Forms.ToolStripButton();
            this.m_btnTools_Bildexport = new System.Windows.Forms.ToolStripButton();
            this.m_btnToolsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnTools_RipCD = new System.Windows.Forms.ToolStripButton();
            this.m_btnTools_AudioImport = new System.Windows.Forms.ToolStripButton();
            this.m_btnTools_WriteTags = new System.Windows.Forms.ToolStripButton();
            this.m_btnToolsSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.diskInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemStatisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_sfdlgPictureExport = new System.Windows.Forms.SaveFileDialog();
            this.m_ofdlgPictureImport = new System.Windows.Forms.OpenFileDialog();
            this.m_cmnuMusic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_settings = new BSE.Configuration.Configuration();
            this.m_tltAdmin = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).BeginInit();
            this.m_tspTop.SuspendLayout();
            this.m_toolstripContentPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.m_msAdmin.SuspendLayout();
            this.m_pnlLeft.SuspendLayout();
            this.m_pnlCovers.SuspendLayout();
            this.m_pnlAlbum.SuspendLayout();
            this.m_pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCover)).BeginInit();
            this.m_tbcAlbum.SuspendLayout();
            this.m_tbpLieder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grdLieder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetAlbum)).BeginInit();
            this.m_tsTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_bindingSource
            // 
            this.m_bindingSource.DataMember = "Album";
            this.m_bindingSource.DataSource = this.m_dataSetAlbum;
            // 
            // m_tspRight
            // 
            resources.ApplyResources(this.m_tspRight, "m_tspRight");
            // 
            // m_tspTop
            // 
            this.m_tspTop.Controls.Add(this.m_tsTools);
            resources.ApplyResources(this.m_tspTop, "m_tspTop");
            this.m_tspTop.Controls.SetChildIndex(this.m_tsTools, 0);
            // 
            // m_tspBottom
            // 
            resources.ApplyResources(this.m_tspBottom, "m_tspBottom");
            // 
            // m_toolstripContentPanel
            // 
            this.m_toolstripContentPanel.Controls.Add(this.m_pnlAlbum);
            this.m_toolstripContentPanel.Controls.Add(this.m_sptLft);
            this.m_toolstripContentPanel.Controls.Add(this.m_pnlLeft);
            resources.ApplyResources(this.m_toolstripContentPanel, "m_toolstripContentPanel");
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // m_msAdmin
            // 
            resources.ApplyResources(this.m_msAdmin, "m_msAdmin");
            this.m_msAdmin.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_msAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuTools,
            this.m_mnuExtras});
            this.m_msAdmin.Name = "m_msAdmin";
            // 
            // m_mnuTools
            // 
            this.m_mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuTools_Bildimport,
            this.m_mnuTools_Bildexport,
            this.m_mnuTools_Sep1,
            this.m_mnuTools_RipCD,
            this.m_mnuToolsSep2,
            this.m_mnuTools_AudioImport,
            this.m_mnuToolsSep3,
            this.m_mnuTools_WriteTags});
            this.m_mnuTools.Name = "m_mnuTools";
            resources.ApplyResources(this.m_mnuTools, "m_mnuTools");
            // 
            // m_mnuTools_Bildimport
            // 
            this.m_mnuTools_Bildimport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_into;
            this.m_mnuTools_Bildimport.Name = "m_mnuTools_Bildimport";
            resources.ApplyResources(this.m_mnuTools_Bildimport, "m_mnuTools_Bildimport");
            this.m_mnuTools_Bildimport.Click += new System.EventHandler(this.m_btnTools_Bildimport_Click);
            // 
            // m_mnuTools_Bildexport
            // 
            this.m_mnuTools_Bildexport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_out;
            this.m_mnuTools_Bildexport.Name = "m_mnuTools_Bildexport";
            resources.ApplyResources(this.m_mnuTools_Bildexport, "m_mnuTools_Bildexport");
            this.m_mnuTools_Bildexport.Click += new System.EventHandler(this.m_btnTools_Bildexport_Click);
            // 
            // m_mnuTools_Sep1
            // 
            this.m_mnuTools_Sep1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_mnuTools_Sep1.Name = "m_mnuTools_Sep1";
            resources.ApplyResources(this.m_mnuTools_Sep1, "m_mnuTools_Sep1");
            // 
            // m_mnuTools_RipCD
            // 
            this.m_mnuTools_RipCD.Image = global::BSE.Platten.Admin.Properties.Resources.cd_music;
            this.m_mnuTools_RipCD.Name = "m_mnuTools_RipCD";
            resources.ApplyResources(this.m_mnuTools_RipCD, "m_mnuTools_RipCD");
            this.m_mnuTools_RipCD.Click += new System.EventHandler(this.m_btnTools_RipCD_Click);
            // 
            // m_mnuToolsSep2
            // 
            this.m_mnuToolsSep2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_mnuToolsSep2.Name = "m_mnuToolsSep2";
            resources.ApplyResources(this.m_mnuToolsSep2, "m_mnuToolsSep2");
            // 
            // m_mnuTools_AudioImport
            // 
            this.m_mnuTools_AudioImport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_music;
            this.m_mnuTools_AudioImport.Name = "m_mnuTools_AudioImport";
            resources.ApplyResources(this.m_mnuTools_AudioImport, "m_mnuTools_AudioImport");
            this.m_mnuTools_AudioImport.Click += new System.EventHandler(this.m_btnTools_AudioImport_Click);
            // 
            // m_mnuToolsSep3
            // 
            this.m_mnuToolsSep3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_mnuToolsSep3.Name = "m_mnuToolsSep3";
            resources.ApplyResources(this.m_mnuToolsSep3, "m_mnuToolsSep3");
            // 
            // m_mnuTools_WriteTags
            // 
            this.m_mnuTools_WriteTags.Image = global::BSE.Platten.Admin.Properties.Resources.tag;
            this.m_mnuTools_WriteTags.Name = "m_mnuTools_WriteTags";
            resources.ApplyResources(this.m_mnuTools_WriteTags, "m_mnuTools_WriteTags");
            this.m_mnuTools_WriteTags.Click += new System.EventHandler(this.m_btnTools_WriteTags_Click);
            // 
            // m_mnuExtras
            // 
            this.m_mnuExtras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuExtras_Optionen});
            this.m_mnuExtras.Name = "m_mnuExtras";
            resources.ApplyResources(this.m_mnuExtras, "m_mnuExtras");
            // 
            // m_mnuExtras_Optionen
            // 
            this.m_mnuExtras_Optionen.Image = global::BSE.Platten.Admin.Properties.Resources.gearwheel;
            this.m_mnuExtras_Optionen.Name = "m_mnuExtras_Optionen";
            resources.ApplyResources(this.m_mnuExtras_Optionen, "m_mnuExtras_Optionen");
            this.m_mnuExtras_Optionen.Click += new System.EventHandler(this.m_mnuExtras_Optionen_Click);
            // 
            // m_pnlLeft
            // 
            this.m_pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlLeft.Controls.Add(this.m_pnlCovers);
            this.m_pnlLeft.Controls.Add(this.m_sptAdminTop);
            resources.ApplyResources(this.m_pnlLeft, "m_pnlLeft");
            this.m_pnlLeft.Name = "m_pnlLeft";
            // 
            // m_pnlCovers
            // 
            this.m_pnlCovers.AssociatedSplitter = null;
            this.m_pnlCovers.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlCovers.CaptionFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlCovers.CaptionHeight = 27;
            this.m_pnlCovers.Controls.Add(this.m_Covers);
            this.m_pnlCovers.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlCovers.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlCovers.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlCovers.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlCovers.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlCovers.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlCovers.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlCovers.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlCovers.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlCovers.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlCovers.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlCovers.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlCovers.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_pnlCovers, "m_pnlCovers");
            this.m_pnlCovers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlCovers.Image = null;
            this.m_pnlCovers.Name = "m_pnlCovers";
            this.m_pnlCovers.ShowTransparentBackground = false;
            this.m_pnlCovers.ToolTipTextCloseIcon = null;
            this.m_pnlCovers.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlCovers.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_Covers
            // 
            this.m_Covers.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_Covers, "m_Covers");
            this.m_Covers.Name = "m_Covers";
            this.m_Covers.CoverBoxClick += new System.EventHandler<BSE.Platten.Covers.CoverBoxClickEventArgs>(this.m_Covers_CoverClick);
            // 
            // m_sptAdminTop
            // 
            this.m_sptAdminTop.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_sptAdminTop, "m_sptAdminTop");
            this.m_sptAdminTop.Name = "m_sptAdminTop";
            this.m_sptAdminTop.TabStop = false;
            // 
            // m_sptLft
            // 
            this.m_sptLft.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_sptLft, "m_sptLft");
            this.m_sptLft.Name = "m_sptLft";
            this.m_sptLft.TabStop = false;
            // 
            // m_pnlAlbum
            // 
            this.m_pnlAlbum.AssociatedSplitter = null;
            this.m_pnlAlbum.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAlbum.CaptionFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlAlbum.CaptionHeight = 27;
            this.m_pnlAlbum.Controls.Add(this.m_pnlContent);
            this.m_pnlAlbum.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlAlbum.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlAlbum.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlAlbum.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlAlbum.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlAlbum.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlAlbum.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlAlbum.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlAlbum.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlAlbum.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlAlbum.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlAlbum.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlAlbum.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_pnlAlbum, "m_pnlAlbum");
            this.m_pnlAlbum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlAlbum.Image = null;
            this.m_pnlAlbum.Name = "m_pnlAlbum";
            this.m_pnlAlbum.ShowTransparentBackground = false;
            this.m_pnlAlbum.ToolTipTextCloseIcon = null;
            this.m_pnlAlbum.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlAlbum.ToolTipTextExpandIconPanelExpanded = null;
            this.m_pnlAlbum.Resize += new System.EventHandler(this.PanelAlbumResize);
            // 
            // m_pnlContent
            // 
            this.m_pnlContent.Controls.Add(this.m_picCover);
            this.m_pnlContent.Controls.Add(this.m_lblTitelId);
            this.m_pnlContent.Controls.Add(this.m_tbcAlbum);
            this.m_pnlContent.Controls.Add(this.m_txtTitelId);
            this.m_pnlContent.Controls.Add(this.m_txtErschDatum);
            this.m_pnlContent.Controls.Add(this.m_lblInterpreten);
            this.m_pnlContent.Controls.Add(this.m_lblInterpret);
            this.m_pnlContent.Controls.Add(this.m_txtInterpret);
            this.m_pnlContent.Controls.Add(this.m_vsbPaging);
            this.m_pnlContent.Controls.Add(this.m_cboInterpreten);
            this.m_pnlContent.Controls.Add(this.m_cboGenre);
            this.m_pnlContent.Controls.Add(this.m_lblErschDatum);
            this.m_pnlContent.Controls.Add(this.m_lblTitel);
            this.m_pnlContent.Controls.Add(this.m_cboMedium);
            this.m_pnlContent.Controls.Add(this.m_txtTitel);
            this.m_pnlContent.Controls.Add(this.m_lblGenre);
            this.m_pnlContent.Controls.Add(this.m_lblMedium);
            this.m_pnlContent.Controls.Add(this.m_lblMutiert);
            this.m_pnlContent.Controls.Add(this.m_txtMutationDurch);
            this.m_pnlContent.Controls.Add(this.m_btnEditImage);
            this.m_pnlContent.Controls.Add(this.m_btnShowInterprets);
            this.m_pnlContent.Controls.Add(this.m_txtMutationDatum);
            this.m_pnlContent.Controls.Add(this.m_txtErstDurch);
            this.m_pnlContent.Controls.Add(this.m_txtErstDatum);
            this.m_pnlContent.Controls.Add(this.m_lblErstellt);
            resources.ApplyResources(this.m_pnlContent, "m_pnlContent");
            this.m_pnlContent.Name = "m_pnlContent";
            // 
            // m_picCover
            // 
            resources.ApplyResources(this.m_picCover, "m_picCover");
            this.m_picCover.BackColor = System.Drawing.Color.Transparent;
            this.m_picCover.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.m_bindingSource, "Cover", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.m_picCover.Name = "m_picCover";
            this.m_picCover.TabStop = false;
            // 
            // m_lblTitelId
            // 
            resources.ApplyResources(this.m_lblTitelId, "m_lblTitelId");
            this.m_lblTitelId.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTitelId.Name = "m_lblTitelId";
            // 
            // m_tbcAlbum
            // 
            resources.ApplyResources(this.m_tbcAlbum, "m_tbcAlbum");
            this.m_tbcAlbum.Controls.Add(this.m_tbpLieder);
            this.m_tbcAlbum.Name = "m_tbcAlbum";
            this.m_tbcAlbum.SelectedIndex = 0;
            // 
            // m_tbpLieder
            // 
            this.m_tbpLieder.Controls.Add(this.m_grdLieder);
            resources.ApplyResources(this.m_tbpLieder, "m_tbpLieder");
            this.m_tbpLieder.Name = "m_tbpLieder";
            this.m_tbpLieder.UseVisualStyleBackColor = true;
            // 
            // m_grdLieder
            // 
            this.m_grdLieder.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.m_grdLieder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_grdLieder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_grdLieder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_grdLieder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grdLieder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_dgvColumnLiedID,
            this.m_dgvColumnTitelId,
            this.m_dgvColumnTrack,
            this.m_dgvColumnLied,
            this.m_dgvColumnDauer,
            this.m_dgvColumnLiedpfad,
            this.m_dgvColumnGuid,
            this.m_dgvColumnTimestamp});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_grdLieder.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.m_grdLieder, "m_grdLieder");
            this.m_grdLieder.GridColor = System.Drawing.SystemColors.Control;
            this.m_grdLieder.Name = "m_grdLieder";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_grdLieder.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.m_grdLieder.RowTemplate.Height = 21;
            this.m_grdLieder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridLiederCellEndEdit);
            this.m_grdLieder.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridLiederCellFormatting);
            this.m_grdLieder.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridLiederDataError);
            this.m_grdLieder.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridLiederRowHeaderMouseDoubleClick);
            this.m_grdLieder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridLiederKeyDown);
            // 
            // m_dgvColumnLiedID
            // 
            this.m_dgvColumnLiedID.DataPropertyName = "LiedID";
            resources.ApplyResources(this.m_dgvColumnLiedID, "m_dgvColumnLiedID");
            this.m_dgvColumnLiedID.Name = "m_dgvColumnLiedID";
            // 
            // m_dgvColumnTitelId
            // 
            this.m_dgvColumnTitelId.DataPropertyName = "TitelId";
            resources.ApplyResources(this.m_dgvColumnTitelId, "m_dgvColumnTitelId");
            this.m_dgvColumnTitelId.Name = "m_dgvColumnTitelId";
            // 
            // m_dgvColumnTrack
            // 
            this.m_dgvColumnTrack.DataPropertyName = "Track";
            resources.ApplyResources(this.m_dgvColumnTrack, "m_dgvColumnTrack");
            this.m_dgvColumnTrack.Name = "m_dgvColumnTrack";
            // 
            // m_dgvColumnLied
            // 
            this.m_dgvColumnLied.DataPropertyName = "Lied";
            resources.ApplyResources(this.m_dgvColumnLied, "m_dgvColumnLied");
            this.m_dgvColumnLied.Name = "m_dgvColumnLied";
            // 
            // m_dgvColumnDauer
            // 
            this.m_dgvColumnDauer.DataPropertyName = "Dauer";
            dataGridViewCellStyle3.Format = "T";
            dataGridViewCellStyle3.NullValue = null;
            this.m_dgvColumnDauer.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.m_dgvColumnDauer, "m_dgvColumnDauer");
            this.m_dgvColumnDauer.Name = "m_dgvColumnDauer";
            // 
            // m_dgvColumnLiedpfad
            // 
            this.m_dgvColumnLiedpfad.DataPropertyName = "Liedpfad";
            resources.ApplyResources(this.m_dgvColumnLiedpfad, "m_dgvColumnLiedpfad");
            this.m_dgvColumnLiedpfad.Name = "m_dgvColumnLiedpfad";
            // 
            // m_dgvColumnGuid
            // 
            this.m_dgvColumnGuid.DataPropertyName = "Guid";
            resources.ApplyResources(this.m_dgvColumnGuid, "m_dgvColumnGuid");
            this.m_dgvColumnGuid.Name = "m_dgvColumnGuid";
            // 
            // m_dgvColumnTimestamp
            // 
            this.m_dgvColumnTimestamp.DataPropertyName = "Timestamp";
            resources.ApplyResources(this.m_dgvColumnTimestamp, "m_dgvColumnTimestamp");
            this.m_dgvColumnTimestamp.Name = "m_dgvColumnTimestamp";
            // 
            // m_txtTitelId
            // 
            this.m_txtTitelId.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtTitelId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "TitelId", true));
            resources.ApplyResources(this.m_txtTitelId, "m_txtTitelId");
            this.m_txtTitelId.Name = "m_txtTitelId";
            this.m_txtTitelId.ReadOnly = true;
            // 
            // m_txtErschDatum
            // 
            this.m_txtErschDatum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "ErschDatum", true));
            resources.ApplyResources(this.m_txtErschDatum, "m_txtErschDatum");
            this.m_txtErschDatum.Name = "m_txtErschDatum";
            this.m_txtErschDatum.Validating += new System.ComponentModel.CancelEventHandler(this.TxtErschDatumValidating);
            // 
            // m_lblInterpreten
            // 
            resources.ApplyResources(this.m_lblInterpreten, "m_lblInterpreten");
            this.m_lblInterpreten.BackColor = System.Drawing.Color.Transparent;
            this.m_lblInterpreten.Name = "m_lblInterpreten";
            // 
            // m_lblInterpret
            // 
            resources.ApplyResources(this.m_lblInterpret, "m_lblInterpret");
            this.m_lblInterpret.BackColor = System.Drawing.Color.Transparent;
            this.m_lblInterpret.Name = "m_lblInterpret";
            // 
            // m_txtInterpret
            // 
            resources.ApplyResources(this.m_txtInterpret, "m_txtInterpret");
            this.m_txtInterpret.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Interpret", true));
            this.m_txtInterpret.Name = "m_txtInterpret";
            this.m_txtInterpret.ReadOnlyChanged += new System.EventHandler(this.TxtInterpretReadOnlyChanged);
            // 
            // m_vsbPaging
            // 
            resources.ApplyResources(this.m_vsbPaging, "m_vsbPaging");
            this.m_vsbPaging.LargeChange = 1;
            this.m_vsbPaging.Minimum = 1;
            this.m_vsbPaging.Name = "m_vsbPaging";
            this.m_vsbPaging.Value = 1;
            // 
            // m_cboInterpreten
            // 
            resources.ApplyResources(this.m_cboInterpreten, "m_cboInterpreten");
            this.m_cboInterpreten.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.m_bindingSource, "InterpretId", true));
            this.m_cboInterpreten.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboInterpreten.FormattingEnabled = true;
            this.m_cboInterpreten.Name = "m_cboInterpreten";
            this.m_cboInterpreten.VisibleChanged += new System.EventHandler(this.CboInterpretenVisibleChanged);
            // 
            // m_cboGenre
            // 
            resources.ApplyResources(this.m_cboGenre, "m_cboGenre");
            this.m_cboGenre.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.m_bindingSource, "GenreId", true));
            this.m_cboGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboGenre.FormattingEnabled = true;
            this.m_cboGenre.Name = "m_cboGenre";
            // 
            // m_lblErschDatum
            // 
            resources.ApplyResources(this.m_lblErschDatum, "m_lblErschDatum");
            this.m_lblErschDatum.BackColor = System.Drawing.Color.Transparent;
            this.m_lblErschDatum.Name = "m_lblErschDatum";
            // 
            // m_lblTitel
            // 
            resources.ApplyResources(this.m_lblTitel, "m_lblTitel");
            this.m_lblTitel.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTitel.Name = "m_lblTitel";
            // 
            // m_cboMedium
            // 
            this.m_cboMedium.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.m_bindingSource, "MediumId", true));
            this.m_cboMedium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedium.FormattingEnabled = true;
            resources.ApplyResources(this.m_cboMedium, "m_cboMedium");
            this.m_cboMedium.Name = "m_cboMedium";
            // 
            // m_txtTitel
            // 
            resources.ApplyResources(this.m_txtTitel, "m_txtTitel");
            this.m_txtTitel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Titel", true));
            this.m_txtTitel.Name = "m_txtTitel";
            this.m_txtTitel.Validating += new System.ComponentModel.CancelEventHandler(this.TxtTitelValidating);
            // 
            // m_lblGenre
            // 
            resources.ApplyResources(this.m_lblGenre, "m_lblGenre");
            this.m_lblGenre.BackColor = System.Drawing.Color.Transparent;
            this.m_lblGenre.Name = "m_lblGenre";
            // 
            // m_lblMedium
            // 
            resources.ApplyResources(this.m_lblMedium, "m_lblMedium");
            this.m_lblMedium.BackColor = System.Drawing.Color.Transparent;
            this.m_lblMedium.Name = "m_lblMedium";
            // 
            // m_lblMutiert
            // 
            resources.ApplyResources(this.m_lblMutiert, "m_lblMutiert");
            this.m_lblMutiert.BackColor = System.Drawing.Color.Transparent;
            this.m_lblMutiert.Name = "m_lblMutiert";
            // 
            // m_txtMutationDurch
            // 
            resources.ApplyResources(this.m_txtMutationDurch, "m_txtMutationDurch");
            this.m_txtMutationDurch.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtMutationDurch.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "MutationNm", true));
            this.m_txtMutationDurch.Name = "m_txtMutationDurch";
            this.m_txtMutationDurch.ReadOnly = true;
            this.m_txtMutationDurch.TabStop = false;
            // 
            // m_btnEditImage
            // 
            resources.ApplyResources(this.m_btnEditImage, "m_btnEditImage");
            this.m_btnEditImage.Image = global::BSE.Platten.Admin.Properties.Resources.Image;
            this.m_btnEditImage.Name = "m_btnEditImage";
            this.m_tltAdmin.SetToolTip(this.m_btnEditImage, resources.GetString("m_btnEditImage.ToolTip"));
            this.m_btnEditImage.UseVisualStyleBackColor = true;
            this.m_btnEditImage.Click += new System.EventHandler(this.m_btnEditImage_Click);
            // 
            // m_btnShowInterprets
            // 
            resources.ApplyResources(this.m_btnShowInterprets, "m_btnShowInterprets");
            this.m_btnShowInterprets.Image = global::BSE.Platten.Admin.Properties.Resources.RefreshDocViewHS;
            this.m_btnShowInterprets.Name = "m_btnShowInterprets";
            this.m_tltAdmin.SetToolTip(this.m_btnShowInterprets, resources.GetString("m_btnShowInterprets.ToolTip"));
            this.m_btnShowInterprets.UseVisualStyleBackColor = true;
            this.m_btnShowInterprets.Click += new System.EventHandler(this.m_btnShowInterprets_Click);
            // 
            // m_txtMutationDatum
            // 
            resources.ApplyResources(this.m_txtMutationDatum, "m_txtMutationDatum");
            this.m_txtMutationDatum.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtMutationDatum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "MutationDatum", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.m_txtMutationDatum.Name = "m_txtMutationDatum";
            this.m_txtMutationDatum.ReadOnly = true;
            this.m_txtMutationDatum.TabStop = false;
            // 
            // m_txtErstDurch
            // 
            resources.ApplyResources(this.m_txtErstDurch, "m_txtErstDurch");
            this.m_txtErstDurch.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtErstDurch.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "ErstellerNm", true));
            this.m_txtErstDurch.Name = "m_txtErstDurch";
            this.m_txtErstDurch.ReadOnly = true;
            this.m_txtErstDurch.TabStop = false;
            // 
            // m_txtErstDatum
            // 
            resources.ApplyResources(this.m_txtErstDatum, "m_txtErstDatum");
            this.m_txtErstDatum.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtErstDatum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "ErstellDatum", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.m_txtErstDatum.Name = "m_txtErstDatum";
            this.m_txtErstDatum.ReadOnly = true;
            this.m_txtErstDatum.TabStop = false;
            // 
            // m_lblErstellt
            // 
            resources.ApplyResources(this.m_lblErstellt, "m_lblErstellt");
            this.m_lblErstellt.BackColor = System.Drawing.Color.Transparent;
            this.m_lblErstellt.Name = "m_lblErstellt";
            // 
            // m_dataSetAlbum
            // 
            this.m_dataSetAlbum.DataSetName = "DataSetAlbum";
            // 
            // m_configuration
            // 
            this.m_configuration.ApplicationSubDirectory = null;
            // 
            // m_tsTools
            // 
            resources.ApplyResources(this.m_tsTools, "m_tsTools");
            this.m_tsTools.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnToolsSep1,
            this.m_btnTools_Bildimport,
            this.m_btnTools_Bildexport,
            this.m_btnToolsSep2,
            this.m_btnTools_RipCD,
            this.m_btnTools_AudioImport,
            this.m_btnTools_WriteTags,
            this.m_btnToolsSep3,
            this.toolStripDropDownButton1});
            this.m_tsTools.Name = "m_tsTools";
            // 
            // m_btnToolsSep1
            // 
            this.m_btnToolsSep1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_btnToolsSep1.Name = "m_btnToolsSep1";
            resources.ApplyResources(this.m_btnToolsSep1, "m_btnToolsSep1");
            // 
            // m_btnTools_Bildimport
            // 
            this.m_btnTools_Bildimport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_Bildimport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_into;
            resources.ApplyResources(this.m_btnTools_Bildimport, "m_btnTools_Bildimport");
            this.m_btnTools_Bildimport.Name = "m_btnTools_Bildimport";
            this.m_btnTools_Bildimport.Click += new System.EventHandler(this.m_btnTools_Bildimport_Click);
            // 
            // m_btnTools_Bildexport
            // 
            this.m_btnTools_Bildexport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_Bildexport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_out;
            resources.ApplyResources(this.m_btnTools_Bildexport, "m_btnTools_Bildexport");
            this.m_btnTools_Bildexport.Name = "m_btnTools_Bildexport";
            this.m_btnTools_Bildexport.Click += new System.EventHandler(this.m_btnTools_Bildexport_Click);
            // 
            // m_btnToolsSep2
            // 
            this.m_btnToolsSep2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_btnToolsSep2.Name = "m_btnToolsSep2";
            resources.ApplyResources(this.m_btnToolsSep2, "m_btnToolsSep2");
            // 
            // m_btnTools_RipCD
            // 
            this.m_btnTools_RipCD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_RipCD.Image = global::BSE.Platten.Admin.Properties.Resources.cd_music;
            resources.ApplyResources(this.m_btnTools_RipCD, "m_btnTools_RipCD");
            this.m_btnTools_RipCD.Name = "m_btnTools_RipCD";
            this.m_btnTools_RipCD.Click += new System.EventHandler(this.m_btnTools_RipCD_Click);
            // 
            // m_btnTools_AudioImport
            // 
            this.m_btnTools_AudioImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_AudioImport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_music;
            resources.ApplyResources(this.m_btnTools_AudioImport, "m_btnTools_AudioImport");
            this.m_btnTools_AudioImport.Name = "m_btnTools_AudioImport";
            this.m_btnTools_AudioImport.Click += new System.EventHandler(this.m_btnTools_AudioImport_Click);
            // 
            // m_btnTools_WriteTags
            // 
            this.m_btnTools_WriteTags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_WriteTags.Image = global::BSE.Platten.Admin.Properties.Resources.tag;
            resources.ApplyResources(this.m_btnTools_WriteTags, "m_btnTools_WriteTags");
            this.m_btnTools_WriteTags.Name = "m_btnTools_WriteTags";
            this.m_btnTools_WriteTags.Click += new System.EventHandler(this.m_btnTools_WriteTags_Click);
            // 
            // m_btnToolsSep3
            // 
            this.m_btnToolsSep3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_btnToolsSep3.Name = "m_btnToolsSep3";
            resources.ApplyResources(this.m_btnToolsSep3, "m_btnToolsSep3");
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diskInformationToolStripMenuItem,
            this.systemStatisticToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::BSE.Platten.Admin.Properties.Resources.monitor;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            // 
            // diskInformationToolStripMenuItem
            // 
            this.diskInformationToolStripMenuItem.Image = global::BSE.Platten.Admin.Properties.Resources.chart_donut;
            this.diskInformationToolStripMenuItem.Name = "diskInformationToolStripMenuItem";
            resources.ApplyResources(this.diskInformationToolStripMenuItem, "diskInformationToolStripMenuItem");
            this.diskInformationToolStripMenuItem.Click += new System.EventHandler(this.OnDiskInformationToolStripMenuItemClick);
            // 
            // systemStatisticToolStripMenuItem
            // 
            this.systemStatisticToolStripMenuItem.Image = global::BSE.Platten.Admin.Properties.Resources.chart_pie;
            this.systemStatisticToolStripMenuItem.Name = "systemStatisticToolStripMenuItem";
            resources.ApplyResources(this.systemStatisticToolStripMenuItem, "systemStatisticToolStripMenuItem");
            this.systemStatisticToolStripMenuItem.Click += new System.EventHandler(this.OnSystemStatisticToolStripMenuItemClick);
            // 
            // m_ofdlgPictureImport
            // 
            resources.ApplyResources(this.m_ofdlgPictureImport, "m_ofdlgPictureImport");
            // 
            // m_cmnuMusic
            // 
            this.m_cmnuMusic.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_cmnuMusic.Name = "m_cmnuMusic";
            resources.ApplyResources(this.m_cmnuMusic, "m_cmnuMusic");
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
            // 
            // Admin
            // 
            resources.ApplyResources(this, "$this");
            this.Configuration = this.m_configuration;
            this.Controls.Add(this.m_msAdmin);
            this.MainMenuStrip = this.m_msAdmin;
            this.Name = "Admin";
            this.VScrollBar = this.m_vsbPaging;
            this.HostAvailable += new System.EventHandler<BSE.Platten.Common.HostAvailableEventArgs>(this.HostAvailabilityChanged);
            this.ExecuteSearch += new System.EventHandler(this.CAdminExecuteSearch);
            this.SaveRecords += new System.EventHandler(this.CAdminSaveRecords);
            this.PositionChanged += new System.EventHandler(this.CAdminPositionChanged);
            this.ViewStateChanged += new System.EventHandler<BSE.Platten.Admin.ViewStateChangeEventArgs>(this.CAdminViewStateChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CAdminFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CAdminFormClosed);
            this.Controls.SetChildIndex(this.m_tspBottom, 0);
            this.Controls.SetChildIndex(this.m_tspRight, 0);
            this.Controls.SetChildIndex(this.m_tspLeft, 0);
            this.Controls.SetChildIndex(this.m_tspTop, 0);
            this.Controls.SetChildIndex(this.m_msAdmin, 0);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).EndInit();
            this.m_tspTop.ResumeLayout(false);
            this.m_tspTop.PerformLayout();
            this.m_toolstripContentPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.m_msAdmin.ResumeLayout(false);
            this.m_msAdmin.PerformLayout();
            this.m_pnlLeft.ResumeLayout(false);
            this.m_pnlCovers.ResumeLayout(false);
            this.m_pnlAlbum.ResumeLayout(false);
            this.m_pnlContent.ResumeLayout(false);
            this.m_pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCover)).EndInit();
            this.m_tbcAlbum.ResumeLayout(false);
            this.m_tbpLieder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_grdLieder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetAlbum)).EndInit();
            this.m_tsTools.ResumeLayout(false);
            this.m_tsTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_msAdmin;
        private System.Windows.Forms.ToolStripMenuItem m_mnuTools;
        private System.Windows.Forms.Panel m_pnlLeft;
        private BSE.Windows.Forms.Splitter m_sptLft;
        private BSE.Windows.Forms.Panel m_pnlAlbum;
        private BSE.Windows.Forms.Panel m_pnlCovers;
        private BSE.Windows.Forms.Splitter m_sptAdminTop;
        private System.Windows.Forms.TextBox m_txtTitelId;
        private BSE.Platten.Common.UnchangeableLabel m_lblTitelId;
        private System.Windows.Forms.TextBox m_txtInterpret;
        private BSE.Platten.Common.UnchangeableLabel m_lblInterpret;
        private System.Windows.Forms.ComboBox m_cboMedium;
        private System.Windows.Forms.ComboBox m_cboInterpreten;
        private System.Windows.Forms.TextBox m_txtTitel;
        private BSE.Platten.Common.UnchangeableLabel m_lblMedium;
        private BSE.Platten.Common.UnchangeableLabel m_lblTitel;
        private BSE.Platten.Common.UnchangeableLabel m_lblInterpreten;
        private BSE.Platten.Common.UnchangeableLabel m_lblErschDatum;
        private System.Windows.Forms.TextBox m_txtMutationDurch;
        private System.Windows.Forms.TextBox m_txtMutationDatum;
        private System.Windows.Forms.TextBox m_txtErstDurch;
        private System.Windows.Forms.TextBox m_txtErstDatum;
        private BSE.Platten.Common.UnchangeableLabel m_lblMutiert;
        private BSE.Platten.Common.UnchangeableLabel m_lblErstellt;
        private System.Windows.Forms.PictureBox m_picCover;
        private System.Windows.Forms.ComboBox m_cboGenre;
        private BSE.Platten.Common.UnchangeableLabel m_lblGenre;
        private System.Windows.Forms.Button m_btnShowInterprets;
        private System.Windows.Forms.Button m_btnEditImage;
        private System.Windows.Forms.DataGridView m_grdLieder;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExtras;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExtras_Optionen;
        private BSE.Configuration.Configuration m_configuration;
        private BSE.Platten.Covers.CoverPanel m_Covers;
        private BSE.Platten.BO.CDataSetAlbum m_dataSetAlbum;
        private System.Windows.Forms.VScrollBar m_vsbPaging;
        private System.Windows.Forms.ToolStrip m_tsTools;
        private System.Windows.Forms.ToolStripButton m_btnTools_Bildimport;
        private System.Windows.Forms.ToolStripButton m_btnTools_Bildexport;
        private System.Windows.Forms.ToolStripMenuItem m_mnuTools_Bildimport;
        private System.Windows.Forms.ToolStripMenuItem m_mnuTools_Bildexport;
        private System.Windows.Forms.ToolStripSeparator m_mnuTools_Sep1;
        private System.Windows.Forms.ToolStripSeparator m_btnToolsSep2;
        private System.Windows.Forms.ToolStripButton m_btnTools_AudioImport;
        private System.Windows.Forms.ToolStripSeparator m_btnToolsSep3;
        private System.Windows.Forms.ToolStripButton m_btnTools_WriteTags;
        private System.Windows.Forms.ToolStripMenuItem m_mnuTools_RipCD;
        private System.Windows.Forms.ToolStripSeparator m_mnuToolsSep2;
        private System.Windows.Forms.ToolStripMenuItem m_mnuTools_AudioImport;
        private System.Windows.Forms.ToolStripSeparator m_mnuToolsSep3;
        private System.Windows.Forms.ToolStripMenuItem m_mnuTools_WriteTags;
        private System.Windows.Forms.SaveFileDialog m_sfdlgPictureExport;
        private System.Windows.Forms.OpenFileDialog m_ofdlgPictureImport;
        private System.Windows.Forms.ContextMenuStrip m_cmnuMusic;
        private BSE.Configuration.Configuration m_settings;
        private System.Windows.Forms.ToolTip m_tltAdmin;
        private System.Windows.Forms.TextBox m_txtErschDatum;
        private System.Windows.Forms.TabControl m_tbcAlbum;
        private System.Windows.Forms.TabPage m_tbpLieder;
        private System.Windows.Forms.Panel m_pnlContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnLiedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnTitelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnTrack;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnLied;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnDauer;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnLiedpfad;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvColumnTimestamp;
        private System.Windows.Forms.ToolStripButton m_btnTools_RipCD;
        private System.Windows.Forms.ToolStripSeparator m_btnToolsSep1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem diskInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemStatisticToolStripMenuItem;
    }
}
