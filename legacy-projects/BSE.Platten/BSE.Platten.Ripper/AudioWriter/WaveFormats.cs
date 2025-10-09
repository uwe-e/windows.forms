using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Ripper.AudioWriters
{
    /// <summary>
    /// Enumeration of the <see cref="WaveFormats"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1717:OnlyFlagsEnumsShouldHavePluralNames")]
    public enum WaveFormats
    {
        /// <summary>
        /// WaveFormats None
        /// </summary>
        None = 0,
        /// <summary>
        /// WaveFormats Pcm
        /// </summary>
        Pcm = 1,
        /// <summary>
        /// WaveFormats Float
        /// </summary>
        Float = 3
    }
}
