using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Zusammenfassung für CListView.
	/// </summary>
	[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ListView))]
	public class ListView : System.Windows.Forms.ListView
	{
		#region EventsPublic
        /// <summary>
        /// Occurs when subitem in the listview was edited.
        /// </summary>
        [Description("Occurs when subitem in the listview was edited.")]
        public event EventHandler<SubItemEndEditingEventArgs> SubItemEndEditing;
        /// <summary>
        /// Occurs when subitem in the listview is edited.
        /// </summary>
        [Description("Occurs when subitem in the listview is edited.")]
        public event EventHandler<SubItemEventArgs> SubItemBeginEditing;
        /// <summary>
        /// Occurs when subitem in the listview is clicked.
        /// </summary>
        [Description("Occurs when subitem in the listview is clicked.")]
        public event EventHandler<SubItemEventArgs> SubItemClicked;
        /// <summary>
        /// Occurs when a ListViewItem is added to the ListViewItemCollection.
        /// </summary>
        [Description("Occurs when a ListViewItem is added to the ListViewItemCollection.")]
        public event EventHandler<EventArgs> ListViewItemAdded;
        /// <summary>
        /// Occurs when a ListViewItem is inserted to the ListViewItemCollection.
        /// </summary>
        [Description("Occurs when a ListViewItem is inserted to the ListViewItemCollection.")]
        public event EventHandler<EventArgs> ListViewItemInserted;
        /// <summary>
        /// Occurs when a ListViewItem is removed to the ListViewItemCollection.
        /// </summary>
        [Description("Occurs when a ListViewItem is removed to the ListViewItemCollection.")]
        public event EventHandler<EventArgs> ListViewItemRemoved;
        /// <summary>
        /// Occurs when the ListViewItemCollection is cleared.
        /// </summary>
        [Description("Occurs when the ListViewItemCollection is cleared.")]
        public event EventHandler<EventArgs> ListViewCleared;
		/// <summary>
		/// Occurs when the mouse pointer is over the column and a mouse button is pressed.
		/// </summary>
		[Description("Occurs when the mouse pointer is over the column and a mouse button is pressed.")]
		public event EventHandler<MouseEventArgs> ColumnMouseDown;
		/// <summary>
		/// Occurs when the mouse pointer is over the column and a mouse button is released.
		/// </summary>
		[Description("Occurs when the mouse pointer is over the column and a mouse button is released.")]
		public event EventHandler<MouseEventArgs> ColumnMouseUp;

		#endregion

		#region FieldsPrivate
		/// <summary>
		/// Represents the collection of column headers in a ListView control.
		/// </summary>
		private BSE.Windows.Forms.ColumnHeaderCollection m_columns;
        private ListViewItemCollection m_items;
		private Color m_colorAlternatingBack;
		private Control m_embeddedControl;
		private BSE.Windows.Forms.BaseListViewItemSorter m_listViewSorter;
		private Control m_editingControl;
		private ListViewItem m_editListViewItem;
		private int m_editSubItemIndex;
		/// <summary>
		/// Settings for columnheaders
		/// -2 fit largest item
		/// -1 fit column header
		/// </summary>
		private int m_iSizeColumnOnShow = -2;
		/// <summary>
		/// Control des Headers
		/// </summary>
		private HeaderControl m_headerControl;
		/// <summary>
		/// Specifies the effects of a drag-and-drop operation
		/// </summary>
		private DragDropEffects m_dragDropEffects = DragDropEffects.None;
		/// <summary>
		/// Specifies the effects of the dragdrop event. If DragDropOnlyAsEvent is true,
		///	you must catch the DragDropWithListViewItemObjects event
		/// </summary>
		private bool m_bDragDropOnlyAsEvent;
		/// <summary>
		/// Enables drag-and-drop operations on this listview
		/// </summary>
		private bool m_bAllowDrag;
		/// <summary>
		/// Allows to select all listviewitems with ctrl+A
		/// </summary>
		private bool m_bAllowSelectAllItems;
		private int m_iListViewItemIndex;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
		
		#endregion
		
		#region Properties
		/// <summary>
        /// A ListView.ColumnHeaderCollection that represents the ColumnHeaderEx headers.
		/// </summary>
		[Description("A ListView.ColumnHeaderCollection that represents the ColumnHeaderEx headers.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new BSE.Windows.Forms.ColumnHeaderCollection Columns
		{
			get {return this.m_columns;}
		}
        /// <summary>
        /// A ListView.ListViewItemCollection that represents the items in listview.
        /// </summary>
        [Description("A ListView.ListViewItemCollection that represents the items in listview.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ListViewItemCollection Items
        {
            get { return m_items; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the user can edit the labels of items in the control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new bool LabelEdit
        {
            get { return base.LabelEdit; }
            set { base.LabelEdit = value; }
        }
		/// <summary>
		/// Gets or sets the in the ListviewItem embedded control
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Control EmbeddedControl
		{
			get {return this.m_embeddedControl;}
			set {this.m_embeddedControl = value;}
		}
		/// <summary>
		/// Objekt für die Sortierung der Spalten in der ListView
		/// </summary>
		[Browsable(true)]
		[Description("Objekt für die Sortierung der Spalten in der ListView")]
        public BSE.Windows.Forms.BaseListViewItemSorter ListViewSorter
		{
			get { return this.m_listViewSorter; }
			set { this.m_listViewSorter = value; }
		}
        /// <summary>
        /// Gets or sets the background color of odd-numbered rows of the listView
        /// </summary>
		[Description("Gets or sets the background color of odd-numbered rows of the listView")]
        [Category("Appearance")]
		public System.Drawing.Color AlternatingBackColor
		{
			get {return this.m_colorAlternatingBack;}
			set
            {
                this.m_colorAlternatingBack = value;
                if (this.m_colorAlternatingBack != SystemColors.Window)
                {
                    Invalidate();
                }
            }
		}
		/// <summary>
		/// Settings for columnheaders
		/// -2 fit largest item
		/// -1 fit column header
		/// </summary>
		/// <value>
		/// <b>true:</b> Spalten werden bei neuer Darstellung auf die Breite des längsten Elements ausgerichtet.<br/>
		/// <b>false:</b> Spalten werden bei neuer Darstellung auf die Breite des Headers ausgerichtet.<br/>
		/// </value>
		[Description("Settings for columnheaders: true fit largest item; false fit column header")]
		[Category("Behavior")]
		public bool FitLargestItem
		{
			get
			{
				if (this.m_iSizeColumnOnShow == -2)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			set
			{
				if (value == true)
				{
					this.m_iSizeColumnOnShow = -2;
				}
				else
				{
					this.m_iSizeColumnOnShow = -1;
				}
			}
		}
		/// <summary>
		/// Specifies the effects of a drag-and-drop operation
		/// </summary>
		[Description("Specifies the effects of a drag-and-drop operation")]
		[DefaultValue(DragDropEffects.None)]
		[Category("DragDrop")]
		public DragDropEffects DragDropEffects
		{
			get {return this.m_dragDropEffects;}
			set {this.m_dragDropEffects = value;}
		}
		/// <summary>
		/// Specifies the effects of the dragdrop event. If DragDropOnlyAsEvent is true,
		///	you must catch the DragDropWithListViewItemObjects event
		/// </summary>
		[Description("Specifies the effects of the dragdrop event. If DragDropOnlyAsEvent is true," +
			 "you must catch the DragDropWithListViewItemObjects event")]
		[DefaultValue(false)]
		[Category("DragDrop")]
		public bool DragDropOnlyAsEvent
		{
			get {return this.m_bDragDropOnlyAsEvent;}
			set {this.m_bDragDropOnlyAsEvent = value;}
		}
		/// <summary>
		/// Enables drag-and-drop operations on this listview
		/// </summary>
		[Description("Enables drag-and-drop operations on this listview")]
		[DefaultValue(false)]
		[Category("DragDrop")]
		public bool AllowDrag
		{
			get {return this.m_bAllowDrag;}
			set {this.m_bAllowDrag = value;}
		}
		/// <summary>
		/// Enables to select all listviewitems with ctrl+A
		/// </summary>
		[Description("Enables to select all listviewitems with ctrl+A")]
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool AllowSelectAllItems
		{
			get {return this.m_bAllowSelectAllItems;}
			set {this.m_bAllowSelectAllItems = value;}
		}

		#endregion

		#region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the ListView class.
        /// </summary>
		public ListView()
		{
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            this.View = View.Details;
			this.AllowColumnReorder = true;
			this.m_columns = new BSE.Windows.Forms.ColumnHeaderCollection(this);
            this.m_items = new ListViewItemCollection(this);
            this.AlternatingBackColor = SystemColors.Window;
		}
        /// <summary>
        /// Initializes a new instance of the ListView class.
        /// </summary>
        /// <param name="dragDropEffects">Specifies the effects of a drag-and-drop operation</param>
		public ListView(DragDropEffects dragDropEffects) : base()
		{
			this.m_dragDropEffects = dragDropEffects;
		}
		/// <summary>
		/// Find ListViewItem and SubItem Index at position (x,y)
		/// </summary>
		/// <param name="x">relative to ListView</param>
		/// <param name="y">relative to ListView</param>
        /// <param name="listViewItem">Item at position (x,y)</param>
		/// <returns>SubItem index</returns>
		public int GetSubItemAt(int x, int y, out ListViewItem listViewItem)
		{
			int iSubItemIndex = -1;
			int iRowIndex = -1;
			listViewItem = null;
			bool bHasSubItem = NativeMethods.HitTest(new Point(x,y),this,out iRowIndex,out iSubItemIndex);
			if (bHasSubItem)
			{
				listViewItem = this.Items[iRowIndex];
				if (listViewItem != null)
				{
					ListViewItem.ListViewSubItem listViewSubItem = this.Items[iRowIndex].SubItems[iSubItemIndex];
					if (listViewSubItem != null)
					{
						return iSubItemIndex;
					}
				}
			}

			return iSubItemIndex;
		}
		/// <summary>
		/// Get bounds for a SubItem
		/// </summary>
        /// <param name="listViewItem">Target ListViewItem</param>
        /// <param name="subItemIndex">Target SubItem index</param>
		/// <returns>Bounds of SubItem (relative to ListView)</returns>
		public Rectangle GetSubItemBounds(ListViewItem listViewItem, int subItemIndex)
		{
			int[] iOrder = GetColumnOrder();

			Rectangle subItemRectangle = Rectangle.Empty;
			if (subItemIndex >= iOrder.Length)
			{
				throw new IndexOutOfRangeException("SubItem " + subItemIndex + " out of range");
			}

			if (listViewItem == null)
			{
                throw new ArgumentNullException("listViewItem");
			}
			
			Rectangle listViewItemBounds = listViewItem.GetBounds(ItemBoundsPortion.Entire);
			int	subItemX = listViewItemBounds.Left;

			ColumnHeader columnHeader;
			int i;
			for (i=0; i < iOrder.Length; i++)
			{
				columnHeader = this.Columns[iOrder[i]];
				if (columnHeader.Index == subItemIndex)
				{
					break;
				}
				subItemX += columnHeader.Width;
			} 
			subItemRectangle	= new Rectangle(subItemX, listViewItemBounds.Top,
				this.Columns[iOrder[i]].Width, listViewItemBounds.Height);
			return subItemRectangle;
		}

		/// <summary>
		/// Begin in-place editing of given cell
		/// </summary>
		/// <param name="listViewItem">ListViewItem to edit</param>
		/// <param name="iSubItemIndex">Index of SubItem to edit</param>
		public void StartEditing(ListViewItem listViewItem, int iSubItemIndex)
		{
			BSE.Windows.Forms.ColumnHeader columnHeader = (BSE.Windows.Forms.ColumnHeader)this.Columns[iSubItemIndex];
			if (columnHeader.EmbeddedControl == null)
			{
				return;
			}
			
			Type type = columnHeader.EmbeddedControl.GetType();
            this.m_editingControl = (Control)Activator.CreateInstance(type);
            this.m_editingControl.Parent = this;

			OnSubItemBeginEditing(new SubItemEventArgs(listViewItem, iSubItemIndex));

			Rectangle rectangleSubItem = GetSubItemBounds(listViewItem, iSubItemIndex);

			if (rectangleSubItem.X < 0)
			{
				// Left edge of SubItem not visible - adjust rectangle position and width
				rectangleSubItem.Width += rectangleSubItem.X;
				rectangleSubItem.X = 0;
			}
			if (rectangleSubItem.X + rectangleSubItem.Width > this.Width)
			{
				// Right edge of SubItem not visible - adjust rectangle width
				rectangleSubItem.Width = this.Width - rectangleSubItem.Left;
			}

			// Subitem bounds are relative to the location of the ListView!
			rectangleSubItem.Offset(Left, Top);

			// In case the editing control and the listview are on different parents,
			// account for different origins
			Point pointOrigin = new Point(0,0);
			Point pointListViewOrigin  = this.Parent.PointToScreen(pointOrigin);
            Point pointControlOrigin = this.m_editingControl.Parent.PointToScreen(pointOrigin);

			rectangleSubItem.Offset(pointListViewOrigin.X - pointControlOrigin.X, pointListViewOrigin.Y - pointControlOrigin.Y);
			
			// Position and show editor
            this.m_editingControl.Bounds = rectangleSubItem;
            this.m_editingControl.Text = listViewItem.SubItems[iSubItemIndex].Text;
            this.m_editingControl.Visible = true;
            this.m_editingControl.BringToFront();
            this.m_editingControl.Focus();
			this.m_editingControl.Leave += new EventHandler(EditingControlLeave);
			this.m_editingControl.KeyPress += new KeyPressEventHandler(EditingControlKeyPress);
			this.m_editListViewItem = listViewItem;
			this.m_editSubItemIndex = iSubItemIndex;

		}
		/// <summary>
		/// Accept or discard current value of cell editor control
		/// </summary>
        /// <param name="bAcceptChanges">Use the _editingControl's Text as new SubItem text or discard changes?</param>
		public void EndEditing(bool bAcceptChanges)
		{
			if (this.m_editingControl == null)
			{
				return;
			}

            if (this.m_editListViewItem == null)
            {
                return;
            }

			BSE.Windows.Forms.SubItemEndEditingEventArgs e = new BSE.Windows.Forms.SubItemEndEditingEventArgs(
				this.m_editListViewItem,		// The item being edited
				this.m_editSubItemIndex,	// The subitem index being edited
				bAcceptChanges ?
				this.m_editingControl.Text :	// Use editControl text if changes are accepted
				this.m_editListViewItem.SubItems[this.m_editSubItemIndex].Text,	// or the original subitem's text, if changes are discarded
				!bAcceptChanges	// Cancel?
				);

			OnSubItemEndEditing(e);

            this.m_editListViewItem.SubItems[this.m_editSubItemIndex].Text = e.DisplayText;

            using (Control control = this.m_editingControl)
            {
                control.Parent.Focus();
                control.Leave -= new EventHandler(EditingControlLeave);
                control.KeyPress -= new KeyPressEventHandler(EditingControlKeyPress);
                control.Visible = false;
            }

            this.m_editListViewItem = null;
            this.m_editSubItemIndex = -1;
		}
		
		/// <summary>
		/// When adding an item in a loop, use this to update the newly added item.
		/// </summary>
        /// <param name="iListViewItemIndex">Index of the item just added</param>
		public void UpdateItem(int iListViewItemIndex)
		{
			m_iListViewItemIndex = iListViewItemIndex;
			this.Update();
		}

		#endregion

		#region MethodsProtected

		/// <summary>
        /// Clean up any resources being used.
		/// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
                if (this.m_editingControl != null)
                {
                    this.m_editingControl.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
			}
			base.Dispose( disposing );
		}
        /// <summary>
        /// Raises the SubItemBeginEditing event. 
        /// </summary>
        /// <param name="e">A SubItemEventArgs that contains the event data.</param>
        protected void OnSubItemBeginEditing(SubItemEventArgs e)
		{
			if (SubItemBeginEditing != null)
			{
				SubItemBeginEditing(this, e);
			}
		}
        /// <summary>
        /// Raises the SubItemEndEditing event. 
        /// </summary>
        /// <param name="e">A SubItemEventArgs that contains the event data.</param>
		protected void OnSubItemEndEditing(SubItemEndEditingEventArgs e)
		{
			if (SubItemEndEditing != null)
			{
				SubItemEndEditing(this, e);
			}
		}
        /// <summary>
        /// Raises the SubItemClicked event.
        /// </summary>
        /// <param name="e">A SubItemEventArgs that contains the event data.</param>
		protected void OnSubItemClicked(SubItemEventArgs e)
		{
			if (SubItemClicked != null)
			{
				SubItemClicked(this, e);
			}
		}
        /// <summary>
        /// Raises the CreateControl method.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.m_listViewSorter == null)
            {
                this.m_listViewSorter = new ListViewItemSorter();
            }
            this.m_listViewSorter.ListView = this;
        }
		/// <summary>
		/// Liefert eine Liste von <see cref="MenuItem"/>, die die Spalten der <see cref="ListView"/>
		/// entsprechen. Ist die Spalte sichtbar (Breite grösser 0) so wird ein Häckchen vor
		/// den Eintrag gesetzt <see cref="MenuItem.Checked"/>.
		/// </summary>
		/// <returns>Liste von <see cref="MenuItem"/>, die die Spalten der <see cref="ListView"/>
		/// entsprechen.</returns>
		protected ToolStripItem[] GetMenuColumns()
		{
			int iColumnsCount = Columns.Count;
			ToolStripMenuItem[] menuItems = new ToolStripMenuItem[iColumnsCount];

			for (int i = 0; i < iColumnsCount; i++)
			{
				ColumnHeader columnHeader = Columns[i];
				ToolStripMenuItem menuItem = new ToolStripMenuItem();
				menuItem.Text = columnHeader.Text;
				menuItem.Checked = false;
				if (columnHeader.Width > 0)
				{
					menuItem.Checked = true;
				}
                menuItem.Click += new EventHandler(this.HeaderColumnMenuClick);
				menuItems[i] = menuItem;
			}
			return menuItems;
		}
		/// <summary>
		/// Occurs when the mouse pointer is over the listview column and a mouse button is pressed.
		/// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
		protected void OnColumnMouseDown(object sender,MouseEventArgs e)
		{
			if (ColumnMouseDown != null)
			{
				ColumnMouseDown(this,e);
			}
			else
			{
				ColumnMouseDownAction(sender, e);
			}
		}
		/// <summary>
		/// Occurs when the mouse pointer is over the listview column and a mouse button is pressed.
		/// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
		protected void OnColumnMouseUp(object sender,MouseEventArgs e)
		{
			if (ColumnMouseUp != null)
			{
				ColumnMouseUp(this,e);
			}
		}
        /// <summary>
        /// Raises the MouseUp event. 
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);
            if (this.Activation != ItemActivation.OneClick)
			{
				return;
			} 

			EditSubitemAt(new Point(e.X, e.Y));
		}
        /// <summary>
        /// Raises the DoubleClick event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
		protected override void OnDoubleClick(EventArgs e)
		{
            if (this.Activation == ItemActivation.OneClick)
			{
				return;
			} 
            EditSubitemAt(this.PointToClient(Cursor.Position));
            base.OnDoubleClick(e);
		}
        /// <summary>
        /// Raises the HandleCreated event.  
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
		protected override void OnHandleCreated(EventArgs e)
		{
			//Create a new HeaderControl object
			m_headerControl = new HeaderControl(this);
			if(m_headerControl.Handle != IntPtr.Zero)
			{
				//if(headerImages != null)//If we have a valid header handle and a valid ImageList for it
				//send a message HDM_SETIMAGELIST
				NativeMethods.SendMessage(m_headerControl.Handle,0x1200+8,IntPtr.Zero, IntPtr.Zero);
			}
			base.OnHandleCreated(e);
		}
        /// <summary>
        /// Overrides WndProc.
        /// </summary>
        /// <param name="m">The Windows Message to process.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void	WndProc(ref	Message	m)
		{
			switch (m.Msg)
			{
                case NativeMethods.WM_LBUTTONDBLCLK:
                    OnDoubleClick(new System.EventArgs());
                    break;
				// Look	for	WM_VSCROLL,WM_HSCROLL or WM_SIZE messages.
                case NativeMethods.WM_VSCROLL:
                case NativeMethods.WM_HSCROLL:
                case NativeMethods.WM_SIZE:
					EndEditing(false);
					base.WndProc(ref m);
					break;
                case NativeMethods.WM_NOTIFY:
					// Look for WM_NOTIFY of events that might also change the
					// editor's position/size: Column reordering or resizing
                    NativeMethods.NMHDR nMHDR = (NativeMethods.NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NMHDR));
                    if (nMHDR.code == NativeMethods.HDN_BEGINDRAG ||
                        nMHDR.code == NativeMethods.HDN_ITEMCHANGINGA ||
                        nMHDR.code == NativeMethods.HDN_ITEMCHANGINGW)
						EndEditing(false);
					base.WndProc(ref m);
					break;
                case NativeMethods.WM_PAINT:
                    SetAlternatingColor();
                    base.WndProc(ref m);
                    break;
                default:
					base.WndProc(ref m);
					break;
			}
		}
        /// <summary>
        /// Raises the DragOver event.
        /// </summary>
        /// <param name="drgevent">A DragEventArgs that contains the event data.</param>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            // get the currently hovered row that the items will be dragged to
            Point clientPoint = base.PointToClient(new Point(drgevent.X, drgevent.Y));
            ListViewItem hoverListViewItem = base.GetItemAt(clientPoint.X, clientPoint.Y);

            if (hoverListViewItem != null)
            {
                hoverListViewItem.EnsureVisible();
            }
        }
        /// <summary>
        /// Raises the DragDrop event. 
        /// </summary>
        /// <param name="drgevent">A DragEventArgs that contains the event data.</param>
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (!this.m_bDragDropOnlyAsEvent)
			{
				if (drgevent.Data is CDataObject)
				{
					// get the currently hovered row that the items will be dragged to
					Point clientPoint = base.PointToClient(new Point(drgevent.X, drgevent.Y));
					ListViewItem hoverListViewItem = base.GetItemAt(clientPoint.X, clientPoint.Y);
				
					//Get the dataobject
					CDataObject dataObject = (CDataObject)drgevent.Data;
					CDraggedListViewObjects draggedListViewObjects = null;
					//check the overload of the dataobject
					if (dataObject.GetDataPresent(typeof(CDraggedListViewObjects).ToString()))
					{
						draggedListViewObjects
							= (CDraggedListViewObjects)dataObject.GetData(typeof(CDraggedListViewObjects).ToString());
						if (draggedListViewObjects.ParentListView == null)
						{
							return;
						}
					}
					if (dataObject.DragData != null)
					{
						draggedListViewObjects
							= (CDraggedListViewObjects)dataObject.DragData;
						if (draggedListViewObjects.ParentListView == null)
						{
							return;
						}
					}

					if(hoverListViewItem == null)
					{
						// the user does not wish to re-order the items, just append to the end
						for(int i=0; i < draggedListViewObjects.DragObjects.Count; i++)
						{
							ListViewItem newListViewItem = (ListViewItem) draggedListViewObjects.DragObjects[i];
							this.Items.Add(newListViewItem);
						}
					}
					else
					{
						// the user wishes to re-order the items
						// get the index of the hover item
						int iHoverIndex = hoverListViewItem.Index;

						// determine if the items to be dropped are from
						// this list view. If they are, perform a hack
						// to increment the hover index so that the items
						// get moved properly.
						if(this == draggedListViewObjects.ParentListView)
						{
							if(iHoverIndex > base.SelectedItems[0].Index)
							{
								iHoverIndex++;
							}
						}
						// insert the new items into the list view
						// by inserting the items reversely from the array list
						for(int i = draggedListViewObjects.DragObjects.Count - 1; i >= 0; i--)
						{
							ListViewItem newListViewItem = (ListViewItem) draggedListViewObjects.DragObjects[i];
							this.Items.Insert(iHoverIndex, newListViewItem);
						}
					}
					// remove all the selected items from the previous list view
					// if the list view was found
					if(draggedListViewObjects.ParentListView != null)
					{
						if (draggedListViewObjects.ParentListView.DragDropEffects == DragDropEffects.Move)
						{
							foreach(ListViewItem listViewItemToRemove in draggedListViewObjects.ParentListView.SelectedItems)
							{
								draggedListViewObjects.ParentListView.Items.Remove(listViewItemToRemove);
							}
						}
					}
				}
			}
			// call the base on drag drop to raise the event
			base.OnDragDrop (drgevent);
		}
        /// <summary>
        /// Raises the DragEnter event.
        /// </summary>
        /// <param name="drgevent">A DragEventArgs that contains the event data.</param>
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (drgevent.AllowedEffect == DragDropEffects.None)
			{
				return;
			}
			if (drgevent.Data.GetType() == typeof(CDataObject))
			{
				drgevent.Effect = DragDropEffects.All;
			}
			else
			{
				drgevent.Effect = DragDropEffects.None;
			}
			// call the base OnDragEnter event
			base.OnDragEnter(drgevent);
		}
        /// <summary>
        /// Raises the ItemDrag event.
        /// </summary>
        /// <param name="e">An ItemDragEventArgs that contains the event data.</param>
		protected override void OnItemDrag(ItemDragEventArgs e)
		{
			if (!this.m_bAllowDrag)
			{
				return;
			}
			CDataObject dataObject = null;
			CDraggedListViewObjects draggedListViewObjects = GetListViewItems();
			
			int iListViewItemForFileDroppingIndex = -1;
			
			foreach(ColumnHeader clmHeader in this.Columns)
			{
				if (clmHeader.EnableFileDropping)
				{
					iListViewItemForFileDroppingIndex = clmHeader.Index;
					break;
				}
			}
			
			if (iListViewItemForFileDroppingIndex != -1)
			{
				int iSelectedItemsCount = this.SelectedItems.Count;
				String[] strFiles = new String[iSelectedItemsCount];
				for (int i = 0; i < iSelectedItemsCount; i++)
				{
					strFiles[i] = this.SelectedItems[i].SubItems[iListViewItemForFileDroppingIndex].Text;
				}
				dataObject = new CDataObject(DataFormats.FileDrop,strFiles,draggedListViewObjects);
			}
			else
			{
				dataObject = new CDataObject(draggedListViewObjects);
			}

			if (dataObject != null)
			{
				base.DoDragDrop(dataObject,this.m_dragDropEffects);
			}
			// call the base OnItemDrag event
			base.OnItemDrag(e);
		}
        /// <summary>
        /// Raises the KeyDown event.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (this.m_bAllowSelectAllItems)
			{
				switch (e.KeyCode)
				{
					case Keys.A:
						if (e.Modifiers == Keys.Control)
						{
							foreach (ListViewItem listViewItem in this.Items)
							{
								listViewItem.Selected = true;
							}
						}
						break;
				}
			}
			base.OnKeyDown(e);
		}

		#endregion

		#region MethodsPrivate
		/// <summary>
		/// Diese Funktion wird ausgeführt, wenn die Maustaste gedrückt wurde. Ist es die 
		/// rechte Maustaste, so wird ein Kontextmenue mit allen Spalten dargestellt.
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Eventargument</param>
		private void ColumnMouseDownAction(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                contextMenu.Items.AddRange(GetMenuColumns());
                contextMenu.Show(
                    new Point(
                    Cursor.Position.X,
                    Cursor.Position.Y));
			}
		}
        private void HeaderColumnMenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ColumnHeader columnHeader = null;
            foreach (ColumnHeader tmpColumnHeader in this.Columns)
            {
                if (tmpColumnHeader.Text == menuItem.Text)
                {
                    columnHeader = tmpColumnHeader;
                    break;
                }
            }
            if (menuItem.Checked)
            {
                columnHeader.Width = 0;
                menuItem.Checked = false;
            }
            else
            {
                //Settings for columnheaders
                columnHeader.Width = m_iSizeColumnOnShow;
                menuItem.Checked = true;
            }
        }
		
        private void EditingControlLeave(object sender, EventArgs e)
		{
			// cell editor losing focus
			EndEditing(true);
		}
		
		private void EditingControlKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case (char)(int)Keys.Escape:
				{
					EndEditing(false);
					break;
				}

				case (char)(int)Keys.Enter:
				{  
					EndEditing(true);
					break;
				}
			}
		}

		///<summary>
		/// Fire SubItemClicked
		///</summary>
        ///<param name="point">Point of click/doubleclick</param>
		private void EditSubitemAt(Point point)
		{
			ListViewItem listViewItem;
			int iIndex = GetSubItemAt(point.X, point.Y, out listViewItem);
			if (iIndex >= 0)
			{
				OnSubItemClicked(new SubItemEventArgs(listViewItem, iIndex));
				//wird der event nicht verwendet, werden die eingebetteten Controls angezeigt
				if (SubItemClicked == null)
				{
					StartEditing(listViewItem,iIndex);
				}
			}
		}
        
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private int[] GetColumnOrder()
        {
            IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)) * Columns.Count);

            IntPtr result = NativeMethods.SendMessage(Handle, NativeMethods.LVM_GETCOLUMNORDERARRAY, new IntPtr(Columns.Count), lParam);
            if (result.ToInt32() == 0)	// Something went wrong
            {
                Marshal.FreeHGlobal(lParam);
                return null;
            }

            int[] iOrder = new int[Columns.Count];
            Marshal.Copy(lParam, iOrder, 0, Columns.Count);

            Marshal.FreeHGlobal(lParam);

            return iOrder;
        }
        //private void CreateListViewSorter()
        //{
        //    if (this.m_listViewSorter == null)
        //    {
        //        this.m_listViewSorter = new BSE.Windows.Forms.CListViewSorter(this);
        //    }

        //    int iColumnsCount = this.Columns.Count;

        //    for (int i = 0; i < iColumnsCount; i++)
        //    {
        //        ColumnHeader columnHeader = Columns[i];
        //        BSE.Windows.Forms.ListViewComparer listViewComparer = BSE.Windows.Forms.ListViewComparer.Strings;
        //        listViewComparer = columnHeader.ListViewComparer;

        //        switch (listViewComparer)
        //        {
        //            case BSE.Windows.Forms.ListViewComparer.Strings:
        //                m_listViewSorter[i] = new BSE.Windows.Forms.CListViewSorter.Comparer(BSE.Windows.Forms.CListViewSorter.CompareStrings);
        //                break;
        //            case BSE.Windows.Forms.ListViewComparer.Numbers:
        //                m_listViewSorter[i] = new BSE.Windows.Forms.CListViewSorter.Comparer(BSE.Windows.Forms.CListViewSorter.CompareNumbers);
        //                break;
        //            case BSE.Windows.Forms.ListViewComparer.Dates:
        //                m_listViewSorter[i] = new BSE.Windows.Forms.CListViewSorter.Comparer(BSE.Windows.Forms.CListViewSorter.CompareDates);
        //                break;
        //            case BSE.Windows.Forms.ListViewComparer.Guids:
        //                m_listViewSorter[i] = new BSE.Windows.Forms.CListViewSorter.Comparer(BSE.Windows.Forms.CListViewSorter.CompareGuids);
        //                break;
        //            default:
        //                m_listViewSorter[i] = new BSE.Windows.Forms.CListViewSorter.Comparer(BSE.Windows.Forms.CListViewSorter.CompareStrings);
        //                break;
        //        }
        //    }
        //}

        private void SetAlternatingColor()
        {
            int iIndex = 0;
            foreach (ListViewItem listViewItem in this.Items)
            {
                if (listViewItem != null)
                {
                    listViewItem.BackColor = this.BackColor;
                    if (iIndex % 2 != 0)
                    {
                        listViewItem.BackColor = this.AlternatingBackColor;
                    }
                    iIndex++;
                }
            }
        }

		private CDraggedListViewObjects GetListViewItems()
		{
			// create a drag item data object that will be used to pass along with the drag and drop
			CDraggedListViewObjects draggedListViewObjects
				= new CDraggedListViewObjects(this);

			// go through each of the selected items and 
			// add them to the drag items collection
			// by creating a clone of the list item
			foreach(ListViewItem listViewItem in this.SelectedItems)
			{
				draggedListViewObjects.DragObjects.Add(listViewItem.Clone());
			}

			return draggedListViewObjects;
		}

        #region class NativeMethods

        internal static class NativeMethods
        {
            #region Constants
            /// <summary>
            /// The position is inside the list-view control's client window, but it is not over a list item
            /// </summary>
            public const int LVHT_NOWHERE = 0x1;
            public const int LVHT_ONITEM = 0x0014;
            /// <summary>
            /// This message is sent when a window is being activated or deactivated.
            /// This message is sent first to the window procedure of the top-level
            /// window being deactivated; it is then sent to the window procedure of the top-level
            /// window being activated.
            /// </summary>
            public const int WM_ACTIVATE = 0x0006;
            /// <summary>
            /// The WM_CLOSE message is sent as a signal that a window or an application should terminate.
            /// </summary>
            public const int WM_CLOSE = 0x0010;
            /// <summary>
            /// The WM_CREATE message is sent when an application requests
            /// that a window be created by calling the CreateWindowEx or CreateWindow function.
            /// (The message is sent before the function returns.) The window procedure of the
            /// new window receives this message after the window is created,
            /// but before the window becomes visible.
            /// </summary>
            public const int WM_CREATE = 0x0001;
            /// <summary>
            /// The WM_NOTIFY message is sent by a common control to its parent window
            /// when an event has occurred or the control requires some information.
            /// </summary>
            /// <summary>
            /// This message is sent when a window is being destroyed. It is sent to the window procedure
            /// of the window being destroyed after the window is removed from the screen.
            /// </summary>
            public const int WM_DESTROY = 0x0002;
            /// <summary>
            /// This message is sent when an application changes the enabled state of a window.
            /// It is sent to the window whose enabled state is changing.
            /// </summary>
            public const int WM_ENABLE = 0x000A;
            /// <summary>
            /// Sent by a common control to its parent window when an event has occurred or the control requires some information.
            /// </summary>
            public const int WM_NOTIFY = 0x4E;
            /// <summary>
            /// The WM_NULL message performs no operation.
            /// An application sends the WM_NULL message if it wants to post a message
            /// that the recipient window will ignore.
            /// </summary>
            public const int WM_NULL = 0x0000;
            /// <summary>
            /// This message is sent after a window has been moved.
            /// </summary>
            public const int WM_MOVE = 0x0003;
            /// <summary>
            /// This message is sent to a window after it has gained the keyboard focus.
            /// </summary>
            public const int WM_SETFOCUS = 0x0007;
            /// <summary>
            /// This message is sent to a window immediately before it loses the keyboard focus.
            /// </summary>
            public const int WM_KILLFOCUS = 0x0008;
            /// <summary>
            /// The WM_PAINT message is sent when the system or another application
            /// makes a request to paint a portion of an application's window.
            /// </summary>
            public const int WM_PAINT = 0x000F;
            /// <summary>
            /// The WM_SIZE message is sent to a window after its size has changed.
            /// </summary>
            public const int WM_SIZE = 0x05;
            /// <summary>
            /// The WM_HSCROLL message is sent to a window when a scroll event occurs
            /// in the window's standard horizontal scroll bar.
            /// This message is also sent to the owner of a horizontal
            /// scroll bar control when a scroll event occurs in the control.
            /// </summary>
            public const int WM_HSCROLL = 0x114;
            /// <summary>
            /// The WM_VSCROLL message is sent to a window when a scroll event occurs
            /// in the window's standard vertical scroll bar.
            /// This message is also sent to the owner of a vertical
            /// scroll bar control when a scroll event occurs in the control.
            /// </summary>
            public const int WM_VSCROLL = 0x115;
            /// <summary>
            /// Konstante für die Windows Message: Linke Maustaste wurde doppelgeklickt.
            /// </summary>
            public const int WM_LBUTTONDBLCLK = 0x0203;
            /// <summary>
            /// The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor
            /// is in the client area of a window. If the mouse is not captured,
            /// the message is posted to the window beneath the cursor. Otherwise,
            /// the message is posted to the window that has captured the mouse.
            /// </summary>
            public const int WM_LBUTTONDOWN = 0x0201;
            /// <summary>
            /// The WM_LBUTTONUP message is posted when the user releases the left mouse button while the cursor
            /// is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor.
            /// Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            public const int WM_LBUTTONUP = 0x0202;
            /// <summary>
            /// The WM_RBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is
            /// in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor.
            /// Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            public const int WM_RBUTTONDOWN = 0x0204;
            /// <summary>
            /// The WM_RBUTTONUP message is posted when the user releases the right mouse button while the cursor
            /// is in the client area of a window. If the mouse is not captured, the message is posted to the window
            /// beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            /// </summary>
            public const int WM_RBUTTONUP = 0x0205;
            /// <summary>
            /// Gets the current left-to-right order of columns in a list-view control.
            /// You can send this message explicitly or use the ListView_GetColumnOrderArray macro.
            /// </summary>
            public const int LVM_GETCOLUMNORDERARRAY = 0x103b;
            /// <summary>
            /// This message determines which list-view item or subitem is at a specified position
            /// </summary>
            public const int LVM_SUBITEMHITTEST = 0x1039;
            /// <summary>
            /// Sent by a header control when a drag operation has begun on one of its items.
            /// This notification message is sent only by header controls that are set to the HDS_DRAGDROP style.
            /// This notification is sent in the form of a WM_NOTIFY message.
            /// </summary>
            public const int HDN_BEGINDRAG = -310;
            public const int HDN_ITEMCHANGINGA = -300;
            public const int HDN_ITEMCHANGINGW = -320;
            #endregion

            #region MethodsPublic
            /// <summary>
            /// Contains information about a notification message.
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct NMHDR
            {
                /// <summary>
                /// A window handle to the control sending the message.
                /// </summary>
                public IntPtr hwndFrom;
                /// <summary>
                /// An identifier of the control sending the message.
                /// </summary>
                public IntPtr idFrom;
                /// <summary>
                /// A notification code. This member can be one of the common notification codes 
                /// (see Notifications under General Control Reference),
                /// or it can be a control-specific notification code. 
                /// </summary>
                public int code;
            }
/// <summary>
            /// Contains information about a hit test.
            /// This structure has been extended to accommodate subitem hit-testing.
            /// It is used in association with the LVM_HITTEST and LVM_SUBITEMHITTEST messages and their related macros.
            /// This structure supersedes the LVHITTESTINFO structure.
            /// </summary>
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            struct LVHITTESTINFO
            {
                /// <summary>
                /// The position to hit test, in client coordinates. 
                /// </summary>
                public int pt_x;
                /// <summary>
                /// The position to hit test, in client coordinates. 
                /// </summary>
                public int pt_y;
                /// <summary>
                /// The variable that receives information about the results of a hit test.
                /// </summary>
                public int flags;
                /// <summary>
                /// Receives the index of the matching item. Or if hit-testing a subitem,
                /// this value represents the subitem's parent item. 
                /// </summary>
                public int iItem;
                /// <summary>
                /// Receives the index of the matching subitem. When hit-testing an item, this member will be zero. 
                /// </summary>
                public int iSubItem;
            }
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
            /// <summary>
            /// The SendMessage function sends the specified message to a window or windows. 
            /// It calls the window procedure for the specified window and does not return 
            /// until the window procedure has processed the message.			/// 
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
            private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref NativeMethods.LVHITTESTINFO lParam);

            public static bool HitTest(Point hitPoint, ListView listView, out int rowIndex, out int columnIndex)
            {
                // clear the output values
                rowIndex = -1;
                columnIndex = -1;

                // set up the return value
                bool bHitLocationFound = false;

                // initialise a hittest information structure
                LVHITTESTINFO lvHitTestInfo = new LVHITTESTINFO();
                lvHitTestInfo.pt_x = hitPoint.X;
                lvHitTestInfo.pt_y = hitPoint.Y;

                // send the hittest message to find out where the click was
                if (SendMessage(listView.Handle, NativeMethods.LVM_SUBITEMHITTEST, 0, ref lvHitTestInfo) != -1)
                {
                    bool nowhere = ((lvHitTestInfo.flags & NativeMethods.LVHT_NOWHERE) != 0);
                    bool onItem = ((lvHitTestInfo.flags & NativeMethods.LVHT_ONITEM) != 0);

                    if (onItem && !nowhere)
                    {
                        rowIndex = lvHitTestInfo.iItem;
                        columnIndex = lvHitTestInfo.iSubItem;
                        bHitLocationFound = true;
                    }
                }

                return bHitLocationFound;
            }
            #endregion
        }

        #endregion

		#region Class CHeaderControl
		/// <summary>
        /// Klasse HeaderControl
		/// </summary>
		internal class HeaderControl : NativeWindow
		{
			#region FieldsPrivate

			/// <summary>
			/// Listview zu der dieser Header gehört.
			/// </summary>
			BSE.Windows.Forms.ListView m_lvwParent;

			#endregion
			
			#region MethodsPublic
			/// <summary>
			/// Header der Listview
			/// </summary>
			/// <param name="lvwParent">Listview zu der dieser Header gehört.</param>
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            public HeaderControl(BSE.Windows.Forms.ListView lvwParent)
			{
				this.m_lvwParent = lvwParent;
				//Get the header control handle
				IntPtr header = NativeMethods.SendMessage(m_lvwParent.Handle, (0x1000+31), IntPtr.Zero, IntPtr.Zero);
				this.AssignHandle(header);				
			}

			#endregion

			#region MethodsProtected
			/// <summary>
			/// Invokes the default window procedure associated with this window.
			/// </summary>
			/// <param name="m">
			/// A <see cref="Message"/> that is associated with the current Windows message.
			/// </param>
			protected override void WndProc(ref Message m)
			{
				switch(m.Msg)
				{
					case NativeMethods.WM_LBUTTONDOWN:
						m_lvwParent.OnColumnMouseDown(this,new MouseEventArgs(
							MouseButtons.Left,
							1,
							MousePosition.X,
							MousePosition.Y,1));
						base.WndProc(ref m);
						break;
                    case NativeMethods.WM_LBUTTONUP:
						m_lvwParent.OnColumnMouseUp(this,new MouseEventArgs(
							MouseButtons.Left,
							1,
							MousePosition.X,
							MousePosition.Y,
							1));
						base.WndProc(ref m);
						break;
                    case NativeMethods.WM_RBUTTONDOWN:
						m_lvwParent.OnColumnMouseDown(this,new MouseEventArgs(
							MouseButtons.Right,
							1,
							MousePosition.X,
							MousePosition.Y,
							1));
						base.WndProc(ref m);
						break;
                    case NativeMethods.WM_RBUTTONUP:
						m_lvwParent.OnColumnMouseUp(this,new MouseEventArgs(
							MouseButtons.Right,
							1,
							MousePosition.X,
							MousePosition.Y,
							1));
						base.WndProc(ref m);
						break;
					default:
						base.WndProc(ref m);
						break;
				}
			}

			#endregion
		}

		#endregion

		#endregion

        #region Class ListViewItemCollection
        /// <summary>
        /// Represents the collection of items in a ListView control or assigned to a ListViewGroup.
        /// </summary>
        public new class ListViewItemCollection : System.Windows.Forms.ListView.ListViewItemCollection
        {
            #region FieldsPrivate

            private BSE.Windows.Forms.ListView m_lstvParent;

            #endregion

            #region MethodsPublic
            /// <summary>
            /// Initializes a new instance of the ListView.ListViewItemCollection class.
            /// </summary>
            public ListViewItemCollection(BSE.Windows.Forms.ListView lstvParent)
                : base(lstvParent)
            {
                this.m_lstvParent = lstvParent;
            }
            /// <summary>
            /// Adds an existing ListViewItem to the collection.
            /// </summary>
            /// <param name="value">The ListViewItem to add to the collection.</param>
            /// <returns>The ListViewItem that was added to the collection.</returns>
            public override ListViewItem Add(ListViewItem value)
            {
                if (this.m_lstvParent.ListViewItemAdded != null)
                {
                    this.m_lstvParent.ListViewItemAdded(this.m_lstvParent, EventArgs.Empty);
                }
                return base.Add(value);
            }
            /// <summary>
            /// Adds an array of ListViewItem objects to the collection.
            /// </summary>
            /// <param name="value">An array of ListViewItem objects to add to the collection.</param>
            public new void AddRange(System.Windows.Forms.ListViewItem[] value)
            {
                base.AddRange(value);
                if (this.m_lstvParent.ListViewItemAdded != null)
                {
                    this.m_lstvParent.ListViewItemAdded(this.m_lstvParent, EventArgs.Empty);
                }
            }
            /// <summary>
            /// Removes the specified item from the collection.
            /// </summary>
            /// <param name="item">A ListViewItem representing the item to remove from the collection.</param>
            public override void Remove(System.Windows.Forms.ListViewItem item)
            {
                base.Remove(item);
                if (this.m_lstvParent.ListViewItemRemoved != null)
                {
                    this.m_lstvParent.ListViewItemRemoved(this.m_lstvParent, EventArgs.Empty);
                }
            }
            /// <summary>
            /// Removes the item at the specified index within the collection.
            /// </summary>
            /// <param name="iIndex">The zero-based index of the item to remove.</param>
            public override void RemoveAt(int iIndex)
            {
                System.Windows.Forms.ListViewItem listViewItem = this[iIndex];
                base.RemoveAt(iIndex);
                if (this.m_lstvParent.ListViewItemRemoved != null)
                {
                    this.m_lstvParent.ListViewItemRemoved(this.m_lstvParent, EventArgs.Empty);
                }
            }
            /// <summary>
            /// Inserts an existing ListViewItem into the collection at the specified index.
            /// </summary>
            /// <param name="iIndex">The zero-based index location where the item is inserted.</param>
            /// <param name="listViewItem">The ListViewItem that represents the item to insert.</param>
            /// <returns>The ListViewItem that was inserted into the collection.</returns>
            public new ListViewItem Insert(int iIndex, ListViewItem listViewItem)
            {
                base.Insert(iIndex, listViewItem);
                if (this.m_lstvParent.ListViewItemInserted != null)
                {
                    this.m_lstvParent.ListViewItemInserted(this.m_lstvParent, EventArgs.Empty);
                }
                return listViewItem;
            }
            /// <summary>
            /// Removes all items from the collection.
            /// </summary>
            public override void Clear()
            {
                base.Clear();
                if (this.m_lstvParent.ListViewCleared != null)
                {
                    this.m_lstvParent.ListViewCleared(this.m_lstvParent, EventArgs.Empty);
                }
            }

            #endregion
        }

        #endregion
    }
}
