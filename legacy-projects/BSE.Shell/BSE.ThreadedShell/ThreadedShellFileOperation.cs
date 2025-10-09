using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace BSE.ThreadedShell
{
    /// <summary>
    /// Execute file operations on a separate thread.
    /// <example>
    /// <code>
    /// Collection<string> sourceFiles = new Collection<string>();
    /// foreach (object fileOrDirectory in filesAndDirectories)
    /// {
    ///     DirectoryInfo directoryInfo = fileOrDirectory as DirectoryInfo;
    ///     if (directoryInfo != null)
    ///     {
    ///         sourceFiles.Add(directoryInfo.FullName);
    ///     }
    ///     FileInfo fileInfo = fileOrDirectory as FileInfo;
    ///     if (fileInfo != null)
    ///     {
    ///         sourceFiles.Add(fileInfo.FullName);
    ///     }
    /// }
    /// 
    /// BSE.ThreadedShell.ThreadedShellFileOperation threadedShellFileOperation
    ///             = new BSE.ThreadedShell.ThreadedShellFileOperation
    /// {
    ///     SourceFiles = sourceFiles,
    ///     FileOperation = BSE.Shell.ShellFileOperation.FileOperations.FO_DELETE,
    ///     Handle = this.Handle
    /// };
    /// threadedShellFileOperation.StartFileOperations();
    /// </code>
    /// </example>
    /// </summary>
    public class ThreadedShellFileOperation
    {
        #region Events
        /// <summary>
        /// Occurs when the file operation is complete.
        /// </summary>
        public EventHandler<EventArgs> FileOperationComplete;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the window handle to the dialog box to display information about the status of the file operation.
        /// </summary>
        public IntPtr Handle
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="BSE.Shell.FileOperation"/>.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        public BSE.Shell.FileOperation FileOperation
        {
            private get;
            set;
        }
        /// <summary>
        /// The <see cref="BSE.Shell.ShellFileOperationFlags"/> that control the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        public BSE.Shell.ShellFileOperationFlags OperationFlags
        {
            private get;
            set;
        }
        /// <summary>
        /// The source file <see cref="Collection<string>"/> for the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        public Collection<string> SourceFiles
        {
            private get;
            set;
        }
        /// <summary>
        /// The destination file <see cref="Collection<string>"/> for the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        public Collection<string> DestinationFiles
        {
            private get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        private FileOperationData FileOperationsData
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadedShellFileOperation"/> class.
        /// </summary>
        public ThreadedShellFileOperation()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadedShellFileOperation"/> class.
        /// </summary>
        /// <param name="fileOperationsData"></param>
        public ThreadedShellFileOperation(FileOperationData fileOperationsData)
            : this()
        {
            this.FileOperationsData = fileOperationsData;
        }
        /// <summary>
        /// Execute the threaded file operations.
        /// </summary>
        public void StartFileOperations()
        {
            if (this.FileOperationsData == null)
            {
                this.FileOperationsData = new FileOperationData
                {
                    Handle = this.Handle,
                    SourceFiles = this.SourceFiles,
                    DestinationFiles = this.DestinationFiles,
                    FileOperation = this.FileOperation,
                    OperationFlags = this.OperationFlags
                };
            }
            
            FileOperationThread fileOperationthread = new FileOperationThread(this.FileOperationsData);
            fileOperationthread.FileOperationComplete += new EventHandler<EventArgs>(FileOperationCompleteThread);
        }
        #endregion

        #region MethodsPrivate
        private void FileOperationCompleteThread(object sender, EventArgs e)
        {
            using (FileOperationThread fileOperationthread = sender as FileOperationThread)
            {
                if (fileOperationthread != null)
                {
                    fileOperationthread.FileOperationComplete -= new EventHandler<EventArgs>(FileOperationCompleteThread);
                    if (FileOperationComplete != null)
                    {
                        FileOperationComplete(this, new EventArgs());
                    }
                }
            }
        }
        #endregion
    }
}
