using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// BaseListViewItemSorter for sorting ListViewItems according to custom columns Comparers.
    /// </summary>
    public abstract class BaseListViewItemSorter : Component, IListViewItemSorter
    {
        #region FieldsPrivate
        /// <summary>
        /// Gets or sets the index of the column in the ListView.
        /// </summary>
        private int m_iSortColumnIndex;
        /// <summary>
        /// Gets or sets the index of the column in the ListView.
        /// </summary>
        private SortOrder m_sortOrder;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ListView for this ListViewItemSorter
        /// </summary>
        /// <value>
        /// Parent ListView.
        /// </value>
        public abstract BSE.Windows.Forms.ListView ListView {get; set;}
        /// <summary>
        /// Gets or sets the index of the column in the ListView.
        /// </summary>
        public int SortColumnIndex
        {
            set { this.m_iSortColumnIndex = value; }
            get { return this.m_iSortColumnIndex; }
        }
        /// <summary>
        /// Specifies how the ListViewItems in the ListView are sorted.
        /// </summary>		
        public SortOrder SortOrder
        {
            set { this.m_sortOrder = value; }
            get { return this.m_sortOrder; }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Compares two items.
        /// </summary>
        /// <summary>
        /// Compares two objects and returns a value indicating whether one 
        /// is less than, equal to or greater than the other.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
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
        public abstract int Compare(Object x, Object y);
        /// <summary>
        /// Sorts the ListView by column.
        /// </summary>
        /// <param name="iColIndex">Index of the column.</param>
        /// <param name="bAscending"><b>true:</b> sort order ascending<br/>
        /// <b>false:</b> sort order descending.</param>
        public void SortBy(int iColIndex, bool bAscending)
        {
            this.m_iSortColumnIndex = iColIndex;
            this.m_sortOrder = bAscending ? SortOrder.Ascending : SortOrder.Descending;

            if (this.ListView != null)
            {
                // Perform the sort with these new sort options.
                this.ListView.Sort();
            }
        }
        /// <summary>
        /// Sorts the ListView by column.
        /// </summary>
        /// <param name="columnHeader">Column to get the index for the comparer.</param>
        /// <param name="bAscending"><b>true:</b> sort order ascending<br/>
        /// <b>false:</b> sort order descending.</param>
        public void SortBy(System.Windows.Forms.ColumnHeader columnHeader, bool bAscending)
        {
            SortBy(columnHeader.Index, bAscending);
        }
        #endregion
    }
}
