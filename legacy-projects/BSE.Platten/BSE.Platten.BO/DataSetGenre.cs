using System;
using System.Data;

namespace BSE.Platten.BO
{
	#region Class CDataSetGenre
	/// <summary>
	/// Zusammendfassende Beschreibung für C_DataSetMedium.
	/// </summary>
    [Serializable]
    public class CDataSetGenre : DataSet
	{
        #region Konstanten

        public const string SOURCETABLE = "Genre";

        #endregion
        #region FieldsPrivate

		private CDataTableGenre m_dataTableGenre;

		#endregion

		#region Properties

		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CDataTableGenre Genre
		{
			get { return this.m_dataTableGenre; }
		}

		#endregion
		
		#region MethodsPublic

		public CDataSetGenre()
		{
			this.InitClass();
		}

		#endregion

		#region MethodsPrivate

		private void InitClass()
		{
			this.DataSetName = "DataSetMedium";
			this.Namespace = "";
			this.m_dataTableGenre = new CDataTableGenre();
			this.Tables.Add(this.m_dataTableGenre);
		}

		#endregion
	}

	#endregion

	#region Class CDataTableGenre

	public class CDataTableGenre : DataTable,System.Collections.IEnumerable
	{
		#region EventsPublic

		public event EventHandler<DataRowGenreChangeEventArgs> GenreChanged;
        public event EventHandler<DataRowGenreChangeEventArgs> GenreChanging;

		#endregion
		
		#region FieldsPrivate

		private DataColumn m_dataColumnGenreId;
		private DataColumn m_dataColumnGenre;
		private DataColumn m_dataColumnGuid;
		private DataColumn m_dataColumnTimestamp;

		#endregion

		#region Properties

		public int Count 
		{
			get { return this.Rows.Count; }
		}

		internal DataColumn DataColumnGenreId
		{
			get { return this.m_dataColumnGenreId; }
		}
		
		public DataColumn DataColumnGenre
		{
			get { return this.m_dataColumnGenre; }
		}
		
		internal DataColumn DataColumnGuid
		{
			get { return this.m_dataColumnGuid; }
		}

		internal DataColumn DataColumnTimestamp
		{
			get { return this.m_dataColumnTimestamp; }
		}

		public CDataRowGenre this[int iIndex]
		{
			get { return ((CDataRowGenre)(base.Rows[iIndex]));}
		}

		#endregion
		
		#region MethodsPublic

		public System.Collections.IEnumerator GetEnumerator() 
		{
			return base.Rows.GetEnumerator();
		}
		
		public void AddDataRowGenre(CDataRowGenre row) 
		{
			this.Rows.Add(row);
		}
		
		public CDataRowGenre FindByGenreId(int iGenreId) 
		{
			return ((CDataRowGenre)(this.Rows.Find(new Object[] {iGenreId})));
		}
		
		public new CDataRowGenre NewRow() 
		{
			return ((CDataRowGenre)(this.NewRow()));
		}

		#endregion

		#region MethodsProtected

		protected override System.Type GetRowType() 
		{
			return typeof(CDataRowGenre);
		}
		
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder) 
		{
			// We need to ensure that all Rows in the tabled are typed rows.
			// Table calls newRow whenever it needs to create a row.
			// So the following conditions are covered by Row newRow(Record record)
			// * Cursor calls table.addRecord(record) 
			// * table.addRow(object[] values) calls newRow(record)    
            return new CDataRowGenre(builder);
		}
		
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			if (((this.GenreChanged) != (null)))
			{
				this.GenreChanged(this, new DataRowGenreChangeEventArgs(((CDataRowGenre)(e.Row)), e.Action));
			}
			base.OnRowChanged(e);
		}
		
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			if (((this.GenreChanging) != (null)))
			{
				this.GenreChanging(this, new DataRowGenreChangeEventArgs(((CDataRowGenre)(e.Row)), e.Action));
			}
			base.OnRowChanging(e);
		}

		#endregion

		#region MethodsPrivate
		
		internal CDataTableGenre() : base(CDataSetGenre.SOURCETABLE) 
		{
			this.InitClass();
		}

		private void InitClass() 
		{
			this.m_dataColumnGenreId = new DataColumn("GenreId", typeof(int), "", MappingType.Element);
			this.m_dataColumnGenreId.AllowDBNull = true;
			this.m_dataColumnGenreId.Unique = true;
			this.m_dataColumnGenreId.DefaultValue = -1;
			this.Columns.Add(this.m_dataColumnGenreId);
			this.m_dataColumnGenre = new DataColumn("Genre", typeof(string), "", MappingType.Element);
            this.m_dataColumnGenre.MaxLength = 100;
            this.Columns.Add(this.m_dataColumnGenre);
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

	#region Class CDataRowGenre

	public class CDataRowGenre : DataRow
	{
		#region FieldsPrivate
		
		private CDataTableGenre m_dataTableGenre;

		#endregion

		#region Properties

		public int GenreId
		{
			get 
			{
				return ((int)(this[this.m_dataTableGenre.DataColumnGenreId]));
			}
			set 
			{
				this[this.m_dataTableGenre.DataColumnGenreId] = value;
			}
		}
		
		public string Genre
		{
			get 
			{
				return ((string)(this[this.m_dataTableGenre.DataColumnGenre]));
			}
			set 
			{
				this[this.m_dataTableGenre.DataColumnGenre] = value;
			}
		}

		public string Guid
		{
			get 
			{
				return ((string)(this[this.m_dataTableGenre.DataColumnGuid]));
			}
			set 
			{
				this[this.m_dataTableGenre.DataColumnGuid] = value;
			}
		}
		
		public System.DateTime TimeStamp
		{
			get 
			{
				return ((System.DateTime)(this[this.m_dataTableGenre.DataColumnTimestamp]));
			}
			set 
			{
				this[this.m_dataTableGenre.DataColumnTimestamp] = value;
			}
		}

		#endregion

		#region MethodsPrivate

		internal CDataRowGenre(DataRowBuilder dataRowBuilder) : base(dataRowBuilder) 
		{
			this.m_dataTableGenre = ((CDataTableGenre)(this.Table));
		}

		#endregion
	}

	#endregion

	#region Class DataRowGenreChangeEvent

	public class DataRowGenreChangeEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private CDataRowGenre m_row;
		private System.Data.DataRowAction m_dataRowAction;

		#endregion

		#region Properties

		public CDataRowGenre Row
		{
			get {return this.m_row;}
		}

		public DataRowAction Action
		{
			get {return this.m_dataRowAction;}
		}

		#endregion

		#region MethodsPublic

		public DataRowGenreChangeEventArgs(CDataRowGenre row,DataRowAction dataRowAction)
		{
			this.m_row = row;
			this.m_dataRowAction = dataRowAction;
		}

		#endregion
	}

	#endregion
}
