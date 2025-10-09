using System;
using BSE.Platten.Audio.WMFSDK;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
    /// A abstract class that provides the capability to set or get descriptive attributes that are stored
    /// in the header section of a audio file.
	/// </summary>
	public abstract class AudioData
	{
		#region MethodsPublic
		/// <summary>
        /// The GetMediaMetadata method gets a <see cref="BSE.Platten.Audio.AudioMetaData"/> object containing the attributes that are stored
        /// in the header section of a audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <returns>A <see cref="BSE.Platten.Audio.AudioMetaData"/> object containing the stored attributes of a audio file.</returns>
        public abstract AudioMetadata GetMediaMetadata(string fileInfoFullName);
		/// <summary>
        /// The SetAttributeAuthor method sets the "Author" attribute that is stored in the header section of the audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
		/// <param name="pwszAttribValue">The value that is stored in the "Author" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributeAuthor(string fileInfoFullName,string pwszAttribValue);
		/// <summary>
        /// The SetAttributeAlbumTitle method sets the "WM/AlbumTitle" attribute that is stored in the header section of the audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/AlbumTitle" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributeAlbumTitle(string fileInfoFullName,string pwszAttribValue);
		/// <summary>
        /// The SetAttributeGenre method sets the "WM/Genre" attribute that is stored in the header section of the audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/Genre" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributeGenre(string fileInfoFullName,string pwszAttribValue);
		/// <summary>
        /// The SetAttributeYear method sets the "WM/Year" attribute that is stored in the header section of the audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/Year" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributeYear(string fileInfoFullName,string pwszAttribValue);
		/// <summary>
        /// The SetAttributeTrackNumber method sets the "WM/TrackNumber" attribute that is stored in the header section of the audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "WM/TrackNumber" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributeTrackNumber(string fileInfoFullName,string pwszAttribValue);
		/// <summary>
        /// The SetAttributeTitle method sets the "Title" attribute that is stored in the header section of the audio file.
		/// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribValue">The value that is stored in the "Title" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributeTitle(string fileInfoFullName,string pwszAttribValue);
        /// <summary>
        /// The SetAttributePicture method sets the "WM/Picture" attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="coverImage">The <see cref="System.Drawing.Image"/>value that is stored in the "WM/Picture" attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttributePicture(string fileInfoFullName, System.Drawing.Image coverImage);
        /// <summary>
        /// The SetAttribute method sets a descriptive attribute that is stored in the header section of the audio file.
        /// </summary>
        /// <param name="fileInfoFullName">The fully qualified path of the audio file.</param>
        /// <param name="pwszAttribName">The name of the attribute.</param>
        /// <param name="attrDataType">A <see cref="WMT_ATTR_DATATYPE"/> enumeration type.</param>
        /// <param name="attribValue">An object containing the value of the attribute.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public abstract void SetAttribute(string fileInfoFullName, string pwszAttribName,
            WMT_ATTR_DATATYPE attrDataType, object attribValue);
		#endregion
	}
}
