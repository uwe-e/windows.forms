using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Shell
{
    /// <summary>
    /// Specifies the flags that control the file operation. This member can take a
    /// combination of the following flags.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
    [Flags]
    public enum ShellFileOperationFlags
    {
        /// <summary>
        /// The pTo member specifies multiple destination files (one for each source file
        /// in pFrom) rather than one directory where all source files are to be
        /// deposited.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_MULTIDESTFILES = 0x0001,
        /// <summary>
        /// Not used.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_CONFIRMMOUSE = 0x0002,
        /// <summary>
        /// Do not display a progress dialog box.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_SILENT = 0x0004,
        /// <summary>
        /// Give the file being operated on a new name in a move, copy, or rename operation if a file with the
        /// target name already exists at the destination.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_RENAMEONCOLLISION = 0x0008,
        /// <summary>
        /// Respond with Yes to All for any dialog box that is displayed.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NOCONFIRMATION = 0x0010,
        /// <summary>
        /// If FOF_RENAMEONCOLLISION is specified and any files were renamed, assign a name mapping object
        /// that contains their old and new names to the hNameMappings member. This object must be
        /// freed using SHFreeNameMappings when it is no longer needed.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_WANTMAPPINGHANDLE = 0x0020,
        /// <summary>
        /// Preserve undo information, if possible.
        /// 
        /// Prior to Windows Vista, operations could be undone only from the same process that
        /// performed the original operation.
        /// 
        /// In Windows Vista and later systems, the scope of the undo is a user session. Any process
        /// running in the user session can undo another operation. The undo state is held in the
        /// Explorer.exe process, and as long as that process is running, it can coordinate the undo
        /// functions.
        /// 
        /// If the source file parameter does not contain fully qualified path and file names,
        /// this flag is ignored.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_ALLOWUNDO = 0x0040,
        /// <summary>
        /// Perform the operation only on files (not on folders) if a wildcard file name (*.*) is specified.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_FILESONLY = 0x0080,
        /// <summary>
        /// Display a progress dialog box but do not show individual file names as they are operated on.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_SIMPLEPROGRESS = 0x0100,
        /// <summary>
        /// Do not ask the user to confirm the creation of a new directory if the operation requires one
        /// to be created.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NOCONFIRMMKDIR = 0x0200,
        /// <summary>
        /// Do not display a dialog to the user if an error occurs.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NOERRORUI = 0x0400,
        /// <summary>
        /// Version 4.71. Do not copy the security attributes of the file. The destination file receives the
        /// security attributes of its new folder.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NOCOPYSECURITYATTRIBS = 0x0800,
        /// <summary>
        /// Only perform the operation in the local directory. Don't operate recursively into subdirectories,
        /// which is the default behavior.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NORECURSION = 0x1000,
        /// <summary>
        /// Version 5.0. Do not move connected files as a group. Only move the specified files.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NO_CONNECTED_ELEMENTS = 0x2000,
        /// <summary>
        /// Version 5.0. Send a warning if a file is being permanently destroyed during a delete operation
        /// rather than recycled. This flag partially overrides FOF_NOCONFIRMATION.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_WANTNUKEWARNING = 0x4000,
        /// <summary>
        /// Not used.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FOF_NORECURSEREPARSE = 0x8000
    }
}
