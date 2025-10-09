using System;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CMedium.
	/// </summary>
	public class CMediumData : ICloneable
	{
		#region FieldsPrivate
		
		private int m_iMediumId;
		private string m_strMedium;
		private string m_strBeschreibung;
		private System.Guid m_Guid;
		private System.DateTime m_dtTimeStamp;
		
		#endregion
		
		#region Properties
		
		public int MediumId
		{
			get {return this.m_iMediumId;}
			set {this.m_iMediumId = value;}
		}

		public string Medium
		{
			get {return this.m_strMedium;}
			set {this.m_strMedium = value;}
		}

		public string Beschreibung
		{
			get {return this.m_strBeschreibung;}
			set {this.m_strBeschreibung = value;}
		}
		
		public System.Guid Guid
		{
			get {return this.m_Guid;}
			set {this.m_Guid = value;}
		}

		public System.DateTime TimeStamp
		{
			get {return this.m_dtTimeStamp;}
			set {this.m_dtTimeStamp = value;}
		}
		
		#endregion

		#region MethodsPublic

        public CMediumData()
		{
		}

		public virtual object Clone()
		{
            CMediumData medium = new CMediumData();
			medium.MediumId = this.m_iMediumId;
			medium.Medium = this.m_strMedium;
			medium.Beschreibung = this.m_strBeschreibung;
			medium.Guid = this.m_Guid;
			medium.TimeStamp = this.m_dtTimeStamp;
			return medium;
		}

		#endregion
	}
}
