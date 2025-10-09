using System;
using System.Data;

namespace BSE.Platten.BO
{
	#region Class CDataSetMedium
	/// <summary>
	/// Zusammendfassende Beschreibung für C_DataSetMedium.
	/// </summary>
	public class CDataSetMedium : DataSet
    {
        #region Konstanten

        public const string SOURCETABLE = "Medium";

        #endregion
        
        #region FieldsPrivate

        private CDataTableMedium m_dataTableMedium;

		#endregion

		#region Properties

		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CDataTableMedium Medium
		{
			get 
			{
				return this.m_dataTableMedium;
			}
		}

		#endregion
		
		#region MethodsPublic

		public CDataSetMedium()
		{
			this.InitClass();
		}

		#endregion

		#region MethodsPrivate

		private void InitClass()
		{
			this.DataSetName = "DataSetMedium";
			this.Namespace = "";
			this.m_dataTableMedium = new CDataTableMedium();
			this.Tables.Add(this.m_dataTableMedium);
		}

		#endregion
	}

	#endregion

	#region Class CDataTableMedium

	public class CDataTableMedium : DataTable,System.Collections.IEnumerable
	{
		#region FieldsPublic

		public event EventHandler<MediumChangeEventArgs> MediumChanged;
        public event EventHandler<MediumChangeEventArgs> MediumChanging;

		#endregion
		
		#region FieldsPrivate

		private DataColumn m_dataColumnMediumId;
		private DataColumn m_dataColumnMedium;
		private DataColumn m_dataColumnBeschreibung;
		private DataColumn m_dataColumnGuid;
		private DataColumn m_dataColumnTimestamp;

		#endregion

		#region Properties

		public int Count 
		{
			get 
			{
				return this.Rows.Count;
			}
		}

		internal DataColumn DataColumnMediumId 
		{
			get 
			{
				return this.m_dataColumnMediumId;
			}
		}
		
		public DataColumn DataColumnMedium
		{
			get 
			{
				return this.m_dataColumnMedium;
			}
		}
		
		public DataColumn DataColumnBeschreibung 
		{
			get 
			{
				return this.m_dataColumnBeschreibung;
			}
		}
		
		internal DataColumn DataColumnGuid
		{
			get 
			{
				return this.m_dataColumnGuid;
			}
		}

		internal DataColumn DataColumnTimestamp
		{
			get 
			{
				return this.m_dataColumnTimestamp;
			}
		}

		public CDataRowMedium this[int iIndex]
		{
			get { return ((CDataRowMedium)(this.Rows[iIndex]));}
		}

		#endregion
		
		#region MethodsPublic
		
		public System.Collections.IEnumerator GetEnumerator() 
		{
			return this.Rows.GetEnumerator();
		}
		
		public void AddDataRowMedium(CDataRowMedium row) 
		{
            this.Rows.Add(row);
		}
		
		public CDataRowMedium FindByMediumId(int iMediumId) 
		{
            return ((CDataRowMedium)(this.Rows.Find(new Object[] { iMediumId })));
		}
		
		public new CDataRowMedium NewRow() 
		{
            return ((CDataRowMedium)(this.NewRow()));
		}

		#endregion

		#region MethodsProtected
	
		protected override System.Type GetRowType() 
		{
			return typeof(CDataRowMedium);
		}
		
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder) 
		{
			// We need to ensure that all Rows in the tabled are typed rows.
			// Table calls newRow whenever it needs to create a row.
			// So the following conditions are covered by Row newRow(Record record)
			// * Cursor calls table.addRecord(record) 
			// * table.addRow(object[] values) calls newRow(record)    
            return new CDataRowMedium(builder);
		}
		
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			if (this.MediumChanged != null)
			{
				this.MediumChanged(this, new MediumChangeEventArgs(((CDataRowMedium)(e.Row)), e.Action));
			}
			base.OnRowChanged(e);
		}
		
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			if (((this.MediumChanging) != (null)))
			{
				this.MediumChanging(this, new MediumChangeEventArgs(((CDataRowMedium)(e.Row)), e.Action));
			}
			base.OnRowChanging(e);
		}

		#endregion

		#region MethodsPrivate
		
		internal CDataTableMedium() : base(CDataSetMedium.SOURCETABLE) 
		{
			this.InitClass();
		}

		private void InitClass() 
		{
			this.m_dataColumnMediumId = new DataColumn("MediumId", typeof(int), "", MappingType.Element);
			this.m_dataColumnMediumId.AllowDBNull = true;
			this.m_dataColumnMediumId.Unique = true;
			this.m_dataColumnMediumId.DefaultValue = -1;
			this.Columns.Add(this.m_dataColumnMediumId);
			this.m_dataColumnMedium = new DataColumn("Medium", typeof(string), "", MappingType.Element);
            this.m_dataColumnMedium.MaxLength = 5;
            this.Columns.Add(this.m_dataColumnMedium);
			this.m_dataColumnBeschreibung = new DataColumn("Beschreibung", typeof(string), "", MappingType.Element);
            this.m_dataColumnBeschreibung.MaxLength = 50;
            this.Columns.Add(this.m_dataColumnBeschreibung);
			this.m_dataColumnGuid = new DataColumn("Guid", typeof(string), "", MappingType.Element);
			this.Columns.Add(this.m_dataColumnGuid);
			this.m_dataColumnTimestamp = new DataColumn("Timestamp", typeof(DateTime), "", MappingType.Element);
			this.Columns.Add(this.m_dataColumnTimestamp);
            //Beim Merge können Rows nur zusammengeführt werden, wenn sie eine eindeutige
            //Beziehung haben. Diese Beziehung ist der Guid Wert
            this.PrimaryKey = new DataColumn[] { this.m_dataColumnGuid };
		}

		#endregion
	}

	#endregion

	#region Class DataRowMedium

	public class CDataRowMedium : DataRow
	{
		
		#region FieldsPrivate
		
		private CDataTableMedium m_dataTableMedium;

		#endregion

		#region Properties

		public int MediumId
		{
			get 
			{
				return ((int)(this[this.m_dataTableMedium.DataColumnMediumId]));
			}
			set 
			{
				this[this.m_dataTableMedium.DataColumnMediumId] = value;
			}
		}

		public string Medium
		{
			get 
			{
				return ((string)(this[this.m_dataTableMedium.DataColumnMedium]));
			}
			set 
			{
				this[this.m_dataTableMedium.DataColumnMedium] = value;
			}
		}
		
		public string Beschreibung
		{
			get 
			{
				return ((string)(this[this.m_dataTableMedium.DataColumnBeschreibung]));
			}
			set 
			{
				this[this.m_dataTableMedium.DataColumnBeschreibung] = value;
			}
		}
		
		public string Guid
		{
			get 
			{
				return ((string)(this[this.m_dataTableMedium.DataColumnGuid]));
			}
			set 
			{
				this[this.m_dataTableMedium.DataColumnGuid] = value;
			}
		}
		
		public System.DateTime TimeStamp
		{
			get 
			{
				return ((System.DateTime)(this[this.m_dataTableMedium.DataColumnTimestamp]));
			}
			set 
			{
				this[this.m_dataTableMedium.DataColumnTimestamp] = value;
			}
		}

		#endregion

		#region MethodsPrivate

		internal CDataRowMedium(DataRowBuilder dataRowBuilder) : base(dataRowBuilder) 
		{
			this.m_dataTableMedium = ((CDataTableMedium)(this.Table));
		}

		#endregion

	}

	#endregion

	#region Class DataRowMediumChangeEvent

	public class MediumChangeEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private CDataRowMedium m_row;
		private System.Data.DataRowAction m_dataRowAction;

		#endregion

		#region Properties

		public CDataRowMedium Row
		{
			get {return this.m_row;}
		}

		public DataRowAction DataRowAction
		{
			get {return this.m_dataRowAction;}
		}

		#endregion

		#region MethodsPublic

		public MediumChangeEventArgs(CDataRowMedium row,DataRowAction dataRowAction)
		{
			this.m_row = row;
			this.m_dataRowAction = dataRowAction;
		}

		#endregion
	}

	#endregion
}
