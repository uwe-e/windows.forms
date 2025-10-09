using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BSE.CDDrives
{
    /// <summary>
    /// Serves as a standard header for information related to a device event reported through the
    /// WM_DEVICECHANGE message.
    /// 
    /// The members of the <see cref="DEV_BROADCAST_HDR"/> structure are contained in each device
    /// management structure. To determine which structure you have received through
    /// WM_DEVICECHANGE, treat the structure as a <see cref="DEV_BROADCAST_HDR"/> structure and check
    /// its <see cref="DeviceType"/> member.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DEV_BROADCAST_HDR
    {
        /// <summary>
        /// The size of this structure, in bytes. 
        /// </summary>
        public uint dbch_size;
        /// <summary>
        /// The <see cref="DeviceType"/>, which determines the event-specific information that follows the first three members.
        /// </summary>
        public DeviceType dbch_devicetype;
        /// <summary>
        /// DBT_DEVTYP_DEVNODE
        /// </summary>
        uint dbch_reserved;
    }
}
