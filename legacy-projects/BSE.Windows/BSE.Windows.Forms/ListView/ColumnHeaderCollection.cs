using System;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Zusammenfassung für ColumnHeaderCollection.
	/// </summary>
	public class ColumnHeaderCollection : System.Windows.Forms.ListView.ColumnHeaderCollection
	{
		#region MethodsPublic

		/// <summary>
		/// Initializes a new instance of the BSE.Windows.Forms.ListView.ColumnHeaderCollection class.
		/// </summary>
		/// <param name="lstvParent">The ListView control that owns this collection.</param>
		public ColumnHeaderCollection(BSE.Windows.Forms.ListView lstvParent) : base(lstvParent)
		{
		}
		/// <summary>
		/// Gets the column header at the specified index within the collection.
		/// </summary>
		new public BSE.Windows.Forms.ColumnHeader this[int iIndex]
		{
			get{return (BSE.Windows.Forms.ColumnHeader)base[iIndex];}
		}
		/// <summary>
		/// Adds an existing ColumnHeader to the collection.
		/// </summary>
		/// <param name="value">The ColumnHeader to add to the collection.</param>
		/// <returns>The zero-based index into the collection where the item was added.</returns>
		public virtual int Add(BSE.Windows.Forms.ColumnHeader value)
		{
			base.Add(value);
			return value.Index;
		}
		/// <summary>
		/// Adds an array of column headers to the collection.
		/// </summary>
		/// <param name="values">An array of ColumnHeader objects to add to the collection.</param>
		public virtual void AddRange(BSE.Windows.Forms.ColumnHeader[] values)
		{
			base.AddRange(values);
		}	
		#endregion
	}
}
