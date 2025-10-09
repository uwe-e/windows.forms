namespace BSE.Platten.Audio
{
    partial class CPlayerOptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPlayerOptionsDialog));
            this.m_pnlAction = new System.Windows.Forms.Panel();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_grpPlayerProperties = new System.Windows.Forms.GroupBox();
            this.m_pnlBaseContent = new System.Windows.Forms.Panel();
            this.m_pnlAction.SuspendLayout();
            this.m_pnlBaseContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlAction
            // 
            this.m_pnlAction.AccessibleDescription = null;
            this.m_pnlAction.AccessibleName = null;
            resources.ApplyResources(this.m_pnlAction, "m_pnlAction");
            this.m_pnlAction.BackColor = System.Drawing.Color.Transparent;
            this.m_pnlAction.BackgroundImage = null;
            this.m_pnlAction.Controls.Add(this.m_btnOK);
            this.m_pnlAction.Controls.Add(this.m_btnCancel);
            this.m_pnlAction.Font = null;
            this.m_pnlAction.Name = "m_pnlAction";
            // 
            // m_btnOK
            // 
            this.m_btnOK.AccessibleDescription = null;
            this.m_btnOK.AccessibleName = null;
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.BackgroundImage = null;
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Font = null;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AccessibleDescription = null;
            this.m_btnCancel.AccessibleName = null;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.BackgroundImage = null;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Font = null;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // m_grpPlayerProperties
            // 
            this.m_grpPlayerProperties.AccessibleDescription = null;
            this.m_grpPlayerProperties.AccessibleName = null;
            resources.ApplyResources(this.m_grpPlayerProperties, "m_grpPlayerProperties");
            this.m_grpPlayerProperties.BackColor = System.Drawing.Color.Transparent;
            this.m_grpPlayerProperties.BackgroundImage = null;
            this.m_grpPlayerProperties.Font = null;
            this.m_grpPlayerProperties.Name = "m_grpPlayerProperties";
            this.m_grpPlayerProperties.TabStop = false;
            // 
            // m_pnlBaseContent
            // 
            this.m_pnlBaseContent.AccessibleDescription = null;
            this.m_pnlBaseContent.AccessibleName = null;
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            this.m_pnlBaseContent.BackgroundImage = null;
            this.m_pnlBaseContent.Controls.Add(this.m_grpPlayerProperties);
            this.m_pnlBaseContent.Font = null;
            this.m_pnlBaseContent.Name = "m_pnlBaseContent";
            // 
            // CPlayerOptionsDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_pnlBaseContent);
            this.Controls.Add(this.m_pnlAction);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CPlayerOptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.m_pnlAction.ResumeLayout(false);
            this.m_pnlBaseContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_pnlAction;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.GroupBox m_grpPlayerProperties;
        private System.Windows.Forms.Panel m_pnlBaseContent;
    }
}