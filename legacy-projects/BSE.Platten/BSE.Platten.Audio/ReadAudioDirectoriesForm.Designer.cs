namespace BSE.Platten.Audio
{
    partial class ReadAudioDirectoriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadAudioDirectoriesForm));
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_lblReaderMessage = new System.Windows.Forms.Label();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.m_lblReaderMessage);
            this.ContentPanel.Controls.Add(this.m_btnCancel);
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_lblReaderMessage
            // 
            resources.ApplyResources(this.m_lblReaderMessage, "m_lblReaderMessage");
            this.m_lblReaderMessage.AutoEllipsis = true;
            this.m_lblReaderMessage.BackColor = System.Drawing.Color.Transparent;
            this.m_lblReaderMessage.Name = "m_lblReaderMessage";
            // 
            // ReadAudioDirectoriesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReadAudioDirectoriesForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CReadAudioDirectories_FormClosing);
            this.Load += new System.EventHandler(this.CReadAudioDirectories_Load);
            this.Controls.SetChildIndex(this.ContentPanel, 0);
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Label m_lblReaderMessage;
    }
}