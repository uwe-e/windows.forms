using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using BSE.CoverFlow.WPFLib.Extension;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Represents a control that contains multiple collapsible items that share the same space on the screen. 
    /// </summary>
    public class ExpanderTabControl : TabControl
    {
        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded",
            typeof(bool),
            typeof(ExpanderTabControl),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ExpanderTabControl.OnIsExpandedChanged)));
        /// <summary>
        /// Identifies the <see cref="Collapsed"/> routed event.
        /// </summary>
        public static readonly RoutedEvent CollapsedEvent = EventManager.RegisterRoutedEvent("Collapsed",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ExpanderTabControl));
        /// <summary>
        /// Identifies the <see cref="Expanded"/> routed event.
        /// </summary>
        public static readonly RoutedEvent ExpandedEvent = EventManager.RegisterRoutedEvent("Expanded",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ExpanderTabControl));
        #endregion

        #region FieldsPrivate
        private ExpandableTabItem m_checkedTabItem;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the content window of an <see cref="ExpanderTabControl"/> control closes and only the Header is visible.
        /// </summary>
        public event RoutedEventHandler Collapsed
        {
            add
            {
                base.AddHandler(CollapsedEvent, value);
            }
            remove
            {
                base.RemoveHandler(CollapsedEvent, value);
            }
        }
        /// <summary>
        /// Occurs when the content window of an <see cref="ExpanderTabControl"/> control opens to display both its header and content. 
        /// </summary>
        public event RoutedEventHandler Expanded
        {
            add
            {
                base.AddHandler(ExpandedEvent, value);
            }
            remove
            {
                base.RemoveHandler(ExpandedEvent, value);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets whether the Expander content of the <see cref="ExpanderTabControl"/> is visible. 
        /// </summary>
        [Bindable(true), Category("Appearance")]
        public bool IsExpanded
        {
            get
            {
                return (bool)base.GetValue(IsExpandedProperty);
            }
            set
            {
                base.SetValue(IsExpandedProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        static ExpanderTabControl()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpanderTabControl), new FrameworkPropertyMetadata(typeof(ExpanderTabControl)));
        }
        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExpanderTabControl control = (ExpanderTabControl)d;
            bool newValue = (bool)e.NewValue;

            if (newValue)
            {
                control.OnExpanded();
            }
            else
            {
                control.OnCollapsed();
            }
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the <see cref="FrameworkElement.Initialized"/> event. This method is invoked whenever IsInitialized is set to <b>true</b> internally. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            base.ItemContainerGenerator.StatusChanged += new EventHandler(this.OnGeneratorStatusChanged);
        }
        /// <summary>
        /// Raises the <see cref="Collapsed"/> event when the <see cref="IsExpanded"/> property changes from <b>true</b> to <b>false</b>.
        /// </summary>
        protected virtual void OnCollapsed()
        {
            base.RaiseEvent(new RoutedEventArgs(CollapsedEvent, this));
        }
        /// <summary>
        /// Raises the <see cref="Expanded"/> event when the <see cref="IsExpanded"/> property changes from <b>false</b> to <b>true</b>.
        /// </summary>
        protected virtual void OnExpanded()
        {
            RoutedEventArgs e = new RoutedEventArgs
            {
                RoutedEvent = ExpandedEvent,
                Source = this
            };
            base.RaiseEvent(e);
        }
        #endregion

        #region MethodsPrivate
        private void OnGeneratorStatusChanged(object sender, EventArgs e)
        {
            if (base.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                if (base.HasItems)
                {
                    IList<ExpandableTabItem> expanderTabItems = base.Items.GetItems<ExpandableTabItem>();
                    if (expanderTabItems != null)
                    {
                        foreach (ExpandableTabItem tabItem in expanderTabItems)
                        {
                            if (tabItem != null)
                            {
                                tabItem.IsSelected = false;
                                tabItem.IsChecked = false;
                                tabItem.Checked += new RoutedEventHandler(OnTabItemChecked);
                                tabItem.Unchecked += new RoutedEventHandler(OnTabItemUnchecked);
                            }
                        }
                    }
                }
            }
        }
        private void OnTabItemUnchecked(object sender, RoutedEventArgs e)
        {
            ExpandableTabItem tabItem = sender as ExpandableTabItem;
            if (tabItem == m_checkedTabItem)
            {
                this.IsExpanded = false;
            }
        }

        private void OnTabItemChecked(object sender, RoutedEventArgs e)
        {
            this.m_checkedTabItem = sender as ExpandableTabItem;
            this.IsExpanded = true;
        }
        #endregion
    }
}
