using System;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Occurs when edit on the control ends.
	/// </summary>
	public class SubItemEndEditingEventArgs : BSE.Windows.Forms.SubItemEventArgs
	{
		#region FieldsPrivate
		
		private string m_strDisplayText = string.Empty;
		private bool m_bCancel = true;
		
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the text of the ListViewItem.SubItem
		/// </summary>
		public string DisplayText
		{
			get { return this.m_strDisplayText; }
            set { this.m_strDisplayText = value; }
		}
        /// <summary>
        /// Gets a value indicating whether the changes in a ListViewItem.SubItem was cancelled.
        /// </summary>
		public bool Cancel
		{
			get { return this.m_bCancel; }
		}
		
		#endregion

		#region MethodsPublic
		/// <summary>
        /// Initializes a new instance of the <see cref="SubItemEndEditingEventArgs"/> class.
		/// </summary>
        /// <param name="listViewItem">The ListView that performs the event.</param>
        /// <param name="iSubItemIndex">The index of the ListviewItem.SubItems</param>
        /// <param name="strDisplay">The text of the ListviewItem.SubItem</param>
		/// <param name="bCancel">A value indicating whether the changes in a ListViewItem.SubItem was cancelled.</param>
        public SubItemEndEditingEventArgs(ListViewItem listViewItem, int iSubItemIndex, string strDisplay, bool bCancel) :
			base(listViewItem, iSubItemIndex)
		{
			this.m_strDisplayText = strDisplay;
			this.m_bCancel = bCancel;
		}

		#endregion
	}
}
