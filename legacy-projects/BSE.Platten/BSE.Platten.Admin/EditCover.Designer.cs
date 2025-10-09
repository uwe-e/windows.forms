namespace BSE.Platten.Admin
{
    partial class EditCover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCover));
            this.m_tsCovers = new System.Windows.Forms.ToolStrip();
            this.m_btnTools_Bildimport = new System.Windows.Forms.ToolStripButton();
            this.m_btnTools_Bildexport = new System.Windows.Forms.ToolStripButton();
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            this.m_picCover = new System.Windows.Forms.PictureBox();
            this.m_ofdlgPictureImport = new System.Windows.Forms.OpenFileDialog();
            this.m_sfdlgPictureExport = new System.Windows.Forms.SaveFileDialog();
            this.ContentPanel.SuspendLayout();
            this.m_tsCovers.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.Controls.Add(this.m_tsCovers);
            this.ContentPanel.Controls.Add(this.m_pnlBase);
            this.ContentPanel.Controls.Add(this.m_pnlAction);
            // 
            // m_tsCovers
            // 
            resources.ApplyResources(this.m_tsCovers, "m_tsCovers");
            this.m_tsCovers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_tsCovers.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.m_tsCovers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnTools_Bildimport,
            this.m_btnTools_Bildexport});
            this.m_tsCovers.Name = "m_tsCovers";
            this.m_tsCovers.Stretch = true;
            // 
            // m_btnTools_Bildimport
            // 
            resources.ApplyResources(this.m_btnTools_Bildimport, "m_btnTools_Bildimport");
            this.m_btnTools_Bildimport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_Bildimport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_into;
            this.m_btnTools_Bildimport.Name = "m_btnTools_Bildimport";
            this.m_btnTools_Bildimport.Click += new System.EventHandler(this.m_btnTools_Bildimport_Click);
            // 
            // m_btnTools_Bildexport
            // 
            resources.ApplyResources(this.m_btnTools_Bildexport, "m_btnTools_Bildexport");
            this.m_btnTools_Bildexport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTools_Bildexport.Image = global::BSE.Platten.Admin.Properties.Resources.folder_out;
            this.m_btnTools_Bildexport.Name = "m_btnTools_Bildexport";
            this.m_btnTools_Bildexport.Click += new System.EventHandler(this.m_btnTools_Bildexport_Click);
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
            // 
            // m_btnOK
            // 
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            // 
            // m_pnlBase
            // 
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_pnlBase.Controls.Add(this.m_picCover);
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // m_picCover
            // 
            resources.ApplyResources(this.m_picCover, "m_picCover");
            this.m_picCover.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_picCover.Name = "m_picCover";
            this.m_picCover.TabStop = false;
            // 
            // m_ofdlgPictureImport
            // 
            resources.ApplyResources(this.m_ofdlgPictureImport, "m_ofdlgPictureImport");
            // 
            // m_sfdlgPictureExport
            // 
            resources.ApplyResources(this.m_sfdlgPictureExport, "m_sfdlgPictureExport");
            // 
            // EditCover
            // 
            this.AcceptButton = this.m_btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.Name = "EditCover";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.m_tsCovers.ResumeLayout(false);
            this.m_tsCovers.PerformLayout();
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlAction.PerformLayout();
            this.m_pnlBase.ResumeLayout(false);
            this.m_pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip m_tsCovers;
        private System.Windows.Forms.ToolStripButton m_btnTools_Bildimport;
        private System.Windows.Forms.ToolStripButton m_btnTools_Bildexport;
        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Panel m_pnlBase;
        private System.Windows.Forms.PictureBox m_picCover;
        private System.Windows.Forms.OpenFileDialog m_ofdlgPictureImport;
        private System.Windows.Forms.SaveFileDialog m_sfdlgPictureExport;
    }
}