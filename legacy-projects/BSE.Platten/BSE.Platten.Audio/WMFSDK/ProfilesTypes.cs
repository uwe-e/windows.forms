//Widows Media Format Interfaces
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
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio.WMFSDK
{
    /// <summary>
    /// The IWMStreamConfig interface is the primary interface of a stream configuration object.
    /// It provides methods to configure basic properties for streams to be used in a profile.
    /// 
    /// Every profile contains one or more stream configuration objects. You can get the
    /// <see cref="IWMStreamConfig"/> interface of a stream configuration object by calling the
    /// IWMProfile.GetStream method or the IWMProfile.GetStreamByNumber method. The difference between these
    /// two methods is that GetStream retrieves the stream using an index ranging from zero to one less than
    /// the total stream count, and GetStreamByNumber retrieves the stream using the assigned stream number.
    /// You can also retrieve a stream configuration object using the IWMProfile.CreateNewStream method. 
    /// All of the methods that create stream configuration objects set a pointer to this interface.
    /// </summary>
    [ComImport]
    [Guid("96406BDC-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig
    {
        /// <summary>
        /// Retrieves the major type of the stream (audio, video, or script).
        /// </summary>
        /// <param name="pguidStreamType">Pointer to a GUID object specifying the major type of the stream.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreamType([Out] out Guid pguidStreamType);
        /// <summary>
        /// Retrieves the stream number.
        /// </summary>
        /// <param name="pwStreamNum">Pointer to a <b>WORD</b> containing the stream number.
        /// Stream numbers must be in the range of 1 through 63.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreamNumber([Out] out ushort pwStreamNum);
        /// <summary>
        /// Specifies the stream number.
        /// </summary>
        /// <param name="wStreamNum"><b>WORD</b> containing the stream number. Stream numbers must be in the range of 1 through 63.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetStreamNumber([In] ushort wStreamNum);
        /// <summary>
        /// Retrieves the stream name.
        /// </summary>
        /// <param name="pwszStreamName">Pointer to a wide-character null-terminated string containing the stream name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchStreamName">On input, a pointer to a variable containing the length of the pwszStreamName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains
        /// the actual length of the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreamName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszStreamName,
                           [In, Out] ref ushort pcchStreamName);
        /// <summary>
        /// Specifies the stream name.
        /// </summary>
        /// <param name="pwszStreamName">Pointer to a wide-character null-terminated string containing the stream name.
        /// Stream names are limited to 256 wide characters.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetStreamName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszStreamName);
        /// <summary>
        /// Retrieves the connection name given to the stream.
        /// </summary>
        /// <param name="pwszInputName">Pointer to a wide-character null-terminated string containing the input name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchInputName">On input, a pointer to a variable containing the length of the pwszInputName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains
        /// the length of the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszInputName,
                               [In, Out] ref ushort pcchInputName);
        /// <summary>
        /// Specifies the connection name given to a stream.
        /// </summary>
        /// <param name="pwszInputName">Pointer to a wide-character null-terminated string containing the input name.
        /// Connection names are limited to 256 wide characters.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetConnectionName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszInputName);
        /// <summary>
        /// Retrieves the bit rate for the stream.
        /// </summary>
        /// <param name="pdwBitrate">Pointer to a <b>DWORD</b> containing the bit rate, in bits per second.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetBitrate([Out] out uint pdwBitrate);
        /// <summary>
        /// Specifies the bit rate for the stream.
        /// </summary>
        /// <param name="pdwBitrate"><b>DWORD</b> containing the bit rate, in bits per second.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetBitrate([In] uint pdwBitrate);
        /// <summary>
        /// Retrieves the maximum latency between when a stream is received and when it begins to be displayed.
        /// </summary>
        /// <param name="pmsBufferWindow">Pointer to a variable specifying the buffer window, in milliseconds.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetBufferWindow([Out] out uint pmsBufferWindow);
        /// <summary>
        /// Specifies the maximum latency between when a stream is received and when it begins to be displayed.
        /// </summary>
        /// <param name="msBufferWindow">Buffer window, in milliseconds.</param>
        void SetBufferWindow([In] uint msBufferWindow);
    };
    /// <summary>
    /// The IWMStreamConfig2 interface manages the data unit extensions associated with a stream.
    /// 
    /// IWMStreamConfig2 inherits from <see cref="IWMStreamConfig"/>. To obtain a pointer to <see cref="IWMStreamConfig2"/>,
    /// call the QueryInterface method of the <see cref="IWMStreamConfig"/> interface.
    /// </summary>
    [ComImport]
    [Guid("7688D8CB-FC0D-43BD-9459-5A8DEC200CFA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig2 : IWMStreamConfig
    {
        /// <summary>
        /// Retrieves the major type of the stream (audio, video, or script).
        /// </summary>
        /// <param name="pguidStreamType">Pointer to a GUID object specifying the major type of the stream.</param>
        new void GetStreamType([Out] out Guid pguidStreamType);
        /// <summary>
        /// Retrieves the stream number.
        /// </summary>
        /// <param name="pwStreamNum">Pointer to a <b>WORD</b> containing the stream number.
        /// Stream numbers must be in the range of 1 through 63.</param>
        new void GetStreamNumber([Out] out ushort pwStreamNum);
        /// <summary>
        /// Specifies the stream number.
        /// </summary>
        /// <param name="wStreamNum"><b>WORD</b> containing the stream number. Stream numbers must be in the range of 1 through 63.</param>
        new void SetStreamNumber([In] ushort wStreamNum);
        /// <summary>
        /// Retrieves the stream name.
        /// </summary>
        /// <param name="pwszStreamName">Pointer to a wide-character null-terminated string containing the stream name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchStreamName">On input, a pointer to a variable containing the length of the pwszStreamName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains
        /// the actual length of the name, including the terminating null character.</param>
        new void GetStreamName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszStreamName,
         [In, Out] ref ushort pcchStreamName);
        /// <summary>
        /// Specifies the stream name.
        /// </summary>
        /// <param name="pwszStreamName">Pointer to a wide-character null-terminated string containing the stream name.
        /// Stream names are limited to 256 wide characters.</param>
        new void SetStreamName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszStreamName);
        /// <summary>
        /// Retrieves the connection name given to the stream.
        /// </summary>
        /// <param name="pwszInputName">Pointer to a wide-character null-terminated string containing the input name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchInputName">On input, a pointer to a variable containing the length of the pwszInputName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains
        /// the length of the name, including the terminating null character.</param>
        new void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszInputName,
         [In, Out] ref ushort pcchInputName);
        /// <summary>
        /// Specifies the connection name given to a stream.
        /// </summary>
        /// <param name="pwszInputName">Pointer to a wide-character null-terminated string containing the input name.
        /// Connection names are limited to 256 wide characters.</param>
        new void SetConnectionName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszInputName);
        /// <summary>
        /// Retrieves the bit rate for the stream.
        /// </summary>
        /// <param name="pdwBitrate">Pointer to a <b>DWORD</b> containing the bit rate, in bits per second.</param>
        new void GetBitrate([Out] out uint pdwBitrate);
        /// <summary>
        /// Specifies the bit rate for the stream.
        /// </summary>
        /// <param name="pdwBitrate"><b>DWORD</b> containing the bit rate, in bits per second.</param>
        new void SetBitrate([In] uint pdwBitrate);
        /// <summary>
        /// Retrieves the maximum latency between when a stream is received and when it begins to be displayed.
        /// </summary>
        /// <param name="pmsBufferWindow">Pointer to a variable specifying the buffer window, in milliseconds.</param>
        new void GetBufferWindow([Out] out uint pmsBufferWindow);
        /// <summary>
        /// Specifies the maximum latency between when a stream is received and when it begins to be displayed.
        /// </summary>
        /// <param name="msBufferWindow">Buffer window, in milliseconds.</param>
        new void SetBufferWindow([In] uint msBufferWindow);
        /// <summary>
        /// Retrieves the type of communication protocol.
        /// </summary>
        /// <param name="pnTransportType">Pointer to a variable that receives one member of the
        /// <b>WMT_TRANSPORT_TYPE</b> enumeration type.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetTransportType([Out] out WMT_TRANSPORT_TYPE pnTransportType);
        /// <summary>
        /// Sets the type of communication protocol.
        /// </summary>
        /// <param name="nTransportType">The SetTransportType method sets the type of data communication protocol
        /// (reliable or unreliable) used for the stream.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetTransportType([In] WMT_TRANSPORT_TYPE nTransportType);
        /// <summary>
        /// Adds a data unit extension to the stream.
        /// </summary>
        /// <param name="guidExtensionSystemID">A GUID that identifies the data unit extension system.
        /// This can be one of the predefined GUIDs listed in INSSBuffer3.SetProperty, or a GUID whose value
        /// is understood by a custom player application.</param>
        /// <param name="cbExtensionDataSize">Size, in bytes, of the data unit extensions that will be attached to the
        /// packets in the stream. Set to 0xFFFF to specify data unit extensions of variable size.
        /// Each individual data unit extension can then be set to any size ranging from 0 to 65534.</param>
        /// <param name="pbExtensionSystemInfo">Pointer to a byte buffer containing information about the data unit
        /// extension system. If you have no information, you can pass NULL. When passing NULL,
        /// cbExtensionSystemInfo must be zero.</param>
        /// <param name="cbExtensionSystemInfo">Count of bytes in the buffer at pbExtensionSystemInfo. If you have no
        /// data unit extension system information, you can pass zero. When passing zero, pbExtensionSystemInfo
        /// must be NULL.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        void AddDataUnitExtension([In] Guid guidExtensionSystemID,
                                  [In] ushort cbExtensionDataSize,
                                  [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbExtensionSystemInfo,
                                  [In] uint cbExtensionSystemInfo);
        /// <summary>
        /// Retrieves a count of all the data unit extensions in the stream.
        /// </summary>
        /// <param name="pcDataUnitExtensions">Pointer to a <b>WORD</b> that receives the count of data unit
        /// extensions.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetDataUnitExtensionCount([Out] out ushort pcDataUnitExtensions);
        /// <summary>
        /// Retrieves a data unit extension from the stream.
        /// </summary>
        /// <param name="wDataUnitExtensionNumber"><b>WORD</b> containing the data unit extension number.
        /// This number is assigned to a data unit extension system when it is added to the stream.</param>
        /// <param name="pguidExtensionSystemID">Pointer to a GUID that receives the identifier of the data unit
        /// extension system.</param>
        /// <param name="pcbExtensionDataSize">Pointer to the size, in bytes, of the data unit extensions that will
        /// be attached to the packets in the stream.</param>
        /// <param name="pbExtensionSystemInfo">Pointer to a byte buffer that receives information about the data
        /// unit extension system.</param>
        /// <param name="pcbExtensionSystemInfo">Pointer to the size, in bytes, of the data stored at
        /// pbExtensionSystemInfo.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void GetDataUnitExtension([In] uint wDataUnitExtensionNumber,
                                  [Out] out Guid pguidExtensionSystemID,
                                  [Out] out ushort pcbExtensionDataSize,
            /*[out, size_is( *pcbExtensionSystemInfo )]*/ IntPtr pbExtensionSystemInfo,
                                  [In, Out] ref uint pcbExtensionSystemInfo);
        /// <summary>
        /// Removes all previously added data unit extensions.
        /// </summary>
        void RemoveAllDataUnitExtensions();
    }
    /// <summary>
    /// The IWMStreamConfig3 interface controls language settings for a stream.
    /// 
    /// An IWMStreamConfig3 interface exists for every stream configuration object. You can obtain a pointer
    /// to an IWMStreamConfig3 interface by calling the QueryInterface method of any other interface of the
    /// stream configuration object.
    /// </summary>
    [ComImport]
    [Guid("CB164104-3AA9-45a7-9AC9-4DAEE131D6E1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamConfig3 : IWMStreamConfig2
    {
        /// <summary>
        /// Retrieves the major type of the stream (audio, video, or script).
        /// </summary>
        /// <param name="pguidStreamType">Pointer to a GUID object specifying the major type of the stream.</param>
        new void GetStreamType([Out] out Guid pguidStreamType);
        /// <summary>
        /// Retrieves the stream number.
        /// </summary>
        /// <param name="pwStreamNum">Pointer to a <b>WORD</b> containing the stream number.
        /// Stream numbers must be in the range of 1 through 63.</param>
        new void GetStreamNumber([Out] out ushort pwStreamNum);
        /// <summary>
        /// Specifies the stream number.
        /// </summary>
        /// <param name="wStreamNum"><b>WORD</b> containing the stream number. Stream numbers must be in the range of 1 through 63.</param>
        new void SetStreamNumber([In] ushort wStreamNum);
        /// <summary>
        /// Retrieves the stream name.
        /// </summary>
        /// <param name="pwszStreamName">Pointer to a wide-character null-terminated string containing the stream name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchStreamName">On input, a pointer to a variable containing the length of the pwszStreamName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains
        /// the actual length of the name, including the terminating null character.</param>
        new void GetStreamName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszStreamName,
         [In, Out] ref ushort pcchStreamName);
        /// <summary>
        /// Specifies the stream name.
        /// </summary>
        /// <param name="pwszStreamName">Pointer to a wide-character null-terminated string containing the stream name.
        /// Stream names are limited to 256 wide characters.</param>
        new void SetStreamName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszStreamName);
        /// <summary>
        /// Retrieves the connection name given to the stream.
        /// </summary>
        /// <param name="pwszInputName">Pointer to a wide-character null-terminated string containing the input name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchInputName">On input, a pointer to a variable containing the length of the pwszInputName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains
        /// the length of the name, including the terminating null character.</param>
        new void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszInputName,
         [In, Out] ref ushort pcchInputName);
        /// <summary>
        /// Specifies the connection name given to a stream.
        /// </summary>
        /// <param name="pwszInputName">Pointer to a wide-character null-terminated string containing the input name.
        /// Connection names are limited to 256 wide characters.</param>
        new void SetConnectionName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszInputName);
        /// <summary>
        /// Retrieves the bit rate for the stream.
        /// </summary>
        /// <param name="pdwBitrate">Pointer to a <b>DWORD</b> containing the bit rate, in bits per second.</param>
        new void GetBitrate([Out] out uint pdwBitrate);
        /// <summary>
        /// Specifies the bit rate for the stream.
        /// </summary>
        /// <param name="pdwBitrate"><b>DWORD</b> containing the bit rate, in bits per second.</param>
        new void SetBitrate([In] uint pdwBitrate);
        /// <summary>
        /// Retrieves the maximum latency between when a stream is received and when it begins to be displayed.
        /// </summary>
        /// <param name="pmsBufferWindow">Pointer to a variable specifying the buffer window, in milliseconds.</param>
        new void GetBufferWindow([Out] out uint pmsBufferWindow);
        /// <summary>
        /// Specifies the maximum latency between when a stream is received and when it begins to be displayed.
        /// </summary>
        /// <param name="msBufferWindow">Buffer window, in milliseconds.</param>
        new void SetBufferWindow([In] uint msBufferWindow);
        /// <summary>
        /// Retrieves the type of communication protocol.
        /// </summary>
        /// <param name="pnTransportType">Pointer to a variable that receives one member of the
        /// <b>WMT_TRANSPORT_TYPE</b> enumeration type.</param>
        new void GetTransportType([Out] out WMT_TRANSPORT_TYPE pnTransportType);
        /// <summary>
        /// Sets the type of communication protocol.
        /// </summary>
        /// <param name="nTransportType">The SetTransportType method sets the type of data communication protocol
        /// (reliable or unreliable) used for the stream.</param>
        new void SetTransportType([In] WMT_TRANSPORT_TYPE nTransportType);
        /// <summary>
        /// Adds a data unit extension to the stream.
        /// </summary>
        /// <param name="guidExtensionSystemID">A GUID that identifies the data unit extension system.
        /// This can be one of the predefined GUIDs listed in INSSBuffer3.SetProperty, or a GUID whose value
        /// is understood by a custom player application.</param>
        /// <param name="cbExtensionDataSize">Size, in bytes, of the data unit extensions that will be attached to the
        /// packets in the stream. Set to 0xFFFF to specify data unit extensions of variable size.
        /// Each individual data unit extension can then be set to any size ranging from 0 to 65534.</param>
        /// <param name="pbExtensionSystemInfo">Pointer to a byte buffer containing information about the data unit
        /// extension system. If you have no information, you can pass NULL. When passing NULL,
        /// cbExtensionSystemInfo must be zero.</param>
        /// <param name="cbExtensionSystemInfo">Count of bytes in the buffer at pbExtensionSystemInfo. If you have no
        /// data unit extension system information, you can pass zero. When passing zero, pbExtensionSystemInfo
        /// must be NULL.</param>
        new void AddDataUnitExtension([In] Guid guidExtensionSystemID,
          [In] ushort cbExtensionDataSize,
          [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbExtensionSystemInfo,
          [In] uint cbExtensionSystemInfo);
        /// <summary>
        /// Retrieves a count of all the data unit extensions in the stream.
        /// </summary>
        /// <param name="pcDataUnitExtensions">Pointer to a <b>WORD</b> that receives the count of data unit
        /// extensions.</param>
        new void GetDataUnitExtensionCount([Out] out ushort pcDataUnitExtensions);
        /// <summary>
        /// Retrieves a data unit extension from the stream.
        /// </summary>
        /// <param name="wDataUnitExtensionNumber"><b>WORD</b> containing the data unit extension number.
        /// This number is assigned to a data unit extension system when it is added to the stream.</param>
        /// <param name="pguidExtensionSystemID">Pointer to a GUID that receives the identifier of the data unit
        /// extension system.</param>
        /// <param name="pcbExtensionDataSize">Pointer to the size, in bytes, of the data unit extensions that will
        /// be attached to the packets in the stream.</param>
        /// <param name="pbExtensionSystemInfo">Pointer to a byte buffer that receives information about the data
        /// unit extension system.</param>
        /// <param name="pcbExtensionSystemInfo">Pointer to the size, in bytes, of the data stored at
        /// pbExtensionSystemInfo.</param>
        new void GetDataUnitExtension([In] uint wDataUnitExtensionNumber,
         [Out] out Guid pguidExtensionSystemID,
         [Out] out ushort pcbExtensionDataSize,
            /*[out, size_is( *pcbExtensionSystemInfo )]*/ IntPtr pbExtensionSystemInfo,
         [In, Out] ref uint pcbExtensionSystemInfo);
        /// <summary>
        /// Removes all previously added data unit extensions.
        /// </summary>
        new void RemoveAllDataUnitExtensions();
        /// <summary>
        /// Retrieves the language setting for the stream.
        /// </summary>
        /// <param name="pwszLanguageString">Pointer to a wide-character null-terminated string containing the language
        /// string. Pass NULL to retrieve the size of the string, which is returned
        /// in pcchLanguageStringLength.</param>
        /// <param name="pcchLanguageStringLength">Pointer to a <b>WORD</b> containing the size of the language
        /// string in wide characters. This size includes the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        void GetLanguage([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszLanguageString,
                         [In, Out] ref ushort pcchLanguageStringLength);
        /// <summary>
        /// Configures the language setting for the stream.
        /// </summary>
        /// <param name="pwszLanguageString">Pointer to a wide-character null-terminated string containing
        /// the language string.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string pwszLanguageString);
    }
    /// <summary>
    /// The IWMProfile interface is the primary interface for a profile object. A profile object is used to
    /// configure custom profiles. You can use IWMProfile to create, delete, or modify stream configuration
    /// objects and mutual exclusion objects. You can also set and retrieve general information about the profile.
    /// To access all the features of the profile object, you should use IWMProfile3, which inherits
    /// from IWMProfile and IWMProfile2.
    /// 
    /// IWMProfile is also accessible through the reader object, where you can use it to get information about
    /// the streams of a file that is loaded in the reader. When accessing IWMProfile from the reader, you can
    /// make changes to the profile, but none of the changes can be saved to the file. It is often handy to use
    /// the profile of an existing file as the foundation of a new profile. The synchronous reader supports
    /// IWMProfile in the same way as the reader.
    /// 
    /// The profile information obtained through the reader or synchronous reader does not come from a .prx file.
    /// The reader uses the information in the ASF file to assemble the stream configurations. Thus certain
    /// profile information, like the name and description, are not available through the reader.
    /// 
    /// There are several ways to obtain a pointer to an IWMProfile interface. The profile manager has methods
    /// to create a new profile and to access existing profiles. All of these methods set an IWMProfile pointer.
    /// When reading a file, a pointer to IWMProfile can be obtained by calling the QueryInterface method of 
    /// any reader interface. Likewise, any interface of the synchronous reader object can obtain a pointer with
    /// a call to QueryInterfaceIWMProfile3.
    /// </summary>
    [ComImport]
    [Guid("96406BDB-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile
    {
        /// <summary>
        /// Retrieves the version number of Microsoft Windows Media Services in the profile.
        /// </summary>
        /// <param name="pdwVersion">Pointer to a DWORD containing one member of the WMT_VERSION enumeration type.
        /// This value specifies the version of the Windows Media Format SDK that was used to create the profile.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetVersion([Out] out WMT_VERSION pdwVersion);
        /// <summary>
        /// Retrieves the name of the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchName">On input, specifies the length of the pwszName buffer. On output,
        /// if the method succeeds, specifies a pointer to the length of the name, including the terminating 
        /// null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                     [In, Out] ref uint pcchName);
        /// <summary>
        /// Specifies the name of the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Profile names are limited to 256 wide characters.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        /// <summary>
        /// Retrieves the description of the profile.
        /// </summary>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.
        /// Pass NULL to retrieve the required length for the description.</param>
        /// <param name="pcchDescription">On input, specifies the length of the pwszDescription string.
        /// On output, if the method succeeds, specifies a pointer to a count of the number of characters
        /// in the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
                            [In, Out] ref uint pcchDescription);
        /// <summary>
        /// Specifies the description of the profile.
        /// </summary>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.
        /// Profile descriptions are limited to 1024 wide characters.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription);
        /// <summary>
        /// Retrieves the number of streams in the profile.
        /// </summary>
        /// <param name="pcStreams">Pointer to a count of streams.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetStreamCount([Out] out uint pcStreams);
        /// <summary>
        /// Retrieves a stream, using an index number, from the profile.
        /// </summary>
        /// <param name="dwStreamIndex">DWORD containing the stream index.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the stream
        /// configuration object that describes the specified stream.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStream([In] uint dwStreamIndex, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Retrieves a stream, using the number of the stream, from the profile.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the stream configuration
        /// object that describes the specified stream.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreamByNumber([In] ushort wStreamNum, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Removes a stream from the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object
        /// that describes the stream you want to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Removes a stream from the profile.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveStreamByNumber([In] ushort wStreamNum);
        /// <summary>
        /// Adds a stream to the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object to
        /// be added to the profile. The stream must be configured by using the methods of the IWMStreamConfig
        /// interface before this method is used to add the stream to the profile.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Enables changes made to a stream configuration to be included in the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object
        /// for the stream you want to reconfigure.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void ReconfigStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Creates a stream configuration object for the profile.
        /// </summary>
        /// <param name="guidStreamType">GUID object specifying the major media type for the stream to be
        /// created (for example, WMMEDIATYPE_Video). The supported major types are listed in Media Types.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the created stream
        /// configuration object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        void CreateNewStream([In] ref Guid guidStreamType,
                             [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Retrieves the number of mutual exclusion objects in the profile.
        /// </summary>
        /// <param name="pcME">Pointer to a count of mutual exclusions.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetMutualExclusionCount([Out] out uint pcME);
        /// <summary>
        /// Retrieves a mutual exclusion object from the profile.
        /// </summary>
        /// <param name="dwMEIndex">DWORD containing the index of the mutual exclusion object.</param>
        /// <param name="ppME">Pointer to a pointer to the IWMMutualExclusion interface of the mutual exclusion
        /// object specified by the index passed as dwMEIndex.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMutualExclusion([In] uint dwMEIndex,
                                [Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        /// <summary>
        /// Removes a mutual exclusion object from the profile.
        /// </summary>
        /// <param name="pME">Pointer to the IWMMutualExclusion interface of the mutual exclusion object you want
        /// to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        /// <summary>
        /// Adds a mutual exclusion object to the profile.
        /// </summary>
        /// <param name="pME">Pointer to the IWMMutualExclusion interface of the mutual exclusion object to include
        /// in the profile. You must configure the mutual exclusion object by using the methods of the
        /// IWMMutualExclusion interface prior to using this method to add the mutual exclusion object
        /// to the profile.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        /// <summary>
        /// Creates a mutual exclusion object for the profile.
        /// </summary>
        /// <param name="ppME">Pointer to a pointer to the IWMMutualExclusion interface of the new mutual
        /// exclusion object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void CreateNewMutualExclusion([Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
    }
    /// <summary>
    /// The IWMProfileManager interface is used to create profiles, load existing profiles, and save profiles.
    /// It can be used with both system profiles and application-defined custom profiles.
    /// To make changes to a profile, you must load it into a profile object using one of the loading methods 
    /// of this interface. You can then access the profile data through the use of the interfaces of the
    /// profile object.
    /// 
    /// <see cref="IWMProfileManager"/> is the default interface of a profile manager object. When you create
    /// a new profile manager object using the WMCreateProfileManager function, you obtain a pointer to
    /// IWMProfileManager.
    /// </summary>
    [ComImport]
    [Guid("d16679f2-6ca0-472d-8d31-2f5d55aee155")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManager
    {
        /// <summary>
        /// Creates an empty profile.
        /// </summary>
        /// <param name="dwVersion"><b>DWORD</b> containing one member of the WMT_VERSION enumeration type.</param>
        /// <param name="ppProfile">Pointer to a pointer to an <see cref="IWMProfile"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void CreateEmptyProfile([In] WMT_VERSION dwVersion,
                                [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Creates a profile object and populates it with the data from a system profile. Uses the GUID to find
        /// the profile data.
        /// </summary>
        /// <param name="guidProfile"><b>GUID</b> identifying the profile. For more information, see the table of
        /// defined constants in Using System Profiles.</param>
        /// <param name="ppProfile">Pointer to a pointer to an IWMProfile interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void LoadProfileByID([In] ref Guid guidProfile,
                             [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Creates a profile object and populates it with the data from an existing profile that has been saved
        /// to a string.
        /// </summary>
        /// <param name="pwszProfile">Pointer to a wide-character null-terminated string containing the profile.
        /// Profile strings are limited to 153600 wide characters.</param>
        /// <param name="ppProfile">Pointer to a pointer to an IWMProfile interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void LoadProfileByData([In, MarshalAs(UnmanagedType.LPWStr)] string pwszProfile,
                               [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Saves a custom profile into a string. You can save the profile to disk by copying the string into a .prx
        /// file.
        /// </summary>
        /// <param name="pIWMProfile">Pointer to the IWMProfile interface of the object containing the profile data
        /// to be saved.</param>
        /// <param name="pwszProfile">Pointer to a wide-character null-terminated string containing the profile.
        /// Set this to NULL to retrieve the length of string required.</param>
        /// <param name="pdwLength">On input, specifies the length of the pwszProfile string. On output, if the method
        /// succeeds, specifies a pointer to a DWORD containing the number of characters, including the
        /// terminating null character, required to hold the profile.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void SaveProfile([In, MarshalAs(UnmanagedType.Interface)] IWMProfile pIWMProfile,
                         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszProfile,
                         [In, Out] ref uint pdwLength);
        /// <summary>
        /// Retrieves the number of system profiles.
        /// </summary>
        /// <param name="pcProfiles">Pointer to a count of the system profiles.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetSystemProfileCount([Out] out uint pcProfiles);
        /// <summary>
        /// Creates a profile object and populates it with data from a system profile. Uses the profile's index to
        /// find the profile data.
        /// </summary>
        /// <param name="dwProfileIndex"><b>DWORD</b> containing the profile index.</param>
        /// <param name="ppProfile">Pointer to a pointer to an IWMProfile interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void LoadSystemProfile([In] uint dwProfileIndex,
                               [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
    }
    /// <summary>
    /// The IWMProfileManager2 interface adds methods to specify and retrieve the version number of the 
    /// system profiles enumerated by the profile manager. Most applications should set the value to the 
    /// latest version unless they need to be backward-compatible with another application that was written
    /// using an earlier version of this SDK.
    /// </summary>
    [ComImport]
    [Guid("7A924E51-73C1-494d-8019-23D37ED9B89A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManager2 : IWMProfileManager
    {
        /// <summary>
        /// Creates an empty profile.
        /// </summary>
        /// <param name="dwVersion"><b>DWORD</b> containing one member of the WMT_VERSION enumeration type.</param>
        /// <param name="ppProfile">Pointer to a pointer to an <see cref="IWMProfile"/> interface.</param>
        new void CreateEmptyProfile([In] WMT_VERSION dwVersion,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Creates a profile object and populates it with the data from a system profile. Uses the GUID to find
        /// the profile data.
        /// </summary>
        /// <param name="guidProfile"><b>GUID</b> identifying the profile. For more information, see the table of
        /// defined constants in Using System Profiles.</param>
        /// <param name="ppProfile">Pointer to a pointer to an IWMProfile interface.</param>
        new void LoadProfileByID([In] ref Guid guidProfile,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Creates a profile object and populates it with the data from an existing profile that has been saved
        /// to a string.
        /// </summary>
        /// <param name="pwszProfile">Pointer to a wide-character null-terminated string containing the profile.
        /// Profile strings are limited to 153600 wide characters.</param>
        /// <param name="ppProfile">Pointer to a pointer to an IWMProfile interface.</param>
        new void LoadProfileByData([In, MarshalAs(UnmanagedType.LPWStr)] string pwszProfile,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Saves a custom profile into a string. You can save the profile to disk by copying the string into a .prx
        /// file.
        /// </summary>
        /// <param name="pIWMProfile">Pointer to the IWMProfile interface of the object containing the profile data
        /// to be saved.</param>
        /// <param name="pwszProfile">Pointer to a wide-character null-terminated string containing the profile.
        /// Set this to NULL to retrieve the length of string required.</param>
        /// <param name="pdwLength">On input, specifies the length of the pwszProfile string. On output, if the method
        /// succeeds, specifies a pointer to a DWORD containing the number of characters, including the
        /// terminating null character, required to hold the profile.</param>
        new void SaveProfile([In, MarshalAs(UnmanagedType.Interface)] IWMProfile pIWMProfile,
         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszProfile,
         [In, Out] ref uint pdwLength);
        /// <summary>
        /// Retrieves the number of system profiles.
        /// </summary>
        /// <param name="pcProfiles">Pointer to a count of the system profiles.</param>
        new void GetSystemProfileCount([Out] out uint pcProfiles);
        /// <summary>
        /// Creates a profile object and populates it with data from a system profile. Uses the profile's index to
        /// find the profile data.
        /// </summary>
        /// <param name="dwProfileIndex"><b>DWORD</b> containing the profile index.</param>
        /// <param name="ppProfile">Pointer to a pointer to an IWMProfile interface.</param>
        new void LoadSystemProfile([In] uint dwProfileIndex,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMProfile ppProfile);
        /// <summary>
        /// Retrieves the version number of the system profiles that the profile manager enumerates.
        /// </summary>
        /// <param name="pdwVersion">Pointer to one member of the WMT_VERSION enumeration type.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetSystemProfileVersion([Out] out WMT_VERSION pdwVersion);
        /// <summary>
        /// Specifies the version number of the system profiles that the profile manager enumerates.
        /// </summary>
        /// <param name="dwVersion">One member of the WMT_VERSION enumeration type.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetSystemProfileVersion([In] WMT_VERSION dwVersion);
    }
    /// <summary>
    /// The <b>IWMProfileManagerLanguage</b> interface controls the language of the system profiles parsed by
    /// the profile manager.
    /// 
    /// An <b>IWMProfileManagerLanguage</b> interface exists for every profile manager object. You can obtain
    /// a pointer to an instance of this method by calling the QueryInterface method of any other
    /// interface of the profile manager object.
    /// </summary>
    [ComImport]
    [Guid("BA4DCC78-7EE0-4ab8-B27A-DBCE8BC51454")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfileManagerLanguage
    {
        /// <summary>
        /// Retrieves the language identifier of the system profiles currently loaded.
        /// </summary>
        /// <param name="wLangID">Pointer to a <b>WORD</b> that receives the language identifier (LANGID) of
        /// the language set in the profile manager.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void GetUserLanguageID([Out] out ushort wLangID);
        /// <summary>
        /// Specifies which set of system profiles to load based upon language.
        /// </summary>
        /// <param name="wLangID"><b>WORD</b> containing the language identifier (LANGID) of the language you want to use.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void SetUserLanguageID([In] ushort wLangID);
    };
    /// <summary>
    /// The IWMProfile2 interface exposes the globally unique identifier for a system profile. System profiles
    /// have associated identifiers, but custom profiles do not.
    /// 
    /// As with IWMProfile, IWMProfile2 is included in profile objects as well as in reader and synchronous
    /// reader objects. To obtain a pointer to an IWMProfile2 interface, call the QueryInterface method
    /// of any interface in one of these objects. For more information, see IWMProfile Interface.
    /// </summary>
    [ComImport]
    [Guid("07E72D33-D94E-4be7-8843-60AE5FF7E5F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile2 : IWMProfile
    {
        /// <summary>
        /// Retrieves the version number of Microsoft Windows Media Services in the profile.
        /// </summary>
        /// <param name="pdwVersion">Pointer to a DWORD containing one member of the WMT_VERSION enumeration type.
        /// This value specifies the version of the Windows Media Format SDK that was used to create the profile.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetVersion([Out] out WMT_VERSION pdwVersion);
        /// <summary>
        /// Retrieves the name of the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchName">On input, specifies the length of the pwszName buffer. On output,
        /// if the method succeeds, specifies a pointer to the length of the name, including the terminating 
        /// null character.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
         [In, Out] ref uint pcchName);
        /// <summary>
        /// Specifies the name of the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Profile names are limited to 256 wide characters.</param>
        new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        /// <summary>
        /// Retrieves the description of the profile.
        /// </summary>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.
        /// Pass NULL to retrieve the required length for the description.</param>
        /// <param name="pcchDescription">On input, specifies the length of the pwszDescription string.
        /// On output, if the method succeeds, specifies a pointer to a count of the number of characters
        /// in the name, including the terminating null character.</param>
        new void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
         [In, Out] ref uint pcchDescription);
        /// <summary>
        /// Specifies the description of the profile.
        /// </summary>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.
        /// Profile descriptions are limited to 1024 wide characters.</param>
        new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription);
        /// <summary>
        /// Retrieves the number of streams in the profile.
        /// </summary>
        /// <param name="pcStreams">Pointer to a count of streams.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetStreamCount([Out] out uint pcStreams);
        /// <summary>
        /// Retrieves a stream, using an index number, from the profile.
        /// </summary>
        /// <param name="dwStreamIndex">DWORD containing the stream index.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the stream
        /// configuration object that describes the specified stream.</param>
        new void GetStream([In] uint dwStreamIndex, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Retrieves a stream, using the number of the stream, from the profile.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the stream configuration
        /// object that describes the specified stream.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetStreamByNumber([In] ushort wStreamNum, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Removes a stream from the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object
        /// that describes the stream you want to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void RemoveStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Removes a stream from the profile.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number.</param>
        new void RemoveStreamByNumber([In] ushort wStreamNum);
        /// <summary>
        /// Adds a stream to the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object to
        /// be added to the profile. The stream must be configured by using the methods of the IWMStreamConfig
        /// interface before this method is used to add the stream to the profile.</param>
        new void AddStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Enables changes made to a stream configuration to be included in the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object
        /// for the stream you want to reconfigure.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void ReconfigStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Creates a stream configuration object for the profile.
        /// </summary>
        /// <param name="guidStreamType">GUID object specifying the major media type for the stream to be
        /// created (for example, WMMEDIATYPE_Video). The supported major types are listed in Media Types.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the created stream
        /// configuration object.</param>
        new void CreateNewStream([In] ref Guid guidStreamType,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Retrieves the number of mutual exclusion objects in the profile.
        /// </summary>
        /// <param name="pcME">Pointer to a count of mutual exclusions.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetMutualExclusionCount([Out] out uint pcME);
        /// <summary>
        /// Retrieves a mutual exclusion object from the profile.
        /// </summary>
        /// <param name="dwMEIndex">DWORD containing the index of the mutual exclusion object.</param>
        /// <param name="ppME">Pointer to a pointer to the IWMMutualExclusion interface of the mutual exclusion
        /// object specified by the index passed as dwMEIndex.</param>
        new void GetMutualExclusion([In] uint dwMEIndex,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        /// <summary>
        /// Removes a mutual exclusion object from the profile.
        /// </summary>
        /// <param name="pME">Pointer to the IWMMutualExclusion interface of the mutual exclusion object you want
        /// to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void RemoveMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        /// <summary>
        /// Adds a mutual exclusion object to the profile.
        /// </summary>
        /// <param name="pME">Pointer to the IWMMutualExclusion interface of the mutual exclusion object to include
        /// in the profile. You must configure the mutual exclusion object by using the methods of the
        /// IWMMutualExclusion interface prior to using this method to add the mutual exclusion object
        /// to the profile.</param>
        new void AddMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        /// <summary>
        /// Creates a mutual exclusion object for the profile.
        /// </summary>
        /// <param name="ppME">Pointer to a pointer to the IWMMutualExclusion interface of the new mutual
        /// exclusion object.</param>
        new void CreateNewMutualExclusion([Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        /// <summary>
        /// Retrieves the globally unique identifier of the profile.
        /// </summary>
        /// <param name="pguidID">Pointer to a GUID specifying the ID of the profile. It the profile is not
        /// a system profile, this is set to GUID_NULL.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void GetProfileID([Out] out Guid pguidID);
    }
    /// <summary>
    /// The IWMProfile3 interface provides enhanced features for profiles. This includes the ability to create
    /// two new types of objects: bandwidth sharing objects and stream prioritization objects.
    /// 
    /// An IWMProfile3 interface is created for each profile object created. You can retrieve a pointer to an
    /// IWMProfile3 interface by calling the QueryInterface method of any other interface of the profile.
    /// You can also access IWMProfile3 from a reader or synchronous reader object by calling the QueryInterface
    /// method of an existing interface in the object. For more information, see <see cref="IWMProfile"/> Interface.
    /// </summary>
    [ComImport]
    [Guid("00EF96CC-A461-4546-8BCD-C9A28F0E06F5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMProfile3 : IWMProfile2
    {
        /// <summary>
        /// Retrieves the version number of Microsoft Windows Media Services in the profile.
        /// </summary>
        /// <param name="pdwVersion">Pointer to a DWORD containing one member of the WMT_VERSION enumeration type.
        /// This value specifies the version of the Windows Media Format SDK that was used to create the profile.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetVersion([Out] out WMT_VERSION pdwVersion);
        /// <summary>
        /// Retrieves the name of the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchName">On input, specifies the length of the pwszName buffer. On output,
        /// if the method succeeds, specifies a pointer to the length of the name, including the terminating 
        /// null character.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
         [In, Out] ref uint pcchName);
        /// <summary>
        /// Specifies the name of the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Profile names are limited to 256 wide characters.</param>
        new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        /// <summary>
        /// Retrieves the description of the profile.
        /// </summary>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.
        /// Pass NULL to retrieve the required length for the description.</param>
        /// <param name="pcchDescription">On input, specifies the length of the pwszDescription string.
        /// On output, if the method succeeds, specifies a pointer to a count of the number of characters
        /// in the name, including the terminating null character.</param>
        new void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
         [In, Out] ref uint pcchDescription);
        /// <summary>
        /// Specifies the description of the profile.
        /// </summary>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.
        /// Profile descriptions are limited to 1024 wide characters.</param>
        new void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription);
        /// <summary>
        /// Retrieves the number of streams in the profile.
        /// </summary>
        /// <param name="pcStreams">Pointer to a count of streams.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetStreamCount([Out] out uint pcStreams);
        /// <summary>
        /// Retrieves a stream, using an index number, from the profile.
        /// </summary>
        /// <param name="dwStreamIndex">DWORD containing the stream index.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the stream
        /// configuration object that describes the specified stream.</param>
        new void GetStream([In] uint dwStreamIndex, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Retrieves a stream, using the number of the stream, from the profile.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the stream configuration
        /// object that describes the specified stream.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetStreamByNumber([In] ushort wStreamNum, [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Removes a stream from the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object
        /// that describes the stream you want to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void RemoveStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Removes a stream from the profile.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number.</param>
        new void RemoveStreamByNumber([In] ushort wStreamNum);
        /// <summary>
        /// Adds a stream to the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object to
        /// be added to the profile. The stream must be configured by using the methods of the IWMStreamConfig
        /// interface before this method is used to add the stream to the profile.</param>
        new void AddStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Enables changes made to a stream configuration to be included in the profile.
        /// </summary>
        /// <param name="pConfig">Pointer to the IWMStreamConfig interface of the stream configuration object
        /// for the stream you want to reconfigure.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void ReconfigStream([In, MarshalAs(UnmanagedType.Interface)] IWMStreamConfig pConfig);
        /// <summary>
        /// Creates a stream configuration object for the profile.
        /// </summary>
        /// <param name="guidStreamType">GUID object specifying the major media type for the stream to be
        /// created (for example, WMMEDIATYPE_Video). The supported major types are listed in Media Types.</param>
        /// <param name="ppConfig">Pointer to a pointer to the IWMStreamConfig interface of the created stream
        /// configuration object.</param>
        new void CreateNewStream([In] ref Guid guidStreamType,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamConfig ppConfig);
        /// <summary>
        /// Retrieves the number of mutual exclusion objects in the profile.
        /// </summary>
        /// <param name="pcME">Pointer to a count of mutual exclusions.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetMutualExclusionCount([Out] out uint pcME);
        /// <summary>
        /// Retrieves a mutual exclusion object from the profile.
        /// </summary>
        /// <param name="dwMEIndex">DWORD containing the index of the mutual exclusion object.</param>
        /// <param name="ppME">Pointer to a pointer to the IWMMutualExclusion interface of the mutual exclusion
        /// object specified by the index passed as dwMEIndex.</param>
        new void GetMutualExclusion([In] uint dwMEIndex,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        /// <summary>
        /// Removes a mutual exclusion object from the profile.
        /// </summary>
        /// <param name="pME">Pointer to the IWMMutualExclusion interface of the mutual exclusion object you want
        /// to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void RemoveMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        /// <summary>
        /// Adds a mutual exclusion object to the profile.
        /// </summary>
        /// <param name="pME">Pointer to the IWMMutualExclusion interface of the mutual exclusion object to include
        /// in the profile. You must configure the mutual exclusion object by using the methods of the
        /// IWMMutualExclusion interface prior to using this method to add the mutual exclusion object
        /// to the profile.</param>
        new void AddMutualExclusion([In, MarshalAs(UnmanagedType.Interface)] IWMMutualExclusion pME);
        /// <summary>
        /// Creates a mutual exclusion object for the profile.
        /// </summary>
        /// <param name="ppME">Pointer to a pointer to the IWMMutualExclusion interface of the new mutual
        /// exclusion object.</param>
        new void CreateNewMutualExclusion([Out, MarshalAs(UnmanagedType.Interface)] out IWMMutualExclusion ppME);
        /// <summary>
        /// Retrieves the globally unique identifier of the profile.
        /// </summary>
        /// <param name="pguidID">Pointer to a GUID specifying the ID of the profile. It the profile is not
        /// a system profile, this is set to GUID_NULL.</param>
        new void GetProfileID([Out] out Guid pguidID);
        /// <summary>
        /// Not implemented in this release.
        /// </summary>
        /// <param name="pnStorageFormat">Storage format.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStorageFormat([Out] out WMT_STORAGE_FORMAT pnStorageFormat);
        /// <summary>
        /// Not implemented in this release.
        /// </summary>
        /// <param name="nStorageFormat">Storage format.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetStorageFormat([In] WMT_STORAGE_FORMAT nStorageFormat);
        /// <summary>
        /// Retrieves the number of bandwidth sharing objects that exist in the profile.
        /// </summary>
        /// <param name="pcBS">Pointer to receive the total number of bandwidth sharing objects.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetBandwidthSharingCount([Out] out uint pcBS);
        /// <summary>
        /// Obtains a pointer to the IWMBandwidthSharing interface of an existing bandwidth sharing object.
        /// </summary>
        /// <param name="dwBSIndex"><b>DWORD</b> containing the index number of the bandwidth sharing object you
        /// want to retrieve.</param>
        /// <param name="ppBS">Pointer to receive the address of the IWMBandwidthSharing interface
        /// of the object requested.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetBandwidthSharing([In] uint dwBSIndex,
                                 [Out, MarshalAs(UnmanagedType.Interface)] out IWMBandwidthSharing ppBS);
        /// <summary>
        /// Removes a bandwidth sharing object from the profile.
        /// </summary>
        /// <param name="pBS">Pointer to a bandwidth sharing object.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveBandwidthSharing([In, MarshalAs(UnmanagedType.Interface)] IWMBandwidthSharing pBS);
        /// <summary>
        /// Adds an existing bandwidth sharing object to the profile.
        /// </summary>
        /// <param name="pBS">Pointer to the IWMBandwidthSharing interface of a bandwidth sharing object.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddBandwidthSharing([In, MarshalAs(UnmanagedType.Interface)] IWMBandwidthSharing pBS);
        /// <summary>
        /// Creates a new bandwidth sharing object.
        /// </summary>
        /// <param name="ppBS">Pointer to a variable that receives the address of the IWMBandwidthSharing
        /// interface of the new object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void CreateNewBandwidthSharing([Out, MarshalAs(UnmanagedType.Interface)] out IWMBandwidthSharing ppBS);
        /// <summary>
        /// Retrieves the stream prioritization object associated with the profile.
        /// </summary>
        /// <param name="ppSP">Pointer to receive the address of the IWMStreamPrioritization interface of the
        /// stream prioritization object in the profile.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetStreamPrioritization([Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamPrioritization ppSP);
        /// <summary>
        /// Assigns a stream prioritization object to the profile.
        /// </summary>
        /// <param name="pSP">Pointer to the IWMStreamPrioritization interface of the stream prioritization object
        /// you want to assign to the profile.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetStreamPrioritization([In, MarshalAs(UnmanagedType.Interface)] IWMStreamPrioritization pSP);
        /// <summary>
        /// Removes a stream prioritization object from the profile.
        /// </summary>
        void RemoveStreamPrioritization();
        /// <summary>
        /// Creates a new stream prioritization object.
        /// </summary>
        /// <param name="ppSP">Pointer to receive the address of the IWMStreamPrioritization interface of the
        /// new object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void CreateNewStreamPrioritization([Out, MarshalAs(UnmanagedType.Interface)] out IWMStreamPrioritization ppSP);
        /// <summary>
        /// Retrieves the expected number of packets for a specified duration.
        /// </summary>
        /// <param name="msDuration">Specifies the duration in milliseconds.</param>
        /// <param name="pcPackets">Pointer to receive the count of packets expected for msDuration milliseconds.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetExpectedPacketCount([In] ulong msDuration, [Out] out ulong pcPackets);
    }
}