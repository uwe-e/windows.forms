using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Data;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Represents a dialog windows control, which acts as a container for the dialog content.
    /// </summary>
    public class Dialog : ContentControl
    {
        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="DialogOkCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogOKCommandProperty =
            DependencyProperty.Register("DialogOkCommand", typeof(ICommand), typeof(Dialog), new PropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="DialogCancelCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogCancelCommandProperty =
            DependencyProperty.Register("DialogCancelCommand", typeof(ICommand), typeof(Dialog), new PropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="DialogResizeMode"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogResizeModeProperty =
            DependencyProperty.Register("DialogResizeMode", typeof(ResizeMode), typeof(Dialog));
        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Dialog));
        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(DialogButton), typeof(Dialog),
                new FrameworkPropertyMetadata(DialogButton.OkCancel));
        #endregion

        #region Commands
        /// <summary>
        /// Accept command
        /// </summary>
        public static RoutedCommand AcceptCommand;
        /// <summary>
        /// Cancel command
        /// </summary>
        public static RoutedCommand CancelCommand;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the command to invoke when the dialog's OK button is pressed.
        /// </summary>
        public ICommand DialogOkCommand
        {
            get
            {
                return (ICommand)GetValue(Dialog.DialogOKCommandProperty);
            }
            set
            {
                SetValue(Dialog.DialogOKCommandProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the command to invoke when the dialog's Cancel button is pressed.
        /// </summary>
        public ICommand DialogCancelCommand
        {
            get
            {
                return (ICommand)GetValue(Dialog.DialogCancelCommandProperty);
            }
            set
            {
                SetValue(Dialog.DialogCancelCommandProperty, value);
            }
        }
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
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the button combination to be shown
        /// </summary>
        public DialogButton Buttons
        {
            get { return (DialogButton)base.GetValue(Dialog.ButtonsProperty); }
            set { base.SetValue(Dialog.ButtonsProperty, value); }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="Dialog"/> class.
        /// </summary>
        public Dialog()
        {
            CommandBinding bindingAccept = new CommandBinding(Dialog.AcceptCommand, new ExecutedRoutedEventHandler(OnAccept));
            this.CommandBindings.Add(bindingAccept);
            CommandBinding bindingCancel = new CommandBinding(Dialog.CancelCommand, new ExecutedRoutedEventHandler(OnCancel));
            this.CommandBindings.Add(bindingCancel);
        }

        #endregion

        #region MethodsPrivate
        private void OnCancel(object sender, ExecutedRoutedEventArgs e)
        {
            if (DialogCancelCommand != null)
            {
                DialogCancelCommand.Execute(null);
            }
        }
        private void OnAccept(object sender, ExecutedRoutedEventArgs e)
        {
            if (DialogOkCommand != null)
            {
                DialogOkCommand.Execute(null);
            }
        }

        static Dialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Dialog), new FrameworkPropertyMetadata(typeof(Dialog)));

            Dialog.AcceptCommand = new RoutedCommand("Accept", typeof(Dialog));
            Dialog.CancelCommand = new RoutedCommand("Cancel", typeof(Dialog));
        }
        
        #endregion

    }
}
