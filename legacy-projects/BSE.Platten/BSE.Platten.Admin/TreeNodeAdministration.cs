using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BSE.Platten.Admin
{
    public enum TreeNodeMode
    {
        Tools,
        Statistic
    }

    public enum ParentChild
    {
        Parent,
        Child
    }
    
    public class TreeNodeAdministration : TreeNode
    {
        #region FieldsPrivate

        private TreeNodeMode m_treeNodeMode;
        private ParentChild m_parentChild;
        private bool m_bCanExpand;
        private bool m_bCanExecute;

        #endregion

        #region Properties

        public TreeNodeMode TreeNodeMode
        {
            get { return this.m_treeNodeMode; }
            set { this.m_treeNodeMode = value; }
        }

        public ParentChild ParentChild
        {
            get { return this.m_parentChild; }
            set { this.m_parentChild = value; }
        }

        public bool CanExpand
        {
            get { return this.m_bCanExpand; }
            set { this.m_bCanExpand = value; }
        }

        public bool CanExecute
        {
            get { return this.m_bCanExecute; }
            set { this.m_bCanExecute = value; }
        }

        #endregion

        #region MethodsPublic

        public TreeNodeAdministration()
        {
            //
            // TODO: Fügen Sie hier die Konstruktorlogik hinzu
            //
        }

        public TreeNodeAdministration(string text)
            : this()
        {
            base.Text = text;
        }



		#endregion
    }
}
