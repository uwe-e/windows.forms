using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using BSE.Platten.Admin.Properties;

namespace BSE.Platten.Admin
{
    public partial class TreeViewAdministration : TreeView
    {
        #region Events

        public event EventHandler<TreeNodeActivateEventArgs> TreeNodeActivated;

        #endregion

        #region FieldsPrivate

        private TreeNodeAdministration m_treeNodeTools;
        private TreeNodeAdministration m_treeNodeSystem;
        private Image m_imgTools;
        private Image m_imgSystem;

        #endregion
        
        #region MethodsPublic

        public TreeViewAdministration()
        {
            InitializeComponent();
        }

        public void InitializeTreeView()
        {
            if (DesignMode)
            {
                return;
            }
            
            this.ShowRootLines = false;
            this.ShowPlusMinus = false;
            this.m_imgTools = Resources.tools_16;
            this.m_imgSystem = Resources.system;
            this.ImageList = new ImageList();
            this.ImageList.Images.AddRange(new Image[] {
                this.m_imgTools,
                this.m_imgSystem});
            // Tools
            this.m_treeNodeTools = new TreeNodeAdministration();
            this.m_treeNodeTools.ParentChild = ParentChild.Parent;
            this.m_treeNodeTools.TreeNodeMode = TreeNodeMode.Tools;
            this.m_treeNodeTools.CanExecute = false;
            this.m_treeNodeTools.Text = Resources.IDS_TreeViewAdministrationToolsText;
            this.m_treeNodeTools.ImageIndex = 0;
            this.m_treeNodeTools.Nodes.Clear();
            // System
            this.m_treeNodeSystem = new TreeNodeAdministration();
            this.m_treeNodeSystem.ParentChild = ParentChild.Parent;
            this.m_treeNodeSystem.TreeNodeMode = TreeNodeMode.Statistic;
            this.m_treeNodeSystem.CanExecute = false;
            this.m_treeNodeSystem.Text = Resources.IDS_TreeViewAdministrationSystemText;
            this.m_treeNodeSystem.ImageIndex = 1;
            this.m_treeNodeSystem.SelectedImageIndex = 1;
            this.m_treeNodeSystem.Nodes.Clear();

            this.Nodes.AddRange(new TreeNode[] {
                this.m_treeNodeTools,
                this.m_treeNodeSystem});
            
            Type typeOfInterface = typeof(IIsInAdminForm);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            int iImageIndex = 2;
            foreach (Type type in types)
            {
                if (type.IsClass &&
                    typeOfInterface.IsAssignableFrom(type))
                {
                    System.Reflection.PropertyInfo propertyInfo = type.GetProperty("ShowInTreeView");
                    if (propertyInfo != null)
                    {
                        using (BaseForm baseForm = Activator.CreateInstance(type) as BaseForm)
                        {
                            if ((bool)propertyInfo.GetValue(baseForm, null))
                            {
                                TreeNodeAdministration treeNode = new TreeNodeAdministration(baseForm.Text);
                                treeNode.Tag = type;
                                if (baseForm.TreeNodeImage != null)
                                {
                                    this.ImageList.Images.Add(baseForm.TreeNodeImage);
                                    treeNode.ImageIndex = iImageIndex;
                                    treeNode.SelectedImageIndex = iImageIndex;
                                    iImageIndex++;
                                }
                                if (baseForm.ShowInToolsNode == true)
                                {
                                    treeNode.TreeNodeMode = TreeNodeMode.Tools;
                                    treeNode.ParentChild = ParentChild.Child;
                                    treeNode.CanExpand = false;
                                    treeNode.CanExecute = true;
                                    this.m_treeNodeTools.Nodes.Add(treeNode);
                                }
                                if (baseForm.ShowInStatisticNode == true)
                                {
                                    treeNode.TreeNodeMode = TreeNodeMode.Statistic;
                                    treeNode.ParentChild = ParentChild.Child;
                                    treeNode.CanExpand = false;
                                    treeNode.CanExecute = true;
                                    this.m_treeNodeSystem.Nodes.Add(treeNode);
                                }
                            }
                        }
                    }
                }
            }
            this.ExpandAll();
        }

        #endregion

        #region MethodsProtected

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            TreeNodeAdministration treeNode = this.GetNodeAt(e.X, e.Y) as TreeNodeAdministration;
            if (treeNode != null)
            {
                if (treeNode.IsSelected == false)
                {
                    this.SelectedNode = treeNode;
                }
                else
                {
                    if (treeNode.ParentChild == ParentChild.Child)
                    {
                        if (TreeNodeActivated != null)
                        {
                            Type type = treeNode.Tag as Type;
                            TreeNodeActivated(this, new TreeNodeActivateEventArgs(type));
                        }
                    }
                }
            }
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            TreeNodeAdministration treeNode = e.Node as TreeNodeAdministration;
            if (treeNode != null)
            {
                if (treeNode.ParentChild == ParentChild.Child)
                {
                    Type type = (Type)treeNode.Tag;
                    if (TreeNodeActivated != null)
                    {
                        TreeNodeActivated(this, new TreeNodeActivateEventArgs(type));
                    }
                }
            }
        }

        #endregion
    }
}
