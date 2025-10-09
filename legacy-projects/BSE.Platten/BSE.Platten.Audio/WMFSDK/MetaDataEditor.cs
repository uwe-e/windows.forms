using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BSE.Platten.Audio.WMFSDK
{
    /// <summary>
    /// The MetadataEditor class is used to edit metadata information in audio file headers.
    /// </summary>
    /// <copyright>Copyright © 2004 MCH Messe Basel AG</copyright>
    public class MetadataEditor : IDisposable
    {
        #region FieldsPrivate

        private IWMMetadataEditor m_IWMMetadataEditor;
        private IWMHeaderInfo3 m_IWMHeaderInfo3;
        // Track whether Dispose has been called.
        private bool m_bDisposed;
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="BSE.Platten.Audio.WMFSDK.MetadataEditor"/> class.
        /// </summary>
        public MetadataEditor()
        {
        }
        /// <summary>
        /// The GetMediaMetadata method gets a <see cref="BSE.Platten.Audio.AudioMetadata"/> object containing the attributes that are stored
        /// in the header section of a audio file.
        /// </summary>
        /// <param name="pwszFileName">The fully qualified path of the audio file.</param>
        /// <returns>A <see cref="BSE.Platten.Audio.AudioMetaData"/> object containing the stored attributes of a audio file.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public AudioMetadata GetMediaMetadata(string pwszFileName)
        {
            AudioMetadata audioMetaData = new AudioMetadata();
            try
            {
                ushort wStreamNum = 0xFFFF;
                ushort wAttributeCount;

                IWMHeaderInfo3 wmHeaderInfo3 = CreateEditor(pwszFileName);
                wmHeaderInfo3.GetAttributeCount(wStreamNum, out wAttributeCount);

                for (ushort wAttribIndex = 0; wAttribIndex < wAttributeCount; wAttribIndex++)
                {
                    WMT_ATTR_DATATYPE attrDataType;
                    string pwszAttribName = null;
                    byte[] pbAttribValue = null;
                    ushort wAttribNameLen = 0;
                    ushort wAttribValueLen = 0;

                    wmHeaderInfo3.GetAttributeByIndex(wAttribIndex,
                        ref wStreamNum,
                        pwszAttribName,
                        ref wAttribNameLen,
                        out attrDataType,
                        pbAttribValue,
                        ref wAttribValueLen);

                    pbAttribValue = new byte[wAttribValueLen];
                    pwszAttribName = new String((char)0, wAttribNameLen);

                    wmHeaderInfo3.GetAttributeByIndex(wAttribIndex,
                        ref wStreamNum,
                        pwszAttribName,
                        ref wAttribNameLen,
                        out attrDataType,
                        pbAttribValue,
                        ref wAttribValueLen);

                    SetMediaMetaDataObjects(
                        wAttribIndex,
                        wStreamNum,
                        pwszAttribName,
                        attrDataType,
                        0,
                        pbAttribValue,
                        wAttribValueLen,
                        ref audioMetaData);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return audioMetaData;
        }
        /// <summary>
        /// The SetAttribute method sets a descriptive attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="pwszFileName">The name of the audio file.</param>
        /// <param name="pwszAttribName">The name of the attribute.</param>
        /// <param name="attribDataType">A <see cref="WMT_ATTR_DATATYPE"/> enumeration type.</param>
        /// <param name="pAttribValue">A byte array containing the value of the attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void SetAttribute(string pwszFileName, string pwszAttribName,
            WMT_ATTR_DATATYPE attrDataType, byte[] pAttribValue)
        {
            try
            {
                ushort wStreamNum = 0;
                IWMHeaderInfo3 wmHeaderInfo3 = CreateEditor(pwszFileName);
                wmHeaderInfo3.SetAttribute(
                    wStreamNum,
                    pwszAttribName,
                    attrDataType,
                    pAttribValue,
                    (ushort)pAttribValue.Length);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// The SetAttribute method sets a descriptive attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="pwszFileName">The name of the audio file.</param>
        /// <param name="pwszAttribName">The name of the attribute.</param>
        /// <param name="attribDataType">A <see cref="WMT_ATTR_DATATYPE"/> enumeration type.</param>
        /// <param name="pwszAttribValue">A string containing the value of the attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void SetAttribute(string pwszFileName, string pwszAttribName,
            WMT_ATTR_DATATYPE attrDataType, string pwszAttribValue)
        {
            try
            {
                ushort wStreamNum = 0;
                byte[] pbAttribValue;
                int nAttribValueLen;

                if (TranslateAttrib(attrDataType, pwszAttribValue, out pbAttribValue, out nAttribValueLen) == false)
                {
                    return;
                }

                IWMHeaderInfo3 wmHeaderInfo3 = CreateEditor(pwszFileName);
                wmHeaderInfo3.SetAttribute(
                    wStreamNum,
                    pwszAttribName,
                    attrDataType,
                    pbAttribValue,
                    (ushort)nAttribValueLen);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Returns the index of an descriptive attribute that is stored in the ASF file header.
        /// </summary>
        /// <param name="pwszFileName">The name of the audio file.</param>
        /// <param name="pwszAttribName">The name of the attribute.</param>
        /// <returns>The index of the attribute</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public int GetAttributeIndex(string pwszFileName, string pwszAttribName)
        {
            int iAttributeIndex = -1;
            try
            {
                ushort wStreamNum = 0xFFFF;
                ushort wAttributeCount;

                IWMHeaderInfo3 wmHeaderInfo3 = CreateEditor(pwszFileName);
                wmHeaderInfo3.GetAttributeCount(wStreamNum, out wAttributeCount);

                for (ushort wAttribIndex = 0; wAttribIndex < wAttributeCount; wAttribIndex++)
                {
                    WMT_ATTR_DATATYPE attrDataType;
                    string pwszTempAttribName = null;
                    byte[] pbAttribValue = null;
                    ushort wAttribNameLen = 0;
                    ushort wAttribValueLen = 0;

                    wmHeaderInfo3.GetAttributeByIndex(wAttribIndex,
                        ref wStreamNum,
                        pwszTempAttribName,
                        ref wAttribNameLen,
                        out attrDataType,
                        pbAttribValue,
                        ref wAttribValueLen);

                    pbAttribValue = new byte[wAttribValueLen];
                    pwszTempAttribName = new String((char)0, wAttribNameLen);

                    wmHeaderInfo3.GetAttributeByIndex(wAttribIndex,
                        ref wStreamNum,
                        pwszTempAttribName,
                        ref wAttribNameLen,
                        out attrDataType,
                        pbAttribValue,
                        ref wAttribValueLen);

                    if (string.Compare(pwszTempAttribName.TrimEnd('\0'), pwszAttribName,StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        iAttributeIndex = (int)wAttribIndex;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return iAttributeIndex;
        }
        /// <summary>
        /// Deletes an attribute using the attribute index.
        /// </summary>
        /// <param name="pwszFileName">The name of the audio file.</param>
        /// <param name="iIndex">The index of the attribute to be deleted.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void DeleteAttribute(string pwszFileName, int iIndex)
        {
            if (iIndex != -1)
            {
                ushort wStreamNum = 0;
                try
                {
                    IWMHeaderInfo3 wmHeaderInfo3 = CreateEditor(pwszFileName);
                    wmHeaderInfo3.DeleteAttribute(wStreamNum, (ushort)iIndex);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Enables to perform final clean up before the object is released from memory.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~MetadataEditor()
        {
            Dispose(false);
        }
        #endregion

        #region MethodsProtected
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (this.m_bDisposed == false)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // No managed resources to clear up...
                }
                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                if (this.m_IWMMetadataEditor != null)
                {
                    this.m_IWMMetadataEditor.Flush();
                    this.m_IWMMetadataEditor.Close();
                }
            }
            // Note disposing has been done.
            this.m_bDisposed = true;
        }
        #endregion

        #region MethodsPrivate
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters")]
        private static void SetMediaMetaDataObjects(ushort wIndex,
            ushort wStream,
            string pwszName,
            WMT_ATTR_DATATYPE AttribDataType,
            ushort wLangID,
            byte[] pbValue,
            uint dwValueLen,
            ref AudioMetadata mediaMetaData)
        {
            string pwszValue = String.Empty;
            //
            // Make the data type string
            //
            string pwszType = "Unknown";
            string[] pTypes = { "DWORD", "STRING", "BINARY", "BOOL", "QWORD", "WORD", "GUID" };

            if (pTypes.Length > Convert.ToInt32(AttribDataType))
            {
                pwszType = pTypes[Convert.ToInt32(AttribDataType)];
            }
            //
            // The attribute value.
            //
            switch (AttribDataType)
            {
                // String
                case WMT_ATTR_DATATYPE.WMT_TYPE_STRING:

                    if (0 == dwValueLen)
                    {
                        pwszValue = "***** NULL *****";
                    }
                    else
                    {
                        if ((0xFE == Convert.ToInt16(pbValue[0])) &&
                            (0xFF == Convert.ToInt16(pbValue[1])))
                        {
                            pwszValue = "\"UTF-16LE BOM+\"";

                            if (4 <= dwValueLen)
                            {
                                for (int i = 0; i < pbValue.Length - 2; i += 2)
                                {
                                    pwszValue += Convert.ToString(BitConverter.ToChar(pbValue, i));
                                }
                            }

                            pwszValue = pwszValue + "\"";
                        }
                        else if ((0xFF == Convert.ToInt16(pbValue[0])) &&
                            (0xFE == Convert.ToInt16(pbValue[1])))
                        {
                            pwszValue = "\"UTF-16BE BOM+\"";
                            if (4 <= dwValueLen)
                            {
                                for (int i = 0; i < pbValue.Length - 2; i += 2)
                                {
                                    pwszValue += Convert.ToString(BitConverter.ToChar(pbValue, i));
                                }
                            }

                            pwszValue = pwszValue + "\"";
                        }
                        else
                        {
                            if (2 <= dwValueLen)
                            {
                                for (int i = 0; i < pbValue.Length - 2; i += 2)
                                {
                                    pwszValue += Convert.ToString(BitConverter.ToChar(pbValue, i));
                                }
                            }
                        }
                    }
                    break;

                // Binary
                case WMT_ATTR_DATATYPE.WMT_TYPE_BINARY:

                    pwszValue = "[" + dwValueLen.ToString() + " bytes]";
                    break;

                // Boolean
                case WMT_ATTR_DATATYPE.WMT_TYPE_BOOL:

                    if (BitConverter.ToBoolean(pbValue, 0))
                    {
                        pwszValue = "True";
                    }
                    else
                    {
                        pwszValue = "False";
                    }
                    break;

                // DWORD
                case WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:

                    uint dwValue = BitConverter.ToUInt32(pbValue, 0);
                    pwszValue = dwValue.ToString();
                    break;

                // QWORD
                case WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:

                    ulong qwValue = BitConverter.ToUInt64(pbValue, 0);
                    pwszValue = qwValue.ToString();
                    break;

                // WORD
                case WMT_ATTR_DATATYPE.WMT_TYPE_WORD:

                    uint wValue = BitConverter.ToUInt16(pbValue, 0);
                    pwszValue = wValue.ToString();
                    break;

                // GUID
                case WMT_ATTR_DATATYPE.WMT_TYPE_GUID:

                    pwszValue = BitConverter.ToString(pbValue, 0, pbValue.Length);
                    break;

                default:

                    break;
            }

            switch (pwszName.TrimEnd('\0'))
            {
                case WMFSDKFunctions.g_wszWMDuration:
                    long lDuration = Convert.ToInt64(pwszValue.ToString(), CultureInfo.InvariantCulture);
                    TimeSpan timeSpan = new TimeSpan(lDuration);
                    mediaMetaData.Duration = new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                    break;
                case WMFSDKFunctions.g_wszWMBitrate:
                    mediaMetaData.Bitrate = Convert.ToInt32(pwszValue.ToString(), CultureInfo.InvariantCulture);
                    break;
                case WMFSDKFunctions.g_wszWMTrackNumber:
                    mediaMetaData.WMTrackNumber = pwszValue;
                    break;
                case WMFSDKFunctions.g_wszWMAuthor:
                    mediaMetaData.Author = pwszValue;
                    break;
                case WMFSDKFunctions.g_wszWMAlbumArtist:
                    mediaMetaData.WMAlbumArtist = pwszValue;
                    break;
                case WMFSDKFunctions.g_wszWMAlbumTitle:
                    mediaMetaData.WMAlbumTitle = pwszValue;
                    break;
                case WMFSDKFunctions.g_wszWMGenre:
                    mediaMetaData.WMGenre = pwszValue;
                    break;
                case WMFSDKFunctions.g_wszWMTitle:
                    mediaMetaData.Title = pwszValue;
                    break;
                case WMFSDKFunctions.g_wszWMYear:
                    mediaMetaData.WMYear = pwszValue;
                    break;
            }
        }

        //------------------------------------------------------------------------------
        // Name: TranslateAttrib()
        // Desc: Converts attributes to byte arrays.
        //------------------------------------------------------------------------------
        private bool TranslateAttrib(WMT_ATTR_DATATYPE AttribDataType, string pwszValue, out byte[] pbValue, out int nValueLength)
        {
            switch (AttribDataType)
            {
                case WMT_ATTR_DATATYPE.WMT_TYPE_DWORD:

                    nValueLength = 4;
                    uint[] pdwAttribValue = new uint[1] { Convert.ToUInt32(pwszValue) };

                    pbValue = new Byte[nValueLength];
                    Buffer.BlockCopy(pdwAttribValue, 0, pbValue, 0, nValueLength);

                    return (true);

                case WMT_ATTR_DATATYPE.WMT_TYPE_WORD:

                    nValueLength = 2;
                    ushort[] pwAttribValue = new ushort[1] { Convert.ToUInt16(pwszValue) };

                    pbValue = new Byte[nValueLength];
                    Buffer.BlockCopy(pwAttribValue, 0, pbValue, 0, nValueLength);

                    return (true);

                case WMT_ATTR_DATATYPE.WMT_TYPE_QWORD:

                    nValueLength = 8;
                    ulong[] pqwAttribValue = new ulong[1] { Convert.ToUInt64(pwszValue) };

                    pbValue = new Byte[nValueLength];
                    Buffer.BlockCopy(pqwAttribValue, 0, pbValue, 0, nValueLength);

                    return (true);

                case WMT_ATTR_DATATYPE.WMT_TYPE_STRING:

                    nValueLength = (ushort)((pwszValue.Length + 1) * 2);
                    pbValue = new Byte[nValueLength];

                    Buffer.BlockCopy(pwszValue.ToCharArray(), 0, pbValue, 0, pwszValue.Length * 2);
                    pbValue[nValueLength - 2] = 0;
                    pbValue[nValueLength - 1] = 0;

                    return (true);

                case WMT_ATTR_DATATYPE.WMT_TYPE_BOOL:

                    nValueLength = 4;
                    pdwAttribValue = new uint[1] { Convert.ToUInt32(pwszValue) };
                    if (pdwAttribValue[0] != 0)
                    {
                        pdwAttribValue[0] = 1;
                    }

                    pbValue = new Byte[nValueLength];
                    Buffer.BlockCopy(pdwAttribValue, 0, pbValue, 0, nValueLength);

                    return (true);

                default:

                    pbValue = null;
                    nValueLength = 0;
                    Console.WriteLine("Unsupported data type.");

                    return (false);
            }
        }

        private IWMHeaderInfo3 CreateEditor(string pwszFileName)
        {
            if (this.m_IWMHeaderInfo3 == null)
            {
                this.m_IWMMetadataEditor = WMFSDKFunctions.CreateEditor();
                this.m_IWMMetadataEditor.Open(pwszFileName);

                this.m_IWMHeaderInfo3 = (IWMHeaderInfo3)this.m_IWMMetadataEditor;
            }
            return this.m_IWMHeaderInfo3;
        }

        #endregion
    }
}
