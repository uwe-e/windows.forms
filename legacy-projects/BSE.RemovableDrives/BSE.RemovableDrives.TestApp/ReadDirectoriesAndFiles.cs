using System;
using System.IO;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Summary description for CReadDirectoriesAndFiles.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2005 BSE</copyright>
	public abstract class ReadDirectoriesAndFiles
	{

		#region EventsPublic
		/// <summary>
        /// Represents the CancelReading method that will handle an event.
		/// </summary>
        public event System.EventHandler CancelReading;
		/// <summary>
        /// Represents the ReadingComplete method that will handle an event.
		/// </summary>
        public event System.EventHandler ReadingComplete;
		/// <summary>
        /// Represents the ReadDirectory method that will handle an event.
		/// </summary>
        public event EventHandler<ReadDirectoriesEventArgs> ReadDirectory;
		/// <summary>
        /// Represents the FoundDirectory method that will handle an event.
		/// </summary>
        public event EventHandler<ReadDirectoriesEventArgs> FoundDirectory;

		#endregion

        #region FieldsPrivate

        private System.Timers.Timer m_timer;
        private System.Windows.Forms.IWin32Window m_owner;
        private System.Threading.Thread m_threadReadDirectoriesAndFiles = null;
        private DirectoryInfo m_directoryInfo;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the current thread
        /// </summary>
        public System.Threading.Thread Thread
        {
            get { return this.m_threadReadDirectoriesAndFiles; }
            set { this.m_threadReadDirectoriesAndFiles = value; }
        }
        /// <summary>
        /// Gets the Win32 HWND handle
        /// </summary>
        public System.Windows.Forms.IWin32Window Owner
        {
            get { return this.m_owner; }
        }
        /// <summary>
        /// Gets the current directoryinfo
        /// </summary>
        public DirectoryInfo DirectoryInfo
        {
            get { return this.m_directoryInfo; }
            set { this.m_directoryInfo = value; }
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
            OnCancelReading(new System.EventArgs());
		}
		#endregion

		#region MethodsProtected

        /// <summary>
        /// default constructor of the CReadDirectoriesAndFiles class.
		/// </summary>
        protected ReadDirectoriesAndFiles(System.Windows.Forms.IWin32Window owner, System.IO.DirectoryInfo directoryInfo)
        {
            this.m_owner = owner;
            if (this.m_timer == null)
            {
                this.m_timer = new System.Timers.Timer();
                this.m_timer.Elapsed += this.TimerElapsed;
                this.m_timer.Enabled = true;
            }
            this.m_timer.Start();
        }
        /// <summary>
        /// Raises the CancelReading event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
		protected void OnCancelReading(System.EventArgs e)
		{
			if (CancelReading != null)
			{
				CancelReading(this,e);
			}
		}
        /// <summary>
        /// Raises the ReadingComplete event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
		protected virtual void OnReadingComplete(System.EventArgs e)
		{
			if (ReadingComplete != null)
			{
				ReadingComplete(this,e);
			}
		}
        /// <summary>
        /// Raises the ReadDirectory event.
        /// </summary>
        /// <param name="e">An ReadDirectoriesEventArgs that contains the event data.</param>
        protected virtual void OnReadDirectory(ReadDirectoriesEventArgs e)
		{
			if (ReadDirectory != null)
			{
				ReadDirectory(this, e);
			}
		}
        /// <summary>
        /// Raises the FoundDirectory event.
        /// </summary>
        /// <param name="e">An ReadDirectoriesEventArgs that contains the event data.</param>
		protected virtual void OnFoundDirectory(ReadDirectoriesEventArgs e)
		{
			if (FoundDirectory != null)
			{
				FoundDirectory(this, e);
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
                    OnReadingComplete(new System.EventArgs());
                }
            }
        }

        #endregion
    }
}
