using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BSE.Wpf.Windows.Controls
{
    public class ToolBar : System.Windows.Controls.ToolBar
    {
        #region FieldsPublic
        public static readonly DependencyProperty IsOverflowPanelVisibleProperty = DependencyProperty.Register(
            "IsOverflowPanelVisible", typeof(bool), typeof(ToolBar));
        #endregion

        #region FieldsPrivate
        private static ResourceKey m_cacheSplitButtonStyle;
        private static ResourceKey m_cacheDropDownButtonStyle;
 

        #endregion

        #region Properties
        public static ResourceKey SplitButtonStyleKey
        {
            get
            {
                if (m_cacheSplitButtonStyle == null)
                {
                    m_cacheSplitButtonStyle = new SystemThemeKey(SystemResourceKeyID.ToolBarSplitButtonStyle);
                }
                return m_cacheSplitButtonStyle;
            }
        }
        public static ResourceKey DropDownButtonStyleKey
        {
            get
            {
                if (m_cacheDropDownButtonStyle == null)
                {
                    m_cacheDropDownButtonStyle = new SystemThemeKey(SystemResourceKeyID.ToolBarDropDownButtonStyle);
                }
                return m_cacheDropDownButtonStyle;
            }
        }

        public bool IsOverflowPanelVisible
        {
            get
            {
                return (bool)this.GetValue(IsOverflowPanelVisibleProperty);
            }
            set
            {
                this.SetValue(IsOverflowPanelVisibleProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        #endregion

        #region MethodsProtected
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Grid overflowGrid = base.GetTemplateChild("OverflowGrid") as Grid;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            FrameworkElement frameworkElement = element as FrameworkElement;
            if (frameworkElement != null)
            {
                ResourceKey name = null;
                Type type = frameworkElement.GetType();
                if (type == typeof(DropDownButton))
                {
                    name = DropDownButtonStyleKey;
                }
                else if (type == typeof(SplitButton))
                {
                    name = SplitButtonStyleKey;
                }
                if (name != null)
                {
                    frameworkElement.SetResourceReference(FrameworkElement.StyleProperty, name);
                    //System.Reflection.PropertyInfo numberPropertyInfo = frameworkElement.GetType().GetProperty("DefaultStyleKey", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    //numberPropertyInfo.SetValue(frameworkElement, name, null);
                }
            }
        }
        #endregion

        #region MethodsPrivate
        static ToolBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
               typeof(ToolBar), new FrameworkPropertyMetadata(typeof(ToolBar)));
        }
        #endregion

    }
}
