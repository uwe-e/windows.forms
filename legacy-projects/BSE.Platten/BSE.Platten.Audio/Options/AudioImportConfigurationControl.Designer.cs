namespace BSE.Platten.Audio
{
    partial class CAudioImportConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAudioImportConfigurationControl));
            this.m_grpAudioOptions = new System.Windows.Forms.GroupBox();
            this.m_fileOptions = new BSE.Platten.Common.FileConfigurationControl();
            this.m_grpFileOptions = new System.Windows.Forms.GroupBox();
            this.m_chkCopyOrMove = new System.Windows.Forms.CheckBox();
            this.m_grpAudioOptions.SuspendLayout();
            this.m_grpFileOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpAudioOptions
            // 
            this.m_grpAudioOptions.AccessibleDescription = null;
            this.m_grpAudioOptions.AccessibleName = null;
            resources.ApplyResources(this.m_grpAudioOptions, "m_grpAudioOptions");
            this.m_grpAudioOptions.BackgroundImage = null;
            this.m_grpAudioOptions.Controls.Add(this.m_fileOptions);
            this.m_grpAudioOptions.Controls.Add(this.m_grpFileOptions);
            this.m_grpAudioOptions.Font = null;
            this.m_grpAudioOptions.Name = "m_grpAudioOptions";
            this.m_grpAudioOptions.TabStop = false;
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
            this.m_fileOptions.ConfigChanging += new System.EventHandler(this.m_fileOptions_ConfigChange);
            // 
            // m_grpFileOptions
            // 
            this.m_grpFileOptions.AccessibleDescription = null;
            this.m_grpFileOptions.AccessibleName = null;
            resources.ApplyResources(this.m_grpFileOptions, "m_grpFileOptions");
            this.m_grpFileOptions.BackgroundImage = null;
            this.m_grpFileOptions.Controls.Add(this.m_chkCopyOrMove);
            this.m_grpFileOptions.Font = null;
            this.m_grpFileOptions.Name = "m_grpFileOptions";
            this.m_grpFileOptions.TabStop = false;
            // 
            // m_chkCopyOrMove
            // 
            this.m_chkCopyOrMove.AccessibleDescription = null;
            this.m_chkCopyOrMove.AccessibleName = null;
            resources.ApplyResources(this.m_chkCopyOrMove, "m_chkCopyOrMove");
            this.m_chkCopyOrMove.BackgroundImage = null;
            this.m_chkCopyOrMove.Checked = true;
            this.m_chkCopyOrMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCopyOrMove.Font = null;
            this.m_chkCopyOrMove.Name = "m_chkCopyOrMove";
            this.m_chkCopyOrMove.UseVisualStyleBackColor = true;
            this.m_chkCopyOrMove.Click += new System.EventHandler(this.m_chkCopyOrMove_Click);
            // 
            // CAudioImportConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpAudioOptions);
            this.Font = null;
            this.Name = "CAudioImportConfigurationControl";
            this.m_grpAudioOptions.ResumeLayout(false);
            this.m_grpFileOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpAudioOptions;
        private System.Windows.Forms.GroupBox m_grpFileOptions;
        private BSE.Platten.Common.FileConfigurationControl m_fileOptions;
        private System.Windows.Forms.CheckBox m_chkCopyOrMove;
    }
}
