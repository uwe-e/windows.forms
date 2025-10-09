using System;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Event Handler for DragEnter, DragOver, DragDrop and ItemDrag events
	/// </summary>
	public delegate void CDragEventHandler(object sender, BSE.Windows.Forms.CDragEventArgs e);
	/// <summary>
	/// Occurs on DragEnter, DragOver, DragDrop and ItemDrag events.
	/// </summary>
	public class CDragEventArgs : System.Windows.Forms.DragEventArgs
	{
		
		#region FieldsPrivate
		
		private BSE.Windows.Forms.CDraggedListViewObjects m_draggedListViewObjects;
		
		#endregion
		
		#region Properties
		
		public BSE.Windows.Forms.CDraggedListViewObjects DraggedListViewObjects
		{
			get {return this.m_draggedListViewObjects;}
			set {this.m_draggedListViewObjects = value;}
		}
		
		#endregion

		#region MethodsPublic

		public CDragEventArgs(
			IDataObject data,
			int keyState,
			int x,
			int y,
			DragDropEffects allowedEffect,
			DragDropEffects effect,
			CDraggedListViewObjects draggedListViewObjects) : base(data,keyState,x,y,allowedEffect,effect)
		{
			this.m_draggedListViewObjects = draggedListViewObjects;
		}

		#endregion

	}
}
