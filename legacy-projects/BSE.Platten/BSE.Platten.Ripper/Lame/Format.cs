using BSE.Platten.Ripper.AudioWriters;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Explicit), Serializable]
    public class Format
    {
        [FieldOffset(0)]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public LHV1 LHV1;

        public Format(WaveFormat format, int mpegBitrate)
        {
            this.LHV1 = new LHV1(format, mpegBitrate);
        }
    }
}
