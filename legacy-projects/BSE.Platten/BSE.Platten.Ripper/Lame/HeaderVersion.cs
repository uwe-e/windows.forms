//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
//
//  Email:  yetiicb@hotmail.com
//
//  Copyright (C) 2002-2003 Idael Cardoso. 
//  
//  LAME ( LAME Ain't an Mp3 Encoder ) 
//  You must call the fucntion "beVersion" to obtain information  like version 
//  numbers (both of the DLL and encoding engine), release date and URL for 
//  lame_enc's homepage. All this information should be made available to the 
//  user of your product through a dialog box or something similar.
//  You must see all information about LAME project and legal license infos at 
//  http://www.mp3dev.org/  The official LAME site
//
//
//  About Thomson and/or Fraunhofer patents:
//  Any use of this product does not convey a license under the relevant 
//  intellectual property of Thomson and/or Fraunhofer Gesellschaft nor imply 
//  any right to use this product in any finished end user or ready-to-use final 
//  product. An independent license for such use is required. 
//  For details, please visit http://www.mp3licensing.com.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using BSE.Platten.Ripper.Properties;
using System.Security.Permissions;
using BSE.Platten.Ripper.AudioWriters;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Sequential, Size = 327), Serializable]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public struct LHV1 // BE_CONFIG_LAME LAME header version 1
    {
        #region Events
        #endregion

        #region Constants
        public const uint Mpeg1 = 1;
        public const uint Mpeg2 = 0;
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        
        #region STRUCTURE INFORMATION
        /// <summary>
        /// Gets or sets the StructVersion.
        /// </summary>
        public uint StructVersion
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the StructSize.
        /// </summary>
        public uint StructSize
        {
            get;
            set;
        }
        #endregion
        
        #region BASIC ENCODER SETTINGS
        /// <summary>
        /// Gets or sets the SampleRate of the input file
        /// </summary>
        public uint SampleRate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the downsamplerate. 0=ENCODER DECIDES
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public uint ReSamplerate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="MpegMode"/> mode
        /// </summary>
        public MpegMode Mode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the VBR min bitrate.
        /// </summary>
        public uint Bitrate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the VBR max bitrate.
        /// </summary>
        public uint MaxBitrate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="LameQualityPreset"/> preset.
        /// </summary>
        public LameQualityPreset Preset
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the MpegVersion.
        /// </summary>
        /// <remarks>MPEG-1 OR MPEG-2</remarks>
        public uint MpegVersion
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the PsyModel.
        /// </summary>
        /// <remarks>The is for future use. Set the value to 0.</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public uint PsyModel
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Emphasis.
        /// </summary>
        /// <remarks>The is for future use. Set the value to 0.</remarks>
        public uint Emphasis
        {
            get;
            set;
        }
        #endregion

        #region BIT STREAM SETTINGS
        /// <summary>
        /// Gets or sets the private bit.
        /// </summary>
        public int Private
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the CRC.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public int CRC
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the copyright bit.
        /// </summary>
        public int Copyright
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the original bit.
        /// </summary>
        public int Original
        {
            get;
            set;
        }
        #endregion
        
        #region VBR STUFF
        /// <summary>
        /// Gets or sets an information whether the XING VBR HEADER should be written.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public int WriteVBRHeader
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets an information whether the VBR ENCODING should be used.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public int EnableVBR
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets VBR quality.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public int VBRQuality
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets an information whether ABR should be used in stead VBRQuality.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public uint VBRAbrBps
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="VBRMethod"/> enumeration value.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public VBRMethod VBRMethod
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets an information whether the Bit resorvoir should be disabled.
        /// </summary>
        public int NoRes
        {
            get;
            set;
        }
        #endregion

        #region MISC SETTINGS
        /// <summary>
        /// Gets or sets an information whether the strict ISO encoding rules should be used.
        /// </summary>
        public int UseStrictIso
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the quality settings.
        /// </summary>
        /// <remarks>HIGH BYTE should be NOT LOW byte, otherwhise quality=5</remarks>
        public ushort Quality
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="LHV1"/> class.
        /// </summary>
        /// <param name="format">The <see cref="WaveFormat"/> object.</param>
        /// <param name="mpegBitrate">The mpegBitrate value.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public LHV1(WaveFormat format, uint mpegBitrate) : this()
        {
            if (format == null)
            {
                throw new ArgumentNullException(
                    string.Format(CultureInfo.InvariantCulture, Resources.IDS_ArgumentNullException, "format"));
            }
            if (format.FormatTag != (short)WaveFormats.Pcm)
            {
                throw new ArgumentOutOfRangeException("format", "Only PCM format supported");
            }
            if (format.BitsPerSample != 16)
            {
                throw new ArgumentOutOfRangeException("format", "Only 16 bits samples supported");
            }
            this.StructVersion = 1;
            StructSize = (uint)Marshal.SizeOf(typeof(BeConfiguration));
            SetMpegVersion(format);
            this.SampleRate = (uint)format.SamplesPerSec;				// INPUT FREQUENCY
            this.ReSamplerate = 0;					// DON'T RESAMPLE
            SetMpegMode(format);
            CheckMpegVersion(mpegBitrate, this.MpegVersion);
            this.Bitrate = mpegBitrate;								// MINIMUM BIT RATE
            this.Preset = LameQualityPreset.NormalQuality;      	// QUALITY PRESET SETTING
            this.PsyModel = 0;										// USE DEFAULT PSYCHOACOUSTIC MODEL 
            this.Emphasis = 0;										// NO EMPHASIS TURNED ON
            this.Original = 1;										// SET ORIGINAL FLAG
            this.WriteVBRHeader = 0;
            this.NoRes = 0;											// No Bit resorvoir
            this.Copyright = 0;
            this.CRC = 0;
            this.EnableVBR = 0;
            this.Private = 0;
            this.UseStrictIso = 0;
            this.MaxBitrate = 0;
            this.VBRAbrBps = 0;
            this.Quality = 0;
            this.VBRMethod = VBRMethod.None;
            this.VBRQuality = 0;
        }
        /// <summary>
        /// Specifies whether this <see cref="LHV1"/> contains the same properties as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns><b>true</b> if obj is a <see cref="LHV1"/> and has the same properties as this <see cref="LHV1"/>.</returns>
        public override bool Equals(object obj)
        {
            if ((obj is LHV1) == false)
            {
                return false;
            }
            return Equals((LHV1)obj);
        }
        /// <summary>
        /// Specifies whether this <see cref="LHV1"/> contains the same properties as the specified Object.
        /// </summary>
        /// <param name="lhv">The <see cref="LHV1"/> struct to test.</param>
        /// <returns><b>true</b> if obj is a <see cref="LHV1"/> and has the same properties as this <see cref="LHV1"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public bool Equals(LHV1 lhv)
        {
            if (this.StructVersion.Equals(lhv.StructVersion) == false)
            {
                return false;
            }
            if (this.StructSize.Equals(lhv.StructSize) == false)
            {
                return false;
            }
            if (this.SampleRate.Equals(lhv.SampleRate) == false)
            {
                return false;
            }
            if (this.ReSamplerate.Equals(lhv.ReSamplerate) == false)
            {
                return false;
            }
            if (this.Mode.Equals(lhv.Mode) == false)
            {
                return false;
            }
            if (this.Bitrate.Equals(lhv.Bitrate) == false)
            {
                return false;
            }
            if (this.MaxBitrate.Equals(lhv.MaxBitrate) == false)
            {
                return false;
            }
            if (this.Preset.Equals(lhv.Preset) == false)
            {
                return false;
            }
            if (this.MpegVersion.Equals(lhv.MpegVersion) == false)
            {
                return false;
            }
            if (this.PsyModel.Equals(lhv.PsyModel) == false)
            {
                return false;
            }
            if (this.Emphasis.Equals(lhv.Emphasis) == false)
            {
                return false;
            }
            if (this.Private.Equals(lhv.Private) == false)
            {
                return false;
            }
            if (this.CRC.Equals(lhv.CRC) == false)
            {
                return false;
            }
            if (this.Copyright.Equals(lhv.Copyright) == false)
            {
                return false;
            }
            if (this.Original.Equals(lhv.Original) == false)
            {
                return false;
            }
            if (this.WriteVBRHeader.Equals(lhv.WriteVBRHeader) == false)
            {
                return false;
            }
            if (this.EnableVBR.Equals(lhv.EnableVBR) == false)
            {
                return false;
            }
            if (this.VBRQuality.Equals(lhv.VBRQuality) == false)
            {
                return false;
            }
            if (this.VBRAbrBps.Equals(lhv.VBRAbrBps) == false)
            {
                return false;
            }
            if (this.VBRMethod.Equals(lhv.VBRMethod) == false)
            {
                return false;
            }
            if (this.NoRes.Equals(lhv.NoRes) == false)
            {
                return false;
            }
            if (this.UseStrictIso.Equals(lhv.UseStrictIso) == false)
            {
                return false;
            }
            if (this.Quality.Equals(lhv.Quality) == false)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks for equality between two <see cref="LHV1"/> structs.
        /// </summary>
        /// <param name="mp31">The first <see cref="LHV1"/> struct to test.</param>
        /// <param name="mp32">The second <see cref="LHV1"/> struct to test.</param>
        /// <returns><b>true</b> if the <see cref="LHV1"/>s are equal; <b>false</b> if <see cref="LHV1"/>s are not equal.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static bool operator ==(LHV1 lhv1, LHV1 lhv2)
        {
            return lhv1.Equals(lhv2);
        }
        /// <summary>
        /// Checks for inequality between two <see cref="LHV1"/> structs.
        /// </summary>
        /// <param name="lhv1">The first <see cref="LHV1"/> struct to test.</param>
        /// <param name="lhv2">The second <see cref="LHV1"/> struct to test.</param>
        /// <returns><b>true</b> if the <see cref="LHV1"/>s are not equal; <b>false</b> if <see cref="LHV1"/>s are equal.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public static bool operator !=(LHV1 lhv1, LHV1 lhv2)
        {
            return !lhv1.Equals(lhv2);
        }
        /// <summary>
        /// Returns a hash code for this <see cref="LHV1"/>.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="LHV1"/>.</returns>
        public override int GetHashCode()
        {
            return this.Private ^ this.CRC ^ this.Copyright ^ this.Original ^ this.WriteVBRHeader ^ this.EnableVBR ^ this.VBRQuality ^ this.NoRes ^ this.UseStrictIso;
        }  
        #endregion

        #region MethodsPrivate
        private void SetMpegVersion(WaveFormat format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(
                    string.Format(CultureInfo.InvariantCulture, Resources.IDS_ArgumentNullException, "format"));
            }
            switch (format.SamplesPerSec)
            {
                case 16000:
                case 22050:
                case 24000:
                    this.MpegVersion = Mpeg2;
                    break;
                case 32000:
                case 44100:
                case 48000:
                    this.MpegVersion = Mpeg1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("format", "Unsupported sample rate");
            }
        }
        private void SetMpegMode(WaveFormat format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(
                    string.Format(CultureInfo.InvariantCulture, Resources.IDS_ArgumentNullException, "format"));
            }
            switch (format.Channels)
            {
                case 1:
                    this.Mode = MpegMode.Mono;
                    break;
                case 2:
                    this.Mode = MpegMode.Stereo;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("format", "Invalid number of channels");
            }
        }
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        private static void CheckMpegVersion(uint mpegBitrate, uint mpegversion)
        {
            switch (mpegBitrate)
            {
                case 32:
                case 40:
                case 48:
                case 56:
                case 64:
                case 80:
                case 96:
                case 112:
                case 128:
                case 160: //Allowed bit rates in MPEG1 and MPEG2
                    break;
                case 192:
                case 224:
                case 256:
                case 320: //Allowed only in MPEG1
                    if (mpegversion != Mpeg1)
                    {
                        throw new ArgumentOutOfRangeException("mpegversion", "Bit rate not compatible with input format");
                    }
                    break;
                case 8:
                case 16:
                case 24:
                case 144: //Allowed only in MPEG2
                    if (mpegversion != Mpeg2)
                    {
                        throw new ArgumentOutOfRangeException("mpegversion", "Bit rate not compatible with input format");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mpegBitrate", "Unsupported bit rate");
            }
        }
        #endregion
    }
}
