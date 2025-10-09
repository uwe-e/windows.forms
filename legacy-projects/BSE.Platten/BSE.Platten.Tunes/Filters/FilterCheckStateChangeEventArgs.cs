using System;

using BSE.Platten.BO;

namespace BSE.Platten.Tunes.Filters
{
	/// <summary>
	/// Summary description for CCheckStateChangeEventArgs.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2004 MCH Messe Basel AG</copyright>
	public class FilterCheckStateChangeEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private bool m_bCheckState;
		private System.Windows.Forms.CheckBox m_checkBox;
		
		#endregion

		#region Properties
		
		public bool CheckState
		{
			get {return this.m_bCheckState;}
		}

        public System.Windows.Forms.CheckBox CheckBox
        {
            get { return this.m_checkBox; }
        }
		
		#endregion

		#region MethodsPublic
		/// <summary>
		/// Konstruktor der Klasse CCheckStateChangeEventArgs.
		/// </summary>
        public FilterCheckStateChangeEventArgs(System.Windows.Forms.CheckBox checkBox, bool bCheckState)
		{
            this.m_checkBox = checkBox;
			this.m_bCheckState = bCheckState;
		}
		#endregion
	}
}
