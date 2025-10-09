using System;
using System.Collections.Generic;
using System.Text;

using BSE.Platten.Common;
using BSE.Platten.Ripper.Lame;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Ripper
{
    /// <summary>
    /// Contains the setting properties of the MP3ConfigurationData class.
    /// </summary>
    public class MP3ConfigurationData : IConfigurationData
    {
        #region FieldsPrivate

        private uint m_iBitRateMpeg1 = 192;
        private bool m_bOriginalBit = true;
        private MpegMode m_eMpegMode = MpegMode.Stereo;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the BitrateMpeg1.
        /// </summary>
        public uint BitrateMpeg1
        {
            get { return this.m_iBitRateMpeg1; }
            set { this.m_iBitRateMpeg1 = value; }
        }
        /// <summary>
        /// Gets or sets the CopyrightBit.
        /// </summary>
        public bool CopyrightBit
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the CRCChecksum.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public bool CRCChecksum
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the OriginalBit.
        /// </summary>
        public bool OriginalBit
        {
            get { return this.m_bOriginalBit; }
            set { this.m_bOriginalBit = value; }
        }
        /// <summary>
        /// Gets or sets the OriginalBit.
        /// </summary>
        public bool PrivateBit
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the MpegMode.
        /// </summary>
        public MpegMode MpegMode
        {
            get { return this.m_eMpegMode; }
            set { this.m_eMpegMode = value; }
        }
        #endregion
    }
}
