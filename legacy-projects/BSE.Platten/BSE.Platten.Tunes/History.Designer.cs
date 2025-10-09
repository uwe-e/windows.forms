namespace BSE.Platten.Tunes
{
    partial class History
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_grdHistory = new System.Windows.Forms.DataGridView();
            this.m_ctxHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mnuToAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.m_backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.interpret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnLied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnZeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_grdHistory)).BeginInit();
            this.m_ctxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grdHistory
            // 
            this.m_grdHistory.AccessibleDescription = null;
            this.m_grdHistory.AccessibleName = null;
            this.m_grdHistory.AllowUserToAddRows = false;
            this.m_grdHistory.AllowUserToDeleteRows = false;
            this.m_grdHistory.AllowUserToOrderColumns = true;
            this.m_grdHistory.AllowUserToResizeRows = false;
            resources.ApplyResources(this.m_grdHistory, "m_grdHistory");
            this.m_grdHistory.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_grdHistory.BackgroundImage = null;
            this.m_grdHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_grdHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grdHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.interpret,
            this.m_clmnTitle,
            this.m_clmnLied,
            this.m_clmnZeit});
            this.m_grdHistory.Font = null;
            this.m_grdHistory.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_grdHistory.MultiSelect = false;
            this.m_grdHistory.Name = "m_grdHistory";
            this.m_grdHistory.ReadOnly = true;
            this.m_grdHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.m_grdHistory.RowHeadersVisible = false;
            this.m_grdHistory.RowTemplate.Height = 18;
            this.m_grdHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_grdHistory.ShowCellToolTips = false;
            this.m_grdHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridMouseDown);
            this.m_grdHistory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GridMouseUp);
            this.m_grdHistory.Resize += new System.EventHandler(this.GridResize);
            this.m_grdHistory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridKeyUp);
            // 
            // m_ctxHistory
            // 
            this.m_ctxHistory.AccessibleDescription = null;
            this.m_ctxHistory.AccessibleName = null;
            resources.ApplyResources(this.m_ctxHistory, "m_ctxHistory");
            this.m_ctxHistory.BackgroundImage = null;
            this.m_ctxHistory.Font = null;
            this.m_ctxHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuToAlbum});
            this.m_ctxHistory.Name = "m_ctxHistory";
            // 
            // m_mnuToAlbum
            // 
            this.m_mnuToAlbum.AccessibleDescription = null;
            this.m_mnuToAlbum.AccessibleName = null;
            resources.ApplyResources(this.m_mnuToAlbum, "m_mnuToAlbum");
            this.m_mnuToAlbum.BackgroundImage = null;
            this.m_mnuToAlbum.Image = global::BSE.Platten.Tunes.Properties.Resources.Album16;
            this.m_mnuToAlbum.Name = "m_mnuToAlbum";
            this.m_mnuToAlbum.ShortcutKeyDisplayString = null;
            this.m_mnuToAlbum.Click += new System.EventHandler(this.SelectAlbumClick);
            // 
            // m_backgroundWorkerUpdate
            // 
            this.m_backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerUpdateDoWork);
            this.m_backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerUpdateRunWorkerCompleted);
            // 
            // interpret
            // 
            this.interpret.DataPropertyName = "interpret";
            resources.ApplyResources(this.interpret, "interpret");
            this.interpret.Name = "interpret";
            this.interpret.ReadOnly = true;
            // 
            // m_clmnTitle
            // 
            this.m_clmnTitle.DataPropertyName = "Album";
            resources.ApplyResources(this.m_clmnTitle, "m_clmnTitle");
            this.m_clmnTitle.Name = "m_clmnTitle";
            this.m_clmnTitle.ReadOnly = true;
            // 
            // m_clmnLied
            // 
            this.m_clmnLied.DataPropertyName = "Title";
            resources.ApplyResources(this.m_clmnLied, "m_clmnLied");
            this.m_clmnLied.Name = "m_clmnLied";
            this.m_clmnLied.ReadOnly = true;
            // 
            // m_clmnZeit
            // 
            this.m_clmnZeit.DataPropertyName = "PlayedAt";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.m_clmnZeit.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.m_clmnZeit, "m_clmnZeit");
            this.m_clmnZeit.Name = "m_clmnZeit";
            this.m_clmnZeit.ReadOnly = true;
            // 
            // History
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grdHistory);
            this.Font = null;
            this.Name = "History";
            ((System.ComponentModel.ISupportInitialize)(this.m_grdHistory)).EndInit();
            this.m_ctxHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_grdHistory;
        private System.Windows.Forms.ContextMenuStrip m_ctxHistory;
        private System.Windows.Forms.ToolStripMenuItem m_mnuToAlbum;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn interpret;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnLied;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnZeit;
    }
}
