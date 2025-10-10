namespace WindowsFormsApplication1
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.m_spcBase = new System.Windows.Forms.SplitContainer();
            this.m_spcDirectories = new System.Windows.Forms.SplitContainer();
            this.m_trvAudioDirectories = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_lstvDirectoriesAndFiles = new BSE.Windows.Forms.ListView();
            this.m_clmnName = ((BSE.Windows.Forms.ColumnHeader)(new BSE.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new BSE.Wpf.RemovableDrives.UserControl1();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripRemovableDeviceController1 = new BSE.RemovableDrives.ToolStripRemovableDeviceController();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.m_spcBase.Panel1.SuspendLayout();
            this.m_spcBase.Panel2.SuspendLayout();
            this.m_spcBase.SuspendLayout();
            this.m_spcDirectories.Panel1.SuspendLayout();
            this.m_spcDirectories.Panel2.SuspendLayout();
            this.m_spcDirectories.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(892, 137);
            this.propertyGrid1.TabIndex = 2;
            // 
            // m_spcBase
            // 
            this.m_spcBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_spcBase.Location = new System.Drawing.Point(0, 0);
            this.m_spcBase.Name = "m_spcBase";
            this.m_spcBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_spcBase.Panel1
            // 
            this.m_spcBase.Panel1.Controls.Add(this.m_spcDirectories);
            // 
            // m_spcBase.Panel2
            // 
            this.m_spcBase.Panel2.Controls.Add(this.panel1);
            this.m_spcBase.Panel2.Controls.Add(this.propertyGrid1);
            this.m_spcBase.Size = new System.Drawing.Size(892, 403);
            this.m_spcBase.SplitterDistance = 186;
            this.m_spcBase.TabIndex = 0;
            // 
            // m_spcDirectories
            // 
            this.m_spcDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_spcDirectories.Location = new System.Drawing.Point(0, 0);
            this.m_spcDirectories.Name = "m_spcDirectories";
            // 
            // m_spcDirectories.Panel1
            // 
            this.m_spcDirectories.Panel1.Controls.Add(this.m_trvAudioDirectories);
            // 
            // m_spcDirectories.Panel2
            // 
            this.m_spcDirectories.Panel2.Controls.Add(this.m_lstvDirectoriesAndFiles);
            this.m_spcDirectories.Size = new System.Drawing.Size(892, 186);
            this.m_spcDirectories.SplitterDistance = 297;
            this.m_spcDirectories.TabIndex = 0;
            // 
            // m_trvAudioDirectories
            // 
            this.m_trvAudioDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trvAudioDirectories.ImageIndex = 0;
            this.m_trvAudioDirectories.ImageList = this.imageList1;
            this.m_trvAudioDirectories.Location = new System.Drawing.Point(0, 0);
            this.m_trvAudioDirectories.Name = "m_trvAudioDirectories";
            this.m_trvAudioDirectories.SelectedImageKey = "FolderOpen256.png";
            this.m_trvAudioDirectories.Size = new System.Drawing.Size(297, 186);
            this.m_trvAudioDirectories.TabIndex = 0;
            this.m_trvAudioDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAudioDirectoriesAfterSelect);
            this.m_trvAudioDirectories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewAudioDirectoriesMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Removabledrive.png");
            this.imageList1.Images.SetKeyName(1, "Folder256.png");
            this.imageList1.Images.SetKeyName(2, "FolderOpen256.png");
            // 
            // m_lstvDirectoriesAndFiles
            // 
            this.m_lstvDirectoriesAndFiles.AllowColumnReorder = true;
            this.m_lstvDirectoriesAndFiles.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvDirectoriesAndFiles.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnName});
            this.m_lstvDirectoriesAndFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstvDirectoriesAndFiles.FitLargestItem = true;
            this.m_lstvDirectoriesAndFiles.Location = new System.Drawing.Point(0, 0);
            this.m_lstvDirectoriesAndFiles.Name = "m_lstvDirectoriesAndFiles";
            this.m_lstvDirectoriesAndFiles.Size = new System.Drawing.Size(591, 186);
            this.m_lstvDirectoriesAndFiles.SmallImageList = this.imageList1;
            this.m_lstvDirectoriesAndFiles.TabIndex = 0;
            this.m_lstvDirectoriesAndFiles.UseCompatibleStateImageBehavior = false;
            this.m_lstvDirectoriesAndFiles.View = System.Windows.Forms.View.Details;
            this.m_lstvDirectoriesAndFiles.DoubleClick += new System.EventHandler(this.ListViewDirectoriesAndFilesDoubleClick);
            this.m_lstvDirectoriesAndFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListViewDirectoriesAndFilesKeyUp);
            // 
            // m_clmnName
            // 
            this.m_clmnName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            this.m_clmnName.Text = "Name";
            this.m_clmnName.Width = 173;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.elementHost1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 76);
            this.panel1.TabIndex = 3;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(325, 6);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(113, 45);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRemovableDeviceController1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripRemovableDeviceController1
            // 
            this.toolStripRemovableDeviceController1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripRemovableDeviceController1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRemovableDeviceController1.Image")));
            this.toolStripRemovableDeviceController1.Name = "toolStripRemovableDeviceController1";
            this.toolStripRemovableDeviceController1.Size = new System.Drawing.Size(20, 20);
            this.toolStripRemovableDeviceController1.Text = "toolStripRemovableDeviceController1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_spcBase);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(892, 403);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(892, 453);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(28, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::WindowsFormsApplication1.Properties.Resources.Network;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 453);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.m_spcBase.Panel1.ResumeLayout(false);
            this.m_spcBase.Panel2.ResumeLayout(false);
            this.m_spcBase.ResumeLayout(false);
            this.m_spcDirectories.Panel1.ResumeLayout(false);
            this.m_spcDirectories.Panel2.ResumeLayout(false);
            this.m_spcDirectories.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.SplitContainer m_spcBase;
        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.SplitContainer m_spcDirectories;
		private System.Windows.Forms.TreeView m_trvAudioDirectories;
		private BSE.Windows.Forms.ListView m_lstvDirectoriesAndFiles;
        private System.Windows.Forms.ImageList imageList1;
        private BSE.Windows.Forms.ColumnHeader m_clmnName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private BSE.RemovableDrives.ToolStripRemovableDeviceController toolStripRemovableDeviceController1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private BSE.Wpf.RemovableDrives.UserControl1 userControl11;
	}
}

