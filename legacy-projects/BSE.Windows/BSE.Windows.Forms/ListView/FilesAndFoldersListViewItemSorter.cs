using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Sorts ListViewItems in the ListView like Windows Explorer<br/>
    /// Custom ListViewItemSorter with pluggable cell comparators
    /// </summary>
    [DesignTimeVisibleAttribute(true)]
    [ToolboxBitmap(typeof(FilesAndFoldersListViewItemSorter), "ListViewItemSorter")]
    public class FilesAndFoldersListViewItemSorter : BaseListViewItemSorter
    {
        #region Delegates
        /// <summary>
        /// Basic comparer.
        /// </summary>
        /// <param name="listViewItemX">First listviewItem to compare</param>
        /// <param name="listViewItemY">Second listviewItem to compare</param>
        /// <param name="iSortColumnIndex">The Index of the current column</param>
        /// <param name="iFileSystemColumnIndex">The Index of the FileSystem column</param>
        /// <returns></returns>
        private delegate int Comparer(ListViewItem listViewItemX, ListViewItem listViewItemY, int iSortColumnIndex, int iFileSystemColumnIndex);
        #endregion
        #region FieldsPrivate
        /// <summary>
        /// Parent ListView.
        /// </summary>
        private BSE.Windows.Forms.ListView m_lstvParent;
        /// <summary>
        /// Current column index.
        /// </summary>
        private int m_iFileSystemColumnIndex = -1;
        /// <summary>
        /// Columns Comparers.
        /// </summary>.
        private Comparer[] m_arComparers;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the ListView for the ListViewItemSorter.
        /// </summary>
        /// <value>
        /// The ListView for the ListViewItemSorter.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override BSE.Windows.Forms.ListView ListView
        {
            get
            {
                return this.m_lstvParent;
            }
            set
            {
                if (this.m_lstvParent == value)
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
                    CreateListViewSorter();
                }
            }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Creates new instance of the FilesAndFoldersListViewItemSorter.
        /// </summary>
        public FilesAndFoldersListViewItemSorter()
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
        public override int Compare(Object x, Object y)
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

            if (this.m_iFileSystemColumnIndex == -1)
            {
                BSE.Windows.Forms.ColumnHeaderCollection columnHeaders = this.m_lstvParent.Columns as BSE.Windows.Forms.ColumnHeaderCollection;
                if ((columnHeaders != null) && (columnHeaders.Count > 0))
                {
                    foreach (BSE.Windows.Forms.ColumnHeader columnHeader in columnHeaders)
                    {
                        if (columnHeader.ListViewComparer == BSE.Windows.Forms.ListViewComparer.FileSystem)
                        {
                            this.m_iFileSystemColumnIndex = columnHeader.Index;
                            break;
                        }
                    }
                }
            }

            ListViewItem listviewItemX = x as ListViewItem;
            ListViewItem listviewItemY = y as ListViewItem;
            int iCompareValue = 0;

            iCompareValue = this.m_arComparers[base.SortColumnIndex](listviewItemX, listviewItemY, base.SortColumnIndex, this.m_iFileSystemColumnIndex);

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
            if (listView != this.m_lstvParent)
            {
                throw new ArgumentException("ListViewSorter.ListViewColumnClick: Invalid arguments.");
            }

            int iColumnIndex = e.Column;
            NativeMethods.SendMessage(listView.Handle, NativeMethods.LVM_SETSELECTEDCOLUMN, (IntPtr)iColumnIndex, IntPtr.Zero);
            // sort
            SortBy(e.Column, base.SortColumnIndex != e.Column || base.SortOrder != SortOrder.Ascending);
        }
        /// <summary>
        /// Create the compares for the columns in the ListView
        /// </summary>
        private void CreateListViewSorter()
        {
            int iColumnsCount = this.m_lstvParent.Columns.Count;

            for (int i = 0; i < iColumnsCount; i++)
            {
                BSE.Windows.Forms.ColumnHeader columnHeader = this.m_lstvParent.Columns[i] as BSE.Windows.Forms.ColumnHeader;
                ListViewComparer listViewComparer = columnHeader.ListViewComparer;

                switch (listViewComparer)
                {
                    case ListViewComparer.FileSystem:
                        m_arComparers[i] = new Comparer(CompareFiles);
                        break;
                    case ListViewComparer.Numbers:
                        m_arComparers[i] = new Comparer(CompareNumbers);
                        break;
                    case ListViewComparer.Dates:
                        m_arComparers[i] = new Comparer(CompareDates);
                        break;
                    default:
                        m_arComparers[i] = new Comparer(CompareStrings);
                        break;
                }
            }
        }
        /// <summary>
        /// Comparer for strings in a files and folder list grouped by files and folders.
        /// </summary>
        /// <param name="listViewItemX">First listviewItem to compare</param>
        /// <param name="listViewItemY">Second listviewItem to compare</param>
        /// <param name="iSortColumnIndex">The Index of the current column</param>
        /// <param name="iFileSystemColumnIndex">The Index of the FileSystem column</param>
        /// <returns></returns>
        private static int CompareFiles(ListViewItem listViewItemX, ListViewItem listViewItemY, int iSortColumnIndex, int iFileSystemColumnIndex)
        {
            String strX = listViewItemX.SubItems[iSortColumnIndex].Text;
            String strY = listViewItemY.SubItems[iSortColumnIndex].Text;
            if (IsListViewItemFolder(listViewItemX).Equals(IsListViewItemFolder(listViewItemY)) == true)
            {
                return String.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);
            }
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == false))
            {
                return -1;
            }
            if ((IsListViewItemFolder(listViewItemX) == false) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return 1;
            }

            return string.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Comparer for strings in a files and folder list.
        /// </summary>
        /// <param name="listViewItemX">First listviewItem to compare</param>
        /// <param name="listViewItemY">Second listviewItem to compare</param>
        /// <param name="iSelectedColumnIndex">The Index of the current column</param>
        /// <param name="iFileSystemColumnIndex">The Index of the FileSystem column</param>
        /// <list type="table">
        ///   <listheader>
        ///     <term>Value</term>
        ///     <description>Condition</description>
        ///   </listheader>
        ///   <item>
        ///     <term>Less than zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem is less than <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        ///   <item>
        ///     <term>Zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem equals <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        ///   <item>
        ///     <term>Greater than zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem is greater than <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        /// </list>
        /// <returns></returns>
        private static int CompareStrings(ListViewItem listViewItemX, ListViewItem listViewItemY, int iSelectedColumnIndex, int iFileSystemColumnIndex)
        {
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return String.Compare(
                    listViewItemX.SubItems[iFileSystemColumnIndex].Text,
                    listViewItemY.SubItems[iFileSystemColumnIndex].Text,
                    StringComparison.OrdinalIgnoreCase);
            }
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == false))
            {
                return -1;
            }
            if ((IsListViewItemFolder(listViewItemX) == false) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return 1;
            }
            if ((listViewItemX.SubItems == null) || (listViewItemX.SubItems.Count <= iSelectedColumnIndex))
            {
                return 1;
            }
            if ((listViewItemY.SubItems == null) || (listViewItemY.SubItems.Count <= iSelectedColumnIndex))
            {
                return -1;
            }

            string strX = listViewItemX.SubItems[iSelectedColumnIndex].Text;
            string strY = listViewItemY.SubItems[iSelectedColumnIndex].Text;

            return string.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// Comparer for numbers in a files and folder list.
        /// </summary>
        /// <param name="listViewItemX">First listviewItem to compare</param>
        /// <param name="listViewItemY">Second listviewItem to compare</param>
        /// <param name="iSelectedColumnIndex">The Index of the current column</param>
        /// <param name="iFileSystemColumnIndex">The Index of the FileSystem column</param>
        /// <returns>
        /// <list type="table">
        ///   <listheader>
        ///     <term>Value</term>
        ///     <description>Condition</description>
        ///   </listheader>
        ///   <item>
        ///     <term>Less than zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem is less than <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        ///   <item>
        ///     <term>Zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem equals <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        ///   <item>
        ///     <term>Greater than zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem is greater than <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        /// </list>
        /// </returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
        private static int CompareNumbers(ListViewItem listViewItemX, ListViewItem listViewItemY, int iSelectedColumnIndex, int iFileSystemColumnIndex)
        {
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return String.Compare(
                    listViewItemX.SubItems[iFileSystemColumnIndex].Text,
                    listViewItemY.SubItems[iFileSystemColumnIndex].Text,
                    StringComparison.OrdinalIgnoreCase);
            }
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == false))
            {
                return -1;
            }
            if ((IsListViewItemFolder(listViewItemX) == false) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return 1;
            }
            if ((listViewItemX.SubItems == null) || (listViewItemX.SubItems.Count <= iSelectedColumnIndex))
            {
                return 1;
            }
            if ((listViewItemY.SubItems == null) || (listViewItemY.SubItems.Count <= iSelectedColumnIndex))
            {
                return -1;
            }

            String strX = listViewItemX.SubItems[iSelectedColumnIndex].Text;
            String strY = listViewItemY.SubItems[iSelectedColumnIndex].Text;

            double dX;
            double dY;

            double.TryParse(strX, out dX);
            double.TryParse(strY, out dY);

            return dX.CompareTo(dY);
        }
        /// <summary>
        /// Comparer for dates in a files and folder list.
        /// </summary>
        /// <param name="listViewItemX">First listviewItem to compare</param>
        /// <param name="listViewItemY">Second listviewItem to compare</param>
        /// <param name="iSelectedColumnIndex">The Index of the current column</param>
        /// <param name="iFileSystemColumnIndex">The Index of the FileSystem column</param>
        /// <returns>
        /// <list type="table">
        ///   <listheader>
        ///     <term>Value</term>
        ///     <description>Condition</description>
        ///   </listheader>
        ///   <item>
        ///     <term>Less than zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem is less than <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        ///   <item>
        ///     <term>Zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem equals <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        ///   <item>
        ///     <term>Greater than zero</term>
        ///     <description><paramref name="listViewItemX"/>.SubItem is greater than <paramref name="listViewItemY"/>.SubItem.</description>
        ///   </item>
        /// </list>
        /// </returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
        private static int CompareDates(ListViewItem listViewItemX, ListViewItem listViewItemY, int iSelectedColumnIndex, int iFileSystemColumnIndex)
        {
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return String.Compare(
                    listViewItemX.SubItems[iFileSystemColumnIndex].Text,
                    listViewItemY.SubItems[iFileSystemColumnIndex].Text,
                    StringComparison.OrdinalIgnoreCase);
            }
            if ((IsListViewItemFolder(listViewItemX) == true) && (IsListViewItemFolder(listViewItemY) == false))
            {
                return -1;
            }
            if ((IsListViewItemFolder(listViewItemX) == false) && (IsListViewItemFolder(listViewItemY) == true))
            {
                return 1;
            }
            if ((listViewItemX.SubItems == null) || (listViewItemX.SubItems.Count <= iSelectedColumnIndex))
            {
                return 1;
            }
            if ((listViewItemY.SubItems == null) || (listViewItemY.SubItems.Count <= iSelectedColumnIndex))
            {
                return -1;
            }

            String strX = listViewItemX.SubItems[iSelectedColumnIndex].Text;
            String strY = listViewItemY.SubItems[iSelectedColumnIndex].Text;

            DateTime dtX;
            DateTime dtY;

            DateTime.TryParse(strX, out dtX);
            DateTime.TryParse(strY, out dtY);

            return DateTime.Compare(dtX, dtY);
        }
        private static Boolean IsListViewItemFolder(ListViewItem listViewItem)
        {
            if (listViewItem.Tag is DirectoryInfo)
            {
                return true;
            }
            return false;
        }
        #region class NativeMethods

        internal static class NativeMethods
        {
            #region Constants
            /// <summary>
            /// Sets the index of the selected column.
            /// </summary>
            public const int LVM_SETSELECTEDCOLUMN = 0x108C;
            #endregion

            #region MethodsPublic
            /// <summary>
            /// The SendMessage function sends the specified message to a window or windows. 
            /// It calls the window procedure for the specified window and does not return 
            /// until the window procedure has processed the message.
            /// </summary>
            /// <param name="hWnd">
            /// Handle to the window whose window procedure will receive the message. 
            /// If this parameter is HWND_BROADCAST, the message is sent to all top-level 
            /// windows in the system, including disabled or invisible unowned windows, 
            /// overlapped windows, and pop-up windows; but the message is not sent to child windows.
            /// </param>
            /// <param name="Msg">Specifies the message to be sent.</param>
            /// <param name="wParam">Specifies additional message-specific information.</param>
            /// <param name="lParam">Specifies additional message-specific information.</param>
            /// <returns></returns>
            [System.Runtime.InteropServices.DllImport("User32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
            #endregion
        }

        #endregion

        #endregion

    }
}
