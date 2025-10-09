namespace BSE.Platten.Admin
{
    partial class Interpreten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interpreten));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            this.m_lblInterpretID = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtInterpretLang = new System.Windows.Forms.TextBox();
            this.m_lblInterpret = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtInterpret = new System.Windows.Forms.TextBox();
            this.m_lblInterpretLang = new BSE.Platten.Common.UnchangeableLabel();
            this.m_txtInterpretID = new System.Windows.Forms.TextBox();
            this.m_vsbPaging = new System.Windows.Forms.VScrollBar();
            this.m_dataSetInterpret = new BSE.Platten.BO.CDataSetInterpret();
            this.m_pnlInterpreten = new BSE.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).BeginInit();
            this.m_toolstripContentPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetInterpret)).BeginInit();
            this.m_pnlInterpreten.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_bindingSource
            // 
            this.m_bindingSource.DataMember = "Interpreten";
            this.m_bindingSource.DataSource = this.m_dataSetInterpret;
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
            this.m_toolstripContentPanel.Controls.Add(this.m_pnlInterpreten);
            resources.ApplyResources(this.m_toolstripContentPanel, "m_toolstripContentPanel");
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
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
            this.m_btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_btnOK
            // 
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = false;
            // 
            // m_pnlBase
            // 
            this.m_pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBase.Controls.Add(this.m_lblInterpretID);
            this.m_pnlBase.Controls.Add(this.m_txtInterpretLang);
            this.m_pnlBase.Controls.Add(this.m_lblInterpret);
            this.m_pnlBase.Controls.Add(this.m_txtInterpret);
            this.m_pnlBase.Controls.Add(this.m_lblInterpretLang);
            this.m_pnlBase.Controls.Add(this.m_txtInterpretID);
            this.m_pnlBase.Controls.Add(this.m_vsbPaging);
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // m_lblInterpretID
            // 
            resources.ApplyResources(this.m_lblInterpretID, "m_lblInterpretID");
            this.m_lblInterpretID.BackColor = System.Drawing.Color.Transparent;
            this.m_lblInterpretID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblInterpretID.Name = "m_lblInterpretID";
            // 
            // m_txtInterpretLang
            // 
            resources.ApplyResources(this.m_txtInterpretLang, "m_txtInterpretLang");
            this.m_txtInterpretLang.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Interpret_Lang", true));
            this.m_txtInterpretLang.Name = "m_txtInterpretLang";
            this.m_txtInterpretLang.Validating += new System.ComponentModel.CancelEventHandler(this.TxtInterpretLangValidating);
            // 
            // m_lblInterpret
            // 
            resources.ApplyResources(this.m_lblInterpret, "m_lblInterpret");
            this.m_lblInterpret.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblInterpret.Name = "m_lblInterpret";
            // 
            // m_txtInterpret
            // 
            resources.ApplyResources(this.m_txtInterpret, "m_txtInterpret");
            this.m_txtInterpret.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "Interpret", true));
            this.m_txtInterpret.Name = "m_txtInterpret";
            this.m_txtInterpret.Validating += new System.ComponentModel.CancelEventHandler(this.TxtInterpretValidating);
            // 
            // m_lblInterpretLang
            // 
            resources.ApplyResources(this.m_lblInterpretLang, "m_lblInterpretLang");
            this.m_lblInterpretLang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblInterpretLang.Name = "m_lblInterpretLang";
            // 
            // m_txtInterpretID
            // 
            this.m_txtInterpretID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_bindingSource, "InterpretId", true));
            resources.ApplyResources(this.m_txtInterpretID, "m_txtInterpretID");
            this.m_txtInterpretID.Name = "m_txtInterpretID";
            this.m_txtInterpretID.ReadOnly = true;
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
            // m_dataSetInterpret
            // 
            this.m_dataSetInterpret.DataSetName = "DataSetInterpret";
            // 
            // m_pnlInterpreten
            // 
            this.m_pnlInterpreten.AssociatedSplitter = null;
            this.m_pnlInterpreten.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlInterpreten.CaptionFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_pnlInterpreten.CaptionHeight = 27;
            this.m_pnlInterpreten.Controls.Add(this.m_pnlBase);
            this.m_pnlInterpreten.Controls.Add(this.m_pnlAction);
            this.m_pnlInterpreten.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.m_pnlInterpreten.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlInterpreten.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.m_pnlInterpreten.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlInterpreten.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlInterpreten.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.m_pnlInterpreten.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlInterpreten.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.m_pnlInterpreten.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlInterpreten.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.m_pnlInterpreten.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.m_pnlInterpreten.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.m_pnlInterpreten.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_pnlInterpreten, "m_pnlInterpreten");
            this.m_pnlInterpreten.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_pnlInterpreten.Image = null;
            this.m_pnlInterpreten.Name = "m_pnlInterpreten";
            this.m_pnlInterpreten.ShowTransparentBackground = false;
            this.m_pnlInterpreten.ToolTipTextCloseIcon = null;
            this.m_pnlInterpreten.ToolTipTextExpandIconPanelCollapsed = null;
            this.m_pnlInterpreten.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // Interpreten
            // 
            resources.ApplyResources(this, "$this");
            this.DataSet = this.m_dataSetInterpret;
            this.Name = "Interpreten";
            this.ShowInTaskbar = false;
            this.ShowInToolsNode = true;
            this.ShowInTreeView = true;
            this.TreeNodeImage = global::BSE.Platten.Admin.Properties.Resources.Interpret16;
            this.VScrollBar = this.m_vsbPaging;
            this.NewRecord += new System.EventHandler(this.CInterpretenNewRecord);
            this.ClearSearch += new System.EventHandler(this.CInterpretenClearSearch);
            this.ExecuteSearch += new System.EventHandler(this.CInterpretenExecuteSearch);
            this.SaveRecords += new System.EventHandler(this.CInterpretenSaveRecords);
            this.Load += new System.EventHandler(this.CInterpretenLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_bindingSource)).EndInit();
            this.m_toolstripContentPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlAction.PerformLayout();
            this.m_pnlBase.ResumeLayout(false);
            this.m_pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataSetInterpret)).EndInit();
            this.m_pnlInterpreten.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlBase;
        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.VScrollBar m_vsbPaging;
        private System.Windows.Forms.TextBox m_txtInterpretID;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private BSE.Platten.Common.UnchangeableLabel m_lblInterpretID;
        private BSE.Platten.Common.UnchangeableLabel m_lblInterpret;
        private System.Windows.Forms.TextBox m_txtInterpret;
        private BSE.Platten.Common.UnchangeableLabel m_lblInterpretLang;
        private System.Windows.Forms.TextBox m_txtInterpretLang;
        private BSE.Platten.BO.CDataSetInterpret m_dataSetInterpret;
        private BSE.Windows.Forms.Panel m_pnlInterpreten;

    }
}
