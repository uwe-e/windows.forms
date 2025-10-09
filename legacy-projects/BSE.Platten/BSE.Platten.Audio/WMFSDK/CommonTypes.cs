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
    /// The WMT_STREAM_SELECTION enumeration type defines the playback status of a stream.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public enum WMT_STREAM_SELECTION
    {
        /// <summary>
        /// No samples will be delivered for the stream.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_OFF = 0,
        /// <summary>
        /// Only samples with cleanpoints will be delivered for the stream.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLEANPOINT_ONLY = 1,
        /// <summary>
        /// All samples will be delivered for the stream.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_ON = 2,
    };
    /// <summary>
    /// The WMT_ATTR_DATATYPE enumeration defines the data type for a variably typed property.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public enum WMT_ATTR_DATATYPE
    {
        /// <summary>
        /// The property is a 4-byte DWORD value.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_DWORD = 0,
        /// <summary>
        /// The property is a null-terminated Unicode string.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_STRING = 1,
        /// <summary>
        /// The property is an array of bytes.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_BINARY = 2,
        /// <summary>
        /// The property is a 4-byte Boolean value.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_BOOL = 3,
        /// <summary>
        /// The property is an 8-byte QWORD value.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_QWORD = 4,
        /// <summary>
        /// The property is a 2-byte WORD value.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_WORD = 5,
        /// <summary>
        /// The property is a 128-bit (6-byte) GUID.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TYPE_GUID = 6,
    };
    /// <summary>
    /// The WMT_VERSION enumeration type defines the versions of the Windows Media Format SDK.
    /// Every profile you create will have an associated version identified by one of these enumerations.
    /// The version associated with a profile dictates the types of data allowed.
    /// For example, data unit extensions were introduced with version 8. A profile defined as version 7
    /// cannot include data unit extensions. Under most circumstances, you will create profiles
    /// for the most current version.
    /// </summary>
    /// <remarks>
    /// The version assigned to a profile does not directly relate to the codecs used in the profile's individual
    /// streams. However, it is recommended that you use codecs of the same version as the profile. Unless
    /// you have specific requirements to the contrary, you should always use the latest version.
    /// </remarks>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public enum WMT_VERSION
    {
        /// <summary>
        /// Compatible with version 4 of the Windows Media Format SDK.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        WMT_VER_4_0 = 0x00040000,
        /// <summary>
        /// Compatible with the Windows Media Format 7 SDK.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        WMT_VER_7_0 = 0x00070000,
        /// <summary>
        /// Compatible with the Windows Media Format 8.2 SDK.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        WMT_VER_8_0 = 0x00080000,
        /// <summary>
        /// Compatible with the Windows Media Format 9 Series SDK, and with the Windows Media Format 9.5 SDK.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        WMT_VER_9_0 = 0x00090000,
    };
    /// <summary>
    /// The WMT_STORAGE_FORMAT enumeration type defines the file types that can be manipulated with this SDK.
    /// </summary>
    /// <remarks>
    /// Storage format MP3 is supported for reading, but not writing.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public enum WMT_STORAGE_FORMAT
    {
        /// <summary>
        /// The file is encoded in MP3 format.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_Storage_Format_MP3,
        /// <summary>
        /// The file is encoded in Windows Media Format.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_Storage_Format_V1
    };
    /// <summary>
    /// The WMT_TRANSPORT_TYPE enumeration type defines the transport types supported by this SDK.
    /// </summary>
    /// <remarks>
    /// This enumeration indicates the type of data communication protocol (reliable or unreliable).
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    public enum WMT_TRANSPORT_TYPE
    {
        /// <summary>
        /// The transport type is not reliable.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        WMT_Transport_Type_Unreliable,
        /// <summary>
        /// The transport type is reliable.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        WMT_Transport_Type_Reliable
    };
    /// <summary>
    /// The WMT_STATUS enumeration type defines a range of file status information. Members of WMT_STATUS are passed
    /// to the common callback function, IWMStatusCallback.OnStatus, so that the application can respond to the
    /// changing status of the objects being used.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    public enum WMT_STATUS
    {
        /// <summary>
        /// An error occurred.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_ERROR = 0,
        /// <summary>
        /// A file was opened.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_OPENED = 1,
        /// <summary>
        /// The reader object is beginning to buffer content.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_BUFFERING_START = 2,
        /// <summary>
        /// The reader object has finished buffering content.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_BUFFERING_STOP = 3,
        /// <summary>
        /// The end of the file has been reached. Both this member and the next one, WMT_END_OF_FILE,
        /// have the value 4.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_EOF = 4,
        /// <summary>
        /// The end of the file has been reached. Both this member and the previous one, WMT_EOF, have the value 4.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_END_OF_FILE = 4,
        /// <summary>
        /// The end of a segment has been encountered.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_END_OF_SEGMENT = 5,
        /// <summary>
        /// The end of a server-side playlist has been reached.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_END_OF_STREAMING = 6,
        /// <summary>
        /// The reader object is locating requested data.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_LOCATING = 7,
        /// <summary>
        /// A reporting object is connecting to server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CONNECTING = 8,
        /// <summary>
        /// There is no license and the content is protected by version 1 digital rights management.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_NO_RIGHTS = 9,
        /// <summary>
        /// The file loaded in the reader object contains compressed data for which no codec could be found.
        /// The pValue parameter in OnStatus contains a GUID. The first DWORD of this GUID contains the FOURCC or
        /// the format tag of the missing codec. The remaining bytes of the GUID can be ignored.
        /// 
        /// The hr parameter in OnStatus may equal S_OK, although a missing codec would normally be considered
        /// an error. Also, this event may be followed by WMT_STARTED with hr equal to S_OK, even if codecs
        /// are missing for every stream in the file. In that case, however, the application will not
        /// receive any decoded samples, and should stop the reader object.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_MISSING_CODEC = 10,
        /// <summary>
        /// A reporting object has begun operations.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_STARTED = 11,
        /// <summary>
        /// A reporting object has ceased operations.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_STOPPED = 12,
        /// <summary>
        /// A file was closed.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLOSED = 13,
        /// <summary>
        /// The reader object is playing content at above normal speed, or in reverse.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_STRIDING = 14,
        /// <summary>
        /// Timer event.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_TIMER = 15,
        /// <summary>
        /// Progress update from the indexer object.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_INDEX_PROGRESS = 16,
        /// <summary>
        /// The reader object has begun saving a file from a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_SAVEAS_START = 17,
        /// <summary>
        /// The reader has stopped saving a file from a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_SAVEAS_STOP = 18,
        /// <summary>
        /// The current file's header object contains certain attributes that are different from those of the
        /// previous file. This event is sent when playing a server-side playlist. Use the IWMHeaderInfo interface
        /// to query for any of the following attributes in a new file: Stridable, Broadcast, Seekable,
        /// and HasImage.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_NEW_SOURCEFLAGS = 19,
        /// <summary>
        /// The current file's header object contains metadata attributes that are different from
        /// those of the previous file. This event is sent when playing a server-side playlist.
        /// Use the IWMHeaderInfo interface to query for any metadata attribute you are interested in.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_NEW_METADATA = 20,
        /// <summary>
        /// A license backup or restore has started.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_BACKUPRESTORE_BEGIN = 21,
        /// <summary>
        /// The next source in the playlist was opened.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_SOURCE_SWITCH = 22,
        /// <summary>
        /// The license acquisition process has completed. The pValue parameter in OnStatus contains a
        /// WM_GET_LICENSE_DATA structure. The hr member of this structure indicates whether the license
        /// was successfully acquired.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_ACQUIRE_LICENSE = 23,
        /// <summary>
        /// Individualization status message.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_INDIVIDUALIZE = 24,
        /// <summary>
        /// The file loaded in the reader object cannot be played without a security update.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_NEEDS_INDIVIDUALIZATION = 25,
        /// <summary>
        /// There is no license and the content is protected by version 7 digital rights management.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_NO_RIGHTS_EX = 26,
        /// <summary>
        /// A license backup or restore has finished.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_BACKUPRESTORE_END = 27,
        /// <summary>
        /// The backup restorer object is connecting to a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_BACKUPRESTORE_CONNECTING = 28,
        /// <summary>
        /// The backup restorer object is disconnecting from a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_BACKUPRESTORE_DISCONNECTING = 29,
        /// <summary>
        /// Error relating to the URL.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_ERROR_WITHURL = 30,
        /// <summary>
        /// The backup restorer object cannot back up one or more licenses because the right has been disallowed by
        /// the content owner.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RESTRICTED_LICENSE = 31,
        /// <summary>
        /// Sent when a client (a playing application or server) connects to a writer network sink object. The
        /// pValue parameter of the IWMStatusCallback::OnStatus callback is set to a WM_CLIENT_PROPERTIES
        /// structure. New applications should wait for WMT_CLIENT_CONNECT_EX instead.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLIENT_CONNECT = 32,
        /// <summary>
        /// Sent when a client (a playing application or server) disconnects from a writer network sink object.
        /// The pValue parameter of the IWMStatusCallback::OnStatus callback is set to a WM_CLIENT_PROPERTIES
        /// structure. The values in this structure are identical to those sent on connection.
        /// New applications should wait for WMT_CLIENT_DISCONNECT_EX instead.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLIENT_DISCONNECT = 33,
        /// <summary>
        /// Change in output properties.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_NATIVE_OUTPUT_PROPS_CHANGED = 34,
        /// <summary>
        /// Start of automatic reconnection to a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RECONNECT_START = 35,
        /// <summary>
        /// End of automatic reconnection to a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RECONNECT_END = 36,
        /// <summary>
        /// Sent when a client (a playing application or server) connects to a writer network sink object.
        /// The pValue parameter of the IWMStatusCallback::OnStatus callback is set to
        /// a WM_CLIENT_PROPERTIES_EX structure.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLIENT_CONNECT_EX = 37,
        /// <summary>
        /// Sent when a client (a playing application or server) disconnects from a writer network
        /// sink object. The pValue parameter of the IWMStatusCallback.OnStatus callback is set
        /// to a WM_CLIENT_PROPERTIES_EX structure. The client properties are identical to those
        /// sent on connection except for the pwszDNSName member, which may have changed.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLIENT_DISCONNECT_EX = 38,
        /// <summary>
        /// Change to the forward error correction span.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_SET_FEC_SPAN = 39,
        /// <summary>
        /// The reader is ready to begin buffering content.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PREROLL_READY = 40,
        /// <summary>
        /// The reader is finished buffering.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PREROLL_COMPLETE = 41,
        /// <summary>
        /// Sent by a writer network sink when one or more properties of a connected client changes.
        /// The pValue parameter of the IWMStatusCallback.OnStatus callback is set to a WM_CLIENT_PROPERTIES_EX
        /// structure. This usually means that a DNS name is present for a client for which none was available
        /// at connection.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CLIENT_PROPERTIES = 42,
        /// <summary>
        /// Sent before a WMT_NO_RIGHTS or WMT_NO_RIGHTS_EX status message. The pValue parameter is set to one
        /// of the WMT_DRMLA_TRUST constants indicating whether the license acquisition URL is completely trusted.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_LICENSEURL_SIGNATURE_STATE = 43
    };
    /// <summary>
    /// The WMT_PLAY_MODE enumeration type defines the playback options of the reader.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1712:DoNotPrefixEnumValuesWithTypeName")]
    public enum WMT_PLAY_MODE
    {
        /// <summary>
        /// The reader will select the most appropriate play mode based on the location of the content.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PLAY_MODE_AUTOSELECT = 0,
        /// <summary>
        /// The reader will read files from a local storage location.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PLAY_MODE_LOCAL = 1,
        /// <summary>
        /// The reader will download files from network locations.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PLAY_MODE_DOWNLOAD = 2,
        /// <summary>
        /// The reader will stream files from network locations.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PLAY_MODE_STREAMING = 3,
    };
    /// <summary>
    /// The WMT_OFFSET_FORMAT enumeration type defines the types of offsets used in this SDK.
    /// </summary>
    /// <remarks>
    /// WMT_OFFSET_FORMAT is used as an input parameter to IWMReaderAdvanced3.StartAtPosition.
    /// The value passed specifies whether the reader should begin playback at a specified presentation time,
    /// frame number, or offset into a playlist.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1712:DoNotPrefixEnumValuesWithTypeName")]
    public enum WMT_OFFSET_FORMAT
    {
        /// <summary>
        /// An offset into a file is specified by presentation time in 100-nanosecond units.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_OFFSET_FORMAT_100NS,
        /// <summary>
        /// An offset into a file is specified by frame number.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_OFFSET_FORMAT_FRAME_NUMBERS,
        /// <summary>
        /// An offset of playlist entries.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_OFFSET_FORMAT_PLAYLIST_OFFSET,
        /// <summary>
        /// An offset into a file is specified by presentation time as identified by SMTPE time codes.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_OFFSET_FORMAT_TIMECODE
    };
    /// <summary>
    /// The WMT_CODEC_INFO_TYPE enumeration type defines the broad categories of codecs supported by this SDK.
    /// </summary>
    /// <remarks>
    /// This type is used when adding or retrieving the codecs used in a file using IWMHeaderInfo2.GetCodecInfo
    /// and IWMHeaderInfo3::AddCodecInfo. When enumerating codecs with the methods of
    /// IWMCodecInfo, IWMCodecInfo2, and IWMCodecInfo3, you do not use this type. Those methods use the
    /// major media type GUIDs instead.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WMT_CODEC_INFO_TYPE : uint
    {
        /// <summary>
        /// Audio codec.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CODECINFO_AUDIO = 0,
        /// <summary>
        /// Video codec.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CODECINFO_VIDEO = 1,
        /// <summary>
        /// Codec of an unknown type.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_CODECINFO_UNKNOWN = 0xFFFFFFFF,
    };

    /// <summary>
    /// The WMT_RIGHTS enumeration type defines the rights that may be specified in a DRM license.
    /// </summary>
    /// <remarks>
    /// These values are bit flags, so one or more can be set by combining them with the bitwise OR operator.
    /// When using Windows Media DRM 10, WMT_RIGHT_COPY_TO_NON_SDMI_DEVICE, WMT_RIGHT_COPY_TO_SDMI_DEVICE,
    /// and WMT_RIGHT_COPY_TO_CD are superseded by WMT_RIGHT_COPY. Limitations on the devices to which 
    /// the content may be copied are specified by using output protection levels (OPLs).
    /// </remarks>
    [Flags]
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames")]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32")]
    public enum WMT_RIGHTS : uint
    {
        /// <summary>
        /// This rigth is not defined in the WMF SDK, I added it to
        /// play files with no DRM
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_NO_DRM = 0x00000000,
        /// <summary>
        /// Specifies the right to play content without restriction.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_PLAYBACK = 0x00000001,
        /// <summary>
        /// Specifies the right to copy content to a device not compliant with the Secure Digital Music
        /// Initiative (SDMI).
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_COPY_TO_NON_SDMI_DEVICE = 0x00000002,
        /// <summary>
        /// Specifies the right to copy content to a CD.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_COPY_TO_CD = 0x00000008,
        /// <summary>
        /// Specifies the right to copy content to a device compliant with the Secure Digital Music Initiative (SDMI).
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_COPY_TO_SDMI_DEVICE = 0x00000010,
        /// <summary>
        /// Specifies the right to play content one time only.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_ONE_TIME = 0x00000020,
        /// <summary>
        /// Specifies the right to save content from a server.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_SAVE_STREAM_PROTECTED = 0x00000040,
        /// <summary>
        /// Reserved for future use. Do not use.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_SDMI_TRIGGER = 0x00010000,
        /// <summary>
        /// Reserved for future use. Do not use.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_RIGHT_SDMI_NOMORECOPIES = 0x00020000
    }
    /// <summary>
    /// The WMT_INDEXER_TYPE enumeration type defines the types of indexing supported by the indexer.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public enum WMT_INDEXER_TYPE
    {
        /// <summary>
        /// The indexer will construct an index using presentation times as indexes.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_IT_PRESENTATION_TIME,
        /// <summary>
        /// The indexer will construct an index using frame numbers as indexes.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_IT_FRAME_NUMBERS,
        /// <summary>
        /// The indexer will construct an index using SMPTE time codes as indexes.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_IT_TIMECODE
    };
    /// <summary>
    /// The WMT_INDEX_TYPE enumeration type defines the type of object that will be associated with an index.
    /// Because the time specified by an index will not usually correspond exactly with an object in the file,
    /// the indexer must associate the index with an object in the bit stream close to the specified time.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum WMT_INDEX_TYPE
    {
        /// <summary>
        /// The index will associate indexes with the nearest data unit, or packet, in the Windows Media file.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_IT_NEAREST_DATA_UNIT = 1,
        /// <summary>
        /// The index will associate indexes with the nearest data object, or compressed sample, in the Windows Media file.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_IT_NEAREST_OBJECT,
        /// <summary>
        /// The index will associate indexes with the nearest cleanpoint, or video key frame, in the Windows Media file. This is the default index type.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_IT_NEAREST_CLEAN_POINT
    };
    /// <summary>
    /// The WMT_STREAM_SELECTION enumeration type defines the types of protocols that the network sink supports.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public enum WMT_NET_PROTOCOL
    {
        /// <summary>
        /// The network sink supports hypertext transfer protocol (HTTP).
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        WMT_PROTOCOL_HTTP = 0,
    };

    /// <summary>
    /// The WMT_TIMECODE_EXTENSION_DATA structure contains information needed for a single SMPTE time code sample
    /// extension. One of these structures will be attached to every video frame that requires a SMPTE time code.
    /// </summary>
    /// <remarks>
    /// One of the more common SMPTE user scenarios is assembling a bunch of clips from their source reels into
    /// a prospective edit, and preserving the source reel time code in the edit. The time code in this type of
    /// file consists of a set of disjointed SMPTE ranges, where each range corresponds to the linear time code
    /// from its source reel.
    /// Because these ranges are not guaranteed to be in any sort of time-related order (in other words, the first
    /// range may occur earlier in time than the second range), the concept of a range is supported in the
    /// Windows Media Format SDK time code index and interfaces. SMPTE time code MUST increase in time over a
    /// given range. Minor discontinuities within the range (such as dropped frames, or drop-frame counting) need
    /// not be marked within the range.
    /// Ranges are guaranteed to be monotonically increasing (in other words, 0, 1, 2, 3, … ) with a WMV file.
    /// SMPTE time code values are guaranteed to be increasing within a given range in a WMV file,
    /// but not across ranges.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WMT_TIMECODE_EXTENSION_DATA
    {
        /// <summary>
        /// WORD specifying the range to which the time code belongs. See Remarks.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ushort wRange;
        /// <summary>
        /// DWORD containing the time code. Time code is stored so that the hexadecimal value is read as if it were
        /// a decimal value. That is, the time code value 0x01133512 does not represent decimal 18035986, rather
        /// it specifies 1 hour, 13 minutes, 35 seconds, and 12 frames.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwTimecode;
        /// <summary>
        /// DWORD containing any information that the user desires. Typically, this member is used to store shot
        /// or take numbers, or other information pertinent to the production process.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwUserbits;
        /// <summary>
        /// DWORD provided for maintaining any AM_TIMECODE flags that are present in source material. These flags
        /// are not used by any of the objects in the Windows Media Format SDK. For more information about
        /// AM_TIMECODE flags, refer to the SMPTE time code specification.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwAmFlags;
    };
    /// <summary>
    /// The WM_STREAM_PRIORITY_RECORD structure contains a stream number and specifies whether delivery of that
    /// stream is mandatory.
    /// </summary>
    /// <remarks>
    /// WM_STREAM_PRIORITY_RECORD is used in an array by the IWMStreamPrioritization interface.
    /// Each member of the array specifies a stream; the lower the element number in the array, the higher
    /// the priority of the stream.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WM_STREAM_PRIORITY_RECORD
    {
        /// <summary>
        /// WORD containing the stream number.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ushort wStreamNumber;
        /// <summary>
        /// Flag indicating whether the listed stream is mandatory. Mandatory streams will not be dropped regardless
        /// of their position in the priority list.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        [MarshalAs(UnmanagedType.Bool)]
        public bool fMandatory;
    };
    /// <summary>
    /// The WM_MEDIA_TYPE structure is the primary structure used to describe media formats for the objects of
    /// the Windows Media Format SDK. For more information about media formats and what they are used for,
    /// see Formats.
    /// </summary>
    /// <remarks>
    /// This is the same as the DirectShow structure AM_MEDIA_TYPE but is redefined in this SDK to avoid
    /// conflict with DirectShow names.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WM_MEDIA_TYPE
    {
        /// <summary>
        /// Major type of the media sample. For example, WMMEDIATYPE_Video specifies a video stream. For a list
        /// of possible major media types, see Media Types.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Guid majortype;
        /// <summary>
        /// Subtype of the media sample. The subtype defines a specific format (usually an encoding scheme) within a
        /// major media type. For example, WMMEDIASUBTYPE_WMV3 specifies a video stream encoded with the
        /// Windows Media Video 9 codec. Subtypes can be uncompressed or compressed. For lists of possible
        /// media subtypes, see Uncompressed Media Subtypes and Compressed Media Subtypes.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Guid subtype;
        /// <summary>
        /// Set to true if the samples are of a fixed size. Compressed audio samples are of a fixed size while
        /// video samples are not.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        [MarshalAs(UnmanagedType.Bool)]
        public bool bFixedSizeSamples;
        /// <summary>
        /// Set to true if the samples are temporally compressed. Temporal compression is compression where some
        /// samples describe the changes in content from the previous sample, instead of describing the sample 
        /// in its entirety. Only compressed video can be temporally compressed. By definition, no media type
        /// can use both fixed sized samples and temporal compression.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        [MarshalAs(UnmanagedType.Bool)]
        public bool bTemporalCompression;
        /// <summary>
        /// Long integer containing the size of the sample, in bytes. This member is used only if bFixedSizeSamples
        /// is true.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint lSampleSize;
        /// <summary>
        /// GUID of the format type. The format type specifies the additional structure used to identify the
        /// media format. This structure is pointed to by pbFormat
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public Guid formattype;
        /// <summary>
        /// Not used. Should be NULL.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")]
        public IntPtr pUnk;
        /// <summary>
        /// Size, in bytes, of the structure pointed to by pbFormat.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint cbFormat;
        /// <summary>
        /// Pointer to the format structure of the media type. The structure referenced is determined by the format type GUID.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")]
        public IntPtr pbFormat;
    };
    /// <summary>
    /// The IWMMediaProps interface sets and retrieves the WM_MEDIA_TYPE structure for an input, stream, or output.
    /// 
    /// In the case of inputs and streams, the contents of the media type structure determine what actions the
    /// writer object will perform on the input data when writing the file. Typically, the input media type is 
    /// an uncompressed type and the stream is a compressed type, so that the contents of their respective media
    /// type structures will determine the settings passed by the writer to the codec that will compress the
    /// stream.
    /// 
    /// In the case of outputs, the media type structure determines the settings used to decompress the contents
    /// of a stream. The Windows Media codecs are capable of delivering output content in a variety of formats.
    /// 
    /// The methods of IWMMediaProps are inherited by IWMVideoMediaProps, which provides access to additional
    /// settings for specifying video media types. The methods are also inherited by IWMInputMediaProps and
    /// IWMOutputMediaProps.
    /// 
    /// An instance of the IWMMediaProps interface exists for every stream configuration object,
    /// input media properties object, and output media properties object. You can retrieve a pointer to
    /// this interface by calling the QueryInterface method of any other interface in one of those objects.
    /// </summary>
    [ComImport]
    [Guid("96406BCE-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMediaProps
    {
        /// <summary>
        /// Retrieves the major type of the media (audio, video, or script).
        /// </summary>
        /// <param name="pguidType">Pointer to a GUID specifying the media type.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Retrieves a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to a WM_MEDIA_TYPE structure. If this parameter is set to NULL,
        /// this method returns the size of the buffer required in the pcbType parameter.</param>
        /// <param name="pcbType">On input, the size of the pType buffer. On output, if pType is set to NULL,
        /// the value this points to is set to the size of the buffer needed to hold the media type structure.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMediaType( /*[out] WM_MEDIA_TYPE* */ IntPtr pType,
                           [In, Out] ref uint pcbType);
        /// <summary>
        /// Specifies a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to the WM_MEDIA_TYPE structure describing the input, stream, or output.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetMediaType([In] ref WM_MEDIA_TYPE pType);
    }
    /// <summary>
    /// With this interface, the application can specify additional video-specific parameters not available
    /// on the IWMMediaProps interface.
    /// 
    /// To get access to the methods of this interface, call QueryInterface on a stream configuration object.
    /// For more information, see IWMStreamConfig Interface).
    /// 
    /// Methods
    /// 
    /// The IWMVideoMediaProps interface inherits from IWMMediaProps.
    /// </summary>
    [ComImport]
    [Guid("96406BCF-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMVideoMediaProps : IWMMediaProps
    {
        /// <summary>
        /// Retrieves the major type of the media (audio, video, or script).
        /// </summary>
        /// <param name="pguidType">Pointer to a GUID specifying the media type.</param>
        new void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Retrieves a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to a WM_MEDIA_TYPE structure. If this parameter is set to NULL,
        /// this method returns the size of the buffer required in the pcbType parameter.</param>
        /// <param name="pcbType">On input, the size of the pType buffer. On output, if pType is set to NULL,
        /// the value this points to is set to the size of the buffer needed to hold the media type structure.</param>
        new void GetMediaType( /*[out] WM_MEDIA_TYPE* */ IntPtr pType,
          [In, Out] ref uint pcbType);
        /// <summary>
        /// Specifies a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to the WM_MEDIA_TYPE structure describing the input, stream, or output.</param>
        new void SetMediaType([In] ref WM_MEDIA_TYPE pType);
        /// <summary>
        /// Retrieves the maximum interval between key frames.
        /// </summary>
        /// <param name="pllTime">Pointer to a variable that receives the interval in 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMaxKeyFrameSpacing([Out] out long pllTime);
        /// <summary>
        /// Specifies the maximum interval between key frames.
        /// </summary>
        /// <param name="llTime">Maximum key-frame spacing in 100-nanosecond units.</param>
        void SetMaxKeyFrameSpacing([In] long llTime);
        /// <summary>
        /// Retrieves the quality setting for the video stream.
        /// </summary>
        /// <param name="pdwQuality">Pointer to a DWORD containing the quality setting.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetQuality([Out] out uint pdwQuality);
        /// <summary>
        /// Specifies the quality setting for the video stream.
        /// </summary>
        /// <param name="dwQuality">DWORD specifying the quality setting, in the range from zero (maximum frame rate)
        /// to 100 (maximum image quality).</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetQuality([In] uint dwQuality);
    }
    /// <summary>
    /// The IWMInputMediaProps interface is used to retrieve the properties of digital media that will be
    /// passed to the writer.
    /// 
    /// An input media properties object is created by a call to either the IWMWriter.GetInputProps or
    /// IWMWriter.GetInputFormat method.
    /// 
    /// Methods
    /// 
    /// The IWMInputMediaProps interface inherits from IWMMediaProps.
    /// </summary>
    [ComImport]
    [Guid("96406BD5-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMInputMediaProps : IWMMediaProps
    {
        /// <summary>
        /// Retrieves the major type of the media (audio, video, or script).
        /// </summary>
        /// <param name="pguidType">Pointer to a GUID specifying the media type.</param>
        new void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Retrieves a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to a WM_MEDIA_TYPE structure. If this parameter is set to NULL,
        /// this method returns the size of the buffer required in the pcbType parameter.</param>
        /// <param name="pcbType">On input, the size of the pType buffer. On output, if pType is set to NULL,
        /// the value this points to is set to the size of the buffer needed to hold the media type structure.</param>
        new void GetMediaType( /*[out] WM_MEDIA_TYPE* */ IntPtr pType,
          [In, Out] ref uint pcbType);
        /// <summary>
        /// Specifies a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to the WM_MEDIA_TYPE structure describing the input, stream, or output.</param>
        new void SetMediaType([In] ref WM_MEDIA_TYPE pType);
        /// <summary>
        /// Retrieves the connection name specified in the profile.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the connection name.
        /// Pass NULL to retrieve the length required for the name.</param>
        /// <param name="pcchName">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the length
        /// of the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                               [In, Out] ref ushort pcchName);
        /// <summary>
        /// Not implemented in this release. Returns an empty string.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Pass NULL to retrieve the length required for the name.</param>
        /// <param name="pcchName">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the length
        /// of the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetGroupName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                          [In, Out] ref ushort pcchName);
    }
    /// <summary>
    /// The IWMOutputMediaProps interface is used to retrieve the properties of an output stream.
    /// 
    /// An IWMOutputMediaProps object is created by a call to IWMReader.GetOutputFormat or
    /// IWMReader.GetOutputProps.
    /// 
    /// Methods
    /// 
    /// The IWMOutputMediaProps interface inherits from IWMMediaProps.
    /// </summary>
    [ComImport]
    [Guid("96406BD7-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMOutputMediaProps : IWMMediaProps
    {
        /// <summary>
        /// Retrieves the major type of the media (audio, video, or script).
        /// </summary>
        /// <param name="pguidType">Pointer to a GUID specifying the media type.</param>
        new void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Retrieves a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to a WM_MEDIA_TYPE structure. If this parameter is set to NULL,
        /// this method returns the size of the buffer required in the pcbType parameter.</param>
        /// <param name="pcbType">On input, the size of the pType buffer. On output, if pType is set to NULL,
        /// the value this points to is set to the size of the buffer needed to hold the media type structure.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetMediaType( /*[out] WM_MEDIA_TYPE* */ IntPtr pType,
          [In, Out] ref uint pcbType);
        /// <summary>
        /// Specifies a WM_MEDIA_TYPE structure describing the media type.
        /// </summary>
        /// <param name="pType">Pointer to the WM_MEDIA_TYPE structure describing the input, stream, or output.</param>
        new void SetMediaType([In] ref WM_MEDIA_TYPE pType);
        /// <summary>
        /// Returns an empty string.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchName">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, and if the method succeeds, the variable contains
        /// the length of the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreamGroupName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                                [In, Out] ref ushort pcchName);
        /// <summary>
        /// Retrieves the name of the connection to be used for output.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchName">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters. On output, if the method succeeds, it specifies a pointer to the length of
        /// the connection name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetConnectionName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                               [In, Out] ref ushort pcchName);
    }
    /// <summary>
    /// The IWMStreamList interface is used by mutual exclusion objects and bandwidth sharing objects to maintain
    /// lists of streams. The IWMMutualExclusion and IWMBandwidthSharing interfaces each inherit from
    /// IWMStreamList. These are the only uses of this interface in the SDK. You never need to deal with
    /// interface pointers for IWMStreamList directly.
    /// </summary>
    [ComImport]
    [Guid("96406BDD-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamList
    {
        /// <summary>
        /// Retrieves an array of stream numbers that make up the list.
        /// </summary>
        /// <param name="pwStreamNumArray">Pointer to a WORD array containing the stream numbers. Pass NULL to
        /// retrieve the required size of the array.</param>
        /// <param name="pcStreams">On input, a pointer to a variable containing the size of the
        /// pwStreamNumArray array. On output, if the method succeeds, this variable contains the number 
        /// of stream numbers entered into pwStreamNumArray by the method.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreams([Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
                        [In, Out] ref ushort pcStreams);
        /// <summary>
        /// Adds a stream to the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range
        /// of 1 through 63.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddStream([In] ushort wStreamNum);
        /// <summary>
        /// Removes a stream from the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of
        /// 1 through 63.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveStream([In] ushort wStreamNum);
    };
    /// <summary>
    /// The IWMMutualExclusion interface represents a group of streams, of which only one at a time can be played.
    /// 
    /// IWMMutualExclusion is the base interface for mutual exclusion objects. You can create a mutual exclusion
    /// object only as part of a profile. Never use COM functions, such as CoCreateInstance, to create a mutual
    /// exclusion object. Instead, you must already have a profile opened and make a call to its
    /// IWMProfile.CreateNewMutualExclusion method. After a mutual exclusion object has been created,
    /// you can change the type of mutual exclusion by using the methods in this interface.
    /// 
    /// You can manage the streams in a mutual exclusion object using the methods of the IWMStreamList interface.
    /// IWMMutualExclusion inherits from IWMStreamList, so those methods are directly available in this interface.
    /// 
    /// Methods
    /// 
    /// The IWMMutualExclusion interface inherits from IWMStreamList.
    /// </summary>
    [ComImport]
    [Guid("96406BDE-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMutualExclusion : IWMStreamList
    {
        /// <summary>
        /// Retrieves an array of stream numbers that make up the list.
        /// </summary>
        /// <param name="pwStreamNumArray">Pointer to a WORD array containing the stream numbers. Pass NULL to
        /// retrieve the required size of the array.</param>
        /// <param name="pcStreams">On input, a pointer to a variable containing the size of the
        /// pwStreamNumArray array. On output, if the method succeeds, this variable contains the number 
        /// of stream numbers entered into pwStreamNumArray by the method.</param>
        new void GetStreams([Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
         [In, Out] ref ushort pcStreams);
        /// <summary>
        /// Adds a stream to the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range
        /// of 1 through 63.</param>
        new void AddStream([In] ushort wStreamNum);
        /// <summary>
        /// Removes a stream from the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of
        /// 1 through 63.</param>
        new void RemoveStream([In] ushort wStreamNum);
        /// <summary>
        /// Retrieves the GUID of the type of mutual exclusion required.
        /// </summary>
        /// <param name="pguidType">Pointer to a GUID that specifies the type of mutual exclusion.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Specifies the GUID of the type of mutual exclusion required.
        /// </summary>
        /// <param name="guidType">GUID specifying the type of mutual exclusion. For a list of values,
        /// see IWMMutualExclusion.GetType</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        void SetType([In] ref Guid guidType);
    };
    /// <summary>
    /// The IWMMutualExclusion2 interface provides advanced configuration features for mutual exclusion objects.
    /// 
    /// This interface supports both multiple languages and advanced mutual exclusion.
    /// 
    /// An IWMMutualExclusion2 interface is created for each mutual exclusion object created. To retrieve a
    /// pointer to an IWMMutualExclusion2 interface, call the QueryInterface method of the IWMMutualExclusion
    /// interface returned by IWMProfile.CreateNewMutualExclusion.
    /// 
    /// Methods
    /// 
    /// The IWMMutualExclusion2 interface inherits from IWMMutualExclusion.
    /// </summary>
    [ComImport]
    [Guid("0302B57D-89D1-4ba2-85C9-166F2C53EB91")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMutualExclusion2 : IWMMutualExclusion
    {
        /// <summary>
        /// Retrieves an array of stream numbers that make up the list.
        /// </summary>
        /// <param name="pwStreamNumArray">Pointer to a WORD array containing the stream numbers. Pass NULL to
        /// retrieve the required size of the array.</param>
        /// <param name="pcStreams">On input, a pointer to a variable containing the size of the
        /// pwStreamNumArray array. On output, if the method succeeds, this variable contains the number 
        /// of stream numbers entered into pwStreamNumArray by the method.</param>
        new void GetStreams([Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
         [In, Out] ref ushort pcStreams);
        /// <summary>
        /// Adds a stream to the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range
        /// of 1 through 63.</param>
        new void AddStream([In] ushort wStreamNum);
        /// <summary>
        /// Removes a stream from the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of
        /// 1 through 63.</param>
        new void RemoveStream([In] ushort wStreamNum);
        /// <summary>
        /// Retrieves the GUID of the type of mutual exclusion required.
        /// </summary>
        /// <param name="pguidType">Pointer to a GUID that specifies the type of mutual exclusion.</param>
        new void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Specifies the GUID of the type of mutual exclusion required.
        /// </summary>
        /// <param name="guidType">GUID specifying the type of mutual exclusion. For a list of values,
        /// see IWMMutualExclusion.GetType</param>
        new void SetType([In] ref Guid guidType);
        /// <summary>
        /// Retrieves the name that has been assigned to the mutual exclusion object through a call to SetName.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name of the
        /// mutual exclusion object. Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchName">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the length
        /// of the name, including the terminating null character.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetName([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                     [In, Out] ref ushort pcchName);
        /// <summary>
        /// Assigns a name to the mutual exclusion object.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name you want
        /// to assign.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);
        /// <summary>
        /// Retrieves the number of records that exist for the mutual exclusion object.
        /// </summary>
        /// <param name="pwRecordCount">Pointer to a WORD containing the number of records that exist
        /// in the mutual exclusion object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetRecordCount([Out] out ushort pwRecordCount);
        /// <summary>
        /// Adds a record to the mutual exclusion object. Records can hold groups of streams.
        /// </summary>
        void AddRecord();
        /// <summary>
        /// Removes a record from the mutual exclusion object.
        /// </summary>
        /// <param name="wRecordNumber">WORD containing the number of the record to remove.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveRecord([In] ushort wRecordNumber);
        /// <summary>
        /// Retrieves the name that has been assigned to a record through a call to SetName.
        /// </summary>
        /// <param name="wRecordNumber">WORD containing the number of the record for which you want to get the name.</param>
        /// <param name="pwszRecordName">Pointer to a wide-character null-terminated string containing the record name.
        /// Pass NULL to retrieve the length of the name.</param>
        /// <param name="pcchRecordName">On input, a pointer to a variable containing the length of the pwszRecordName
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains the
        /// length of the name, including the terminating null character. However, if you pass NULL as
        /// pwszRecordName, this will be set to the required length on output.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetRecordName([In] ushort wRecordNumber,
                           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszRecordName,
                           [In, Out] ref ushort pcchRecordName);
        /// <summary>
        /// Assigns a name to a record.
        /// </summary>
        /// <param name="wRecordNumber">WORD containing the record number to which you want to assign a name.</param>
        /// <param name="pwszRecordName">Pointer to a wide-character null-terminated string containing the name
        /// you want to assign to the record. Record names are limited to 256 wide characters.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetRecordName([In] ushort wRecordNumber,
                           [In, MarshalAs(UnmanagedType.LPWStr)] string pwszRecordName);
        /// <summary>
        /// Retrieves the list of all streams in a record.
        /// </summary>
        /// <param name="wRecordNumber">WORD containing the record number for which to retrieve the streams.</param>
        /// <param name="pwStreamNumArray">Pointer to an array that will receive the stream numbers. If it is NULL,
        /// GetStreamsForRecord will return the number of streams to pcStreams.</param>
        /// <param name="pcStreams">Pointer to a WORD containing the number of streams in the record.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStreamsForRecord([In] ushort wRecordNumber,
                                 [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
                                 [In, Out] ref ushort pcStreams);
        /// <summary>
        /// Adds a stream to the list in a record.
        /// </summary>
        /// <param name="wRecordNumber">WORD containing the number of the record to which to add the stream.</param>
        /// <param name="wStreamNumber">WORD containing the stream number you want to add.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddStreamForRecord([In] ushort wRecordNumber, [In] ushort wStreamNumber);
        /// <summary>
        /// Removes a stream from the list in a record.
        /// </summary>
        /// <param name="wRecordNumber">WORD containing the record number from which you want to remove a stream.</param>
        /// <param name="wStreamNumber">WORD containing the stream number you want to remove from the record.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveStreamForRecord([In] ushort wRecordNumber, [In] ushort wStreamNumber);
    }
    /// <summary>
    /// The IWMBandwidthSharing interface contains methods to manage the properties of combined streams.
    /// 
    /// The list of streams that share bandwidth is stored in the bandwidth sharing object. The streams can be
    /// manipulated using the methods of the IWMStreamList interface. IWMBandwidthSharing inherits from
    /// IWMStreamList, so the stream list manipulation methods are always exposed through this interface.
    /// 
    /// The information in a bandwidth sharing object is purely informational. Nothing in the SDK seeks to
    /// enforce or check the accuracy of the bandwidth specified. You might want to use bandwidth sharing so 
    /// that a reading application can make adjustments based on the information contained in the bandwidth
    /// sharing object.
    /// 
    /// An IWMBandwidthSharing interface is exposed for each bandwidth sharing object upon creation. Bandwidth
    /// sharing objects are created using the IWMProfile3::CreateNewBandwidthSharing method.
    /// 
    /// Methods
    /// 
    /// The IWMBandwidthSharing interface inherits from IWMStreamList.
    /// </summary>
    [ComImport]
    [Guid("AD694AF1-F8D9-42F8-BC47-70311B0C4F9E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMBandwidthSharing : IWMStreamList
    {
        /// <summary>
        /// Retrieves an array of stream numbers that make up the list.
        /// </summary>
        /// <param name="pwStreamNumArray">Pointer to a WORD array containing the stream numbers. Pass NULL to
        /// retrieve the required size of the array.</param>
        /// <param name="pcStreams">On input, a pointer to a variable containing the size of the
        /// pwStreamNumArray array. On output, if the method succeeds, this variable contains the number 
        /// of stream numbers entered into pwStreamNumArray by the method.</param>
        new void GetStreams([Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwStreamNumArray,
         [In, Out] ref ushort pcStreams);
        /// <summary>
        /// Adds a stream to the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range
        /// of 1 through 63.</param>
        new void AddStream([In] ushort wStreamNum);
        /// <summary>
        /// Removes a stream from the list.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of
        /// 1 through 63.</param>
        new void RemoveStream([In] ushort wStreamNum);
        /// <summary>
        /// Retrieves the type of sharing (exclusive or partial) for the bandwidth sharing object.
        /// </summary>
        /// <param name="pguidType">Pointer to a globally unique identifier specifying the type of combined
        /// stream to be used.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        void GetType([Out] out Guid pguidType);
        /// <summary>
        /// Sets the type of sharing (exclusive or partial) for the bandwidth sharing object.
        /// </summary>
        /// <param name="guidType">Globally unique identifier specifying the type of combined stream
        /// to be used.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        void SetType([In] ref Guid guidType);
        /// <summary>
        /// Retrieves the bandwidth and maximum buffer size of the streams in the bandwidth sharing object.
        /// </summary>
        /// <param name="pdwBitrate">Pointer to a DWORD containing the bit rate in bits per second. The combined
        /// bandwidths of the streams cannot exceed this value.</param>
        /// <param name="pmsBufferWindow">Pointer to DWORD containing the buffer window in milliseconds.
        /// The combined buffer sizes of the streams cannot exceed this value.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetBandwidth([Out] out uint pdwBitrate, [Out] out uint pmsBufferWindow);
        /// <summary>
        /// Sets the bandwidth and maximum buffer size for streams in the bandwidth sharing object.
        /// </summary>
        /// <param name="dwBitrate">DWORD containing the bit rate in bits per second. The combined bandwidths of the
        /// streams cannot exceed this value.</param>
        /// <param name="msBufferWindow">Specifies the buffer window in milliseconds. The combined buffer sizes of
        /// the streams cannot exceed this value.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetBandwidth([In] uint dwBitrate, [In] uint msBufferWindow);
    }
    /// <summary>
    /// The IWMStreamPrioritization interface provides methods to set and read priority records for a file.
    /// 
    /// Stream prioritization allows content creators to specify the priority of the streams in an ASF file.
    /// The streams assigned the lowest priority will be dropped first in the case of insufficient bit rate
    /// during playback.
    /// 
    /// Only one stream prioritization object can exist for a profile. You can check to see if one is present
    /// with a call to IWMProfile3::GetStreamPrioritization, which will retrieve a pointer to one if it exists.
    /// 
    /// You can create a new stream prioritization object with a call to IWMProfile3.CreateNewStreamPrioritization.
    /// You will then receive a pointer to IWMStreamPrioritization for the new object. This will erase the
    /// existing stream prioritization, if there is one.
    /// 
    /// Methods
    /// 
    /// The IWMStreamPrioritization interface inherits the methods of the IUnknown interface.
    /// </summary>
    [ComImport]
    [Guid("8C1C6090-F9A8-4748-8EC3-DD1108BA1E77")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStreamPrioritization
    {
        /// <summary>
        /// Retrieves the list of streams and their priorities from the profile.
        /// </summary>
        /// <param name="pRecordArray">Pointer to an array of WM_STREAM_PRIORITY_RECORD structures. This array will
        /// receive the current stream priority data.</param>
        /// <param name="pcRecords">Pointer to a WORD that receives the count of records.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetPriorityRecords([Out, MarshalAs(UnmanagedType.LPArray)] WM_STREAM_PRIORITY_RECORD[] pRecordArray,
                                [In, Out] ref ushort pcRecords);
        /// <summary>
        /// Set the list of streams and their priorities for the profile.
        /// </summary>
        /// <param name="pRecordArray">Pointer to an array of WM_STREAM_PRIORITY_RECORD structures.</param>
        /// <param name="cRecords">Count of records.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetPriorityRecords([In, MarshalAs(UnmanagedType.LPArray)] WM_STREAM_PRIORITY_RECORD[] pRecordArray,
                                [In] ushort cRecords);
    }
    /// <summary>
    /// The IWMStatusCallback interface is implemented by the application to receive status information
    /// from various objects.
    /// </summary>
    [ComImport]
    [Guid("6d7cdc70-9888-11d3-8edc-00c04f6109cf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMStatusCallback
    {
        /// <summary>
        /// Called when status information must be communicated to the host application. This happens routinely
        /// when an ASF file is being opened and read, and when errors occur during reading.
        /// </summary>
        /// <param name="Status">One member of the WMT_STATUS enumeration type. For a description of possible
        /// WMT_STATUS values, see the tables in the Remarks section.</param>
        /// <param name="hr">HRESULT error code. If this indicates failure, you should not process the status as normal,
        /// as some error has occurred. Use if (FAILED(hr)) to check for a failed value. See the topic Error Codes
        /// for a list of possible results.</param>
        /// <param name="dwType">Member of the WMT_ATTR_DATATYPE enumeration type. This value specifies
        /// the type of data in the buffer at pValue.</param>
        /// <param name="pValue">Pointer to a byte array containing the value. The contents of this array
        /// depend on the value of Status and the value of dwType.</param>
        /// <param name="pvContext">Generic pointer provided by the application, for its own use. This pointer matches
        /// the context pointer given to the IWMReader::Open, IWMIndexer.StartIndexing, and other methods.
        /// The SDK makes no assumptions about the use of this pointer; it is simply provided by the application
        /// and passed back to the application when a callback is made.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void OnStatus([In] WMT_STATUS Status,
                      [In] IntPtr hr,
                      [In] WMT_ATTR_DATATYPE dwType,
                      [In] IntPtr pValue,
                      [In] IntPtr pvContext);
    }
    /// <summary>
    /// The IWMHeaderInfo interface sets and retrieves information in the header section of an ASF file. You can
    /// manipulate three types of header information by using the methods of this interface: metadata attributes,
    /// markers, and script commands.
    /// 
    /// Metadata attributes are name/value pairs that describe or relate to the contents of the file. Typical
    /// metadata attributes contain information about the artist, title, and performance details of the content.
    /// The Windows Media Format SDK includes a large selection of predefined metadata attributes that you can
    /// use in your files. See Attributes for a complete listing of predefined attributes. Additionally, you can
    /// create your own attributes.
    /// 
    /// The methods of IWMHeaderInfo that deal with metadata are somewhat limited. They cannot be used to
    /// create or access attributes containing more than 64 kilobytes of data. They are also limited to simple
    /// data types. Much more robust metadata support is provided through the IWMHeaderInfo3 interface, which
    /// should be used for all new files.
    /// 
    /// Markers enable you to name specific locations in the file for easy access. Typically, markers are used
    /// to create a table of contents for a file, such as a list of scenes in a video file.
    /// 
    /// Script commands are name/value pairs containing information that your reading application will respond
    /// to programmatically. There are no script commands that are directly supported by the reader or the
    /// synchronous reader, but there are a few standard script commands supported by Windows Media Player.
    /// For more information about script commands, see the Using Script Commands section of this documentation.
    /// 
    /// The IWMHeaderInfo interface is implemented by the metadata editor object, the writer object, the reader
    /// object, and the synchronous reader object. To obtain a pointer to an instance, call the QueryInterface
    /// method of any other interface in the desired object.
    /// 
    /// Methods
    /// 
    /// The IWMHeaderInfo interface inherits the methods of the IUnknown interface.
    /// </summary>
    [ComImport]
    [Guid("96406BDA-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMHeaderInfo
    {
        /// <summary>
        /// Returns the number of attributes defined in the ASF file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Pass zero for file-level attributes.</param>
        /// <param name="pcAttributes">Pointer to a count of the attributes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetAttributeCount([In] ushort wStreamNum, [Out] out ushort pcAttributes);
        /// <summary>
        /// Returns a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwStreamNum">Pointer to a WORD containing the stream number. Although this parameter is
        /// a pointer, the method will not change the value. For file-level attributes, use zero for the stream
        /// number.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name. Pass NULL
        /// to this parameter to retrieve the required length for the name. Attribute names are limited to 1024
        /// wide characters.</param>
        /// <param name="pcchNameLen">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the actual
        /// length of the name, including the terminating null character.</param>
        /// <param name="pType">Pointer to a variable containing one value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the value. Pass NULL to this parameter to retrieve
        /// the required length for the value.</param>
        /// <param name="pcbLength">On input, a pointer to a variable containing the length of the pValue array,
        /// in bytes. On output, if the method succeeds, the variable contains the actual number of bytes written
        /// to pValue by the method.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetAttributeByIndex([In] ushort wIndex,
                                 [In, Out] ref ushort pwStreamNum,
                                 [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                                 [In, Out] ref ushort pcchNameLen,
                                 [Out] out WMT_ATTR_DATATYPE pType,
                                 IntPtr pValue,
                                 [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Returns a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="pwStreamNum">Pointer to a WORD containing the stream number, or zero to indicate any stream.
        /// Although this parameter is a pointer, the method does not change the value.</param>
        /// <param name="pszName">Pointer to a null-terminated string containing the name of the attribute. Attribute
        /// names are limited to 1024 wide characters.</param>
        /// <param name="pType">Pointer to a variable that receives a value from the WMT_ATTR_DATATYPE enumeration type.
        /// The returned value specifies the data type of the attribute.</param>
        /// <param name="pValue">Pointer to a byte array that receives the value of the attribute. The caller must
        /// allocate the array. To determine the required array size, set this parameter to NULL and check the
        /// value returned in the pcbLength parameter.</param>
        /// <param name="pcbLength">On input, the length of the pValue array, in bytes. On output, if the method
        /// succeeds, the actual number of bytes that were written to pValue.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetAttributeByName([In, Out] ref ushort pwStreamNum,
                                [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
                                [Out] out WMT_ATTR_DATATYPE pType,
                                IntPtr pValue,
                                [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Sets a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. To set a file-level attribute, pass zero.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the name of the
        /// attribute. Attribute names are limited to 1024 wide characters.</param>
        /// <param name="Type">A value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the value of the attribute.</param>
        /// <param name="cbLength">The size of pValue, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void SetAttribute([In] ushort wStreamNum,
                          [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
                          [In] WMT_ATTR_DATATYPE Type,
                          IntPtr pValue,
                          [In] ushort cbLength);
        /// <summary>
        /// Returns the number of markers currently in the ASF file header.
        /// </summary>
        /// <param name="pcMarkers">Pointer to a count of markers.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetMarkerCount([Out] out ushort pcMarkers);
        /// <summary>
        /// Returns the name and time of a marker.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwszMarkerName">Pointer to a wide-character null-terminated string containing the marker name.</param>
        /// <param name="pcchMarkerNameLen">On input, a pointer to a variable containing the length of the
        /// pwszMarkerName array in wide characters (2 bytes). On output, if the method succeeds, the variable
        /// contains the actual length of the name, including the terminating null character. To retrieve the
        /// length of the name, you must set this to zero and set pwszMarkerName and pcnsMarkerTime to NULL.</param>
        /// <param name="pcnsMarkerTime">Pointer to a variable specifying the marker time in 100-nanosecond
        /// increments.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMarker([In] ushort wIndex,
                       [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszMarkerName,
                       [In, Out] ref ushort pcchMarkerNameLen,
                       [Out] out ulong pcnsMarkerTime);
        /// <summary>
        /// Adds a marker, consisting of a name and a specific time, to the ASF file header.
        /// </summary>
        /// <param name="pwszMarkerName">Pointer to a wide-character null-terminated string containing the marker name.
        /// Marker names are limited to 5120 wide characters.</param>
        /// <param name="cnsMarkerTime">The marker time in 100-nanosecond increments.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddMarker([In, MarshalAs(UnmanagedType.LPWStr)] string pwszMarkerName,
                       [In] ulong cnsMarkerTime);
        /// <summary>
        /// Removes a marker from the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index of the marker.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveMarker([In] ushort wIndex);
        /// <summary>
        /// Returns the number of scripts currently in the ASF file header.
        /// </summary>
        /// <param name="pcScripts">Pointer to a count of scripts.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetScriptCount([Out] out ushort pcScripts);
        /// <summary>
        /// Returns the type and command strings, and time of a script.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwszType">Pointer to a wide-character null-terminated string buffer into which the type is
        /// copied.</param>
        /// <param name="pcchTypeLen">On input, a pointer to a variable containing the length of the pwszType array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the actual
        /// length of the string loaded into pwszType, including the terminating null character. To retrieve the
        /// length of the type, you must set this to zero and set pwszType to NULL.</param>
        /// <param name="pwszCommand">Pointer to a wide-character null-terminated string buffer into which the command
        /// is copied.</param>
        /// <param name="pcchCommandLen">On input, a pointer to a variable containing the length of the pwszCommand
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains the
        /// actual length of the command string, including the terminating null character. To retrieve the
        /// length of the command, you must set this to zero and set pwszCommand to NULL.</param>
        /// <param name="pcnsScriptTime">Pointer to a QWORD specifying the presentation time of this script command
        /// in 100-nanosecond increments.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetScript([In] ushort wIndex,
                       [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszType,
                       [In, Out] ref ushort pcchTypeLen,
                       [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszCommand,
                       [In, Out] ref ushort pcchCommandLen,
                       [Out] out ulong pcnsScriptTime);
        /// <summary>
        /// Adds a script, consisting of type and command strings, and a specific time, to the ASF file header.
        /// </summary>
        /// <param name="pwszType">Pointer to a wide-character null-terminated string containing the type. Script types
        /// are limited to 1024 wide characters.</param>
        /// <param name="pwszCommand">Pointer to a wide-character null-terminated string containing the command.
        /// Script commands are limited to 10240 wide characters.</param>
        /// <param name="cnsScriptTime">The script time in 100-nanosecond increments.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddScript([In, MarshalAs(UnmanagedType.LPWStr)] string pwszType,
                       [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommand,
                       [In] ulong cnsScriptTime);
        /// <summary>
        /// Removes a script from the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index of the script.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveScript([In] ushort wIndex);
    }
    /// <summary>
    /// The IWMHeaderInfo2 interface exposes information about the codecs used to create the content in a file.
    /// 
    /// The IWMHeaderInfo2 interface is implemented by the metadata editor object, the writer object, the reader
    /// object, and the synchronous reader object. To obtain a pointer to an instance, call the QueryInterface
    /// method of any other interface in the desired object.
    /// 
    /// Methods
    /// 
    /// The IWMHeaderInfo2 interface inherits from IWMHeaderInfo.
    /// </summary>
    [ComImport]
    [Guid("15CF9781-454E-482e-B393-85FAE487A810")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMHeaderInfo2 : IWMHeaderInfo
    {
        /// <summary>
        /// Returns the number of attributes defined in the ASF file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Pass zero for file-level attributes.</param>
        /// <param name="pcAttributes">Pointer to a count of the attributes.</param>
        new void GetAttributeCount([In] ushort wStreamNum, [Out] out ushort pcAttributes);
        /// <summary>
        /// Returns a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwStreamNum">Pointer to a WORD containing the stream number. Although this parameter is
        /// a pointer, the method will not change the value. For file-level attributes, use zero for the stream
        /// number.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name. Pass NULL
        /// to this parameter to retrieve the required length for the name. Attribute names are limited to 1024
        /// wide characters.</param>
        /// <param name="pcchNameLen">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the actual
        /// length of the name, including the terminating null character.</param>
        /// <param name="pType">Pointer to a variable containing one value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the value. Pass NULL to this parameter to retrieve
        /// the required length for the value.</param>
        /// <param name="pcbLength">On input, a pointer to a variable containing the length of the pValue array,
        /// in bytes. On output, if the method succeeds, the variable contains the actual number of bytes written
        /// to pValue by the method.</param>
        new void GetAttributeByIndex([In] ushort wIndex,
         [In, Out] ref ushort pwStreamNum,
         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
         [In, Out] ref ushort pcchNameLen,
         [Out] out WMT_ATTR_DATATYPE pType,
         IntPtr pValue,
         [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Returns a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="pwStreamNum">Pointer to a WORD containing the stream number, or zero to indicate any stream.
        /// Although this parameter is a pointer, the method does not change the value.</param>
        /// <param name="pszName">Pointer to a null-terminated string containing the name of the attribute. Attribute
        /// names are limited to 1024 wide characters.</param>
        /// <param name="pType">Pointer to a variable that receives a value from the WMT_ATTR_DATATYPE enumeration type.
        /// The returned value specifies the data type of the attribute.</param>
        /// <param name="pValue">Pointer to a byte array that receives the value of the attribute. The caller must
        /// allocate the array. To determine the required array size, set this parameter to NULL and check the
        /// value returned in the pcbLength parameter.</param>
        /// <param name="pcbLength">On input, the length of the pValue array, in bytes. On output, if the method
        /// succeeds, the actual number of bytes that were written to pValue.</param>
        new void GetAttributeByName([In, Out] ref ushort pwStreamNum,
         [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
         [Out] out WMT_ATTR_DATATYPE pType,
         IntPtr pValue,
         [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Sets a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. To set a file-level attribute, pass zero.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the name of the
        /// attribute. Attribute names are limited to 1024 wide characters.</param>
        /// <param name="Type">A value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the value of the attribute.</param>
        /// <param name="cbLength">The size of pValue, in bytes.</param>
        new void SetAttribute([In] ushort wStreamNum,
         [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
         [In] WMT_ATTR_DATATYPE Type,
         IntPtr pValue,
         [In] ushort cbLength);
        /// <summary>
        /// Returns the number of markers currently in the ASF file header.
        /// </summary>
        /// <param name="pcMarkers">Pointer to a count of markers.</param>
        new void GetMarkerCount([Out] out ushort pcMarkers);
        /// <summary>
        /// Returns the name and time of a marker.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwszMarkerName">Pointer to a wide-character null-terminated string containing the marker name.</param>
        /// <param name="pcchMarkerNameLen">On input, a pointer to a variable containing the length of the
        /// pwszMarkerName array in wide characters (2 bytes). On output, if the method succeeds, the variable
        /// contains the actual length of the name, including the terminating null character. To retrieve the
        /// length of the name, you must set this to zero and set pwszMarkerName and pcnsMarkerTime to NULL.</param>
        /// <param name="pcnsMarkerTime">Pointer to a variable specifying the marker time in 100-nanosecond
        /// increments.</param>
        new void GetMarker([In] ushort wIndex,
         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszMarkerName,
         [In, Out] ref ushort pcchMarkerNameLen,
         [Out] out ulong pcnsMarkerTime);
        /// <summary>
        /// Adds a marker, consisting of a name and a specific time, to the ASF file header.
        /// </summary>
        /// <param name="pwszMarkerName">Pointer to a wide-character null-terminated string containing the marker name.
        /// Marker names are limited to 5120 wide characters.</param>
        /// <param name="cnsMarkerTime">The marker time in 100-nanosecond increments.</param>
        new void AddMarker([In, MarshalAs(UnmanagedType.LPWStr)] string pwszMarkerName,
         [In] ulong cnsMarkerTime);
        /// <summary>
        /// Removes a marker from the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index of the marker.</param>
        new void RemoveMarker([In] ushort wIndex);
        /// <summary>
        /// Returns the number of scripts currently in the ASF file header.
        /// </summary>
        /// <param name="pcScripts">Pointer to a count of scripts.</param>
        new void GetScriptCount([Out] out ushort pcScripts);
        /// <summary>
        /// Returns the type and command strings, and time of a script.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwszType">Pointer to a wide-character null-terminated string buffer into which the type is
        /// copied.</param>
        /// <param name="pcchTypeLen">On input, a pointer to a variable containing the length of the pwszType array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the actual
        /// length of the string loaded into pwszType, including the terminating null character. To retrieve the
        /// length of the type, you must set this to zero and set pwszType to NULL.</param>
        /// <param name="pwszCommand">Pointer to a wide-character null-terminated string buffer into which the command
        /// is copied.</param>
        /// <param name="pcchCommandLen">On input, a pointer to a variable containing the length of the pwszCommand
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains the
        /// actual length of the command string, including the terminating null character. To retrieve the
        /// length of the command, you must set this to zero and set pwszCommand to NULL.</param>
        /// <param name="pcnsScriptTime">Pointer to a QWORD specifying the presentation time of this script command
        /// in 100-nanosecond increments.</param>
        new void GetScript([In] ushort wIndex,
         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszType,
         [In, Out] ref ushort pcchTypeLen,
         [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszCommand,
         [In, Out] ref ushort pcchCommandLen,
         [Out] out ulong pcnsScriptTime);
        /// <summary>
        /// Adds a script, consisting of type and command strings, and a specific time, to the ASF file header.
        /// </summary>
        /// <param name="pwszType">Pointer to a wide-character null-terminated string containing the type. Script types
        /// are limited to 1024 wide characters.</param>
        /// <param name="pwszCommand">Pointer to a wide-character null-terminated string containing the command.
        /// Script commands are limited to 10240 wide characters.</param>
        /// <param name="cnsScriptTime">The script time in 100-nanosecond increments.</param>
        new void AddScript([In, MarshalAs(UnmanagedType.LPWStr)] string pwszType,
         [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommand,
         [In] ulong cnsScriptTime);
        /// <summary>
        /// Removes a script from the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index of the script.</param>
        new void RemoveScript([In] ushort wIndex);
        /// <summary>
        /// Retrieves the number of codecs for which information is available.
        /// </summary>
        /// <param name="pcCodecInfos">Pointer to a count of codecs for which information is available.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetCodecInfoCount([Out] out uint pcCodecInfos);
        /// <summary>
        /// Retrieves information about a codec.
        /// </summary>
        /// <param name="wIndex">DWORD containing the zero-based codec index.</param>
        /// <param name="pcchName">On input, pointer to the length of pwszName in wide characters. On output, pointer
        /// to a count of the characters used in pwszName, including the terminating null character.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string buffer into which the name of
        /// the codec is copied.</param>
        /// <param name="pcchDescription">On input, pointer to the length of pwszDescription in wide characters.
        /// On output, pointer to a count of the characters used in pwszDescription, including the terminating
        /// null character.</param>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string buffer into which
        /// the description of the codec is copied.</param>
        /// <param name="pCodecType">Pointer to one member of the <see cref="WMT_CODEC_INFO_TYPE"/> enumeration
        /// type.</param>
        /// <param name="pcbCodecInfo">On input, pointer to the length of pbCodecInfo, in bytes. On output, pointer to
        /// a count of the bytes used in pbCodecInfo.</param>
        /// <param name="pbCodecInfo">Pointer to a byte array.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetCodecInfo([In] uint wIndex,
                          [In, Out] ref ushort pcchName,
                          [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
                          [In, Out] ref ushort pcchDescription,
                          [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
                          [Out] out WMT_CODEC_INFO_TYPE pCodecType,
                          [In, Out] ref ushort pcbCodecInfo,
                          [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pbCodecInfo);
    }
    /// <summary>
    /// The IWMHeaderInfo3 interface supports the following new metadata features:
    /// 
    /// * Attribute data in excess of 64 kilobytes.
    /// * Multiple attributes with the same name.
    /// * Attributes in multiple languages.
    /// 
    /// Because the attributes created using this interface can have duplicate names, the methods of this
    /// interface use index values to identify attributes.
    /// 
    /// The IWMHeaderInfo3 interface is implemented by the metadata editor object, the writer object, the reader
    /// object, and the synchronous reader object. To obtain a pointer to an instance, call the QueryInterface
    /// method of any other interface in the desired object.
    /// </summary>
    [ComImport]
    [Guid("15CC68E3-27CC-4ecd-B222-3F5D02D80BD5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMHeaderInfo3 : IWMHeaderInfo2
    {
        /// <summary>
        /// Returns the number of attributes defined in the ASF file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Pass zero for file-level attributes.</param>
        /// <param name="pcAttributes">Pointer to a count of the attributes.</param>
        new void GetAttributeCount([In] ushort wStreamNum, [Out] out ushort pcAttributes);
        /// <summary>
        /// Returns a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwStreamNum">Pointer to a WORD containing the stream number. Although this parameter is
        /// a pointer, the method will not change the value. For file-level attributes, use zero for the stream
        /// number.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name. Pass NULL
        /// to this parameter to retrieve the required length for the name. Attribute names are limited to 1024
        /// wide characters.</param>
        /// <param name="pcchNameLen">On input, a pointer to a variable containing the length of the pwszName array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the actual
        /// length of the name, including the terminating null character.</param>
        /// <param name="pType">Pointer to a variable containing one value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the value. Pass NULL to this parameter to retrieve
        /// the required length for the value.</param>
        /// <param name="pcbLength">On input, a pointer to a variable containing the length of the pValue array,
        /// in bytes. On output, if the method succeeds, the variable contains the actual number of bytes written
        /// to pValue by the method.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetAttributeByIndex(
            [In]									ushort wIndex,
            [Out, In]								ref ushort pwStreamNum,
            [Out, MarshalAs(UnmanagedType.LPWStr)]	string pwszName,
            [Out, In]								ref ushort pcchNameLen,
            [Out]									out WMT_ATTR_DATATYPE pType,
            [Out, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
            [Out, In]								ref ushort pcbLength);
        /// <summary>
        /// Returns a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="pwStreamNum">Pointer to a WORD containing the stream number, or zero to indicate any stream.
        /// Although this parameter is a pointer, the method does not change the value.</param>
        /// <param name="pszName">Pointer to a null-terminated string containing the name of the attribute. Attribute
        /// names are limited to 1024 wide characters.</param>
        /// <param name="pType">Pointer to a variable that receives a value from the WMT_ATTR_DATATYPE enumeration type.
        /// The returned value specifies the data type of the attribute.</param>
        /// <param name="pValue">Pointer to a byte array that receives the value of the attribute. The caller must
        /// allocate the array. To determine the required array size, set this parameter to NULL and check the
        /// value returned in the pcbLength parameter.</param>
        /// <param name="pcbLength">On input, the length of the pValue array, in bytes. On output, if the method
        /// succeeds, the actual number of bytes that were written to pValue.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetAttributeByName([In, Out] ref ushort pwStreamNum,
           [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
           [Out] out WMT_ATTR_DATATYPE pType,
           [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pValue,
           [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Sets a descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. To set a file-level attribute, pass zero.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the name of the
        /// attribute. Attribute names are limited to 1024 wide characters.</param>
        /// <param name="Type">A value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the value of the attribute.</param>
        /// <param name="cbLength">The size of pValue, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void SetAttribute(
            [In]									ushort wStreamNum,
            [In, MarshalAs(UnmanagedType.LPWStr)]	string pszName,
            [In]									WMT_ATTR_DATATYPE Type,
            [In, MarshalAs(UnmanagedType.LPArray)]	byte[] pValue,
            [In]									ushort cbLength);
        /// <summary>
        /// Returns the number of markers currently in the ASF file header.
        /// </summary>
        /// <param name="pcMarkers">Pointer to a count of markers.</param>
        new void GetMarkerCount([Out] out ushort pcMarkers);
        /// <summary>
        /// Returns the name and time of a marker.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwszMarkerName">Pointer to a wide-character null-terminated string containing the marker name.</param>
        /// <param name="pcchMarkerNameLen">On input, a pointer to a variable containing the length of the
        /// pwszMarkerName array in wide characters (2 bytes). On output, if the method succeeds, the variable
        /// contains the actual length of the name, including the terminating null character. To retrieve the
        /// length of the name, you must set this to zero and set pwszMarkerName and pcnsMarkerTime to NULL.</param>
        /// <param name="pcnsMarkerTime">Pointer to a variable specifying the marker time in 100-nanosecond
        /// increments.</param>
        new void GetMarker([In] ushort wIndex,
           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszMarkerName,
           [In, Out] ref ushort pcchMarkerNameLen,
           [Out] out ulong pcnsMarkerTime);
        /// <summary>
        /// Adds a marker, consisting of a name and a specific time, to the ASF file header.
        /// </summary>
        /// <param name="pwszMarkerName">Pointer to a wide-character null-terminated string containing the marker name.
        /// Marker names are limited to 5120 wide characters.</param>
        /// <param name="cnsMarkerTime">The marker time in 100-nanosecond increments.</param>
        new void AddMarker([In, MarshalAs(UnmanagedType.LPWStr)] string pwszMarkerName,
           [In] ulong cnsMarkerTime);
        /// <summary>
        /// Removes a marker from the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index of the marker.</param>
        new void RemoveMarker([In] ushort wIndex);
        /// <summary>
        /// Returns the number of scripts currently in the ASF file header.
        /// </summary>
        /// <param name="pcScripts">Pointer to a count of scripts.</param>
        new void GetScriptCount([Out] out ushort pcScripts);
        /// <summary>
        /// Returns the type and command strings, and time of a script.
        /// </summary>
        /// <param name="wIndex">WORD containing the index.</param>
        /// <param name="pwszType">Pointer to a wide-character null-terminated string buffer into which the type is
        /// copied.</param>
        /// <param name="pcchTypeLen">On input, a pointer to a variable containing the length of the pwszType array
        /// in wide characters (2 bytes). On output, if the method succeeds, the variable contains the actual
        /// length of the string loaded into pwszType, including the terminating null character. To retrieve the
        /// length of the type, you must set this to zero and set pwszType to NULL.</param>
        /// <param name="pwszCommand">Pointer to a wide-character null-terminated string buffer into which the command
        /// is copied.</param>
        /// <param name="pcchCommandLen">On input, a pointer to a variable containing the length of the pwszCommand
        /// array in wide characters (2 bytes). On output, if the method succeeds, the variable contains the
        /// actual length of the command string, including the terminating null character. To retrieve the
        /// length of the command, you must set this to zero and set pwszCommand to NULL.</param>
        /// <param name="pcnsScriptTime">Pointer to a QWORD specifying the presentation time of this script command
        /// in 100-nanosecond increments.</param>
        new void GetScript([In] ushort wIndex,
           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszType,
           [In, Out] ref ushort pcchTypeLen,
           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszCommand,
           [In, Out] ref ushort pcchCommandLen,
           [Out] out ulong pcnsScriptTime);
        /// <summary>
        /// Adds a script, consisting of type and command strings, and a specific time, to the ASF file header.
        /// </summary>
        /// <param name="pwszType">Pointer to a wide-character null-terminated string containing the type. Script types
        /// are limited to 1024 wide characters.</param>
        /// <param name="pwszCommand">Pointer to a wide-character null-terminated string containing the command.
        /// Script commands are limited to 10240 wide characters.</param>
        /// <param name="cnsScriptTime">The script time in 100-nanosecond increments.</param>
        new void AddScript([In, MarshalAs(UnmanagedType.LPWStr)] string pwszType,
           [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommand,
           [In] ulong cnsScriptTime);
        /// <summary>
        /// Removes a script from the ASF file header.
        /// </summary>
        /// <param name="wIndex">WORD containing the index of the script.</param>
        new void RemoveScript([In] ushort wIndex);
        /// <summary>
        /// Retrieves the number of codecs for which information is available.
        /// </summary>
        /// <param name="pcCodecInfos">Pointer to a count of codecs for which information is available.</param>
        new void GetCodecInfoCount([Out] out uint pcCodecInfos);
        /// <summary>
        /// Retrieves information about a codec.
        /// </summary>
        /// <param name="wIndex">DWORD containing the zero-based codec index.</param>
        /// <param name="pcchName">On input, pointer to the length of pwszName in wide characters. On output, pointer
        /// to a count of the characters used in pwszName, including the terminating null character.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string buffer into which the name of
        /// the codec is copied.</param>
        /// <param name="pcchDescription">On input, pointer to the length of pwszDescription in wide characters.
        /// On output, pointer to a count of the characters used in pwszDescription, including the terminating
        /// null character.</param>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string buffer into which
        /// the description of the codec is copied.</param>
        /// <param name="pCodecType">Pointer to one member of the <see cref="WMT_CODEC_INFO_TYPE"/> enumeration
        /// type.</param>
        /// <param name="pcbCodecInfo">On input, pointer to the length of pbCodecInfo, in bytes. On output, pointer to
        /// a count of the bytes used in pbCodecInfo.</param>
        /// <param name="pbCodecInfo">Pointer to a byte array.</param>
        new void GetCodecInfo([In] uint wIndex,
           [In, Out] ref ushort pcchName,
           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
           [In, Out] ref ushort pcchDescription,
           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszDescription,
           [Out] out WMT_CODEC_INFO_TYPE pCodecType,
           [In, Out] ref ushort pcbCodecInfo,
           [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pbCodecInfo);
        /// <summary>
        /// Retrieves the total number of attributes in the file header.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number for which to retrieve the attribute count.
        /// Pass zero to retrieve the count of attributes that apply to the file rather than a specific stream.
        /// Pass 0xFFFF to retrieve the total count of all attributes in the file, both stream-specific and
        /// file-level.</param>
        /// <param name="pcAttributes">Pointer to a WORD containing the number of attributes that exist for the
        /// specified stream.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        void GetAttributeCountEx([In] ushort wStreamNum, [Out] out ushort pcAttributes);
        /// <summary>
        /// Retrieves a list of all the indices of attributes for a specified language.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number for which to retrieve attribute indices. Passing
        /// zero retrieves indices for file-level attributes. Passing 0xFFFF retrieves indices for all
        /// appropriate attributes, regardless of their association to streams.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the attribute name for
        /// which you want to retrieve indices. Pass NULL to retrieve indices for attributes based on language.
        /// Attribute names are limited to 1024 wide characters.</param>
        /// <param name="pwLangIndex">Pointer to a WORD containing the language index of the language for which to
        /// retrieve attribute indices. Pass NULL to retrieve indices for attributes by name.</param>
        /// <param name="pwIndices">Pointer to a WORD array containing the indices that meet the criteria described by
        /// the input parameters. Pass NULL to retrieve the size of the array, which will be returned in pwCount.</param>
        /// <param name="pwCount">On output, pointer to a WORD containing the number of elements in the pwIndices
        /// array.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void GetAttributeIndices([In] ushort wStreamNum,
           [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            /* DWORD* */IntPtr pwLangIndex,
           [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pwIndices,
           [In, Out] ref ushort pwCount);
        /// <summary>
        /// Retrieves an attribute by its index.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number to which the attribute applies. Set to zero to
        /// retrieve a file-level attribute.</param>
        /// <param name="wIndex">WORD containing the index of the attribute to be retrieved.</param>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the attribute name.
        /// Pass NULL to retrieve the size of the string, which will be returned in pwNameLen.</param>
        /// <param name="pwNameLen">Pointer to a WORD containing the size of pwszName, in wide characters. This size
        /// includes the terminating null character. Attribute names are limited to 1024 wide characters.</param>
        /// <param name="pType">Type of data used for the attribute. For more information about the types of data supported,
        /// see <see cref="WMT_ATTR_DATATYPE"/>.</param>
        /// <param name="pwLangIndex">Pointer to a WORD containing the language index of the language associated with
        /// the attribute. This is the index of the language in the language list for the file.</param>
        /// <param name="pValue">Pointer to an array of bytes containing the attribute value. Pass NULL to retrieve the
        /// size of the attribute value, which will be returned in pdwDataLength.</param>
        /// <param name="pdwDataLength">Pointer to a DWORD containing the length, in bytes, of the attribute value
        /// pointed to by pValue.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        void GetAttributeByIndexEx([In] ushort wStreamNum,
           [In] ushort wIndex,
           [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszName,
           [In, Out] ref ushort pwNameLen,
           [Out] out WMT_ATTR_DATATYPE pType,
           [Out] out ushort pwLangIndex,
           IntPtr pValue,
           [In, Out] ref uint pdwDataLength);
        /// <summary>
        /// Changes the settings of an existing attribute.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number to which the attribute applies. Pass zero for
        /// file-level attributes.</param>
        /// <param name="wIndex">WORD containing the index of the attribute to change.</param>
        /// <param name="Type">Type of data used for the new attribute value. For more information about the types of
        /// data supported, see <see cref="WMT_ATTR_DATATYPE"/>.</param>
        /// <param name="wLangIndex">WORD containing the language index of the language to be associated with
        /// the new attribute. This is the index of the language in the language list for the file.</param>
        /// <param name="pValue">Pointer to an array of bytes containing the attribute value.</param>
        /// <param name="dwLength">DWORD containing the length of the attribute value, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void ModifyAttribute([In] ushort wStreamNum,
           [In] ushort wIndex,
           [In] WMT_ATTR_DATATYPE Type,
           [In] ushort wLangIndex,
           IntPtr pValue,
           [In] uint dwLength);
        /// <summary>
        /// Adds an attribute for a specified language.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number of the stream to which the attribute applies.
        /// Setting this value to zero indicates an attribute that applies to the entire file.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the name of the
        /// attribute. Attribute names are limited to 1024 wide characters.</param>
        /// <param name="pwIndex">Pointer to a WORD. On successful completion of the method, this value is set to the
        /// index assigned to the new attribute.</param>
        /// <param name="Type">Type of data used for the new attribute. For more information about the types of data
        /// supported, see <see cref="WMT_ATTR_DATATYPE"/>.</param>
        /// <param name="wLangIndex">WORD containing the language index of the language to be associated with the new
        /// attribute. This is the index of the language in the language list for the file. Setting this value to
        /// zero indicates that the default language will be used. A default language is created and set
        /// according to the regional settings on the computer running your application.</param>
        /// <param name="pValue">Pointer to an array of bytes containing the attribute value.</param>
        /// <param name="dwLength">DWORD containing the length of the attribute value, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void AddAttribute([In] ushort wStreamNum,
                          [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
                          [Out] out ushort pwIndex,
                          [In] WMT_ATTR_DATATYPE Type,
                          [In] ushort wLangIndex,
                          IntPtr pValue,
                          [In] uint dwLength);
        /// <summary>
        /// Deletes an attribute using the attribute index.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number for which the attribute applies. Setting this
        /// value to zero indicates a file-level attribute.</param>
        /// <param name="wIndex">WORD containing the index of the attribute to be deleted.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void DeleteAttribute([In] ushort wStreamNum, [In] ushort wIndex);
        /// <summary>
        /// Adds information about a codec that was used to compress data in the file.
        /// </summary>
        /// <param name="pwszName">Pointer to a wide-character null-terminated string containing the name.</param>
        /// <param name="pwszDescription">Pointer to a wide-character null-terminated string containing the description.</param>
        /// <param name="codecType">A value from the <see cref="WMT_CODEC_INFO_TYPE"/> enumeration specifying the codec type.</param>
        /// <param name="cbCodecInfo">The size of the codec information, in bytes.</param>
        /// <param name="pbCodecInfo">Pointer to an array of bytes that contains the codec information.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddCodecInfo([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
                          [In, MarshalAs(UnmanagedType.LPWStr)] string pwszDescription,
                          [In] WMT_CODEC_INFO_TYPE codecType,
                          [In] ushort cbCodecInfo,
                          [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pbCodecInfo);
    }
    /// <summary>
    /// The IWMMetadataEditor interface is used to edit metadata information in ASF file headers. It is obtained by
    /// calling the <see cref="WMCreateEditor"/> function.
    /// </summary>
    [ComImport]
    [Guid("96406BD9-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMetadataEditor
    {
        /// <summary>
        /// Opens an ASF file.
        /// </summary>
        /// <param name="pwszFilename"></param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
        /// <summary>
        /// Closes the currently open file without writing any changes to the metadata back to the disk.
        /// </summary>
        void Close();
        /// <summary>
        /// Closes the currently open file, writing any changes to the metadata back to the disk.
        /// </summary>
        void Flush();
    }
    /// <summary>
    /// The IWMMetadataEditor2 interface provides an improved method for opening files for metadata operations.
    /// 
    /// This interface is implemented as part of the metadata editor object. To obtain a pointer to
    /// IWMMetadataEditor2, call the QueryInterface method of any other interface in an existing metadata editor
    /// object.
    /// 
    /// Methods
    /// 
    /// The IWMMetadataEditor2 interface inherits from <see cref="IWMMetadataEditor"/>.
    /// </summary>

    [Guid("203CFFE3-2E18-4fdf-B59D-6E71530534CF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMMetadataEditor2 : IWMMetadataEditor
    {
        /// <summary>
        /// Opens an ASF file.
        /// </summary>
        /// <param name="pwszFilename"></param>
        new void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
        /// <summary>
        /// Closes the currently open file without writing any changes to the metadata back to the disk.
        /// </summary>
        new void Close();
        /// <summary>
        /// Closes the currently open file, writing any changes to the metadata back to the disk.
        /// </summary>
        new void Flush();
        /// <summary>
        /// Opens a file so that the metadata can be accessed.
        /// </summary>
        /// <param name="pwszFilename">Pointer to a wide-character null-terminated string containing
        /// the file name.</param>
        /// <param name="dwDesiredAccess">DWORD containing the desired access type. This can be set to GENERIC_READ
        /// or GENERIC_WRITE. For read/write access, pass both values combined with a bitwise OR. When using
        /// GENERIC_READ, you must also pass a valid sharing mode as dwShareMode. Failure to do so will result
        /// in an error.</param>
        /// <param name="dwShareMode">DWORD containing the sharing mode. This can be one of the values in the following
        /// table or a combination of the two using a bitwise OR. A value of zero indicates no sharing. Sharing
        /// is not supported when requesting read/write access. If you request read/write access and pass any
        /// value other than zero for the share mode, an error is returned.</param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        void OpenEx([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename,
                    [In] uint dwDesiredAccess,
                    [In] uint dwShareMode);
    }
    /// <summary>
    /// The IWMIndexer interface is used to create an index for ASF files to enable seeking. An index is created
    /// only for a file that contains video, although the indexer can safely be used on files that do not contain
    /// any video.
    /// 
    /// An index is an object in the ASF file that equates video samples with presentation times. This is
    /// important because the timing of video frames is not necessarily easily computed from the frame rate.
    /// 
    /// In addition to the standard temporal index, the indexer object can create indexes based on video frame
    /// number and SMPTE time code. For more information about creating these indexes, see IWMIndexer.Configure.
    /// 
    /// This interface can be obtained by using the WMCreateIndexer function.
    /// 
    /// Methods
    /// 
    /// The IWMIndexer interface inherits the methods of the IUnknown interface.
    /// </summary>
    [ComImport]
    [Guid("6d7cdc71-9888-11d3-8edc-00c04f6109cf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMIndexer
    {
        /// <summary>
        /// Initiates indexing.
        /// </summary>
        /// <param name="pwszURL">Pointer to a wide-character null-terminated string containing the URL or file name.</param>
        /// <param name="pCallback">Pointer to an <see cref="IWMStatusCallback"/> interface.</param>
        /// <param name="pvContext">Generic pointer, for use by the application.</param>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void StartIndexing([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
                           [In, MarshalAs(UnmanagedType.Interface)] IWMStatusCallback pCallback,
                           [In] IntPtr pvContext);
        /// <summary>
        /// Cancels indexing.
        /// </summary>
        void Cancel();
    }
    /// <summary>
    /// The IWMIndexer2 interface enables you to change the settings of the indexer object to suit your needs.
    /// 
    /// This interface is implemented as part of the indexer object. To obtain a pointer to IWMIndexer2, call
    /// the QueryInterface method of the <see cref="IWMIndexer"/> interface.
    /// 
    /// Methods
    /// 
    /// The IWMIndexer2 interface inherits from <see cref="IWMIndexer"/>.
    /// </summary>
    [ComImport]
    [Guid("B70F1E42-6255-4df0-A6B9-02B212D9E2BB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMIndexer2 : IWMIndexer
    {
        /// <summary>
        /// Initiates indexing.
        /// </summary>
        /// <param name="pwszURL">Pointer to a wide-character null-terminated string containing the URL or file name.</param>
        /// <param name="pCallback">Pointer to an <see cref="IWMStatusCallback"/> interface.</param>
        /// <param name="pvContext">Generic pointer, for use by the application.</param>
        new void StartIndexing([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
         [In, MarshalAs(UnmanagedType.Interface)] IWMStatusCallback pCallback,
         [In] IntPtr pvContext);
        /// <summary>
        /// Cancels indexing.
        /// </summary>
        new void Cancel();
        /// <summary>
        /// Enables custom configuration of the indexer object.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number for which an index is to be made. If you pass 0,
        /// all streams will be indexed.</param>
        /// <param name="nIndexerType">A variable containing one member of the <see cref="WMT_INDEXER_TYPE"/>
        /// enumeration type.</param>
        /// <param name="pvInterval">This void pointer must point to a DWORD containing the desired indexing
        /// interval. Intervals for temporal indexing are in milliseconds. Frame-based index intervals are
        /// specified in frames.
        /// 
        /// If you pass NULL, Configure will use the default value. For temporal indexes, the default value is
        /// 3000 milliseconds, for frame-based indexes it is 10 frames.</param>
        /// <param name="pvIndexType">This void pointer must point to a WORD value containing one member of the
        /// <see cref="WMT_INDEX_TYPE"/> enumeration type. If you pass NULL, Configure will use the default value.
        /// 
        /// The default value is WMT_IT_NEAREST_CLEAN_POINT. Using another index type degrades seeking
        /// performance.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void Configure([In] ushort wStreamNum,
                          [In] WMT_INDEXER_TYPE nIndexerType,
                          [In] IntPtr pvInterval,
                          [In] IntPtr pvIndexType);
    }

}