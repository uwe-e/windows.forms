using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BSE.Windows.Test
{
    public partial class ListViewTest : Form
    {
        private bool m_bUpdateInProgress = false;

        public ListViewTest()
        {
            InitializeComponent();
            ToolStripManager.Renderer = new BSE.Windows.Forms.Office2007Renderer(new BSE.Windows.Forms.Office2007BlueColorTable());
            BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(this.Controls, BSE.Windows.Forms.PanelStyle.Office2007);
            //listView1.AlternatingBackColor = Color.LightSteelBlue;
        }

        private void m_btnAddItems_Click(object sender, EventArgs e)
        {
            //DirectoryInfo directoryInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            string strPath = @"c:\";
            //string strPath = @"e:\";
            DirectoryInfo directoryInfo = new DirectoryInfo(strPath);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in files)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = fileInfo.FullName;
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, fileInfo.CreationTime.ToString()));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, fileInfo.Length.ToString()));
                this.listView1.Items.Add(listViewItem);
            }

            //backgroundWorker1.RunWorkerAsync(
        }

        private void m_btnRemoveItems_Click(object sender, EventArgs e)
        {
            //this.listView1.Items.Clear();
        }

        private void listView1_ListViewItemAdded(object sender, EventArgs e)
        {
            //MessageBox.Show("Item Added");
        }

        private void listView1_ListViewItemInserted(object sender, EventArgs e)
        {
            //MessageBox.Show("Item Inserted");
        }

        private void listView1_ListViewItemRemoved(object sender, EventArgs e)
        {
            //MessageBox.Show("Item Removed");
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //foreach (ListViewItem listViewItem in this.listView1.SelectedItems)
                //{
                //    this.listView1.Items.Remove(listViewItem);
                //}
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_btnAddFilesAndFolders_Click(object sender, EventArgs e)
        {
            if (this.m_bUpdateInProgress == true)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            this.m_bUpdateInProgress = true;
            DirectoryInfo directoryInfo = null;
            FileSystemInfo[] infos = null;
            //string strPath = @"U:\Lieder";
            //string strPath = @"c:\";
            string strPath = @"e:\";
            //MethodInvoker backgroundMethod = new MethodInvoker(delegate
            //{
            //    directoryInfo = new DirectoryInfo(strPath);
            //    infos = directoryInfo.GetFileSystemInfos();
            //});
            //backgroundMethod.BeginInvoke((AsyncCallback)delegate(IAsyncResult result)
            //{
            //    backgroundMethod.EndInvoke(result);
            //    // marshal back to the UI thread
            //    BeginInvoke((MethodInvoker)delegate
            //    {
            //        this.UpdateUI(strPath, directoryInfo);
            //    });
            //}, null);
            fileSystemWatcher1.Path = strPath;
            backgroundWorker1.RunWorkerAsync(strPath);
            //directoryInfo = new DirectoryInfo(strPath);
            //while (GetDirectories(directoryInfo,) != null) ;

        }

        private void UpdateUI(string strPath, DirectoryInfo rootDirectoryInfo)
        {
            this.m_lstvFilesAndFolders.BeginUpdate();
            this.m_lstvFilesAndFolders.Items.Clear();
            try
            {
                ListViewItem listViewItem;
                DirectoryInfo[] directoryInfos = rootDirectoryInfo.GetDirectories();
                foreach (DirectoryInfo directoryInfo in directoryInfos)
                {
                    listViewItem = new ListViewItem();
                    listViewItem.Text = directoryInfo.Name;
                    listViewItem.Tag = directoryInfo;
                    listViewItem.ImageIndex = 0;
                    this.m_lstvFilesAndFolders.Items.Add(listViewItem);
                }
                FileInfo[] fileInfos = rootDirectoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    listViewItem = new ListViewItem();
                    listViewItem.Text = fileInfo.Name;
                    listViewItem.Tag = fileInfo;
                    listViewItem.ImageKey = ExtractAssociatedIcon(fileInfo);
                    listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, fileInfo.CreationTime.ToString()));
                    listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, fileInfo.Length.ToString()));
                    this.m_lstvFilesAndFolders.Items.Add(listViewItem);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.m_bUpdateInProgress = false;
                this.m_lstvFilesAndFolders.EndUpdate();
            }
        }

        private string ExtractAssociatedIcon(FileInfo fileInfo)
        {
            string strExtension = fileInfo.Extension;
            if (this.m_imageList.Images.ContainsKey(fileInfo.Extension) == false)
            {
                System.Drawing.Image associatedImage = System.Drawing.Icon.ExtractAssociatedIcon(fileInfo.FullName).ToBitmap();
                if (associatedImage != null)
                {
                    if (associatedImage.Height == 32)
                    {
                        associatedImage = associatedImage.GetThumbnailImage(16, 16, null, IntPtr.Zero);
                    }
                    this.m_imageList.Images.Add(fileInfo.Extension, associatedImage);
                }
            }

            return strExtension;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string strPath = e.Argument as string;
            if (string.IsNullOrEmpty(strPath) == false)
            {
                DirectoryInfo rootDirectoryInfo = new DirectoryInfo(strPath);
                if (rootDirectoryInfo.Exists == true)
                {
                    GetDirectories(rootDirectoryInfo);
                }
            }
        }

        private void GetDirectories(DirectoryInfo directoryInfo)
        {
            DirectoryInfo[] directories = null;
            try
            {
                directories = directoryInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException) { }

            if (directories != null)
            {
                foreach (DirectoryInfo directoryInfo1 in directories)
                {
                    System.Threading.Thread.Sleep(10);
                    backgroundWorker1.ReportProgress(int.MinValue, directoryInfo1);
                    DirectoryInfo[] subDirectories = null;
                    try
                    {
                        subDirectories = directoryInfo1.GetDirectories();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;
                    }
                    if (subDirectories != null)
                    {
                        GetDirectories(directoryInfo1);
                    }
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ListViewItem listViewItem = null;
            DirectoryInfo directoryInfo = e.UserState as DirectoryInfo;
            if (directoryInfo != null)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = directoryInfo.Name;
                listViewItem.Tag = directoryInfo;
                listViewItem.ImageIndex = 0;
            }
            FileInfo fileInfo = e.UserState as FileInfo;
            if (fileInfo != null)
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = fileInfo.Name;
                listViewItem.Tag = fileInfo;
                listViewItem.ImageKey = ExtractAssociatedIcon(fileInfo);
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, fileInfo.CreationTime.ToString()));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, fileInfo.Length.ToString()));
            }
            if (listViewItem != null)
            {
                this.m_lstvFilesAndFolders.Items.Add(listViewItem);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            MessageBox.Show("Complete");
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {

        }
    }
}