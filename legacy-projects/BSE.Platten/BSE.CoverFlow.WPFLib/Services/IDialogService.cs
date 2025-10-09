using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using BSE.CoverFlow.WPFLib.Controls;

namespace BSE.CoverFlow.WPFLib.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Gets the registered views.
        /// </summary>
        ReadOnlyCollection<FrameworkElement> Views { get; }
        /// <summary>
        /// Registers a View.
        /// </summary>
        /// <param name="view">The registered View.</param>
        void Register(FrameworkElement view);
        /// <summary>
        /// Unregisters a View.
        /// </summary>
        /// <param name="view">The unregistered View.</param>
        void Unregister(FrameworkElement view);
        /// <summary>
        /// Shows a message box.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A ViewModel that represents the owner window of the message box.
        /// </param>
        /// <param name="messageBoxText">A string that specifies the text to display.</param>
        /// <param name="caption">A string that specifies the title bar caption to display.</param>
        /// <param name="button">
        /// A MessageBoxButton value that specifies which button or buttons to display.
        /// </param>
        /// <param name="icon">A MessageBoxImage value that specifies the icon to display.</param>
        /// <returns>
        /// A MessageBoxResult value that specifies which message box button is clicked by the user.
        /// </returns>
        DialogResult ShowMessageBox(
            object ownerViewModel,
            string messageBoxText,
            string caption,
            DialogButton button);
        bool? ShowDialog(
            object ownerViewModel,
            object viewModel);
    }
}
