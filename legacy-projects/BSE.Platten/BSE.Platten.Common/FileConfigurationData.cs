using System;

namespace BSE.Platten.Common
{
	/// <summary>
    /// Contains the properties of the FileConfigurationData class.
	/// </summary>
    public class FileConfigurationData : IConfigurationData
	{
		#region FieldsPrivate
		
		private bool m_bEachAlbumGetsDirectory = true;
		private bool m_bTitleAsFileName;
		
		#endregion
		
		#region Properties
		
		public bool EachAlbumGetsDirectory
		{
			get {return m_bEachAlbumGetsDirectory;}
			set {m_bEachAlbumGetsDirectory = value;}
		}

		public bool TitleAsFileName
		{
			get {return m_bTitleAsFileName;}
			set {m_bTitleAsFileName = value;}
		}
		
		#endregion
	}
}
