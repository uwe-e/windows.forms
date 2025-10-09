namespace BSE.Platten.Ripper
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
            this.m_rippingOptions = new BSE.Platten.Ripper.RippingConfigurationControl();
            this.m_pnlBaseContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBaseContent
            // 
            this.m_pnlBaseContent.AccessibleDescription = null;
            this.m_pnlBaseContent.AccessibleName = null;
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            this.m_pnlBaseContent.BackgroundImage = null;
            this.m_pnlBaseContent.Controls.Add(this.m_rippingOptions);
            this.m_pnlBaseContent.Font = null;
            // 
            // m_rippingOptions
            // 
            this.m_rippingOptions.AccessibleDescription = null;
            this.m_rippingOptions.AccessibleName = null;
            resources.ApplyResources(this.m_rippingOptions, "m_rippingOptions");
            this.m_rippingOptions.BackgroundImage = null;
            this.m_rippingOptions.EnableAudioSaveOptions = true;
            this.m_rippingOptions.Font = null;
            this.m_rippingOptions.Name = "m_rippingOptions";
            this.m_rippingOptions.ConfigChanging += new System.EventHandler(this.m_rippingOptions_ConfigChange);
            // 
            // OptionsDialog
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Icon = null;
            this.Name = "OptionsDialog";
            this.m_pnlBaseContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RippingConfigurationControl m_rippingOptions;

    }
}