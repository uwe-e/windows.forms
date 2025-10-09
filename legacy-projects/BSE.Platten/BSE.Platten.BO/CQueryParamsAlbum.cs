using System;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammendfassende Beschreibung für CQueryParamsAlbum.
	/// </summary>
	public class CQueryParamsAlbum
	{
		#region Fields

        private string m_strInterpret;
		private string m_strTitel;
		private int m_iMediumId;
		private int m_iGenreId;
		private int m_iErschDatum;
		private int m_iMP3Tag;

		#endregion

		#region Properties

		public string Interpret
		{
			get {return this.m_strInterpret;}
			set {this.m_strInterpret = value;}
		}

		public string Titel
		{
			get {return this.m_strTitel;}
			set {this.m_strTitel = value;}
		}

		public int MediumId
		{
			get {return this.m_iMediumId;}
			set {this.m_iMediumId = value;}
		}

		public int GenreId
		{
			get {return this.m_iGenreId;}
			set {this.m_iGenreId = value;}
		}

		public int ErschDatum
		{
			get {return this.m_iErschDatum;}
			set {this.m_iErschDatum = value;}
		}

		public int MP3Tag
		{
			get {return this.m_iMP3Tag;}
			set {this.m_iMP3Tag = value;}
		}
		
		#endregion
	}
}
