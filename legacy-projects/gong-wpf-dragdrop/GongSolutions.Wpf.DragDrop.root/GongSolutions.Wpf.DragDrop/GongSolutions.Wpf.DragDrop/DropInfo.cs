﻿using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using GongSolutions.Wpf.DragDrop.Utilities;

namespace GongSolutions.Wpf.DragDrop
{
    /// <summary>
    /// Holds information about a the target of a drag drop operation.
    /// </summary>
    /// 
    /// <remarks>
    /// The <see cref="DropInfo"/> class holds all of the framework's information about the current 
    /// target of a drag. It is used by <see cref="IDropTarget.DragOver"/> method to determine whether 
    /// the current drop target is valid, and by <see cref="IDropTarget.Drop"/> to perform the drop.
    /// </remarks>
    public class DropInfo
    {
        /// <summary>
        /// Initializes a new instance of the DropInfo class.
        /// </summary>
        /// 
        /// <param name="sender">
        /// The sender of the drag event.
        /// </param>
        /// 
        /// <param name="e">
        /// The drag event.
        /// </param>
        /// 
        /// <param name="dragInfo">
        /// Information about the source of the drag, if the drag came from within the framework.
        /// </param>
        public DropInfo(object sender, DragEventArgs e, DragInfo dragInfo)
        {
            string dataFormat = DragDrop.DataFormat.Name;
            Data = (e.Data.GetDataPresent(dataFormat)) ? e.Data.GetData(dataFormat) : e.Data;
            DragInfo = dragInfo;

            VisualTarget = sender as UIElement;

            if (sender is ItemsControl)
            {
                ItemsControl itemsControl = (ItemsControl)sender;
                UIElement item = itemsControl.GetItemContainerAt(e.GetPosition(itemsControl));

                VisualTargetOrientation = itemsControl.GetItemsPanelOrientation();

                if (item != null)
                {
                    ItemsControl itemParent = ItemsControl.ItemsControlFromItemContainer(item);

                    InsertIndex = itemParent.ItemContainerGenerator.IndexFromContainer(item);
                    TargetCollection = itemParent.ItemsSource ?? itemParent.Items;
                    TargetItem = itemParent.ItemContainerGenerator.ItemFromContainer(item);
                    VisualTargetItem = item;

                    if (VisualTargetOrientation == Orientation.Vertical)
                    {
                        if (e.GetPosition(item).Y > item.RenderSize.Height / 2) InsertIndex++;
                    }
                    else
                    {
                        if (e.GetPosition(item).X > item.RenderSize.Width / 2) InsertIndex++;
                    }
                }
                else
                {
                    TargetCollection = itemsControl.ItemsSource ?? itemsControl.Items;
                    InsertIndex = itemsControl.Items.Count;
                }
            }
        }

        /// <summary>
        /// Gets the drag data.
        /// </summary>
        /// 
        /// <remarks>
        /// If the drag came from within the framework, this will hold:
        /// 
        /// - The dragged data if a single item was dragged.
        /// - A typed IEnumerable if multiple items were dragged.
        /// </remarks>
        public object Data { get; private set; }

        /// <summary>
        /// Gets a <see cref="DragInfo"/> object holding information about the source of the drag, 
        /// if the drag came from within the framework.
        /// </summary>
        public DragInfo DragInfo { get; private set; }

        /// <summary>
        /// Gets or sets the class of drop target to display.
        /// </summary>
        /// 
        /// <remarks>
        /// The standard drop target adorner classes are held in the <see cref="DropTargetAdorners"/>
        /// class.
        /// </remarks>
        public Type DropTargetAdorner { get; set; }

        /// <summary>
        /// Gets or sets the allowed effects for the drop.
        /// </summary>
        /// 
        /// <remarks>
        /// This must be set to a value other than <see cref="DragDropEffects.None"/> by a drop handler in order 
        /// for a drop to be possible.
        /// </remarks>
        public DragDropEffects Effects { get; set; }

        /// <summary>
        /// Gets the current insert position within <see cref="TargetCollection"/>.
        /// </summary>
        public int InsertIndex { get; private set; }

        /// <summary>
        /// Gets the collection that the target ItemsControl is bound to.
        /// </summary>
        /// 
        /// <remarks>
        /// If the current drop target is unbound or not an ItemsControl, this will be null.
        /// </remarks>
        public IEnumerable TargetCollection { get; private set; }

        /// <summary>
        /// Gets the object that the current drop target is bound to.
        /// </summary>
        /// 
        /// <remarks>
        /// If the current drop target is unbound or not an ItemsControl, this will be null.
        /// </remarks>
        public object TargetItem { get; private set; }

        /// <summary>
        /// Gets the control that is the current drop target.
        /// </summary>
        public UIElement VisualTarget { get; private set; }

        /// <summary>
        /// Gets the item in an ItemsControl that is the current drop target.
        /// </summary>
        /// 
        /// <remarks>
        /// If the current drop target is unbound or not an ItemsControl, this will be null.
        /// </remarks>
        public UIElement VisualTargetItem { get; private set; }

        /// <summary>
        /// Gets th orientation of the current drop target.
        /// </summary>
        public Orientation VisualTargetOrientation { get; private set; }
    }
}
