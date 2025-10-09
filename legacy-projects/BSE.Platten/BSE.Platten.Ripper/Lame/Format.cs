using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BSE.Platten.Ripper.AudioWriters;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Explicit), Serializable]
    public class Format
    {
        #region FieldsPublic
        [FieldOffset(0)]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public LHV1 LHV1;
        #endregion

        #region MethodsPublic
        public Format(WaveFormat format, uint mpegBitrate)
        {
            this.LHV1 = new LHV1(format, mpegBitrate);
        }
        #endregion
    }
}
