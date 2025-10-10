// UsbEject version 1.0 March 2006
// written by Simon Mourier <email: simon [underscore] mourier [at] hotmail [dot] com>

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace BSE.RemovableDrives
{
	internal sealed class NativeMethods
	{
        // from winuser.h
        internal const int WM_DEVICECHANGE = 0x0219;
        internal const int DBT_DEVICEARRIVAL = 0x8000;
        internal const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

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
