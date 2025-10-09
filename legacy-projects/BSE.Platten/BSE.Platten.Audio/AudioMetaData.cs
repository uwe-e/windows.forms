using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace BSE.Platten.Audio
{
	public enum MetadataPropertyName
	{
		None,
		WMTrackNumber,
		Author,
		WMAlbumTitle,
		Title,
		Duration,
		WMGenre,
		WMYear
	}
	/// <summary>
    /// Summary description for AudioMetadata.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2004 BSE</copyright>
	public class AudioMetadata
	{
		#region FieldsPrivate
		
		private string m_strFullName = string.Empty;
		private string m_strName = string.Empty;
		private string m_strExtension = string.Empty;
		private string m_strWMAlbumArtist = string.Empty;
		private string m_strWMAlbumTitle = string.Empty;
		private string m_strAudioFileUrl = string.Empty;
		private string m_strAuthor = string.Empty;
		private string m_strBeatsPerMinute = string.Empty;
		private int m_iBitrate;
		private string m_strContentDistributor = string.Empty;
		private string m_strCopyright = string.Empty;
		private string m_strCopyrightURL = string.Empty;
		private string m_strDescription = string.Empty;
		private long m_iFileSize;
		private string m_strWMGenre = string.Empty;
		private string m_strProvider = string.Empty;
		private string m_strPublisher = string.Empty;
		private string m_strTitle = string.Empty;
		private string m_strWMTrackNumber = string.Empty;
		private string m_strWMYear = string.Empty;
		private bool m_bHasAudio;

		#endregion

		#region Properties
		/// <summary>
        /// Gets the full path of the directory or file.
		/// </summary>
        /// <value>
        /// A string containing the full path.
        /// </value>
		public string FullName
		{
			get {return m_strFullName;}
			set {m_strFullName = value;}
		}
		/// <summary>
        /// Gets the name of the file.
		/// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
		public string Name
		{
			get {return m_strName;}
			set {m_strName = value;}
		}
        /// <summary>
        /// Gets the string representing the extension part of the file.
        /// </summary>
        /// <value>
        /// A string containing the <see cref="System.IO.FileSystemInfo"/> extension.
        /// </value>
		public string Extension
		{
			get {return m_strExtension;}
			set {m_strExtension = value;}
		}
		/// <summary>
        /// Gets the name of the primary artist for the album.
		/// </summary>
        /// <value>
        /// Type: <see cref="System.String"/>
        /// The name of the primary artist.
        /// </value>
		public string WMAlbumArtist
		{
			get {return m_strWMAlbumArtist;}
			set {m_strWMAlbumArtist = value;}
		}
		/// <summary>
        /// Gets the title of the album on which the content was originally released.
		/// </summary>
        /// <value>
        /// Type: <see cref="System.String"/>
        /// The title of the album.
        /// </value>
		public string WMAlbumTitle
		{
			get {return m_strWMAlbumTitle;}
			set {m_strWMAlbumTitle = value;}
		}
		/// <summary>
        /// Gets or sets the WM/AudioFileURL value. The WM/AudioFileURL value contains the address of an
        /// official Web page with information about the file in which this attribute appears.
        /// For example, a song might have a link back to the album page on the artist's Web site.
		/// </summary>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string AudioFileUrl
		{
			get {return m_strAudioFileUrl;}
			set {m_strAudioFileUrl = value;}
		}
		
		public string Author
		{
			get {return m_strAuthor;}
			set {m_strAuthor = value;}
		}
		
		public string BeatsPerMinute
		{
			get {return m_strBeatsPerMinute;}
			set {m_strBeatsPerMinute = value;}
		}

		public int Bitrate
		{
			get {return m_iBitrate;}
			set {m_iBitrate = value;}
		}

		public string ContentDistributor
		{
			get {return m_strContentDistributor;}
			set {m_strContentDistributor = value;}
		}
        /// <summary>
        /// Gets or sets the Copyright value. The Copyright value contains a copyright message for the content. 
        /// </summary>
		public string Copyright
		{
			get {return m_strCopyright;}
			set {m_strCopyright = value;}
		}
        /// <summary>
        /// Gets or sets the CopyrightURL value. The CopyrightURL value contains the Web address of
        /// a copyright page associated with branding.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
		public string CopyrightURL
		{
			get {return m_strCopyrightURL;}
			set {m_strCopyrightURL = value;}
		}
		
		public string Description
		{
			get {return m_strDescription;}
			set {m_strDescription = value;}
		}

        public TimeSpan Duration
        {
            get;
            set;
        }

		public long FileSize
		{
			get {return m_iFileSize;}
			set {m_iFileSize = value;}
		}

		public string WMGenre
		{
			get {return m_strWMGenre;}
			set {m_strWMGenre = value;}
		}

		public string Provider
		{
			get {return m_strProvider;}
			set {m_strProvider = value;}
		}

		public string Publisher
		{
			get {return m_strPublisher;}
			set {m_strPublisher = value;}
		}

		public string Title
		{
			get {return m_strTitle;}
			set {m_strTitle = value;}
		}

		public string WMTrackNumber
		{
			get {return m_strWMTrackNumber;}
			set {m_strWMTrackNumber = value;}
		}

		public string WMYear
		{
			get {return m_strWMYear;}
			set {m_strWMYear = value;}
		}

		public bool HasAudio
		{
			get {return m_bHasAudio;}
			set {m_bHasAudio = value;}
		}

		#endregion
    }
}
