using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BSE.Shell
{
    internal static class NativeMethods
    {
        /// <summary>
        /// Copies, moves, renames, or deletes a file system object. This function has been replaced in
        /// Windows Vista by IFileOperation.
        /// </summary>
        /// <param name="lpFileOp">A pointer to an SHFILEOPSTRUCT structure that contains information this
        /// function needs to carry out the specified operation. This parameter must contain a
        /// valid value that is not NULL. You are responsible for validating the value. If you do
        /// not validate it, you will experience unexpected results.</param>
        /// <returns>Returns zero if successful; otherwise nonzero. Applications normally should simply check
        /// for zero or nonzero. </returns>
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        internal static extern Int32 SHFileOperation(
            ref SHFILEOPSTRUCT lpFileOp);
        /// <summary>
        /// Notifies the system of an event that an application has performed. An application should use this
        /// function if it performs an action that may affect the Shell.
        /// </summary>
        /// <param name="wEventId">Describes the event that has occurred. Typically, only one event is
        /// specified at a time. If more than one event is specified, the values contained in the
        /// dwItem1 and dwItem2 parameters must be the same, respectively, for all specified events.
        /// This parameter can be one or more of the following values:
        /// 
        /// <see cref="SHCNE_ALLEVENTS"/>
        /// All events have occurred.
        /// <see cref="SHCNE_ASSOCCHANGED"/>
        /// A file type association has changed. <see cref="SHCNF_IDLIST"/> must be specified in the uFlags
        /// parameter. dwItem1 and dwItem2 are not used and must be NULL.
        /// <see cref="SHCNE_ATTRIBUTES"/>
        /// The attributes of an item or folder have changed. <see cref="SHCNF_IDLIST"/> or
        /// <see cref="SHCNF_PATH"/> must be specified in uFlags. dwItem1 contains the item or
        /// folder that has changed. dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_CREATE"/>
        /// A nonfolder item has been created. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the item that was created. dwItem2 is not
        /// used and should be NULL.
        /// <see cref="SHCNE_DELETE"/>
        /// A nonfolder item has been deleted. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the item that was deleted. dwItem2 is
        /// not used and should be NULL. 
        /// <see cref="SHCNE_DRIVEADD"/>
        /// A drive has been added. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be
        /// specified in uFlags. dwItem1 contains the root of the drive that was added. dwItem2
        /// is not used and should be NULL. 
        /// <see cref="SHCNE_DRIVEADDGUI"/>
        /// Windows XP and later: Not used.
        /// <see cref="SHCNE_DRIVEREMOVED"/>
        /// A drive has been removed. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be
        /// specified in uFlags. dwItem1 contains the root of the drive that was removed. dwItem2
        /// is not used and should be NULL. 
        /// <see cref="SHCNE_EXTENDED_EVENT"/>
        /// Not currently used. 
        /// <see cref="SHCNE_FREESPACE"/>
        /// The amount of free space on a drive has changed. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the root of the drive on which the free
        /// space changed. dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_MEDIAINSERTED"/>
        /// Storage media has been inserted into a drive. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the root of the drive that contains
        /// the new media. dwItem2 is not used and should be NULL. 
        /// <see cref="SHCNE_MEDIAREMOVED"/>
        /// Storage media has been removed from a drive. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the root of the drive from which the media
        /// was removed. dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_MKDIR"/>
        /// A folder has been created. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must
        /// be specified in uFlags. dwItem1 contains the folder that was created. dwItem2 is not
        /// used and should be NULL.
        /// <see cref="SHCNE_NETSHARE"/>
        /// A folder on the local computer is being shared via the network. <see cref="SHCNF_IDLIST"/>
        /// or <see cref="SHCNF_PATH"/> must be specified in uFlags. dwItem1 contains the folder
        /// that is being shared. dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_NETUNSHARE"/>
        /// A folder on the local computer is no longer being shared via the network. <see cref="SHCNF_IDLIST"/>
        /// or <see cref="SHCNF_PATH"/> must be specified in uFlags. dwItem1 contains the folder
        /// that is no longer being shared. dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_RENAMEFOLDER"/>
        /// The name of a folder has changed. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the previous pointer to an item identifier
        /// list (PIDL) or name of the folder. dwItem2 contains the new PIDL or name of the folder.
        /// <see cref="SHCNE_RENAMEITEM"/>
        /// The name of a nonfolder item has changed. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the previous PIDL or name of the item.
        /// dwItem2 contains the new PIDL or name of the item.
        /// <see cref="SHCNE_RMDIR"/>
        /// A folder has been removed. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must
        /// be specified in uFlags. dwItem1 contains the folder that was removed. dwItem2 is not
        /// used and should be NULL.
        /// <see cref="SHCNE_SERVERDISCONNECT"/>
        /// The computer has disconnected from a server. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/>
        /// must be specified in uFlags. dwItem1 contains the server from which the computer was
        /// disconnected. dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_UPDATEDIR"/>
        /// The contents of an existing folder have changed, but the folder still exists and has
        /// not been renamed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1
        /// contains the folder that has changed. dwItem2 is not used and should be NULL. If a folder has
        /// been created, deleted, or renamed, use <see cref="SHCNE_MKDIR"/>, <see cref="SHCNE_RMDIR"/>,
        /// or <see cref="SHCNE_RENAMEFOLDER"/>, respectively.
        /// <see cref="SHCNE_UPDATEIMAGE"/>
        /// An image in the system image list has changed. <see cref="SHCNF_DWORD"/> must be
        /// specified in uFlags.
        /// 
        /// Windows NT/2000/XP: dwItem2 contains the index in the system image list that has changed.
        /// dwItem1 is not used and should be NULL.
        /// 
        /// Windows 95/98: dwItem1 contains the index in the system image list that has changed.
        /// dwItem2 is not used and should be NULL.
        /// <see cref="SHCNE_UPDATEITEM"/>
        /// An existing item (a folder or a nonfolder) has changed, but the item still exists and
        /// has not been renamed. <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be
        /// specified in uFlags. dwItem1 contains the item that has changed. dwItem2 is not used
        /// and should be NULL. If a nonfolder item has been created, deleted, or renamed, use
        /// <see cref="SHCNE_CREATE"/>, <see cref="SHCNE_DELETE"/>, or <see cref="SHCNE_RENAMEITEM"/>,
        /// respectively, instead.
        /// <see cref="SHCNE_DISKEVENTS"/>
        /// Specifies a combination of all of the disk event identifiers.
        /// <see cref="SHCNE_GLOBALEVENTS"/>
        /// Specifies a combination of all of the global event identifiers.
        /// <see cref="SHCNE_INTERRUPT"/>
        /// The specified event occurred as a result of a system interrupt. As this value modifies
        /// other event values, it cannot be used alone.
        /// </param>
        /// <param name="uFlags">
        /// Flags that, when combined bitwise with <see cref="SHCNF_TYPE"/>, indicate the meaning
        /// of the dwItem1 and dwItem2 parameters. The uFlags parameter must be one of the following
        /// values.
        /// <see cref="SHCNF_DWORD"/>
        /// The dwItem1 and dwItem2 parameters are DWORD values.
        /// <see cref="SHCNF_IDLIST"/>
        /// dwItem1 and dwItem2 are the addresses of ITEMIDLIST structures that represent the
        /// item(s) affected by the change. Each ITEMIDLIST must be relative to the desktop folder.
        /// <see cref="SHCNF_PATH"/>
        /// dwItem1 and dwItem2 are the addresses of null-terminated strings of maximum length
        /// MAX_PATH that contain the full path names of the items affected by the change.
        /// <see cref="SHCNF_PRINTER"/>
        /// dwItem1 and dwItem2 are the addresses of null-terminated strings that represent the
        /// friendly names of the printer(s) affected by the change.
        /// <see cref="SHCNF_FLUSH"/>
        /// The function should not return until the notification has been delivered to all affected
        /// components. As this flag modifies other data-type flags, it cannot by used by itself.
        /// <see cref="SHCNF_FLUSHNOWAIT"/>
        /// The function should begin delivering notifications to all affected components but should
        /// return as soon as the notification process has begun. As this flag modifies other
        /// data-type flags, it cannot by used by itself. This flag includes <see cref="SHCNF_FLUSH"/>.
        /// <see cref="SHCNF_NOTIFYRECURSIVE"/>
        /// Notify clients registered for all children.
        /// </param>
        /// <param name="dwItem1">Optional. First event-dependent value.</param>
        /// <param name="dwItem2">Optional. Second event-dependent value.</param>
        [DllImport("shell32.dll")]
        internal static extern void SHChangeNotify(
            UInt32 wEventId,
            UInt32 uFlags,
            IntPtr dwItem1,
            IntPtr dwItem2);				// Second event-dependent value. 
    }
}
