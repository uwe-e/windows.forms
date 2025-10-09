namespace BSE.Platten.Admin
{
    partial class EditLieder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLieder));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_pnlBase = new System.Windows.Forms.Panel();
            this.m_grpLieder = new System.Windows.Forms.GroupBox();
            this.m_btnFindFile = new System.Windows.Forms.Button();
            this.m_txtLied = new System.Windows.Forms.TextBox();
            this.m_lblLied = new System.Windows.Forms.Label();
            this.m_txtFile = new System.Windows.Forms.TextBox();
            this.m_lblFile = new System.Windows.Forms.Label();
            this.m_txtDuration = new System.Windows.Forms.TextBox();
            this.m_lblDuration = new System.Windows.Forms.Label();
            this.m_txtTrack = new System.Windows.Forms.TextBox();
            this.m_lblTrack = new System.Windows.Forms.Label();
            this.m_txtLiedId = new System.Windows.Forms.TextBox();
            this.m_lblLiedId = new System.Windows.Forms.Label();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_ofdlgFileImport = new System.Windows.Forms.OpenFileDialog();
            this.ContentPanel.SuspendLayout();
            this.m_pnlAction.SuspendLayout();
            this.m_pnlBase.SuspendLayout();
            this.m_grpLieder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.m_pnlBase);
            this.ContentPanel.Controls.Add(this.m_pnlAction);
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
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.BtnOKClick);
            // 
            // m_pnlBase
            // 
            this.m_pnlBase.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlBase.Controls.Add(this.m_grpLieder);
            resources.ApplyResources(this.m_pnlBase, "m_pnlBase");
            this.m_pnlBase.Name = "m_pnlBase";
            // 
            // m_grpLieder
            // 
            this.m_grpLieder.Controls.Add(this.m_btnFindFile);
            this.m_grpLieder.Controls.Add(this.m_txtLied);
            this.m_grpLieder.Controls.Add(this.m_lblLied);
            this.m_grpLieder.Controls.Add(this.m_txtFile);
            this.m_grpLieder.Controls.Add(this.m_lblFile);
            this.m_grpLieder.Controls.Add(this.m_txtDuration);
            this.m_grpLieder.Controls.Add(this.m_lblDuration);
            this.m_grpLieder.Controls.Add(this.m_txtTrack);
            this.m_grpLieder.Controls.Add(this.m_lblTrack);
            this.m_grpLieder.Controls.Add(this.m_txtLiedId);
            this.m_grpLieder.Controls.Add(this.m_lblLiedId);
            resources.ApplyResources(this.m_grpLieder, "m_grpLieder");
            this.m_grpLieder.Name = "m_grpLieder";
            this.m_grpLieder.TabStop = false;
            // 
            // m_btnFindFile
            // 
            resources.ApplyResources(this.m_btnFindFile, "m_btnFindFile");
            this.m_btnFindFile.Image = global::BSE.Platten.Admin.Properties.Resources.findfile;
            this.m_btnFindFile.Name = "m_btnFindFile";
            this.m_btnFindFile.UseVisualStyleBackColor = true;
            this.m_btnFindFile.Click += new System.EventHandler(this.FindFileClick);
            // 
            // m_txtLied
            // 
            resources.ApplyResources(this.m_txtLied, "m_txtLied");
            this.m_txtLied.Name = "m_txtLied";
            // 
            // m_lblLied
            // 
            resources.ApplyResources(this.m_lblLied, "m_lblLied");
            this.m_lblLied.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblLied.Name = "m_lblLied";
            // 
            // m_txtFile
            // 
            resources.ApplyResources(this.m_txtFile, "m_txtFile");
            this.m_txtFile.Name = "m_txtFile";
            this.m_txtFile.ReadOnly = true;
            this.m_txtFile.TextChanged += new System.EventHandler(this.FileTextChanged);
            // 
            // m_lblFile
            // 
            resources.ApplyResources(this.m_lblFile, "m_lblFile");
            this.m_lblFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblFile.Name = "m_lblFile";
            // 
            // m_txtDuration
            // 
            resources.ApplyResources(this.m_txtDuration, "m_txtDuration");
            this.m_txtDuration.Name = "m_txtDuration";
            this.m_txtDuration.ReadOnly = true;
            // 
            // m_lblDuration
            // 
            resources.ApplyResources(this.m_lblDuration, "m_lblDuration");
            this.m_lblDuration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblDuration.Name = "m_lblDuration";
            // 
            // m_txtTrack
            // 
            resources.ApplyResources(this.m_txtTrack, "m_txtTrack");
            this.m_txtTrack.Name = "m_txtTrack";
            this.m_txtTrack.ReadOnly = true;
            // 
            // m_lblTrack
            // 
            resources.ApplyResources(this.m_lblTrack, "m_lblTrack");
            this.m_lblTrack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblTrack.Name = "m_lblTrack";
            // 
            // m_txtLiedId
            // 
            resources.ApplyResources(this.m_txtLiedId, "m_txtLiedId");
            this.m_txtLiedId.Name = "m_txtLiedId";
            this.m_txtLiedId.ReadOnly = true;
            // 
            // m_lblLiedId
            // 
            resources.ApplyResources(this.m_lblLiedId, "m_lblLiedId");
            this.m_lblLiedId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblLiedId.Name = "m_lblLiedId";
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // m_ofdlgFileImport
            // 
            resources.ApplyResources(this.m_ofdlgFileImport, "m_ofdlgFileImport");
            // 
            // EditLieder
            // 
            this.AcceptButton = this.m_btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.Name = "EditLieder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlBase.ResumeLayout(false);
            this.m_grpLieder.ResumeLayout(false);
            this.m_grpLieder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Panel m_pnlBase;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.GroupBox m_grpLieder;
        private System.Windows.Forms.TextBox m_txtLied;
        private System.Windows.Forms.Label m_lblLied;
        private System.Windows.Forms.TextBox m_txtDuration;
        private System.Windows.Forms.Label m_lblDuration;
        private System.Windows.Forms.TextBox m_txtTrack;
        private System.Windows.Forms.Label m_lblTrack;
        private System.Windows.Forms.TextBox m_txtLiedId;
        private System.Windows.Forms.Label m_lblLiedId;
        private System.Windows.Forms.TextBox m_txtFile;
        private System.Windows.Forms.Label m_lblFile;
        private System.Windows.Forms.Button m_btnFindFile;
        private System.Windows.Forms.ErrorProvider m_errorProvider;
        private System.Windows.Forms.OpenFileDialog m_ofdlgFileImport;
    }
}