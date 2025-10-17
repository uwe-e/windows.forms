using BSE.Platten.Ripper.AudioWriters;
using System;
using System.Runtime.InteropServices;

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Sequential), Serializable]
    public class BeConfiguration
    {
        // encoding formats
		/// <summary>
		/// 
		/// </summary>
        public const uint BeConfigurationLame = 256;

        public uint Config
        {
            get;
            set;
        }
        
        public Format Format
        {
            get;
            set;
        }

        public BeConfiguration(WaveFormat format, int mpegBitrate)
		{
			this.Config = BeConfigurationLame;
			this.Format = new Format(format, mpegBitrate);
		}
        public BeConfiguration(WaveFormat format)
            : this(format, 128)
		{
		}
		
    }
}
