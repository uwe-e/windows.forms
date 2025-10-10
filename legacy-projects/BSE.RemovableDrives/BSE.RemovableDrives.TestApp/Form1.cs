using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Interop;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		private delegate void DirectoryFoundHandler(DirectoryInfo directoryInfo);
		private BSE.RemovableDrives.RemovableDrive m_removableDrive;
		private Collection<AudioDirectory> m_audioDirectories;
		private BSE.Platten.Audio.ReadDirectoriesAndFiles m_readDirectoriesAndFiles;

        public Form1()
        {
            InitializeComponent();
            this.m_audioDirectories = new Collection<AudioDirectory>();
        }

		private void TreeViewAudioDirectoriesMouseClick(object sender, MouseEventArgs e)
		{
			TreeNode selectedTreeNode = this.m_trvAudioDirectories.GetNodeAt(e.X, e.Y);
			if (selectedTreeNode != null)
			{
				if (selectedTreeNode.IsExpanded == false)
				{
					selectedTreeNode.Expand();
				}
			}
		}

		private void TreeViewAudioDirectoriesAfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode selectedTreeNode = e.Node;
			if (selectedTreeNode != null)
			{
				//toolStripStatusLabel1.Text = selectedTreeNode.FullPath;
				ListingDirectoriesAndFiles(selectedTreeNode);
			}
		}

		private void RemovableDriveControllerDriveChanges(object sender, BSE.RemovableDrives.DriveChangeEventArgs e)
		{
            this.m_trvAudioDirectories.Nodes.Clear();
            this.m_audioDirectories.Clear();
            
            BSE.RemovableDrives.RemovableDrive removableDrive = e.RemovableDrive;
			if (removableDrive != null)
			{
				if (removableDrive.Equals(this.m_removableDrive) == false)
				{
					this.m_removableDrive = removableDrive;
					propertyGrid1.SelectedObject = this.m_removableDrive;
					if (this.m_removableDrive.DriveInfo.RootDirectory.Exists == true)
					{
						FindDirectories(this.m_removableDrive.DriveInfo.RootDirectory);
					}
				}
			}
		}

		private void RemovableDriveControllerDriveAdded(object sender, BSE.RemovableDrives.DriveChangeEventArgs e)
		{
			BSE.RemovableDrives.RemovableDrive removableDrive = e.RemovableDrive;
			if (removableDrive != null)
			{
				MessageBox.Show(removableDrive.VolumeName + " added");
			}
		}

		private void RemovableDriveControllerDriveRemoved(object sender, BSE.RemovableDrives.DriveChangeEventArgs e)
		{
			BSE.RemovableDrives.RemovableDrive removableDrive = e.RemovableDrive;
			if (removableDrive != null)
			{
				if (removableDrive.Equals(this.m_removableDrive) == true)
				{
					this.m_removableDrive = null;
					propertyGrid1.SelectedObject = null;
                    this.m_trvAudioDirectories.Nodes.Clear();
                    this.m_audioDirectories.Clear();
				}
			}
		}

		private void FindDirectories(DirectoryInfo directoryInfo)
		{
			this.m_readDirectoriesAndFiles = new BSE.Platten.Audio.ReadDirectories(this, directoryInfo);
			this.m_readDirectoriesAndFiles.ReadDirectory += new EventHandler<BSE.Platten.Audio.ReadDirectoriesEventArgs>(
				this.ReadDirectoriesAndFilesReadDirectory);
			this.m_readDirectoriesAndFiles.FoundDirectory += new EventHandler<BSE.Platten.Audio.ReadDirectoriesEventArgs>(
			   this.ReadDirectoriesAndFilesFoundDirectory);
		}

		private void ReadDirectoriesAndFilesFoundDirectory(object sender, BSE.Platten.Audio.ReadDirectoriesEventArgs e)
		{
			//der Event bei gefundenem Directory wird weitergegeben
			//OnFoundDirectory(sender, e);
			this.Invoke(new DirectoryFoundHandler(AddDirectoryToTree), e.DirectoryInfo);
		}

		private void ReadDirectoriesAndFilesReadDirectory(object sender, BSE.Platten.Audio.ReadDirectoriesEventArgs e)
		{
			//die Caption des Dialogs wird geschrieben
			//this.Invoke(new WriteCaptionHandler(WriteCaptionText), string.Format("lese {0}", e.DirectoryInfo.FullName));
		}

		private void AddDirectoryToTree(DirectoryInfo directoryInfo)
		{
			AudioDirectory currentDirectory = new AudioDirectory();
			currentDirectory.DriveInfo = directoryInfo;
			currentDirectory.FullName = directoryInfo.FullName;

			if (this.m_audioDirectories.Contains(currentDirectory) == false)
			{
				this.m_audioDirectories.Add(currentDirectory);
			}

			AudioDirectory parentDirectory = GetParentDirectory(currentDirectory);
			while (parentDirectory != null)
			{
				if (this.m_audioDirectories.Contains(parentDirectory) == false)
				{
					this.m_audioDirectories.Add(parentDirectory);
				}
				parentDirectory = GetParentDirectory(parentDirectory);
			}

			TreeNode[] treeNodes = this.m_trvAudioDirectories.Nodes.Find(directoryInfo.Root.FullName,true);
			if (treeNodes.Length == 0)
			{
				TreeNode rootNode = new TreeNode();
				rootNode.Name = directoryInfo.Root.FullName;
				rootNode.Text = directoryInfo.Root.Name;
				rootNode.ImageIndex = 0;
				rootNode.SelectedImageIndex = 0;
				if (currentDirectory.FullName.Equals(directoryInfo.FullName) == true)
				{
					rootNode.Tag = currentDirectory;
				}
				this.m_trvAudioDirectories.Nodes.Add(rootNode);
			}

			int iCount = this.m_audioDirectories.Count;
			for (int i = iCount - 1; i >= 0; i--)
			{
				AudioDirectory audioDirectory = this.m_audioDirectories[i];
				if (audioDirectory != null)
				{
					if (audioDirectory.DriveInfo.Parent != null)
					{
						TreeNode[] selectedNodes = m_trvAudioDirectories.Nodes.Find(audioDirectory.DriveInfo.Parent.FullName, true);
						if (selectedNodes.Length > 0)
						{
							TreeNode selectedNode = selectedNodes[0];
                            TreeNode[] availableNodes = m_trvAudioDirectories.Nodes.Find(audioDirectory.DriveInfo.FullName, true);
                            if (availableNodes.Length == 0)
                            {
								TreeNode newNode = new TreeNode();
								newNode.Text = audioDirectory.DriveInfo.Name;
								newNode.ImageIndex = 1;
								newNode.SelectedImageIndex = 2;
								newNode.Name = audioDirectory.DriveInfo.FullName;
								if (this.m_audioDirectories[i].Equals(currentDirectory) == true)
								{
									newNode.Tag = currentDirectory;
								}
								selectedNode.Nodes.Add(newNode);
                            }
						}
					}
				}
			}
            this.m_trvAudioDirectories.Nodes[0].Expand();
		}

		private static AudioDirectory GetParentDirectory(AudioDirectory currentAudioDirectory)
		{
			AudioDirectory parentAudioDirectory = null;
			if (currentAudioDirectory.DriveInfo.Parent != null)
			{
				parentAudioDirectory = new AudioDirectory();
				parentAudioDirectory.DriveInfo = currentAudioDirectory.DriveInfo.Parent;
				parentAudioDirectory.FullName = currentAudioDirectory.DriveInfo.Parent.FullName;
			}
			return parentAudioDirectory;
		}

		private void ListingDirectoriesAndFiles(TreeNode selectedTreeNode)
		{
			this.m_lstvDirectoriesAndFiles.Items.Clear();
			if (selectedTreeNode != null)
			{
				TreeNodeCollection treeNodes = selectedTreeNode.Nodes;
				if (treeNodes != null)
				{
					foreach (TreeNode treeNode in treeNodes)
					{
						ListViewItem listViewItem = new ListViewItem();
						listViewItem.Text = treeNode.Text;
						listViewItem.ImageIndex = 1;
						listViewItem.Tag = treeNode;
						this.m_lstvDirectoriesAndFiles.Items.Add(listViewItem);
					}
				}
				AudioDirectory audioDirectory = selectedTreeNode.Tag as AudioDirectory;
				if (audioDirectory != null)
				{
					//this.toolStripStatusLabel1.Text = audioDirectory.FullName + "has Audiofiles";
				}
			}
		}

		private void ListViewDirectoriesAndFilesDoubleClick(object sender, EventArgs e)
		{
			ListViewItem selectedListViewItem = this.m_lstvDirectoriesAndFiles.SelectedItems[0];
			if (selectedListViewItem != null)
			{
				TreeNode treeNode = selectedListViewItem.Tag as TreeNode;
				if (treeNode != null)
				{
					treeNode.Expand();
					this.m_trvAudioDirectories.SelectedNode = treeNode;
				}
			}
		}

		private void ListViewDirectoriesAndFilesKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ListViewItem selectedListViewItem = this.m_lstvDirectoriesAndFiles.SelectedItems[0];
				if (selectedListViewItem != null)
				{
					TreeNode treeNode = selectedListViewItem.Tag as TreeNode;
					if (treeNode != null)
					{
						treeNode.Expand();
						this.m_trvAudioDirectories.SelectedNode = treeNode;
					}
				}
			}
		}

	}
}
