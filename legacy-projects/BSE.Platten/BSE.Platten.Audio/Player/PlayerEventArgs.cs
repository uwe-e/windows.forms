using System;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für CPlayerEventArgs.
	/// </summary>
	public class PlayerEventArgs : System.EventArgs
	{
		#region FieldsPrivate
		
		private BSE.Platten.Audio.PlayMode m_playMode;
		private bool m_bPlayerHasStarted;
		
		#endregion
		
		#region Properties
		
		public BSE.Platten.Audio.PlayMode PlayMode
		{
			get {return this.m_playMode;}
		}

		public bool PlayerHasStarted
		{
			get {return this.m_bPlayerHasStarted;}
		}
		
		#endregion

		#region MethodsPublic

		public PlayerEventArgs()
		{
		}
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
		public PlayerEventArgs(bool bPlayerHasStarted)
		{
			this.m_bPlayerHasStarted = bPlayerHasStarted;
		}

		public PlayerEventArgs(BSE.Platten.Audio.PlayMode playMode)
		{
			this.m_playMode = playMode;
		}

		#endregion
	}
}
