using System;

namespace BSE.Platten.Tunes
{
	/// <summary>
	/// Zusammenfassung für CPlayListEventArgs.
	/// </summary>
	public class PlayListEventArgs : System.EventArgs
	{

		#region FieldsPrivate
		
		private BSE.Platten.BO.Playlist m_playList;
		private BSE.Platten.BO.CTrack m_track;
		
		#endregion
		
		#region Properties
		
		public BSE.Platten.BO.Playlist PlayList
		{
			get {return this.m_playList;}
		}

		public BSE.Platten.BO.CTrack Track
		{
			get {return this.m_track;}
		}
		
		#endregion

		#region MethodsPublic

		public PlayListEventArgs(BSE.Platten.BO.Playlist playList)
		{
			this.m_playList = playList;
		}

		public PlayListEventArgs(BSE.Platten.BO.CTrack track)
		{
			this.m_track = track;
		}

		#endregion

	}
}
