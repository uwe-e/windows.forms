using System;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Summary description for CReadDirectoriesAndFilesEventArgs.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2005 MCH Messe Schweiz (Basel) AG</copyright>
	public class ReadFilesEventArgs : EventArgs
	{

		#region FieldsPrivate
		
		private System.IO.FileInfo m_fileInfo;
		private AudioMetadata m_audioMetaData;

		#endregion

		#region Properties
		
		/// <summary>
		/// Exposes instance methods for creating, moving, and enumerating through directories and subdirectories.
		/// </summary>
		public System.IO.FileInfo FileInfo
		{
			get {return this.m_fileInfo;}
		}
		/// <summary>
		/// CAudioMetaData data object
		/// </summary>
		public AudioMetadata AudioMetadata
		{
			get {return this.m_audioMetaData;}
		}

		#endregion

		#region MethodsPublic
		
		/// <summary>
		/// Konstruktor der Klasse CReadDirectoriesAndFilesEventArgs.
		/// </summary>
		public ReadFilesEventArgs(System.IO.FileInfo fileInfo, AudioMetadata audioMetadata)
		{
			this.m_fileInfo = fileInfo;
			this.m_audioMetaData = audioMetadata;
		}

		#endregion

	}
}
