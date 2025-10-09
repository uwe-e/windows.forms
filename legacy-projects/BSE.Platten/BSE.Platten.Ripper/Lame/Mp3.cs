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

namespace BSE.Platten.Ripper.Lame
{
    [StructLayout(LayoutKind.Sequential), Serializable]
    public struct MP3
    {
        #region Properties
        /// <summary>
        /// Gets or sets the SampleRate.
        /// </summary>
        /// <remarks>The values 48000, 44100 and 32000 are allowed.</remarks>
        public uint SampleRate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Mode.
        /// </summary>
        /// <remarks>The values BE_MP3_MODE_STEREO, BE_MP3_MODE_DUALCHANNEL, BE_MP3_MODE_MONO.</remarks>
        public byte Mode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Bitrate.
        /// </summary>
        /// <remarks>The values 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256 and 320 are allowed.</remarks>
        public ushort Bitrate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Private.
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
        /// Gets or sets the Copyright.
        /// </summary>
        public int Copyright
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Original.
        /// </summary>
        public int Original
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Specifies whether this <see cref="MP3"/> contains the same properties as the specified Object.
        /// </summary>
        /// <param name="obj">The Object to test.</param>
        /// <returns><b>true</b> if obj is a <see cref="MP3"/> and has the same properties as this <see cref="MP3"/>.</returns>
        public override bool Equals(object obj)
        {
            if ((obj is MP3) == false)
            {
                return false;
            }
            return Equals((MP3)obj);
        }
        /// <summary>
        /// Specifies whether this <see cref="MP3"/> contains the same properties as the specified Object.
        /// </summary>
        /// <param name="mp3">The <see cref="MP3"/> struct to test.</param>
        /// <returns><b>true</b> if obj is a <see cref="MP3"/> and has the same properties as this <see cref="MP3"/>.</returns>
        public bool Equals(MP3 mp3)
        {
            if (this.Bitrate.Equals(mp3.Bitrate) == false)
            {
                return false;
            }
            if (this.Copyright.Equals(mp3.Copyright) == false)
            {
                return false;
            }
            if (this.CRC.Equals(mp3.CRC) == false)
            {
                return false;
            }
            if (this.Mode.Equals(mp3.Mode) == false)
            {
                return false;
            }
            if (this.Original.Equals(mp3.Original) == false)
            {
                return false;
            }
            if (this.Private.Equals(mp3.Private) == false)
            {
                return false;
            }
            if (this.SampleRate.Equals(mp3.SampleRate) == false)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks for equality between two <see cref="MP3"/> structs.
        /// </summary>
        /// <param name="mp31">The first <see cref="MP3"/> struct to test.</param>
        /// <param name="mp32">The second <see cref="MP3"/> struct to test.</param>
        /// <returns><b>true</b> if the <see cref="MP3"/>s are equal; <b>false</b> if <see cref="MP3"/>s are not equal.</returns>
        public static bool operator ==(MP3 mp31, MP3 mp32)
        {
            return mp31.Equals(mp32);
        }
        /// <summary>
        /// Checks for inequality between two <see cref="MP3"/> structs.
        /// </summary>
        /// <param name="mp31">The first <see cref="MP3"/> struct to test.</param>
        /// <param name="mp32">The second <see cref="MP3"/> struct to test.</param>
        /// <returns><b>true</b> if the <see cref="MP3"/>s are not equal; <b>false</b> if <see cref="MP3"/>s are equal.</returns>
        public static bool operator !=(MP3 mp31, MP3 mp32)
        {
            return !mp31.Equals(mp32);
        }
        /// <summary>
        /// Returns a hash code for this <see cref="MP3"/>.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="MP3"/>.</returns>
        public override int GetHashCode()
        {
            return this.Bitrate ^ this.Copyright ^ this.CRC ^ this.Original ^ this.Private;
        }  
        #endregion

        #region MethodsProtected
        #endregion
        
    }
}
