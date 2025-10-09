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
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio.WMFSDK
{
    /// <summary>
    /// The INSSBuffer interface is the basic interface of a buffer object. A buffer object is a wrapper around
    /// a memory buffer. The methods exposed by this interface are used to manipulate the buffer.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [ComImport]
    [Guid("E1CD3524-03D7-11d2-9EED-006097D2D7CF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INSSBuffer
    {
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="pdwLength">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetLength([Out] out uint pdwLength);
        /// <summary>
        /// Specifies the size of the used portion of the buffer.
        /// </summary>
        /// <param name="dwLength">DWORD containing the size of the used portion, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetLength([In] uint dwLength);
        /// <summary>
        /// Retrieves the maximum size to which a buffer can be set.
        /// </summary>
        /// <param name="pdwLength">Pointer to a DWORD containing the maximum length, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetMaxLength([Out] out uint pdwLength);
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetBuffer([Out] out IntPtr ppdwBuffer);
        /// <summary>
        /// Retrieves the location and size of the used portion of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        /// <param name="pdwLength">Pointer to a DWORD containing the length of the buffer, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetBufferAndLength([Out] out IntPtr ppdwBuffer, [Out] out uint pdwLength);
    }
    /// <summary>
    /// The INSSBuffer2 interface inherits from INSSBuffer and defines two additional methods. Currently,
    /// neither of these methods is implemented.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [ComImport]
    [Guid("4F528693-1035-43fe-B428-757561AD3A68")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INSSBuffer2 : INSSBuffer
    {
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="pdwLength">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        new void GetLength([Out] out uint pdwLength);
        /// <summary>
        /// Specifies the size of the used portion of the buffer.
        /// </summary>
        /// <param name="dwLength">DWORD containing the size of the used portion, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetLength([In] uint dwLength);
        /// <summary>
        /// Retrieves the maximum size to which a buffer can be set.
        /// </summary>
        /// <param name="pdwLength">Pointer to a DWORD containing the maximum length, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetMaxLength([Out] out uint pdwLength);
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetBuffer([Out] out IntPtr ppdwBuffer);
        /// <summary>
        /// Retrieves the location and size of the used portion of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        /// <param name="pdwLength">Pointer to a DWORD containing the length of the buffer, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetBufferAndLength([Out] out IntPtr ppdwBuffer, [Out] out uint pdwLength);
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="cbProperties"></param>
        /// <param name="pbProperties"></param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetSampleProperties([In] uint cbProperties, [Out] out byte pbProperties);
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="cbProperties"></param>
        /// <param name="pbProperties"></param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void SetSampleProperties([In] uint cbProperties, [In] ref byte pbProperties);
    };
    /// <summary>
    /// The INSSBuffer3 interface enhances the <see cref="INSSBuffer"/> interface by adding the ability to set and retrieve
    /// single properties for a sample. This interface inherits its functionality from the <see cref="INSSBuffer2"/>
    /// interface, which inherits functionality from <see cref="INSSBuffer"/>. <see cref="INSSBuffer2"/> is not documented separately
    /// in this documentation because the two methods it exposes are not implemented at this time.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [ComImport]
    [Guid("C87CEAAF-75BE-4bc4-84EB-AC2798507672")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INSSBuffer3 : INSSBuffer2
    {
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="pdwLength">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetLength([Out] out uint pdwLength);
        /// <summary>
        /// Specifies the size of the used portion of the buffer.
        /// </summary>
        /// <param name="dwLength">DWORD containing the size of the used portion, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetLength([In] uint dwLength);
        /// <summary>
        /// Retrieves the maximum size to which a buffer can be set.
        /// </summary>
        /// <param name="pdwLength">Pointer to a DWORD containing the maximum length, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetMaxLength([Out] out uint pdwLength);
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetBuffer([Out] out IntPtr ppdwBuffer);
        /// <summary>
        /// Retrieves the location and size of the used portion of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        /// <param name="pdwLength">Pointer to a DWORD containing the length of the buffer, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetBufferAndLength([Out] out IntPtr ppdwBuffer, [Out] out uint pdwLength);
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="cbProperties"></param>
        /// <param name="pbProperties"></param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetSampleProperties([In] uint cbProperties, [Out] out byte pbProperties);
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="cbProperties"></param>
        /// <param name="pbProperties"></param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetSampleProperties([In] uint cbProperties, [In] ref byte pbProperties);
        /// <summary>
        /// Sets a property for the sample.
        /// </summary>
        /// <param name="guidBufferProperty">GUID value identifying the property you want to set. The predefined buffer
        /// properties are described in the Sample Extension Types section of this documentation.
        /// You can also define your own sample extension schemes using your own GUID values.</param>
        /// <param name="pvBufferProperty">Pointer to a buffer containing the property value.</param>
        /// <param name="dwBufferPropertySize">DWORD value containing the size of the buffer pointed to by pvBufferProperty.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        void SetProperty([In] Guid guidBufferProperty,
                         [In] IntPtr pvBufferProperty,
                         [In] uint dwBufferPropertySize);
        /// <summary>
        /// Retrieves a property for the sample.
        /// </summary>
        /// <param name="guidBufferProperty">GUID value identifying the property to retrieve. The predefined buffer
        /// properties are described in the Sample Extension Types section of this documentation.
        /// You can also define your own sample extension schemes using your own GUID values.</param>
        /// <param name="pvBufferProperty">Pointer to a buffer that will receive the value of the property
        /// specified by guidBufferProperty.</param>
        /// <param name="pdwBufferPropertySize">Pointer to a DWORD value containing the size of the buffer pointed 
        /// to by pvBufferProperty. If you pass NULL for pvBufferProperty, the method sets the value
        /// pointed to by this parameter to the size required to hold the property value.
        /// If you pass a non-NULL value for pvBufferProperty, the value pointed to by this parameter must
        /// equal the size of the buffer pointed to by pvBufferProperty.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        void GetProperty([In] Guid guidBufferProperty,
            /*out]*/ IntPtr pvBufferProperty,
                         [In, Out] ref uint pdwBufferPropertySize);
    }
    /// <summary>
    /// The INSSBuffer4 interface provides methods to enumerate buffer properties. These methods are important
    /// when reading files that may have properties of which you are not aware.
    /// An INSSBuffer4 interface exists for every buffer object. To retrieve a pointer to an instance
    /// of INSSBuffer4, call the QueryInterface method of one of the other interfaces in the buffer object,
    /// typically INSSBuffer.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [ComImport]
    [Guid("B6B8FD5A-32E2-49d4-A910-C26CC85465ED")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INSSBuffer4 : INSSBuffer3
    {
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="pdwLength">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetLength([Out] out uint pdwLength);
        /// <summary>
        /// Specifies the size of the used portion of the buffer.
        /// </summary>
        /// <param name="dwLength">DWORD containing the size of the used portion, in bytes.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetLength([In] uint dwLength);
        /// <summary>
        /// Retrieves the maximum size to which a buffer can be set.
        /// </summary>
        /// <param name="pdwLength">Pointer to a DWORD containing the maximum length, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetMaxLength([Out] out uint pdwLength);
        /// <summary>
        /// Retrieves the location of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetBuffer([Out] out IntPtr ppdwBuffer);
        /// <summary>
        /// Retrieves the location and size of the used portion of the buffer.
        /// </summary>
        /// <param name="ppdwBuffer">Pointer to a pointer to the buffer.</param>
        /// <param name="pdwLength">Pointer to a DWORD containing the length of the buffer, in bytes.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetBufferAndLength([Out] out IntPtr ppdwBuffer, [Out] out uint pdwLength);
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="cbProperties"></param>
        /// <param name="pbProperties"></param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void GetSampleProperties([In] uint cbProperties, [Out] out byte pbProperties);
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="cbProperties"></param>
        /// <param name="pbProperties"></param>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        new void SetSampleProperties([In] uint cbProperties, [In] ref byte pbProperties);
        /// <summary>
        /// Sets a property for the sample.
        /// </summary>
        /// <param name="guidBufferProperty">GUID value identifying the property you want to set. The predefined buffer
        /// properties are described in the Sample Extension Types section of this documentation.
        /// You can also define your own sample extension schemes using your own GUID values.</param>
        /// <param name="pvBufferProperty">Pointer to a buffer containing the property value.</param>
        /// <param name="dwBufferPropertySize">DWORD value containing the size of the buffer pointed to by pvBufferProperty.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        new void SetProperty([In] Guid guidBufferProperty,
          [In] IntPtr pvBufferProperty,
          [In] uint dwBufferPropertySize);
        /// <summary>
        /// Retrieves a property for the sample.
        /// </summary>
        /// <param name="guidBufferProperty">GUID value identifying the property to retrieve. The predefined buffer
        /// properties are described in the Sample Extension Types section of this documentation.
        /// You can also define your own sample extension schemes using your own GUID values.</param>
        /// <param name="pvBufferProperty">Pointer to a buffer that will receive the value of the property
        /// specified by guidBufferProperty.</param>
        /// <param name="pdwBufferPropertySize">Pointer to a DWORD value containing the size of the buffer pointed 
        /// to by pvBufferProperty. If you pass NULL for pvBufferProperty, the method sets the value
        /// pointed to by this parameter to the size required to hold the property value.
        /// If you pass a non-NULL value for pvBufferProperty, the value pointed to by this parameter must
        /// equal the size of the buffer pointed to by pvBufferProperty.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames")]
        new void GetProperty([In] Guid guidBufferProperty,
            /*out]*/ IntPtr pvBufferProperty,
          [In, Out] ref uint pdwBufferPropertySize);
        /// <summary>
        /// Retrieves the total count of buffer properties associated with the sample.
        /// </summary>
        /// <param name="pcBufferProperties">Pointer to the size of buffer properties.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetPropertyCount([Out] out uint pcBufferProperties);
        /// <summary>
        /// Retrieves a buffer property, also called a data unit extension, using an index instead of a name.
        /// </summary>
        /// <param name="dwBufferPropertyIndex">DWORD containing the buffer property index.
        /// This value will be between zero and one less than the total number of properties associated
        /// with the sample. You can retrieve the total number of properties by calling
        /// INSSBuffer4.GetPropertyCount.</param>
        /// <param name="pguidBufferProperty">Pointer to a GUID specifying the type of buffer property.</param>
        /// <param name="pvBufferProperty">Void pointer containing the value of the buffer property.</param>
        /// <param name="pdwBufferPropertySize">Pointer to a DWORD containing the size of the value pointed
        /// to by pvBufferProperty. If you set pvBufferProperty to NULL, this value will be set
        /// to the required size in bytes of the buffer needed to store the property value.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void GetPropertyByIndex([In] uint dwBufferPropertyIndex,
                                [Out] out Guid pguidBufferProperty,
            /*[out]*/   IntPtr pvBufferProperty,
                                [In, Out] ref uint pdwBufferPropertySize);
    }
    /// <summary>
    /// The IWMSSBufferAllocator interface provides methods for allocating a buffer. This method is implemented
    /// by the server object in Microsoft Windows Media Services 9 Series. For more information,
    /// see the Windows Media Services 9 Series SDK documentation.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    [ComImport]
    [Guid("61103CA4-2033-11d2-9EF1-006097D2D7CF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMSBufferAllocator
    {
        /// <summary>
        /// Initializes a buffer.
        /// </summary>
        /// <param name="dwMaxBufferSize">DWORD containing the maximum size of the buffer in bytes.</param>
        /// <param name="ppBuffer">Address of a variable that receives a pointer to the INSSBuffer interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AllocateBuffer([In] uint dwMaxBufferSize,
                            [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppBuffer);
        /// <summary>
        /// Initializes a buffer that can be used to perform page-aligned reads.
        /// </summary>
        /// <param name="dwMaxBufferSize">DWORD containing the size of the buffer in bytes.</param>
        /// <param name="ppBuffer">Address of a variable that receives a pointer to the <see cref="INSSBuffer"/> interface.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        void AllocatePageSizeBuffer([In] uint dwMaxBufferSize,
                                    [Out, MarshalAs(UnmanagedType.Interface)] out INSSBuffer ppBuffer);
    };

}