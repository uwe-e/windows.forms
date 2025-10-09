using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Defines methods for ListViewItemSorters.
    /// </summary>
    public interface IListViewItemSorter : IComparer
    {
        /// <summary>
        /// Gets or sets the index of the column.
        /// </summary>
        int SortColumnIndex { get; set; }
        /// <summary>
        /// Parent ListView.
        /// </summary>
        /// <value>
        /// Parent ListView.
        /// </value>
        BSE.Windows.Forms.ListView ListView { get; set; }
        /// <summary>
        /// Specifies how items in a list are sorted.
        /// </summary>
        SortOrder SortOrder { get; set; }
        /// <summary>
        /// Sorts list by column.
        /// </summary>
        /// <param name="iColIndex">Index of the column.</param>
        /// <param name="bAscending"><b>true:</b> sort order ascending<br/>
        /// <b>false:</b> sort order descending.</param>
        void SortBy(int iColIndex, bool bAscending);
    }
}
