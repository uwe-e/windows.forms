using System;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.ComponentModel;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Sorts ListView according to custom columns Comparers.<br/>
	/// Custom ListViewItemSorter with pluggable cell comparators
	/// </summary>
	/// <copyright>
	/// Copyright © 2004-2006 MCH Messe Schweiz (Basel) AG<br/>
	/// http://www.codeproject.com/cs/miscctrl/listviewsorter.asp <br/>
	/// ListView Sorter<br/>By <b>gz</b> and reviewed by <b>bj</b><br/>
    /// Custom ListViewItemSorter with pluggable cell comparators  
	/// </copyright>
	/// <remarks>
	/// http://www.codeproject.com/cs/miscctrl/listviewsorter.asp <br/>
	/// ListView Sorter<br/>By <b>gz</b> and reviewed by <b>bj</b><br/>
	/// Custom ListViewItemSorter with pluggable cell comparators
	/// </remarks>
    [DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(ListViewItemSorter), "ListViewItemSorter")]
    public class ListViewItemSorter : BaseListViewItemSorter
	{
		#region Delegates
		/// <summary>
		/// Basic comparer.
		/// </summary>
        /// <param name="strX">First string to compare.</param>
        /// <param name="strY">Second string to compare.</param>
		/// <returns>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <description>Condition</description>
		///   </listheader>
		///   <item>
		///     <term>Less than zero</term>
		///     <description><paramref name="strA"/> is less than <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Zero</term>
		///     <description><paramref name="strA"/> equals <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Greater than zero</term>
		///     <description><paramref name="strA"/> is greater than <paramref name="strB"/>.</description>
		///   </item>
		/// </list>
		/// </returns>
		private delegate int Comparer(string strX, string strY);
		#endregion

		#region FieldsPrivate
		/// <summary>
		/// Columns Comparers.
		/// </summary>.
		private Comparer[] m_arComparers;
		/// <summary>
		/// Parent ListView.
		/// </summary>
		private ListView m_lstvParent;
		#endregion

		#region Properties
		/// <summary>
		/// Parent ListView.
		/// </summary>
		/// <value>
		/// Parent ListView.
		/// </value>
		public override ListView ListView
		{
			get
			{
				return this.m_lstvParent;
			}
			set
			{
				if ((this.m_lstvParent == value) &&
					(this.m_lstvParent.Columns.Count == this.m_arComparers.Length))
				{
					return;
				}

				// unwire old
				if (this.m_lstvParent != null)
				{
					this.m_lstvParent.ColumnClick -= new ColumnClickEventHandler(this.ListViewColumnClick);
                    this.m_lstvParent.ListViewItemSorter = null;
				}

				// setup data
				this.m_lstvParent = value;

				base.SortOrder = SortOrder.None;
				// wire new
				if (this.m_lstvParent != null)
				{
                    this.m_arComparers = this.m_lstvParent != null ? new Comparer[this.m_lstvParent.Columns.Count] : null;
                    this.m_lstvParent.ColumnClick += new ColumnClickEventHandler(this.ListViewColumnClick);
                    this.m_lstvParent.ListViewItemSorter = this;
                    CreateListViewItemSorter();
				}
			}
		}
		#endregion

		#region MethodsPublic
		/// <overloads>
		/// Creates new instance.
		/// </overloads>
		/// <summary>
		/// Creates new instance.
		/// </summary>
		public ListViewItemSorter()
		{
            base.SortOrder = SortOrder.None;
		}
        /// <summary>
        /// Compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">First object to compare.</param>
        /// <returns>
        /// <list type="table">
        ///   <listheader>
        ///     <term>Value</term>
        ///     <description>Condition</description>
        ///   </listheader>
        ///   <item>
        ///     <term>Less than zero</term>
        ///     <description><paramref name="x"/> is less than <paramref name="y"/>.</description>
        ///   </item>
        ///   <item>
        ///     <term>Zero</term>
        ///     <description><paramref name="x"/> equals <paramref name="y"/>.</description>
        ///   </item>
        ///   <item>
        ///     <term>Greater than zero</term>
        ///     <description><paramref name="x"/> is greater than <paramref name="y"/>.</description>
        ///   </item>
        /// </list>
        /// </returns>
        public override int Compare(Object x,Object y)
        {
            // verify data
            if ((this.m_lstvParent == null) ||
                (base.SortOrder == SortOrder.None) ||
                (base.SortColumnIndex < 0) ||
                (this.m_arComparers == null) ||
                (this.m_arComparers.Length <= base.SortColumnIndex))
            {
                return 0;
            }

            // verify arguments
            ListViewItem listViewItemX = x as ListViewItem;
            ListViewItem listViewItemY = y as ListViewItem;

            if ((listViewItemX == null) || (listViewItemY == null))
            {
                return 0;
            }

            if ((listViewItemX.ListView != this.m_lstvParent) ||
                (listViewItemY.ListView != this.m_lstvParent))
            {
                throw new Exception("CListViewSorter.IComparer.Compare: Invalid arguments.");
            }

            if ((listViewItemX.SubItems == null) || (listViewItemX.SubItems.Count <= base.SortColumnIndex))
            {
                return 0;
            }
            if ((listViewItemY.SubItems == null) || (listViewItemY.SubItems.Count <= base.SortColumnIndex))
            {
                return 0;
            }

            // compare
            int iCompareValue = this.m_arComparers[base.SortColumnIndex](listViewItemX.SubItems[base.SortColumnIndex].Text, listViewItemY.SubItems[base.SortColumnIndex].Text);

            if (base.SortOrder == SortOrder.Descending)
            {
                iCompareValue *= -1;
            }
            return iCompareValue;
        }

		#endregion

		#region MethodsPrivate
        /// <summary>
		/// Handles sorting request.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Eventarguments</param>
		private void ListViewColumnClick(object sender, ColumnClickEventArgs e)
		{
			// verify arguments
			BSE.Windows.Forms.ListView listView = sender as BSE.Windows.Forms.ListView;
            if (listView != null)
            {
                if (this.m_lstvParent.Columns.Count != this.m_arComparers.Length)
                {
                    this.ListView = m_lstvParent;
                }
                int iColumnIndex = e.Column;
                // sort
                SortBy(iColumnIndex, base.SortColumnIndex != iColumnIndex || base.SortOrder != SortOrder.Ascending);
            }
		}
        private void CreateListViewItemSorter()
        {
            int iColumnsCount = this.ListView.Columns.Count;

            for (int i = 0; i < iColumnsCount; i++)
            {
                BSE.Windows.Forms.ColumnHeader columnHeader = this.ListView.Columns[i] as BSE.Windows.Forms.ColumnHeader;
                ListViewComparer listViewComparer = columnHeader.ListViewComparer;
                switch (listViewComparer)
                {
                    case BSE.Windows.Forms.ListViewComparer.Strings:
                        m_arComparers[i] = new Comparer(CompareStrings);
                        break;
                    case BSE.Windows.Forms.ListViewComparer.Numbers:
                        m_arComparers[i] = new Comparer(CompareNumbers);
                        break;
                    case BSE.Windows.Forms.ListViewComparer.Dates:
                        m_arComparers[i] = new Comparer(CompareDates);
                        break;
                    case BSE.Windows.Forms.ListViewComparer.Guids:
                        m_arComparers[i] = new Comparer(CompareGuids);
                        break;
                    default:
                        m_arComparers[i] = new Comparer(CompareStrings);
                        break;
                }
            }
        }
		/// <summary>
		/// Standard strings comparer.
		/// </summary>
        /// <param name="strX">First string to compare.</param>
        /// <param name="strY">Second string to compare.</param>
		/// <returns>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <description>Condition</description>
		///   </listheader>
		///   <item>
		///     <term>Less than zero</term>
		///     <description><paramref name="strA"/> is less than <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Zero</term>
		///     <description><paramref name="strA"/> equals <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Greater than zero</term>
		///     <description><paramref name="strA"/> is greater than <paramref name="strB"/>.</description>
		///   </item>
		/// </list>
		/// </returns>
		private static int CompareStrings(string strX, string strY)
		{
            return string.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);
		}
		/// <summary>
		/// Standard numbers comparer.
		/// </summary>
        /// <param name="strX">First string to compare.<br/>
        /// Falls strX gleich '--' ist, so wird dies wie 0.0 betrachtet.</param>
        /// <param name="strY">Second string to compare.<br/>
        /// Falls strY gleich '--' ist, so wird dies wie 0.0 betrachtet.</param>
		/// <returns>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <description>Condition</description>
		///   </listheader>
		///   <item>
		///     <term>Less than zero</term>
		///     <description><paramref name="strA"/> is less than <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Zero</term>
		///     <description><paramref name="strA"/> equals <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Greater than zero</term>
		///     <description><paramref name="strA"/> is greater than <paramref name="strB"/>.</description>
		///   </item>
		/// </list>
		/// </returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
        private static int CompareNumbers(string strX, string strY)
		{
			double dX;
			double dY;
            
            double.TryParse(strX, out dX);
            double.TryParse(strY, out dY);

			return dX.CompareTo(dY);
		}
		/// <summary>
		/// Standard dates comparer.
		/// </summary>
        /// <param name="strX">First string to compare.<br/>
        /// Falls strX gleich '--' ist, so wird dies wie <see cref="DateTime.MinValue"/> 
		/// betrachtet.</param>
        /// <param name="strY">Second string to compare.<br/>
        /// Falls strY gleich '--' ist, so wird dies wie <see cref="DateTime.MinValue"/> 
		/// betrachtet.</param>
		/// <returns>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <description>Condition</description>
		///   </listheader>
		///   <item>
		///     <term>Less than zero</term>
		///     <description><paramref name="strA"/> is less than <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Zero</term>
		///     <description><paramref name="strA"/> equals <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Greater than zero</term>
		///     <description><paramref name="strA"/> is greater than <paramref name="strB"/>.</description>
		///   </item>
		/// </list>
		/// </returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
		private static int CompareDates(string strX, string strY)
		{
			DateTime dtX = DateTime.MinValue;
			DateTime dtY = DateTime.MinValue;

            DateTime.TryParse(strX, out dtX);
            DateTime.TryParse(strY, out dtY);

			return DateTime.Compare(dtX, dtY);
		}
		/// <summary>
		/// Standard guid comparer.
		/// </summary>
        /// <param name="strX">First string to compare.<br/>
        /// Falls strX gleich '--' ist, so wird dies wie <see cref="Guid.Empty"/> betrachtet.</param>
        /// <param name="strY">Second string to compare.<br/>
        /// Falls strY gleich '--' ist, so wird dies wie <see cref="Guid.Empty"/> betrachtet.</param>
		/// <returns>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <description>Condition</description>
		///   </listheader>
		///   <item>
		///     <term>Less than zero</term>
		///     <description><paramref name="strA"/> is less than <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Zero</term>
		///     <description><paramref name="strA"/> equals <paramref name="strB"/>.</description>
		///   </item>
		///   <item>
		///     <term>Greater than zero</term>
		///     <description><paramref name="strA"/> is greater than <paramref name="strB"/>.</description>
		///   </item>
		/// </list>
		/// </returns>
		private static int CompareGuids(string strX, string strY)
		{
			Guid guidX = Guid.Empty;
			Guid guidY = Guid.Empty;
			
            try
			{
				if (strX != "--")
				{
					guidX = new Guid(strX);
				}
			}
			catch (Exception exception)
			{
				// Es ist keine Guid. Fehler ignorieren.
				// Tritt auf wenn der Wert auf der Datenbank null ist.
				System.Diagnostics.Trace.WriteLine(exception.ToString());
			}
			try
			{
				if (strY != "--")
				{
					guidY = new Guid(strY);
				}
			}
			catch (Exception exception)
			{
				// Es ist keine Guid. Fehler ignorieren.
				// Tritt auf wenn der Wert auf der Datenbank null ist.
				System.Diagnostics.Trace.WriteLine(exception.ToString());
			}

			return guidX.CompareTo(guidY);
		}
        #endregion
    }
}