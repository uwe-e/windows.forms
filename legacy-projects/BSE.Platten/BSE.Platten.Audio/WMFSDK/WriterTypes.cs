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
    /// The WM_WRITER_STATISTICS structure describes the performance of a writing operation.
    /// </summary>
    /// <remarks>
    /// Sample rates are specified in kilohertz. For instance, a sample rate of 8 indicates 8000 samples per second.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WM_WRITER_STATISTICS
    {
        /// <summary>
        /// QWORD containing the sample count.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ulong qwSampleCount;
        /// <summary>
        /// QWORD containing the byte count.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ulong qwByteCount;
        /// <summary>
        /// QWORD containing the dropped sample count.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ulong qwDroppedSampleCount;
        /// <summary>
        /// QWORD containing the dropped byte count.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ulong qwDroppedByteCount;
        /// <summary>
        /// DWORD containing the current bit rate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwCurrentBitrate;
        /// <summary>
        /// DWORD containing the average bit rate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwAverageBitrate;
        /// <summary>
        /// DWORD containing the expected bit rate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwExpectedBitrate;
        /// <summary>
        /// DWORD containing the current sample rate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwCurrentSampleRate;
        /// <summary>
        /// DWORD containing the average sample rate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwAverageSampleRate;
        /// <summary>
        /// DWORD containing the expected sample rate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwExpectedSampleRate;
    };
    /// <summary>
    /// The WM_WRITER_STATISTICS_EX structure is used by IWMWriterAdvanced3.GetStatisticsEx to obtain extended
    /// writer statistics.
    /// </summary>
    /// <remarks>
    /// Sample rates are given in kilohertz.
    /// 
    /// Basic writer statistics are contained within a WM_WRITER_STATISTICS structure and must be obtained by
    /// calling IWMWriterAdvanced.GetStatistics.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WM_WRITER_STATISTICS_EX
    {
        /// <summary>
        /// DWORD containing the bit rate plus any overhead.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwBitratePlusOverhead;
        /// <summary>
        /// DWORD containing the current rate at which samples are dropped in the queue in order to reduce
        /// demands on the CPU.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwCurrentSampleDropRateInQueue;
        /// <summary>
        /// DWORD containing the current rate at which samples are dropped in the codec. Samples can be dropped when
        /// they contain little new data. To prevent this from happening, call IWMWriterAdvanced2.SetInputSetting
        /// to set the g_wszFixedFrameRate setting to TRUE.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwCurrentSampleDropRateInCodec;
        /// <summary>
        /// DWORD containing the current rate at which samples are dropped in the multiplexer because they arrived
        /// late or overflowed the buffer window.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwCurrentSampleDropRateInMultiplexer;
        /// <summary>
        /// DWORD containing the total number of samples dropped in the queue.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwTotalSampleDropsInQueue;
        /// <summary>
        /// DWORD containing the total number of samples dropped in the codec.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwTotalSampleDropsInCodec;
        /// <summary>
        /// DWORD containing the total number of samples dropped in the multiplexer.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwTotalSampleDropsInMultiplexer;
    };
    /// <summary>
    /// The WMT_BUFFER_SEGMENT structure contains the information needed to specify a segment in a buffer.
    /// It is used as a member of the WMT_FILESINK_DATA_UNIT and WMT_PAYLOAD_FRAGMENT structures to specify
    /// segments of a packet.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WMT_BUFFER_SEGMENT
    {
        /// <summary>
        /// Pointer to a buffer object containing the buffer segment.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public INSSBuffer pBuffer;
        /// <summary>
        /// The offset, in bytes, from the start of the buffer to the buffer segment.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint cbOffset;
        /// <summary>
        /// The length, in bytes, of the buffer segment.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint cbLength;
    };
    /// <summary>
    /// The WMT_PAYLOAD_FRAGMENT structure contains the information needed to extract a payload fragment
    /// from a buffer and identifies the payload to which the fragment belongs. An array of WMT_PAYLOAD_FRAGMENT
    /// structures is used as a member of the WMT_FILESINK_DATA_UNIT structure to provide access to each payload fragment in a packet.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WMT_PAYLOAD_FRAGMENT
    {
        /// <summary>
        /// DWORD containing the payload index. This identifies the payload item to which this fragment belongs.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint dwPayloadIndex;
        /// <summary>
        /// A WMT_BUFFER_SEGMENT structure specifying the buffer segment containing the payload fragment.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public WMT_BUFFER_SEGMENT segmentData;
    };
    /// <summary>
    /// The WMT_FILESINK_DATA_UNIT structure is used by IWMWriterFileSink3.OnDataUnitEx to deliver information
    /// about a packet.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WMT_FILESINK_DATA_UNIT
    {
        /// <summary>
        /// A WMT_BUFFER_SEGMENT structure specifying the buffer segment that contains the packet header.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public WMT_BUFFER_SEGMENT packetHeaderBuffer;
        /// <summary>
        /// Count of payloads in this packet. This is also the number of elements in the array specified in pPayloadHeaderBuffers.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint cPayloads;
        /// <summary>
        /// Pointer to an array of WMT_BUFFER_SEGMENT structures. Each element specifies a buffer segment that
        /// contains a payload header. The number of elements is specified by cPayloads.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public IntPtr pPayloadHeaderBuffers;
        /// <summary>
        /// Count of payload data fragments in this packet. This is also the number of elements in the array pointed
        /// to by pPayloadDataFragments.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public uint cPayloadDataFragments;
        /// <summary>
        /// Pointer to an array of WMT_PAYLOAD_FRAGMENT structures. Each element specifies a buffer segment that
        /// contains a payload fragment. The number of elements is specified by cPayloadDataFragments.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")]
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public IntPtr pPayloadDataFragments;
    };
    /// <summary>
    /// The IWMWriterSink interface is the basic interface of all writer sinks, including the file, network,
    /// and push sinks defined in the Windows Media Format SDK, and custom sinks. If you are using one of the
    /// defined writer sinks, you never need to deal with the methods of this interface. If you are creating your
    /// own custom writer sink, you must implement these methods in your application.
    /// 
    /// This interface exists on the writer file sink object, the writer network sink object, and the writer
    /// push sink object. You should never obtain a pointer to this interface from one of these objects,
    /// however, as its methods are called internally by the writer sink objects and the writer object.
    /// You can create a class in your application that inherits from this interface to make your own sink.
    /// </summary>
    [ComImport]
    [Guid("96406BE4-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterSink
    {
        /// <summary>
        /// The OnHeader method is called by the writer when the ASF header is ready for the sink.
        /// </summary>
        /// <param name="pHeader">Pointer to an INSSBuffer interface on an object containing the ASF header.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void OnHeader([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pHeader);
        /// <summary>
        /// The IsRealTime is called by the writer to determine whether the sink needs data units to be delivered
        /// in real time. It is up to you to decide whether your custom sink requires real-time delivery.
        /// </summary>
        /// <param name="pfRealTime">Pointer to a Boolean value that is True if the sink requires real time data unit delivery.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        /// <summary>
        /// The AllocateDataUnit method is called by the writer object when it needs a buffer to deliver a data unit.
        /// Your implementation of this method returns a buffer of at least the size passed in. You can manage
        /// buffers internally in any way that you like. The simplest method is to create a new buffer object
        /// for each call, but doing so is quite inefficient. Instead, most sinks maintain several buffers
        /// that are reused.
        /// </summary>
        /// <param name="cbDataUnit">Size of the data unit that the writer needs to deliver, in bytes. The buffer
        /// you assign to ppDataUnit must be this size or bigger.</param>
        /// <param name="ppDataUnit">On return, set to a pointer to the INSSBuffer interface of a buffer object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AllocateDataUnit([In] uint cbDataUnit,
                              [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppDataUnit);
        /// <summary>
        /// The OnDataUnit method is called by the writer when a data unit is ready for the sink. How your application
        /// handles the data unit depends upon the destination of the content.
        /// </summary>
        /// <param name="pDataUnit">Pointer to an INSSBuffer interface on an object containing the data unit.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void OnDataUnit([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pDataUnit);
        /// <summary>
        /// The OnEndWriting method is called by the writer when writing is complete. This method should conclude
        /// operations for your sink. For example, the writer file sink closes and indexes the file.
        /// </summary>
        void OnEndWriting();
    }

    [ComImport]
    [Guid("96406BE5-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterFileSink : IWMWriterSink
    {
        //IWMWriterSink
        new void OnHeader([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pHeader);
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        new void AllocateDataUnit([In] uint cbDataUnit,
         [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppDataUnit);
        new void OnDataUnit([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pDataUnit);
        new void OnEndWriting();
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
    }

    [ComImport]
    [Guid("14282BA7-4AEF-4205-8CE5-C229035A05BC")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterFileSink2 : IWMWriterFileSink
    {
        //IWMWriterSink
        new void OnHeader([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pHeader);
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        new void AllocateDataUnit([In] uint cbDataUnit,
         [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppDataUnit);
        new void OnDataUnit([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pDataUnit);
        new void OnEndWriting();
        //IWMWriterFileSink
        new void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
        //IWMWriterFileSink2
        void Start([In] ulong cnsStartTime);
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
        void Stop([In] ulong cnsStopTime);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void IsStopped([Out, MarshalAs(UnmanagedType.Bool)] out bool pfStopped);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetFileDuration([Out] out ulong pcnsDuration);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetFileSize([Out] out ulong pcbFile);
        void Close();
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void IsClosed([Out, MarshalAs(UnmanagedType.Bool)] out bool pfClosed);
    }

    [ComImport]
    [Guid("3FEA4FEB-2945-47A7-A1DD-C53A8FC4C45C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterFileSink3 : IWMWriterFileSink2
    {
        //IWMWriterSink
        new void OnHeader([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pHeader);
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        new void AllocateDataUnit([In] uint cbDataUnit,
         [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppDataUnit);
        new void OnDataUnit([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pDataUnit);
        new void OnEndWriting();
        //IWMWriterFileSink
        new void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
        //IWMWriterFileSink2
        new void Start([In] ulong cnsStartTime);
        new void Stop([In] ulong cnsStopTime);
        new void IsStopped([Out, MarshalAs(UnmanagedType.Bool)] out bool pfStopped);
        new void GetFileDuration([Out] out ulong pcnsDuration);
        new void GetFileSize([Out] out ulong pcbFile);
        new void Close();
        new void IsClosed([Out, MarshalAs(UnmanagedType.Bool)] out bool pfClosed);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetAutoIndexing([In, MarshalAs(UnmanagedType.Bool)] bool fDoAutoIndexing);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetAutoIndexing([Out, MarshalAs(UnmanagedType.Bool)] out bool pfAutoIndexing);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetControlStream([In] ushort wStreamNumber,
                              [In, MarshalAs(UnmanagedType.Bool)] bool fShouldControlStartAndStop);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMode([Out] out uint pdwFileSinkMode);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        void OnDataUnitEx([In] ref WMT_FILESINK_DATA_UNIT pFileSinkDataUnit);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetUnbufferedIO([In, MarshalAs(UnmanagedType.Bool)] bool fUnbufferedIO,
                             [In, MarshalAs(UnmanagedType.Bool)] bool fRestrictMemUsage);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetUnbufferedIO([Out, MarshalAs(UnmanagedType.Bool)] out bool pfUnbufferedIO);
        void CompleteOperations();
    }
    /// <summary>
    /// The IWMWriterNetworkSink interface is used to deliver streams to the network. It inherits all the
    /// methods of IWMWriterSink, and adds methods to configure the network sink.
    /// 
    /// The network sink object exposes this interface. To create the network sink object,
    /// call the WMCreateWriterNetworkSink function.
    /// </summary>
    [ComImport]
    [Guid("96406BE7-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterNetworkSink : IWMWriterSink
    {
        //IWMWriterSink
        new void OnHeader([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pHeader);
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        new void AllocateDataUnit([In] uint cbDataUnit,
         [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppDataUnit);
        new void OnDataUnit([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pDataUnit);
        new void OnEndWriting();
        /// <summary>
        /// Sets the maximum number of clients that connect to this sink.
        /// </summary>
        /// <param name="dwMaxClients"></param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetMaximumClients([In] uint dwMaxClients);
        /// <summary>
        /// Retrieves the maximum number of clients that can connect to this sink.
        /// </summary>
        /// <param name="pdwMaxClients"></param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMaximumClients([Out] out uint pdwMaxClients);
        /// <summary>
        /// Sets the network protocol that the network sink uses.
        /// </summary>
        /// <param name="protocol"></param>
        void SetNetworkProtocol([In] WMT_NET_PROTOCOL protocol);
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetNetworkProtocol([Out] out WMT_NET_PROTOCOL pProtocol);
        /// <summary>
        /// Retrieves URL from which the stream is broadcast.
        /// </summary>
        /// <param name="pwszURL"></param>
        /// <param name="pcchURL"></param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void GetHostURL([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszURL,
                        [In, Out] ref uint pcchURL);
        /// <summary>
        /// Opens a network port.
        /// </summary>
        /// <param name="pdwPortNum"></param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void Open([In, Out] ref uint pdwPortNum);
        /// <summary>
        /// Disconnects all clients from the network sink.
        /// </summary>
        void Disconnect();
        /// <summary>
        /// Disconnects all clients from the network sink, and releases the port.
        /// </summary>
        void Close();
    }
    /// <summary>
    /// The IWMWriterPushSink interface enables the application to send ASF files to a publishing point on
    /// a Windows Media server. The writer push sink object exposes this interface. To create an instance
    /// of the writer push sink, call the WMCreateWriterPushSink function.
    /// </summary>
    [ComImport]
    [Guid("dc10e6a5-072c-467d-bf57-6330a9dde12a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterPushSink : IWMWriterSink
    {
        //IWMWriterSink
        new void OnHeader([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pHeader);
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        new void AllocateDataUnit([In] uint cbDataUnit,
         [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppDataUnit);
        new void OnDataUnit([In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pDataUnit);
        new void OnEndWriting();
        /// <summary>
        /// The Connect method connects to a publishing point on a Windows Media server.
        /// </summary>
        /// <param name="pwszURL">Wide-character string that contains the URL of the publishing point on the
        /// Windows Media server. For example, if the URL is "http://MyServer/MyPublishingPoint", 
        /// the push sink connects to the publishing point named MyPublishingPoint on the server named MyServer.
        /// The default port number is 80. If the server is using a different port, specify the port number
        /// in the URL. For example, "http://MyServer:8080/MyPublishingPoint" specifies port number 8080.</param>
        /// <param name="pwszTemplateURL">Optional wide-character string that contains the URL of an existing
        /// publishing point to use as a template. This parameter can be NULL.</param>
        /// <param name="fAutoDestroy">Boolean value that specifies whether to remove the publishing point after
        /// the push sink disconnects from the server.</param>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void Connect([In, MarshalAs(UnmanagedType.LPWStr)] string pwszURL,
                     [In, MarshalAs(UnmanagedType.LPWStr)] string pwszTemplateURL,
                     [In, MarshalAs(UnmanagedType.Bool)] bool fAutoDestroy);
        void Disconnect();
        void EndSession();
    }
    /// <summary>
    /// The IWMWriter interface is used to write ASF files. It includes methods for allocating buffers,
    /// setting and retrieving input properties, and setting profiles and output file names.
    /// The writer object exposes this interface. To create the writer object, call the WMCreateWriter function.
    /// </summary>
    [ComImport]
    [Guid("96406BD4-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriter
    {
        /// <summary>
        /// Specifies the profile to use for the current writing task, identifying the profile by its globally
        /// unique identifier.
        /// </summary>
        /// <param name="guidProfile">GUID of the profile.</param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void SetProfileByID([In] ref Guid guidProfile);
        /// <summary>
        /// Specifies the profile to use for the current writing task, using a pointer to an IWMProfile object.
        /// </summary>
        /// <param name="pProfile">Pointer to an IWMProfile interface.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetProfile([In, MarshalAs(UnmanagedType.Interface)] IWMProfile pProfile);
        /// <summary>
        /// Specifies the name of the file to be written.
        /// </summary>
        /// <param name="pwszFilename">Pointer to a wide-character null-terminated string containing the file name.</param>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetOutputFilename([In, MarshalAs(UnmanagedType.LPWStr)] string pwszFilename);
        /// <summary>
        /// Retrieves the number of uncompressed input streams.
        /// </summary>
        /// <param name="pcInputs">Pointer to a count of inputs.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetInputCount([Out] out uint pcInputs);
        /// <summary>
        /// Retrieves the media properties of a specified input stream.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input index number.</param>
        /// <param name="ppInput">Pointer to a pointer to an IWMInputMediaProps object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetInputProps([In] uint dwInputNum,
                           [Out, MarshalAs(UnmanagedType.Interface)] out IWMInputMediaProps ppInput);
        /// <summary>
        /// Specifies the media properties of a specified input stream.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number.</param>
        /// <param name="pInput">Pointer to an IWMInputMediaProps interface. See Remarks.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetInputProps([In] uint dwInputNum,
                           [In, MarshalAs(UnmanagedType.Interface)] IWMInputMediaProps pInput);
        /// <summary>
        /// Retrieves the number of format types supported by this input on the writer.
        /// </summary>
        /// <param name="dwInputNumber">DWORD containing the input number.</param>
        /// <param name="pcFormats">Pointer to a count of formats.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetInputFormatCount([In] uint dwInputNumber, [Out] out uint pcFormats);
        /// <summary>
        /// Retrieves possible media formats for the specified input.
        /// </summary>
        /// <param name="dwInputNumber">DWORD containing the input number.</param>
        /// <param name="dwFormatNumber">DWORD containing the format number.</param>
        /// <param name="pProps">Pointer to a pointer to an IWMInputMediaProps interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetInputFormat([In] uint dwInputNumber,
                            [In] uint dwFormatNumber,
                            [Out, MarshalAs(UnmanagedType.Interface)] out IWMInputMediaProps pProps);
        /// <summary>
        /// Initializes the writing process.
        /// </summary>
        void BeginWriting();
        /// <summary>
        /// Terminates the writing process.
        /// </summary>
        void EndWriting();
        /// <summary>
        /// Allocates a buffer that the application can use to supply samples to the writer.
        /// </summary>
        /// <param name="dwSampleSize">DWORD containing the sample size, in bytes.</param>
        /// <param name="ppSample">Pointer to a pointer to an <see cref="INSSBuffer"/> interface to an object containing the sample.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AllocateSample([In] uint dwSampleSize,
                            [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppSample);
        /// <summary>
        /// Passes in uncompressed data to be compressed and appended to the Windows Media file that is being created.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number.</param>
        /// <param name="cnsSampleTime">QWORD containing the sample time, in 100-nanosecond units.</param>
        /// <param name="dwFlags"></param>
        /// <param name="pSample">Pointer to an INSSBuffer interface representing a sample.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void WriteSample([In] uint dwInputNum,
                         [In] ulong cnsSampleTime,
                         [In] uint dwFlags,
                         [In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pSample);
        /// <summary>
        /// Functionality removed. Always returns S_OK.
        /// </summary>
        void Flush();
    }
    /// <summary>
    /// The IWMWriterAdvanced interface provides advanced writing functionality.
    /// 
    /// This interface exists for every instance of the writer object. To obtain a pointer to this interface,
    /// call QueryInterface on the writer object.
    /// </summary>
    [ComImport]
    [Guid("96406BE3-2B2B-11d3-B36B-00C04F6108FF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterAdvanced
    {
        /// <summary>
        /// Retrieves the number of writer sinks.
        /// </summary>
        /// <param name="pcSinks">DWORD indicating the total number of sinks associated with the writer object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetSinkCount([Out] out uint pcSinks);
        /// <summary>
        /// Retrieves a writer sink object.
        /// </summary>
        /// <param name="dwSinkNum">DWORD containing the sink number (its index). This is a number between 0 and
        /// one less than the total number of sinks associated with the file as obtained with
        /// IWMWriterAdvanced.GetSinkCount.</param>
        /// <param name="ppSink">Pointer to a pointer to an <see cref="IWMWriterSink"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetSink([In] uint dwSinkNum,
                     [Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterSink ppSink);
        /// <summary>
        /// Adds a writer sink.
        /// </summary>
        /// <param name="pSink">Pointer to an IWMWriterSink interface.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AddSink([In, MarshalAs(UnmanagedType.Interface)] IWMWriterSink pSink);
        /// <summary>
        /// Removes a writer sink object.
        /// </summary>
        /// <param name="pSink">Pointer to the IWMWriterSink interface of the sink object to remove, or NULL to remove all sinks.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void RemoveSink([In, MarshalAs(UnmanagedType.Interface)] IWMWriterSink pSink);
        /// <summary>
        /// Writes a stream sample directly into an ASF file, bypassing the normal compression procedures.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of 1 through 63.</param>
        /// <param name="cnsSampleTime">QWORD containing the sample time, in 100-nanosecond units.</param>
        /// <param name="msSampleSendTime">DWORD containing the sample send time, in milliseconds. This parameter is not used.</param>
        /// <param name="cnsSampleDuration">QWORD containing the sample duration, in 100-nanosecond units. This parameter is not used.</param>
        /// <param name="dwFlags">DWORD containing one or more of the flags.</param>
        /// <param name="pSample">Pointer to an <see cref="INSSBuffer"/> interface representing the sample.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void WriteStreamSample([In] ushort wStreamNum,
                               [In] ulong cnsSampleTime,
                               [In] uint msSampleSendTime,
                               [In] ulong cnsSampleDuration,
                               [In] uint dwFlags,
                               [In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pSample);
        /// <summary>
        /// Specifies whether the source is live.
        /// </summary>
        /// <param name="fIsLiveSource">Boolean value that is True if the source is live.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetLiveSource([MarshalAs(UnmanagedType.Bool)]bool fIsLiveSource);
        /// <summary>
        /// Ascertains whether the writer is running in real time.
        /// </summary>
        /// <param name="pfRealTime">Pointer to a Boolean value that is True if the writer is running in real time.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        /// <summary>
        /// Retrieves the clock time that the writer is working to.
        /// </summary>
        /// <param name="pcnsCurrentTime">Pointer to a variable containing the current time in 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetWriterTime([Out] out ulong pcnsCurrentTime);
        /// <summary>
        /// Retrieves statistics about the current writing operation.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers must be in the range of 1
        /// through 63. A value of 0 retrieves statistics for the file as a whole.</param>
        /// <param name="pStats">Pointer to a <see cref="WM_WRITER_STATISTICS"/> structure that receives the statistics.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetStatistics([In] ushort wStreamNum,
                           [Out] out WM_WRITER_STATISTICS pStats);
        /// <summary>
        /// Sets the amount of time that the inputs can fall out of synchronization before the samples are discarded.
        /// </summary>
        /// <param name="msWindow">Amount of time that the inputs can be out of synchronization, in milliseconds.
        /// Note that this parameter is in milliseconds and not 100-nanosecond units.</param>
        void SetSyncTolerance([In] uint msWindow);
        /// <summary>
        /// Retrieves the amount of time during which the inputs can fall out of synchronization before
        /// the samples are discarded.
        /// </summary>
        /// <param name="pmsWindow">Pointer to the limit of the number of milliseconds that the inputs can
        /// be out of synchronization. Note that this parameter is in milliseconds and not 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        void GetSyncTolerance([Out] out uint pmsWindow);
    }
    /// <summary>
    /// The IWMWriterAdvanced2 interface provides the ability to set and retrieve named settings for an input.
    /// 
    /// IWMWriterAdvanced2 exists for every instance of the writer object. To obtain a pointer to this interface,
    /// call <see cref="QueryInterface"/> on the writer object.
    /// </summary>
    [ComImport]
    [Guid("962dc1ec-c046-4db8-9cc7-26ceae500817")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterAdvanced2 : IWMWriterAdvanced
    {
        /// <summary>
        /// Retrieves the number of writer sinks.
        /// </summary>
        /// <param name="pcSinks">DWORD indicating the total number of sinks associated with the writer object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetSinkCount([Out] out uint pcSinks);
        /// <summary>
        /// Retrieves a writer sink object.
        /// </summary>
        /// <param name="dwSinkNum">DWORD containing the sink number (its index). This is a number between 0 and
        /// one less than the total number of sinks associated with the file as obtained with
        /// IWMWriterAdvanced.GetSinkCount.</param>
        /// <param name="ppSink">Pointer to a pointer to an <see cref="IWMWriterSink"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetSink([In] uint dwSinkNum,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterSink ppSink);
        /// <summary>
        /// Adds a writer sink.
        /// </summary>
        /// <param name="pSink">Pointer to an IWMWriterSink interface.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void AddSink([In, MarshalAs(UnmanagedType.Interface)] IWMWriterSink pSink);
        /// <summary>
        /// Removes a writer sink object.
        /// </summary>
        /// <param name="pSink">Pointer to the IWMWriterSink interface of the sink object to remove, or NULL to remove all sinks.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void RemoveSink([In, MarshalAs(UnmanagedType.Interface)] IWMWriterSink pSink);
        /// <summary>
        /// Writes a stream sample directly into an ASF file, bypassing the normal compression procedures.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of 1 through 63.</param>
        /// <param name="cnsSampleTime">QWORD containing the sample time, in 100-nanosecond units.</param>
        /// <param name="msSampleSendTime">DWORD containing the sample send time, in milliseconds. This parameter is not used.</param>
        /// <param name="cnsSampleDuration">QWORD containing the sample duration, in 100-nanosecond units. This parameter is not used.</param>
        /// <param name="dwFlags">DWORD containing one or more of the flags.</param>
        /// <param name="pSample">Pointer to an <see cref="INSSBuffer"/> interface representing the sample.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        new void WriteStreamSample([In] ushort wStreamNum,
         [In] ulong cnsSampleTime,
         [In] uint msSampleSendTime,
         [In] ulong cnsSampleDuration,
         [In] uint dwFlags,
         [In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pSample);
        /// <summary>
        /// Specifies whether the source is live.
        /// </summary>
        /// <param name="fIsLiveSource">Boolean value that is True if the source is live.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetLiveSource([MarshalAs(UnmanagedType.Bool)]bool fIsLiveSource);
        /// <summary>
        /// Ascertains whether the writer is running in real time.
        /// </summary>
        /// <param name="pfRealTime">Pointer to a Boolean value that is True if the writer is running in real time.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        /// <summary>
        /// Retrieves the clock time that the writer is working to.
        /// </summary>
        /// <param name="pcnsCurrentTime">Pointer to a variable containing the current time in 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetWriterTime([Out] out ulong pcnsCurrentTime);
        /// <summary>
        /// Retrieves statistics about the current writing operation.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers must be in the range of 1
        /// through 63. A value of 0 retrieves statistics for the file as a whole.</param>
        /// <param name="pStats">Pointer to a <see cref="WM_WRITER_STATISTICS"/> structure that receives the statistics.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetStatistics([In] ushort wStreamNum,
         [Out] out WM_WRITER_STATISTICS pStats);
        /// <summary>
        /// Sets the amount of time that the inputs can fall out of synchronization before the samples are discarded.
        /// </summary>
        /// <param name="msWindow">Amount of time that the inputs can be out of synchronization, in milliseconds.
        /// Note that this parameter is in milliseconds and not 100-nanosecond units.</param>
        new void SetSyncTolerance([In] uint msWindow);
        /// <summary>
        /// Retrieves the amount of time during which the inputs can fall out of synchronization before
        /// the samples are discarded.
        /// </summary>
        /// <param name="pmsWindow">Pointer to the limit of the number of milliseconds that the inputs can
        /// be out of synchronization. Note that this parameter is in milliseconds and not 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetSyncTolerance([Out] out uint pmsWindow);
        /// <summary>
        /// Retrieves a setting for a particular input by name.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the setting name.</param>
        /// <param name="pType">Pointer to a value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the setting. The type of date is determined
        /// by pType. Pass NULL to retrieve the size of array required.</param>
        /// <param name="pcbLength">On input, pointer to the length of pValue. On output, pointer to a count of 
        /// the bytes in pValue filled in by this method.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetInputSetting([In] uint dwInputNum,
                             [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
                             [Out] out WMT_ATTR_DATATYPE pType,
                             [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pValue,
                             [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Specifies a named setting for a particular input.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the setting name.</param>
        /// <param name="Type">Pointer to a value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the setting.</param>
        /// <param name="cbLength">Size of pValue, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        void SetInputSetting([In] uint dwInputNum,
                             [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
                             [In] WMT_ATTR_DATATYPE Type,
                             [In, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 4)] byte[] pValue,
                             [In] ushort cbLength);
    }
    /// <summary>
    /// The IWMWriterAdvanced3 interface provides additional functionality for the writer object.
    /// 
    /// IWMWriterAdvanced3 exists for every instance of the writer object. To obtain a pointer to this interface,
    /// call QueryInterface on the writer object.
    /// </summary>
    [ComImport]
    [Guid("2cd6492d-7c37-4e76-9d3b-59261183a22e")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterAdvanced3 : IWMWriterAdvanced2
    {
        /// <summary>
        /// Retrieves the number of writer sinks.
        /// </summary>
        /// <param name="pcSinks">DWORD indicating the total number of sinks associated with the writer object.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetSinkCount([Out] out uint pcSinks);
        /// <summary>
        /// Retrieves a writer sink object.
        /// </summary>
        /// <param name="dwSinkNum">DWORD containing the sink number (its index). This is a number between 0 and
        /// one less than the total number of sinks associated with the file as obtained with
        /// IWMWriterAdvanced.GetSinkCount.</param>
        /// <param name="ppSink">Pointer to a pointer to an <see cref="IWMWriterSink"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetSink([In] uint dwSinkNum,
         [Out, MarshalAs(UnmanagedType.Interface)] out IWMWriterSink ppSink);
        /// <summary>
        /// Adds a writer sink.
        /// </summary>
        /// <param name="pSink">Pointer to an IWMWriterSink interface.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void AddSink([In, MarshalAs(UnmanagedType.Interface)] IWMWriterSink pSink);
        /// <summary>
        /// Removes a writer sink object.
        /// </summary>
        /// <param name="pSink">Pointer to the IWMWriterSink interface of the sink object to remove, or NULL to remove all sinks.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void RemoveSink([In, MarshalAs(UnmanagedType.Interface)] IWMWriterSink pSink);
        /// <summary>
        /// Writes a stream sample directly into an ASF file, bypassing the normal compression procedures.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers are in the range of 1 through 63.</param>
        /// <param name="cnsSampleTime">QWORD containing the sample time, in 100-nanosecond units.</param>
        /// <param name="msSampleSendTime">DWORD containing the sample send time, in milliseconds. This parameter is not used.</param>
        /// <param name="cnsSampleDuration">QWORD containing the sample duration, in 100-nanosecond units. This parameter is not used.</param>
        /// <param name="dwFlags">DWORD containing one or more of the flags.</param>
        /// <param name="pSample">Pointer to an <see cref="INSSBuffer"/> interface representing the sample.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        new void WriteStreamSample([In] ushort wStreamNum,
         [In] ulong cnsSampleTime,
         [In] uint msSampleSendTime,
         [In] ulong cnsSampleDuration,
         [In] uint dwFlags,
         [In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pSample);
        /// <summary>
        /// Specifies whether the source is live.
        /// </summary>
        /// <param name="fIsLiveSource">Boolean value that is True if the source is live.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetLiveSource([MarshalAs(UnmanagedType.Bool)]bool fIsLiveSource);
        /// <summary>
        /// Ascertains whether the writer is running in real time.
        /// </summary>
        /// <param name="pfRealTime">Pointer to a Boolean value that is True if the writer is running in real time.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void IsRealTime([Out, MarshalAs(UnmanagedType.Bool)] out bool pfRealTime);
        /// <summary>
        /// Retrieves the clock time that the writer is working to.
        /// </summary>
        /// <param name="pcnsCurrentTime">Pointer to a variable containing the current time in 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetWriterTime([Out] out ulong pcnsCurrentTime);
        /// <summary>
        /// Retrieves statistics about the current writing operation.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number. Stream numbers must be in the range of 1
        /// through 63. A value of 0 retrieves statistics for the file as a whole.</param>
        /// <param name="pStats">Pointer to a <see cref="WM_WRITER_STATISTICS"/> structure that receives the statistics.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetStatistics([In] ushort wStreamNum,
         [Out] out WM_WRITER_STATISTICS pStats);
        /// <summary>
        /// Sets the amount of time that the inputs can fall out of synchronization before the samples are discarded.
        /// </summary>
        /// <param name="msWindow">Amount of time that the inputs can be out of synchronization, in milliseconds.
        /// Note that this parameter is in milliseconds and not 100-nanosecond units.</param>
        new void SetSyncTolerance([In] uint msWindow);
        /// <summary>
        /// Retrieves the amount of time during which the inputs can fall out of synchronization before
        /// the samples are discarded.
        /// </summary>
        /// <param name="pmsWindow">Pointer to the limit of the number of milliseconds that the inputs can
        /// be out of synchronization. Note that this parameter is in milliseconds and not 100-nanosecond units.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetSyncTolerance([Out] out uint pmsWindow);
        /// <summary>
        /// Retrieves a setting for a particular input by name.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the setting name.</param>
        /// <param name="pType">Pointer to a value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the setting. The type of date is determined
        /// by pType. Pass NULL to retrieve the size of array required.</param>
        /// <param name="pcbLength">On input, pointer to the length of pValue. On output, pointer to a count of 
        /// the bytes in pValue filled in by this method.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetInputSetting([In] uint dwInputNum,
          [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
          [Out] out WMT_ATTR_DATATYPE pType,
          [Out, MarshalAs(UnmanagedType.LPArray)] byte[] pValue,
          [In, Out] ref ushort pcbLength);
        /// <summary>
        /// Specifies a named setting for a particular input.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number.</param>
        /// <param name="pszName">Pointer to a wide-character null-terminated string containing the setting name.</param>
        /// <param name="Type">Pointer to a value from the WMT_ATTR_DATATYPE enumeration type.</param>
        /// <param name="pValue">Pointer to a byte array containing the setting.</param>
        /// <param name="cbLength">Size of pValue, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        new void SetInputSetting([In] uint dwInputNum,
         [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
         [In] WMT_ATTR_DATATYPE Type,
         [In, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 4)] byte[] pValue,
         [In] ushort cbLength);
        /// <summary>
        /// Retrieves extended statistics for the writer.
        /// </summary>
        /// <param name="wStreamNum">WORD containing the stream number for which you want to get statistics.
        /// You can pass 0 to obtain extended statistics for the entire file. Stream numbers are in the range
        /// of 1 through 63.</param>
        /// <param name="pStats">Pointer to the WM_WRITER_STATISTICS_EX structure that receives the statistics.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
        void GetStatisticsEx([In] ushort wStreamNum,
                             [Out] out WM_WRITER_STATISTICS_EX pStats);
        /// <summary>
        /// Configures the writer so that it does not block the calling thread.
        /// </summary>
        void SetNonBlocking();
    };
    /// <summary>
    /// The IWMWriterPreprocess interface handles multi-pass encoding. By making more than one pass, the writer
    /// can obtain better quality with better compression.
    /// An IWMWriterPreprocess interface exists for every instance of the writer object. You can obtain a pointer
    /// to IWMWriterPreprocess with a call to the QueryInterface method of any other interface in the writer
    /// object.
    /// </summary>
    [ComImport]
    [Guid("fc54a285-38c4-45b5-aa23-85b9f7cb424b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMWriterPreprocess
    {
        /// <summary>
        /// The GetMaxPreprocessingPasses method retrieves the maximum number of preprocessing passes for a specified input stream.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number for which you want to get the maximum number of preprocessing passes.</param>
        /// <param name="dwFlags">Reserved. Set to zero.</param>
        /// <param name="pdwMaxNumPasses">Pointer to a DWORD that will receive the maximum number of preprocessing
        /// passes. If the codec supports two-pass encoding, this value is 1, as the final pass is not counted.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void GetMaxPreprocessingPasses([In] uint dwInputNum,
                                       [In] uint dwFlags,
                                       [Out] out uint pdwMaxNumPasses);
        /// <summary>
        /// The SetNumPreprocessingPasses method sets the number of passes to perform on an input.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number for which you want to set the number of passes.</param>
        /// <param name="dwFlags">Reserved. Set to zero.</param>
        /// <param name="dwNumPasses">DWORD containing the number of preprocessing passes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void SetNumPreprocessingPasses([In] uint dwInputNum,
                                       [In] uint dwFlags,
                                       [In] uint dwNumPasses);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void BeginPreprocessingPass([In] uint dwInputNum, [In] uint dwFlags);
        /// <summary>
        /// The PreprocessSample method delivers a sample to the writer for preprocessing.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number of the sample.</param>
        /// <param name="cnsSampleTime">Specifies the presentation time of the sample in 100-nanosecond units.</param>
        /// <param name="dwFlags">Reserved. Set to zero.</param>
        /// <param name="pSample">Pointer to an INSSBuffer interface on an object that contains the sample.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void PreprocessSample([In] uint dwInputNum,
                              [In] ulong cnsSampleTime,
                              [In] uint dwFlags,
                              [In, MarshalAs(UnmanagedType.Interface)] INSSBuffer pSample);
        /// <summary>
        /// The EndPreprocessingPass method ends a preprocessing pass started with a call to
        /// IWMWriterPreprocess.BeginPreprocessingPass.
        /// </summary>
        /// <param name="dwInputNum">DWORD containing the input number for which you want to halt preprocessing.</param>
        /// <param name="dwFlags">Reserved. Set to zero.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms")]
        void EndPreprocessingPass([In] uint dwInputNum, [In] uint dwFlags);
    }
}
