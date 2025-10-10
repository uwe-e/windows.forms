using System.Windows.Controls;
using System.Windows;
using System.IO;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System;
using System.Windows.Input;
using System.Linq;
using System.Windows.Threading;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Represents a control that displays a list of <see cref="IImageFlowItem"/> objects.
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(ImageFlowItem))]
    public class ImageFlowPanel : ItemsControl
    {
        #region Events
        /// <summary>
        /// Occurs when the <see cref="ImageFlowPanel.CacheDirectoryInfo"/> for this element changes.
        /// </summary>
        public static readonly RoutedEvent CacheDirectoryChangedEvent = EventManager.RegisterRoutedEvent(
            "CacheDirectoryChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<DirectoryInfo>), typeof(ImageFlowPanel));
        /// <summary>
        /// Identifies the <see cref="SelectedItemMouseDown"/> routed event.
        /// </summary>
        public static readonly RoutedEvent SelectedItemMouseDownEvent = EventManager.RegisterRoutedEvent(
                    "SelectedItemMouseDown", RoutingStrategy.Bubble,
                    typeof(ImageFlowItemMouseEventHandler), typeof(ImageFlowPanel));
        /// <summary>
        /// Occurs when any mouse button on the selected <see cref="IImageFlowItem"/> is depressed. 
        /// </summary>
        public event ImageFlowItemMouseEventHandler SelectedItemMouseDown
        {
            add { this.AddHandler(SelectedItemMouseDownEvent, value); }
            remove { this.RemoveHandler(SelectedItemMouseDownEvent, value); }
        }
        /// <summary>
        /// Identifies the <see cref="SelectedItemMouseDoubleClick"/> routed event.
        /// </summary>
        public static readonly RoutedEvent SelectedItemMouseDoubleClickEvent = EventManager.RegisterRoutedEvent(
                    "SelectedItemMouseDoubleClick", RoutingStrategy.Bubble,
                    typeof(ImageFlowItemMouseEventHandler), typeof(ImageFlowPanel));
        /// <summary>
        /// Occurs when any mouse button on the selected <see cref="IImageFlowItem"/> is clicked two or more times.
        /// </summary>
        public event ImageFlowItemMouseEventHandler SelectedItemMouseDoubleClick
        {
            add { this.AddHandler(SelectedItemMouseDoubleClickEvent, value); }
            remove { this.RemoveHandler(SelectedItemMouseDoubleClickEvent, value); }
        }
        #endregion

        #region FieldsPublic
        /// <summary>
        /// Identifies the CacheDirectoryInfo dependency property.
        /// </summary>
        public static readonly DependencyProperty CacheDirectoryInfoProperty
            = DependencyProperty.Register("CacheDirectoryInfo", typeof(DirectoryInfo), typeof(ImageFlowPanel),
                new PropertyMetadata(new PropertyChangedCallback(OnCacheDirectoryChanged)));
        /// <summary>
        /// Identifies the SelectedCoverFlowItem dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedCoverFlowItemProperty
            = DependencyProperty.Register("SelectedCoverFlowItem", typeof(IImageFlowItem), typeof(ImageFlowPanel),
            new PropertyMetadata(new PropertyChangedCallback(OnSelectedCoverFlowItemChanged)));

        public static readonly DependencyProperty SelectedItemProperty
            = DependencyProperty.Register("SelectedItem", typeof(IImageFlowItem), typeof(ImageFlowPanel),
            new FrameworkPropertyMetadata(null));

        #endregion

        #region FieldsPrivate
        private ImageSource m_defaultImageSource;
        private Storyboard m_storyboard;
        private ModelVisual3D m_modelVisual3D;
        private bool m_bDisableMouseHitTesting;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the collection used to generate the content of the ImageFlowPanel control.
        /// </summary>
        //[Microsoft.Windows.Design.PropertyEditing.NewItemTypes(typeof(ImageFlowItem))]
        [Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ItemCollection Items
        {
            get { return base.Items; }
        }
        /// <summary>
        /// Gets or sets the number of visible <see cref="ImageFlowItem"/> objects within the viewport.
        /// </summary>
        public int VisibleImagesPerSide
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the selected <see cref="IImageFlowItem"/> item or returns null if the selection is empty This is a dependency property. 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(true), ReadOnly(true), Category("Appearance")]
        public IImageFlowItem SelectedItem
        {
            get
            {
                return (IImageFlowItem)this.GetValue(SelectedItemProperty);
            }
            private set
            {
                this.SetValue(SelectedItemProperty,value);
            }
        }
        /// <summary>
        /// Gets the name of the Coverflow assembly.
        /// </summary>
        private static string AssemblyName
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="DirectoryInfo"/> for the used cache directory.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(true)]
        public DirectoryInfo CacheDirectoryInfo
        {
            get
            {
                return (DirectoryInfo)this.GetValue(CacheDirectoryInfoProperty);
            }
            set
            {
                this.SetValue(CacheDirectoryInfoProperty, value);
            }
        }

        private static DirectoryInfo DefaultCacheDirectory
        {
            get
            {
                string strApplicationDataPath = System.IO.Path.Combine(
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                        Constants.ApplicationBaseDataDirectoryName);

                return new DirectoryInfo(
                        System.IO.Path.Combine(strApplicationDataPath, ImageFlowPanel.AssemblyName));
            }
        }

        private List<IImageFlowItem> RealizedChildren
        {
            get;
            set;
        }
        private Queue<IImageFlowItem> RemoveableChildren
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the selected <see cref="IImageFlowItem"/>.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(true)]
        public IImageFlowItem SelectedCoverFlowItem
        {
            get
            {
                return (IImageFlowItem)base.GetValue(SelectedCoverFlowItemProperty);
            }
            set
            {
                base.SetValue(SelectedCoverFlowItemProperty, value);
            }
        }
        private Queue<IImageFlowItem> SelectableItems
        {
            get;
            set;
        }

        private WorkingState WorkingState
        {
            get;
            set;
        }
        private int StartPosition
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the <see cref="ModelVisual3D"/> from the resources.
        /// </summary>
        private ModelVisual3D ModelVisual3D
        {
            get
            {
                if (this.m_modelVisual3D == null)
                {
                    this.m_modelVisual3D = this.FindResource("ModelVisual3D") as ModelVisual3D;
                }
                return this.m_modelVisual3D;
            }
        }
        /// <summary>
        /// Gets the <see cref="Storyboard"/> from the resources.
        /// </summary>
        private Storyboard Storyboard
        {
            get
            {
                if (this.m_storyboard == null)
                {
                    this.m_storyboard = this.FindResource("ModelAnimation") as Storyboard;
                }
                return this.m_storyboard;
            }
        }
        private ScrollBar HorizontalScrollBar
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the <see cref="ImageSource"/> for the default image from the resources.
        /// </summary>
        private ImageSource DefaultImageSource
        {
            get
            {
                if (this.m_defaultImageSource == null)
                {
                    System.Windows.Controls.Image image = this.FindResource("DefaultImage") as System.Windows.Controls.Image;
                    this.m_defaultImageSource = image.Source;
                    this.m_defaultImageSource.Freeze();
                    image = null;
                }
                return this.m_defaultImageSource;
            }
        }
        private Viewport3D Viewport
        {
            get;
            set;
        }
        private ModelVisual3D ModelVisual
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFlowPanel"/> class.
        /// </summary>
        public ImageFlowPanel()
        {
            this.VisibleImagesPerSide = 6;
            this.CacheDirectoryInfo = DefaultCacheDirectory;
            this.RealizedChildren = new List<IImageFlowItem>();
            this.RemoveableChildren = new Queue<IImageFlowItem>();
            this.SelectableItems = new Queue<IImageFlowItem>(2);
            this.WorkingState = WorkingState.None;
            this.Background = new SolidColorBrush(System.Windows.Media.Colors.Black);
        }

        static ImageFlowPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ImageFlowPanel), new FrameworkPropertyMetadata(typeof(ImageFlowPanel)));
        }
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.Viewport = base.GetTemplateChild("PART_ViewPort") as Viewport3D;
            if (this.Viewport != null)
            {
                this.Viewport.MouseDown += new MouseButtonEventHandler(ImageFlowPanelMouseDown);
            }
            this.ModelVisual = base.GetTemplateChild("PART_VisualModel") as ModelVisual3D;
            this.HorizontalScrollBar = base.GetTemplateChild("PART_HorizontalScrollBar") as ScrollBar;
            if (this.HorizontalScrollBar != null)
            {
                this.HorizontalScrollBar.Scroll += new ScrollEventHandler(HorizontalScrollBarScroll);
            }
        }
        /// <summary>
        /// Sets the selected <see cref="IImageFlowItem"/> item. 
        /// </summary>
        /// <param name="item">The <see cref="IImageFlowItem"/> item that should be selected.</param>
        public void SetSelectedItem(IImageFlowItem item)
        {
            this.AddToSelectableItemsQueue(item);
            this.HorizontalScrollBar.Value = this.Items.IndexOf(item);
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Invoked when the <see cref="ImageFlowPanel.Items"/> property changes.
        /// </summary>
        /// <param name="e">Information about the change.</param>
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (this.Items.Count <= this.VisibleImagesPerSide + 1)
                    {
                        IImageFlowItem newImageFlowItem = e.NewItems[0] as IImageFlowItem;
                        if (newImageFlowItem != null)
                        {
                            CreateImageFlowItem(newImageFlowItem, e.NewStartingIndex);
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    this.Reset();
                    break;
            }
        }
        /// <summary>
        /// Called when the <see cref="ItemsControl.ItemsSource"/> property changes.
        /// </summary>
        /// <param name="oldValue">Old value of the <see cref="ItemsControl.ItemsSource"/> property.</param>
        /// <param name="newValue">New value of the <see cref="ItemsControl.ItemsSource"/> property.</param>
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            if (newValue != null)
            {
                List<IImageFlowItem> imageFlowItems = newValue.Cast<IImageFlowItem>().ToList();

                this.HorizontalScrollBar.Minimum = 0;
                this.HorizontalScrollBar.Value = 0;
                this.HorizontalScrollBar.Maximum = imageFlowItems.Count - 1;
                this.HorizontalScrollBar.LargeChange = 1;
                this.HorizontalScrollBar.SmallChange = 1;

                List<IImageFlowItem> creatableItems = imageFlowItems.Take(this.VisibleImagesPerSide + 1).ToList();
                creatableItems.ForEach(delegate(IImageFlowItem item)
                {
                    CreateImageFlowItem(item, this.RealizedChildren.Count);
                });
            }
        }
        /// <summary>
        /// Raises the <see cref="ImageFlowPanel.CacheDirectoryChangedEvent"/> event.
        /// </summary>
        /// <param name="args">Arguments associated with the <see cref="ImageFlowPanel.CacheDirectoryChangedEvent"/> event.</param>
        protected virtual void OnCacheDirectoryChanged(RoutedPropertyChangedEventArgs<DirectoryInfo> args)
        {
            DirectoryInfo directoryInfo = args.NewValue as DirectoryInfo;
            if ((directoryInfo != null) && (directoryInfo.Exists == false))
            {
                directoryInfo.Create();
            }
            RaiseEvent(args);
        }
        #endregion

        #region MethodsPrivate
        private void CreateImageFlowItem(IImageFlowItem item, int iPosition)
        {
            IImageFlowItem imageFlowItem = (IImageFlowItem)item.Clone();
            imageFlowItem.Background = this.Background;
            imageFlowItem.DefaultImageSource = this.DefaultImageSource;
            imageFlowItem.ModelVisual3D = this.ModelVisual3D;
            imageFlowItem.Storyboard = this.Storyboard;
            imageFlowItem.Position = iPosition;
            imageFlowItem.CacheDirectoryInfo = this.CacheDirectoryInfo;
            imageFlowItem.Viewport3DIndex = this.ModelVisual.Children.Count;
            imageFlowItem.PrepareItem();
            this.ModelVisual.Children.Add(imageFlowItem.ModelVisual3D);

            if (iPosition < 0)
            {
                this.RealizedChildren.Insert(0, imageFlowItem);
            }
            else
            {
                this.RealizedChildren.Add(imageFlowItem);
            }
        }

        private void AddToSelectableItemsQueue(IImageFlowItem item)
        {
            this.SelectableItems.Enqueue(item);
            DequeueItems();
        }
        
        private void DequeueItems()
        {
            if (this.SelectableItems.Count > 0)
            {
                if (this.WorkingState == WorkingState.Working)
                {
                    return;
                }
                else
                {
                    this.WorkingState = WorkingState.Working;
                    //IImageFlowItem selectedItem = this.SelectableItems.Dequeue();
                    IImageFlowItem selectedItem = this.SelectableItems.Last();
                    if (selectedItem != null)
                    {
                        SetSelectItemImpl(selectedItem);
                    }
                }
            }
        }

        private void SetSelectItemImpl(IImageFlowItem imageFlowItem)
        {
            this.m_bDisableMouseHitTesting = true;
            int iCurrentPosition = 0;
            int iCounter = 0;
            int iNewPosition = 0;

            if (imageFlowItem != null)
            {
                foreach (IImageFlowItem item in this.Items)
                {
                    if ((this.SelectedItem != null) && (this.SelectedItem.Equals(item) == true))
                    {
                        iCurrentPosition = iCounter;
                    }
                    if (item.Equals(imageFlowItem) == true)
                    {
                        iNewPosition = iCounter;
                    }
                    iCounter++;
                }
                int iPosition = 0;
                {
                    iPosition = iNewPosition - iCurrentPosition;
                }
                if (Math.Abs(iPosition) > Constants.MaxScrollStep)
                {
                    //The value for the abbreviation
                    int iAbbreviationValue = Math.Abs(iPosition) - (2 * this.VisibleImagesPerSide);
                    if (iPosition < 0)
                    {
                        iPosition += iAbbreviationValue;
                        this.StartPosition -= iAbbreviationValue - 1;
                        PageLeft();
                    }
                    else
                    {
                        iPosition -= iAbbreviationValue;
                        this.StartPosition += iAbbreviationValue - 1;
                        PageRight();
                    }
                }

                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(this.SelectItemsTimerTick);
                dispatcherTimer.Tag = iPosition;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 0);
                dispatcherTimer.Start();
            }
        }
        
        private void PageLeft()
        {
            CleanUpUnusedItems();

            int iIndex = this.StartPosition - this.VisibleImagesPerSide - 1;
            if (iIndex >= 0)
            {
                IImageFlowItem newItem = this.Items.GetItemAt(iIndex) as IImageFlowItem;
                this.CreateImageFlowItem(newItem, -(this.VisibleImagesPerSide + 1));
            }

            if (this.RealizedChildren.Count > 0)
            {
                IImageFlowItem removableItem = this.RealizedChildren.Last();
                if (removableItem != null)
                {
                    if ((this.StartPosition >= (this.VisibleImagesPerSide * -2)) &&
                        (removableItem.Position < -(this.VisibleImagesPerSide - 1)) || (removableItem.Position > (this.VisibleImagesPerSide - 1)))
                    {
                        this.RemoveableChildren.Enqueue(removableItem);
                        removableItem.Storyboard.CurrentStateInvalidated += new EventHandler(this.StoryboardCurrentStateInvalidated);
                    }
                }
            }

            double yRotation = 0.0;
            double dOffsetX = 0.0;
            double dOffsetY = 0.0;
            double dOffsetZ = 0.0;
            this.RealizedChildren
                .ForEach(delegate(IImageFlowItem item)
                {
                    item.Position++;
                    item.GetOffsetsFromPosition(item.Position, out yRotation, out dOffsetX, out dOffsetY, out dOffsetZ);
                    AnimateByParameters(item, yRotation, dOffsetX, dOffsetY, dOffsetZ);
                });
            this.StartPosition--;
        }

        private void PageRight()
        {
            CleanUpUnusedItems();

            int iIndex = this.StartPosition + this.VisibleImagesPerSide + 1;
            if (iIndex < this.Items.Count)
            {
                IImageFlowItem newItem = this.Items.GetItemAt(iIndex) as IImageFlowItem;
                this.CreateImageFlowItem(newItem, this.VisibleImagesPerSide + 1);
            }

            if (this.RealizedChildren.Count > 0)
            {
                IImageFlowItem removableItem = this.RealizedChildren.First();
                if ((removableItem != null) && (removableItem.Position < -(this.VisibleImagesPerSide - 1)))
                {
                    this.RemoveableChildren.Enqueue(removableItem);
                    removableItem.Storyboard.CurrentStateInvalidated += new EventHandler(this.StoryboardCurrentStateInvalidated);
                }
            }

            double yRotation = 0.0;
            double dOffsetX = 0.0;
            double dOffsetY = 0.0;
            double dOffsetZ = 0.0;
            this.RealizedChildren
                .ForEach(delegate(IImageFlowItem item)
                {
                    item.Position--;
                    item.GetOffsetsFromPosition(item.Position, out yRotation, out dOffsetX, out dOffsetY, out dOffsetZ);
                    AnimateByParameters(item, yRotation, dOffsetX, dOffsetY, dOffsetZ);
                });
            this.StartPosition++;
        }
        private void AnimateByParameters(IImageFlowItem item, double angle, double offsetX, double offsetY, double offsetZ)
        {
            this.AnimateByParameters(item, angle, offsetX, offsetY, offsetZ, new Duration(TimeSpan.FromSeconds(0.6)));
        }

        private void AnimateByParameters(IImageFlowItem item, double angle, double offsetX, double offsetY, double offsetZ, Duration duration)
        {
            Rotation3DAnimation rotation3DAnimation = item.Storyboard.Children[0] as Rotation3DAnimation;
            ChangeViewport3DIndex(rotation3DAnimation, item.Viewport3DIndex, AnimationProperty.AxisAngleRotation3D);
            rotation3DAnimation.To = new AxisAngleRotation3D(new Vector3D(0, 1, 0), angle);
            rotation3DAnimation.Duration = duration.TimeSpan;

            DoubleAnimation doubleAnimationX = item.Storyboard.Children[1] as DoubleAnimation;
            ChangeViewport3DIndex(doubleAnimationX, item.Viewport3DIndex, AnimationProperty.OffsetX);
            doubleAnimationX.Duration = duration.TimeSpan;
            doubleAnimationX.To = offsetX;

            DoubleAnimation doubleAnimationY = item.Storyboard.Children[2] as DoubleAnimation;
            ChangeViewport3DIndex(doubleAnimationY, item.Viewport3DIndex, AnimationProperty.OffsetY);
            doubleAnimationY.Duration = duration.TimeSpan;
            doubleAnimationY.To = offsetY;

            DoubleAnimation doubleAnimationZ = item.Storyboard.Children[3] as DoubleAnimation;
            ChangeViewport3DIndex(doubleAnimationZ, item.Viewport3DIndex, AnimationProperty.OffsetZ);
            doubleAnimationZ.Duration = duration.TimeSpan;
            doubleAnimationZ.To = offsetZ;

            if (this.ModelVisual.Children.Contains(item.ModelVisual3D))
            {
                item.Storyboard.Begin(this.Viewport, HandoffBehavior.Compose, true);
            }
        }

        private static void ChangeViewport3DIndex(Timeline animation, int viewport3DIndex, AnimationProperty animationProperty)
        {
            string strPath = string.Empty;
            switch (animationProperty)
            {
                case AnimationProperty.AxisAngleRotation3D:
                    strPath = "(0).[2].(1).[" + viewport3DIndex + "].(2).(3).(4).[0].(5)";
                    break;
                case AnimationProperty.OffsetX:
                    strPath = "(0).[2].(1).[" + viewport3DIndex + "].(2).(3).(4).[1].(5)";
                    break;
                case AnimationProperty.OffsetY:
                    strPath = "(0).[2].(1).[" + viewport3DIndex + "].(2).(3).(4).[1].(5)";
                    break;
                case AnimationProperty.OffsetZ:
                    strPath = "(0).[2].(1).[" + viewport3DIndex + "].(2).(3).(4).[1].(5)";
                    break;
            }
            PropertyPath targetProperty = Storyboard.GetTargetProperty(animation);
            targetProperty.Path = strPath;
            Storyboard.SetTargetProperty(animation, targetProperty);
        }

        private static void UpdateViewport3DIndex(IImageFlowItem imageFlowItem)
        {
            Rotation3DAnimation rotation3DAnimation = imageFlowItem.Storyboard.Children[0] as Rotation3DAnimation;
            ChangeViewport3DIndex(rotation3DAnimation, imageFlowItem.Viewport3DIndex, AnimationProperty.AxisAngleRotation3D);

            DoubleAnimation doubleAnimationX = imageFlowItem.Storyboard.Children[1] as DoubleAnimation;
            ChangeViewport3DIndex(doubleAnimationX, imageFlowItem.Viewport3DIndex, AnimationProperty.OffsetX);

            DoubleAnimation doubleAnimationY = imageFlowItem.Storyboard.Children[2] as DoubleAnimation;
            ChangeViewport3DIndex(doubleAnimationY, imageFlowItem.Viewport3DIndex, AnimationProperty.OffsetY);

            DoubleAnimation doubleAnimationZ = imageFlowItem.Storyboard.Children[3] as DoubleAnimation;
            ChangeViewport3DIndex(doubleAnimationZ, imageFlowItem.Viewport3DIndex, AnimationProperty.OffsetZ);
        }

        private void StoryboardCurrentStateInvalidated(object sender, EventArgs e)
        {
            ClockGroup group = sender as ClockGroup;
            if (group.CurrentState != ClockState.Active)
            {
                this.CleanUpUnusedItems();
            }
        }

        private void Reset()
        {
            this.StartPosition = 0;
            this.SelectedItem = null;
            if (this.RealizedChildren.Count > 0)
            {
                this.RealizedChildren.ForEach(delegate(IImageFlowItem item)
                {
                    this.RemoveableChildren.Enqueue(item);
                    item.Storyboard.CurrentStateInvalidated += new EventHandler(this.StoryboardCurrentStateInvalidated);
                });
            }
            CleanUpUnusedItems();
        }

        private void CleanUpUnusedItems()
        {
            while (this.RemoveableChildren.Count > 0)
            {
                using (ImageFlowItem removedItem = this.RemoveableChildren.Dequeue() as ImageFlowItem)
                {
                    if (removedItem != null)
                    {
                        this.RealizedChildren.Remove(removedItem);
                        int index = this.ModelVisual.Children.IndexOf(removedItem.ModelVisual3D);
                        if (index > -1)
                        {
                            this.ModelVisual.Children.RemoveAt(index);
                            this.RealizedChildren.ForEach(delegate(IImageFlowItem imageFlowItem)
                            {
                                if (imageFlowItem.Viewport3DIndex > index)
                                {
                                    imageFlowItem.Viewport3DIndex--;
                                    UpdateViewport3DIndex(imageFlowItem);
                                }
                            });
                        }
                    }
                }
            }
        }

        private void SelectItemsTimerTick(object sender, EventArgs e)
        {
            DispatcherTimer dispatcherTimer = sender as DispatcherTimer;
            int iPosition = (int)dispatcherTimer.Tag;
            if (iPosition < 0)
            {
                this.PageLeft();
                iPosition++;
            }
            else if (iPosition > 0)
            {
                this.PageRight();
                iPosition--;
            }
            dispatcherTimer.Tag = iPosition;
            if (iPosition == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;

                this.m_bDisableMouseHitTesting = false;
                this.WorkingState = WorkingState.None;
                this.SelectedItem = (from item in this.RealizedChildren
                                     where item.Position == 0
                                     select item).FirstOrDefault();
            }
        }
        private void ImageFlowPanelMouseDown(object sender, MouseButtonEventArgs e)
        {
            IImageFlowItem selectableItem = null;
            Point positionPoint = e.GetPosition(this.Viewport);
            var rayMeshGeometry3DHitTestResult = VisualTreeHelper.HitTest(this.Viewport, positionPoint) as RayMeshGeometry3DHitTestResult;
            if (rayMeshGeometry3DHitTestResult != null)
            {
                ModelVisual3D modelVisual3D = rayMeshGeometry3DHitTestResult.VisualHit as ModelVisual3D;

                selectableItem = (from imageFlowItem in this.RealizedChildren
                                  where imageFlowItem.Matches(modelVisual3D)
                                  select imageFlowItem).FirstOrDefault();
                if ((selectableItem != null) && (this.m_bDisableMouseHitTesting == false))
                {
                    if (selectableItem.Position == 0)
                    {
                        ImageFlowItemMouseEventArgs imageFlowItemMouseDownArgs = new ImageFlowItemMouseEventArgs(
                            e.MouseDevice, e.Timestamp, e.ChangedButton, selectableItem);
                        imageFlowItemMouseDownArgs.RoutedEvent = ImageFlowPanel.SelectedItemMouseDownEvent;
                        this.RaiseEvent(imageFlowItemMouseDownArgs);
                        if (e.ClickCount == 2)
                        {
                            ImageFlowItemMouseEventArgs imageFlowItemMouseDoubleClickArgs = new ImageFlowItemMouseEventArgs(
                                e.MouseDevice, e.Timestamp, e.ChangedButton, selectableItem);
                            imageFlowItemMouseDoubleClickArgs.RoutedEvent = ImageFlowPanel.SelectedItemMouseDoubleClickEvent;
                            this.RaiseEvent(imageFlowItemMouseDoubleClickArgs);
                        }
                    }
                    else
                    {
                        if (e.ChangedButton == MouseButton.Left)
                        {
                            this.AddToSelectableItemsQueue(selectableItem);

                            IImageFlowItem selectedItem = (from IImageFlowItem item in this.Items
                                                           where item.Equals(selectableItem)
                                                           select item).FirstOrDefault();
                            if (selectedItem != null)
                            {
                                this.HorizontalScrollBar.Value = this.Items.IndexOf(selectedItem);
                            }
                        }
                    }
                }
            }
        }

        private void HorizontalScrollBarScroll(object sender, ScrollEventArgs e)
        {
            if (this.WorkingState == WorkingState.None)
            {
                this.SetValueFromScrollbar(e.NewValue);
            }
        }

        private void SetValueFromScrollbar(double scrollBarValue)
        {
            int iValue = Convert.ToInt32(scrollBarValue);
            IImageFlowItem imageFlowItem = (from IImageFlowItem item in this.Items
                                            select item)
                                            .Where((item, index) => index == iValue).FirstOrDefault();
            if (imageFlowItem != null)
            {
                this.AddToSelectableItemsQueue(imageFlowItem);
            }
        }
        private static void OnCacheDirectoryChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ImageFlowPanel imageFlowPanel = d as ImageFlowPanel;
            if (imageFlowPanel != null)
            {
                RoutedPropertyChangedEventArgs<DirectoryInfo> e = new RoutedPropertyChangedEventArgs<DirectoryInfo>(
                    (DirectoryInfo)args.OldValue,
                    (DirectoryInfo)args.NewValue,
                    CacheDirectoryChangedEvent);
                imageFlowPanel.OnCacheDirectoryChanged(e);
            }
        }
        private static void OnSelectedCoverFlowItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ImageFlowPanel imageFlowPanel = d as ImageFlowPanel;
            if (imageFlowPanel != null)
            {
                IImageFlowItem imageFlowItem = args.NewValue as IImageFlowItem;
                if (imageFlowItem != null)
                {
                    imageFlowPanel.SetSelectedItem(imageFlowItem);
                }
            }
        }
        #endregion
    }
}
