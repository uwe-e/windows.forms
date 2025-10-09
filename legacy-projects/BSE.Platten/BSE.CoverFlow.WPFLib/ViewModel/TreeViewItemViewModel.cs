using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class TreeViewItemViewModel : ViewModelBase
    {
        #region FieldsPrivate
        private static readonly TreeViewItemViewModel DummyChild = new TreeViewItemViewModel();
        private readonly ObservableCollection<TreeViewItemViewModel> m_children;
        private readonly TreeViewItemViewModel m_parent;

        private bool m_bIsExpanded;
        private bool m_bIsSelected;
        #endregion

        #region Properties
        /// <summary>
        /// Returns the logical child items of this object.
        /// </summary>
        public ObservableCollection<TreeViewItemViewModel> Children
        {
            get { return this.m_children; }
        }
        /// <summary>
        /// Returns true if this object's Children have not yet been populated.
        /// </summary>
        public bool HasDummyChild
        {
            get { return this.Children.Count == 1 && this.Children[0] == DummyChild; }
        }
        public TreeViewItemViewModel Parent
        {
            get { return this.m_parent; }
        }
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return this.m_bIsExpanded; }
            set
            {
                if (value != this.m_bIsExpanded)
                {
                    this.m_bIsExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (this.m_bIsExpanded && this.m_parent != null)
                {
                    this.m_parent.IsExpanded = true;
                }
                // Lazy load the child items, if necessary.
                if (this.HasDummyChild)
                {
                    this.Children.Remove(DummyChild);
                    this.LoadChildren();
                }
            }
        }
        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return this.m_bIsSelected; }
            set
            {
                if (value != this.m_bIsSelected)
                {
                    this.m_bIsSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsProtected
        protected TreeViewItemViewModel(TreeViewItemViewModel parent, bool lazyLoadChildren)
        {
            this.m_parent = parent;

            this.m_children = new ObservableCollection<TreeViewItemViewModel>();

            if (lazyLoadChildren)
            {
                this.m_children.Add(DummyChild);
            }
        }
        protected virtual void LoadChildren()
        {
        }
        #endregion

        #region MethodsPrivate
        // This is used to create the DummyChild instance.
        private TreeViewItemViewModel()
        {
        }
        #endregion

    }
}
