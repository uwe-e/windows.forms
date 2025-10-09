using System;
using System.Windows.Forms;
using System.Collections;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Zusammenfassung für CDraggedListViewItems.
	/// </summary>
	public class CDraggedListViewObjects
	{
		#region FieldsPrivate
		
		private BSE.Windows.Forms.ListView m_lvwParent;
		private ArrayList m_dragObjects;
		
		#endregion
		
		#region Properties
		
		public BSE.Windows.Forms.ListView ParentListView
		{
			get {return this.m_lvwParent;}
		}

		public ArrayList DragObjects
		{
			get {return this.m_dragObjects;}
		}
		
		#endregion

		#region MethodsPublic

		public CDraggedListViewObjects(BSE.Windows.Forms.ListView lvwParent)
		{
			this.m_lvwParent = lvwParent;
			this.m_dragObjects = new ArrayList();
		}

		#endregion

	}
}
