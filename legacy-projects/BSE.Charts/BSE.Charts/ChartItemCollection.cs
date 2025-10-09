using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace BSE.Charts
{
	public partial class Chart
	{
		public class ChartItemCollection : IList<BSE.Charts.ChartItem>, IList
		{
			#region FieldsPrivate

			/// <summary>
			/// The Charts- control this collection is associated with.
			/// </summary>
			private Chart m_charts;
			/// <summary>
			/// The list of chartItems stored in this control.
			/// </summary>
			private List<BSE.Charts.ChartItem> m_chartItems;

			#endregion

			#region Properties

			#endregion

			#region Constructor

			/// <summary>
			/// 
			/// </summary>
			/// <param name="container"></param>
			internal ChartItemCollection(Chart charts)
			{
				this.m_charts = charts;
				this.m_chartItems = new List<BSE.Charts.ChartItem>();
			}

			#endregion

			#region MethodsPublic

			/// <summary>
			/// Gets or sets the element at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index of the element to get or set.</param>
			/// <returns>The element at the specified index.</returns>
			public BSE.Charts.ChartItem this[int iIndex]
			{
				get
				{
					return (BSE.Charts.ChartItem)this.m_chartItems[iIndex];
				}
				set
				{
					if (this.m_chartItems[iIndex] != value)
					{
						this.m_chartItems[iIndex].Parent = null;
						this.m_chartItems[iIndex] = value;
						this.m_chartItems[iIndex].Parent = this.m_charts;
					}
				}
			}

			/// <summary>
			/// Determines the index of a specific item in the list.
			/// </summary>
			/// <param name="item">The object to locate in the list.</param>
			/// <returns>The index of the item if found in the list, otherwise -1.</returns>
			public int IndexOf(BSE.Charts.ChartItem chartItem)
			{
				return this.m_chartItems.IndexOf(chartItem);
			}

			/// <summary>
			/// Inserts an item to the list at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index at which item should be inserted.</param>
			/// <param name="item">The object to insert into the list.</param>
			public void Insert(int iIndex, BSE.Charts.ChartItem chartItem)
			{
				chartItem.Parent = this.m_charts;
				this.m_chartItems.Insert(iIndex, chartItem);
				this.m_charts.Invalidate();
			}

			/// <summary>
			/// Removes the item at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index of the item to remove.</param>
			public void RemoveAt(int iIndex)
			{
				this.m_chartItems[iIndex].Parent = null;
				this.m_chartItems.RemoveAt(iIndex);
				this.m_charts.Invalidate();
			}

			#endregion

			#region Interface IEnumerable

			/// <summary>
			/// Returns an enumerator that iterates through a collection.
			/// </summary>
			/// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
			public IEnumerator<BSE.Charts.ChartItem> GetEnumerator()
			{
				return this.m_chartItems.GetEnumerator();
			}

			/// <summary>
			/// Returns an enumerator that iterates through a collection.
			/// </summary>
			/// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.m_chartItems.GetEnumerator();
			}

			#endregion

			#region Interface ICollection<T>

			/// <summary>
			/// Gets the number of elements contained in the collection.
			/// </summary>
			public int Count
			{
				get
				{
					return this.m_chartItems.Count;
				}
			}

			/// <summary>
			/// Gets a value indicating whether the collection is read-only.
			/// </summary>
			bool ICollection<BSE.Charts.ChartItem>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			/// <summary>
			/// Adds an item to the collection.
			/// </summary>
			/// <param name="item">The item to add to the collection.</param>
			public void Add(BSE.Charts.ChartItem chartItem)
			{
				this.m_chartItems.Add(chartItem);
				if (!this.m_charts.DesignMode)
				{
					chartItem.Parent = this.m_charts;
					chartItem.Index = this.m_charts.GetIndex();
					if (chartItem.Color.IsEmpty)
					{
						chartItem.Color = new ChartItemColors().GetColor(chartItem.Index);
					}
				}
				this.m_charts.Invalidate();
			}

			/// <summary>
			/// Removes all items from the collection.
			/// </summary>
			public void Clear()
			{
				foreach (BSE.Charts.ChartItem chartItem in this.m_chartItems)
				{
					chartItem.Parent = null;
				}
				this.m_chartItems.Clear();
				this.m_charts.Invalidate();
			}

			/// <summary>
			/// Determines whether the collection contains a specific value.
			/// </summary>
			/// <param name="item">The object to locate in the collection.</param>
			/// <returns>True if the item is found in the collection, otherwise false.</returns>
			public bool Contains(BSE.Charts.ChartItem chartItem)
			{
				return this.m_chartItems.Contains(chartItem);
			}

			/// <summary>
			/// Copies the elements of the collection to an array, starting at a particular array index.
			/// </summary>
			/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection.
			/// The array must have zero-based indexing.</param>
			/// <param name="index">The zero-based index in array at which copying begins.</param>
			void ICollection<BSE.Charts.ChartItem>.CopyTo(BSE.Charts.ChartItem[] array, int iIndex)
			{
				this.m_chartItems.CopyTo(array, iIndex);
			}

			/// <summary>
			/// Removes the first occurrence of a specific object from the collection.
			/// </summary>
			/// <param name="item">The object to remove from the collection.</param>
			/// <returns>True if the item was successfully removed from the colleection, otherwise false.  This method
			/// also returns false if the item is not found in the original collection.</returns>
			public bool Remove(BSE.Charts.ChartItem chartItem)
			{
				chartItem.Parent = null;
				bool rval = this.m_chartItems.Remove(chartItem);
				this.m_charts.Invalidate();
				return rval;
			}

			#endregion

			#region Interface ICollection

			/// <summary>
			/// Copies the elements of the collection to an array, starting at a particular array index.
			/// </summary>
			/// <param name="array">The one-dimensional array that is the destination of the elements copied from the collection.
			/// The array must have zero-based indexing.</param>
			/// <param name="index">The zero-based index in array at which copying begins</param>
			void ICollection.CopyTo(Array array, int iIndex)
			{
				((ICollection)this.m_chartItems).CopyTo(array, iIndex);
			}

			/// <summary>
			/// Gets an object that can be used to synchronize access to the collection.
			/// </summary>
			object ICollection.SyncRoot
			{
				get
				{
					return this;
				}
			}

			/// <summary>
			/// Gets a value indicating whether access to the collection is synchronized (thread safe).
			/// </summary>
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			#endregion

			#region Interface IList

			/// <summary>
			/// Adds an item to the list.
			/// </summary>
			/// <param name="obj">The item to add to the list.</param>
			/// <returns>The position at which the item was inserted.</returns>
			int IList.Add(object obj)
			{
				this.Add((BSE.Charts.ChartItem)obj);
				return this.Count - 1;
			}

			/// <summary>
			/// Determines whether the list contains a specific value.
			/// </summary>
			/// <param name="obj">The object to locate in the list.</param>
			/// <returns>True if an instance of the item was found in the list, otherwise false.</returns>
			bool IList.Contains(object obj)
			{
				return this.Contains((BSE.Charts.ChartItem)obj);
			}

			/// <summary>
			/// Determines the index of a specific item in the list.
			/// </summary>
			/// <param name="obj">The object to locate in the list.</param>
			/// <returns>The index of the item if found in the list, otherwise -1.</returns>
			int IList.IndexOf(object obj)
			{
				return this.IndexOf((BSE.Charts.ChartItem)obj);
			}

			/// <summary>
			/// Inserts an item to the list at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index at which item should be inserted.</param>
			/// <param name="obj">The object to insert into the list.</param>
			void IList.Insert(int iIndex, object obj)
			{
				this.Insert(iIndex, (BSE.Charts.ChartItem)obj);
			}

			/// <summary>
			/// Removes the first occurrence of a specific object from the collection.
			/// </summary>
			/// <param name="item">The object to remove from the collection.</param>
			void IList.Remove(object value)
			{
				this.Remove((BSE.Charts.ChartItem)value);
			}

			/// <summary>
			/// Gets or sets the element at the specified index.
			/// </summary>
			/// <param name="index">The zero-based index of the element to get or set.</param>
			/// <returns>The element at the specified index.</returns>
			object IList.this[int iIndex]
			{
				get
				{
					return this[iIndex];
				}
				set
				{
					this[iIndex] = (BSE.Charts.ChartItem)value;
				}
			}

			/// <summary>
			/// Gets a value indicating whether the list is read-only.
			/// </summary>
			bool IList.IsReadOnly
			{
				get { return false; }
			}

			/// <summary>
			/// Gets a value indicating whether the list has a fixed size.
			/// </summary>
			bool IList.IsFixedSize
			{
				get { return false; }
			}
			#endregion
		}
	}
}
