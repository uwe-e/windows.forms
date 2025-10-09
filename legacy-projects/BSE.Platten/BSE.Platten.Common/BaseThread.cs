using System;
using System.IO;

namespace BSE.Platten.Common
{
	/// <summary>
    /// Summary description for BaseThread.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2009 BSE</copyright>
	public abstract class BaseThread : IDisposable
	{
		#region EventsPublic
		/// <summary>
        /// Represents the ThreadCanceled method that will handle an event.
		/// </summary>
        public event System.EventHandler ThreadCanceled;
		/// <summary>
        /// Represents the ThreadCompleted method that will handle an event.
		/// </summary>
        public event System.EventHandler ThreadCompleted;
		/// <summary>
        /// Represents the ThreadWorked method that will handle an event.
		/// </summary>
        public event EventHandler<ThreadEventArgs> ThreadWorked;
		/// <summary>
        /// Represents the ProgressChanged method that will handle an event.
		/// </summary>
        public event EventHandler<ThreadEventArgs> ProgressChanged;

		#endregion

        #region FieldsPrivate

        private System.Timers.Timer m_timer;
        private System.Threading.Thread m_baseThread = null;
        // Track whether Dispose has been called.
        private bool m_bDisposed;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the current thread
        /// </summary>
        public System.Threading.Thread Thread
        {
            get { return this.m_baseThread; }
            set { this.m_baseThread = value; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Cancels the current thread
        /// </summary>
        public void CancelRead()
		{
            if (this.m_timer != null)
			{
                this.m_timer.Stop();
			}
            if (this.Thread != null)
            {
                this.Thread.Abort();
                
            }
            OnThreadCanceled(new System.EventArgs());
		}
        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

		#endregion

		#region MethodsProtected
        /// <summary>
        /// Default constructor of the BaseThread class.
		/// </summary>
        protected BaseThread()
        {
            if (this.m_timer == null)
            {
                this.m_timer = new System.Timers.Timer();
                this.m_timer.Elapsed += this.TimerElapsed;
                this.m_timer.Enabled = true;
            }
            this.m_timer.Start();
        }
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (this.m_bDisposed == false)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    //component.Dispose();
                    if ((this.m_timer != null))
                    {
                        this.m_timer.Stop();
                        this.m_timer.Elapsed -= new System.Timers.ElapsedEventHandler(this.TimerElapsed);
                        this.m_timer.Dispose();
                    }
                    if (this.Thread != null)
                    {
                        this.Thread = null;
                    }
                }
                this.m_bDisposed = true;
            }
        }
        /// <summary>
        /// Raises the ThreadCanceled event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
		protected void OnThreadCanceled(System.EventArgs e)
		{
			if (ThreadCanceled != null)
			{
				ThreadCanceled(this,e);
			}
		}
        /// <summary>
        /// Raises the ThreadCompleted event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
		protected virtual void OnThreadCompleted(System.EventArgs e)
		{
			if (ThreadCompleted != null)
			{
				ThreadCompleted(this,e);
			}
		}
        /// <summary>
        /// Raises the ThreadWorked event.
        /// </summary>
        /// <param name="e">An ThreadEventArgs that contains the event data.</param>
        protected virtual void OnThreadWorked(ThreadEventArgs e)
		{
			if (ThreadWorked != null)
			{
				ThreadWorked(this, e);
			}
		}
        /// <summary>
        /// Raises the rogressChanged event.
        /// </summary>
        /// <param name="e">An ThreadEventArgs that contains the event data.</param>
		protected virtual void OnProgressChanged(ThreadEventArgs e)
		{
			if (ProgressChanged != null)
			{
				ProgressChanged(this, e);
			}
		}

		#endregion

        #region MethodsPrivate

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.Thread != null)
            {
                if (this.Thread.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    this.m_timer.Stop();
                    OnThreadCompleted(new System.EventArgs());
                }
            }
        }

        #endregion
    }
}
