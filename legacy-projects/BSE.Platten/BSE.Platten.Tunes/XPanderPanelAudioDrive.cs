using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Collections.ObjectModel;
using BSE.Platten.Common;
using BSE.Platten.BO;
using BSE.Platten.Audio;
using System.Security.Permissions;
using System.Linq;

namespace BSE.Platten.Tunes
{
    public partial class XPanderPanelAudioDrive : BSE.Windows.Forms.XPanderPanel
    {
        #region Delegates
        private delegate void AddTreeNode(DirectoryInfo directoryInfo);
        private delegate void AddListViewItem(AudioMetadataFile audioMetaDataFile);
        #endregion

        #region FieldsPrivate
        private BSE.Platten.BO.Environment m_environment;
        private BSE.Wpf.RemovableDrives.RemovableDrive m_audioDrive;
        private Queue<DirectoryInfo> m_queueDirectoryInfos;
        private Queue<AudioMetadataFile> m_queueFiles;
        private Queue<DirectoryInfo> m_queueSelectedDirectories;

        private string m_strCurrentDirectoryName;
        private string m_strVolumeName;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the removable audiodrive.
        /// </summary>
        /// <value>
        /// Type: <see cref="BSE.Wpf.RemovableDrives.RemovableDrive"/>
        /// The removable audiodrive.
        /// </value>
        public BSE.Wpf.RemovableDrives.RemovableDrive AudioDrive
        {
            get { return this.m_audioDrive; }
            set
            {
                this.m_audioDrive = value;
            }
        }
        /// <summary>
        /// Gets the name of the volume.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.IO.DriveInfo"/>
        /// The name of the volume.
        /// </value>
        public string VolumeName
        {
            get { return this.m_strVolumeName; }
        }
        public BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set { this.m_environment = value; }
        }
        /// <summary>
        /// Gets or sets the settings for the control.
        /// </summary>
        /// <value>
        /// Type: <see cref="BSE.Configuration.CConfiguration"/>
        /// The settings for the control.
        /// </value>
        public BSE.Configuration.Configuration Settings
        {
            get { return this.m_settings; }
            set { this.m_settings = value; }
        }
        #endregion

        #region MethodsPublic
        public XPanderPanelAudioDrive()
        {
            InitializeComponent();
            this.m_queueSelectedDirectories = new Queue<DirectoryInfo>(2);
            this.m_trvDirectories.TreeViewNodeSorter = new TreeNodeSorter();
            this.m_lstvDirectoriesAndFiles.DragEnter += new DragEventHandler(m_lstvDirectoriesAndFiles_DragEnter);
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the CloseClick event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnCloseClick(object sender, EventArgs e)
        {
            SaveSettings();
            base.OnCloseClick(sender, e);
        }
        /// <summary>
        /// Raises the CreateControl method.
        /// </summary>
        protected override void OnCreateControl()
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.FormClosing += new FormClosingEventHandler(PlayListFormClosing);
                LoadSettings();
            }
            if (this.AudioDrive != null)
            {
                this.LoadDrive(this.AudioDrive);
            }
            base.OnCreateControl();
        }
        #endregion

        #region MethodsPrivate

           private void LoadDrive(BSE.Wpf.RemovableDrives.RemovableDrive removableDrive)
        {
            if (removableDrive != null)
            {
                if (this.m_trvDirectories.Enabled == false)
                {
                    this.m_trvDirectories.Enabled = true;
                }
                if (this.m_lstvDirectoriesAndFiles.Enabled == false)
                {
                    this.m_lstvDirectoriesAndFiles.Enabled = true;
                }
                this.m_strVolumeName = removableDrive.VolumeName;
                string strVolume = string.Format(CultureInfo.InvariantCulture,
                                                "{0} ({1})",
                                                removableDrive.VolumeLabel,
                                                removableDrive.Name);
                this.Text = strVolume;
                this.m_fileSystemWatcherFile.Path
                    = this.m_fileSystemWatcherFolder.Path
                    = removableDrive.Name;
                this.m_lstvDirectoriesAndFiles.Items.Clear();
                this.m_trvDirectories.Nodes.Clear();

                SetProgressBarValues();
                SetRootNode(removableDrive.DriveInfo.RootDirectory);
                this.Cursor = Cursors.WaitCursor;
                if (this.m_queueDirectoryInfos == null)
                {
                    this.m_queueDirectoryInfos = new Queue<DirectoryInfo>();
                }
                this.m_queueDirectoryInfos.Clear();
                if (this.m_queueFiles == null)
                {
                    this.m_queueFiles = new Queue<AudioMetadataFile>();
                }
                this.m_queueFiles.Clear();

                this.m_fileSystemWatcherFile.Path = removableDrive.DriveInfo.RootDirectory.FullName;
                this.m_trvDirectories.BeginUpdate();
                this.m_backgroundWorkerDirectories.RunWorkerAsync(removableDrive.DriveInfo.RootDirectory);
            }
            else
            {
                this.m_trvDirectories.Enabled = false;
                this.m_lstvDirectoriesAndFiles.Enabled = false;
            }
        }

        private void GetDirectories(DirectoryInfo rootDirectoryInfo)
        {
            DirectoryInfo[] directories = null;
            try
            {
                directories = rootDirectoryInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException) { }

            if (directories != null)
            {
                DirectoryInfoComparer directoryInfoComparer = new DirectoryInfoComparer();
                Array.Sort(directories, directoryInfoComparer);
                foreach (DirectoryInfo directoryInfo in directories)
                {
                    lock (this.m_queueDirectoryInfos)
                    {
                        this.m_queueDirectoryInfos.Enqueue(directoryInfo);
                    }
                    this.m_backgroundWorkerDirectories.ReportProgress(int.MinValue);
                    DirectoryInfo[] subDirectories = null;
                    try
                    {
                        subDirectories = directoryInfo.GetDirectories();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    if (subDirectories != null)
                    {
                        GetDirectories(directoryInfo);
                    }
                }
            }
        }

        private TreeNode GetParentTreeNode(DirectoryInfo directoryInfo)
        {
            TreeNode parentTreeNode = null;
            DirectoryInfo parentDirectory = directoryInfo.Parent;
            TreeNode[] treeNodes = this.m_trvDirectories.Nodes.Find(parentDirectory.FullName, true);
            if (treeNodes.Length > 0)
            {
                parentTreeNode = treeNodes[0];
            }
            return parentTreeNode;
        }

        private void SetRootNode(DirectoryInfo directoryInfo)
        {
            TreeNode rootTreeNode = new TreeNode();
            rootTreeNode.Name = directoryInfo.FullName;
            rootTreeNode.Text = directoryInfo.Name;
            this.m_trvDirectories.Nodes.Add(rootTreeNode);
        }

        private void SetProgressBarValues()
        {
            DriveInfo driveInfo = new DriveInfo(this.m_audioDrive.Name);
            if (driveInfo != null)
            {
                long lTotalSize = driveInfo.TotalSize;
                long lUsedSize = driveInfo.TotalSize - driveInfo.AvailableFreeSpace;

                int iPercent = (int)((float)lUsedSize / (float)lTotalSize * 100);
                this.m_progressBar.Value = iPercent;
                this.m_progressBar.Text = string.Format(CultureInfo.InvariantCulture, "{0}%", iPercent);
            }
        }

        private void TreeViewDirectoriesAfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedTreeNode = e.Node;
            if (selectedTreeNode != null)
            {
                this.m_strCurrentDirectoryName = selectedTreeNode.Name;
                ListingDirectoriesAndFiles(this.m_strCurrentDirectoryName);
            }
        }

        private void TreeViewDirectoriesMouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode selectedTreeNode = this.m_trvDirectories.GetNodeAt(e.X, e.Y);
            if (selectedTreeNode != null)
            {
                if (selectedTreeNode.IsExpanded == false)
                {
                    selectedTreeNode.Expand();
                }
            }
        }

        private void TreeViewDirectoriesKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TreeNode treeNode = this.m_trvDirectories.SelectedNode;
                if (treeNode != null)
                {
                    try
                    {
                        TreeNode rootTreeNode = this.m_trvDirectories.Nodes[0];
                        if (rootTreeNode.Equals(treeNode) == false)
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(treeNode.Name);
                            if (directoryInfo.Exists == true)
                            {
                                Collection<string> sourceFiles = new Collection<string>();
                                sourceFiles.Add(directoryInfo.FullName);

                                BSE.ThreadedShell.ThreadedShellFileOperation threadedShellFileOperation
                                = new BSE.ThreadedShell.ThreadedShellFileOperation
                                {
                                    SourceFiles = sourceFiles,
                                    FileOperation = BSE.Shell.FileOperation.FO_DELETE,
                                    Handle = this.Handle
                                };
                                threadedShellFileOperation.StartFileOperations();
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FileSystemWatcherFileCreated(object sender, FileSystemEventArgs e)
        {
            SetProgressBarValues();
        }

        private void FileSystemWatcherFileDeleted(object sender, FileSystemEventArgs e)
        {
            SetProgressBarValues();
            foreach (ListViewItem listViewItem in this.m_lstvDirectoriesAndFiles.Items)
            {
                FileInfo fileInfo = listViewItem.Tag as FileInfo;
                if ((fileInfo != null) && (fileInfo.FullName.Equals(e.FullPath) == true))
                {
                    this.m_lstvDirectoriesAndFiles.Items.Remove(listViewItem);
                }
            }
        }

        private void FileSystemWatcherFolderCreated(object sender, FileSystemEventArgs e)
        {
            SetProgressBarValues();
            DirectoryInfo directoryInfo = new DirectoryInfo(e.FullPath);
            if (directoryInfo.Exists == true)
            {
                AddDirectoryInfoToTreeView(directoryInfo);
                TreeNode parentTreeNode = this.GetParentTreeNode(directoryInfo);
                if (string.Equals(parentTreeNode.Name, this.m_strCurrentDirectoryName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    ListingDirectoriesAndFiles(this.m_strCurrentDirectoryName);
                }
            }
        }
        
        private void FileSystemWatcherFolderDeleted(object sender, FileSystemEventArgs e)
        {
            SetProgressBarValues();
            foreach (ListViewItem listViewItem in this.m_lstvDirectoriesAndFiles.Items)
            {
                DirectoryInfo directoryInfo = listViewItem.Tag as DirectoryInfo;
                if ((directoryInfo != null) && (directoryInfo.FullName.Equals(e.FullPath) == true))
                {
                    this.m_lstvDirectoriesAndFiles.Items.Remove(listViewItem);
                }
            }
            TreeNode[] treeNodes = this.m_trvDirectories.Nodes.Find(e.FullPath, true);
            if ((treeNodes != null) && (treeNodes.Length > 0))
            {
                foreach (TreeNode treeNode in treeNodes)
                {
                    this.m_trvDirectories.Nodes.Remove(treeNode);
                }
            }
        }

        private void ListingDirectoriesAndFiles(string strCurrentDirectory)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_lstvDirectoriesAndFiles.Items.Clear();
            if (string.IsNullOrEmpty(strCurrentDirectory) == false)
            {
                this.m_lstvDirectoriesAndFiles.BeginUpdate();
                DirectoryInfo rootDirectoryInfo = new DirectoryInfo(strCurrentDirectory);
                if ((rootDirectoryInfo != null) && (rootDirectoryInfo.Exists == true))
                {
                    DirectoryInfo[] directories = rootDirectoryInfo.GetDirectories();
                    if (directories != null)
                    {
                        DirectoryInfoComparer directoryInfoComparer = new DirectoryInfoComparer();
                        Array.Sort(directories, directoryInfoComparer);
                        foreach (DirectoryInfo directoryInfo in directories)
                        {
                            ListViewItem listViewItem = new ListViewItem();
                            listViewItem.Tag = directoryInfo;
                            listViewItem.Text = directoryInfo.Name;
                            listViewItem.ImageIndex = 1;
                            listViewItem.SubItems.Add(string.Empty);
                            listViewItem.SubItems.Add(string.Empty);
                            listViewItem.SubItems.Add(string.Empty);
                            listViewItem.SubItems.Add(string.Empty);
                            listViewItem.SubItems.Add(string.Empty);
                            listViewItem.SubItems.Add(string.Empty);
                            listViewItem.SubItems.Add(string.Empty);
                            this.m_lstvDirectoriesAndFiles.Items.Add(listViewItem);
                        }
                    }
                    this.m_queueSelectedDirectories.Enqueue(rootDirectoryInfo);
                    DequeueSelectedDirectories();
                }
            }
        }

        private void DequeueSelectedDirectories()
        {
            if (this.m_backgroundWorkerFiles.IsBusy == true)
            {
                this.m_backgroundWorkerFiles.CancelAsync();
                return;
            }
            else
            {
                if (this.m_queueSelectedDirectories.Count > 0)
                {
                    DirectoryInfo selectedDirectoryInfo = this.m_queueSelectedDirectories.Dequeue();
                    if (selectedDirectoryInfo != null)
                    {
                        this.m_backgroundWorkerFiles.RunWorkerAsync(selectedDirectoryInfo);
                    }
                }
            }
        }

        private void ListViewDirectoriesAndFilesDoubleClick(object sender, EventArgs e)
        {
            if (this.m_lstvDirectoriesAndFiles.SelectedItems.Count != 0)
            {
                ListViewItem listViewItem = this.m_lstvDirectoriesAndFiles.SelectedItems[0];// .FocusedItem;
                if (listViewItem != null)
                {
                    DirectoryInfo directoryInfo = listViewItem.Tag as DirectoryInfo;
                    if (directoryInfo != null)
                    {
                        TreeNode[] treeNodes = this.m_trvDirectories.Nodes.Find(directoryInfo.FullName, true);
                        if (treeNodes.Length > 0)
                        {
                            TreeNode selectedNode = treeNodes[0];
                            if (selectedNode != null)
                            {
                                selectedNode.Expand();
                                this.m_trvDirectories.SelectedNode = selectedNode;
                            }
                        }
                    }
                }
            }
        }

        private void ListViewDirectoriesAndFilesKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                System.Collections.ArrayList filesAndDirectories = new System.Collections.ArrayList();
                foreach (ListViewItem listViewItem in this.m_lstvDirectoriesAndFiles.SelectedItems)
                {
                    DirectoryInfo directoryInfo = listViewItem.Tag as DirectoryInfo;
                    if (directoryInfo != null)
                    {
                        if (directoryInfo.Exists == true)
                        {
                            filesAndDirectories.Add(directoryInfo);
                        }
                    }
                    FileInfo fileInfo = listViewItem.Tag as FileInfo;
                    if (fileInfo != null)
                    {
                        if (fileInfo.Exists == true)
                        {
                            filesAndDirectories.Add(fileInfo);
                        }
                    }
                }
                Collection<string> sourceFiles = new Collection<string>();
                foreach (object fileOrDirectory in filesAndDirectories)
                {
                    DirectoryInfo directoryInfo = fileOrDirectory as DirectoryInfo;
                    if (directoryInfo != null)
                    {
                        sourceFiles.Add(directoryInfo.FullName);
                    }
                    FileInfo fileInfo = fileOrDirectory as FileInfo;
                    if (fileInfo != null)
                    {
                        sourceFiles.Add(fileInfo.FullName);
                    }
                }

                BSE.ThreadedShell.ThreadedShellFileOperation threadedShellFileOperation
                                = new BSE.ThreadedShell.ThreadedShellFileOperation
                                {
                                    SourceFiles = sourceFiles,
                                    FileOperation = BSE.Shell.FileOperation.FO_DELETE,
                                    Handle = this.Handle
                                };
                threadedShellFileOperation.StartFileOperations();
            }
        }

        private void TreeViewDirectoriesDragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetType() == typeof(BSE.Windows.Forms.CDataObject))
            //{
            //    e.Effect = DragDropEffects.All;
            //}
            if (e.Data.GetDataPresent(BSE.Wpf.Windows.Controls.DragDrop.DragDropHelper.DragDropDataFormat.Name) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }
        
        void m_lstvDirectoriesAndFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(BSE.Wpf.Windows.Controls.DragDrop.DragDropHelper.DragDropDataFormat.Name) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void DirectoriesAndFilesDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(BSE.Wpf.Windows.Controls.DragDrop.DragDropHelper.DragDropDataFormat.Name) == true)
            {
                Control control = sender as Control;
                object hoverItem = null;
                // get the currently hovered row that the items will be dragged to
                Point clientPoint = control.PointToClient(new Point(e.X, e.Y));
                ListView listView = control as ListView;
                if (listView != null)
                {
                    hoverItem = listView.GetItemAt(clientPoint.X, clientPoint.Y);
                }
                TreeView treeView = control as TreeView;
                if (treeView != null)
                {
                    hoverItem = treeView.GetNodeAt(clientPoint.X, clientPoint.Y);
                }
                
                System.Reflection.FieldInfo fieldInfo = e.Data.GetType().GetField("innerData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                object fieldInfoValue = fieldInfo.GetValue(e.Data);
                if (fieldInfoValue != null)
                {
                    fieldInfo = fieldInfoValue.GetType().GetField("innerData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    System.Windows.DataObject dataObject1 = fieldInfo.GetValue(fieldInfoValue) as System.Windows.DataObject;
                    if (dataObject1 != null)
                    {
                        Album album = dataObject1.GetData(BSE.Wpf.Windows.Controls.DragDrop.DragDropHelper.DragDropDataFormat.Name) as Album;
                        if (album != null)
                        {
                            InsertAlbum(control, hoverItem, album);
                        }
                        object[] trackObjects = dataObject1.GetData(BSE.Wpf.Windows.Controls.DragDrop.DragDropHelper.DragDropDataFormat.Name) as object[];
                        if (trackObjects != null)
                        {
                            CTrack[] tracks = trackObjects.Cast<CTrack>().ToArray();
                            if (tracks != null)
                            {
                                InsertItems(control, hoverItem, tracks);
                            }
                        }
                    }
                }
            }
            
            //BSE.Windows.Forms.CDataObject dataObject = e.Data as BSE.Windows.Forms.CDataObject;
            //if (dataObject != null)
            //{
            //    try
            //    {
            //        Control control = sender as Control;
            //        object hoverItem = null;
            //        // get the currently hovered row that the items will be dragged to
            //        Point clientPoint = control.PointToClient(new Point(e.X, e.Y));
            //        ListView listView = control as ListView;
            //        if (listView != null)
            //        {
            //            hoverItem = listView.GetItemAt(clientPoint.X, clientPoint.Y);
            //        }
            //        TreeView treeView = control as TreeView;
            //        if (treeView != null)
            //        {
            //            hoverItem = treeView.GetNodeAt(clientPoint.X, clientPoint.Y);
            //        }

            //        BSE.Windows.Forms.CDraggedListViewObjects draggedListViewObjects = null;
            //        //check the overload of the dataobject
            //        if (dataObject.GetDataPresent(typeof(BSE.Windows.Forms.CDraggedListViewObjects)))
            //        {
            //            draggedListViewObjects
            //                = (BSE.Windows.Forms.CDraggedListViewObjects)dataObject.GetData(
            //                typeof(BSE.Windows.Forms.CDraggedListViewObjects));
            //            if (draggedListViewObjects.ParentListView == null)
            //            {
            //                return;
            //            }
            //        }
            //        if (dataObject.DragData != null)
            //        {
            //            draggedListViewObjects
            //                = (BSE.Windows.Forms.CDraggedListViewObjects)dataObject.DragData;

            //            if (draggedListViewObjects.ParentListView == null)
            //            {
            //                return;
            //            }
            //        }
            //        if (draggedListViewObjects != null)
            //        {
            //            object dragObject = draggedListViewObjects.DragObjects[0];
            //            //Wenn das Object vom Typ ListViewItem ist werden die ListViewItems in die ListView eingefügt
            //            if (dragObject is System.Windows.Forms.ListViewItem)
            //            {
            //                InsertItems(control, hoverItem, draggedListViewObjects);
            //            }

            //            PlayListDragDropData playListDragDropData = dragObject as PlayListDragDropData;
            //            if (playListDragDropData != null)
            //            {
            //                InsertAlbum(control, hoverItem, playListDragDropData.Id);
            //            }
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void InsertItems(object sender, object hoverItem, CTrack[] tracks)
        {
            string strCurrentDirectory = this.m_strCurrentDirectoryName;
            try
            {
                strCurrentDirectory = GetCurrentCopyDirectory(sender, hoverItem, strCurrentDirectory);

                Collection<CTrack> tracksToCopy = null;
                foreach (CTrack track in tracks)
                {
                    if (track != null)
                    {
                        FileInfo fileInfo = new FileInfo(track.FileFullName);
                        if (fileInfo.Exists == true)
                        {
                            if (tracksToCopy == null)
                            {
                                tracksToCopy = new Collection<CTrack>();
                            }
                            track.Extension = fileInfo.Extension;
                            tracksToCopy.Add(track);
                        }
                    }
                }
                if (tracksToCopy != null)
                {
                    CreateOperationCopy(tracksToCopy, strCurrentDirectory);
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void InsertItems(object sender, object hoverItem, BSE.Windows.Forms.CDraggedListViewObjects draggedListViewObjects)
        //{
        //    string strCurrentDirectory = this.m_strCurrentDirectoryName;
        //    try
        //    {
        //        strCurrentDirectory = GetCurrentCopyDirectory(sender, hoverItem, strCurrentDirectory);

        //        Collection<CTrack> tracksToCopy = null;
        //        foreach (object dragObject in draggedListViewObjects.DragObjects)
        //        {
        //            ListViewItem listViewItem = dragObject as ListViewItem;
        //            if (listViewItem != null)
        //            {
        //                CTrack track = listViewItem.Tag as CTrack;
        //                if (track != null)
        //                {
        //                    FileInfo fileInfo = new FileInfo(track.FileFullName);
        //                    if (fileInfo.Exists == true)
        //                    {
        //                        if (tracksToCopy == null)
        //                        {
        //                            tracksToCopy = new Collection<CTrack>();
        //                        }
        //                        track.Extension = fileInfo.Extension;
        //                        tracksToCopy.Add(track);
        //                    }
        //                }
        //            }
        //        }
        //        if (tracksToCopy != null)
        //        {
        //            CreateOperationCopy(tracksToCopy, strCurrentDirectory);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void CreateOperationCopy(Collection<CTrack> tracksToCopy, string strCurrentDirectory)
        {
            if ((tracksToCopy != null) && (tracksToCopy.Count > 0))
            {
                Collection<string> sourceFiles;
                Collection<string> destinationFiles;

                Form window = this.FindForm();


                GetSourceAndDestinationsFiles(tracksToCopy, strCurrentDirectory, out sourceFiles, out destinationFiles);

                BSE.ThreadedShell.ThreadedShellFileOperation threadedShellFileOperation
                    = new BSE.ThreadedShell.ThreadedShellFileOperation
                    {
                        DestinationFiles = destinationFiles,
                        SourceFiles = sourceFiles,
                        OperationFlags = BSE.Shell.ShellFileOperationFlags.FOF_MULTIDESTFILES | BSE.Shell.ShellFileOperationFlags.FOF_NOCONFIRMMKDIR,
                        FileOperation = BSE.Shell.FileOperation.FO_COPY,
                        Handle = this.Handle
                    };
                threadedShellFileOperation.FileOperationComplete += new EventHandler<EventArgs>(FilesOperationCopy);
                threadedShellFileOperation.StartFileOperations();
            }
        }
        private void FilesOperationCopy(object sender, EventArgs e)
        {
            BSE.ThreadedShell.ThreadedShellFileOperation threadedShellFileOperation = sender as BSE.ThreadedShell.ThreadedShellFileOperation;
            if (threadedShellFileOperation != null)
            {
                threadedShellFileOperation.FileOperationComplete -= new EventHandler<EventArgs>(FilesOperationCopy);
            }
            this.m_trvDirectories.Sort();
        }

        private void InsertAlbum(object sender, object hoverItem, Album album)
        {
            if ((this.m_environment != null) && (album != null))
            {
                CTunesBusinessObject tunesBusinessObject = new CTunesBusinessObject(this.m_environment.GetConnectionString());
                try
                {
                    CTrack[] tracks = tunesBusinessObject.GetAlbumTracksForPlayListByTitelId(album.AlbumId);
                    if (tracks != null)
                    {
                        string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.m_environment);
                        string strCurrentDirectory = this.m_strCurrentDirectoryName;
                        strCurrentDirectory = GetCurrentCopyDirectory(sender, hoverItem, strCurrentDirectory);

                        Collection<CTrack> tracksToCopy = null;
                        foreach (CTrack track in tracks)
                        {
                            if (string.IsNullOrEmpty(track.FileName) == false)
                            {
                                string strFullName = System.IO.Path.Combine(strAudioHomeDirectory, track.FileName);
                                FileInfo fileInfo = new FileInfo(strFullName);
                                if (fileInfo.Exists == true)
                                {
                                    if (tracksToCopy == null)
                                    {
                                        tracksToCopy = new Collection<CTrack>();
                                    }
                                    track.FileFullName = strFullName;
                                    track.Extension = fileInfo.Extension;
                                    tracksToCopy.Add(track);
                                }
                            }
                        }

                        if (tracksToCopy != null)
                        {
                            CreateOperationCopy(tracksToCopy, strCurrentDirectory);
                        }
                    }
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void GetSourceAndDestinationsFiles(
            Collection<CTrack> tracksCollection,
            string strCurrentDirectory,
            out Collection<string> sourceFiles,
            out Collection<string> destinationFiles)
        {

            sourceFiles = new Collection<string>();
            destinationFiles = new Collection<string>();

            if (tracksCollection != null)
            {
                if (tracksCollection.Count > 0)
                {
                    foreach (CTrack track in tracksCollection)
                    {
                        sourceFiles.Add(track.FileFullName);

                        string strDestinationFile = string.Format(CultureInfo.InvariantCulture, "({0}) {1}{2}",
                            track.TrackNumber, track.Title, track.Extension);

                        strDestinationFile = BSE.Platten.BO.Environment.ParseOutInvalidFileNameChars(
                            strDestinationFile);

                        string strInterpret = track.Interpret;
                        strInterpret = BSE.Platten.BO.Environment.RemoveInvalidFolderChars(strInterpret);
                        string strRelativePath = strCurrentDirectory;
                        if (IsFolderNamePartOfDirectory(strCurrentDirectory, strInterpret) == false)
                        {
                            strRelativePath = System.IO.Path.Combine(strCurrentDirectory, strInterpret);
                        }
                        string strAlbum = track.Album;
                        strAlbum = BSE.Platten.BO.Environment.RemoveInvalidFolderChars(strAlbum);
                        strRelativePath = System.IO.Path.Combine(strRelativePath, strAlbum);

                        string strFullName = System.IO.Path.Combine(strRelativePath, strDestinationFile);

                        destinationFiles.Add(strFullName);
                    }
                }
            }
        }

        private static bool IsFolderNamePartOfDirectory(string strCurrentDirecory, string strDirectoryPathPart)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(strCurrentDirecory);
            if (directoryInfo.Exists == true)
            {
                if (directoryInfo.Name.Equals(strDirectoryPathPart) == true)
                {
                    return true;
                }
                if (directoryInfo.Parent != null)
                {
                    return IsFolderNamePartOfDirectory(directoryInfo.Parent.FullName, strDirectoryPathPart);
                }
            }
            return false;
        }

        private static string GetCurrentCopyDirectory(object sender, object hoverItem, string strCurrentDirectory)
        {
            // Wenn das Album ans Ende des Trees gezogen wird...
            if (hoverItem == null)
            {
                TreeView treeView = sender as TreeView;
                if (treeView != null)
                {
                    // muss das Rootverzeichnis verwendet werden
                    strCurrentDirectory = treeView.Nodes[0].Name;
                }
            }
            else
            {
                TreeNode treeNode = hoverItem as TreeNode;
                if (treeNode != null)
                {
                    strCurrentDirectory = treeNode.Name;
                }
                ListViewItem listViewItem = hoverItem as ListViewItem;
                if (listViewItem != null)
                {
                    DirectoryInfo directoryInfo = listViewItem.Tag as DirectoryInfo;
                    if (directoryInfo != null)
                    {
                        strCurrentDirectory = directoryInfo.FullName;
                    }
                }
            }
            return strCurrentDirectory;
        }

        private void AddDirectoryInfoToTreeView(DirectoryInfo directoryInfo)
        {
            TreeNode parentTreeNode = GetParentTreeNode(directoryInfo);
            if (parentTreeNode != null)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Name = directoryInfo.FullName;
                treeNode.Text = directoryInfo.Name;
                treeNode.ImageIndex = 1;
                treeNode.SelectedImageIndex = 2;
                parentTreeNode.Nodes.Add(treeNode);

                if (string.Equals(parentTreeNode.Name, this.m_audioDrive.DriveInfo.RootDirectory.FullName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    parentTreeNode.Expand();
                }
            }
        }

        private void AddAudioMetaDataFilesToListView(AudioMetadataFile audioMetaDataFile)
        {
            if (audioMetaDataFile != null)
            {
                FileInfo fileInfo = audioMetaDataFile.FileInfo;
                if (fileInfo != null)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = fileInfo.Name;
                    AudioMetadata audioMetaData = audioMetaDataFile.AudioMetadata;
                    if (audioMetaData != null)
                    {
                        listViewItem.SubItems.Add(audioMetaData.WMTrackNumber);
                        listViewItem.SubItems.Add(audioMetaData.Author);
                        listViewItem.SubItems.Add(audioMetaData.WMAlbumTitle);
                        listViewItem.SubItems.Add(audioMetaData.Title);
                        listViewItem.SubItems.Add(audioMetaData.Duration.ToString());
                        listViewItem.SubItems.Add(audioMetaData.WMGenre);
                        listViewItem.SubItems.Add(audioMetaData.WMYear);
                    }

                    if (this.m_imageList.Images.ContainsKey(fileInfo.Extension) == false)
                    {
                        using (Icon associatedIcon = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName))
                        {
                            int iIconHeightAndWidth = 16;
                            if (associatedIcon.Height > iIconHeightAndWidth)
                            {
                                using (System.Drawing.Bitmap bitMap = associatedIcon.ToBitmap())
                                {
                                    Image thumNail = bitMap.GetThumbnailImage(iIconHeightAndWidth, iIconHeightAndWidth, null, IntPtr.Zero);
                                    this.m_imageList.Images.Add(fileInfo.Extension, thumNail);
                                }
                            }
                        }
                    }
                    listViewItem.ImageKey = fileInfo.Extension;
                    listViewItem.Tag = fileInfo;
                    this.m_lstvDirectoriesAndFiles.Items.Add(listViewItem);
                    this.m_lstvDirectoriesAndFiles.Update();
                }
            }
        }

        private void BackgroundWorkerDirectoriesDoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo rootDirectoryInfo = e.Argument as DirectoryInfo;
            if ((rootDirectoryInfo != null) && (rootDirectoryInfo.Exists == true))
            {
                GetDirectories(rootDirectoryInfo);
            }
        }

        private void BackgroundWorkerDirectoriesProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.m_queueDirectoryInfos.Count > 0)
            {
                lock (this.m_queueDirectoryInfos)
                {
                    DirectoryInfo directoryInfo = this.m_queueDirectoryInfos.Peek();
                    if (directoryInfo != null)
                    {
                        TreeNode parentTreeNode = GetParentTreeNode(directoryInfo);
                        if (parentTreeNode != null)
                        {
                            this.m_trvDirectories.Invoke(new AddTreeNode(this.AddDirectoryInfoToTreeView),
                                new object[] { directoryInfo });
                            this.m_queueDirectoryInfos.Dequeue();
                        }
                    }
                }
            }
        }

        private void BackgroundWorkerDirectoriesRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_trvDirectories.SelectedNode = this.m_trvDirectories.Nodes[0];
            this.m_trvDirectories.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private void BackgroundWorkerFilesDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            DirectoryInfo directoryInfo = e.Argument as DirectoryInfo;
            if ((directoryInfo != null) && (directoryInfo.Exists == true))
            {
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                if (fileInfos != null)
                {
                    FileInfoComparer fileInfoComparer = new FileInfoComparer();
                    Array.Sort(fileInfos, fileInfoComparer);
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        if (backgroundWorker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            break;
                        }

                        lock (this.m_queueFiles)
                        {
                            AudioMetadataFile audioMetaDataFile = new AudioMetadataFile();
                            audioMetaDataFile.FullName = fileInfo.FullName;
                            audioMetaDataFile.FileInfo = fileInfo;
                            if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
                            {
                                AudioData audioData = new WMFMediaData();
                                try
                                {
                                    AudioMetadata audioMetaData = audioData.GetMediaMetadata(fileInfo.FullName);
                                    if (audioMetaData != null)
                                    {
                                        audioMetaDataFile.AudioMetadata = audioMetaData;
                                    }
                                }
                                catch (Exception) { }
                            }
                            this.m_queueFiles.Enqueue(audioMetaDataFile);
                        }
                        this.m_backgroundWorkerFiles.ReportProgress(int.MinValue);
                    }
                }
            }
        }

        private void BackgroundWorkerFilesProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.m_queueFiles.Count > 0)
            {
                lock (this.m_queueFiles)
                {
                    AudioMetadataFile audioMetaDataFile = this.m_queueFiles.Peek();
                    if (audioMetaDataFile != null)
                    {
                        this.m_lstvDirectoriesAndFiles.Invoke(new AddListViewItem(this.AddAudioMetaDataFilesToListView),
                            new object[] { audioMetaDataFile });
                        this.m_queueFiles.Dequeue();
                    }
                }
            }
        }

        private void BackgroundWorkerFilesRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_queueFiles.Clear();
            this.m_lstvDirectoriesAndFiles.EndUpdate();
            this.Cursor = Cursors.Default;
            DequeueSelectedDirectories();
        }

        private void PlayListFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void LoadSettings()
        {
            if (this.m_settings != null)
            {
                XPanderPanelAudioDriveSettingsData xpanderPanelAudioDriveSettingsData = new XPanderPanelAudioDriveSettingsData();
                xpanderPanelAudioDriveSettingsData = xpanderPanelAudioDriveSettingsData.LoadSettings(this, this.m_settings, xpanderPanelAudioDriveSettingsData) as XPanderPanelAudioDriveSettingsData;
                if (xpanderPanelAudioDriveSettingsData != null)
                {
                    //-------------------------------------------------------------------------------
                    // Spaltenbreiten für die DirectoriesAndFiles neu setzen.
                    //-------------------------------------------------------------------------------
                    int iSizeListViewDirectoriesAndFiles = this.m_lstvDirectoriesAndFiles.Columns.Count;
                    int[] columnWidthsListViewDirectoriesAndFiles = xpanderPanelAudioDriveSettingsData.ColumnWidthsListViewDirectoriesAndFiles;
                    if (columnWidthsListViewDirectoriesAndFiles != null)
                    {
                        int iSizeIntArray = columnWidthsListViewDirectoriesAndFiles.Length;
                        for (int i = 0; i < iSizeListViewDirectoriesAndFiles; ++i)
                        {
                            if (i < iSizeIntArray)
                            {
                                this.m_lstvDirectoriesAndFiles.Columns[i].Width = columnWidthsListViewDirectoriesAndFiles[i];
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    //-------------------------------------------------------------------------------
                    // Breiten für die Directories TreeView neu setzen.
                    //-------------------------------------------------------------------------------
                    if (xpanderPanelAudioDriveSettingsData.TreeViewDirectoriesWidth > 0)
                    {
                        this.m_trvDirectories.Width = xpanderPanelAudioDriveSettingsData.TreeViewDirectoriesWidth;
                    }
                }
            }
        }

        private void SaveSettings()
        {
            if (this.m_settings != null)
            {
                XPanderPanelAudioDriveSettingsData xpanderPanelAudioDriveSettingsData = new XPanderPanelAudioDriveSettingsData();
                //-------------------------------------------------------------------------------
                // Spaltenbreiten für die DirectoriesAndFiles ListView speichern.
                //-------------------------------------------------------------------------------
                if (this.m_lstvDirectoriesAndFiles.IsDisposed == false)
                {
                    int iSizeListViewDirectoriesAndFiles = this.m_lstvDirectoriesAndFiles.Columns.Count;
                    int[] columnWidthsListViewDirectoriesAndFiles = new int[iSizeListViewDirectoriesAndFiles];
                    for (int i = 0; i < iSizeListViewDirectoriesAndFiles; ++i)
                    {
                        columnWidthsListViewDirectoriesAndFiles[i] = this.m_lstvDirectoriesAndFiles.Columns[i].Width;
                    }
                    xpanderPanelAudioDriveSettingsData.ColumnWidthsListViewDirectoriesAndFiles = columnWidthsListViewDirectoriesAndFiles;
                }
                //-------------------------------------------------------------------------------
                // Breiten für die Directories TreeView speichern.
                //-------------------------------------------------------------------------------
                if (this.m_trvDirectories.IsDisposed == false)
                {
                    xpanderPanelAudioDriveSettingsData.TreeViewDirectoriesWidth = this.m_trvDirectories.Width;
                }
                xpanderPanelAudioDriveSettingsData.SaveSettings(this, this.m_settings, xpanderPanelAudioDriveSettingsData);
            }
        }

        private class DirectoryInfoComparer : System.Collections.IComparer
        {
            #region MethodsPublic
            public DirectoryInfoComparer()
            {
            }
            public int Compare(object obj1, object obj2)
            {
                DirectoryInfo directoryInfo1 = (DirectoryInfo)obj1;
                DirectoryInfo directoryInfo2 = (DirectoryInfo)obj2;

                return string.Compare(
                       directoryInfo1.Name,
                       directoryInfo2.Name,
                       StringComparison.OrdinalIgnoreCase);
            }
            #endregion
        }

        private class FileInfoComparer : System.Collections.IComparer
        {
            #region MethodsPublic
            public FileInfoComparer()
            {
            }
            public int Compare(object obj1, object obj2)
            {
                FileInfo fileInfo1 = (FileInfo)obj1;
                FileInfo fileInfo2 = (FileInfo)obj2;

                return string.Compare(
                       fileInfo1.Name,
                       fileInfo2.Name,
                       StringComparison.OrdinalIgnoreCase);
            }
            #endregion
        }

        private class TreeNodeSorter : System.Collections.IComparer
        {
            // Compare the length of the strings, or the strings
            // themselves, if they are the same length.
            public int Compare(object x, object y)
            {
                TreeNode treeNodeX = x as TreeNode;
                TreeNode treeNodeY = y as TreeNode;
                return string.Compare(treeNodeX.Text, treeNodeY.Text, StringComparison.OrdinalIgnoreCase);
            }
        }
        #endregion
    }

    public class XPanderPanelAudioDriveSettingsData : BaseControlSettingsData
    {
        #region Fields
        /// <summary>
        /// Spaltenbreiten für die PlayList ListView
        /// </summary>
        private int[] m_iarColumnWidthsListViewDirectoriesAndFiles;
        /// <summary>
        /// Gets or sets the width of the directories TreeView.
        /// </summary>
        private int m_iTreeViewDirectoriesWidth;
        #endregion

        #region Properties
        /// <summary>
        /// Spaltenbreiten für die PlayList ListView
        /// </summary>
        public int[] ColumnWidthsListViewDirectoriesAndFiles
        {
            get { return this.m_iarColumnWidthsListViewDirectoriesAndFiles; }
            set { this.m_iarColumnWidthsListViewDirectoriesAndFiles = value; }
        }
        /// <summary>
        /// Gets or sets the width of the directories TreeView.
        /// </summary>
        public int TreeViewDirectoriesWidth
        {
            get { return this.m_iTreeViewDirectoriesWidth; }
            set { this.m_iTreeViewDirectoriesWidth = value; }
        }
        #endregion
    }
}
