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
    /// Enumearation of the Lame quality presets
    /// </summary>
    public enum LameQualityPreset : int
    {
        /// <summary>
        /// LameQualityPreset NoPreset
        /// </summary>
        NoPreset = -1,
        #region Quality Presets
        /// <summary>
        /// LameQualityPreset NormalQuality
        /// </summary>
        NormalQuality = 0,
        /// <summary>
        /// LameQualityPreset LowQuality
        /// </summary>
        LowQuality = 1,
        /// <summary>
        /// LameQualityPreset HighQuality
        /// </summary>
        HighQuality = 2,
        /// <summary>
        /// LameQualityPreset VoiceQuality
        /// </summary>
        VoiceQuality = 3,
        /// <summary>
        /// LameQualityPreset R3Mix
        /// </summary>
        R3Mix = 4,
        /// <summary>
        /// LameQualityPreset VeryHighQuality
        /// </summary>
        VeryHighQuality = 5,
        /// <summary>
        /// LameQualityPreset Standard
        /// </summary>
        Standard = 6,
        /// <summary>
        /// LameQualityPreset FastStandard
        /// </summary>
        FastStandard = 7,
        /// <summary>
        /// LameQualityPreset Extreme
        /// </summary>
        Extreme = 8,
        /// <summary>
        /// LameQualityPreset FastExtreme
        /// </summary>
        FastExtreme = 9,
        /// <summary>
        /// LameQualityPreset Insane
        /// </summary>
        Insane = 10,
        /// <summary>
        /// LameQualityPreset Abr
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        Abr = 11,
        /// <summary>
        /// LameQualityPreset Cbr
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        Cbr = 12,
        /// <summary>
        /// LameQualityPreset Medium
        /// </summary>
        Medium = 13,
        /// <summary>
        /// LameQualityPreset FastMedium
        /// </summary>
        FastMedium = 14,
        #endregion 
        #region New Preset Values
        /// <summary>
        /// LameQualityPreset Phone
        /// </summary>
        Phone = 1000,
        /// <summary>
        /// LameQualityPreset SW
        /// </summary>
        SW = 2000,
        /// <summary>
        /// LameQualityPreset AM
        /// </summary>
        AM = 3000,
        /// <summary>
        /// LameQualityPreset FM
        /// </summary>
        FM = 4000,
        /// <summary>
        /// LameQualityPreset Voice
        /// </summary>
        Voice = 5000,
        /// <summary>
        /// LameQualityPreset Radio
        /// </summary>
        Radio = 6000,
        /// <summary>
        /// LameQualityPreset Tape
        /// </summary>
        Tape = 7000,
        /// <summary>
        /// LameQualityPreset Hifi
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        Hifi = 8000,
        /// <summary>
        /// LameQualityPreset CD
        /// </summary>
        CD = 9000,
        /// <summary>
        /// LameQualityPreset Studio
        /// </summary>
        Studio = 10000
        #endregion
    }
}
