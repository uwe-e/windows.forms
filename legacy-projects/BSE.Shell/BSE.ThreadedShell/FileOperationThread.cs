using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BSE.ThreadedShell.Properties;
using System.Collections.ObjectModel;

namespace BSE.ThreadedShell
{
    internal class FileOperationThread : IDisposable
    {
        #region Events
        public EventHandler<EventArgs> FileOperationComplete;
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private BackgroundWorker m_backgroundWorker;
        #endregion

        #region Properties
        private FileOperationData FileOperationsData
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        public FileOperationThread(FileOperationData fileOperationsData)
        {
            this.FileOperationsData = fileOperationsData;
            this.m_backgroundWorker = new BackgroundWorker();
            this.m_backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorkerDoWork);
            this.m_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerRunWorkerCompleted);
            this.m_backgroundWorker.RunWorkerAsync();
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
        // Use C# destructor syntax for finalization code.
        ~FileOperationThread()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }
        #endregion

        #region MethodsProtected
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (disposing == true)
            {
                if (this.m_backgroundWorker != null)
                {
                    this.m_backgroundWorker.Dispose();
                }
            }
        }
        #endregion

        #region MethodsPrivate
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (this.FileOperationsData == null)
            {
                throw new ArgumentException(
                    string.Format(
                    System.Globalization.CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "FileOperationsData"));
            }
            try
            {
                BSE.Shell.ShellFileOperation shellFileOperation = new BSE.Shell.ShellFileOperation();
                BSE.Shell.FileOperation fileOperations = this.FileOperationsData.FileOperation;
                shellFileOperation.Handle = this.FileOperationsData.Handle;
                shellFileOperation.OperationFlags = this.FileOperationsData.OperationFlags;
                shellFileOperation.Operation = fileOperations;
                shellFileOperation.SourceFiles = GetFilesFromCollection(this.FileOperationsData.SourceFiles);
                if ((fileOperations == BSE.Shell.FileOperation.FO_COPY) ||
                    (fileOperations == BSE.Shell.FileOperation.FO_MOVE))
                {
                    shellFileOperation.DestinationFiles = GetFilesFromCollection(this.FileOperationsData.DestinationFiles);
                }
                e.Result = shellFileOperation.DoOperation();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (BackgroundWorker backgroundWorker = sender as BackgroundWorker)
            {
                if (backgroundWorker != null)
                {
                    backgroundWorker.DoWork -= new DoWorkEventHandler(BackgroundWorkerDoWork);
                    backgroundWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(BackgroundWorkerRunWorkerCompleted);
                }
                if (e.Error == null)
                {
                    //if ((bool)e.Result == true)
                    {
                        if (FileOperationComplete != null)
                        {
                            FileOperationComplete(this, new EventArgs());
                        }
                    }
                }
            }
        }
        private static string[] GetFilesFromCollection(Collection<string> fileCollection)
        {
            if ((fileCollection == null) && (fileCollection.Count == 0))
            {
                throw new ArgumentException(
                    string.Format(
                    System.Globalization.CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "fileCollection"));
            }
            string[] sourceFiles = new string[fileCollection.Count];
            int iCounter = 0;
            foreach (string strFile in fileCollection)
            {
                sourceFiles[iCounter] = strFile;
                iCounter++;
            }
            return sourceFiles;
        }
        #endregion
    }
}
