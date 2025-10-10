using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BSE.Wpf.Windows.Controls
{
    /// <summary>
    /// The ListView control in WPF is a powerful option when trying to present tabular data to users.
    /// It supports many of the common behaviours found in grid controls as well as the full WFP
    /// templating architecture we have all come to love. Below is a simple of example of a ListView
    /// which has been bound to a collection of strings. The example uses a template GridVewColumn
    /// and a 3 standard GridViewColumn’s to display the data.
    /// http://www.ontheblog.net/CMS/Home/tabid/36/EntryID/37/Default.aspx
    /// </summary>
    public class ListViewColumns : DependencyObject
    {
        #region FieldsPublic
        /// <summary>
        /// IsStretched Dependancy property which can be attached to gridview columns.
        /// </summary>
        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.RegisterAttached("Stretch",
            typeof(bool),
            typeof(ListViewColumns),
            new UIPropertyMetadata(true, null, OnCoerceStretch));
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Gets the stretch.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static bool GetStretch(DependencyObject obj)
        {
            return (bool)obj.GetValue(StretchProperty);
        }
        /// <summary>
        /// Sets the stretch.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetStretch(DependencyObject obj, bool value)
        {
            obj.SetValue(StretchProperty, value);
        }
        /// <summary>
        /// Called when [coerce stretch].
        /// </summary>
        /// <remarks>If this callback seems unfamilar then please read
        /// the great blog post by Paul jackson found here. 
        /// http://compilewith.net/2007/08/wpf-dependency-properties.html</remarks>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static object OnCoerceStretch(DependencyObject source, object value)
        {
            System.Windows.Controls.ListView listView = source as System.Windows.Controls.ListView;

            //Ensure we dont have an invalid dependancy object of type ListView.
            if (listView == null)
                throw new ArgumentException("This property may only be used on ListViews");

            //Setup our event handlers for this list view.
            listView.Loaded += new RoutedEventHandler(ListViewLoaded);
            listView.SizeChanged += new SizeChangedEventHandler(ListViewSizeChanged);
            return value;
        }
        #endregion

        #region MethodsPrivate
        /// <summary>
        /// Sets the column widths.
        /// </summary>
        private static void SetColumnWidths(System.Windows.Controls.ListView listView)
        {
            if (listView != null)
            {
                //Pull the stretch columns fromt the tag property.
                List<GridViewColumn> columns = listView.Tag as List<GridViewColumn>;
                double specifiedWidth = 0;
                GridView gridView = listView.View as GridView;
                if (gridView != null)
                {
                    if (columns == null)
                    {
                        //Instance if its our first run.
                        columns = new List<GridViewColumn>();
                        // Get all columns with no width having been set.
                        foreach (GridViewColumn column in gridView.Columns)
                        {
                            if (!(column.Width >= 0))
                                columns.Add(column);
                            else specifiedWidth += column.ActualWidth;
                        }
                    }
                    else
                    {
                        // Get all columns with no width having been set.
                        foreach (GridViewColumn column in gridView.Columns)
                            if (!columns.Contains(column))
                                specifiedWidth += column.ActualWidth;
                    }

                    // Allocate remaining space equally.
                    foreach (GridViewColumn column in columns)
                    {
                        double newWidth = (listView.ActualWidth - specifiedWidth) / columns.Count;
                        if (newWidth >= 0) column.Width = newWidth - 10;
                    }

                    //Store the columns in the TAG property for later use. 
                    listView.Tag = columns;
                }
            }
        }
        /// <summary>
        /// Handles the SizeChanged event of the lv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.SizeChangedEventArgs"/> instance containing the event data.</param>
        private static void ListViewSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView != null && listView.IsLoaded == true)
            {
                //Set our initial widths.
                SetColumnWidths(listView);
            }
        }

        /// <summary>
        /// Handles the Loaded event of the lv control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private static void ListViewLoaded(object sender, RoutedEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView != null)
            {
                //Set our initial widths.
                SetColumnWidths(listView);
            }
        }
        #endregion
    }
}
