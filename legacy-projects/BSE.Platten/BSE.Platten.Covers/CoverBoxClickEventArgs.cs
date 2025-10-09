using System;

namespace BSE.Platten.Covers
{
	/// <summary>
    /// Zusammenfassung für CoverBoxClickEventArgs.
	/// </summary>
	public class CoverBoxClickEventArgs : System.EventArgs
	{
		#region FieldsPrivate
		
		private int m_iTitelId;
		
		#endregion
		
		#region Properties
        /// <summary>
        /// Gets the TitelId of the album
        /// </summary>
		public int TitelId
		{
			get {return this.m_iTitelId;}
		}
		
		#endregion

		#region MethodsPublic
        /// <summary>
        /// Arguments used when a CoverBoxClick event occurs.
        /// </summary>
        /// <param name="titelId">the titelid of the album.</param>
		public CoverBoxClickEventArgs(int titelId)
		{
			this.m_iTitelId = titelId;
		}

		#endregion
	}
}
