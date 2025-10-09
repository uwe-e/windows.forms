using System;

using BSE.Platten.Common;

namespace BSE.Platten.Audio
{
	/// <summary>
    /// Contains the properties of the AudioImportConfigurationData class.
	/// </summary>
    public class AudioImportConfigurationData : IConfigurationData
	{
		#region FieldsPrivate
		
		private BSE.Shell.FileOperation m_FileOperations = BSE.Shell.FileOperation.FO_COPY;
		
		#endregion
		
		#region Properties
		
		public BSE.Shell.FileOperation FileOperations
		{
			get {return this.m_FileOperations;}
			set {this.m_FileOperations = value;}
		}

		#endregion
	}
}
