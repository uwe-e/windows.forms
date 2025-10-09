using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace BSE.CoverFlow.WPFLib.Controls
{
    public class NavigateableControl : UserControl
    {
        #region MethodsPublic
        public NavigateableControl()
        {
        }
        #endregion
        #region MethodsPrivate
        static NavigateableControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigateableControl), new FrameworkPropertyMetadata(typeof(NavigateableControl)));
        }
         #endregion
    }
}
