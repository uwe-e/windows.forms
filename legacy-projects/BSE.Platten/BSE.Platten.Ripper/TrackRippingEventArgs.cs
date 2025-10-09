using System;

namespace BSE.Platten.Ripper
{
	/// <summary>
	/// Summary description for TrackRippingEventArgs.
	/// </summary>
	/// <remarks></remarks>
	public class TrackRippingEventArgs : System.EventArgs
	{

		#region FieldsPrivate
		
		private BSE.Platten.BO.CTrack m_Track;
		
		#endregion

		#region Properties
		
		public BSE.Platten.BO.CTrack Track
		{
			get {return this.m_Track;}
		}
		
		#endregion

		#region MethodsPublic
		/// <summary>
		/// Konstruktor der Klasse CTrackRippingEventArgs.
		/// </summary>
		public TrackRippingEventArgs(BSE.Platten.BO.CTrack track)
		{
			this.m_Track = track;
		}
		#endregion

	}
}
