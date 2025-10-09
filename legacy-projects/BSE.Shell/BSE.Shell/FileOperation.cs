using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Shell
{
    /// <summary>
    /// Specifies a value that indicates which operation to perform. One of the following
    /// values:.
    /// </summary>
    public enum FileOperation
    {
        /// <summary>
        /// Move the files specified in pFrom to the location specified in pTo.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FO_MOVE = 0x0001,
        /// <summary>
        /// Copy the files specified in the pFrom member to the location specified in the
        /// pTo member.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FO_COPY = 0x0002,
        /// <summary>
        /// Delete the files specified in pFrom.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FO_DELETE = 0x0003,
        /// <summary>
        /// Rename the file specified in pFrom. You cannot use this flag to rename multiple
        /// files with a single function call. Use FO_MOVE instead.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        FO_RENAME = 0x0004
    }
}
