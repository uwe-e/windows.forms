namespace BSE.Platten.Common
{
    partial class FileConfigurationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileConfigurationControl));
            this.m_grpDirectoryInfo = new System.Windows.Forms.GroupBox();
            this.m_chkTitleAsFileName = new System.Windows.Forms.CheckBox();
            this.m_chkEachAlbumGetsDirectory = new System.Windows.Forms.CheckBox();
            this.m_grpDirectoryInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpDirectoryInfo
            // 
            this.m_grpDirectoryInfo.AccessibleDescription = null;
            this.m_grpDirectoryInfo.AccessibleName = null;
            resources.ApplyResources(this.m_grpDirectoryInfo, "m_grpDirectoryInfo");
            this.m_grpDirectoryInfo.BackgroundImage = null;
            this.m_grpDirectoryInfo.Controls.Add(this.m_chkTitleAsFileName);
            this.m_grpDirectoryInfo.Controls.Add(this.m_chkEachAlbumGetsDirectory);
            this.m_grpDirectoryInfo.Font = null;
            this.m_grpDirectoryInfo.Name = "m_grpDirectoryInfo";
            this.m_grpDirectoryInfo.TabStop = false;
            // 
            // m_chkTitleAsFileName
            // 
            this.m_chkTitleAsFileName.AccessibleDescription = null;
            this.m_chkTitleAsFileName.AccessibleName = null;
            resources.ApplyResources(this.m_chkTitleAsFileName, "m_chkTitleAsFileName");
            this.m_chkTitleAsFileName.BackgroundImage = null;
            this.m_chkTitleAsFileName.Font = null;
            this.m_chkTitleAsFileName.Name = "m_chkTitleAsFileName";
            this.m_chkTitleAsFileName.UseVisualStyleBackColor = true;
            this.m_chkTitleAsFileName.Click += new System.EventHandler(this.Checkbox_Click);
            // 
            // m_chkEachAlbumGetsDirectory
            // 
            this.m_chkEachAlbumGetsDirectory.AccessibleDescription = null;
            this.m_chkEachAlbumGetsDirectory.AccessibleName = null;
            resources.ApplyResources(this.m_chkEachAlbumGetsDirectory, "m_chkEachAlbumGetsDirectory");
            this.m_chkEachAlbumGetsDirectory.BackgroundImage = null;
            this.m_chkEachAlbumGetsDirectory.Checked = true;
            this.m_chkEachAlbumGetsDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkEachAlbumGetsDirectory.Font = null;
            this.m_chkEachAlbumGetsDirectory.Name = "m_chkEachAlbumGetsDirectory";
            this.m_chkEachAlbumGetsDirectory.UseVisualStyleBackColor = true;
            this.m_chkEachAlbumGetsDirectory.Click += new System.EventHandler(this.Checkbox_Click);
            // 
            // FileConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpDirectoryInfo);
            this.Font = null;
            this.Name = "FileConfigurationControl";
            this.m_grpDirectoryInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpDirectoryInfo;
        private System.Windows.Forms.CheckBox m_chkTitleAsFileName;
        private System.Windows.Forms.CheckBox m_chkEachAlbumGetsDirectory;
    }
}
