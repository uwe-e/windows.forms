namespace BSE.Platten.Audio
{
    partial class CPlayerConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPlayerConfigurationControl));
            this.m_grpPlayerOptions = new System.Windows.Forms.GroupBox();
            this.m_grpPlayerProperties = new System.Windows.Forms.GroupBox();
            this.m_grpUsedPlayer = new System.Windows.Forms.GroupBox();
            this.m_btnConfigPlayer = new System.Windows.Forms.Button();
            this.m_cboPlayers = new System.Windows.Forms.ComboBox();
            this.m_grpPlayerOptions.SuspendLayout();
            this.m_grpUsedPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpPlayerOptions
            // 
            this.m_grpPlayerOptions.AccessibleDescription = null;
            this.m_grpPlayerOptions.AccessibleName = null;
            resources.ApplyResources(this.m_grpPlayerOptions, "m_grpPlayerOptions");
            this.m_grpPlayerOptions.BackgroundImage = null;
            this.m_grpPlayerOptions.Controls.Add(this.m_grpPlayerProperties);
            this.m_grpPlayerOptions.Controls.Add(this.m_grpUsedPlayer);
            this.m_grpPlayerOptions.Font = null;
            this.m_grpPlayerOptions.Name = "m_grpPlayerOptions";
            this.m_grpPlayerOptions.TabStop = false;
            // 
            // m_grpPlayerProperties
            // 
            this.m_grpPlayerProperties.AccessibleDescription = null;
            this.m_grpPlayerProperties.AccessibleName = null;
            resources.ApplyResources(this.m_grpPlayerProperties, "m_grpPlayerProperties");
            this.m_grpPlayerProperties.BackgroundImage = null;
            this.m_grpPlayerProperties.Font = null;
            this.m_grpPlayerProperties.Name = "m_grpPlayerProperties";
            this.m_grpPlayerProperties.TabStop = false;
            // 
            // m_grpUsedPlayer
            // 
            this.m_grpUsedPlayer.AccessibleDescription = null;
            this.m_grpUsedPlayer.AccessibleName = null;
            resources.ApplyResources(this.m_grpUsedPlayer, "m_grpUsedPlayer");
            this.m_grpUsedPlayer.BackgroundImage = null;
            this.m_grpUsedPlayer.Controls.Add(this.m_btnConfigPlayer);
            this.m_grpUsedPlayer.Controls.Add(this.m_cboPlayers);
            this.m_grpUsedPlayer.Font = null;
            this.m_grpUsedPlayer.Name = "m_grpUsedPlayer";
            this.m_grpUsedPlayer.TabStop = false;
            // 
            // m_btnConfigPlayer
            // 
            this.m_btnConfigPlayer.AccessibleDescription = null;
            this.m_btnConfigPlayer.AccessibleName = null;
            resources.ApplyResources(this.m_btnConfigPlayer, "m_btnConfigPlayer");
            this.m_btnConfigPlayer.BackgroundImage = null;
            this.m_btnConfigPlayer.Font = null;
            this.m_btnConfigPlayer.Name = "m_btnConfigPlayer";
            this.m_btnConfigPlayer.UseVisualStyleBackColor = true;
            this.m_btnConfigPlayer.Click += new System.EventHandler(this.m_btnConfigPlayer_Click);
            // 
            // m_cboPlayers
            // 
            this.m_cboPlayers.AccessibleDescription = null;
            this.m_cboPlayers.AccessibleName = null;
            resources.ApplyResources(this.m_cboPlayers, "m_cboPlayers");
            this.m_cboPlayers.BackgroundImage = null;
            this.m_cboPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPlayers.Font = null;
            this.m_cboPlayers.FormattingEnabled = true;
            this.m_cboPlayers.Name = "m_cboPlayers";
            this.m_cboPlayers.SelectedValueChanged += new System.EventHandler(this.m_cboPlayers_SelectedValueChanged);
            this.m_cboPlayers.Click += new System.EventHandler(this.m_cboPlayers_Click);
            // 
            // CPlayerConfigurationControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpPlayerOptions);
            this.Font = null;
            this.Name = "CPlayerConfigurationControl";
            this.m_grpPlayerOptions.ResumeLayout(false);
            this.m_grpUsedPlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpPlayerOptions;
        private System.Windows.Forms.GroupBox m_grpUsedPlayer;
        private System.Windows.Forms.ComboBox m_cboPlayers;
        private System.Windows.Forms.Button m_btnConfigPlayer;
        private System.Windows.Forms.GroupBox m_grpPlayerProperties;
    }
}
