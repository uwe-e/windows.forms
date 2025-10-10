using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using BSE.Wpf.Windows.Controls.DragDrop;

namespace BSE.Wpf.Windows.Controls
{
    /// <summary>
    /// Represents a control that displays hierarchical data in a tree structure that has items that can expand and collapse.
    /// </summary>
    public class TreeView : System.Windows.Controls.TreeView
    {
        #region Events
        /// <summary>
        /// Identifies the <see cref="ItemDrag"/> routed event.
        /// </summary>
        public static readonly RoutedEvent ItemDragEvent = EventManager.RegisterRoutedEvent(
                    "ItemDrag", RoutingStrategy.Bubble,
                    typeof(ItemDragEventHandler), typeof(TreeView));

        /// <summary>
        /// Occurs when the user begins dragging an item.
        /// </summary>
        public event ItemDragEventHandler ItemDrag
        {
            add { this.AddHandler(TreeView.ItemDragEvent, value, false); }
            remove { this.RemoveHandler(TreeView.ItemDragEvent, value); }
        }
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        Point m_startingPoint;
        bool m_bIsDragging = false;
        #endregion

        #region Properties
        public Type[] AllowedDragTypes
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the TreeView class.
        /// </summary>
        public TreeView()
        {
            this.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(TreeView_PreviewMouseLeftButtonDown);
            this.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(TreeView_PreviewMouseMove);
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        private void TreeView_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.m_startingPoint = e.GetPosition(null);
        }
        private void TreeView_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed ||
                e.RightButton == MouseButtonState.Pressed && this.m_bIsDragging == false)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - this.m_startingPoint.X) >
                        SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(position.Y - this.m_startingPoint.Y) >
                        SystemParameters.MinimumVerticalDragDistance)
                {
                    if (e.OriginalSource.GetType() != typeof(System.Windows.Controls.Primitives.Thumb))
                    {
                        TreeViewItem treeViewItem = FindAnchestor<TreeViewItem>((DependencyObject)e.OriginalSource);
                        if (treeViewItem != null)
                        {
                            if (this.AllowedDragTypes != null
                                && this.AllowedDragTypes.Contains(treeViewItem.DataContext.GetType()) == true)
                            {
                                this.m_bIsDragging = true;
                                using (DragDropWindow dragDropWindow = new DragDropWindow(this, treeViewItem))
                                {
                                    dragDropWindow.Show();
                                    ItemDragEventArgs itemDragEventArgs = new ItemDragEventArgs(
                                                            e.MouseDevice, e.Timestamp, treeViewItem.DataContext);
                                    itemDragEventArgs.RoutedEvent = TreeView.ItemDragEvent;
                                    this.RaiseEvent(itemDragEventArgs);

                                }
                                this.m_bIsDragging = false;
                            }
                        }
                    }
                }
            }
        }
        private static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = System.Windows.Media.VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        #endregion
    }
}
