using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Shell
{
    /// <summary>
    /// Contains information that the <see cref="SHFileOperation"/> function uses to perform file
    /// operations. 
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct SHFILEOPSTRUCT
    {
        /// <summary>
        /// A window handle to the dialog box to display information about the status of the file operation.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public IntPtr hwnd;
        /// <summary>
        /// A value that indicates which operation to perform. One of the following values:
        /// 
        /// <see cref="FO_COPY"/>
        /// Copy the files specified in the pFrom member to the location specified in the pTo member.
        /// <see cref="FO_DELETE"/>
        /// Delete the files specified in pFrom.
        /// <see cref="FO_MOVE"/>
        /// Move the files specified in pFrom to the location specified in pTo.
        /// <see cref="FO_RENAME"/>
        /// Rename the file specified in pFrom. You cannot use this flag to rename multiple files with
        /// a single function call. Use <see cref="FO_MOVE"/> instead.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public UInt32 wFunc;
        /// <summary>
        /// <b>Note  This string must be double-null terminated.</b>
        /// 
        /// A pointer to one or more source file names. These names should be fully-qualified paths to
        /// prevent unexpected results.
        /// 
        /// Standard Microsoft MS-DOS wildcard characters, such as "*", are permitted only in the
        /// file-name position. Using a wildcard character elsewhere in the string will lead to
        /// unpredictable results.
        /// 
        /// Although this member is declared as a single null-terminated string, it is actually a
        /// buffer that can hold multiple null-delimited file names. Each file name is terminated by
        /// a single NULL character. The last file name is terminated with a double NULL
        /// character ("\0\0") to indicate the end of the buffer.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr pFrom;
        /// <summary>
        /// <b>Note  This string must be double-null terminated.</b>
        /// 
        /// A pointer to the destination file or directory name. This parameter must be set to NULL
        /// if it is not used. Wildcard characters are not allowed. Their use will lead to unpredictable
        /// results.
        /// 
        /// Like pFrom, the pTo member is also a double-null terminated string and is handled in much
        /// the same way. However, pTo must meet the following specifications:
        /// 
        /// * Wildcard characters are not supported.
        /// * Copy and Move operations can specify destination directories that do not exist. In those
        /// cases, the system attempts to create them and normally displays a dialog box to ask the
        /// user if they want to create the new directory. To suppress this dialog box and have the
        /// directories created silently, set the FOF_NOCONFIRMMKDIR flag in fFlags.
        /// * For Copy and Move operations, the buffer can contain multiple destination file names
        /// if the fFlags member specifies FOF_MULTIDESTFILES.
        /// * Pack multiple names into the pTo string in the same way as for pFrom.
        /// * Use fully-qualified paths. Using relative paths is not prohibited, but can have
        /// unpredictable results.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2006:UseSafeHandleToEncapsulateNativeResources")]
        public IntPtr pTo;
        /// <summary>
        /// Flags that control the file operation. This member can take a combination of the following
        /// flags.
        /// 
        /// <see cref="FOF_ALLOWUNDO"/>
        /// Preserve undo information, if possible.
        /// 
        /// Prior to Windows Vista, operations could be undone only from the same process that performed
        /// the original operation.
        /// 
        /// In Windows Vista and later systems, the scope of the undo is a user session. Any process
        /// running in the user session can undo another operation. The undo state is held in the
        /// Explorer.exe process, and as long as that process is running, it can coordinate the undo
        /// functions.
        /// 
        /// If the source file parameter does not contain fully qualified path and file names, this
        /// flag is ignored.
        /// 
        /// <see cref="FOF_CONFIRMMOUSE"/>
        /// Not used.
        /// <see cref="FOF_FILESONLY"/>
        /// Perform the operation only on files (not on folders) if a wildcard file name (*.*) is
        /// specified.
        /// <see cref="FOF_MULTIDESTFILES"/>
        /// The pTo member specifies multiple destination files (one for each source file in pFrom)
        /// rather than one directory where all source files are to be deposited.
        /// <see cref="FOF_NOCONFIRMATION"/>
        /// Respond with Yes to All for any dialog box that is displayed.
        /// <see cref="FOF_NOCONFIRMMKDIR"/>
        /// Do not ask the user to confirm the creation of a new directory if the operation requires
        /// one to be created.
        /// <see cref="FOF_NO_CONNECTED_ELEMENTS"/>
        /// Version 5.0. Do not move connected files as a group. Only move the specified files.
        /// <see cref="FOF_NOCOPYSECURITYATTRIBS"/>
        /// Version 4.71. Do not copy the security attributes of the file. The destination file
        /// receives the security attributes of its new folder.
        /// <see cref="FOF_NOERRORUI"/>
        /// Do not display a dialog to the user if an error occurs.
        /// <see cref="FOF_NORECURSEREPARSE"/>
        /// Not used.
        /// <see cref="FOF_NORECURSION"/>
        /// Only perform the operation in the local directory. Don't operate recursively into
        /// subdirectories, which is the default behavior.
        /// <see cref="FOF_NO_UI"/>
        /// Version 6.0.6060 (Windows Vista). Perform the operation silently, presenting no UI to the
        /// user. This is equivalent to FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR.
        /// <see cref="FOF_RENAMEONCOLLISION"/>
        /// Give the file being operated on a new name in a move, copy, or rename operation if a file
        /// with the target name already exists at the destination.
        /// <see cref="FOF_SILENT"/>
        /// Do not display a progress dialog box.
        /// <see cref="FOF_SIMPLEPROGRESS"/>
        /// Display a progress dialog box but do not show individual file names as they are operated on.
        /// <see cref="FOF_WANTMAPPINGHANDLE"/>
        /// If <see cref="FOF_RENAMEONCOLLISION"/> is specified and any files were renamed, assign a
        /// name mapping object that contains their old and new names to the hNameMappings member.
        /// This object must be freed using SHFreeNameMappings when it is no longer needed.
        /// <see cref="FOF_WANTNUKEWARNING"/>
        /// Version 5.0. Send a warning if a file is being permanently destroyed during a delete
        /// operation rather than recycled. This flag partially overrides <see cref="FOF_NOCONFIRMATION"/>.
        /// </summary>
        public UInt16 fFlags;
        /// <summary>
        /// When the function returns, this member contains TRUE if any file operations were aborted before
        /// they were completed; otherwise, FALSE. An operation can be manually aborted by the user
        /// through UI or it can be silently aborted by the system if the <see cref="FOF_NOERRORUI"/> or
        /// <see cref="FOF_NOCONFIRMATION"/> flags were set.
        /// </summary>
        public Int32 fAnyOperationsAborted;
        /// <summary>
        /// When the function returns, this member contains a handle to a name mapping object that contains
        /// the old and new names of the renamed files. This member is used only if the fFlags member
        /// includes the <see cref="FOF_WANTMAPPINGHANDLE"/> flag. See Remarks for more details.
        /// </summary>
        public IntPtr hNameMappings;
        /// <summary>
        /// A pointer to the title of a progress dialog box. This is a null-terminated string. This member
        /// is used only if fFlags includes the FOF_SIMPLEPROGRESS flag.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [MarshalAs(UnmanagedType.LPWStr)]
        public String lpszProgressTitle;
    }
}
