namespace BSE.Platten.Admin
{
    partial class Datentraeger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Datentraeger));
            this.m_vsbPaging = new System.Windows.Forms.VScrollBar();
            this.m_txtMediumDescription = new System.Windows.Forms.TextBox();
            this.m_lblMediumDescription = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtMedium = new System.Windows.Forms.TextBox();
            this.m_lblMedium = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtMediumId = new System.Windows.Forms.TextBox();
            this.m_lblMediumId = new BSE.Platten.Common.UnchangeableLabel();
            this.m_dataSetMedium = new BSE.Platten.BO.CDataSetMedium();
            this.m_pnlMedium = new BSE.Windows.Forms.Panel();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).BeginInit();
            this.m_toolstripContentPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetMedium)).BeginInit();
            this.m_pnlMedium.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_bindingSource
            // 
            this.m_bindingSource.DataMember = "Medium";
            this.m_bindingSource.DataSource = this.m_dataSetMedium;
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
            this.m_toolstripContentPanel.Controls.Add(this.m_pnlMedium);
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
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
            // m_txtMediumDescription
            // 
            resources.ApplyResources(this.m_txtMediumDescription, "m_txtMediumDescription");
            this.m_txtMediumDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Beschreibung", true));
            this.m_txtMediumDescription.Name = "m_txtMediumDescription";
            // 
            // m_lblMediumDescription
            // 
            resources.ApplyResources(this.m_lblMediumDescription, "m_lblMediumDescription");
            this.m_lblMediumDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblMediumDescription.Name = "m_lblMediumDescription";
            // 
            // m_txtMedium
            // 
            resources.ApplyResources(this.m_txtMedium, "m_txtMedium");
            this.m_txtMedium.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Medium", true));
            this.m_txtMedium.Name = "m_txtMedium";
            this.m_txtMedium.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMediumValidating);
            // 
            // m_lblMedium
            // 
            resources.ApplyResources(this.m_lblMedium, "m_lblMedium");
            this.m_lblMedium.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblMedium.Name = "m_lblMedium";
            // 
            // m_txtMediumId
            // 
            resources.ApplyResources(this.m_txtMediumId, "m_txtMediumId");
            this.m_txtMediumId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "MediumId", true));
            this.m_txtMediumId.Name = "m_txtMediumId";
            this.m_txtMediumId.ReadOnly = true;
            // 
            // m_lblMediumId
            // 
            resources.ApplyResources(this.m_lblMediumId, "m_lblMediumId");
            this.m_lblMediumId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblMediumId.Name = "m_lblMediumId";
            // 
            // m_dataSetMedium
            // 
            this.m_dataSetMedium.DataSetName = "DataSetMedium";
            // 
            // m_pnlMedium
            // 
            resources.ApplyResources(this.m_pnlMedium, "m_pnlMedium");
            this.m_pnlMedium.AssociatedSplitter = null;
            this.m_pnlMedium.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlMedium.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlMedium.CaptionHeight = 27;
            this.m_pnlMedium.Controls.Add(this.m_pnlBase);
            this.m_pnlMedium.Controls.Add(this.m_vsbPaging);
            this.m_pnlMedium.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlMedium.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlMedium.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlMedium.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlMedium.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlMedium.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlMedium.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlMedium.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlMedium.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlMedium.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlMedium.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlMedium.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlMedium.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.m_pnlMedium.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlMedium.Image = null;
            this.m_pnlMedium.Name = "m_pnlMedium";
            this.m_pnlMedium.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.m_pnlMedium.ShowTransparentBackground = false;
            this.m_pnlMedium.ToolTipTextCloseIcon = null;
            this.m_pnlMedium.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlMedium.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // m_pnlBase
            // 
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.Controls.Add(this.m_txtMediumId);
            this.m_pnlBase.Controls.Add(this.m_lblMediumId);
            this.m_pnlBase.Controls.Add(this.m_txtMediumDescription);
            this.m_pnlBase.Controls.Add(this.m_lblMedium);
            this.m_pnlBase.Controls.Add(this.m_lblMediumDescription);
            this.m_pnlBase.Controls.Add(this.m_txtMedium);
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // Datentraeger
            // 
            resources.ApplyResources(this, "$this");
            this.DataSet = this.m_dataSetMedium;
            this.Name = "Datentraeger";
            this.ShowInTaskbar = false;
            this.ShowInToolsNode = true;
            this.ShowInTreeView = true;
            this.TreeNodeImage = global::BSE.Platten.Admin.Properties.Resources.Album16;
            this.VScrollBar = this.m_vsbPaging;
            this.NewRecord += new System.EventHandler(this.CDatentraegerNewRecord);
            this.ExecuteSearch += new System.EventHandler(this.CDatentraegerExecuteSearch);
            this.SaveRecords += new System.EventHandler(this.CDatentraegerSaveRecords);
            this.Load += new System.EventHandler(this.CDatentraegerLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).EndInit();
            this.m_toolstripContentPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetMedium)).EndInit();
            this.m_pnlMedium.ResumeLayout(false);
            this.m_pnlBase.ResumeLayout(false);
            this.m_pnlBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSE.Platten.Common.UnchangeableLabel m_lblMediumId;
        private System.Windows.Forms.TextBox m_txtMediumId;
        private BSE.Platten.Common.UnchangeableLabel m_lblMedium;
        private BSE.Platten.Common.UnchangeableLabel m_lblMediumDescription;
        private System.Windows.Forms.TextBox m_txtMedium;
        private System.Windows.Forms.TextBox m_txtMediumDescription;
        private System.Windows.Forms.VScrollBar m_vsbPaging;
        private BSE.Platten.BO.CDataSetMedium m_dataSetMedium;
        private BSE.Windows.Forms.Panel m_pnlMedium;
        private System.Windows.Forms.Panel m_pnlBase;
    }
}
