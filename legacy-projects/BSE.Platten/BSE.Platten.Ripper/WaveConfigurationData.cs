using System;
using System.Collections.Generic;
using System.Text;

using BSE.Platten.Common;

namespace BSE.Platten.Ripper
{
    /// <summary>
    /// Contains the properties of the WaveConfigurationData class.
    /// </summary>
    public class WaveConfigurationData : IConfigurationData
    {
        #region FieldsPrivate

        private uint m_iBitRate = 44100;
        private int m_iBitsPerSample = 16;
        private int m_iChannels = 2;

        #endregion

        #region Properties

        public uint Bitrate
        {
            get { return this.m_iBitRate; }
            set { this.m_iBitRate = value; }
        }

        public int BitsPerSample
        {
            get { return this.m_iBitsPerSample; }
            set { this.m_iBitsPerSample = value; }
        }

        public int Channels
        {
            get { return this.m_iChannels; }
            set { this.m_iChannels = value; }
        }

        #endregion
    }
}
