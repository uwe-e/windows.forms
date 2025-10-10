using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;

namespace BSE.Wpf.Windows.Controls
{
    public class SplitButton : DropDownButton
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsProtected
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ToggleButton toggleButton = this.GetTemplateChild("PART_ToggleButton") as ToggleButton;
            if (toggleButton != null)
            {
                toggleButton.Click += new RoutedEventHandler(toggleButton_Click);
            }
            Button actionButton = this.GetTemplateChild("PART_ActionButton") as Button;
            if (actionButton != null)
            {
                actionButton.Command = this.Command;
            }
        }
        #endregion

        #region MethodsPrivate
        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            this.OnClick();
        }
        static SplitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
               typeof(SplitButton), new FrameworkPropertyMetadata(typeof(SplitButton)));
        }
        #endregion

    }
}
