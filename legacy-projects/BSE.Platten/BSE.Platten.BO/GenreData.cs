using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class CGenreData : ICloneable
    {
		#region FieldsPrivate

		private int m_iGenreId;
		private string m_strGenre;
		private System.Guid m_Guid;
		private System.DateTime m_dtTimeStamp;
		private BSE.Platten.BO.Album[] m_albums;
		
		#endregion
		
		#region Properties
		
		public int GenreId
		{
			get {return this.m_iGenreId;}
			set {this.m_iGenreId = value;}
		}

		public string Genre
		{
			get {return this.m_strGenre;}
			set {this.m_strGenre = value;}
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

        public CGenreData()
		{
		}

		public virtual object Clone()
		{
            CGenreData genre = new CGenreData();
			genre.GenreId = this.m_iGenreId;
			genre.Genre = this.m_strGenre;
			genre.Guid = this.m_Guid;
			genre.TimeStamp = this.m_dtTimeStamp;
			genre.Albums = this.m_albums;
			return genre;
		}
		#endregion
    }
}
