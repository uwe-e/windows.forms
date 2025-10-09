using System;

namespace BSE.Platten.Tunes.Filters
{
	/// <summary>
	/// Zusammenfassung für CFilterNotificationEventArgs.
	/// </summary>
	public class FilterNotificationEventArgs : System.EventArgs
	{
		#region FieldsPrivate
		
		private System.Windows.Forms.CheckBox m_checkBox;
		
		#endregion
		
		#region Properties
		
		public System.Windows.Forms.CheckBox CheckBox
		{
			get {return this.m_checkBox;}
		}
		
		#endregion

		#region MethodsPublic

		public FilterNotificationEventArgs(System.Windows.Forms.CheckBox checkBox)
		{
			this.m_checkBox = checkBox;
		}

		#endregion
	}
}
