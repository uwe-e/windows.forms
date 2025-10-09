using System;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CFavorites.
	/// </summary>
	public class CFavorite : BSE.Platten.BO.CTrack
	{
		#region FieldsPrivate
		
		private int m_iCount;
		
		#endregion
		
		#region Properties
		
		public int Count
		{
			get {return m_iCount;}
			set {m_iCount = value;}
		}
		
		#endregion

		#region MethodsPublic

		public CFavorite()
		{
		}

		public override object Clone()
		{
			BSE.Platten.BO.CFavorite favorite = new BSE.Platten.BO.CFavorite();
			favorite.Count = this.m_iCount;
			return favorite;
		}
		#endregion
	}
}
