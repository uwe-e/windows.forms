namespace BSE.Platten.Admin
{
    partial class Genre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Genre));
            this.m_txtGenre = new System.Windows.Forms.TextBox();
            this.m_lblGenre = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtGenreId = new System.Windows.Forms.TextBox();
            this.m_lblGenreId = new BSE.Platten.Common.UnchangeableLabel();
            this.m_vsbPaging = new System.Windows.Forms.VScrollBar();
            this.m_dataSetGenre = new BSE.Platten.BO.CDataSetGenre();
            this.m_pnlGenre = new BSE.Windows.Forms.Panel();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).BeginInit();
            this.m_toolstripContentPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetGenre)).BeginInit();
            this.m_pnlGenre.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_bindingSource
            // 
            this.m_bindingSource.DataMember = "Genre";
            this.m_bindingSource.DataSource = this.m_dataSetGenre;
            // 
            // m_tspLeft
            // 
            resources.ApplyResources(this.m_tspLeft, "m_tspLeft");
            // 
            // m_tspRight
            // 
            resources.ApplyResources(this.m_tspRight, "m_tspRight");
            // 
            // m_tspTop
            // 
            resources.ApplyResources(this.m_tspTop, "m_tspTop");
            // 
            // m_tspBottom
            // 
            resources.ApplyResources(this.m_tspBottom, "m_tspBottom");
            // 
            // m_toolstripContentPanel
            // 
            resources.ApplyResources(this.m_toolstripContentPanel, "m_toolstripContentPanel");
            this.m_toolstripContentPanel.Controls.Add(this.m_pnlGenre);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // m_txtGenre
            // 
            resources.ApplyResources(this.m_txtGenre, "m_txtGenre");
            this.m_txtGenre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Genre", true));
            this.m_txtGenre.Name = "m_txtGenre";
            this.m_txtGenre.Validating += new System.ComponentModel.CancelEventHandler(this.TxtGenreValidating);
            // 
            // m_lblGenre
            // 
            resources.ApplyResources(this.m_lblGenre, "m_lblGenre");
            this.m_lblGenre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblGenre.Name = "m_lblGenre";
            // 
            // m_txtGenreId
            // 
            resources.ApplyResources(this.m_txtGenreId, "m_txtGenreId");
            this.m_txtGenreId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "GenreId", true));
            this.m_txtGenreId.Name = "m_txtGenreId";
            this.m_txtGenreId.ReadOnly = true;
            // 
            // m_lblGenreId
            // 
            resources.ApplyResources(this.m_lblGenreId, "m_lblGenreId");
            this.m_lblGenreId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblGenreId.Name = "m_lblGenreId";
            // 
            // m_vsbPaging
            // 
            resources.ApplyResources(this.m_vsbPaging, "m_vsbPaging");
            this.m_vsbPaging.LargeChange = 1;
            this.m_vsbPaging.Maximum = 1;
            this.m_vsbPaging.Minimum = 1;
            this.m_vsbPaging.Name = "m_vsbPaging";
            this.m_vsbPaging.Value = 1;
            // 
            // m_dataSetGenre
            // 
            this.m_dataSetGenre.DataSetName = "DataSetMedium";
            // 
            // m_pnlGenre
            // 
            resources.ApplyResources(this.m_pnlGenre, "m_pnlGenre");
            this.m_pnlGenre.AssociatedSplitter = null;
            this.m_pnlGenre.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlGenre.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlGenre.CaptionHeight = 27;
            this.m_pnlGenre.Controls.Add(this.m_pnlBase);
            this.m_pnlGenre.Controls.Add(this.m_vsbPaging);
            this.m_pnlGenre.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlGenre.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlGenre.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlGenre.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlGenre.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlGenre.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlGenre.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlGenre.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlGenre.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlGenre.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlGenre.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlGenre.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlGenre.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlGenre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlGenre.Image = null;
            this.m_pnlGenre.Name = "m_pnlGenre";
            this.m_pnlGenre.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.m_pnlGenre.ShowTransparentBackground = false;
            this.m_pnlGenre.ToolTipTextCloseIcon = null;
            this.m_pnlGenre.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlGenre.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_pnlBase
            // 
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.Controls.Add(this.m_txtGenre);
            this.m_pnlBase.Controls.Add(this.m_lblGenreId);
            this.m_pnlBase.Controls.Add(this.m_lblGenre);
            this.m_pnlBase.Controls.Add(this.m_txtGenreId);
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // Genre
            // 
            resources.ApplyResources(this, "$this");
            this.DataSet = this.m_dataSetGenre;
            this.Name = "Genre";
            this.ShowInTaskbar = false;
            this.ShowInToolsNode = true;
            this.ShowInTreeView = true;
            this.TreeNodeImage = global::BSE.Platten.Admin.Properties.Resources.Genre16;
            this.VScrollBar = this.m_vsbPaging;
            this.NewRecord += new System.EventHandler(this.CGenreNewRecord);
            this.ExecuteSearch += new System.EventHandler(this.CGenreExecuteSearch);
            this.SaveRecords += new System.EventHandler(this.CGenreSaveRecords);
            this.Load += new System.EventHandler(this.CGenreLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).EndInit();
            this.m_toolstripContentPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetGenre)).EndInit();
            this.m_pnlGenre.ResumeLayout(false);
            this.m_pnlBase.ResumeLayout(false);
            this.m_pnlBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar m_vsbPaging;
        private BSE.Platten.Common.UnchangeableLabel m_lblGenreId;
        private System.Windows.Forms.TextBox m_txtGenre;
        private BSE.Platten.Common.UnchangeableLabel m_lblGenre;
        private System.Windows.Forms.TextBox m_txtGenreId;
        private BSE.Platten.BO.CDataSetGenre m_dataSetGenre;
        private BSE.Windows.Forms.Panel m_pnlGenre;
        private System.Windows.Forms.Panel m_pnlBase;
    }
}
