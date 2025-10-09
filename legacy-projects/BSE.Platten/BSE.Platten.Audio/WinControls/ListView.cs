using System;

namespace BSE.Platten.Audio.WinControls
{
	[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ListView))]
	public class ListView : BSE.Windows.Forms.ListView
	{
		#region FieldsPrivate
		
		/// <summary>
		/// Represents the collection of column headers in a ListView control.
		/// </summary>
		private BSE.Platten.Audio.WinControls.ColumnHeaderCollection m_columns;
		
		#endregion
		
		#region Properties
		
		[System.ComponentModel.Browsable(true)]
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
		[System.ComponentModel.Description("A ListView.ColumnHeaderCollection that represents the ColumnHeader headers.")]
		public new BSE.Platten.Audio.WinControls.ColumnHeaderCollection Columns
		{
			get {return m_columns;}
		}
		
		#endregion

		#region MethodsPublic

		public ListView()
		{
			this.m_columns = new BSE.Platten.Audio.WinControls.ColumnHeaderCollection(this);
		}

		#endregion
	}
}
