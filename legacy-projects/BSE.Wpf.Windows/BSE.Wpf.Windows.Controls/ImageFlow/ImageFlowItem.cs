using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.IO;
using System.Windows.Media;
using System.Windows.Markup;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media.Imaging;
using System.Windows;
using System.ComponentModel;
using System.Drawing;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Contains the images and the animation properties for one <see cref="ImageFlowItem"/> object.
    /// </summary>
    public class ImageFlowItem : UIElement, IDisposable, IImageFlowItem
    {
        #region Events
        /// <summary>
        /// Occurs when the <see cref="ImageFlowItem.CreateImageSource"/> for this element changes.
        /// </summary>
        public static readonly RoutedEvent CreateImageSourceChangedEvent = EventManager.RegisterRoutedEvent(
                "OnCreateImageSourceChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<CreateImageSource>), typeof(ImageFlowItem));
        /// <summary>
        /// Occurs when the <see cref="ImageFlowItem.Source"/> Source for this element changes.
        /// </summary>
        public static readonly RoutedEvent SourceChangedEvent = EventManager.RegisterRoutedEvent(
            "SourceChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<ImageSource>), typeof(ImageFlowItem));
        
        #endregion

        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="ImageFlowItem.Source"/> dependencyproperty. 
        /// </summary>
        public static readonly DependencyProperty SourceProperty
            = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageFlowItem),
                new PropertyMetadata(new PropertyChangedCallback(OnSourceChanged)));
        /// <summary>
        /// Identifies the <see cref="ImageFlowItem.CreateImageSource"/> dependencyproperty. 
        /// </summary>
        public static readonly DependencyProperty CreateImageSourceProperty
            = DependencyProperty.Register("CreateImageSource", typeof(CreateImageSource), typeof(ImageFlowItem),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ImageFlowItem.OnCreateImageSourceChanged)));

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the current position of the <see cref="ImageFlowItem"/> within the Visual3DCollection.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public int Position
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="ModelVisual3D"/>.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public ModelVisual3D ModelVisual3D
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="Storyboard"/>.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public Storyboard Storyboard
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Viewport3DIndex for the animation.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public int Viewport3DIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="ImageSource"/> of the <see cref="ImageFlowItem"/>.
        /// </summary>
        public ImageSource Source
        {
            get
            {
                return (ImageSource)this.GetValue(SourceProperty);
            }
            set
            {
                this.SetValue(SourceProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="DirectoryInfo"/> for the <b>CacheDirectoryInfo</b>.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public DirectoryInfo CacheDirectoryInfo { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ImageSource"/> of the default image.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public ImageSource DefaultImageSource { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ImageFlowItem.CreateImageSource"/> thread object which creates the image.
        /// </summary>
        public CreateImageSource CreateImageSource
        {
            get
            {
                return (CreateImageSource)this.GetValue(CreateImageSourceProperty);
            }
            set
            {
                this.SetValue(CreateImageSourceProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the name of the cache file.
        /// </summary>
        public string FileName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a brush that describes the background of a <see cref="ImageFlowItem"/> object.
        /// </summary>
        public System.Windows.Media.Brush Background
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFlowItem"/> class.
        /// </summary>
        public ImageFlowItem()
        {
            this.Background = new SolidColorBrush(System.Windows.Media.Colors.Black);
        }
        /// <summary>
        /// Creates the displayed <see cref="Image"/> from its source.
        /// </summary>
        /// <returns>The displayed <see cref="Image"/>.</returns>
        public virtual Image CreateImage()
        {
            return null;
        }
        /// <summary>
        /// Creates an identical copy of the <see cref="ImageFlowItem"/>.
        /// </summary>
        /// <returns>An object that represents an <see cref="ImageFlowItem"/> that has the same properties the cloned item.</returns>
        public virtual object Clone()
        {
            ImageFlowItem item = new ImageFlowItem();
            item.Source = this.Source;
            return item;
        }
        /// <summary>
        /// Determines whether the specified <see cref="IImageFlowItem"/> object is equal to the current <see cref="IImageFlowItem"/> object.
        /// </summary>
        /// <param name="imageFlowItem">The <see cref="IImageFlowItem"/> object to compare with the current <see cref="IImageFlowItem"/> object. </param>
        /// <returns>true if the specified <see cref="IImageFlowItem"/> object is equal to the current <see cref="IImageFlowItem"/> object; otherwise, false.</returns>
        public virtual bool Equals(IImageFlowItem imageFlowItem)
        {
            ImageFlowItem item = imageFlowItem as ImageFlowItem;
            if (item == null)
            {
                return false;
            }
            return this.Source == item.Source;
        }
        /// <summary>
        /// Returns a hash code for the current <see cref="IImageFlowItem"/>
        /// </summary>
        /// <returns>A hash code for the current <see cref="IImageFlowItem"/></returns>
        public virtual new int GetHashCode()
        {
            return this.Source == null ? 0 : this.Source.GetHashCode();
        }
        /// <summary>
        /// Matches the <see cref="ImageFlowItem"/> object at hittesting.
        /// </summary>
        /// <param name="modelVisual3D">The <see cref="Visual"/> that contains 3-D models.</param>
        /// <returns><b>True</b> when matches else <b>false</b>.</returns>
        public bool Matches(ModelVisual3D modelVisual3D)
        {
            if (this.ModelVisual3D.Equals(modelVisual3D) == true)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets the animation offsets for the <see cref="ImageFlowItem"/> object dependent to the position in its parent list
        /// </summary>
        /// <param name="position">The position of the <see cref="ImageFlowItem"/> object in the Visual3DCollection.</param>
        /// <param name="rotationY">The value for the rotation animation.</param>
        /// <param name="offsetX">The value for the x- axis animation.</param>
        /// <param name="offsetY">The value for the x- axis animation.</param>
        /// <param name="offsetZ">The value for the z- axis animation.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        public void GetOffsetsFromPosition(int position, out double rotationY, out double offsetX, out double offsetY, out double offsetZ)
        {
            rotationY = 0.0;
            offsetX = 0.0;
            offsetY = 0.0;
            //offsetZ = 0.8;
            //offsetZ = 0.4;
            offsetZ = 0.0;
            //offsetZ = 1.2;

            int num = Math.Abs(position) - 1;
            if (position > 0)
            {
                rotationY = -72.0;
                //offsetX = 1.8 + num;
                offsetX = 1.8 + num;
                //offsetZ = -0.0;
                offsetZ = -1.0;
                //offsetZ = -0.1;
            }
            if (position < 0)
            {
                rotationY = 72.0;
                offsetX = -1.8 - num;
                //offsetZ = -0.0;
                offsetZ = -1.0;
                //offsetZ = -0.1;
            }
        }
        /// <summary>
        /// Prepares the <see cref="ImageFlowItem"/> for using.
        /// </summary>
        public virtual void PrepareItem()
        {
            if (this.ModelVisual3D != null && this.Storyboard != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    XamlWriter.Save(ModelVisual3D, memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.ModelVisual3D = XamlReader.Load(memoryStream) as ModelVisual3D;
                }

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    XamlWriter.Save(Storyboard, memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.Storyboard = XamlReader.Load(memoryStream) as Storyboard;
                }

                double dYRotation = 0.0;
                double dOffsetX = 0.0;
                double dOffsetY = 0.0;
                double dOffsetZ = 0.0;

                GetOffsetsFromPosition(this.Position, out dYRotation, out dOffsetX, out dOffsetY, out dOffsetZ);

                Model3DGroup model3DGroup = this.ModelVisual3D.Content as Model3DGroup;
                if (model3DGroup != null)
                {
                    Transform3DGroup transform3DGroup = model3DGroup.Transform as Transform3DGroup;
                    RotateTransform3D rotateTransform3D = transform3DGroup.Children[0] as RotateTransform3D;
                    if (rotateTransform3D != null)
                    {
                        AxisAngleRotation3D axisAngleRotation3D = rotateTransform3D.Rotation as AxisAngleRotation3D;
                        axisAngleRotation3D.Angle = dYRotation;
                    }
                    TranslateTransform3D translateTransform3D = transform3DGroup.Children[1] as TranslateTransform3D;
                    if (translateTransform3D != null)
                    {
                        translateTransform3D.OffsetX = dOffsetX;
                        translateTransform3D.OffsetZ = dOffsetZ;
                    }
                    LoadImageIntoModel3DGroup(this.DefaultImageSource);
                }
                this.CreateImageSource = new CreateImageSource(this);
            }
        }
        /// <summary>
        /// Releases all resources used by the <see cref="Component"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Destructor for the <see cref="ImageFlowItem"/> object.
        /// Use C# destructor syntax for finalization code.
        /// </summary>
        ~ImageFlowItem()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Releases the unmanaged resources used by <see cref="ImageFlowItem"/> and optionally
        /// releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (disposing == true)
            {
                if (this.ModelVisual3D != null)
                {
                    Model3DGroup model3DGroup = this.ModelVisual3D.Content as Model3DGroup;
                    if (model3DGroup != null)
                    {
                        GeometryModel3D geometryModel3D = model3DGroup.Children[0] as GeometryModel3D;
                        if (geometryModel3D != null)
                        {
                            if (geometryModel3D.Material != null)
                            {
                                geometryModel3D = null;
                            }
                            geometryModel3D = null;
                        }
                        GeometryModel3D geometryModel3DMirror = model3DGroup.Children[1] as GeometryModel3D;
                        if (geometryModel3DMirror != null)
                        {
                            if (geometryModel3DMirror.Material != null)
                            {
                                geometryModel3DMirror = null;
                            }
                            geometryModel3DMirror = null;
                        }
                        Transform3DGroup transform3DGroup = model3DGroup.Transform as Transform3DGroup;
                        if (transform3DGroup != null)
                        {
                            RotateTransform3D rotateTransform3D = transform3DGroup.Children[0] as RotateTransform3D;
                            if (rotateTransform3D != null)
                            {
                                rotateTransform3D = null;
                            }
                            TranslateTransform3D translateTransform3D = transform3DGroup.Children[1] as TranslateTransform3D;
                            if (translateTransform3D != null)
                            {
                                translateTransform3D = null;
                            }
                            transform3DGroup = null;
                        }
                        model3DGroup = null;
                    }
                    this.ModelVisual3D = null;
                }
                if (this.Storyboard != null)
                {
                    this.Storyboard = null;
                }
                if (this.Background != null)
                {
                    this.Background = null;
                }
            }
        }
        /// <summary>
        /// Raises the <see cref="ImageFlowItem.CreateImageSourceChangedEvent"/> event.
        /// </summary>
        /// <param name="e">Arguments associated with the <see cref="ImageFlowItem.CreateImageSourceChangedEvent"/> event.</param>
        protected virtual void OnCreateImageSourceChanged(RoutedPropertyChangedEventArgs<CreateImageSource> e)
        {
            if (this.CreateImageSource != null)
            {
                this.CreateImageSource.ImageSourceCreated += new EventHandler<EventArgs>(ImageSourceCreated);
                this.CreateImageSource.Run();
            }
            base.RaiseEvent(e);
        }
        /// <summary>
        /// Raises the <see cref="ImageFlowItem.SourceChangedEvent"/> event.
        /// </summary>
        /// <param name="args">Arguments associated with the <see cref="ImageFlowItem.SourceChangedEvent"/> event.</param>
        protected virtual void OnSourceChanged(RoutedPropertyChangedEventArgs<ImageSource> args)
        {
            RaiseEvent(args);
        }
        /// <summary>
        /// Loads a <see cref="ImageSource"/> into the <see cref="Model3DGroup"/> content.
        /// </summary>
        /// <param name="imageSource"></param>
        protected void LoadImageIntoModel3DGroup(ImageSource imageSource)
        {
            if (imageSource != null)
            {
                BitmapImage bitmapImage = imageSource as BitmapImage;
                Model3DGroup content = this.ModelVisual3D.Content as Model3DGroup;
                if (content != null)
                {
                    GeometryModel3D geometryModel3D = content.Children[0] as GeometryModel3D;
                    if (geometryModel3D != null)
                    {
                        if (geometryModel3D.Material != null)
                        {
                            geometryModel3D.Material = LoadImage(imageSource);
                            ConstructMesh(geometryModel3D, bitmapImage, ReflectionMode.None);
                        }
                    }
                    GeometryModel3D geometryModel3DReflection = content.Children[1] as GeometryModel3D;
                    if (geometryModel3DReflection != null)
                    {
                        if (geometryModel3DReflection.Material != null)
                        {
                            geometryModel3DReflection.Material = LoadReflectedImage(imageSource, this.Background);
                            ConstructMesh(geometryModel3DReflection, bitmapImage, ReflectionMode.Reflection);
                        }
                    }
                }
                bitmapImage = null;
                imageSource = null;
            }
        }
        #endregion

        #region MethodsPrivate

        private static void ConstructMesh(GeometryModel3D geometryModel3D, BitmapImage bitmapImage, ReflectionMode reflectionMode)
        {
            if (geometryModel3D != null && bitmapImage != null)
            {
                double iPixelWidth = bitmapImage.PixelWidth;
                double iPixelHeight = bitmapImage.PixelHeight;

                if (iPixelHeight.Equals(iPixelWidth) == false)
                {
                    MeshGeometry3D meshGeometry3D = geometryModel3D.Geometry as MeshGeometry3D;
                    Point3DCollection point3DCollection = new Point3DCollection();
                    double dAspectRation = 1;
                    if (iPixelHeight > iPixelWidth)
                    {
                        dAspectRation = iPixelWidth / iPixelHeight;
                        if (reflectionMode == ReflectionMode.None)
                        {
                            point3DCollection.Add(new Point3D(0d - dAspectRation, -1, 0));
                            point3DCollection.Add(new Point3D(dAspectRation, -1, 0));
                            point3DCollection.Add(new Point3D(dAspectRation, 1, 0));
                            point3DCollection.Add(new Point3D(0d - dAspectRation, 1, 0));
                        }
                        else
                        {
                            point3DCollection.Add(new Point3D(0d - dAspectRation, -3, 0));
                            point3DCollection.Add(new Point3D(dAspectRation, -3, 0));
                            point3DCollection.Add(new Point3D(dAspectRation, -1, 0));
                            point3DCollection.Add(new Point3D(0d - dAspectRation, -1, 0));
                        }
                    }
                    else
                    {
                        dAspectRation = iPixelHeight / iPixelWidth;
                        if (reflectionMode == ReflectionMode.None)
                        {
                            point3DCollection.Add(new Point3D(-1, 0d - dAspectRation, 0));
                            point3DCollection.Add(new Point3D(1, 0d - dAspectRation, 0));
                            point3DCollection.Add(new Point3D(1, dAspectRation, 0));
                            point3DCollection.Add(new Point3D(-1, dAspectRation, 0));
                        }
                        else
                        {
                            point3DCollection.Add(new Point3D(-1, -2 - dAspectRation, 0));
                            point3DCollection.Add(new Point3D(1, -2 - dAspectRation, 0));
                            point3DCollection.Add(new Point3D(1, 0d - dAspectRation, 0));
                            point3DCollection.Add(new Point3D(-1, 0d - dAspectRation, 0));
                        }
                    }

                    meshGeometry3D.Positions = point3DCollection;
                }
            }
        }

        private static Material LoadImage(ImageSource imageSource)
        {
            return new DiffuseMaterial(new ImageBrush(imageSource));
        }

        private static Material LoadReflectedImage(ImageSource imageSource, System.Windows.Media.Brush background)
        {
            ImageBrush imageBrush = new ImageBrush(imageSource);
            imageBrush.Opacity = 0.75;

            System.Windows.Shapes.Rectangle imageRectangle = new System.Windows.Shapes.Rectangle();
            imageRectangle.Width = imageSource.Width;
            imageRectangle.Height = imageSource.Height;

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new System.Windows.Point(0, 1);
            linearGradientBrush.EndPoint = new System.Windows.Point(0, 0);
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 0.4));

            imageRectangle.Fill = background;
            imageRectangle.Arrange(
                new System.Windows.Rect(
                    new System.Windows.Point(0, 0),
                    new System.Windows.Size(imageSource.Width, imageSource.Height))
                    );

            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)imageSource.Width, (int)imageSource.Height, 96, 96, PixelFormats.Pbgra32);
            renderBitmap.Render(imageRectangle);

            imageRectangle.OpacityMask = linearGradientBrush;
            imageRectangle.Fill = imageBrush;
            imageRectangle.UpdateLayout();

            linearGradientBrush = null;

            renderBitmap.Render(imageRectangle);

            imageRectangle = null;
            imageBrush = null;
            imageBrush = new ImageBrush(renderBitmap);
            renderBitmap = null;

            return new DiffuseMaterial(imageBrush);
        }

        private void ImageSourceCreated(object sender, EventArgs e)
        {
            using (CreateImageSource createImageSource = sender as CreateImageSource)
            {
                if (createImageSource != null)
                {
                    createImageSource.ImageSourceCreated -= new EventHandler<EventArgs>(ImageSourceCreated);
                    System.Threading.ThreadStart threadStart = delegate()
                    {
                        ImageSource imageSource = createImageSource.PictureImageSource;
                        if (imageSource != null)
                        {
                            if (this.ModelVisual3D != null)
                            {
                                this.ModelVisual3D.Dispatcher.BeginInvoke(
                                    System.Windows.Threading.DispatcherPriority.Normal,
                                    (System.Threading.ThreadStart)delegate()
                                    {
                                        this.LoadImageIntoModel3DGroup(imageSource);
                                    });
                            }
                        }
                    };
                    new System.Threading.Thread(threadStart).Start();
                }
            }
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ImageFlowItem imageFlowItem = d as ImageFlowItem;
            if (imageFlowItem != null)
            {
                RoutedPropertyChangedEventArgs<ImageSource> e = new RoutedPropertyChangedEventArgs<ImageSource>(
                    (ImageSource)args.OldValue,
                    (ImageSource)args.NewValue,
                    SourceChangedEvent);
                imageFlowItem.OnSourceChanged(e);
            }
        }

        private static void OnCreateImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageFlowItem imageFlowItem = (ImageFlowItem)d;

            RoutedPropertyChangedEventArgs<CreateImageSource> createImageSourceChangedEvent = new RoutedPropertyChangedEventArgs<CreateImageSource>(
                (CreateImageSource)e.OldValue, (CreateImageSource)e.NewValue, CreateImageSourceChangedEvent);
            imageFlowItem.OnCreateImageSourceChanged(createImageSourceChangedEvent);
        }
        
        #endregion
    }
}
