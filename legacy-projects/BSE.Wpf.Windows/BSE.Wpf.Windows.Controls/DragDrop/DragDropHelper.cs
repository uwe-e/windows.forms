using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;
using System.Collections;

namespace BSE.Wpf.Windows.Controls.DragDrop
{
    public class DragDropHelper
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPublic
        /// <summary>
        /// A <see cref="DataFormat"/> object that defines the name for the specified data format.
        /// </summary>
        public static readonly DataFormat DragDropDataFormat = DataFormats.GetDataFormat("BSEDragDrop");
        #endregion

        #region FieldsPrivate
        private object draggedData;
        private Point initialMousePosition;
        private bool hasVerticalOrientation;
        private bool isInFirstHalf;
        private Window topWindow;
        private int insertionIndex;
        private ItemsControl sourceItemsControl;
        private FrameworkElement sourceItemContainer;
        // target
        private ItemsControl targetItemsControl;
        private FrameworkElement targetItemContainer;
        private InsertionAdorner insertionAdorner;
        private static DragDropHelper m_instance;
        #endregion

        #region Properties
        #endregion

        #region MethodsPublic
        public static bool GetIsDragSource(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsDragSourceProperty);
        }

        public static void SetIsDragSource(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsDragSourceProperty, value);
        }

        public static readonly DependencyProperty IsDragSourceProperty =
            DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDragSourceChanged));


        public static bool GetIsDropTarget(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsDropTargetProperty);
        }

        public static void SetIsDropTarget(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsDropTargetProperty, value);
        }

        public static readonly DependencyProperty IsDropTargetProperty =
            DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDropTargetChanged));

        public static DataTemplate GetDragDropTemplate(DependencyObject dependencyObject)
        {
            return (DataTemplate)dependencyObject.GetValue(DragDropTemplateProperty);
        }

        public static void SetDragDropTemplate(DependencyObject dependencyObject, DataTemplate value)
        {
            dependencyObject.SetValue(DragDropTemplateProperty, value);
        }

        public static readonly DependencyProperty DragDropTemplateProperty =
            DependencyProperty.RegisterAttached("DragDropTemplate", typeof(DataTemplate), typeof(DragDropHelper), new UIPropertyMetadata(null));

        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        private static DragDropHelper Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new DragDropHelper();
                }
                return m_instance;
            }
        }
        
        private static void IsDragSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var dragSource = dependencyObject as ItemsControl;
            if (dragSource != null)
            {
                if (Object.Equals(e.NewValue, true))
                {
                    dragSource.PreviewMouseLeftButtonDown += Instance.DragSource_PreviewMouseLeftButtonDown;
                    dragSource.PreviewMouseLeftButtonUp += Instance.DragSource_PreviewMouseLeftButtonUp;
                    dragSource.PreviewMouseMove += Instance.DragSource_PreviewMouseMove;
                }
                else
                {
                    dragSource.PreviewMouseLeftButtonDown -= Instance.DragSource_PreviewMouseLeftButtonDown;
                    dragSource.PreviewMouseLeftButtonUp -= Instance.DragSource_PreviewMouseLeftButtonUp;
                    dragSource.PreviewMouseMove -= Instance.DragSource_PreviewMouseMove;
                }
            }
        }

        private static void IsDropTargetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var dropTarget = obj as ItemsControl;
            if (dropTarget != null)
            {
                if (Object.Equals(e.NewValue, true))
                {
                    dropTarget.AllowDrop = true;
                    dropTarget.PreviewDrop += Instance.DropTarget_PreviewDrop;
                    dropTarget.PreviewDragEnter += Instance.DropTarget_PreviewDragEnter;
                    dropTarget.PreviewDragOver += Instance.DropTarget_PreviewDragOver;
                    dropTarget.PreviewDragLeave += Instance.DropTarget_PreviewDragLeave;
                }
                else
                {
                    dropTarget.AllowDrop = false;
                    dropTarget.PreviewDrop -= Instance.DropTarget_PreviewDrop;
                    dropTarget.PreviewDragEnter -= Instance.DropTarget_PreviewDragEnter;
                    dropTarget.PreviewDragOver -= Instance.DropTarget_PreviewDragOver;
                    dropTarget.PreviewDragLeave -= Instance.DropTarget_PreviewDragLeave;
                }
            }
        }

        private void DragSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.sourceItemsControl = (ItemsControl)sender;
            Visual visual = e.OriginalSource as Visual;

            this.topWindow = Window.GetWindow(this.sourceItemsControl);
            this.initialMousePosition = e.GetPosition(this.topWindow);

            this.sourceItemContainer = sourceItemsControl.ContainerFromElement(visual) as FrameworkElement;
            if (this.sourceItemContainer != null)
            {
                ListBox sourceView = this.sourceItemsControl as ListBox;
                if (sourceView != null && sourceView.SelectedItems.Count > 1)
                {
                    object[] draggedItems = new object[sourceView.SelectedItems.Count];
                    sourceView.SelectedItems.CopyTo(draggedItems,0);

                    this.draggedData = draggedItems;
                }
                else
                {
                    this.draggedData = this.sourceItemContainer.DataContext;
                }
            }
        }

        // Drag = mouse down + move by a certain amount
        private void DragSource_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.draggedData != null)
            {
                // Only drag when user moved the mouse by a reasonable amount.
                if (DragDropUtilities.IsMovementBigEnough(this.initialMousePosition, e.GetPosition(this.topWindow)))
                {
                    using (DragDropWindow dragDropWindow = new DragDropWindow(this.sourceItemsControl, this.sourceItemContainer))
                    {
                        dragDropWindow.Show();
                        DataObject data = new DataObject(DragDropDataFormat.Name, this.draggedData);
                        DragDropEffects effects = System.Windows.DragDrop.DoDragDrop((DependencyObject)sender, data, DragDropEffects.Move);
                        this.draggedData = null;
                    }
                }
            }
        }

        private void DragSource_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.draggedData = null;
        }

        private void DropTarget_PreviewDragEnter(object sender, DragEventArgs e)
        {
            this.targetItemsControl = (ItemsControl)sender;
            object draggedItem = e.Data.GetData(DragDropDataFormat.Name);

            this.DecideDropTarget(e);
            if (draggedItem != null)
            {
                this.CreateInsertionAdorner();
            }
            e.Handled = true;
        }

        private void DropTarget_PreviewDragOver(object sender, DragEventArgs e)
        {
            object draggedItem = e.Data.GetData(DragDropDataFormat.Name);

            this.DecideDropTarget(e);
            if (draggedItem != null)
            {
                this.UpdateInsertionAdornerPosition();
            }
            e.Handled = true;
        }

        private void DropTarget_PreviewDrop(object sender, DragEventArgs e)
        {
            object draggedItem = e.Data.GetData(DragDropDataFormat.Name);
            int indexRemoved = -1;

            if (draggedItem != null)
            {
                if (e.KeyStates == DragDropKeyStates.ControlKey)
                {
                    ICloneable clonableItem = draggedItem as ICloneable;
                    if (clonableItem != null)
                    {
                        draggedItem = clonableItem.Clone();
                    }
                    e.Effects = DragDropEffects.Copy;
                }
                
                
                if (((e.Effects & DragDropEffects.Move) != 0) && this.sourceItemsControl != null && this.sourceItemsControl.AllowDrop == true)
                {
                    indexRemoved = DragDropUtilities.RemoveItemFromItemsControl(this.sourceItemsControl, draggedItem);
                }
                // This happens when we drag an item to a later position within the same ItemsControl.
                if (indexRemoved != -1 && this.sourceItemsControl == this.targetItemsControl && indexRemoved < this.insertionIndex)
                {
                    this.insertionIndex--;
                }
                if (typeof(IDropableItemsControl).IsAssignableFrom(this.targetItemsControl.GetType()) == true)
                {
                    IDropableItemsControl dropableItemsControl = this.targetItemsControl as IDropableItemsControl;
                    if (dropableItemsControl != null)
                    {
                        ItemDropEventArgs itemDropEventArgs = new ItemDropEventArgs(
                            e.Data,e.AllowedEffects, insertionIndex);
                        itemDropEventArgs.RoutedEvent = SharedEvents.ItemDropEvent.AddOwner(this.targetItemsControl.GetType());
                        this.targetItemsControl.RaiseEvent(itemDropEventArgs);
                    }
                }
                else
                {
                    DragDropUtilities.InsertItemInItemsControl(this.targetItemsControl, draggedItem, this.insertionIndex);
                }
                RemoveInsertionAdorner();
            }
            e.Handled = true;
        }

        private void DropTarget_PreviewDragLeave(object sender, DragEventArgs e)
        {
            // Dragged Adorner is only created once on DragEnter + every time we enter the window. 
            // It's only removed once on the DragDrop, and every time we leave the window. (so no need to remove it here)
            //object draggedItem = e.Data.GetData(this.format.Name);
            object draggedItem = e.Data;

            if (draggedItem != null)
            {
                this.RemoveInsertionAdorner();
            }
            e.Handled = true;
        }

        // If the types of the dragged data and ItemsControl's source are compatible, 
        // there are 3 situations to have into account when deciding the drop target:
        // 1. mouse is over an items container
        // 2. mouse is over the empty part of an ItemsControl, but ItemsControl is not empty
        // 3. mouse is over an empty ItemsControl.
        // The goal of this method is to decide on the values of the following properties: 
        // targetItemContainer, insertionIndex and isInFirstHalf.
        private void DecideDropTarget(DragEventArgs e)
        {
            int targetItemsControlCount = this.targetItemsControl.Items.Count;
            object draggedItem = e.Data.GetData(DragDropDataFormat.Name);

            if (IsDropDataTypeAllowed(draggedItem) == true)
            {
                if (targetItemsControlCount > 0)
                {
                    this.hasVerticalOrientation = DragDropUtilities.HasVerticalOrientation(this.targetItemsControl.ItemContainerGenerator.ContainerFromIndex(0) as FrameworkElement);
                    this.targetItemContainer = targetItemsControl.ContainerFromElement((DependencyObject)e.OriginalSource) as FrameworkElement;

                    if (this.targetItemContainer != null)
                    {
                        Point positionRelativeToItemContainer = e.GetPosition(this.targetItemContainer);
                        this.isInFirstHalf = DragDropUtilities.IsInFirstHalf(this.targetItemContainer, positionRelativeToItemContainer, this.hasVerticalOrientation);
                        this.insertionIndex = this.targetItemsControl.ItemContainerGenerator.IndexFromContainer(this.targetItemContainer);

                        if (this.isInFirstHalf == false)
                        {
                            this.insertionIndex++;
                        }
                    }
                    else
                    {
                        this.targetItemContainer = this.targetItemsControl.ItemContainerGenerator.ContainerFromIndex(targetItemsControlCount - 1) as FrameworkElement;
                        this.isInFirstHalf = false;
                        this.insertionIndex = targetItemsControlCount;
                    }
                }
                else
                {
                    this.targetItemContainer = null;
                    this.insertionIndex = 0;
                }
            }
            else
            {
                this.targetItemContainer = null;
                this.insertionIndex = -1;
                e.Effects = DragDropEffects.None;
            }
        }

        // Can the dragged data be added to the destination collection?
        // It can if destination is bound to IList<allowed type>, IList or not data bound.
        private bool IsDropDataTypeAllowed(object draggedItem)
        {
            bool isDropDataTypeAllowed;
            IEnumerable collectionSource = this.targetItemsControl.ItemsSource;
            if (draggedItem != null)
            {
                if (collectionSource != null)
                {
                    Type draggedType = draggedItem.GetType();
                    Type collectionType = collectionSource.GetType();

                    Type genericIListType = collectionType.GetInterface("IList`1");
                    if (genericIListType != null)
                    {
                        Type[] genericArguments = genericIListType.GetGenericArguments();
                        isDropDataTypeAllowed = genericArguments[0].IsAssignableFrom(draggedType);
                    }
                    else if (typeof(IList).IsAssignableFrom(collectionType))
                    {
                        isDropDataTypeAllowed = true;
                    }
                    else
                    {
                        isDropDataTypeAllowed = false;
                    }
                }
                else // the ItemsControl's ItemsSource is not data bound.
                {
                    isDropDataTypeAllowed = true;
                }
            }
            else
            {
                isDropDataTypeAllowed = false;
            }
            return isDropDataTypeAllowed;
        }

        // Adorners

        private void CreateInsertionAdorner()
        {
            if (this.targetItemContainer != null)
            {
                // Here, I need to get adorner layer from targetItemContainer and not targetItemsControl. 
                // This way I get the AdornerLayer within ScrollContentPresenter, and not the one under AdornerDecorator (Snoop is awesome).
                // If I used targetItemsControl, the adorner would hang out of ItemsControl when there's a horizontal scroll bar.
                var adornerLayer = AdornerLayer.GetAdornerLayer(this.targetItemContainer);
                this.insertionAdorner = new InsertionAdorner(this.hasVerticalOrientation, this.isInFirstHalf, this.targetItemContainer, adornerLayer);
            }
        }

        private void UpdateInsertionAdornerPosition()
        {
            if (this.insertionAdorner != null)
            {
                this.insertionAdorner.IsInFirstHalf = this.isInFirstHalf;
                this.insertionAdorner.InvalidateVisual();
            }
        }

        private void RemoveInsertionAdorner()
        {
            if (this.insertionAdorner != null)
            {
                this.insertionAdorner.Detach();
                this.insertionAdorner = null;
            }
        }
        #endregion

    }
}
