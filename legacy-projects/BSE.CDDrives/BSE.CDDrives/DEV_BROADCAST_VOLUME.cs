using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BSE.CDDrives
{
    /// <summary>
    /// Contains information about a logical volume.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DEV_BROADCAST_VOLUME
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public uint dbcv_size;
        /// <summary>
        /// Set to <see cref="DeviceType"/> DBT_DEVTYP_VOLUME.
        /// </summary>
        public DeviceType dbcv_devicetype;
        /// <summary>
        /// Reserved; do not use.
        /// </summary>
        uint dbcv_reserved;
        /// <summary>
        /// The logical unit mask identifying one or more logical units. Each bit in the mask corresponds to
        /// one logical drive. Bit 0 represents drive A, bit 1 represents drive B, and so on.
        /// </summary>
        uint dbcv_unitmask;
        public char[] Drives
        {
            get
            {
                string drvs = "";
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    if ((dbcv_unitmask & (1 << (c - 'A'))) != 0)
                    {
                        drvs += c;
                    }
                }
                return drvs.ToCharArray();
            }
        }
        /// <summary>
        /// Set to <see cref="VolumeChangeFlags"/>.
        /// </summary>
        public VolumeChangeFlags dbcv_flags;
    }
}
