using System;

namespace BSE.Platten.Audio.WinControls
{
	/// <summary>
	/// Zusammenfassung für ColumnHeader.
	/// </summary>
	public class ColumnHeader : BSE.Windows.Forms.ColumnHeader
	{
		#region FieldsPrivate
		
		private BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE m_AttrDataType;
		private string m_pbAttribValue;
		private BSE.Platten.Audio.MetadataPropertyName m_eMetaDataPropertyName;
		
		#endregion
		
		#region Properties
		
		public BSE.Platten.Audio.WMFSDK.WMT_ATTR_DATATYPE AttribDataType
		{
			get {return m_AttrDataType;}
			set {m_AttrDataType = value;}
		}
		
		public string AttribValue
		{
			get {return m_pbAttribValue;}
			set {m_pbAttribValue = value;}
		}
		
		public BSE.Platten.Audio.MetadataPropertyName MetaDataPropertyName
		{
			get {return m_eMetaDataPropertyName;}
			set {m_eMetaDataPropertyName = value;}
		}
		
		#endregion

		#region MethodsPublic

		public ColumnHeader()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		#endregion

	}
}
