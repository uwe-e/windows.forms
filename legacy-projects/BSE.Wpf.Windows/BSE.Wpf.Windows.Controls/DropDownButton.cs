using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace BSE.Wpf.Windows.Controls
{
    public class DropDownButton : ToggleButton
    {
        #region FieldsPublic
        public static readonly DependencyProperty DropDownContextMenuProperty = DependencyProperty.Register(
            "DropDownContextMenu", typeof(ContextMenu), typeof(DropDownButton));
        public static readonly DependencyProperty DropDownPlacementModeProperty = DependencyProperty.Register(
            "DropDownPlacementMode", typeof(PlacementMode), typeof(DropDownButton));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(DropDownButton));
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(DropDownButton), new FrameworkPropertyMetadata(null));

        #endregion

        #region Properties
        public ContextMenu DropDownContextMenu
        {
            get
            {
                return this.GetValue(DropDownContextMenuProperty) as ContextMenu;
            }
            set
            {
                this.SetValue(DropDownContextMenuProperty, value);
            }
        }
        [Bindable(true), Category("Content")]
        public object Icon
        {
            get
            {
                return base.GetValue(IconProperty);
            }
            set
            {
                base.SetValue(IconProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return this.GetValue(TextProperty) as string;
            }
            set
            {
                this.SetValue(TextProperty, value);
            }
        }
        [Bindable(true), Category("Layout")]
        public PlacementMode DropDownPlacementMode
        {
            get
            {
                return (PlacementMode)this.GetValue(DropDownPlacementModeProperty);
            }
            set
            {
                this.SetValue(DropDownPlacementModeProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        public DropDownButton()
        {
            this.DropDownPlacementMode = PlacementMode.Bottom;
            var binding = new Binding("DropDownContextMenu.IsOpen") { Source = this };
            this.SetBinding(IsCheckedProperty, binding);
        }
        #endregion

        #region MethodsProtected
        protected override void OnClick()
        {
            RoutedEventArgs e = new RoutedEventArgs(ClickEvent, this);
            base.RaiseEvent(e);
            //CommandHelpers.ExecuteCommandSource(this);

            if (this.DropDownContextMenu != null)
            {
                DropDownContextMenu.PlacementTarget = this;
                DropDownContextMenu.Placement = this.DropDownPlacementMode;
                DropDownContextMenu.IsOpen = !DropDownContextMenu.IsOpen;
            }
        }
        #endregion

        #region MethodsPrivate
        static DropDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
               typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
        }
        #endregion

    }
}
