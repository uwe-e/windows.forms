using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BSE.ThreadedShell
{
    /// <summary>
    /// Conains the properties for file operations.
    /// </summary>
    public class FileOperationData
    {
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
        /// A value that indicates which operation to perform.
        /// </summary>
        public BSE.Shell.FileOperation FileOperation
        {
            get;
            set;
        }
        /// <summary>
        /// The <see cref="BSE.Shell.ShellFileOperationFlags"/> that control the file operation.
        /// </summary>
        public BSE.Shell.ShellFileOperationFlags OperationFlags
        {
            get;
            set;
        }
        /// <summary>
        /// The source file <see cref="Collection<string>"/> for the file operation.
        /// </summary>
        public Collection<string> SourceFiles
        {
            get;
            set;
        }
        /// <summary>
        /// The destination file <see cref="Collection<string>"/> for the file operation.
        /// </summary>
        public Collection<string> DestinationFiles
        {
            get;
            set;
        }
        #endregion
    }
}
