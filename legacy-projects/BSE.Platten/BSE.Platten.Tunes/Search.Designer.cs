namespace BSE.Platten.Tunes
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.m_grdSearch = new System.Windows.Forms.DataGridView();
            this.m_ctxHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mnuToAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tsInnerSearch = new BSE.Platten.Tunes.SearchToolStrip();
            this.m_clmnInterpret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmLied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_grdSearch)).BeginInit();
            this.m_ctxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grdSearch
            // 
            this.m_grdSearch.AccessibleDescription = null;
            this.m_grdSearch.AccessibleName = null;
            this.m_grdSearch.AllowUserToAddRows = false;
            this.m_grdSearch.AllowUserToDeleteRows = false;
            this.m_grdSearch.AllowUserToResizeRows = false;
            resources.ApplyResources(this.m_grdSearch, "m_grdSearch");
            this.m_grdSearch.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_grdSearch.BackgroundImage = null;
            this.m_grdSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grdSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_clmnInterpret,
            this.m_clmnTitle,
            this.m_clmLied});
            this.m_grdSearch.Font = null;
            this.m_grdSearch.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_grdSearch.MultiSelect = false;
            this.m_grdSearch.Name = "m_grdSearch";
            this.m_grdSearch.ReadOnly = true;
            this.m_grdSearch.RowHeadersVisible = false;
            this.m_grdSearch.RowTemplate.Height = 18;
            this.m_grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_grdSearch.ShowCellToolTips = false;
            this.m_grdSearch.ShowEditingIcon = false;
            this.m_grdSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridMouseDown);
            this.m_grdSearch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GridMouseUp);
            this.m_grdSearch.Resize += new System.EventHandler(this.GridResize);
            this.m_grdSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridKeyUp);
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
            // m_tsInnerSearch
            // 
            this.m_tsInnerSearch.AccessibleDescription = null;
            this.m_tsInnerSearch.AccessibleName = null;
            resources.ApplyResources(this.m_tsInnerSearch, "m_tsInnerSearch");
            this.m_tsInnerSearch.BackgroundImage = null;
            this.m_tsInnerSearch.Font = null;
            this.m_tsInnerSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_tsInnerSearch.Name = "m_tsInnerSearch";
            this.m_tsInnerSearch.Stretch = true;
            this.m_tsInnerSearch.SearchExecuting += new System.EventHandler<BSE.Platten.Tunes.SearchExecuteEventArgs>(this.SearchExecuting);
            // 
            // m_clmnInterpret
            // 
            this.m_clmnInterpret.DataPropertyName = "interpret";
            resources.ApplyResources(this.m_clmnInterpret, "m_clmnInterpret");
            this.m_clmnInterpret.Name = "m_clmnInterpret";
            this.m_clmnInterpret.ReadOnly = true;
            // 
            // m_clmnTitle
            // 
            this.m_clmnTitle.DataPropertyName = "Album";
            resources.ApplyResources(this.m_clmnTitle, "m_clmnTitle");
            this.m_clmnTitle.Name = "m_clmnTitle";
            this.m_clmnTitle.ReadOnly = true;
            // 
            // m_clmLied
            // 
            this.m_clmLied.DataPropertyName = "Title";
            resources.ApplyResources(this.m_clmLied, "m_clmLied");
            this.m_clmLied.Name = "m_clmLied";
            this.m_clmLied.ReadOnly = true;
            // 
            // Search
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.m_grdSearch);
            this.Controls.Add(this.m_tsInnerSearch);
            this.Font = null;
            this.Name = "Search";
            this.Load += new System.EventHandler(this.SearchLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_grdSearch)).EndInit();
            this.m_ctxHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_grdSearch;
        private System.Windows.Forms.ContextMenuStrip m_ctxHistory;
        private System.Windows.Forms.ToolStripMenuItem m_mnuToAlbum;
        private SearchToolStrip m_tsInnerSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnInterpret;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmLied;
    }
}
