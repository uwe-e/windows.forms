using System;

namespace BSE.Platten.Audio
{
	/// <summary>
	/// Zusammenfassung für CWriteTagEventArgs.
	/// </summary>
	public class WriteTagEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private BSE.Platten.BO.CTrack m_track;
		
		#endregion
		
		#region Properties

		public BSE.Platten.BO.CTrack Track
		{
			get {return this.m_track;}
		}
		#endregion

		#region MethodsPublic

		public WriteTagEventArgs(BSE.Platten.BO.CTrack track)
		{
			this.m_track = track;
		}

		#endregion

	}
}
