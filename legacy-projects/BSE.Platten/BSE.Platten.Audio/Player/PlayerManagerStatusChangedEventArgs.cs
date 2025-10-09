using System;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für CPlayerManagerStatusChangedEventArgs.
	/// </summary>
	public class PlayerManagerStatusChangedEventArgs : EventArgs
	{
		#region FielsPrivate

		private bool m_bHasPlayerStarted;
		private BSE.Platten.BO.CTrack m_currentTrack;
		private BSE.Platten.Audio.PlayMode m_playMode;

		#endregion
		
		#region Properties

		public bool HasPlayerStarted
		{
			get {return this.m_bHasPlayerStarted;}
		}

		public BSE.Platten.BO.CTrack CurrentTrack
		{
			get {return this.m_currentTrack;}
		}

		public BSE.Platten.Audio.PlayMode PlayMode
		{
			get {return this.m_playMode;}
		}
		
		#endregion

		#region MethodsPublic

		public PlayerManagerStatusChangedEventArgs()
		{
		}
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
		public PlayerManagerStatusChangedEventArgs(bool bHasPlayerStarted)
		{
			this.m_bHasPlayerStarted = bHasPlayerStarted;
		}

		public PlayerManagerStatusChangedEventArgs(BSE.Platten.Audio.PlayMode playMode)
		{
			this.m_playMode = playMode;
		}

		public PlayerManagerStatusChangedEventArgs(BSE.Platten.BO.CTrack currentTrack, BSE.Platten.Audio.PlayMode playMode)
		{
			this.m_currentTrack = currentTrack;
			this.m_playMode = playMode; 
		}

		#endregion
	}
}
