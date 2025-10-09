using System;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	/// <summary>
    /// Provides data for the SubItem events.
	/// </summary>
	public class SubItemEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private int m_iSubItemIndex = -1;
		private ListViewItem m_ListViewItem = null;
		
		#endregion
		
		#region Properties
		/// <summary>
        /// The index of the ListviewItem.SubItems
		/// </summary>
		public int SubItemIndex
		{
			get {return this.m_iSubItemIndex;}
		}
		/// <summary>
		/// The ListView that performs the event.
		/// </summary>
        public ListViewItem ListViewItem
		{
			get { return this.m_ListViewItem; }
		}
		
		#endregion

		#region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="SubItemEventArgs"/> class.
        /// </summary>
        /// <param name="listViewItem">The ListView that performs the event.</param>
        /// <param name="iSubItemIndex">The index of the ListviewItem.SubItems</param>
		public SubItemEventArgs(ListViewItem listViewItem, int iSubItemIndex)
		{
			this.m_iSubItemIndex = iSubItemIndex;
			this.m_ListViewItem = listViewItem;
		}

		#endregion
	}
}
