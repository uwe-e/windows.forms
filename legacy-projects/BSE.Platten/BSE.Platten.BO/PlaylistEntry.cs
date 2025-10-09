using System;

namespace BSE.Platten.BO
{
	/// <summary>
    /// Zusammenfassung für PlaylistEntry.
	/// </summary>
	public class PlaylistEntry : BSE.Platten.BO.CTrack
	{
		#region Properties
		
		public int EntryId
		{
			get;
			set;
		}

		public int PlayListId
		{
            get;
            set;
		}

		public System.Guid Guid
		{
            get;
            set;
		}

		public System.DateTime TimeStamp
		{
            get;
            set;
		}
		
		#endregion

		#region MethodsPublic

		public PlaylistEntry()
		{
		}

		public override object Clone()
		{
			BSE.Platten.BO.PlaylistEntry playlistEntry = new BSE.Platten.BO.PlaylistEntry();
            playlistEntry.EntryId = this.EntryId;
			playlistEntry.PlayListId = this.PlayListId;
			playlistEntry.Guid = this.Guid;
			playlistEntry.TimeStamp = this.TimeStamp;
			return playlistEntry;
		}

		#endregion
	}
}
