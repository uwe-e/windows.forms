using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Shell
{
    /// <summary>
    /// Flags that, when combined bitwise with SHCNF_TYPE, indicate the meaning of the dwItem1 and
    /// dwItem2 parameters. The uFlags parameter must be one of the following values.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
    public enum ShellChangeNotificationFlag
    {
        /// <summary>
        /// dwItem1 and dwItem2 are the addresses of ITEMIDLIST structures that represent the item(s) affected
        /// by the change. Each ITEMIDLIST must be relative to the desktop folder. 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_IDLIST = 0x0000,
        /// <summary>
        /// dwItem1 and dwItem2 are the addresses of null-terminated strings of maximum length MAX_PATH
        /// that contain the full path names of the items affected by the change.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_PATHA = 0x0001,
        /// <summary>
        /// dwItem1 and dwItem2 are the addresses of null-terminated strings that represent the friendly
        /// names of the printer(s) affected by the change. 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_PRINTERA = 0x0002,
        /// <summary>
        /// The dwItem1 and dwItem2 parameters are DWORD values.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_DWORD = 0x0003,
        /// <summary>
        /// like SHCNF_PATHA but unicode string.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_PATHW = 0x0005,
        /// <summary>
        /// like SHCNF_PRINTERA but unicode string.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_PRINTERW = 0x0006,
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_TYPE = 0x00FF,
        /// <summary>
        /// The function should not return until the notification has been delivered to all
        /// affected components. As this flag modifies other data-type flags, it cannot by used
        /// by itself.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_FLUSH = 0x1000,
        /// <summary>
        /// The function should begin delivering notifications to all affected components but should
        /// return as soon as the notification process has begun. As this flag modifies other
        /// data-type flags, it cannot by used by itself. This flag includes SHCNF_FLUSH.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        SHCNF_FLUSHNOWAIT = 0x2000
    }
}
