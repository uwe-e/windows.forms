using System;
using System.IO;
using BSE.Platten.BO;
using System.Globalization;
using BSE.Platten.Audio.Properties;
using BSE.Platten.Audio.WMFSDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
    /// A class that provides the capability to set or get descriptive attributes that are stored
    /// in the header section of a audio file.
	/// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
    public class WMFMediaData : AudioData
    {
        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="BSE.Platten.Audio.WMFMediaData"/> class.
        /// </summary>
		public WMFMediaData()
		{
		}
        /// <summary>
        /// The GetMediaMetaData method gets a <see cref="BSE.Platten.Audio.AudioMetaData"/> object containing the attributes that are stored
        /// in the header section of a audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <returns>A <see cref="BSE.Platten.Audio.AudioMetaData"/> object containing the stored attributes of a audio file.</returns>
		public override AudioMetadata GetMediaMetadata(string fileInfoFullName)
		{
            FileInfo fileInfo = new FileInfo(fileInfoFullName);
			AudioMetadata audioMetaData = null;
            if (fileInfo.Exists == true)
			{
                if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
				{
                    using (WMFSDK.MetadataEditor metaDataEditor = new WMFSDK.MetadataEditor())
                    {
                        audioMetaData = metaDataEditor.GetMediaMetadata(fileInfo.FullName);
                    }
				}
			}
			return audioMetaData;
		}
        /// <summary>
        /// The SetAttributeAuthor method sets the "Author" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "Author" attribute.</param>
		public override void SetAttributeAuthor(string fileInfoFullName,string pwszAttribValue)
		{
			SetAttribute(fileInfoFullName,WMFSDK.WMFSDKFunctions.g_wszWMAuthor,WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING,pwszAttribValue);
		}
        /// <summary>
        /// The SetAttributeAlbumTitle method sets the "WM/AlbumTitle" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/AlbumTitle" attribute.</param>
		public override void SetAttributeAlbumTitle(string fileInfoFullName,string pwszAttribValue)
		{
			SetAttribute(fileInfoFullName,WMFSDK.WMFSDKFunctions.g_wszWMAlbumTitle,WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING,pwszAttribValue);
		}
        /// <summary>
        /// The SetAttributeGenre method sets the "WM/Genre" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/Genre" attribute.</param>
		public override void SetAttributeGenre(string fileInfoFullName,string pwszAttribValue)
		{
			SetAttribute(fileInfoFullName,WMFSDK.WMFSDKFunctions.g_wszWMGenre,WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING,pwszAttribValue);
		}
        /// <summary>
        /// The SetAttributeYear method sets the "WM/Year" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/Year" attribute.</param>
		public override void SetAttributeYear(string fileInfoFullName,string pwszAttribValue)
		{
			SetAttribute(fileInfoFullName,WMFSDK.WMFSDKFunctions.g_wszWMYear,WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING,pwszAttribValue);
		}
        /// <summary>
        /// The SetAttributeTrackNumber method sets the "WM/TrackNumber" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/TrackNumber" attribute.</param>
		public override void SetAttributeTrackNumber(string fileInfoFullName,string pwszAttribValue)
		{
			SetAttribute(fileInfoFullName,WMFSDK.WMFSDKFunctions.g_wszWMTrackNumber,WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING,pwszAttribValue);
		}
        /// <summary>
        /// The SetAttributeTitle method sets the "Title" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "Title" attribute.</param>
		public override void SetAttributeTitle(string fileInfoFullName,string pwszAttribValue)
		{
			SetAttribute(fileInfoFullName,WMFSDK.WMFSDKFunctions.g_wszWMTitle,WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_STRING,pwszAttribValue);
		}
        /// <summary>
        /// The SetAttributePicture method sets the "WM/Picture" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="coverImage">The <see cref="System.Drawing.Image"/>value that is stored in the "WM/Picture" attribute.</param>
        public override void SetAttributePicture(string fileInfoFullName, System.Drawing.Image coverImage)
        {
            SetAttribute(
                fileInfoFullName,
                WMFSDK.WMFSDKFunctions.g_wszWMPicture,
                WMFSDK.WMT_ATTR_DATATYPE.WMT_TYPE_BINARY,
                coverImage);
        }
        /// <summary>
        /// The SetAttribute method sets a descriptive attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribName">The name of the attribute.</param>
        /// <param name="attrDataType">A <see cref="WMT_ATTR_DATATYPE"/> enumeration type.</param>
        /// <param name="attribValue">An object containing the value of the attribute.</param>
		public override void SetAttribute(string fileInfoFullName, string pwszAttribName,
            WMT_ATTR_DATATYPE attrDataType, object attribValue)
		{
			FileInfo fileInfo = new FileInfo(fileInfoFullName);
			if (fileInfo.Exists == true)
			{
                if (BSE.Platten.BO.Environment.IsWritableAudioExtension(fileInfo.Extension) == true)
                {
                    string pwszAttribValue = attribValue as string;
                    if (pwszAttribValue != null)
                    {
                        using (WMFSDK.MetadataEditor metaDataEditor = new BSE.Platten.Audio.WMFSDK.MetadataEditor())
                        {
                            metaDataEditor.SetAttribute(
                                fileInfoFullName,
                                pwszAttribName,
                                attrDataType,
                                pwszAttribValue);
                        }
                    }
                    System.Drawing.Image coverImage = attribValue as System.Drawing.Image;
                    if (coverImage != null)
                    {
                        using (WMFSDK.MetadataEditor metaDataEditor = new BSE.Platten.Audio.WMFSDK.MetadataEditor())
                        {
                            int iAttributeIndex = metaDataEditor.GetAttributeIndex(fileInfoFullName, pwszAttribName);
                            if (iAttributeIndex != -1)
                            {
                                metaDataEditor.DeleteAttribute(fileInfoFullName, iAttributeIndex);
                            }

                            using (WMPicture wmPicture = new WMPicture(coverImage, BSE.Platten.Audio.WMFSDK.PictureType.FrontCover, string.Empty))
                            {
                                byte[] bPictureData = wmPicture.GetWMPictureData();
                                if (bPictureData != null)
                                {
                                    metaDataEditor.SetAttribute(
                                        fileInfoFullName,
                                        pwszAttribName,
                                        attrDataType,
                                        bPictureData);
                                }
                            }
                        }
                    }
                }
                else
                {
                    string strInvalidAudioFileFormatException = String.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_InvalidAudioFileFormatException, fileInfo.Extension);
                    throw new System.IO.IOException(strInvalidAudioFileFormatException);
                }
			}
			else
			{
				string strFileNotFoundException = String.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_FileNotFoundException,fileInfoFullName);
				throw new FileNotFoundException(strFileNotFoundException);
			}
		}

		#endregion
    }
}
