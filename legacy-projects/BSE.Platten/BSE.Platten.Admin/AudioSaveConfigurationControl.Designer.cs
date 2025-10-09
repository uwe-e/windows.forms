namespace BSE.Platten.Admin
{
    partial class AudioSaveConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioSaveConfigurationControl));
            this.m_grpAudioSaveOptions = new System.Windows.Forms.GroupBox();
            this.m_fileOptions = new BSE.Platten.Common.FileConfigurationControl();
            this.m_grpAudioSaveOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpAudioSaveOptions
            // 
            this.m_grpAudioSaveOptions.AccessibleDescription = null;
            this.m_grpAudioSaveOptions.AccessibleName = null;
            resources.ApplyResources(this.m_grpAudioSaveOptions, "m_grpAudioSaveOptions");
            this.m_grpAudioSaveOptions.BackgroundImage = null;
            this.m_grpAudioSaveOptions.Controls.Add(this.m_fileOptions);
            this.m_grpAudioSaveOptions.Font = null;
            this.m_grpAudioSaveOptions.Name = "m_grpAudioSaveOptions";
            this.m_grpAudioSaveOptions.TabStop = false;
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
            this.m_fileOptions.CheckBoxChanged += new System.EventHandler<BSE.Platten.Common.CheckBoxChangeEventArgs>(this.m_fileOptions_CheckBoxChanged);
            this.m_fileOptions.ConfigChanging += new System.EventHandler(this.m_fileOptions_ConfigChange);
            // 
            // AudioSaveConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpAudioSaveOptions);
            this.Font = null;
            this.Name = "AudioSaveConfigurationControl";
            this.m_grpAudioSaveOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpAudioSaveOptions;
        private BSE.Platten.Common.FileConfigurationControl m_fileOptions;

    }
}
