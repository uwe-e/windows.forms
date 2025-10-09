using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BSE.Platten.BO
{
    public class SortableCollection<T> : BindingList<T>
    {
        #region FieldsPrivate

        private bool m_bIsSorted;
        private ListSortDirection m_listSortDirection;
        private PropertyDescriptor m_propertyDescriptor;

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        /// <value>rue if the list supports sorting; otherwise, false. The default is false.</value>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        /// <summary>
        /// Sorts the items if overridden in a derived class; otherwise, throws a NotSupportedException.
        /// </summary>
        /// <param name="prop">A PropertyDescriptor that specifies the property to sort on.</param>
        /// <param name="direction">One of the ListSortDirection values.</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.m_bIsSorted = false;
            // Get list to sort
            List<T> items = this.Items as List<T>;

            // Apply and set the sort, if items to sort
            if (items != null)
            {
                this.m_listSortDirection = direction;
                this.m_propertyDescriptor = prop;
                PropertyComparer<T> propertyComparer = new PropertyComparer<T>(
                    this.m_propertyDescriptor,
                    this.m_listSortDirection);
                //Sorts the elements in the entire List using the specified comparer.
                items.Sort(propertyComparer);
                this.m_bIsSorted = true;
            }

            // Let bound controls know they should refresh their views
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        /// <summary>
        /// Gets a value indicating whether the list is sorted.
        /// </summary>
        /// <value>true if the list is sorted; otherwise, false. The default is false.</value>
        protected override bool IsSortedCore
        {
            get { return this.m_bIsSorted; }
        }
        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented in a derived class;
        /// otherwise, raises NotSupportedException.
        /// </summary>
        protected override void RemoveSortCore()
        {
            this.m_bIsSorted = false;
        }
        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return m_listSortDirection; }
        }
        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class;
        /// otherwise, returns a null reference
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return m_propertyDescriptor; }
        }

        #endregion
    }
}
