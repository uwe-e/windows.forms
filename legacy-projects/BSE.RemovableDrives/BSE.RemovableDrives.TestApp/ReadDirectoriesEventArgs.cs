using System;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Summary description for CReadDirectoriesAndFilesEventArgs.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2005 MCH Messe Schweiz (Basel) AG</copyright>
	public class ReadDirectoriesEventArgs : EventArgs
	{

		#region FieldsPrivate
		
		private System.IO.DirectoryInfo m_directoryInfo;

		#endregion

		#region Properties
		
		/// <summary>
		/// Exposes instance methods for creating, moving, and enumerating through directories and subdirectories.
		/// </summary>
		public System.IO.DirectoryInfo DirectoryInfo
		{
			get {return this.m_directoryInfo;}
		}

		#endregion

		#region MethodsPublic
		
		/// <summary>
		/// Konstruktor der Klasse CReadDirectoriesAndFilesEventArgs.
		/// </summary>
		public ReadDirectoriesEventArgs(System.IO.DirectoryInfo directoryInfo)
		{
			this.m_directoryInfo = directoryInfo;
		}

		#endregion

	}
}
