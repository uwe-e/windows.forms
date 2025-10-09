using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class CInterpretData : ICloneable
    {
        #region FieldsPrivate
		
		private int m_iInterpretId;
		private string m_strInterpret;
		private string m_strInterpretLang;
		private System.Guid m_Guid;
		private System.DateTime m_dtTimeStamp;
		private BSE.Platten.BO.Album[] m_albums;
		
		#endregion
		
		#region Properties
		
		public int InterpretId
		{
			get {return this.m_iInterpretId;}
			set {this.m_iInterpretId = value;}
		}

		public string Interpret
		{
			get {return this.m_strInterpret;}
			set {this.m_strInterpret = value;}
		}

		public string InterpretLang
		{
			get {return this.m_strInterpretLang;}
			set {this.m_strInterpretLang = value;}
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

		public BSE.Platten.BO.Album[] Albums
		{
			get {return this.m_albums;}
			set {this.m_albums = value;}
		}
		
		#endregion

		#region MethodsPublic

		public CInterpretData()
		{
		}

		public virtual object Clone()
		{
            CInterpretData interpret = new CInterpretData();
			interpret.InterpretId = this.m_iInterpretId;
			interpret.Interpret = this.m_strInterpret;
			interpret.InterpretLang = this.m_strInterpretLang;
			interpret.Guid = this.m_Guid;
			interpret.TimeStamp = this.m_dtTimeStamp;
			interpret.Albums = this.m_albums;
			return interpret;
		}
		#endregion
    }
}
