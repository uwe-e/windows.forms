namespace BSE.Platten.Tunes
{
    partial class XPanderPanelAudioDrive
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
            try
            {
                if (disposing && (components != null))
                {
                    if (this.m_lstvDirectoriesAndFiles.IsDisposed == false)
                    {
                        this.m_lstvDirectoriesAndFiles.DoubleClick -= new System.EventHandler(this.ListViewDirectoriesAndFilesDoubleClick);
                        this.m_lstvDirectoriesAndFiles.DragDrop -= new System.Windows.Forms.DragEventHandler(this.DirectoriesAndFilesDragDrop);
                        this.m_lstvDirectoriesAndFiles.KeyUp -= new System.Windows.Forms.KeyEventHandler(this.ListViewDirectoriesAndFilesKeyUp);
                    }
                    if (this.m_trvDirectories.IsDisposed == false)
                    {
                        this.m_trvDirectories.MouseDoubleClick -= new System.Windows.Forms.MouseEventHandler(this.TreeViewDirectoriesMouseDoubleClick);
                        this.m_trvDirectories.DragDrop -= new System.Windows.Forms.DragEventHandler(this.DirectoriesAndFilesDragDrop);
                        this.m_trvDirectories.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.TreeViewDirectoriesAfterSelect);
                        this.m_trvDirectories.DragEnter -= new System.Windows.Forms.DragEventHandler(this.TreeViewDirectoriesDragEnter);
                        this.m_trvDirectories.KeyUp -= new System.Windows.Forms.KeyEventHandler(this.TreeViewDirectoriesKeyUp);
                    }
                    if (this.m_fileSystemWatcherFile != null)
                    {
                        this.m_fileSystemWatcherFile.EnableRaisingEvents = false;
                    }
                    if (this.m_fileSystemWatcherFolder != null)
                    {
                        this.m_fileSystemWatcherFolder.EnableRaisingEvents = false;
                    }
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XPanderPanelAudioDrive));
            this.m_trvDirectories = new System.Windows.Forms.TreeView();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_splLeft = new BSE.Windows.Forms.Splitter();
            this.m_lstvDirectoriesAndFiles = new BSE.Windows.Forms.ListView();
            this.m_clmnFileFullName = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnTrackNumber = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnInterpret = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnAlbum = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnTitle = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnDuration = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnGenre = new BSE.Windows.Forms.ColumnHeader();
            this.m_clmnYear = new BSE.Windows.Forms.ColumnHeader();
            this.m_filesAndFoldersListViewItemSorter = new BSE.Windows.Forms.FilesAndFoldersListViewItemSorter();
            this.m_tsMediaPlayer = new System.Windows.Forms.ToolStrip();
            this.m_lblProgressBar = new System.Windows.Forms.ToolStripLabel();
            this.m_progressBar = new BSE.Windows.Forms.ToolStripProgressBar();
            this.m_backgroundWorkerDirectories = new System.ComponentModel.BackgroundWorker();
            this.m_fileSystemWatcherFile = new System.IO.FileSystemWatcher();
            this.m_settings = new BSE.Configuration.Configuration();
            this.m_backgroundWorkerFiles = new System.ComponentModel.BackgroundWorker();
            this.m_fileSystemWatcherFolder = new System.IO.FileSystemWatcher();
            this.m_tsMediaPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fileSystemWatcherFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_fileSystemWatcherFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // m_trvDirectories
            // 
            this.m_trvDirectories.AllowDrop = true;
            resources.ApplyResources(this.m_trvDirectories, "m_trvDirectories");
            this.m_trvDirectories.ImageList = this.m_imageList;
            this.m_trvDirectories.LineColor = System.Drawing.Color.Empty;
            this.m_trvDirectories.Name = "m_trvDirectories";
            this.m_trvDirectories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewDirectoriesMouseDoubleClick);
            this.m_trvDirectories.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirectoriesAndFilesDragDrop);
            this.m_trvDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewDirectoriesAfterSelect);
            this.m_trvDirectories.DragEnter += new System.Windows.Forms.DragEventHandler(this.TreeViewDirectoriesDragEnter);
            this.m_trvDirectories.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeViewDirectoriesKeyUp);
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Silver;
            this.m_imageList.Images.SetKeyName(0, "Removabledrive.png");
            this.m_imageList.Images.SetKeyName(1, "Folder256.png");
            this.m_imageList.Images.SetKeyName(2, "FolderOpen256.png");
            // 
            // m_splLeft
            // 
            this.m_splLeft.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_splLeft, "m_splLeft");
            this.m_splLeft.Name = "m_splLeft";
            this.m_splLeft.TabStop = false;
            // 
            // m_lstvDirectoriesAndFiles
            // 
            this.m_lstvDirectoriesAndFiles.AllowColumnReorder = true;
            this.m_lstvDirectoriesAndFiles.AllowDrop = true;
            this.m_lstvDirectoriesAndFiles.AlternatingBackColor = System.Drawing.SystemColors.Window;
            this.m_lstvDirectoriesAndFiles.Columns.AddRange(new BSE.Windows.Forms.ColumnHeader[] {
            this.m_clmnFileFullName,
            this.m_clmnTrackNumber,
            this.m_clmnInterpret,
            this.m_clmnAlbum,
            this.m_clmnTitle,
            this.m_clmnDuration,
            this.m_clmnGenre,
            this.m_clmnYear});
            resources.ApplyResources(this.m_lstvDirectoriesAndFiles, "m_lstvDirectoriesAndFiles");
            this.m_lstvDirectoriesAndFiles.DragDropOnlyAsEvent = true;
            this.m_lstvDirectoriesAndFiles.FitLargestItem = true;
            this.m_lstvDirectoriesAndFiles.ListViewSorter = this.m_filesAndFoldersListViewItemSorter;
            this.m_lstvDirectoriesAndFiles.Name = "m_lstvDirectoriesAndFiles";
            this.m_lstvDirectoriesAndFiles.ShowItemToolTips = true;
            this.m_lstvDirectoriesAndFiles.SmallImageList = this.m_imageList;
            this.m_lstvDirectoriesAndFiles.UseCompatibleStateImageBehavior = false;
            this.m_lstvDirectoriesAndFiles.View = System.Windows.Forms.View.Details;
            this.m_lstvDirectoriesAndFiles.DoubleClick += new System.EventHandler(this.ListViewDirectoriesAndFilesDoubleClick);
            this.m_lstvDirectoriesAndFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirectoriesAndFilesDragDrop);
            this.m_lstvDirectoriesAndFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListViewDirectoriesAndFilesKeyUp);
            // 
            // m_clmnFileFullName
            // 
            this.m_clmnFileFullName.ListViewComparer = BSE.Windows.Forms.ListViewComparer.FileSystem;
            resources.ApplyResources(this.m_clmnFileFullName, "m_clmnFileFullName");
            // 
            // m_clmnTrackNumber
            // 
            this.m_clmnTrackNumber.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            resources.ApplyResources(this.m_clmnTrackNumber, "m_clmnTrackNumber");
            // 
            // m_clmnInterpret
            // 
            this.m_clmnInterpret.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnInterpret, "m_clmnInterpret");
            // 
            // m_clmnAlbum
            // 
            this.m_clmnAlbum.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnAlbum, "m_clmnAlbum");
            // 
            // m_clmnTitle
            // 
            this.m_clmnTitle.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnTitle, "m_clmnTitle");
            // 
            // m_clmnDuration
            // 
            this.m_clmnDuration.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnDuration, "m_clmnDuration");
            // 
            // m_clmnGenre
            // 
            this.m_clmnGenre.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
            resources.ApplyResources(this.m_clmnGenre, "m_clmnGenre");
            // 
            // m_clmnYear
            // 
            this.m_clmnYear.ListViewComparer = BSE.Windows.Forms.ListViewComparer.Numbers;
            resources.ApplyResources(this.m_clmnYear, "m_clmnYear");
            // 
            // m_filesAndFoldersListViewItemSorter
            // 
            this.m_filesAndFoldersListViewItemSorter.SortColumnIndex = 0;
            this.m_filesAndFoldersListViewItemSorter.SortOrder = System.Windows.Forms.SortOrder.None;
            // 
            // m_tsMediaPlayer
            // 
            this.m_tsMediaPlayer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_tsMediaPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_lblProgressBar,
            this.m_progressBar});
            resources.ApplyResources(this.m_tsMediaPlayer, "m_tsMediaPlayer");
            this.m_tsMediaPlayer.Name = "m_tsMediaPlayer";
            // 
            // m_lblProgressBar
            // 
            this.m_lblProgressBar.Name = "m_lblProgressBar";
            resources.ApplyResources(this.m_lblProgressBar, "m_lblProgressBar");
            // 
            // m_progressBar
            // 
            this.m_progressBar.BackColor = System.Drawing.Color.Transparent;
            this.m_progressBar.BackgroundColor = System.Drawing.Color.DarkOrchid;
            resources.ApplyResources(this.m_progressBar, "m_progressBar");
            this.m_progressBar.ForeColor = System.Drawing.Color.White;
            this.m_progressBar.Name = "m_progressBar";
            this.m_progressBar.ValueColor = System.Drawing.Color.Blue;
            // 
            // m_backgroundWorkerDirectories
            // 
            this.m_backgroundWorkerDirectories.WorkerReportsProgress = true;
            this.m_backgroundWorkerDirectories.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDirectoriesDoWork);
            this.m_backgroundWorkerDirectories.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerDirectoriesRunWorkerCompleted);
            this.m_backgroundWorkerDirectories.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerDirectoriesProgressChanged);
            // 
            // m_fileSystemWatcherFile
            // 
            this.m_fileSystemWatcherFile.EnableRaisingEvents = true;
            this.m_fileSystemWatcherFile.IncludeSubdirectories = true;
            this.m_fileSystemWatcherFile.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.m_fileSystemWatcherFile.SynchronizingObject = this;
            this.m_fileSystemWatcherFile.Deleted += new System.IO.FileSystemEventHandler(this.FileSystemWatcherFileDeleted);
            this.m_fileSystemWatcherFile.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcherFileCreated);
            // 
            // m_settings
            // 
            this.m_settings.ApplicationSubDirectory = null;
            // 
            // m_backgroundWorkerFiles
            // 
            this.m_backgroundWorkerFiles.WorkerReportsProgress = true;
            this.m_backgroundWorkerFiles.WorkerSupportsCancellation = true;
            this.m_backgroundWorkerFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerFilesDoWork);
            this.m_backgroundWorkerFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerFilesRunWorkerCompleted);
            this.m_backgroundWorkerFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerFilesProgressChanged);
            // 
            // m_fileSystemWatcherFolder
            // 
            this.m_fileSystemWatcherFolder.EnableRaisingEvents = true;
            this.m_fileSystemWatcherFolder.IncludeSubdirectories = true;
            this.m_fileSystemWatcherFolder.NotifyFilter = System.IO.NotifyFilters.DirectoryName;
            this.m_fileSystemWatcherFolder.SynchronizingObject = this;
            this.m_fileSystemWatcherFolder.Deleted += new System.IO.FileSystemEventHandler(this.FileSystemWatcherFolderDeleted);
            this.m_fileSystemWatcherFolder.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcherFolderCreated);
            // 
            // XPanderPanelAudioDrive
            // 
            this.Controls.Add(this.m_lstvDirectoriesAndFiles);
            this.Controls.Add(this.m_splLeft);
            this.Controls.Add(this.m_trvDirectories);
            this.Controls.Add(this.m_tsMediaPlayer);
            this.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.Name = "Main";
            resources.ApplyResources(this, "$this");
            this.m_tsMediaPlayer.ResumeLayout(false);
            this.m_tsMediaPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_fileSystemWatcherFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_fileSystemWatcherFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView m_trvDirectories;
        private BSE.Windows.Forms.Splitter m_splLeft;
        private BSE.Windows.Forms.ListView m_lstvDirectoriesAndFiles;
        private System.Windows.Forms.ToolStrip m_tsMediaPlayer;
        private System.Windows.Forms.ImageList m_imageList;
        private BSE.Windows.Forms.ColumnHeader m_clmnFileFullName;
        private BSE.Windows.Forms.ColumnHeader m_clmnTrackNumber;
        private BSE.Windows.Forms.ColumnHeader m_clmnInterpret;
        private BSE.Windows.Forms.ColumnHeader m_clmnAlbum;
        private BSE.Windows.Forms.ColumnHeader m_clmnTitle;
        private BSE.Windows.Forms.ColumnHeader m_clmnDuration;
        private BSE.Windows.Forms.ColumnHeader m_clmnGenre;
        private BSE.Windows.Forms.ColumnHeader m_clmnYear;
        private BSE.Windows.Forms.FilesAndFoldersListViewItemSorter m_filesAndFoldersListViewItemSorter;
        private BSE.Windows.Forms.ToolStripProgressBar m_progressBar;
        private System.Windows.Forms.ToolStripLabel m_lblProgressBar;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerDirectories;
        private System.IO.FileSystemWatcher m_fileSystemWatcherFile;
        private BSE.Configuration.Configuration m_settings;
        private System.ComponentModel.BackgroundWorker m_backgroundWorkerFiles;
        private System.IO.FileSystemWatcher m_fileSystemWatcherFolder;
    }
}
