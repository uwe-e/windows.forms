using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Represents a selectable and expandable item inside a <see cref="ExpanderTabControl"/>. 
    /// </summary>
    public class ExpandableTabItem : TabItem
    {
        #region Events
        /// <summary>
        /// Occurs when a <see cref="ExpandableTabItem"/> header is checked.
        /// </summary>
        [Category("Behavior")]
        public event RoutedEventHandler Checked
        {
            add
            {
                base.AddHandler(CheckedEvent, value);
            }
            remove
            {
                base.RemoveHandler(CheckedEvent, value);
            }
        }
        /// <summary>
        /// Occurs when a <see cref="ExpandableTabItem"/> header is unchecked.
        /// </summary>
        [Category("Behavior")]
        public event RoutedEventHandler Unchecked
        {
            add
            {
                base.AddHandler(UncheckedEvent, value);
            }
            remove
            {
                base.RemoveHandler(UncheckedEvent, value);
            }
        }

        #endregion

        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="Checked"/>  routed event. 
        /// </summary>
        public static readonly RoutedEvent CheckedEvent = EventManager.RegisterRoutedEvent("Checked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ExpandableTabItem));
        /// <summary>
        /// Identifies the <see cref="Unchecked"/> routed event. 
        /// </summary>
        public static readonly RoutedEvent UncheckedEvent = EventManager.RegisterRoutedEvent("Unchecked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ExpandableTabItem));
        /// <summary>
        /// Identifies the <see cref="IsChecked"/> dependency property. 
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked",
                    typeof(bool?),
                    typeof(ExpandableTabItem),
                    new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Journal | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ExpandableTabItem.OnIsCheckedChanged)));
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets whether the <see cref="ExpandableTabItem"/> header is checked. 
        /// </summary>
        [TypeConverter(typeof(NullableBoolConverter)), Category("Appearance"), Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public bool? IsChecked
        {
            get
            {
                object objIsChecked = base.GetValue(IsCheckedProperty);
                if (objIsChecked == null)
                {
                    return null;
                }
                return new bool?((bool)objIsChecked);
            }
            set
            {
                base.SetValue(IsCheckedProperty, value.HasValue ? value : null);
            }
        }
        #endregion

        #region MethodsPublic
        static ExpandableTabItem()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpandableTabItem), new FrameworkPropertyMetadata(typeof(ExpandableTabItem)));
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Called when a <see cref="ExpandableTabItem"/> raises a <see cref="Checked"/> event.
        /// </summary>
        /// <param name="e">The event data for the <see cref="Checked"/> event.</param>
        protected virtual void OnChecked(RoutedEventArgs e)
        {
            base.RaiseEvent(e);
        }
        /// <summary>
        /// Called when a <see cref="ExpandableTabItem"/> raises a <see cref="UnChecked"/> event.
        /// </summary>
        /// <param name="e">The event data for the <see cref="UnChecked"/> event.</param>
        protected virtual void OnUnchecked(RoutedEventArgs e)
        {
            base.RaiseEvent(e);
        }
        /// <summary>
        /// Responds to the <see cref="TabItem.OnMouseLeftButtonDown"/> event.
        /// </summary>
        /// <param name="e">Provides data for MouseButtonEventArgs.</param>
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            ExpandableTabItem tabItemHeader = e.Source as ExpandableTabItem;
            if (tabItemHeader != null)
            {
                object objIsChecked = this.IsChecked;
                if (objIsChecked != null)
                {
                    this.IsChecked = !this.IsChecked;
                    //Trace.WriteLine(this.ToString() + " OnMouseLeftButtonDown " + this.IsChecked);
                }
            }
            base.OnMouseLeftButtonDown(e);
        }
        /// <summary>
        /// Called to indicate that the <b>IsSelected</b> property has changed to <b>true</b>. 
        /// </summary>
        /// <param name="e">The event data for the <see cref="Selected"/> event.</param>
        protected override void OnSelected(System.Windows.RoutedEventArgs e)
        {
            this.IsChecked = true;
            //Trace.WriteLine(this.ToString() + " checked");
            base.OnSelected(e);
        }
        /// <summary>
        /// Called to indicate that the <see cref="IsSelected"/> property has changed to <b>false</b>. 
        /// </summary>
        /// <param name="e">The event data for the <see cref="Unselected"/> event.</param>
        protected override void OnUnselected(RoutedEventArgs e)
        {
            this.IsChecked = false;
            //Trace.WriteLine(this.ToString() + " unchecked");
            base.OnUnselected(e);
        }
        #endregion

        #region MethodsPrivate
        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExpandableTabItem control = (ExpandableTabItem)d;
            bool? oldValue = (bool?)e.OldValue;
            bool? newValue = (bool?)e.NewValue;

            if (newValue == true)
            {
                control.OnChecked(new RoutedEventArgs(CheckedEvent));
            }
            else if (newValue == false)
            {
                control.OnUnchecked(new RoutedEventArgs(UncheckedEvent));
            }

        }
        #endregion
    }
}
