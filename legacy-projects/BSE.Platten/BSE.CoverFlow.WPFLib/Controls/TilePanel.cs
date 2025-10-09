using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Represents the control that displays a main element as the upper content and a collapsible window that displays other content.
    /// </summary>
    public class TilePanel : System.Windows.Controls.ContentControl
    {
        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="ExpandableContent"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExpandableContentProperty = DependencyProperty.Register("ExpandableContent", typeof(object), typeof(TilePanel), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(TilePanel.OnExpandableContentChanged)));
        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(TilePanel), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(TilePanel.OnIsExpandedChanged)));
        /// <summary>
        /// Identifies the <see cref="Collapsed"/> routed event.
        /// </summary>
        public static readonly RoutedEvent CollapsedEvent = EventManager.RegisterRoutedEvent("Collapsed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TilePanel));
        /// <summary>
        /// Identifies the <see cref="Expanded"/> routed event.
        /// </summary>
        public static readonly RoutedEvent ExpandedEvent = EventManager.RegisterRoutedEvent("Expanded", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TilePanel));
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the <see cref="ExpandableContent"/> of an <see cref="TilePanel"/> control closes and only the Header is visible.
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
        /// Occurs when the <see cref="ExpandableContent"/> of an <see cref="TilePanel"/> control opens to display both its header and content.
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
        /// Gets or sets whether the Expander content of the <see cref="TilePanel"/> is visible. 
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
        /// <summary>
        /// Gets or sets the <see cref="ExpandableContent"/> of a <see cref="TilePanel"/>.
        /// </summary>
        [Category("Content"), Bindable(true)]
        public object ExpandableContent
        {
            get
            {
                return base.GetValue(ExpandableContentProperty);
            }
            set
            {
                base.SetValue(ExpandableContentProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ContentControl expandableContent = this.GetTemplateChild("PART_ExpandableContent") as ContentControl;
            if (expandableContent != null)
            {
                expandableContent.Content = this.ExpandableContent;
            }
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Called when the <see cref="ExpandableContent"/> property changes. 
        /// </summary>
        /// <param name="oldExpandableContent"></param>
        /// <param name="newExpandableContent"></param>
        protected virtual void OnExpandableContentChanged(object oldExpandableContent, object newExpandableContent)
        {
            base.RemoveLogicalChild(oldExpandableContent);
            base.AddLogicalChild(newExpandableContent);
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

        static TilePanel()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TilePanel), new FrameworkPropertyMetadata(typeof(TilePanel)));
        }
        private static void OnExpandableContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TilePanel control = (TilePanel)d;
            control.OnExpandableContentChanged(e.OldValue, e.NewValue);
        }
        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TilePanel control = (TilePanel)d;
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
    }
}
