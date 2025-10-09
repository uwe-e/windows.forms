using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;

namespace BSE.Shell
{
    /// <summary>
    /// The class <b>ShellFileOperation</b> copies, moves, renames, or deletes a file system object.
    /// </summary>
    public class ShellFileOperation
    {
        #region Properties
        /// <summary>
        /// The source file array for the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public String[] SourceFiles
        {
            private get;
            set;
        }
        /// <summary>
        /// The Title for the progress.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        public String ProgressTitle
        {
            private get;
            set;
        }
        /// <summary>
        /// Gets or sets the window handle to the dialog box to display information about the status of the file operation.
        /// </summary>
        public IntPtr Handle
        {
            get;
            set;
        }
        /// <summary>
        /// The <see cref="ShellFileOperationFlags"/> that control the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        public ShellFileOperationFlags OperationFlags
        {
            private get;
            set;
        }
        /// <summary>
        /// A value that indicates which operation to perform.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        public FileOperation Operation
        {
            private get;
            set;
        }
        /// <summary>
        /// The destination file array for the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public String[] DestinationFiles
        {
            private get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellFileOperation"/> class.
        /// </summary>
        public ShellFileOperation()
        {
            this.Handle = IntPtr.Zero;
            this.Operation = FileOperation.FO_COPY;
            this.OperationFlags = ShellFileOperationFlags.FOF_ALLOWUNDO
                | ShellFileOperationFlags.FOF_MULTIDESTFILES
                | ShellFileOperationFlags.FOF_NO_CONNECTED_ELEMENTS
                | ShellFileOperationFlags.FOF_WANTNUKEWARNING;
            this.ProgressTitle = string.Empty;
        }
        /// <summary>
        /// Execute the file operations.
        /// </summary>
        /// <returns>Gets a value indicating whether the file operation is executed.</returns>
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool DoOperation()
        {
            SHFILEOPSTRUCT fileOpStruct = new SHFILEOPSTRUCT();

            //fileOpStruct.hwnd = this.OwnerWindow.Handle;
            fileOpStruct.hwnd = this.Handle;
            fileOpStruct.wFunc = (uint)this.Operation;

            String strMultiSource = StringArrayToMultiString(this.SourceFiles);
            String strMultiDestination = StringArrayToMultiString(this.DestinationFiles);
            fileOpStruct.pFrom = Marshal.StringToHGlobalUni(strMultiSource);
            fileOpStruct.pTo = Marshal.StringToHGlobalUni(strMultiDestination);

            fileOpStruct.fFlags = (ushort)this.OperationFlags;
            fileOpStruct.lpszProgressTitle = ProgressTitle;
            fileOpStruct.fAnyOperationsAborted = 0;
            fileOpStruct.hNameMappings = IntPtr.Zero;

            int iRetVal = NativeMethods.SHFileOperation(ref fileOpStruct);

            NativeMethods.SHChangeNotify(
                (uint)ShellChangeNotificationEvents.SHCNE_ALLEVENTS,
                (uint)ShellChangeNotificationFlag.SHCNF_DWORD,
                IntPtr.Zero,
                IntPtr.Zero);

            if (iRetVal != 0)
            {
                return false;
            }
            if (fileOpStruct.fAnyOperationsAborted != 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        #region MethodsPrivate

        private static String StringArrayToMultiString(String[] stringArray)
        {
            String multiString = string.Empty;

            if (stringArray == null)
            {
                return string.Empty;
            }

            for (int i = 0; i < stringArray.Length; i++)
            {
                multiString += stringArray[i] + '\0';
            }
            multiString += '\0';

            return multiString;
        }

        #endregion
    }
}
