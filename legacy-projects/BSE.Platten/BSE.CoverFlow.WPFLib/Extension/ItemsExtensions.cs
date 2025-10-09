using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BSE.CoverFlow.WPFLib.Extension
{
    public static class ItemsExtensions
    {
        public static IList<T> GetItems<T>(this ItemCollection itemCollection) where T : Control
        {
            IList<T> items = null;
            if (itemCollection != null)
            {
                items = itemCollection.Cast<T>().AsEnumerable().Where(item => item != null).ToList();
            }
            return items;
        }
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

    }
}
