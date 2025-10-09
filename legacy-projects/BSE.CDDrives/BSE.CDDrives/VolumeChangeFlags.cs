using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.CDDrives
{
    /// <summary>
    /// 
    /// </summary>
    internal enum VolumeChangeFlags : ushort
    {
        /// <summary>
        /// Change affects media in drive. If not set, change affects physical device or drive.
        /// </summary>
        DBTF_MEDIA = 0x0001,
        /// <summary>
        /// Indicated logical volume is a network volume.
        /// </summary>
        DBTF_NET = 0x0002
    }
}
