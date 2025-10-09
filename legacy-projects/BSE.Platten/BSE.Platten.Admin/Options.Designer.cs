namespace BSE.Platten.Admin
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
            this.m_tabPageAudioOptions = new System.Windows.Forms.TabPage();
            this.m_audioImportOptions = new BSE.Platten.Audio.CAudioImportConfigurationControl();
            this.m_tabPageRippingOptions = new System.Windows.Forms.TabPage();
            this.m_rippingOptions = new BSE.Platten.Ripper.RippingConfigurationControl();
            this.m_tabPageSaveOptions = new System.Windows.Forms.TabPage();
            this.m_audioSaveOptions = new BSE.Platten.Admin.AudioSaveConfigurationControl();
            this.m_tabPageEinstellungen = new System.Windows.Forms.TabPage();
            this.m_visualConfiguration = new BSE.Configuration.VisualConfiguration();
            this.m_tabOptionen = new System.Windows.Forms.TabControl();
            this.m_pnlBaseContent.SuspendLayout();
            this.m_tabPageAudioOptions.SuspendLayout();
            this.m_tabPageRippingOptions.SuspendLayout();
            this.m_tabPageSaveOptions.SuspendLayout();
            this.m_tabPageEinstellungen.SuspendLayout();
            this.m_tabOptionen.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBaseContent
            // 
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            this.m_pnlBaseContent.Controls.Add(this.m_tabOptionen);
            // 
            // m_tabPageAudioOptions
            // 
            resources.ApplyResources(this.m_tabPageAudioOptions, "m_tabPageAudioOptions");
            this.m_tabPageAudioOptions.Controls.Add(this.m_audioImportOptions);
            this.m_tabPageAudioOptions.Name = "m_tabPageAudioOptions";
            this.m_tabPageAudioOptions.UseVisualStyleBackColor = true;
            // 
            // m_audioImportOptions
            // 
            resources.ApplyResources(this.m_audioImportOptions, "m_audioImportOptions");
            this.m_audioImportOptions.EnableAudioImportOptions = true;
            this.m_audioImportOptions.Name = "m_audioImportOptions";
            this.m_audioImportOptions.ConfigChanging += new System.EventHandler(this.m_audioImportOptions_ConfigChange);
            // 
            // m_tabPageRippingOptions
            // 
            resources.ApplyResources(this.m_tabPageRippingOptions, "m_tabPageRippingOptions");
            this.m_tabPageRippingOptions.Controls.Add(this.m_rippingOptions);
            this.m_tabPageRippingOptions.Name = "m_tabPageRippingOptions";
            this.m_tabPageRippingOptions.UseVisualStyleBackColor = true;
            // 
            // m_rippingOptions
            // 
            resources.ApplyResources(this.m_rippingOptions, "m_rippingOptions");
            this.m_rippingOptions.EnableAudioSaveOptions = true;
            this.m_rippingOptions.Name = "m_rippingOptions";
            this.m_rippingOptions.ConfigChanging += new System.EventHandler(this.m_rippingOptions_ConfigChange);
            // 
            // m_tabPageSaveOptions
            // 
            resources.ApplyResources(this.m_tabPageSaveOptions, "m_tabPageSaveOptions");
            this.m_tabPageSaveOptions.Controls.Add(this.m_audioSaveOptions);
            this.m_tabPageSaveOptions.Name = "m_tabPageSaveOptions";
            this.m_tabPageSaveOptions.UseVisualStyleBackColor = true;
            // 
            // m_audioSaveOptions
            // 
            resources.ApplyResources(this.m_audioSaveOptions, "m_audioSaveOptions");
            this.m_audioSaveOptions.Name = "m_audioSaveOptions";
            this.m_audioSaveOptions.SaveCheckBoxChanged += new System.EventHandler<BSE.Platten.Common.CheckBoxChangeEventArgs>(this.m_audioSaveOptions_SaveCheckBoxChanged);
            this.m_audioSaveOptions.ConfigChanging += new System.EventHandler(this.m_audioSaveOptions_ConfigChange);
            // 
            // m_tabPageEinstellungen
            // 
            resources.ApplyResources(this.m_tabPageEinstellungen, "m_tabPageEinstellungen");
            this.m_tabPageEinstellungen.Controls.Add(this.m_visualConfiguration);
            this.m_tabPageEinstellungen.Name = "m_tabPageEinstellungen";
            this.m_tabPageEinstellungen.UseVisualStyleBackColor = true;
            // 
            // m_visualConfiguration
            // 
            resources.ApplyResources(this.m_visualConfiguration, "m_visualConfiguration");
            this.m_visualConfiguration.Configuration = null;
            this.m_visualConfiguration.FolderBrowserDialogDescription = null;
            this.m_visualConfiguration.Name = "m_visualConfiguration";
            this.m_visualConfiguration.ConfigurationChanged += new System.EventHandler<BSE.Configuration.ConfigChangeEventArgs>(this.m_visualConfiguration_ConfigurationChanged);
            // 
            // m_tabOptionen
            // 
            resources.ApplyResources(this.m_tabOptionen, "m_tabOptionen");
            this.m_tabOptionen.Controls.Add(this.m_tabPageEinstellungen);
            this.m_tabOptionen.Controls.Add(this.m_tabPageSaveOptions);
            this.m_tabOptionen.Controls.Add(this.m_tabPageRippingOptions);
            this.m_tabOptionen.Controls.Add(this.m_tabPageAudioOptions);
            this.m_tabOptionen.Multiline = true;
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
            this.m_tabPageAudioOptions.ResumeLayout(false);
            this.m_tabPageRippingOptions.ResumeLayout(false);
            this.m_tabPageSaveOptions.ResumeLayout(false);
            this.m_tabPageEinstellungen.ResumeLayout(false);
            this.m_tabOptionen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_tabOptionen;
        private System.Windows.Forms.TabPage m_tabPageEinstellungen;
        private Configuration.VisualConfiguration m_visualConfiguration;
        private System.Windows.Forms.TabPage m_tabPageSaveOptions;
        private AudioSaveConfigurationControl m_audioSaveOptions;
        private System.Windows.Forms.TabPage m_tabPageRippingOptions;
        private Ripper.RippingConfigurationControl m_rippingOptions;
        private System.Windows.Forms.TabPage m_tabPageAudioOptions;
        private Audio.CAudioImportConfigurationControl m_audioImportOptions;
    }
}