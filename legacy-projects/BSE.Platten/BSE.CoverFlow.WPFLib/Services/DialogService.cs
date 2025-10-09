using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BSE.CoverFlow.WPFLib.Controls;

namespace BSE.CoverFlow.WPFLib.Services
{
    public class DialogService : IDialogService
    {
        private readonly HashSet<FrameworkElement> views;

        /// <summary>
        /// Attached property describing whether a FrameworkElement is acting as a View in MVVM.
        /// </summary>
        public static readonly DependencyProperty IsRegisteredViewProperty =
            DependencyProperty.RegisterAttached("IsRegisteredView", typeof(bool), typeof(DialogService),
            new UIPropertyMetadata(IsRegisteredViewPropertyChanged));
        /// <summary>
        /// Gets value describing whether FrameworkElement is acting as View in MVVM.
        /// </summary>
        public static bool GetIsRegisteredView(FrameworkElement target)
        {
            return (bool)target.GetValue(IsRegisteredViewProperty);
        }
        /// <summary>
        /// Sets value describing whether FrameworkElement is acting as View in MVVM.
        /// </summary>
        public static void SetIsRegisteredView(FrameworkElement target, bool value)
        {
            target.SetValue(IsRegisteredViewProperty, value);
        }

        /// <summary>
        /// Gets the registered views.
        /// </summary>
        public ReadOnlyCollection<FrameworkElement> Views
        {
            get { return new ReadOnlyCollection<FrameworkElement>(views.ToList()); }
        }

        public DialogService()
        {
            views = new HashSet<FrameworkElement>();
        }

        /// <summary>
        /// Registers a View.
        /// </summary>
        /// <param name="view">The registered View.</param>
        public void Register(FrameworkElement view)
        {
            // Get owner window
            Window owner = GetOwner(view);
            if (owner == null)
            {
                // Perform a late register when the View hasn't been loaded yet.
                // This will happen if e.g. the View is contained in a Frame.
                view.Loaded += LateRegister;
                return;
            }

            // Register for owner window closing, since we then should unregister View reference,
            // preventing memory leaks
            owner.Closed += OwnerClosed;

            views.Add(view);
        }

        /// <summary>
        /// Unregisters a View.
        /// </summary>
        /// <param name="view">The unregistered View.</param>
        public void Unregister(FrameworkElement view)
        {
            views.Remove(view);
        }

        public DialogResult ShowMessageBox(
            object ownerViewModel,
            string messageBoxText,
            string caption,
            DialogButton button)
        {

            DialogResult dialogResult = DialogResult.None;
            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
                    (Action)delegate
                    {
                        MessageWindow messageWindow = new MessageWindow
                        {
                            OwnerWindow = this.FindOwnerWindow(ownerViewModel),
                            Title = caption,
                            Content = messageBoxText,
                            WindowStartupLocation = WindowStartupLocation.CenterOwner,
                            WindowStyle = WindowStyle.None,
                            ResizeMode = ResizeMode.NoResize,
                            SizeToContent = System.Windows.SizeToContent.WidthAndHeight
                        };
                        try
                        {
                            messageWindow.ShowDialog();
                        }
                        finally
                        {
                            dialogResult = messageWindow.DialogResult;
                            messageWindow = null; 
                        }
                    });
            return dialogResult;
        }
        public bool? ShowDialog(
            object ownerViewModel,
            object viewModel)
        {
            bool? bShowDialog = null;
            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(
                (Action)delegate
                    {
                        DialogManager dialogManager = new DialogManager
                        {
                            OwnerWindow = this.FindOwnerWindow(ownerViewModel),
                            DataContext = viewModel,
                            ShowInTaskbar = false
                        };
                        try
                        {
                            bShowDialog = dialogManager.ShowDialog();
                        }
                        finally
                        {
                            dialogManager = null;
                        }
                    });
            return bShowDialog;
        }
        /// <summary>
        /// Is responsible for handling IsRegisteredViewProperty changes, i.e. whether
        /// FrameworkElement is acting as View in MVVM or not.
        /// </summary>
        private static void IsRegisteredViewPropertyChanged(DependencyObject target,
            DependencyPropertyChangedEventArgs e)
        {
            // The Visual Studio Designer or Blend will run this code when setting the attached
            // property, however at that point there is no IDialogService registered
            // in the ServiceLocator which will cause the Resolve method to throw a ArgumentException.
            if (DesignerProperties.GetIsInDesignMode(target)) return;

            FrameworkElement view = target as FrameworkElement;
            if (view != null)
            {
                // Cast values
                bool newValue = (bool)e.NewValue;
                bool oldValue = (bool)e.OldValue;

                if (newValue)
                {
                    if (ServiceLocator.Resolve<IDialogService>() != null)
                    {
                        ServiceLocator.Resolve<IDialogService>().Register(view);
                    }
                    else
                    {
                        ServiceLocator.RegisterSingleton<IDialogService,DialogService>();
                        ServiceLocator.Resolve<IDialogService>().Register(view);
                    }
                }
                else
                {
                    ServiceLocator.Resolve<IDialogService>().Unregister(view);
                }
            }
        }
        /// <summary>
        /// Gets the owning Window of a view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>The owning Window if found; otherwise null.</returns>
        private Window GetOwner(FrameworkElement view)
        {
            //return view as Window ?? Window.GetWindow(view);
            Window window = Window.GetWindow(view);
            if (window == null)
            {
                //System.Windows.Interop.HwndSource wpfHandle = PresentationSource.FromVisual(view) as  System.Windows.Interop.HwndSource;
                System.Windows.Forms.Form form = view.FindForm();
                if (form != null)
                {
                    window = new Window();
                    System.Windows.Interop.WindowInteropHelper windowInteropHelper = new System.Windows.Interop.WindowInteropHelper(window);
                    windowInteropHelper.Owner = form.Handle;
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                }
            }
            return window;
        }

        /// <summary>
        /// Finds window corresponding to specified ViewModel.
        /// </summary>
        private Window FindOwnerWindow(object viewModel)
        {
            FrameworkElement view = views.SingleOrDefault(v => ReferenceEquals(v.DataContext, viewModel));
            if (view == null)
            {
                throw new ArgumentException("Viewmodel is not referenced by any registered View.");
            }

            // Get owner window
            Window owner = view as Window;
            if (owner == null)
            {
                owner = Window.GetWindow(view);
            }
            if (owner == null)
            {
                System.Windows.Forms.Form form = view.FindForm();
                if (form != null)
                {
                    owner = new Window();
                    System.Windows.Interop.WindowInteropHelper windowInteropHelper = new System.Windows.Interop.WindowInteropHelper(owner);
                    windowInteropHelper.Owner = form.Handle;
                    owner.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                }
            }

            // Make sure owner window was found
            if (owner == null)
            {
                throw new InvalidOperationException("View is not contained within a Window.");
            }

            return owner;
        }

        /// <summary>
        /// Callback for late View register. It wasn't possible to do a instant register since the
        /// View wasn't at that point part of the logical nor visual tree.
        /// </summary>
        private void LateRegister(object sender, RoutedEventArgs e)
        {
            FrameworkElement view = sender as FrameworkElement;
            if (view != null)
            {
                // Unregister loaded event
                view.Loaded -= LateRegister;

                // Register the view
                Register(view);
            }
        }
        /// <summary>
        /// Handles owner window closed, View service should then unregister all Views acting
        /// within the closed window.
        /// </summary>
        private void OwnerClosed(object sender, EventArgs e)
        {
            Window owner = sender as Window;
            if (owner != null)
            {
                // Find Views acting within closed window
                IEnumerable<FrameworkElement> windowViews =
                    from view in views
                    where Window.GetWindow(view) == owner
                    select view;

                // Unregister Views in window
                foreach (FrameworkElement view in windowViews.ToArray())
                {
                    Unregister(view);
                }
            }
        }
    }
}
