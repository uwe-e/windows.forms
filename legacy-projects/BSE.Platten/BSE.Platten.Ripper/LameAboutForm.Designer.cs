namespace BSE.Platten.Ripper
{
    partial class LameAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LameAboutForm));
            this.m_grpLameAbout = new System.Windows.Forms.GroupBox();
            this.m_lnkLameHomepage = new System.Windows.Forms.LinkLabel();
            this.m_lblLameHomepage = new System.Windows.Forms.Label();
            this.m_lblReleaseDate = new System.Windows.Forms.Label();
            this.m_lblEncodingEngineVersion = new System.Windows.Forms.Label();
            this.m_lblDllVersion = new System.Windows.Forms.Label();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_grpLameAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grpLameAbout
            // 
            this.m_grpLameAbout.AccessibleDescription = null;
            this.m_grpLameAbout.AccessibleName = null;
            resources.ApplyResources(this.m_grpLameAbout, "m_grpLameAbout");
            this.m_grpLameAbout.BackColor = System.Drawing.Color.Transparent;
            this.m_grpLameAbout.BackgroundImage = null;
            this.m_grpLameAbout.Controls.Add(this.m_lnkLameHomepage);
            this.m_grpLameAbout.Controls.Add(this.m_lblLameHomepage);
            this.m_grpLameAbout.Controls.Add(this.m_lblReleaseDate);
            this.m_grpLameAbout.Controls.Add(this.m_lblEncodingEngineVersion);
            this.m_grpLameAbout.Controls.Add(this.m_lblDllVersion);
            this.m_grpLameAbout.Font = null;
            this.m_grpLameAbout.Name = "m_grpLameAbout";
            this.m_grpLameAbout.TabStop = false;
            // 
            // m_lnkLameHomepage
            // 
            this.m_lnkLameHomepage.AccessibleDescription = null;
            this.m_lnkLameHomepage.AccessibleName = null;
            resources.ApplyResources(this.m_lnkLameHomepage, "m_lnkLameHomepage");
            this.m_lnkLameHomepage.Font = null;
            this.m_lnkLameHomepage.Name = "m_lnkLameHomepage";
            this.m_lnkLameHomepage.TabStop = true;
            this.m_lnkLameHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLameHomepage_LinkClicked);
            // 
            // m_lblLameHomepage
            // 
            this.m_lblLameHomepage.AccessibleDescription = null;
            this.m_lblLameHomepage.AccessibleName = null;
            resources.ApplyResources(this.m_lblLameHomepage, "m_lblLameHomepage");
            this.m_lblLameHomepage.Font = null;
            this.m_lblLameHomepage.Name = "m_lblLameHomepage";
            // 
            // m_lblReleaseDate
            // 
            this.m_lblReleaseDate.AccessibleDescription = null;
            this.m_lblReleaseDate.AccessibleName = null;
            resources.ApplyResources(this.m_lblReleaseDate, "m_lblReleaseDate");
            this.m_lblReleaseDate.Font = null;
            this.m_lblReleaseDate.Name = "m_lblReleaseDate";
            // 
            // m_lblEncodingEngineVersion
            // 
            this.m_lblEncodingEngineVersion.AccessibleDescription = null;
            this.m_lblEncodingEngineVersion.AccessibleName = null;
            resources.ApplyResources(this.m_lblEncodingEngineVersion, "m_lblEncodingEngineVersion");
            this.m_lblEncodingEngineVersion.Font = null;
            this.m_lblEncodingEngineVersion.Name = "m_lblEncodingEngineVersion";
            // 
            // m_lblDllVersion
            // 
            this.m_lblDllVersion.AccessibleDescription = null;
            this.m_lblDllVersion.AccessibleName = null;
            resources.ApplyResources(this.m_lblDllVersion, "m_lblDllVersion");
            this.m_lblDllVersion.Font = null;
            this.m_lblDllVersion.Name = "m_lblDllVersion";
            // 
            // m_btnOK
            // 
            this.m_btnOK.AccessibleDescription = null;
            this.m_btnOK.AccessibleName = null;
            resources.ApplyResources(this.m_btnOK, "m_btnOK");
            this.m_btnOK.BackgroundImage = null;
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Font = null;
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            // 
            // LameAboutForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grpLameAbout);
            this.Controls.Add(this.m_btnOK);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LameAboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.m_grpLameAbout.ResumeLayout(false);
            this.m_grpLameAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpLameAbout;
        private System.Windows.Forms.Label m_lblReleaseDate;
        private System.Windows.Forms.Label m_lblEncodingEngineVersion;
        private System.Windows.Forms.Label m_lblDllVersion;
        private System.Windows.Forms.Label m_lblLameHomepage;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.LinkLabel m_lnkLameHomepage;
    }
}