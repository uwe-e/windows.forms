namespace BSE.Platten.Ripper
{
    partial class MP3ConfigurationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MP3ConfigurationControl));
            this.m_grpAudioFormat = new System.Windows.Forms.GroupBox();
            this.m_grpStereoMode = new System.Windows.Forms.GroupBox();
            this.m_rdo2ChannelStereo = new System.Windows.Forms.RadioButton();
            this.m_rdoJointStereo = new System.Windows.Forms.RadioButton();
            this.m_cboBitRate = new System.Windows.Forms.ComboBox();
            this.m_lblBitRate = new System.Windows.Forms.Label();
            this.m_grpAudioFormat.SuspendLayout();
            this.m_grpStereoMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpAudioFormat
            // 
            resources.ApplyResources(this.m_grpAudioFormat, "m_grpAudioFormat");
            this.m_grpAudioFormat.Controls.Add(this.m_grpStereoMode);
            this.m_grpAudioFormat.Controls.Add(this.m_cboBitRate);
            this.m_grpAudioFormat.Controls.Add(this.m_lblBitRate);
            this.m_grpAudioFormat.Name = "m_grpAudioFormat";
            this.m_grpAudioFormat.TabStop = false;
            // 
            // m_grpStereoMode
            // 
            resources.ApplyResources(this.m_grpStereoMode, "m_grpStereoMode");
            this.m_grpStereoMode.Controls.Add(this.m_rdo2ChannelStereo);
            this.m_grpStereoMode.Controls.Add(this.m_rdoJointStereo);
            this.m_grpStereoMode.Name = "m_grpStereoMode";
            this.m_grpStereoMode.TabStop = false;
            // 
            // m_rdo2ChannelStereo
            // 
            resources.ApplyResources(this.m_rdo2ChannelStereo, "m_rdo2ChannelStereo");
            this.m_rdo2ChannelStereo.Name = "m_rdo2ChannelStereo";
            this.m_rdo2ChannelStereo.TabStop = true;
            this.m_rdo2ChannelStereo.UseVisualStyleBackColor = true;
            // 
            // m_rdoJointStereo
            // 
            resources.ApplyResources(this.m_rdoJointStereo, "m_rdoJointStereo");
            this.m_rdoJointStereo.Name = "m_rdoJointStereo";
            this.m_rdoJointStereo.TabStop = true;
            this.m_rdoJointStereo.UseVisualStyleBackColor = true;
            // 
            // m_cboBitRate
            // 
            resources.ApplyResources(this.m_cboBitRate, "m_cboBitRate");
            this.m_cboBitRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboBitRate.FormattingEnabled = true;
            this.m_cboBitRate.Name = "m_cboBitRate";
            // 
            // m_lblBitRate
            // 
            resources.ApplyResources(this.m_lblBitRate, "m_lblBitRate");
            this.m_lblBitRate.Name = "m_lblBitRate";
            // 
            // MP3ConfigurationControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_grpAudioFormat);
            this.Name = "MP3ConfigurationControl";
            this.m_grpAudioFormat.ResumeLayout(false);
            this.m_grpAudioFormat.PerformLayout();
            this.m_grpStereoMode.ResumeLayout(false);
            this.m_grpStereoMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpAudioFormat;
        private System.Windows.Forms.ComboBox m_cboBitRate;
        private System.Windows.Forms.Label m_lblBitRate;
        private System.Windows.Forms.GroupBox m_grpStereoMode;
        private System.Windows.Forms.RadioButton m_rdo2ChannelStereo;
        private System.Windows.Forms.RadioButton m_rdoJointStereo;
    }
}
