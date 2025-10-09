using System;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Zusammenfassung für ColumnHeader.
	/// </summary>
	public class ColumnHeader : System.Windows.Forms.ColumnHeader
	{
		
		#region FieldsPrivate
		
		/// <summary>
		/// Type of system embedded control you would like activated in place here.
		/// </summary>
		private BSE.Windows.Forms.EmbeddedControlType m_eEmbeddedControlType;
		/// <summary>
		/// Activated embedded control types available.
		/// </summary>
		private Control m_embeddedControl;
		/// <summary>
		/// Enum für die Comparer
		/// </summary>
		private BSE.Windows.Forms.ListViewComparer m_listViewComparer;
		/// <summary>
		/// Enables drag and drop for this column
		/// </summary>
		private bool m_bEnableFileDropping;
		
		#endregion
		
		#region Properties
		/// <summary>
		/// Activated embedded control types available.
		/// </summary>
		[System.ComponentModel.Description("Activated embedded control types available.")]
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.Browsable(false)]
		public Control EmbeddedControl
		{
			get { return m_embeddedControl;}
			set {m_embeddedControl = value;}
		}
        /// <summary>
        /// Type of system embedded control you would like activated in place here.
        /// </summary>
		[System.ComponentModel.Description("Type of system embedded control you would like activated in place here.")]
		[System.ComponentModel.Category("Behavior")]
		[System.ComponentModel.DefaultValue(BSE.Windows.Forms.EmbeddedControlType.None)]
		public BSE.Windows.Forms.EmbeddedControlType EmbeddedControlType
		{
			get {return m_eEmbeddedControlType;}
			set
			{
				m_eEmbeddedControlType = value;
				switch (m_eEmbeddedControlType)
				{
					case BSE.Windows.Forms.EmbeddedControlType.None:
						this.m_embeddedControl = null;
						break;
					case BSE.Windows.Forms.EmbeddedControlType.TextBox:
						this.m_embeddedControl = new System.Windows.Forms.TextBox();
						break;
				}
			}
		}
		/// <summary>
		/// Art der Sortierung für eine Spalte in der ListView
		/// </summary>
		[System.ComponentModel.Browsable(true)]
		[System.ComponentModel.Description("Art der Sortierung für eine Spalte in der ListView")]
		[System.ComponentModel.Category("Behavior")]
		public BSE.Windows.Forms.ListViewComparer ListViewComparer
		{
			get {return this.m_listViewComparer;}
			set {this.m_listViewComparer = value;}
		}
		
		/// <summary>
		/// Enables drag and drop for this column
		/// </summary>
		[System.ComponentModel.Browsable(true)]
		[System.ComponentModel.Description("Enables drag and drop for this column")]
		[System.ComponentModel.DefaultValue(false)]
		[System.ComponentModel.Category("Behavior")]
		public bool EnableFileDropping
		{
			get {return this.m_bEnableFileDropping;}
			set {this.m_bEnableFileDropping = value;}
		}

		#endregion

		#region MethodsPublic
		#endregion
	}
}
