using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Displays a message box.
    /// </summary>
    public class MessageWindow : System.Windows.Window
    {
        #region FieldsPublic
        /// <summary>
        /// Identifies the <see cref="DialogOkCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogOKCommandProperty =
            DependencyProperty.Register("DialogOkCommand", typeof(ICommand), typeof(MessageWindow), new PropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="DialogCancelCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogCancelCommandProperty =
            DependencyProperty.Register("DialogCancelCommand", typeof(ICommand), typeof(MessageWindow), new PropertyMetadata(null));
        /// <summary>
        /// Identifies the <see cref="OwnerWindow"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OwnerWindowProperty =
            DependencyProperty.Register("OwnerWindow", typeof(Window), typeof(MessageWindow),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(MessageWindow.OnOwnerWindowChanged)));
        /// <summary>
        /// Identifies the <see cref="Buttons"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(DialogButton), typeof(MessageWindow),
                new FrameworkPropertyMetadata(DialogButton.Ok));
        /// <summary>
        /// Identifies the DialogResult dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.Register("DialogResult", typeof(DialogResult), typeof(MessageWindow),
                new FrameworkPropertyMetadata(BSE.CoverFlow.WPFLib.Controls.DialogResult.None));
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
                return (ICommand)GetValue(MessageWindow.DialogOKCommandProperty);
            }
            set
            {
                SetValue(MessageWindow.DialogOKCommandProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the command to invoke when the dialog's Cancel button is pressed.
        /// </summary>
        public ICommand DialogCancelCommand
        {
            get
            {
                return (ICommand)GetValue(MessageWindow.DialogCancelCommandProperty);
            }
            set
            {
                SetValue(MessageWindow.DialogCancelCommandProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the button combination to be shown
        /// </summary>
        public DialogButton Buttons
        {
            get { return (DialogButton)base.GetValue(MessageWindow.ButtonsProperty); }
            set { base.SetValue(MessageWindow.ButtonsProperty, value); }
        }
        /// <summary>
        /// Gets or sets the Window that owns this dialog.
        /// </summary>
        public Window OwnerWindow
        {
            get { return (Window)GetValue(OwnerWindowProperty); }
            set { SetValue(OwnerWindowProperty, value); }
        }
        /// <summary>
        /// Gets the dialog result
        /// </summary>
        public new DialogResult DialogResult
        {
            get { return (DialogResult)base.GetValue(DialogResultProperty); }
            set { base.SetValue(DialogResultProperty, value); }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageWindow"/> class.
        /// </summary>
        public MessageWindow()
        {
            this.WindowStyle = System.Windows.WindowStyle.None;
            CommandBinding bindingAccept = new CommandBinding(MessageWindow.AcceptCommand, new ExecutedRoutedEventHandler(OnAccept));
            this.CommandBindings.Add(bindingAccept);
            CommandBinding bindingCancel = new CommandBinding(MessageWindow.CancelCommand, new ExecutedRoutedEventHandler(OnCancel));
            this.CommandBindings.Add(bindingCancel);
        }

        static MessageWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageWindow), new FrameworkPropertyMetadata(typeof(MessageWindow)));
            MessageWindow.AcceptCommand = new RoutedCommand("Accept", typeof(MessageWindow));
            MessageWindow.CancelCommand = new RoutedCommand("Cancel", typeof(MessageWindow));
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
            if (this.Buttons == DialogButton.Ok || this.Buttons == DialogButton.OkCancel)
            {
                this.DialogResult = DialogResult.Ok;
            }
            else
            {
                this.DialogResult = DialogResult.Yes;
            }
            this.Close();
        }
        private void OnOwnerWindowChanged(Window window)
        {
            if (window != null)
            {
                WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);
                windowInteropHelper.Owner = new WindowInteropHelper(window).Owner;
            }
        }

        private static void OnOwnerWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageWindow dialogWindow = d as MessageWindow;
            dialogWindow.OnOwnerWindowChanged((Window)e.NewValue);
        }
        #endregion

    }
}
