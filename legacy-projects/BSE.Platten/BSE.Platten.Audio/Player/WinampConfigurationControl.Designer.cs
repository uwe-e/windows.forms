namespace BSE.Platten.Audio
{
    partial class CWinampConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CWinampConfigurationControl));
            this.m_txtPath = new System.Windows.Forms.TextBox();
            this.m_lblPath = new System.Windows.Forms.Label();
            this.m_btnConfig = new System.Windows.Forms.Button();
            this.m_ofdlgFileSearch = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // m_txtPath
            // 
            this.m_txtPath.AccessibleDescription = null;
            this.m_txtPath.AccessibleName = null;
            resources.ApplyResources(this.m_txtPath, "m_txtPath");
            this.m_txtPath.BackgroundImage = null;
            this.m_txtPath.Font = null;
            this.m_txtPath.Name = "m_txtPath";
            // 
            // m_lblPath
            // 
            this.m_lblPath.AccessibleDescription = null;
            this.m_lblPath.AccessibleName = null;
            resources.ApplyResources(this.m_lblPath, "m_lblPath");
            this.m_lblPath.Font = null;
            this.m_lblPath.Name = "m_lblPath";
            this.m_lblPath.UseMnemonic = false;
            // 
            // m_btnConfig
            // 
            this.m_btnConfig.AccessibleDescription = null;
            this.m_btnConfig.AccessibleName = null;
            resources.ApplyResources(this.m_btnConfig, "m_btnConfig");
            this.m_btnConfig.BackgroundImage = null;
            this.m_btnConfig.Font = null;
            this.m_btnConfig.Name = "m_btnConfig";
            this.m_btnConfig.UseVisualStyleBackColor = true;
            this.m_btnConfig.Click += new System.EventHandler(this.m_btnConfig_Click);
            // 
            // m_ofdlgFileSearch
            // 
            this.m_ofdlgFileSearch.DefaultExt = "*.exe";
            this.m_ofdlgFileSearch.FileName = "Winamp.exe";
            resources.ApplyResources(this.m_ofdlgFileSearch, "m_ofdlgFileSearch");
            this.m_ofdlgFileSearch.InitialDirectory = "c:\\programme\\winamp";
            // 
            // CWinampConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_txtPath);
            this.Controls.Add(this.m_btnConfig);
            this.Controls.Add(this.m_lblPath);
            this.Font = null;
            this.Name = "CWinampConfigurationControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lblPath;
        private System.Windows.Forms.Button m_btnConfig;
        private System.Windows.Forms.OpenFileDialog m_ofdlgFileSearch;
        public System.Windows.Forms.TextBox m_txtPath;
    }
}
