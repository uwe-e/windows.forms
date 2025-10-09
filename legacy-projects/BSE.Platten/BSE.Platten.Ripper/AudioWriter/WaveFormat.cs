//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  This material may not be duplicated in whole or in part, except for 
//  personal use, without the express written consent of the author. 
//
//  Email:  ianier@hotmail.com
//
//  Copyright (C) 1999-2003 Ianier Munoz. All Rights Reserved.

using System;
using System.Runtime.InteropServices;

namespace BSE.Platten.Ripper.AudioWriters
{
    [StructLayout(LayoutKind.Sequential)] 
    public class WaveFormat
    {
        #region Properties
        /// <summary>
        /// Gets or sets the FormatTag.
        /// </summary>
        public short FormatTag
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Channels.
        /// </summary>
        public short Channels
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the SamplesPerSec.
        /// </summary>
        public int SamplesPerSec
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the AvgBytesPerSec.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public int AvgBytesPerSec
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the BlockAlign.
        /// </summary>
        public short BlockAlign
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the BitsPerSample.
        /// </summary>
        public short BitsPerSample
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Size.
        /// </summary>
        public short Size
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="WaveFormat"/> class.
        /// </summary>
        /// <param name="samplesPerSec">The samplesPerSec.</param>
        /// <param name="bitsPerSample">The bitsPerSample.</param>
        /// <param name="channels">The channels</param>
        public WaveFormat(int samplesPerSec, int bitsPerSample, int channels)
        {
            this.FormatTag = (short)WaveFormats.Pcm;
            this.Channels = (short)channels;
            this.SamplesPerSec = samplesPerSec;
            this.BitsPerSample = (short)bitsPerSample;
            this.BlockAlign = (short)(channels * (bitsPerSample / 8));
            this.AvgBytesPerSec = SamplesPerSec * BlockAlign;
        }
        #endregion
    }
}
