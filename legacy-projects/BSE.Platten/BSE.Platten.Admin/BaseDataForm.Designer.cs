using System.Windows.Forms;
namespace BSE.Platten.Admin
{
    partial class BaseDataForm
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
            try
            {
                if (disposing && (components != null))
                {
                    if (this.m_ttslCheckDb != null)
                    {
                        this.m_ttslCheckDb.Dispose();
                    }
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDataForm));
            this.m_toolstripContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.m_msBase = new System.Windows.Forms.MenuStrip();
            this.m_mnuDatei = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatei_Beenden = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuEdit_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuSuchen = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuSuchen_Neu = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuSuchen_Ausführen = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatensatz = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatensatz_Neu = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuDatensatz_Speichern = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tsDataBase = new System.Windows.Forms.ToolStrip();
            this.m_btnSuche_Neu = new System.Windows.Forms.ToolStripButton();
            this.m_btnSuchen_Ausführen = new System.Windows.Forms.ToolStripButton();
            this.m_tlbSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnDatensatz_Neu = new System.Windows.Forms.ToolStripButton();
            this.m_btnDatensatz_Speichern = new System.Windows.Forms.ToolStripButton();
            this.m_tlbSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnEdit_Undo = new System.Windows.Forms.ToolStripButton();
            this.m_tlbSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.m_btnPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.m_btnNextRecord = new System.Windows.Forms.ToolStripButton();
            this.m_btnLastRecord = new System.Windows.Forms.ToolStripButton();
            this.m_tspTop = new System.Windows.Forms.ToolStripPanel();
            this.m_tspLeft = new System.Windows.Forms.ToolStripPanel();
            this.m_tspRight = new System.Windows.Forms.ToolStripPanel();
            this.m_tspBottom = new System.Windows.Forms.ToolStripPanel();
            this.m_ssBase = new System.Windows.Forms.StatusStrip();
            this.m_tslblComment = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_tslblNavigation = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ContentPanel.SuspendLayout();
            this.m_msBase.SuspendLayout();
            this.m_tsDataBase.SuspendLayout();
            this.m_tspTop.SuspendLayout();
            this.m_ssBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.Controls.Add(this.m_toolstripContentPanel);
            this.m_errProvider.SetError(this.ContentPanel, resources.GetString("ContentPanel.Error"));
            this.m_errProvider.SetIconAlignment(this.ContentPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("ContentPanel.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.ContentPanel, ((int)(resources.GetObject("ContentPanel.IconPadding"))));
            this.ContentPanel.Resize += new System.EventHandler(this.PanelContentResize);
            // 
            // m_toolstripContentPanel
            // 
            resources.ApplyResources(this.m_toolstripContentPanel, "m_toolstripContentPanel");
            this.m_errProvider.SetError(this.m_toolstripContentPanel, resources.GetString("m_toolstripContentPanel.Error"));
            this.m_errProvider.SetIconAlignment(this.m_toolstripContentPanel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_toolstripContentPanel.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_toolstripContentPanel, ((int)(resources.GetObject("m_toolstripContentPanel.IconPadding"))));
            this.m_toolstripContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            // 
            // m_msBase
            // 
            resources.ApplyResources(this.m_msBase, "m_msBase");
            this.m_errProvider.SetError(this.m_msBase, resources.GetString("m_msBase.Error"));
            this.m_errProvider.SetIconAlignment(this.m_msBase, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_msBase.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_msBase, ((int)(resources.GetObject("m_msBase.IconPadding"))));
            this.m_msBase.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_msBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatei,
            this.m_mnuEdit,
            this.m_mnuSuchen,
            this.m_mnuDatensatz});
            this.m_msBase.Name = "m_msBase";
            // 
            // m_mnuDatei
            // 
            resources.ApplyResources(this.m_mnuDatei, "m_mnuDatei");
            this.m_mnuDatei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatei_Beenden});
            this.m_mnuDatei.Name = "m_mnuDatei";
            // 
            // m_mnuDatei_Beenden
            // 
            resources.ApplyResources(this.m_mnuDatei_Beenden, "m_mnuDatei_Beenden");
            this.m_mnuDatei_Beenden.Name = "m_mnuDatei_Beenden";
            this.m_mnuDatei_Beenden.Click += new System.EventHandler(this.m_mnuDatei_Beenden_Click);
            // 
            // m_mnuEdit
            // 
            resources.ApplyResources(this.m_mnuEdit, "m_mnuEdit");
            this.m_mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuEdit_Undo});
            this.m_mnuEdit.Name = "m_mnuEdit";
            // 
            // m_mnuEdit_Undo
            // 
            resources.ApplyResources(this.m_mnuEdit_Undo, "m_mnuEdit_Undo");
            this.m_mnuEdit_Undo.Image = global::BSE.Platten.Admin.Properties.Resources.undo;
            this.m_mnuEdit_Undo.Name = "m_mnuEdit_Undo";
            this.m_mnuEdit_Undo.Click += new System.EventHandler(this.m_mnuEdit_Undo_Click);
            // 
            // m_mnuSuchen
            // 
            resources.ApplyResources(this.m_mnuSuchen, "m_mnuSuchen");
            this.m_mnuSuchen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuSuchen_Neu,
            this.m_mnuSuchen_Ausführen});
            this.m_mnuSuchen.Name = "m_mnuSuchen";
            // 
            // m_mnuSuchen_Neu
            // 
            resources.ApplyResources(this.m_mnuSuchen_Neu, "m_mnuSuchen_Neu");
            this.m_mnuSuchen_Neu.Image = global::BSE.Platten.Admin.Properties.Resources.find_replace;
            this.m_mnuSuchen_Neu.Name = "m_mnuSuchen_Neu";
            this.m_mnuSuchen_Neu.Click += new System.EventHandler(this.m_mnuSuchen_Neu_Click);
            // 
            // m_mnuSuchen_Ausführen
            // 
            resources.ApplyResources(this.m_mnuSuchen_Ausführen, "m_mnuSuchen_Ausführen");
            this.m_mnuSuchen_Ausführen.Image = global::BSE.Platten.Admin.Properties.Resources.magnifying_glass;
            this.m_mnuSuchen_Ausführen.Name = "m_mnuSuchen_Ausführen";
            this.m_mnuSuchen_Ausführen.Click += new System.EventHandler(this.m_mnuSuchen_Ausführen_Click);
            // 
            // m_mnuDatensatz
            // 
            resources.ApplyResources(this.m_mnuDatensatz, "m_mnuDatensatz");
            this.m_mnuDatensatz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuDatensatz_Neu,
            this.m_mnuDatensatz_Speichern});
            this.m_mnuDatensatz.Name = "m_mnuDatensatz";
            // 
            // m_mnuDatensatz_Neu
            // 
            resources.ApplyResources(this.m_mnuDatensatz_Neu, "m_mnuDatensatz_Neu");
            this.m_mnuDatensatz_Neu.Image = global::BSE.Platten.Admin.Properties.Resources.add;
            this.m_mnuDatensatz_Neu.Name = "m_mnuDatensatz_Neu";
            this.m_mnuDatensatz_Neu.Click += new System.EventHandler(this.m_mnuDatensatz_Neu_Click);
            // 
            // m_mnuDatensatz_Speichern
            // 
            resources.ApplyResources(this.m_mnuDatensatz_Speichern, "m_mnuDatensatz_Speichern");
            this.m_mnuDatensatz_Speichern.Image = global::BSE.Platten.Admin.Properties.Resources.floppy_disk;
            this.m_mnuDatensatz_Speichern.Name = "m_mnuDatensatz_Speichern";
            this.m_mnuDatensatz_Speichern.Click += new System.EventHandler(this.m_mnuDatensatz_Speichern_Click);
            // 
            // m_tsDataBase
            // 
            resources.ApplyResources(this.m_tsDataBase, "m_tsDataBase");
            this.m_errProvider.SetError(this.m_tsDataBase, resources.GetString("m_tsDataBase.Error"));
            this.m_errProvider.SetIconAlignment(this.m_tsDataBase, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_tsDataBase.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_tsDataBase, ((int)(resources.GetObject("m_tsDataBase.IconPadding"))));
            this.m_tsDataBase.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_tsDataBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnSuche_Neu,
            this.m_btnSuchen_Ausführen,
            this.m_tlbSep1,
            this.m_btnDatensatz_Neu,
            this.m_btnDatensatz_Speichern,
            this.m_tlbSep2,
            this.m_btnEdit_Undo,
            this.m_tlbSep3,
            this.m_btnFirstRecord,
            this.m_btnPreviousRecord,
            this.m_btnNextRecord,
            this.m_btnLastRecord});
            this.m_tsDataBase.Name = "m_tsDataBase";
            // 
            // m_btnSuche_Neu
            // 
            resources.ApplyResources(this.m_btnSuche_Neu, "m_btnSuche_Neu");
            this.m_btnSuche_Neu.Image = global::BSE.Platten.Admin.Properties.Resources.find_replace;
            this.m_btnSuche_Neu.Name = "m_btnSuche_Neu";
            this.m_btnSuche_Neu.Click += new System.EventHandler(this.m_mnuSuchen_Neu_Click);
            // 
            // m_btnSuchen_Ausführen
            // 
            resources.ApplyResources(this.m_btnSuchen_Ausführen, "m_btnSuchen_Ausführen");
            this.m_btnSuchen_Ausführen.Image = global::BSE.Platten.Admin.Properties.Resources.magnifying_glass;
            this.m_btnSuchen_Ausführen.Name = "m_btnSuchen_Ausführen";
            this.m_btnSuchen_Ausführen.Click += new System.EventHandler(this.m_mnuSuchen_Ausführen_Click);
            // 
            // m_tlbSep1
            // 
            resources.ApplyResources(this.m_tlbSep1, "m_tlbSep1");
            this.m_tlbSep1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_tlbSep1.Name = "m_tlbSep1";
            // 
            // m_btnDatensatz_Neu
            // 
            resources.ApplyResources(this.m_btnDatensatz_Neu, "m_btnDatensatz_Neu");
            this.m_btnDatensatz_Neu.Image = global::BSE.Platten.Admin.Properties.Resources.add;
            this.m_btnDatensatz_Neu.Name = "m_btnDatensatz_Neu";
            this.m_btnDatensatz_Neu.Click += new System.EventHandler(this.OnNewRecord);
            // 
            // m_btnDatensatz_Speichern
            // 
            resources.ApplyResources(this.m_btnDatensatz_Speichern, "m_btnDatensatz_Speichern");
            this.m_btnDatensatz_Speichern.Image = global::BSE.Platten.Admin.Properties.Resources.floppy_disk;
            this.m_btnDatensatz_Speichern.Name = "m_btnDatensatz_Speichern";
            this.m_btnDatensatz_Speichern.Click += new System.EventHandler(this.m_mnuDatensatz_Speichern_Click);
            // 
            // m_tlbSep2
            // 
            resources.ApplyResources(this.m_tlbSep2, "m_tlbSep2");
            this.m_tlbSep2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_tlbSep2.Name = "m_tlbSep2";
            // 
            // m_btnEdit_Undo
            // 
            resources.ApplyResources(this.m_btnEdit_Undo, "m_btnEdit_Undo");
            this.m_btnEdit_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnEdit_Undo.Image = global::BSE.Platten.Admin.Properties.Resources.undo;
            this.m_btnEdit_Undo.Name = "m_btnEdit_Undo";
            this.m_btnEdit_Undo.Click += new System.EventHandler(this.m_mnuEdit_Undo_Click);
            // 
            // m_tlbSep3
            // 
            resources.ApplyResources(this.m_tlbSep3, "m_tlbSep3");
            this.m_tlbSep3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_tlbSep3.Name = "m_tlbSep3";
            // 
            // m_btnFirstRecord
            // 
            resources.ApplyResources(this.m_btnFirstRecord, "m_btnFirstRecord");
            this.m_btnFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnFirstRecord.Image = global::BSE.Platten.Admin.Properties.Resources.navigate_beginning;
            this.m_btnFirstRecord.Name = "m_btnFirstRecord";
            this.m_btnFirstRecord.Click += new System.EventHandler(this.m_btnFirstRecord_Click);
            // 
            // m_btnPreviousRecord
            // 
            resources.ApplyResources(this.m_btnPreviousRecord, "m_btnPreviousRecord");
            this.m_btnPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnPreviousRecord.Image = global::BSE.Platten.Admin.Properties.Resources.navigate_left;
            this.m_btnPreviousRecord.Name = "m_btnPreviousRecord";
            this.m_btnPreviousRecord.Click += new System.EventHandler(this.m_btnPreviousRecord_Click);
            // 
            // m_btnNextRecord
            // 
            resources.ApplyResources(this.m_btnNextRecord, "m_btnNextRecord");
            this.m_btnNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnNextRecord.Image = global::BSE.Platten.Admin.Properties.Resources.navigate_right;
            this.m_btnNextRecord.Name = "m_btnNextRecord";
            this.m_btnNextRecord.Click += new System.EventHandler(this.m_btnNextRecord_Click);
            // 
            // m_btnLastRecord
            // 
            resources.ApplyResources(this.m_btnLastRecord, "m_btnLastRecord");
            this.m_btnLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnLastRecord.Image = global::BSE.Platten.Admin.Properties.Resources.navigate_end;
            this.m_btnLastRecord.Name = "m_btnLastRecord";
            this.m_btnLastRecord.Click += new System.EventHandler(this.m_btnLastRecord_Click);
            // 
            // m_tspTop
            // 
            resources.ApplyResources(this.m_tspTop, "m_tspTop");
            this.m_tspTop.Controls.Add(this.m_tsDataBase);
            this.m_errProvider.SetError(this.m_tspTop, resources.GetString("m_tspTop.Error"));
            this.m_errProvider.SetIconAlignment(this.m_tspTop, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_tspTop.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_tspTop, ((int)(resources.GetObject("m_tspTop.IconPadding"))));
            this.m_tspTop.Name = "m_tspTop";
            this.m_tspTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.m_tspTop.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // m_tspLeft
            // 
            resources.ApplyResources(this.m_tspLeft, "m_tspLeft");
            this.m_errProvider.SetError(this.m_tspLeft, resources.GetString("m_tspLeft.Error"));
            this.m_errProvider.SetIconAlignment(this.m_tspLeft, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_tspLeft.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_tspLeft, ((int)(resources.GetObject("m_tspLeft.IconPadding"))));
            this.m_tspLeft.Name = "m_tspLeft";
            this.m_tspLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_tspLeft.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // m_tspRight
            // 
            resources.ApplyResources(this.m_tspRight, "m_tspRight");
            this.m_errProvider.SetError(this.m_tspRight, resources.GetString("m_tspRight.Error"));
            this.m_errProvider.SetIconAlignment(this.m_tspRight, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_tspRight.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_tspRight, ((int)(resources.GetObject("m_tspRight.IconPadding"))));
            this.m_tspRight.Name = "m_tspRight";
            this.m_tspRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_tspRight.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // m_tspBottom
            // 
            resources.ApplyResources(this.m_tspBottom, "m_tspBottom");
            this.m_errProvider.SetError(this.m_tspBottom, resources.GetString("m_tspBottom.Error"));
            this.m_errProvider.SetIconAlignment(this.m_tspBottom, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_tspBottom.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_tspBottom, ((int)(resources.GetObject("m_tspBottom.IconPadding"))));
            this.m_tspBottom.Name = "m_tspBottom";
            this.m_tspBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.m_tspBottom.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            // 
            // m_ssBase
            // 
            resources.ApplyResources(this.m_ssBase, "m_ssBase");
            this.m_errProvider.SetError(this.m_ssBase, resources.GetString("m_ssBase.Error"));
            this.m_errProvider.SetIconAlignment(this.m_ssBase, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("m_ssBase.IconAlignment"))));
            this.m_errProvider.SetIconPadding(this.m_ssBase, ((int)(resources.GetObject("m_ssBase.IconPadding"))));
            this.m_ssBase.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.m_ssBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tslblComment,
            this.m_tslblNavigation});
            this.m_ssBase.Name = "m_ssBase";
            this.m_ssBase.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            // 
            // m_tslblComment
            // 
            resources.ApplyResources(this.m_tslblComment, "m_tslblComment");
            this.m_tslblComment.Name = "m_tslblComment";
            this.m_tslblComment.Spring = true;
            // 
            // m_tslblNavigation
            // 
            resources.ApplyResources(this.m_tslblNavigation, "m_tslblNavigation");
            this.m_tslblNavigation.Name = "m_tslblNavigation";
            // 
            // m_bindingSource
            // 
            this.m_bindingSource.PositionChanged += new System.EventHandler(this.OnPositionChanged);
            // 
            // m_errProvider
            // 
            this.m_errProvider.ContainerControl = this;
            resources.ApplyResources(this.m_errProvider, "m_errProvider");
            // 
            // BaseDataForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tspTop);
            this.Controls.Add(this.m_tspLeft);
            this.Controls.Add(this.m_tspRight);
            this.Controls.Add(this.m_tspBottom);
            this.Controls.Add(this.m_ssBase);
            this.Controls.Add(this.m_msBase);
            this.KeyPreview = true;
            this.MainMenuStrip = this.m_msBase;
            this.Name = "BaseDataForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBaseDataForm_KeyUp);
            this.Controls.SetChildIndex(this.m_msBase, 0);
            this.Controls.SetChildIndex(this.m_ssBase, 0);
            this.Controls.SetChildIndex(this.m_tspBottom, 0);
            this.Controls.SetChildIndex(this.m_tspRight, 0);
            this.Controls.SetChildIndex(this.m_tspLeft, 0);
            this.Controls.SetChildIndex(this.m_tspTop, 0);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.m_msBase.ResumeLayout(false);
            this.m_msBase.PerformLayout();
            this.m_tsDataBase.ResumeLayout(false);
            this.m_tsDataBase.PerformLayout();
            this.m_tspTop.ResumeLayout(false);
            this.m_tspTop.PerformLayout();
            this.m_ssBase.ResumeLayout(false);
            this.m_ssBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatei_Beenden;
        private System.Windows.Forms.ToolStripMenuItem m_mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem m_mnuEdit_Undo;
        private System.Windows.Forms.ToolStripMenuItem m_mnuSuchen;
        private System.Windows.Forms.ToolStripMenuItem m_mnuSuchen_Neu;
        private System.Windows.Forms.ToolStripMenuItem m_mnuSuchen_Ausführen;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatensatz;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatensatz_Neu;
        private System.Windows.Forms.ToolStripMenuItem m_mnuDatensatz_Speichern;
        private System.Windows.Forms.ToolStripButton m_btnSuche_Neu;
        private System.Windows.Forms.ToolStripButton m_btnSuchen_Ausführen;
        private System.Windows.Forms.ToolStripSeparator m_tlbSep1;
        private System.Windows.Forms.ToolStripButton m_btnDatensatz_Neu;
        private System.Windows.Forms.ToolStripButton m_btnDatensatz_Speichern;
        private System.Windows.Forms.ToolStripSeparator m_tlbSep2;
        private System.Windows.Forms.ToolStripButton m_btnFirstRecord;
        private System.Windows.Forms.ToolStripButton m_btnPreviousRecord;
        private System.Windows.Forms.ToolStripButton m_btnNextRecord;
        private System.Windows.Forms.ToolStripButton m_btnLastRecord;
        private System.Windows.Forms.StatusStrip m_ssBase;
        private System.Windows.Forms.ToolStripButton m_btnEdit_Undo;
        private System.Windows.Forms.ToolStripSeparator m_tlbSep3;
        private System.Windows.Forms.ToolStripStatusLabel m_tslblNavigation;
        public System.Windows.Forms.BindingSource m_bindingSource;
        private System.Windows.Forms.ErrorProvider m_errProvider;
        private System.Windows.Forms.ToolStrip m_tsDataBase;
        private System.Windows.Forms.MenuStrip m_msBase;
        protected System.Windows.Forms.ToolStripPanel m_tspLeft;
        protected System.Windows.Forms.ToolStripPanel m_tspRight;
        protected System.Windows.Forms.ToolStripPanel m_tspTop;
        protected System.Windows.Forms.ToolStripPanel m_tspBottom;
        private System.Windows.Forms.ToolStripStatusLabel m_tslblComment;
        protected ToolStripContentPanel m_toolstripContentPanel;
    }
}