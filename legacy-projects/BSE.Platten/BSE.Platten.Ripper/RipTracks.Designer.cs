namespace BSE.Platten.Ripper
{
    partial class RipTracks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RipTracks));
            this.m_pgTotalTime = new System.Windows.Forms.ProgressBar();
            this.m_lblTotalTrackPercentLabel = new System.Windows.Forms.Label();
            this.m_lblTotalTrackPercentValue = new System.Windows.Forms.Label();
            this.m_pgTime = new System.Windows.Forms.ProgressBar();
            this.m_lblTrackPercentLabel = new System.Windows.Forms.Label();
            this.m_lblTrackPercentValue = new System.Windows.Forms.Label();
            this.m_txtStatus = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.ContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.AccessibleDescription = null;
            this.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackgroundImage = null;
            this.ContentPanel.Controls.Add(this.m_pgTotalTime);
            this.ContentPanel.Controls.Add(this.m_lblTotalTrackPercentLabel);
            this.ContentPanel.Controls.Add(this.m_lblTotalTrackPercentValue);
            this.ContentPanel.Controls.Add(this.m_pgTime);
            this.ContentPanel.Controls.Add(this.m_lblTrackPercentLabel);
            this.ContentPanel.Controls.Add(this.m_lblTrackPercentValue);
            this.ContentPanel.Controls.Add(this.m_txtStatus);
            this.ContentPanel.Controls.Add(this.m_btnCancel);
            this.ContentPanel.Font = null;
            // 
            // m_pgTotalTime
            // 
            this.m_pgTotalTime.AccessibleDescription = null;
            this.m_pgTotalTime.AccessibleName = null;
            resources.ApplyResources(this.m_pgTotalTime, "m_pgTotalTime");
            this.m_pgTotalTime.BackgroundImage = null;
            this.m_pgTotalTime.Font = null;
            this.m_pgTotalTime.Name = "m_pgTotalTime";
            // 
            // m_lblTotalTrackPercentLabel
            // 
            this.m_lblTotalTrackPercentLabel.AccessibleDescription = null;
            this.m_lblTotalTrackPercentLabel.AccessibleName = null;
            resources.ApplyResources(this.m_lblTotalTrackPercentLabel, "m_lblTotalTrackPercentLabel");
            this.m_lblTotalTrackPercentLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTotalTrackPercentLabel.Font = null;
            this.m_lblTotalTrackPercentLabel.Name = "m_lblTotalTrackPercentLabel";
            // 
            // m_lblTotalTrackPercentValue
            // 
            this.m_lblTotalTrackPercentValue.AccessibleDescription = null;
            this.m_lblTotalTrackPercentValue.AccessibleName = null;
            resources.ApplyResources(this.m_lblTotalTrackPercentValue, "m_lblTotalTrackPercentValue");
            this.m_lblTotalTrackPercentValue.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTotalTrackPercentValue.Font = null;
            this.m_lblTotalTrackPercentValue.Name = "m_lblTotalTrackPercentValue";
            // 
            // m_pgTime
            // 
            this.m_pgTime.AccessibleDescription = null;
            this.m_pgTime.AccessibleName = null;
            resources.ApplyResources(this.m_pgTime, "m_pgTime");
            this.m_pgTime.BackgroundImage = null;
            this.m_pgTime.Font = null;
            this.m_pgTime.Name = "m_pgTime";
            // 
            // m_lblTrackPercentLabel
            // 
            this.m_lblTrackPercentLabel.AccessibleDescription = null;
            this.m_lblTrackPercentLabel.AccessibleName = null;
            resources.ApplyResources(this.m_lblTrackPercentLabel, "m_lblTrackPercentLabel");
            this.m_lblTrackPercentLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTrackPercentLabel.Font = null;
            this.m_lblTrackPercentLabel.Name = "m_lblTrackPercentLabel";
            // 
            // m_lblTrackPercentValue
            // 
            this.m_lblTrackPercentValue.AccessibleDescription = null;
            this.m_lblTrackPercentValue.AccessibleName = null;
            resources.ApplyResources(this.m_lblTrackPercentValue, "m_lblTrackPercentValue");
            this.m_lblTrackPercentValue.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTrackPercentValue.Font = null;
            this.m_lblTrackPercentValue.Name = "m_lblTrackPercentValue";
            // 
            // m_txtStatus
            // 
            this.m_txtStatus.AccessibleDescription = null;
            this.m_txtStatus.AccessibleName = null;
            resources.ApplyResources(this.m_txtStatus, "m_txtStatus");
            this.m_txtStatus.BackgroundImage = null;
            this.m_txtStatus.Font = null;
            this.m_txtStatus.Name = "m_txtStatus";
            this.m_txtStatus.ReadOnly = true;
            this.m_txtStatus.TabStop = false;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AccessibleDescription = null;
            this.m_btnCancel.AccessibleName = null;
            resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
            this.m_btnCancel.BackgroundImage = null;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Font = null;
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // RipTracks
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.Name = "RipTracks";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CRipTracks_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CRipTracks_FormClosing);
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar m_pgTotalTime;
        private System.Windows.Forms.Label m_lblTotalTrackPercentLabel;
        private System.Windows.Forms.Label m_lblTotalTrackPercentValue;
        private System.Windows.Forms.ProgressBar m_pgTime;
        private System.Windows.Forms.Label m_lblTrackPercentLabel;
        private System.Windows.Forms.Label m_lblTrackPercentValue;
        private System.Windows.Forms.TextBox m_txtStatus;
        private System.Windows.Forms.Button m_btnCancel;
    }
}