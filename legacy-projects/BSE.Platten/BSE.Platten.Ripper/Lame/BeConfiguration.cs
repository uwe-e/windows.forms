using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using BSE.Platten.Ripper.AudioWriters;

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Sequential), Serializable]
    public class BeConfiguration
    {
        #region Events
        #endregion

        #region Constants
        // encoding formats
		/// <summary>
		/// 
		/// </summary>
        public const uint BeConfigurationLame = 256;
        #endregion

        #region Properties
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
        #endregion

        #region MethodsPublic
        public BeConfiguration(WaveFormat format, uint mpegBitrate)
		{
			this.Config = BeConfigurationLame;
			this.Format = new Format(format, mpegBitrate);
		}
        public BeConfiguration(WaveFormat format)
            : this(format, 128)
		{
		}
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        #endregion

        

		

		
    }
}
