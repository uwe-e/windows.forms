//Widows Media Format Functions
//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
//
//  Email:  yetiicb@hotmail.com
//
//  Copyright (C) 2002-2004 Idael Cardoso. 
//

using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio.WMFSDK
{
    /// <summary>
    /// Helper class that define the Windows Media Format Functions and constants
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public sealed class WMFSDKFunctions
    {
        #region Constants
        /// <summary>
        /// Constant for the Error Code NS_E_NO_MORE_SAMPLES.
        /// There are no more samples in the current range.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const int NS_E_NO_MORE_SAMPLES = unchecked((int)0xC00D0BCF);
        /// <summary>
        /// Constant for the Error Code ASF_E_NOTFOUND.
        /// The object was not found.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const int ASF_E_NOTFOUND = unchecked((int)0xC00D07F0);
        /// <summary>
        /// Constant for the Duration attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDuration = "Duration";
        /// <summary>
        /// Constant for the Bitrate attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMBitrate = "Bitrate";
        /// <summary>
        /// Constant for the Seekable attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMSeekable = "Seekable";
        /// <summary>
        /// Constant for the Stridable attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMStridable = "Stridable";
        /// <summary>
        /// Constant for the Broadcast attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMBroadcast = "Broadcast";
        /// <summary>
        /// Constant for the Is_Protected attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMProtected = "Is_Protected";
        /// <summary>
        /// Constant for the Is_Trusted attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMTrusted = "Is_Trusted";
        /// <summary>
        /// Constant for the Signature_Name attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMSignature_Name = "Signature_Name";
        /// <summary>
        /// Constant for the HasAudio attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasAudio = "HasAudio";
        /// <summary>
        /// Constant for the HasImage attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasImage = "HasImage";
        /// <summary>
        /// Constant for the HasScript attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasScript = "HasScript";
        /// <summary>
        /// Constant for the HasVideo attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasVideo = "HasVideo";
        /// <summary>
        /// Constant for the CurrentBitrate attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMCurrentBitrate = "CurrentBitrate";
        /// <summary>
        /// Constant for the OptimalBitrate attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMOptimalBitrate = "OptimalBitrate";
        /// <summary>
        /// Constant for the HasAttachedImages attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasAttachedImages = "HasAttachedImages";
        /// <summary>
        /// Constant for the Can_Skip_Backward attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMSkipBackward = "Can_Skip_Backward";
        /// <summary>
        /// Constant for the Can_Skip_Forward attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMSkipForward = "Can_Skip_Forward";
        /// <summary>
        /// Constant for the NumberOfFrames attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMNumberOfFrames = "NumberOfFrames";
        /// <summary>
        /// Constant for the FileSize attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMFileSize = "FileSize";
        /// <summary>
        /// Constant for the HasArbitraryDataStream attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasArbitraryDataStream = "HasArbitraryDataStream";
        /// <summary>
        /// Constant for the HasFileTransferStream attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMHasFileTransferStream = "HasFileTransferStream";
        /// <summary>
        /// Constant for the WM/ContainerFormat attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMContainerFormat = "WM/ContainerFormat";
        /// <summary>
        /// Constant for the Title attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMTitle = "Title";
        /// <summary>
        /// Constant for the Author attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAuthor = "Author";
        /// <summary>
        /// Constant for the Description attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDescription = "Description";
        /// <summary>
        /// Constant for the Rating attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMRating = "Rating";
        /// <summary>
        /// Constant for the Copyright attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMCopyright = "Copyright";
        /// <summary>
        /// Constant for the Use_DRM attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMUse_DRM = "Use_DRM";
        /// <summary>
        /// Constant for the DRM_Flags attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        public const string g_wszWMDRM_Flags = "DRM_Flags";
        /// <summary>
        /// Constant for the DRM_Level attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_Level = "DRM_Level";
        /// <summary>
        /// Constant for the Use_Advanced_DRM attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMUse_Advanced_DRM = "Use_Advanced_DRM";
        /// <summary>
        /// Constant for the DRM_KeySeed attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_KeySeed = "DRM_KeySeed";
        /// <summary>
        /// Constant for the DRM_KeyID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_KeyID = "DRM_KeyID";
        /// <summary>
        /// Constant for the DRM_ContentID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_ContentID = "DRM_ContentID";
        /// <summary>
        /// Constant for the DRM_IndividualizedVersion attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_IndividualizedVersion = "DRM_IndividualizedVersion";
        /// <summary>
        /// Constant for the DRM_LicenseAcqURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_LicenseAcqURL = "DRM_LicenseAcqURL";
        /// <summary>
        /// Constant for the DRM_V1LicenseAcqURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_V1LicenseAcqURL = "DRM_V1LicenseAcqURL";
        /// <summary>
        /// Constant for the DRM_HeaderSignPrivKey attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_HeaderSignPrivKey = "DRM_HeaderSignPrivKey";
        /// <summary>
        /// Constant for the DRM_LASignaturePrivKey attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_LASignaturePrivKey = "DRM_LASignaturePrivKey";
        /// <summary>
        /// Constant for the DRM_LASignatureCert attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_LASignatureCert = "DRM_LASignatureCert";
        /// <summary>
        /// Constant for the DRM_LASignatureLicSrvCert attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_LASignatureLicSrvCert = "DRM_LASignatureLicSrvCert";
        /// <summary>
        /// Constant for the DRM_LASignatureRootCert attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM_LASignatureRootCert = "DRM_LASignatureRootCert";
        /// <summary>
        /// Constant for the WM/AlbumTitle attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAlbumTitle = "WM/AlbumTitle";
        /// <summary>
        /// Constant for the WM/Track attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMTrack = "WM/Track";
        /// <summary>
        /// Constant for the WM/PromotionURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMPromotionURL = "WM/PromotionURL";
        /// <summary>
        /// Constant for the WM/AlbumCoverURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAlbumCoverURL = "WM/AlbumCoverURL";
        /// <summary>
        /// Constant for the WM/Genre attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMGenre = "WM/Genre";
        /// <summary>
        /// Constant for the WM/Year attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMYear = "WM/Year";
        /// <summary>
        /// Constant for the WM/GenreID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMGenreID = "WM/GenreID";
        /// <summary>
        /// Constant for the WM/MCDI attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMMCDI = "WM/MCDI";
        /// <summary>
        /// Constant for the WM/Composer attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMComposer = "WM/Composer";
        /// <summary>
        /// Constant for the WM/Lyrics attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMLyrics = "WM/Lyrics";
        /// <summary>
        /// Constant for the WM/TrackNumber attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMTrackNumber = "WM/TrackNumber";
        /// <summary>
        /// Constant for the WM/ToolName attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMToolName = "WM/ToolName";
        /// <summary>
        /// Constant for the WM/ToolVersion attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMToolVersion = "WM/ToolVersion";
        /// <summary>
        /// Constant for the IsVBR attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMIsVBR = "IsVBR";
        /// <summary>
        /// Constant for the WM/AlbumArtist attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAlbumArtist = "WM/AlbumArtist";
        /// <summary>
        /// Constant for the BannerImageType attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMBannerImageType = "BannerImageType";
        /// <summary>
        /// Constant for the BannerImageData attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMBannerImageData = "BannerImageData";
        /// <summary>
        /// Constant for the BannerImageURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMBannerImageURL = "BannerImageURL";
        /// <summary>
        /// Constant for the CopyrightURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMCopyrightURL = "CopyrightURL";
        /// <summary>
        /// Constant for the AspectRatioX attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAspectRatioX = "AspectRatioX";
        /// <summary>
        /// Constant for the AspectRatioY attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAspectRatioY = "AspectRatioY";
        /// <summary>
        /// Constant for the ASFLeakyBucketPairs attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszASFLeakyBucketPairs = "ASFLeakyBucketPairs";
        /// <summary>
        /// Constant for the NSC_Name attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMNSCName = "NSC_Name";
        /// <summary>
        /// Constant for the NSC_Address attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMNSCAddress = "NSC_Address";
        /// <summary>
        /// Constant for the NSC_Phone attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMNSCPhone = "NSC_Phone";
        /// <summary>
        /// Constant for the NSC_Email attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMNSCEmail = "NSC_Email";
        /// <summary>
        /// Constant for the NSC_Description attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMNSCDescription = "NSC_Description";
        /// <summary>
        /// Constant for the WM/Writer attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWriter = "WM/Writer";
        /// <summary>
        /// Constant for the WM/Conductor attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMConductor = "WM/Conductor";
        /// <summary>
        /// Constant for the WM/Producer attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMProducer = "WM/Producer";
        /// <summary>
        /// Constant for the WM/Director attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDirector = "WM/Director";
        /// <summary>
        /// Constant for the WM/ContentGroupDescription attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMContentGroupDescription = "WM/ContentGroupDescription";
        /// <summary>
        /// Constant for the WM/SubTitle attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMSubTitle = "WM/SubTitle";
        /// <summary>
        /// Constant for the WM/PartOfSet attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMPartOfSet = "WM/PartOfSet";
        /// <summary>
        /// Constant for the WM/ProtectionType attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMProtectionType = "WM/ProtectionType";
        /// <summary>
        /// Constant for the WM/VideoHeight attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMVideoHeight = "WM/VideoHeight";
        /// <summary>
        /// Constant for the WM/VideoWidth attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMVideoWidth = "WM/VideoWidth";
        /// <summary>
        /// Constant for the WM/VideoFrameRate attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMVideoFrameRate = "WM/VideoFrameRate";
        /// <summary>
        /// Constant for the WM/MediaClassPrimaryID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMMediaClassPrimaryID = "WM/MediaClassPrimaryID";
        /// <summary>
        /// Constant for the WM/MediaClassSecondaryID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMMediaClassSecondaryID = "WM/MediaClassSecondaryID";
        /// <summary>
        /// Constant for the WM/Period attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMPeriod = "WM/Period";
        /// <summary>
        /// Constant for the WM/Category attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMCategory = "WM/Category";
        /// <summary>
        /// Constant for the WM/Picture attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMPicture = "WM/Picture";
        /// <summary>
        /// Constant for the WM/Lyrics_Synchronised attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMLyrics_Synchronised = "WM/Lyrics_Synchronised";
        /// <summary>
        /// Constant for the WM/OriginalLyricist attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMOriginalLyricist = "WM/OriginalLyricist";
        /// <summary>
        /// Constant for the WM/OriginalArtist attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMOriginalArtist = "WM/OriginalArtist";
        /// <summary>
        /// Constant for the WM/OriginalAlbumTitle attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMOriginalAlbumTitle = "WM/OriginalAlbumTitle";
        /// <summary>
        /// Constant for the WM/OriginalReleaseYear attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMOriginalReleaseYear = "WM/OriginalReleaseYear";
        /// <summary>
        /// Constant for the WM/OriginalFilename attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMOriginalFilename = "WM/OriginalFilename";
        /// <summary>
        /// Constant for the WM/Publisher attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMPublisher = "WM/Publisher";
        /// <summary>
        /// Constant for the WM/EncodedBy attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMEncodedBy = "WM/EncodedBy";
        /// <summary>
        /// Constant for the WM/EncodingSettings attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMEncodingSettings = "WM/EncodingSettings";
        /// <summary>
        /// Constant for the WM/EncodingTime attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMEncodingTime = "WM/EncodingTime";
        /// <summary>
        /// Constant for the WM/AuthorURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAuthorURL = "WM/AuthorURL";
        /// <summary>
        /// Constant for the WM/UserWebURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMUserWebURL = "WM/UserWebURL";
        /// <summary>
        /// Constant for the WM/AudioFileURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAudioFileURL = "WM/AudioFileURL";
        /// <summary>
        /// Constant for the WM/AudioSourceURL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMAudioSourceURL = "WM/AudioSourceURL";
        /// <summary>
        /// Constant for the WM/Language attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMLanguage = "WM/Language";
        /// <summary>
        /// Constant for the WM/ParentalRating attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMParentalRating = "WM/ParentalRating";
        /// <summary>
        /// Constant for the WM/BeatsPerMinute attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMBeatsPerMinute = "WM/BeatsPerMinute";
        /// <summary>
        /// Constant for the WM/InitialKey attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMInitialKey = "WM/InitialKey";
        /// <summary>
        /// Constant for the WM/Mood attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMMood = "WM/Mood";
        /// <summary>
        /// Constant for the WM/Text attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMText = "WM/Text";
        /// <summary>
        /// Constant for the WM/DVDID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDVDID = "WM/DVDID";
        /// <summary>
        /// Constant for the WM/WMContentID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMContentID = "WM/WMContentID";
        /// <summary>
        /// Constant for the WM/WMCollectionID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMCollectionID = "WM/WMCollectionID";
        /// <summary>
        /// Constant for the WM/WMCollectionGroupID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMCollectionGroupID = "WM/WMCollectionGroupID";
        /// <summary>
        /// Constant for the WM/UniqueFileIdentifier attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMUniqueFileIdentifier = "WM/UniqueFileIdentifier";
        /// <summary>
        /// Constant for the WM/ModifiedBy attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMModifiedBy = "WM/ModifiedBy";
        /// <summary>
        /// Constant for the WM/RadioStationName attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMRadioStationName = "WM/RadioStationName";
        /// <summary>
        /// Constant for the WM/RadioStationOwner attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMRadioStationOwner = "WM/RadioStationOwner";
        /// <summary>
        /// Constant for the WM/PlaylistDelay attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMPlaylistDelay = "WM/PlaylistDelay";
        /// <summary>
        /// Constant for the WM/Codec attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMCodec = "WM/Codec";
        /// <summary>
        /// Constant for the WM/DRM attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMDRM = "WM/DRM";
        /// <summary>
        /// Constant for the WM/ISRC attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMISRC = "WM/ISRC";
        /// <summary>
        /// Constant for the WM/Provider attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMProvider = "WM/Provider";
        /// <summary>
        /// Constant for the WM/ProviderRating attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMProviderRating = "WM/ProviderRating";
        /// <summary>
        /// Constant for the WM/ProviderStyle attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMProviderStyle = "WM/ProviderStyle";
        /// <summary>
        /// Constant for the WM/ContentDistributor attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMContentDistributor = "WM/ContentDistributor";
        /// <summary>
        /// Constant for the WM/SubscriptionContentID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMSubscriptionContentID = "WM/SubscriptionContentID";
        /// <summary>
        /// Constant for the WM/WMADRCPeakReference attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMADRCPeakReference = "WM/WMADRCPeakReference";
        /// <summary>
        /// Constant for the WM/WMADRCPeakTarget attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMADRCPeakTarget = "WM/WMADRCPeakTarget";
        /// <summary>
        /// Constant for the WM/WMADRCAverageReference attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMADRCAverageReference = "WM/WMADRCAverageReference";
        /// <summary>
        /// Constant for the WM/WMADRCAverageTarget attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWMWMADRCAverageTarget = "WM/WMADRCAverageTarget";
        /// <summary>
        /// Constant for the EarlyDataDelivery attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszEarlyDataDelivery = "EarlyDataDelivery";
        /// <summary>
        /// Constant for the JustInTimeDecode attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszJustInTimeDecode = "JustInTimeDecode";
        /// <summary>
        /// Constant for the SingleOutputBuffer attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSingleOutputBuffer = "SingleOutputBuffer";
        /// <summary>
        /// Constant for the SoftwareScaling attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSoftwareScaling = "SoftwareScaling";
        /// <summary>
        /// Constant for the DeliverOnReceive attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszDeliverOnReceive = "DeliverOnReceive";
        /// <summary>
        /// Constant for the ScrambledAudio attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszScrambledAudio = "ScrambledAudio";
        /// <summary>
        /// Constant for the DedicatedDeliveryThread attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszDedicatedDeliveryThread = "DedicatedDeliveryThread";
        /// <summary>
        /// Constant for the EnableDiscreteOutput attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszEnableDiscreteOutput = "EnableDiscreteOutput";
        /// <summary>
        /// Constant for the SpeakerConfig attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSpeakerConfig = "SpeakerConfig";
        /// <summary>
        /// Constant for the DynamicRangeControl attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszDynamicRangeControl = "DynamicRangeControl";
        /// <summary>
        /// Constant for the AllowInterlacedOutput attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszAllowInterlacedOutput = "AllowInterlacedOutput";
        /// <summary>
        /// Constant for the VideoSampleDurations attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszVideoSampleDurations = "VideoSampleDurations";
        /// <summary>
        /// Constant for the StreamLanguage attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszStreamLanguage = "StreamLanguage";
        /// <summary>
        /// Constant for the DeinterlaceMode attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszDeinterlaceMode = "DeinterlaceMode";
        /// <summary>
        /// Constant for the InitialPatternForInverseTelecine attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszInitialPatternForInverseTelecine = "InitialPatternForInverseTelecine";
        /// <summary>
        /// Constant for the JPEGCompressionQuality attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszJPEGCompressionQuality = "JPEGCompressionQuality";
        /// <summary>
        /// Constant for the WatermarkCLSID attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWatermarkCLSID = "WatermarkCLSID";
        /// <summary>
        /// Constant for the WatermarkConfig attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszWatermarkConfig = "WatermarkConfig";
        /// <summary>
        /// Constant for the InterlacedCoding attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszInterlacedCoding = "InterlacedCoding";
        /// <summary>
        /// Constant for the FixedFrameRate attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszFixedFrameRate = "FixedFrameRate";
        /// <summary>
        /// Constant for the _SOURCEFORMATTAG attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszOriginalSourceFormatTag = "_SOURCEFORMATTAG";
        /// <summary>
        /// Constant for the _ORIGINALWAVEFORMAT attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszOriginalWaveFormat = "_ORIGINALWAVEFORMAT";
        /// <summary>
        /// Constant for the _EDL attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszEDL = "_EDL";
        /// <summary>
        /// Constant for the _COMPLEXITYEX attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszComplexity = "_COMPLEXITYEX";
        /// <summary>
        /// Constant for the _DECODERCOMPLEXITYPROFILE attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszDecoderComplexityRequested = "_DECODERCOMPLEXITYPROFILE";
        /// <summary>
        /// Constant for the ReloadIndexOnSeek attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszReloadIndexOnSeek = "ReloadIndexOnSeek";
        /// <summary>
        /// Constant for the StreamNumIndexObjects attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszStreamNumIndexObjects = "StreamNumIndexObjects";
        /// <summary>
        /// Constant for the FailSeekOnError attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszFailSeekOnError = "FailSeekOnError";
        /// <summary>
        /// Constant for the PermitSeeksBeyondEndOfStream attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszPermitSeeksBeyondEndOfStream = "PermitSeeksBeyondEndOfStream";
        /// <summary>
        /// Constant for the UsePacketAtSeekPoint attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszUsePacketAtSeekPoint = "UsePacketAtSeekPoint";
        /// <summary>
        /// Constant for the SourceBufferTime attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSourceBufferTime = "SourceBufferTime";
        /// <summary>
        /// Constant for the SourceMaxBytesAtOnce attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSourceMaxBytesAtOnce = "SourceMaxBytesAtOnce";
        /// <summary>
        /// Constant for the _VBRENABLED attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszVBREnabled = "_VBRENABLED";
        /// <summary>
        /// Constant for the _VBRQUALITY attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszVBRQuality = "_VBRQUALITY";
        /// <summary>
        /// Constant for the _RMAX attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszVBRBitrateMax = "_RMAX";
        /// <summary>
        /// Constant for the _BMAX attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszVBRBufferWindowMax = "_BMAX";
        /// <summary>
        /// Constant for the VBR Peak attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszVBRPeak = "VBR Peak";
        /// <summary>
        /// Constant for the Buffer Average attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszBufferAverage = "Buffer Average";
        /// <summary>
        /// Constant for the _COMPLEXITYEXMAX attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszComplexityMax = "_COMPLEXITYEXMAX";
        /// <summary>
        /// Constant for the _COMPLEXITYEXOFFLINE attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszComplexityOffline = "_COMPLEXITYEXOFFLINE";
        /// <summary>
        /// Constant for the _COMPLEXITYEXLIVE attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszComplexityLive = "_COMPLEXITYEXLIVE";
        /// <summary>
        /// Constant for the _ISVBRSUPPORTED attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszIsVBRSupported = "_ISVBRSUPPORTED";
        /// <summary>
        /// Constant for the _PASSESUSED attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszNumPasses = "_PASSESUSED";
        /// <summary>
        /// Constant for the MusicSpeechClassMode attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszMusicSpeechClassMode = "MusicSpeechClassMode";
        /// <summary>
        /// Constant for the MusicClassMode attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszMusicClassMode = "MusicClassMode";
        /// <summary>
        /// Constant for the SpeechClassMode attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSpeechClassMode = "SpeechClassMode";
        /// <summary>
        /// Constant for the MixedClassMode attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszMixedClassMode = "MixedClassMode";
        /// <summary>
        /// Constant for the SpeechFormatCap attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszSpeechCaps = "SpeechFormatCap";
        /// <summary>
        /// Constant for the PeakValue attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszPeakValue = "PeakValue";
        /// <summary>
        /// Constant for the AverageLevel attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszAverageLevel = "AverageLevel";
        /// <summary>
        /// Constant for the Fold6To2Channels3 attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszFold6To2Channels3 = "Fold6To2Channels3";
        /// <summary>
        /// Constant for the Fold%luTo%luChannels%lu attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszFoldToChannelsTemplate = "Fold%luTo%luChannels%lu";
        /// <summary>
        /// Constant for the DeviceConformanceTemplate attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszDeviceConformanceTemplate = "DeviceConformanceTemplate";
        /// <summary>
        /// Constant for the EnableFrameInterpolation attribute.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public const string g_wszEnableFrameInterpolation = "EnableFrameInterpolation";
        #endregion

        #region FieldsPrivate
        private static IWMProfileManager m_ProfileManager;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Wraps the WMWMCreateReader function
        /// </summary>
        /// <param name="Rights">Indicates the desired operation. See WMF SDK documentation</param>
        /// <returns>The reader object</returns>
        public static IWMReader CreateReader(WMT_RIGHTS rights)
        {
            IWMReader res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateReader(IntPtr.Zero, rights, out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateSyncReader fucntion
        /// </summary>
        /// <param name="Rights">Indicates the desired operation. See WMF SDK documentation</param>
        /// <returns>The reader object</returns>
        public static IWMSyncReader CreateSyncReader(WMT_RIGHTS rights)
        {
            IWMSyncReader res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateSyncReader(IntPtr.Zero, rights, out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateProfileManger function
        /// </summary>
        /// <returns>The profile manager object</returns>
        public static IWMProfileManager CreateProfileManager()
        {
            IWMProfileManager res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateProfileManager(out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateEditor function
        /// </summary>
        /// <returns>The meta editor object</returns>
        public static IWMMetadataEditor CreateEditor()
        {
            IWMMetadataEditor res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateEditor(out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateIndexer function
        /// </summary>
        /// <returns>The indexer object</returns>
        public static IWMIndexer CreateIndexer()
        {
            IWMIndexer res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateIndexer(out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateWriter function
        /// </summary>
        /// <returns>The writer object</returns>
        public static IWMWriter CreateWriter()
        {
            IWMWriter res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateWriter(IntPtr.Zero, out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateWriterFileSink function
        /// </summary>
        /// <returns>The file sink object</returns>
        public static IWMWriterFileSink CreateWriterFileSink()
        {
            IWMWriterFileSink res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateWriterFileSink(out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateWriterNetworkSink function
        /// </summary>
        /// <returns>The network sink object</returns>
        public static IWMWriterNetworkSink CreateWriterNetworkSink()
        {
            IWMWriterNetworkSink res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateWriterNetworkSink(out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMCreateWriterPushSink function
        /// </summary>
        /// <returns>The writer push sink object</returns>
        public static IWMWriterPushSink CreateWriterPushSink()
        {
            IWMWriterPushSink res = null;
            Marshal.ThrowExceptionForHR(NativeMethods.WMCreateWriterPushSink(out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMIsAvailableOffline function
        /// </summary>
        /// <param name="URL">URL to be checked</param>
        /// <param name="Language">Wide-character null-terminated string containing the 
        /// RFC 1766-compliant language ID specifying which language is desired for playback.
        /// See the WMF SDK for details.</param>
        /// <returns>True if URL can be played offline, False otherwise.</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public static bool IsAvailableOffline(string url, string language)
        {
            bool res = false;
            Marshal.ThrowExceptionForHR(NativeMethods.WMIsAvailableOffline(url, language, out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMIsContentProtected function
        /// </summary>
        /// <param name="FileName">Name of the file to check</param>
        /// <returns>True if it is protected, False otherwise.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public static bool IsContentProtected(string FileName)
        {
            bool res = false;
            Marshal.ThrowExceptionForHR(NativeMethods.WMIsContentProtected(FileName, out res));
            return res;
        }
        /// <summary>
        /// Wraps the WMValidateData. 
        /// Raise a CComException if data don't represent a valid ASF content
        /// </summary>
        /// <param name="data">Buffer to check. The minimun buffer size is returned by 
        /// <see cref="Yeti.WMFSdk.WM.ValidateDataMinBuffSize"/>
        /// must be the beggining of the ASF stream</param>
        public static void ValidateData(byte[] data)
        {
            uint DataSize = (uint)data.Length;
            Marshal.ThrowExceptionForHR(NativeMethods.WMValidateData(data, ref DataSize));
        }
        /// <summary>
        /// Minimum buffer size to pass to <see cref="Yeti.WMFSdk.WM.ValidateData"/>
        /// </summary>
        public static uint ValidateDataMinBuffSize
        {
            get
            {
                uint DataSize = 0;
                Marshal.ThrowExceptionForHR(NativeMethods.WMValidateData(null, ref DataSize));
                return DataSize;
            }
        }
        /// <summary>
        /// Wraps the WMCheckURLExtension
        /// </summary>
        /// <param name="url">URL or file name to chekc</param>
        /// <returns>True if the specified fyle type can be opened by WMF objects. False otherwise</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public static bool CheckURLExtension(string url)
        {
            return NativeMethods.WMCheckURLExtension(url) == 0; //S_OK;
        }
        /// <summary>
        /// Wraps the WMCheckURLScheme functions. Examines a network protocol 
        /// and compares it to an internal list of commonly used schemes.
        /// </summary>
        /// <param name="urlScheme">URL to check</param>
        /// <returns>True is it is a valid protocol scheme. False otherwise</returns>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        public static bool CheckURLScheme(string urlScheme)
        {
            return NativeMethods.WMCheckURLScheme(urlScheme) == 0;
        }
        /// <summary>
        /// Static profile manager object. Use this property instead of calling
        /// <see cref="Yeti.WMFSdk.WM.CreateProfileManger"/> because creating and 
        /// realeasing profile managers can impact the performance.
        /// </summary>
        public static IWMProfileManager ProfileManager
        {
            get
            {
                if (m_ProfileManager == null)
                {
                    m_ProfileManager = CreateProfileManager();
                    IWMProfileManager2 pm2 = (IWMProfileManager2)m_ProfileManager;
                    pm2.SetSystemProfileVersion(WMT_VERSION.WMT_VER_9_0);
                }
                return m_ProfileManager;
            }
        }
        #endregion

        #region MethodsPrivate
        private WMFSDKFunctions() { }

        internal static class NativeMethods
        {
            [DllImport("WMVCore.dll", EntryPoint = "WMCreateReader", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateReader(IntPtr pUnkReserved,
                                                      WMT_RIGHTS dwRights,
                                                      [Out, MarshalAs(UnmanagedType.Interface)] out IWMReader ppReader);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateSyncReader", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateSyncReader(IntPtr pUnkCert,
                                                         WMT_RIGHTS dwRights,
                                                         [Out, MarshalAs(UnmanagedType.Interface)] out IWMSyncReader ppSyncReader);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateSyncReader", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateProfileManager([Out, MarshalAs(UnmanagedType.Interface)] out IWMProfileManager ppProfileManager);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateEditor", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateEditor(
                [Out, MarshalAs(UnmanagedType.Interface)] out IWMMetadataEditor ppEditor);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateIndexer", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateIndexer([Out, MarshalAs(UnmanagedType.Interface)] out IWMIndexer ppIndexer);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateWriter", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateWriter(IntPtr pUnkReserved, [Out, MarshalAs(UnmanagedType.Interface)] out IWMWriter ppWriter);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateWriterFileSink", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateWriterFileSink([Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterFileSink ppSink);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateWriterNetworkSink", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateWriterNetworkSink([Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterNetworkSink ppSink);

            [DllImport("WMVCore.dll", EntryPoint = "WMCreateWriterPushSink", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCreateWriterPushSink([Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterPushSink ppSink);

            [DllImport("WMVCore.dll", EntryPoint = "WMIsAvailableOffline", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMIsAvailableOffline([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
                                                           [In, MarshalAs(UnmanagedType.LPWStr)] string pwszLanguage,
                                                           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsAvailableOffline);

            [DllImport("WMVCore.dll", EntryPoint = "WMIsContentProtected", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMIsContentProtected([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
                                                           [Out, MarshalAs(UnmanagedType.Bool)] out bool pfIsProtected);

            [DllImport("WMVCore.dll", EntryPoint = "WMValidateData", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMValidateData([In, MarshalAs(UnmanagedType.LPArray)] byte[] pbData,
                                                     [In, Out] ref uint pdwDataSize);

            [DllImport("WMVCore.dll", EntryPoint = "WMCheckURLExtension", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCheckURLExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL);

            [DllImport("WMVCore.dll", EntryPoint = "WMCheckURLScheme", SetLastError = true,
               CharSet = CharSet.Unicode, ExactSpelling = true,
               CallingConvention = CallingConvention.StdCall)]
            internal static extern int WMCheckURLScheme([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURLScheme);
        }

        #endregion
    }
}
