namespace BSE.Platten.Ripper
{
    partial class RippingConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RippingConfigurationControl));
            this.m_grpRippingOptions = new System.Windows.Forms.GroupBox();
            this.m_fileOptions = new BSE.Platten.Common.FileConfigurationControl();
            this.m_grpFormat = new System.Windows.Forms.GroupBox();
            this.m_btnConfigFormat = new System.Windows.Forms.Button();
            this.m_cboFormats = new System.Windows.Forms.ComboBox();
            this.m_grpRippingOptions.SuspendLayout();
            this.m_grpFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpRippingOptions
            // 
            this.m_grpRippingOptions.AccessibleDescription = null;
            this.m_grpRippingOptions.AccessibleName = null;
            resources.ApplyResources(this.m_grpRippingOptions, "m_grpRippingOptions");
            this.m_grpRippingOptions.BackgroundImage = null;
            this.m_grpRippingOptions.Controls.Add(this.m_fileOptions);
            this.m_grpRippingOptions.Controls.Add(this.m_grpFormat);
            this.m_grpRippingOptions.Font = null;
            this.m_grpRippingOptions.Name = "m_grpRippingOptions";
            this.m_grpRippingOptions.TabStop = false;
            // 
            // m_fileOptions
            // 
            this.m_fileOptions.AccessibleDescription = null;
            this.m_fileOptions.AccessibleName = null;
            resources.ApplyResources(this.m_fileOptions, "m_fileOptions");
            this.m_fileOptions.BackgroundImage = null;
            this.m_fileOptions.EnableEditSaveOptions = true;
            this.m_fileOptions.Font = null;
            this.m_fileOptions.Name = "m_fileOptions";
            this.m_fileOptions.ConfigChanging += new System.EventHandler(this.m_audioSaveOptions_ConfigChange);
            // 
            // m_grpFormat
            // 
            this.m_grpFormat.AccessibleDescription = null;
            this.m_grpFormat.AccessibleName = null;
            resources.ApplyResources(this.m_grpFormat, "m_grpFormat");
            this.m_grpFormat.BackgroundImage = null;
            this.m_grpFormat.Controls.Add(this.m_btnConfigFormat);
            this.m_grpFormat.Controls.Add(this.m_cboFormats);
            this.m_grpFormat.Font = null;
            this.m_grpFormat.Name = "m_grpFormat";
            this.m_grpFormat.TabStop = false;
            // 
            // m_btnConfigFormat
            // 
            this.m_btnConfigFormat.AccessibleDescription = null;
            this.m_btnConfigFormat.AccessibleName = null;
            resources.ApplyResources(this.m_btnConfigFormat, "m_btnConfigFormat");
            this.m_btnConfigFormat.BackgroundImage = null;
            this.m_btnConfigFormat.Font = null;
            this.m_btnConfigFormat.Name = "m_btnConfigFormat";
            this.m_btnConfigFormat.UseVisualStyleBackColor = true;
            this.m_btnConfigFormat.Click += new System.EventHandler(this.m_btnConfigFormat_Click);
            // 
            // m_cboFormats
            // 
            this.m_cboFormats.AccessibleDescription = null;
            this.m_cboFormats.AccessibleName = null;
            resources.ApplyResources(this.m_cboFormats, "m_cboFormats");
            this.m_cboFormats.BackgroundImage = null;
            this.m_cboFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFormats.Font = null;
            this.m_cboFormats.FormattingEnabled = true;
            this.m_cboFormats.Name = "m_cboFormats";
            this.m_cboFormats.Click += new System.EventHandler(this.m_cboFormats_Click);
            // 
            // RippingConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpRippingOptions);
            this.Font = null;
            this.Name = "RippingConfigurationControl";
            this.m_grpRippingOptions.ResumeLayout(false);
            this.m_grpFormat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpRippingOptions;
        private System.Windows.Forms.GroupBox m_grpFormat;
        private BSE.Platten.Common.FileConfigurationControl m_fileOptions;
        private System.Windows.Forms.Button m_btnConfigFormat;
        private System.Windows.Forms.ComboBox m_cboFormats;
    }
}
