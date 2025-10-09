namespace BSE.Platten.Audio
{
    partial class OptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.m_audioImportOptions = new BSE.Platten.Audio.CAudioImportConfigurationControl();
            this.m_pnlBaseContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBaseContent
            // 
            this.m_pnlBaseContent.Controls.Add(this.m_audioImportOptions);
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            // 
            // m_audioImportOptions
            // 
            resources.ApplyResources(this.m_audioImportOptions, "m_audioImportOptions");
            this.m_audioImportOptions.EnableAudioImportOptions = true;
            this.m_audioImportOptions.Name = "m_audioImportOptions";
            this.m_audioImportOptions.ConfigChanging += new System.EventHandler(this.m_cAudioOptions_ConfigChange);
            // 
            // COptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "COptions";
            this.m_pnlBaseContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Platten.Audio.CAudioImportConfigurationControl m_audioImportOptions;
    }
}