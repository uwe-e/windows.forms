using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Configuration
{
	public class VisualObjectItem
	{
		#region FieldsPrivate
		private string m_strDisplayMember;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the DisplayMember of the ComboBox
		/// </summary>
		public string DisplayMember
		{
			get { return this.m_strDisplayMember; }
			set { this.m_strDisplayMember = value; }
		}
		#endregion
	}
}
