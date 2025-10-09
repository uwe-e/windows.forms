using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;

namespace BSE.CoverFlow.WPFLib.Controls
{
    public class PlayerInfoPanel : ContentControl
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPublic
        public static readonly DependencyProperty InfoPanelViewModeProperty;
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        [Category("Appearance"), Bindable(true)]
        public InfoPanelViewMode InfoPanelViewMode
        {
            get
            {
                return (InfoPanelViewMode)this.GetValue(InfoPanelViewModeProperty);
            }
            set
            {
                this.SetValue(InfoPanelViewModeProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        static PlayerInfoPanel()
        {
            InfoPanelViewModeProperty = DependencyProperty.Register(
                "InfoPanelViewMode",
                typeof(InfoPanelViewMode),
                typeof(PlayerInfoPanel));

            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(PlayerInfoPanel), new FrameworkPropertyMetadata(typeof(PlayerInfoPanel)));
        }
        #endregion

    }
}
