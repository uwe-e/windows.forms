using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;
using System.ComponentModel;
using System.Globalization;

namespace BSE.CoverFlow.WPFLib.Data
{
    /// <summary>
    /// http://meleak.wordpress.com/2012/05/02/delaybinding-and-delaymultibinding-with-source-and-target-delay/
    /// </summary>
    public class DelayBindingExtension : BindingExtensionBase
    {
        #region Constructor

        public DelayBindingExtension() { }

        public DelayBindingExtension(string path)
        {
            Path = new PropertyPath(path);
        }

        #endregion

        #region Properties

        public TimeSpan UpdateTargetDelay
        {
            get;
            set;
        }

        public TimeSpan UpdateSourceDelay
        {
            get;
            set;
        }

        #endregion // Properties

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget service = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            DependencyObject targetObject = service.TargetObject as DependencyObject;
            DependencyProperty targetProperty = service.TargetProperty as DependencyProperty;

            // Prevent the designer from reporting exceptions because
            // GetMetadata returns null in design mode
            if (DesignerProperties.GetIsInDesignMode(targetObject) == true)
                return null;

            if (targetObject == null || targetProperty == null)
            {
                return base.ProvideValue(serviceProvider);
            }

            SetBinding(targetObject, targetProperty);

            // Return the current value
            return targetObject.GetValue(targetProperty);
        }

        public override void SetBinding(DependencyObject targetObject, DependencyProperty targetProperty)
        {
            Binding.Mode = GetBindingMode(targetObject, targetProperty);
            // Used as a workaround to bug that happends when the setter rejects the new value.
            // The GUI control doesn't stay in sync. E.g SelectedItem for a ComboBox
            Binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;

            DelayBindingController delayBindingController =
                new DelayBindingController(targetObject, targetProperty,
                                           UpdateSourceDelay, UpdateTargetDelay, Binding, Binding.Mode);
            DelayBindingManager.GetDelayBindingControllers(targetObject).Add(delayBindingController);
            delayBindingController.SetupBindingListeners();
        }

        private BindingMode GetBindingMode(DependencyObject targetObject,
                                           DependencyProperty targetProperty)
        {
            if (Binding.Mode == BindingMode.Default)
            {
                FrameworkPropertyMetadata metadata =
                    targetProperty.GetMetadata(targetObject.GetType()) as FrameworkPropertyMetadata;
                if (metadata != null && metadata.BindsTwoWayByDefault == true)
                {
                    return BindingMode.TwoWay;
                }
                else
                {
                    return BindingMode.OneWay;
                }
            }
            return Binding.Mode;
        }
    }

}
