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
using System.Runtime.InteropServices;
using System.Globalization;
using BSE.Platten.Ripper.Properties;
using System.Security.Permissions;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Ripper.Lame
{
    /// <summary>
    /// Zusammendfassende Beschreibung für CLame.
    /// </summary>
    public static class LameEncDll
    {
        //#region Constants

        ////Error codes
        //[SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        //[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        //public const uint BE_ERR_SUCCESSFUL = 0;
        //[SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        //[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        //public const uint BE_ERR_INVALID_FORMAT = 1;
        //[SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        //[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        //public const uint BE_ERR_INVALID_FORMAT_PARAMETERS = 2;
        //[SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        //[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        //public const uint BE_ERR_NO_MORE_HANDLES = 3;
        //[SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        //[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        //public const uint BE_ERR_INVALID_HANDLE = 4;

        //#endregion

        //#region MethodsPublic
        //[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //[SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        //[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        //public static uint EncodeChunk(IntPtr hbeStream, byte[] buffer, int index, uint nBytes, byte[] pOutput, ref uint pdwOutput)
        //{
        //    uint res;
        //    GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        //    try
        //    {
        //        IntPtr ptr = handle.AddrOfPinnedObject() + index;
        //        res = NativeMethods.beEncodeChunk(hbeStream, nBytes / 2/*Samples*/, ptr, pOutput, ref pdwOutput);
        //        //res = NativeMethods.beEncodeChunk(hbeStream, nBytes / 2/*Samples*/, ptr, pOutput, ref pdwOutput);
        //    }
        //    finally
        //    {
        //        handle.Free();
        //    }
        //    return res;
        //}
        //[SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        //[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        //[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        //public static uint EncodeChunk(IntPtr hbeStream, byte[] buffer, byte[] pOutput, ref uint pdwOutput)
        //{
        //    if (buffer == null)
        //    {
        //        throw new ArgumentNullException(
        //            string.Format(
        //            CultureInfo.InvariantCulture,
        //            Resources.IDS_ArgumentNullException, "buffer"));
        //    }
        //    return EncodeChunk(hbeStream, buffer, 0, (uint)buffer.Length, pOutput, ref pdwOutput);
        //}

        //#endregion

        #region MethodsPrivate
        internal static class NativeMethods
        {
            ///// <summary>
            ///// This function is the first to call before starting an encoding stream.
            ///// </summary>
            ///// <param name="pbeConfig">Encoder settings</param>
            ///// <param name="dwSamples">Receives the number of samples (not bytes, each sample is a SHORT) to send to each beEncodeChunk() on return.</param>
            ///// <param name="dwBufferSize">Receives the minimun number of bytes that must have the output(result) buffer</param>
            ///// <param name="phbeStream">Receives the stream handle on return</param>
            ///// <returns>On success: BE_ERR_SUCCESSFUL</returns>
            //[DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern uint beInitStream(BeConfiguration pbeConfig, ref uint dwSamples, ref uint dwBufferSize, ref IntPtr phbeStream);
            ///// <summary>
            ///// Encodes a chunk of samples. Please note that if you have set the output to 
            ///// generate mono MP3 files you must feed beEncodeChunk() with mono samples
            ///// </summary>
            ///// <param name="hbeStream">Handle of the stream.</param>
            ///// <param name="nSamples">Number of samples to be encoded for this call. 
            ///// This should be identical to what is returned by beInitStream(), 
            ///// unless you are encoding the last chunk, which might be smaller.</param>
            ///// <param name="pSamples">Pointer at the 16-bit signed samples to be encoded. 
            ///// InPtr is used to pass any type of array without need of make memory copy, 
            ///// then gaining in performance. Note that nSamples is not the number of bytes,
            ///// but samples (is sample is a SHORT)</param>
            ///// <param name="pOutput">Buffer where to write the encoded data. 
            ///// This buffer should be at least of the minimum size returned by beInitStream().</param>
            ///// <param name="pdwOutput">Returns the number of bytes of encoded data written. 
            ///// The amount of data written might vary from chunk to chunk</param>
            ///// <returns>On success: BE_ERR_SUCCESSFUL</returns>
            //[DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern uint beEncodeChunk(IntPtr hbeStream, uint nSamples, IntPtr pSamples, [In, Out] byte[] pOutput, ref uint pdwOutput);
            ///// <summary>
            ///// Encodes a chunk of samples. Please note that if you have set the output to 
            ///// generate mono MP3 files you must feed beEncodeChunk() with mono samples
            ///// </summary>
            ///// <param name="hbeStream">Handle of the stream.</param>
            ///// <param name="nSamples">Number of samples to be encoded for this call. 
            ///// This should be identical to what is returned by beInitStream(), 
            ///// unless you are encoding the last chunk, which might be smaller.</param>
            ///// <param name="pInSamples">Array of 16-bit signed samples to be encoded. 
            ///// These should be in stereo when encoding a stereo MP3 
            ///// and mono when encoding a mono MP3</param>
            ///// <param name="pOutput">Buffer where to write the encoded data. 
            ///// This buffer should be at least of the minimum size returned by beInitStream().</param>
            ///// <param name="pdwOutput">Returns the number of bytes of encoded data written. 
            ///// The amount of data written might vary from chunk to chunk</param>
            ///// <returns>On success: BE_ERR_SUCCESSFUL</returns>
            ////[DllImport("Lame_enc.dll")]
            ////[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            ////public static extern uint beEncodeChunk(uint hbeStream, uint nSamples, short[] pInSamples, [In, Out] byte[] pOutput, ref uint pdwOutput);
            ///// <summary>
            ///// This function should be called after encoding the last chunk in order to flush 
            ///// the encoder. It writes any encoded data that still might be left inside the 
            ///// encoder to the output buffer. This function should NOT be called unless 
            ///// you have encoded all of the chunks in your stream.
            ///// </summary>
            ///// <param name="hbeStream">Handle of the stream.</param>
            ///// <param name="pOutput">Where to write the encoded data. This buffer should be 
            ///// at least of the minimum size returned by beInitStream().</param>
            ///// <param name="pdwOutput">Returns number of bytes of encoded data written.</param>
            ///// <returns>On success: BE_ERR_SUCCESSFUL</returns>
            //[DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern uint beDeinitStream(IntPtr hbeStream, [In, Out] byte[] pOutput, ref uint pdwOutput);
            ///// <summary>
            ///// Last function to be called when finished encoding a stream. 
            ///// Should unlike beDeinitStream() also be called if the encoding is canceled.
            ///// </summary>
            ///// <param name="hbeStream">Handle of the stream.</param>
            ///// <returns>On success: BE_ERR_SUCCESSFUL</returns>
            //[DllImport("Lame_enc.dll", CallingConvention = CallingConvention.Cdecl)]
            //public static extern uint beCloseStream(IntPtr hbeStream);
            ///// <summary>
            ///// Returns information like version numbers (both of the DLL and encoding engine), 
            ///// release date and URL for lame_enc's homepage. 
            ///// All this information should be made available to the user of your product 
            ///// through a dialog box or something similar.
            ///// </summary>
            ///// <param name="pbeVersion"Where version number, release date and URL for homepage 
            ///// is returned.</param>
            //[DllImport("Lame_enc.dll", CharSet = CharSet.Ansi)]
            //public static extern void beVersion([Out] BeVersion pbeVersion);
            //[DllImport("Lame_enc.dll", CharSet = CharSet.Unicode)]
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            //public static extern void beWriteVBRHeader(string pszMP3FileName);
            //[DllImport("Lame_enc.dll")]
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            //public static extern uint beEncodeChunkFloatS16NI(uint hbeStream, uint nSamples, [In] float[] buffer_l, [In] float[] buffer_r, [In, Out] byte[] pOutput, ref uint pdwOutput);
            //[DllImport("Lame_enc.dll")]
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            //public static extern uint beFlushNoGap(uint hbeStream, [In, Out] byte[] pOutput, ref uint pdwOutput);
            //[DllImport("Lame_enc.dll", CharSet = CharSet.Unicode)]
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
            //public static extern uint beWriteInfoTag(uint hbeStream, string lpszFileName);

            // Create a new LAME encoder instance
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr lame_init();

            // Set input sample rate
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int lame_set_in_samplerate(IntPtr lame, int value);

            /*
		      mode = 0,1,2,3 = stereo, jstereo, dual channel (not supported), mono
		      default: lame picks based on compression ration and input channels
		    */
            // int CDECL lame_set_mode(lame_global_flags *, MPEG_mode);
            // MPEG_mode CDECL lame_get_mode(const lame_global_flags *);
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int lame_set_mode(IntPtr context, MPEGMode value);

            // Set number of channels
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int lame_set_num_channels(IntPtr lame, int value);

            // Set output bitrate
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int lame_set_brate(IntPtr lame, int value);

            // Initialize parameters
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int lame_init_params(IntPtr lame);

            // Encode PCM samples to MP3
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int lame_encode_buffer_interleaved(
                IntPtr lame,
                [In] short[] pcm,
                int num_samples,
                [Out] byte[] mp3buf,
                int mp3buf_size);

            // Flush internal buffers
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int lame_encode_flush(
                IntPtr lame,
                [Out] byte[] mp3buf,
                int mp3buf_size);

            // Close and free the encoder
            [DllImport("libmp3lame.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void lame_close(IntPtr lame);

        }
        #endregion
    }
}
