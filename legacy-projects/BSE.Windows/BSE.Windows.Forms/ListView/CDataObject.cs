using System;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	/// <summary>
	/// Summary description for CDataObject.
	/// </summary>
	/// <remarks></remarks>
	/// <copyright>Copyright © 2005 BSE</copyright>
	public class CDataObject : DataObject
	{
		#region FieldsPrivate
		
		private object m_dragdata;
		
		#endregion

		#region Properties
		
		/// <summary>
		/// The data to store
		/// </summary>
		public object DragData
		{
			get {return this.m_dragdata;}
			set {this.m_dragdata = value;}
		}
		
		#endregion

		#region MethodsPublic
		
		/// <summary>
		/// Initializes a new instance of the DataObject class, which can store arbitrary data.
		/// </summary>
		public CDataObject() : base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the DataObject class, containing the specified data.
		/// </summary>
		/// <param name="data">The data to store.</param>
		public CDataObject(object data) : base(data)
		{
		}

		/// <summary>
		/// Initializes a new instance of the CDataObject class, containing the specified data and its associated format.
		/// </summary>
		/// <param name="format">The class type associated with the data. See DataFormats for the predefined formats.</param>
		/// <param name="data">The data to store</param>
		public CDataObject(string format,object data) : base(format,data)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the CDataObject class, containing the specified data and its associated format.
		/// </summary>
		/// <param name="format">The class type associated with the data. See DataFormats for the predefined formats.</param>
		/// <param name="data">The string for dragging</param>
		/// <param name="dragdata">The data to store</param>
		public CDataObject(string format,object data,object dragdata) : base(format,data)
		{
			this.m_dragdata = dragdata;
		}
		#endregion

	}
}
