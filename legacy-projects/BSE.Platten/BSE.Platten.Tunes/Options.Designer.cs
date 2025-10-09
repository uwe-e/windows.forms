namespace BSE.Platten.Tunes
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.m_tabPageResourcen = new System.Windows.Forms.TabPage();
            this.m_grpCoverflow = new System.Windows.Forms.GroupBox();
            this.m_btnClearCoverflowCache = new System.Windows.Forms.Button();
            this.m_tabPageEinstellungen = new System.Windows.Forms.TabPage();
            this.m_visualConfiguration = new BSE.Configuration.VisualConfiguration();
            this.m_tabOptionen = new System.Windows.Forms.TabControl();
            this.m_pnlBaseContent.SuspendLayout();
            this.m_tabPageResourcen.SuspendLayout();
            this.m_grpCoverflow.SuspendLayout();
            this.m_tabPageEinstellungen.SuspendLayout();
            this.m_tabOptionen.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBaseContent
            // 
            this.m_pnlBaseContent.Controls.Add(this.m_tabOptionen);
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            // 
            // m_tabPageResourcen
            // 
            this.m_tabPageResourcen.Controls.Add(this.m_grpCoverflow);
            resources.ApplyResources(this.m_tabPageResourcen, "m_tabPageResourcen");
            this.m_tabPageResourcen.Name = "m_tabPageResourcen";
            this.m_tabPageResourcen.UseVisualStyleBackColor = true;
            // 
            // m_grpCoverflow
            // 
            this.m_grpCoverflow.Controls.Add(this.m_btnClearCoverflowCache);
            resources.ApplyResources(this.m_grpCoverflow, "m_grpCoverflow");
            this.m_grpCoverflow.Name = "m_grpCoverflow";
            this.m_grpCoverflow.TabStop = false;
            // 
            // m_btnClearCoverflowCache
            // 
            resources.ApplyResources(this.m_btnClearCoverflowCache, "m_btnClearCoverflowCache");
            this.m_btnClearCoverflowCache.Name = "m_btnClearCoverflowCache";
            this.m_btnClearCoverflowCache.UseVisualStyleBackColor = true;
            this.m_btnClearCoverflowCache.Click += new System.EventHandler(this.ButtonClearCoverflowCacheClick);
            // 
            // m_tabPageEinstellungen
            // 
            this.m_tabPageEinstellungen.Controls.Add(this.m_visualConfiguration);
            resources.ApplyResources(this.m_tabPageEinstellungen, "m_tabPageEinstellungen");
            this.m_tabPageEinstellungen.Name = "m_tabPageEinstellungen";
            this.m_tabPageEinstellungen.UseVisualStyleBackColor = true;
            // 
            // m_visualConfiguration
            // 
            this.m_visualConfiguration.Configuration = null;
            resources.ApplyResources(this.m_visualConfiguration, "m_visualConfiguration");
            this.m_visualConfiguration.FolderBrowserDialogDescription = null;
            this.m_visualConfiguration.Name = "m_visualConfiguration";
            this.m_visualConfiguration.ConfigurationChanged += new System.EventHandler<BSE.Configuration.ConfigChangeEventArgs>(this.VisualConfigurationChanged);
            // 
            // m_tabOptionen
            // 
            this.m_tabOptionen.Controls.Add(this.m_tabPageEinstellungen);
            this.m_tabOptionen.Controls.Add(this.m_tabPageResourcen);
            resources.ApplyResources(this.m_tabOptionen, "m_tabOptionen");
            this.m_tabOptionen.Name = "m_tabOptionen";
            this.m_tabOptionen.SelectedIndex = 0;
            // 
            // Options
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "Options";
            this.UseAsStandardDialog = false;
            this.Load += new System.EventHandler(this.COptions_Load);
            this.m_pnlBaseContent.ResumeLayout(false);
            this.m_tabPageResourcen.ResumeLayout(false);
            this.m_grpCoverflow.ResumeLayout(false);
            this.m_tabPageEinstellungen.ResumeLayout(false);
            this.m_tabOptionen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_tabOptionen;
        private System.Windows.Forms.TabPage m_tabPageEinstellungen;
        private Configuration.VisualConfiguration m_visualConfiguration;
        private System.Windows.Forms.TabPage m_tabPageResourcen;
        private System.Windows.Forms.GroupBox m_grpCoverflow;
        private System.Windows.Forms.Button m_btnClearCoverflowCache;

    }
}