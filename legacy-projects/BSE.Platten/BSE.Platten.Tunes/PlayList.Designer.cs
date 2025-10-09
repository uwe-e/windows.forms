namespace BSE.Platten.Tunes
{
    partial class PlayList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayList));
            this.m_tlbPlayList = new System.Windows.Forms.ToolStrip();
            this.m_btnPlaylists = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_btnNew = new System.Windows.Forms.ToolStripButton();
            this.m_btnSave = new System.Windows.Forms.ToolStripButton();
            this.m_btnDelete = new System.Windows.Forms.ToolStripButton();
            this.m_btnPlay = new System.Windows.Forms.ToolStripSplitButton();
            this.m_mnuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuPlayRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.m_settings = new BSE.Configuration.Configuration();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.playlist1 = new BSE.CoverFlow.WPFLib.PlaylistPanel.Playlist();
            this.m_tlbPlayList.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tlbPlayList
            // 
            resources.ApplyResources(this.m_tlbPlayList, "m_tlbPlayList");
            this.m_tlbPlayList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_tlbPlayList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnPlaylists,
            this.m_btnNew,
            this.m_btnSave,
            this.m_btnDelete,
            this.m_btnPlay});
            this.m_tlbPlayList.Name = "m_tlbPlayList";
            // 
            // m_btnPlaylists
            // 
            this.m_btnPlaylists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnPlaylists.Image = global::BSE.Platten.Tunes.Properties.Resources.playlist1;
            resources.ApplyResources(this.m_btnPlaylists, "m_btnPlaylists");
            this.m_btnPlaylists.Name = "m_btnPlaylists";
            // 
            // m_btnNew
            // 
            this.m_btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnNew.Image = global::BSE.Platten.Tunes.Properties.Resources.NewPlaylist16;
            resources.ApplyResources(this.m_btnNew, "m_btnNew");
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Click += new System.EventHandler(this.NewPlayListClick);
            // 
            // m_btnSave
            // 
            this.m_btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnSave.Image = global::BSE.Platten.Tunes.Properties.Resources.saveHS;
            resources.ApplyResources(this.m_btnSave, "m_btnSave");
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Click += new System.EventHandler(this.SavePlayListClick);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnDelete.Image = global::BSE.Platten.Tunes.Properties.Resources.delete;
            resources.ApplyResources(this.m_btnDelete, "m_btnDelete");
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Click += new System.EventHandler(this.DeletePlayListClick);
            // 
            // m_btnPlay
            // 
            this.m_btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuPlay,
            this.m_mnuPlayRandom});
            this.m_btnPlay.Image = global::BSE.Platten.Tunes.Properties.Resources.DataContainer_MoveNextHS;
            resources.ApplyResources(this.m_btnPlay, "m_btnPlay");
            this.m_btnPlay.Name = "m_btnPlay";
            this.m_btnPlay.ButtonClick += new System.EventHandler(this.PlayTracksClick);
            // 
            // m_mnuPlay
            // 
            this.m_mnuPlay.Image = global::BSE.Platten.Tunes.Properties.Resources.wiedergabe16;
            this.m_mnuPlay.Name = "m_mnuPlay";
            resources.ApplyResources(this.m_mnuPlay, "m_mnuPlay");
            this.m_mnuPlay.Click += new System.EventHandler(this.PlayTracksClick);
            // 
            // m_mnuPlayRandom
            // 
            this.m_mnuPlayRandom.Image = global::BSE.Platten.Tunes.Properties.Resources.Shuffle_icon;
            this.m_mnuPlayRandom.Name = "m_mnuPlayRandom";
            resources.ApplyResources(this.m_mnuPlayRandom, "m_mnuPlayRandom");
            this.m_mnuPlayRandom.Click += new System.EventHandler(this.PlayRandomClick);
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = this.playlist1;
            // 
            // PlayList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.m_tlbPlayList);
            this.Name = "PlayList";
            this.Load += new System.EventHandler(this.PlayListLoad);
            this.m_tlbPlayList.ResumeLayout(false);
            this.m_tlbPlayList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip m_tlbPlayList;
        private System.Windows.Forms.ToolStripButton m_btnNew;
        private System.Windows.Forms.ToolStripButton m_btnSave;
        private System.Windows.Forms.ToolStripButton m_btnDelete;
        private System.Windows.Forms.ToolStripSplitButton m_btnPlay;
        private BSE.Configuration.Configuration m_settings;
        private System.Windows.Forms.ToolStripMenuItem m_mnuPlay;
        private System.Windows.Forms.ToolStripMenuItem m_mnuPlayRandom;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private BSE.CoverFlow.WPFLib.PlaylistPanel.Playlist playlist1;
        private System.Windows.Forms.ToolStripDropDownButton m_btnPlaylists;
    }
}
