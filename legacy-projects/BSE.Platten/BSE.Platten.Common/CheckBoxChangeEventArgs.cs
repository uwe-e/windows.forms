using System;
using System.Windows.Forms;

namespace BSE.Platten.Common
{
	/// <summary>
    /// Zusammenfassung für CheckBoxChangeEventArgs.
	/// </summary>
	public class CheckBoxChangeEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private CheckBox m_chkChangedCheckBox;
		
		#endregion
		
		#region Properties
		
		public CheckBox ChangedCheckBox
		{
			get {return m_chkChangedCheckBox;}
		}
		
		#endregion

		#region MethodsPublic

		public CheckBoxChangeEventArgs(CheckBox changedCheckBox)
		{
			this.m_chkChangedCheckBox = changedCheckBox;
		}

		#endregion
	}
}
