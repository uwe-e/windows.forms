using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Interop;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Creates the container window for a dialog.
    /// </summary>
    public class DialogManager : Control
    {
        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="DialogResizeMode"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogResizeModeProperty =
                    DependencyProperty.Register("DialogResizeMode", typeof(ResizeMode), typeof(DialogManager));
        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DialogManager), new UIPropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="IsOpen"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
                   DependencyProperty.Register("IsOpen", typeof(bool), typeof(DialogManager), new UIPropertyMetadata(false, IsOpenChanged));
        /// <summary>
        /// Identifies the <see cref="ShowInTaskbar"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowInTaskbarProperty =
                    DependencyProperty.Register("ShowInTaskbar", typeof(bool), typeof(DialogManager), new UIPropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="OwnerWindow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OwnerWindowProperty =
                    DependencyProperty.Register("OwnerWindow", typeof(Window), typeof(DialogManager), new UIPropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="DialogResult"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.Register("DialogResult", typeof(bool?), typeof(DialogManager));
        #endregion

        #region FieldsPrivate
        private Window m_window;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the resize mode.
        /// </summary>
        public ResizeMode DialogResizeMode
        {
            get { return (ResizeMode)GetValue(DialogResizeModeProperty); }
            set { SetValue(DialogResizeModeProperty, value); }
        }
        /// <summary>
        /// Gets or sets the dialog's title.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        /// <summary>
        /// This should be bound to IsOpen in the ViewModel associated with ModalDialogManager
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        /// <summary>
        /// Gets or sets the dialog result value, which is the value that is returned from the ShowDialog method.
        /// </summary>
        public bool? DialogResult
        {
            get { return (bool?)GetValue(DialogResultProperty); }
            set { SetValue(DialogResultProperty, value); }
        }
        /// <summary>
        /// Gets or sets a value that indicates whether the dialog has a task bar button. 
        /// </summary>
        public bool ShowInTaskbar
        {
            get { return (bool)GetValue(ShowInTaskbarProperty); }
            set { SetValue(ShowInTaskbarProperty, value); }
        }
        /// <summary>
        /// Gets or sets the Window that owns this dialog.
        /// </summary>
        public Window OwnerWindow
        {
            get { return (Window)GetValue(OwnerWindowProperty); }
            set { SetValue(OwnerWindowProperty, value); }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Opens a window and returns only when the newly opened dialog is closed.
        /// </summary>
        /// <returns>
        /// A Nullable&lt;T&gt; value of type Boolean that specifies whether the activity was accepted (true) or canceled (false).
        /// The return value is the value of the <see cref="DialogResult"/> property before a dialog closes.
        /// </returns>
        public bool? ShowDialog()
        {
            this.IsOpen = true;
            return this.DialogResult;
        }
        
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Invoked whenever the effective value of any dependency property on this <see cref="DialogManager"/> has been updated.
        /// The specific dependency property that changed is reported in the arguments parameter.
        /// </summary>
        /// <param name="e">The event data that describes the property that changed, as well as old and new values.</param>
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == FrameworkElement.DataContextProperty)
            {
                BSE.CoverFlow.WPFLib.ViewModel.IDialogModel dialogModel = this.DataContext as BSE.CoverFlow.WPFLib.ViewModel.IDialogModel;
                if (dialogModel != null)
                {
                    System.Windows.Data.Binding isOpenBinding = new System.Windows.Data.Binding();
                    isOpenBinding.Path = new PropertyPath("IsOpen");
                    isOpenBinding.Mode = System.Windows.Data.BindingMode.TwoWay;
                    isOpenBinding.Source = dialogModel;
                    System.Windows.Data.BindingOperations.SetBinding(this, DialogManager.IsOpenProperty, isOpenBinding);

                    System.Windows.Data.Binding dialogResultBinding = new System.Windows.Data.Binding();
                    dialogResultBinding.Path = new PropertyPath("DialogResult");
                    dialogResultBinding.Mode = System.Windows.Data.BindingMode.TwoWay;
                    dialogResultBinding.Source = dialogModel;
                    System.Windows.Data.BindingOperations.SetBinding(this, DialogManager.DialogResultProperty, dialogResultBinding);
                }
            };
        }
        #endregion

        #region MethodsPrivate
        private void Show()
        {
            if (this.m_window != null)
            {
                Close();
            }
            this.m_window = new Window();
            this.m_window.Owner = GetParentWindow(this);
            if (this.m_window.Owner == null)
            {
                WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this.m_window);
                windowInteropHelper.Owner = new WindowInteropHelper(this.OwnerWindow).Owner;
            }
            this.m_window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.m_window.DataContext = this.DataContext;
            this.m_window.SetBinding(Window.ContentProperty, "");
            this.m_window.WindowStyle = WindowStyle.None;
            this.m_window.ResizeMode = this.DialogResizeMode;
            this.m_window.SizeToContent = SizeToContent.WidthAndHeight;
            this.m_window.ShowInTaskbar = this.ShowInTaskbar;
            this.m_window.ShowDialog();
        }
        private void Close()
        {
            if (m_window != null)
            {
                m_window.Close();
                m_window = null;
            }
        }

        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DialogManager dialogManager = d as DialogManager;
            bool newValue = (bool)e.NewValue;
            if (newValue)
            {
                dialogManager.Show();
            }
            else
            {
                dialogManager.Close();
            }
        }
        /// <summary>
        /// Gets the parent <see cref="Window"/> if its a pure Wpf application
        /// </summary>
        /// <param name="currentElement"></param>
        /// <returns>The parent <see cref="Window"/>.</returns>
        private Window GetParentWindow(FrameworkElement currentElement)
        {
            if (currentElement is Window)
            {
                return currentElement as Window;
            }
            else if (currentElement.Parent is FrameworkElement)
            {
                return GetParentWindow(currentElement.Parent as FrameworkElement);
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}

