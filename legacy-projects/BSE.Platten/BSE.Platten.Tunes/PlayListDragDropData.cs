using System;

namespace BSE.Platten.Tunes
{
	/// <summary>
	/// Zusammenfassung f�r CPlayListDragDropData.
	/// </summary>
	public class PlayListDragDropData
	{
		#region FieldsPrivate
		
		private int m_iId;
		private PlayList.PlayListDragDropMode m_ePlayListDragDropMode;
		
		#endregion
		
		#region Properties
		
		public int Id
		{
			get {return this.m_iId;}
			set {this.m_iId = value;}
		}

		public PlayList.PlayListDragDropMode PlayListDragDropMode
		{
			get {return this.m_ePlayListDragDropMode;}
			set {this.m_ePlayListDragDropMode = value;}
		}
		
		#endregion

		#region MethodsPublic

        public PlayListDragDropData()
		{
			//
			// TODO: F�gen Sie hier die Konstruktorlogik hinzu
			//
		}

		#endregion
	}
}
