using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace BSE.CoverFlow.WPFLib.Controls
{
    public class TwoStateButton : Button
    {
        #region Events
        #endregion

        #region FieldsPublic
        public static readonly DependencyProperty IsPlayingProperty = DependencyProperty.Register(
            "IsPlaying",
            typeof(bool),
            typeof(TwoStateButton));
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        public bool IsPlaying
        {
            get
            {
                return (bool)this.GetValue(IsPlayingProperty);
            }
            set
            {
                this.SetValue(IsPlayingProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate

        static TwoStateButton()
		{
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(TwoStateButton), new FrameworkPropertyMetadata(typeof(TwoStateButton)));
		}

        #endregion
    }
}
