using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace BSE.CoverFlow.WPFLib.Controls
{
     public class PlayerButton : Button
    {
        #region FieldsPublic
        public static readonly DependencyProperty HorizontalOrientationProperty;
        #endregion

        #region Properties
        public HorizontalOrientation HorizontalOrientation
        {
            get
            {
                return (HorizontalOrientation)this.GetValue(HorizontalOrientationProperty);
            }
            set
            {
                this.SetValue(HorizontalOrientationProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsPrivate
        static PlayerButton()
        {
            HorizontalOrientationProperty = DependencyProperty.Register(
                "HorizontalOrientation",
                typeof(HorizontalOrientation),
                typeof(PlayerButton));
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(PlayerButton), new FrameworkPropertyMetadata(typeof(PlayerButton)));
        }

        #endregion

    }
}
