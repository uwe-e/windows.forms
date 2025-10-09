namespace BSE.Windows.Test
{
	partial class ListViewTest
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewTest));
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new BSE.Windows.Forms.Splitter();
            this.panel2 = new BSE.Windows.Forms.Panel();
            this.listView1 = new BSE.Windows.Forms.ListView();
            this.m_clmnFiles = new BSE.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new BSE.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new BSE.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new BSE.Windows.Forms.ColumnHeader();
            this.panel3 = new BSE.Windows.Forms.Panel();
            this.m_lstvFilesAndFolders = new BSE.Windows.Forms.ListView();
            this.m_clmnFilesAndFolders = new BSE.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new BSE.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new BSE.Windows.Forms.ColumnHeader();
            this.filesAndFoldersListViewItemSorter1 = new BSE.Windows.Forms.FilesAndFoldersListViewItemSorter();
            this.panel1 = new BSE.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.m_btnAddFilesAndFolders = new System.Windows.Forms.Button();
            this.m_btnRemoveItems = new System.Windows.Forms.Button();
            this.m_btnAddItems = new System.Windows.Forms.Button();
            this.columnHeader1 = new BSE.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new BSE.Windows.Forms.ColumnHeader();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "Folder256.png");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 293);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(882, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.CaptionFont = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Image = null;
            this.panel2.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel2.Size = new System.Drawing.Size(882, 238);
            this.panel2.TabIndex = 1;
            this.panel2.Text = "panel2";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnFiles,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FitLargestItem = true;
            this.listView1.Location = new System.Drawing.Point(1, 26);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(880, 211);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // m_clmnFiles
            // 
            this.m_clmnFiles.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnFiles.Text = "Name";
            this.m_clmnFiles.Width = 401;
            // 
            // columnHeader4
            // 
            this.columnHeader4.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Dates;
            this.columnHeader4.Width = 169;
            // 
            // columnHeader5
            // 
            this.columnHeader5.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            this.columnHeader5.Width = 209;
            // 
            // columnHeader3
            // 
            this.columnHeader3.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.CaptionFont = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.panel3.Controls.Add(this.m_lstvFilesAndFolders);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Image = null;
            this.panel3.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel3.Location = new System.Drawing.Point(0, 296);
            this.panel3.Name = "panel3";
            this.panel3.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel3.Size = new System.Drawing.Size(882, 243);
            this.panel3.TabIndex = 2;
            this.panel3.Text = "panel3";
            // 
            // m_lstvFilesAndFolders
            // 
            this.m_lstvFilesAndFolders.AllowColumnReorder = true;
            this.m_lstvFilesAndFolders.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvFilesAndFolders.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnFilesAndFolders,
            this.columnHeader6,
            this.columnHeader7});
            this.m_lstvFilesAndFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstvFilesAndFolders.FitLargestItem = true;
            this.m_lstvFilesAndFolders.ListViewSorter = this.filesAndFoldersListViewItemSorter1;
            this.m_lstvFilesAndFolders.Location = new System.Drawing.Point(1, 26);
            this.m_lstvFilesAndFolders.Name = "m_lstvFilesAndFolders";
            this.m_lstvFilesAndFolders.Size = new System.Drawing.Size(880, 216);
            this.m_lstvFilesAndFolders.SmallImageList = this.m_imageList;
            this.m_lstvFilesAndFolders.TabIndex = 0;
            this.m_lstvFilesAndFolders.UseCompatibleStateImageBehavior = false;
            this.m_lstvFilesAndFolders.View = System.Windows.Forms.View.Details;
            // 
            // m_clmnFilesAndFolders
            // 
            this.m_clmnFilesAndFolders.ListViewComparer = BSE.Windows.Forms.ListViewComparer.FileSystem;
            this.m_clmnFilesAndFolders.Text = "Name";
            this.m_clmnFilesAndFolders.Width = 322;
            // 
            // columnHeader6
            // 
            this.columnHeader6.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Dates;
            this.columnHeader6.Text = "Erstellt";
            this.columnHeader6.Width = 307;
            // 
            // columnHeader7
            // 
            this.columnHeader7.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            this.columnHeader7.Text = "Grösse";
            // 
            // filesAndFoldersListViewItemSorter1
            // 
            this.filesAndFoldersListViewItemSorter1.SortColumnIndex = 0;
            this.filesAndFoldersListViewItemSorter1.SortOrder = System.Windows.Forms.SortOrder.None;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.CaptionFont = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.m_btnAddFilesAndFolders);
            this.panel1.Controls.Add(this.m_btnRemoveItems);
            this.panel1.Controls.Add(this.m_btnAddItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Image = null;
            this.panel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel1.Size = new System.Drawing.Size(882, 58);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // m_btnAddFilesAndFolders
            // 
            this.m_btnAddFilesAndFolders.Location = new System.Drawing.Point(318, 29);
            this.m_btnAddFilesAndFolders.Name = "m_btnAddFilesAndFolders";
            this.m_btnAddFilesAndFolders.Size = new System.Drawing.Size(160, 23);
            this.m_btnAddFilesAndFolders.TabIndex = 2;
            this.m_btnAddFilesAndFolders.Text = "add files and foldes";
            this.m_btnAddFilesAndFolders.UseVisualStyleBackColor = true;
            this.m_btnAddFilesAndFolders.Click += new System.EventHandler(this.m_btnAddFilesAndFolders_Click);
            // 
            // m_btnRemoveItems
            // 
            this.m_btnRemoveItems.Location = new System.Drawing.Point(155, 29);
            this.m_btnRemoveItems.Name = "m_btnRemoveItems";
            this.m_btnRemoveItems.Size = new System.Drawing.Size(156, 23);
            this.m_btnRemoveItems.TabIndex = 1;
            this.m_btnRemoveItems.Text = "RemoveItems";
            this.m_btnRemoveItems.UseVisualStyleBackColor = true;
            this.m_btnRemoveItems.Click += new System.EventHandler(this.m_btnRemoveItems_Click);
            // 
            // m_btnAddItems
            // 
            this.m_btnAddItems.Location = new System.Drawing.Point(3, 29);
            this.m_btnAddItems.Name = "m_btnAddItems";
            this.m_btnAddItems.Size = new System.Drawing.Size(146, 23);
            this.m_btnAddItems.TabIndex = 0;
            this.m_btnAddItems.Text = "AddFiles";
            this.m_btnAddItems.UseVisualStyleBackColor = true;
            this.m_btnAddItems.Click += new System.EventHandler(this.m_btnAddItems_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            // 
            // columnHeader2
            // 
            this.columnHeader2.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(39, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(98, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(882, 539);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(882, 564);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // ListViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 564);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "ListViewTest";
            this.Text = "ListViewTest";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private BSE.Windows.Forms.Panel panel1;
        private BSE.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button m_btnRemoveItems;
		private System.Windows.Forms.Button m_btnAddItems;
        private BSE.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button m_btnAddFilesAndFolders;
        private System.Windows.Forms.ImageList m_imageList;
        private BSE.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button1;
        private BSE.Windows.Forms.ColumnHeader columnHeader1;
        private BSE.Windows.Forms.ColumnHeader columnHeader2;
        private BSE.Windows.Forms.ListView listView1;
        private BSE.Windows.Forms.ColumnHeader m_clmnFiles;
        private BSE.Windows.Forms.ColumnHeader columnHeader4;
        private BSE.Windows.Forms.ColumnHeader columnHeader5;
        private BSE.Windows.Forms.ListView m_lstvFilesAndFolders;
        private BSE.Windows.Forms.ColumnHeader m_clmnFilesAndFolders;
        private BSE.Windows.Forms.ColumnHeader columnHeader6;
        private BSE.Windows.Forms.ColumnHeader columnHeader7;
        private BSE.Windows.Forms.FilesAndFoldersListViewItemSorter filesAndFoldersListViewItemSorter1;
        private BSE.Windows.Forms.ColumnHeader columnHeader3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
	}
}