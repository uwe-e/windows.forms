namespace BSE.Platten.Tunes
{
    partial class NewPlayList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPlayList));
            this.m_grpNewPlaylist = new System.Windows.Forms.GroupBox();
            this.m_lblName = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_pnlBaseContent.SuspendLayout();
            this.m_grpNewPlaylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBaseContent
            // 
            this.m_pnlBaseContent.AccessibleDescription = null;
            this.m_pnlBaseContent.AccessibleName = null;
            resources.ApplyResources(this.m_pnlBaseContent, "m_pnlBaseContent");
            this.m_pnlBaseContent.BackgroundImage = null;
            this.m_pnlBaseContent.Controls.Add(this.m_grpNewPlaylist);
            this.m_pnlBaseContent.Font = null;
            // 
            // m_grpNewPlaylist
            // 
            this.m_grpNewPlaylist.AccessibleDescription = null;
            this.m_grpNewPlaylist.AccessibleName = null;
            resources.ApplyResources(this.m_grpNewPlaylist, "m_grpNewPlaylist");
            this.m_grpNewPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.m_grpNewPlaylist.BackgroundImage = null;
            this.m_grpNewPlaylist.Controls.Add(this.m_lblName);
            this.m_grpNewPlaylist.Controls.Add(this.m_txtName);
            this.m_grpNewPlaylist.Font = null;
            this.m_grpNewPlaylist.Name = "m_grpNewPlaylist";
            this.m_grpNewPlaylist.TabStop = false;
            // 
            // m_lblName
            // 
            this.m_lblName.AccessibleDescription = null;
            this.m_lblName.AccessibleName = null;
            resources.ApplyResources(this.m_lblName, "m_lblName");
            this.m_lblName.Font = null;
            this.m_lblName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lblName.Name = "m_lblName";
            // 
            // m_txtName
            // 
            this.m_txtName.AccessibleDescription = null;
            this.m_txtName.AccessibleName = null;
            resources.ApplyResources(this.m_txtName, "m_txtName");
            this.m_txtName.BackgroundImage = null;
            this.m_txtName.Font = null;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.TextChanged += new System.EventHandler(this.TxtNameTextChanged);
            // 
            // NewPlayList
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Font = null;
            this.Icon = null;
            this.Name = "NewPlayList";
            this.Load += new System.EventHandler(this.NewPlayListLoad);
            this.m_pnlBaseContent.ResumeLayout(false);
            this.m_grpNewPlaylist.ResumeLayout(false);
            this.m_grpNewPlaylist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox m_grpNewPlaylist;
        private System.Windows.Forms.Label m_lblName;
        private System.Windows.Forms.TextBox m_txtName;
    }
}