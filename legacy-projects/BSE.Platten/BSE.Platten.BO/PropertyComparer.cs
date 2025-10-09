using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace BSE.Platten.BO
{
    public class PropertyComparer<T> : IComparer<T>
    {
        #region FieldsPrivate

        private PropertyDescriptor m_propertyDescriptor;
        private ListSortDirection m_listSortDirection;

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prop">A PropertyDescriptor that specifies the property to sort on.</param>
        /// <param name="direction">One of the ListSortDirection values.</param>
        public PropertyComparer(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.m_propertyDescriptor = prop;
            this.m_listSortDirection = direction;
        }

        #region IComparer<T>
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            // Get property values
            object xValue = GetPropertyValue(x, this.m_propertyDescriptor.Name);
            object yValue = GetPropertyValue(y, this.m_propertyDescriptor.Name);

            // Determine sort order
            if (this.m_listSortDirection == ListSortDirection.Ascending)
            {
                return CompareAscending(xValue, yValue);
            }
            else
            {
                return CompareDescending(xValue, yValue);
            }
        }

        #endregion

        #endregion

        #region MethodsPrivate

        private static int CompareAscending(object x, object y)
        {
            int result;

            if ((x != null) && (y == null))
            {
                return 1;
            }
            if ((x == null) && (y != null))
            {
                return -1;
            }
            if ((x == null) && (y == null))
            {
                return 0;
            }
            // If values implement IComparer
            IComparable value = x as IComparable;
            if (value != null)
            {
                result = value.CompareTo(y);
            }
            else if (x.Equals(y))
            {
                result = 0;
            }
            else
            {
                result = x.ToString().CompareTo(y.ToString());
            }
            return result;
        }

        private static int CompareDescending(object x, object y)
        {
            // Return result adjusted for ascending or descending sort order ie
            // multiplied by 1 for ascending or -1 for descending
            return CompareAscending(x, y) * -1;
        }

        private static object GetPropertyValue(T value, string property)
        {
            // Get property
            PropertyInfo propertyInfo = value.GetType().GetProperty(property);
            // Return value
            return propertyInfo.GetValue(value, null);
        }

        #endregion
    }
}
