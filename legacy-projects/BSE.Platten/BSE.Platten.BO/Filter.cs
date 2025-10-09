using System;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CFilter.
	/// </summary>
	public class CFilter : ICloneable
	{

        #region FieldsPrivate
		
		private int m_iNumber;
		private int m_iId;
		private string m_strName;

		#endregion
		
		#region Properties
		
		public int Number
		{
			get {return this.m_iNumber;}
			set {this.m_iNumber = value;}
		}

		public int Id
		{
			get {return this.m_iId;}
			set {this.m_iId = value;}
		}
		
		public string Name
		{
			get {return this.m_strName;}
			set {this.m_strName = value;}
		}

		#endregion

		#region MethodsPublic

		public CFilter()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		public object Clone()
		{
			CFilter filter = new CFilter();
			filter.Number = this.m_iNumber;
			filter.Id = this.m_iId;
			filter.Name = this.Name;

			return filter;
		}

		#endregion

	}
}
