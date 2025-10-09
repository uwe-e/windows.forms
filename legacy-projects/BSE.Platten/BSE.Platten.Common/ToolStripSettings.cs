using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;

namespace BSE.Platten.Common
{
	public class ToolStripSettings
	{
		#region FieldsPrivate

		private Point m_location;
		private string m_strName;
		private Size m_size;
		private string m_strToolStripPanelName;
		private bool m_bVisible = true;

		#endregion

		#region Properties
        /// <summary>
        /// Gets or sets the coordinates of the upper-left corner of the toolstrip relative to the upper-left
        /// corner of its container.
        /// </summary>
		public Point Location
		{
			get { return this.m_location; }
			set { this.m_location = value; }
		}
        /// <summary>
        /// Gets or sets the name of the control.
        /// </summary>
		public string Name
		{
			get { return this.m_strName; }
			set { this.m_strName = value; }
		}
        /// <summary>
        /// Gets or sets the height and width of the toolstrip.
        /// </summary>
		public Size Size
		{
			get { return this.m_size; }
			set { this.m_size = value; }
		}
        /// <summary>
        /// Gets or sets the name of the toolstrippanel which contains the toolstrip.
        /// </summary>
		public string ToolStripPanelName
		{
			get { return this.m_strToolStripPanelName; }
			set { this.m_strToolStripPanelName = value; }
		}
        /// <summary>
        /// Gets or sets a value indicating whether the toolstrip and all its parent controls are displayed
        /// </summary>
		public bool Visible
		{
			get { return this.m_bVisible; }
			set { this.m_bVisible = value; }
		}

		#endregion
    }
}
