namespace BSE.Platten.Audio
{
    partial class TagForm
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
                this.m_tagWriter.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagForm));
            this.m_prgsTotalTime = new System.Windows.Forms.ProgressBar();
            this.m_txtStatus = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlContent
            // 
            this.ContentPanel.Controls.Add(this.m_btnCancel);
            this.ContentPanel.Controls.Add(this.m_txtStatus);
            this.ContentPanel.Controls.Add(this.m_prgsTotalTime);
            resources.ApplyResources(this.ContentPanel, "m_pnlContent");
            // 
            // m_prgsTotalTime
            // 
            resources.ApplyResources(this.m_prgsTotalTime, "m_prgsTotalTime");
            this.m_prgsTotalTime.Name = "m_prgsTotalTime";
            // 
            // m_txtStatus
            // 
            resources.ApplyResources(this.m_txtStatus, "m_txtStatus");
            this.m_txtStatus.Name = "m_txtStatus";
            this.m_txtStatus.ReadOnly = true;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // CTagger
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CTagger";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CTagger_FormClosing);
            this.Load += new System.EventHandler(this.CTagger_Load);
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar m_prgsTotalTime;
        private System.Windows.Forms.TextBox m_txtStatus;
        private System.Windows.Forms.Button m_btnCancel;
    }
}