using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.CDDrives
{
    /// <summary>
    /// The device type, which determines the event-specific information that follows the first
    /// three members. This member can be one of the following values.
    /// </summary>
    internal enum DeviceType : uint
    {
        /// <summary>
        /// OEM- or IHV-defined device type. 
        /// </summary>
        DBT_DEVTYP_OEM = 0x00000000,
        /// <summary>
        /// devnode number (specific to Windows 95)
        /// </summary>
        DBT_DEVTYP_DEVNODE = 0x00000001,
        /// <summary>
        /// Logical volume.
        /// </summary>
        DBT_DEVTYP_VOLUME = 0x00000002,
        /// <summary>
        /// Port device (serial or parallel).
        /// </summary>
        DBT_DEVTYP_PORT = 0x00000003,     // serial, parallel
        /// <summary>
        /// network resource (UNC)
        /// </summary>
        DBT_DEVTYP_NET = 0x00000004
    }
}
