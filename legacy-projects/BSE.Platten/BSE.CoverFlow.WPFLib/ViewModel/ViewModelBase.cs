using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Threading;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        #region Events
        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private bool m_bIsIdle = true;
        private readonly Dispatcher m_dispatcher;
        private BSE.CoverFlow.WPFLib.Services.IDialogService m_dialogService;
        #endregion

        #region Properties
        public BSE.CoverFlow.WPFLib.Services.IDialogService DialogService
        {
            get
            {
                return BSE.CoverFlow.WPFLib.Services.ServiceLocator.Resolve<BSE.CoverFlow.WPFLib.Services.IDialogService>();
                //this.m_dialogService = BSE.CoverFlow.WPFLib.Services.ServiceLocator.Resolve<BSE.CoverFlow.WPFLib.Services.IDialogService>();
                //if (this.m_dialogService == null)
                //{
                //    BSE.CoverFlow.WPFLib.Services.ServiceLocator.RegisterSingleton<BSE.CoverFlow.WPFLib.Services.IDialogService,
                //        BSE.CoverFlow.WPFLib.Services.DialogService>();
                //    this.m_dialogService = BSE.CoverFlow.WPFLib.Services.ServiceLocator.Resolve<BSE.CoverFlow.WPFLib.Services.IDialogService>();
                //}
                //return this.m_dialogService;
            }
        }
        /// <summary>
        /// Gets the Dispatcher this DispatcherObject is associated with.
        /// </summary>
        protected Dispatcher Dispatcher
        {
            get { return this.m_dispatcher; }
        }
        /// <summary>
        /// Gets or sets an information whether the backgroundworker thread runs in idle mode.
        /// </summary>
        public bool IsIdle
        {
            get
            {
                return this.m_bIsIdle;
            }
            set
            {
                this.m_bIsIdle = value;
            }
        }
        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this); 
        }
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                //else
                //    Debug.Fail(msg);
            }
        }
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            this.Dispose(false);
        }
        #endregion

        #region MethodsProtected
        protected ViewModelBase()
        {
            this.m_dispatcher = Dispatcher.CurrentDispatcher;
        }
        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // Free other state (managed objects).
            if (disposing)
            {
            }
            // Free your own state (unmanaged objects).
            // Set large fields to null.
        }
        /// <summary>
        /// Executes the specified <see cref="Action "/> synchronously on the thread the Dispatcher is associated with. 
        /// </summary>
        /// <param name="action">The action.</param>
        protected void Invoke(Action action)
        {
            if (this.Dispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                this.Dispatcher.Invoke(action);
            }
        }
        /// <summary>
        /// Executes the specified <see cref="Action "/> asynchronously at the <see cref="DispatcherPriority.Normal"/> on the thread the Dispatcher is associated with.
        /// </summary>
        /// <param name="action">The action.</param>
        protected void InvokeAsynchronously(Action action)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
        }
        /// <summary>
        /// Executes the specified <see cref="Action "/> asynchronously at the <see cref="DispatcherPriority.Background"/> on the thread the Dispatcher is associated with.
        /// </summary>
        /// <param name="action">The <see cref="Action"/></param>
        protected void InvokeAsynchronouslyInBackground(Action action)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, action);
        }
        /// <summary>
        /// Executes the specified <see cref="Action "/> in a <see cref="System.ComponentModel.BackgroundWorker"/> thread.
        /// </summary>
        /// <param name="action">The action.</param>
        protected void DoWork(Action action)
        {
            this.IsIdle = false;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += (sender, e) => action();
                worker.RunWorkerCompleted += (sender, e) => this.IsIdle = true;
                worker.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <param name="args">The data for the PropertyChanged event.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, args);
            }
        }
        #endregion

        #region MethodsPrivate
        #endregion

    }
}
