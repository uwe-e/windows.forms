using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BSE.Wpf.RemovableDrives
{
    internal sealed class NativeMethods
    {
        /// <summary>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        internal const int WM_DEVICECHANGE = 0x0219;
        /// <summary>
        /// The system broadcasts the DBT_DEVICEARRIVAL device event when a device or piece of media has been inserted and becomes available.
        /// </summary>
        internal const int DBT_DEVICEARRIVAL = 0x8000;
        /// <summary>
        /// The system broadcasts the DBT_DEVICEREMOVECOMPLETE device event when a device or piece of media has been physically removed.
        /// </summary>
        internal const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

        /// <summary>
        /// Retrieves a volume GUID path for the volume that is associated with the specified volume mount point (drive letter, volume GUID path, or mounted folder).
        /// </summary>
        /// <param name="volumeName">A pointer to a string that contains the path of a mounted folder (for example, Y:\MountX\) or a drive letter (for example, X:\).
        /// The string must end with a trailing backslash ('\').</param>
        /// <param name="uniqueVolumeName">A pointer to a string that receives the volume GUID path.
        /// This path is of the form "\\?\Volume{GUID}\" where GUID is a GUID that identifies the volume. If there is more than one volume GUID path for the volume,
        /// only the first one in the mount manager's cache is returned.</param>
        /// <param name="uniqueNameBufferCapacity">The length of the output buffer, in TCHARs. A reasonable size for the buffer to accommodate the largest possible volume GUID
        /// path is 50 characters.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetVolumeNameForVolumeMountPoint(
            string volumeName,
            StringBuilder uniqueVolumeName,
            int uniqueNameBufferCapacity);

        private NativeMethods()
        {
        }
    }
}
