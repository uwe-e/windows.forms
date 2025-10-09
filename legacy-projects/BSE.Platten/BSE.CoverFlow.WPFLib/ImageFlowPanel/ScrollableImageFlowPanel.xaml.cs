using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using BSE.Wpf.Windows.Controls.ImageFlow;

namespace BSE.CoverFlow.WPFLib.ImageFlowPanel
{
    /// <summary>
    /// Interaction logic for ScrollableImageFlowPanel.xaml
    /// </summary>
    public partial class ScrollableImageFlowPanel : UserControl
    {
        #region FieldsPublic
        public static readonly DependencyProperty PanelSizeStateProperty
            = DependencyProperty.Register(
                "PanelSizeState", typeof(PanelSizeState), typeof(ScrollableImageFlowPanel),
                new PropertyMetadata(new PropertyChangedCallback(OnPanelSizeStateChanged)));

        #endregion

        #region Events

        public static readonly RoutedEvent PanelSizeStateChangedEvent = EventManager.RegisterRoutedEvent(
            "PanelSizeStateChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<PanelSizeState>), typeof(ScrollableImageFlowPanel));
        
        public static readonly RoutedEvent ChangePanelSizeEvent = EventManager.RegisterRoutedEvent(
            "ChangePanelSize", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ScrollableImageFlowPanel));
        
        public event RoutedEventHandler ChangePanelSize
        {
            add { AddHandler(ChangePanelSizeEvent, value); }
            remove { RemoveHandler(ChangePanelSizeEvent, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SelectedItemMouseDoubleClick"/> routed event.
        /// </summary>
        public static readonly RoutedEvent SelectedItemMouseDoubleClickEvent = EventManager.RegisterRoutedEvent(
                    "SelectedItemMouseDoubleClick", RoutingStrategy.Bubble,
                    typeof(ImageFlowItemMouseEventHandler), typeof(ScrollableImageFlowPanel));
        /// <summary>
        /// Occurs when any mouse button on the selected <see cref="IImageFlowItem"/> is clicked two or more times.
        /// </summary>
        public event ImageFlowItemMouseEventHandler SelectedItemMouseDoubleClick
        {
            add { this.AddHandler(SelectedItemMouseDoubleClickEvent, value); }
            remove { this.RemoveHandler(SelectedItemMouseDoubleClickEvent, value); }
        }

        #endregion

        #region Properties

        public PanelSizeState PanelSizeState
        {
            get
            {
                return (PanelSizeState)this.GetValue(PanelSizeStateProperty);
            }
            set
            {
                this.SetValue(PanelSizeStateProperty, value);
            }
        }
        public DirectoryInfo CacheDirectory
        {
            get
            {
                return this.ImageFlowPanel.CacheDirectoryInfo;
            }
            set
            {
                this.ImageFlowPanel.CacheDirectoryInfo = value;
            }
        }
        public new Brush Background
        {
            get
            {
                return this.ImageFlowPanel.Background;
            }
            set
            {
                this.ImageFlowPanel.Background = value;
            }
        }

        public ItemCollection Items
        {
            get { return this.ImageFlowPanel.Items; }
        }
        public System.Collections.IEnumerable ItemsSource
        {
            get
            {
                return this.ImageFlowPanel.ItemsSource;
            }
            set
            {
                this.ImageFlowPanel.ItemsSource = value;
            }
        }
        #endregion

        #region MethodsPublic
        public ScrollableImageFlowPanel()
        {
            InitializeComponent();
        }
        public void SetSelectedItem(BSE.Wpf.Windows.Controls.ImageFlow.IImageFlowItem imageFlowItem)
        {
            this.ImageFlowPanel.SetSelectedItem(imageFlowItem);
        }
        #endregion

        #region MethodsProtected
        protected virtual void OnPanelSizeStateChanged(RoutedPropertyChangedEventArgs<PanelSizeState> args)
        {
            RaiseEvent(args);
        }
        #endregion

        #region MethodsPrivate
        
        private void ButtonSizeToggleClick(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ScrollableImageFlowPanel.ChangePanelSizeEvent);
            RaiseEvent(newEventArgs);
        }

        private void ImageFlowPanel_SelectedItemMouseDoubleClick(object sender, BSE.Wpf.Windows.Controls.ImageFlow.ImageFlowItemMouseEventArgs e)
        {
            e.RoutedEvent =  SelectedItemMouseDoubleClickEvent;
            this.RaiseEvent(e);
        }

        private static void OnPanelSizeStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ScrollableImageFlowPanel imageFlowPanel = d as ScrollableImageFlowPanel;
            if (imageFlowPanel != null)
            {
                RoutedPropertyChangedEventArgs<PanelSizeState> e = new RoutedPropertyChangedEventArgs<PanelSizeState>(
                    (PanelSizeState)args.OldValue,
                    (PanelSizeState)args.NewValue,
                    PanelSizeStateChangedEvent);
                imageFlowPanel.OnPanelSizeStateChanged(e);
            }
        }
        #endregion

        
    }
}
