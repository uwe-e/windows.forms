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

namespace BSE.Platten.Ripper.Lame
{
    /// <summary>
    /// Enumeration of the MPEG modes
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum MpegMode : uint
    {
        /// <summary>
        /// MpegMode Stereo
        /// </summary>
        Stereo = 0,
        /// <summary>
        /// MpegMode JointStereo
        /// </summary>
        JointStereo,
        /// <summary>
        /// MpegMode DualChannel
        /// </summary>
        /// <remarks>LAME doesn't supports this!</remarks>
        DualChannel,
        /// <summary>
        /// MpegMode Mono
        /// </summary>
        Mono,
        /// <summary>
        /// MpegMode NotSet
        /// </summary>
        NotSet,
        /// <summary>
        /// MpegMode MaxIndicator
        /// </summary>
        /// <remarks>Don't use this! It's used for sanity checks.</remarks>
        MaxIndicator
    }
}
