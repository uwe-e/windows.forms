using System;
using System.Data;

namespace BSE.Platten.BO
{
	#region Class CDataSetInterpret
	/// <summary>
	/// Zusammendfassende Beschreibung für C_DataSetMedium.
	/// </summary>
	public class CDataSetInterpret : DataSet
	{
        #region Konstanten

        public const string SOURCETABLE = "Interpreten";

        #endregion
        
        #region FieldsPrivate

		private CDataTableInterpret m_dataTableInterpret;

		#endregion

		#region Properties
		
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public CDataTableInterpret Interpret
		{
			get 
			{
				return this.m_dataTableInterpret;
			}
		}

		#endregion
		
		#region MethodsPublic

		public CDataSetInterpret()
		{
			this.InitClass();
		}

		#endregion

		#region MethodsPrivate

		private void InitClass()
		{
			this.DataSetName = "DataSetInterpret";
			this.Namespace = "";
			this.m_dataTableInterpret = new CDataTableInterpret();
			this.Tables.Add(this.m_dataTableInterpret);
		}

		#endregion
	}

	#endregion

	#region Class CDataTableInterpret

	public class CDataTableInterpret : DataTable,System.Collections.IEnumerable
	{
		#region EventsPublic

		public event EventHandler<InterpretChangeEventArgs> InterpretChanged;
        public event EventHandler<InterpretChangeEventArgs> InterpretChanging;

		#endregion
		
		#region FieldsPrivate

		private DataColumn m_dataColumnInterpretId;
		private DataColumn m_dataColumnInterpret;
		private DataColumn m_dataColumnInterpretLang;
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

		internal DataColumn DataColumnInterpretId 
		{
			get 
			{
				return this.m_dataColumnInterpretId;
			}
		}
		
		public DataColumn DataColumnInterpret
		{
			get 
			{
				return this.m_dataColumnInterpret;
			}
		}

        public DataColumn DataColumnInterpretLang
		{
			get 
			{
				return this.m_dataColumnInterpretLang;
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

		public CDataRowInterpret this[int iIndex]
		{
			get { return ((CDataRowInterpret)(base.Rows[iIndex]));}
		}

		#endregion
		
		#region MethodsPublic

		public System.Collections.IEnumerator GetEnumerator() 
		{
			return this.Rows.GetEnumerator();
		}
		
		public void AddDataRowInterpreten(CDataRowInterpret row) 
		{
			this.Rows.Add(row);
		}
		
		public CDataRowInterpret FindByInterpretId(int iInterpretId) 
		{
			return ((CDataRowInterpret)(this.Rows.Find(new Object[] {iInterpretId})));
		}
		
		public new CDataRowInterpret NewRow() 
		{
			return ((CDataRowInterpret)(this.NewRow()));
		}

		#endregion

		#region MethodsProtected

		protected override System.Type GetRowType() 
		{
			return typeof(CDataRowInterpret);
		}
		
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder) 
		{
			// We need to ensure that all Rows in the tabled are typed rows.
			// Table calls newRow whenever it needs to create a row.
			// So the following conditions are covered by Row newRow(Record record)
			// * Cursor calls table.addRecord(record) 
			// * table.addRow(object[] values) calls newRow(record)    
            return new CDataRowInterpret(builder);
		}
		
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
            if (((this.InterpretChanged) != (null)))
			{
				this.InterpretChanged(this, new InterpretChangeEventArgs(((CDataRowInterpret)(e.Row)), e.Action));
			}
		}

		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
            if (((this.InterpretChanging) != (null)))
			{
				this.InterpretChanging(this, new InterpretChangeEventArgs(((CDataRowInterpret)(e.Row)), e.Action));
			}
		}

		#endregion

		#region MethodsPrivate
		
		internal CDataTableInterpret() : base(CDataSetInterpret.SOURCETABLE) 
		{
			this.InitClass();
		}

		private void InitClass() 
		{
			this.m_dataColumnInterpretId = new DataColumn("InterpretId", typeof(int), "", MappingType.Element);
			this.m_dataColumnInterpretId.AllowDBNull = false;
			this.m_dataColumnInterpretId.Unique = true;
			this.m_dataColumnInterpretId.DefaultValue = -1;
			this.Columns.Add(this.m_dataColumnInterpretId);
			this.m_dataColumnInterpret = new DataColumn("Interpret", typeof(string), "", MappingType.Element);
            this.m_dataColumnInterpret.MaxLength = 60;
            this.m_dataColumnInterpret.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnInterpret);
			this.m_dataColumnInterpretLang = new DataColumn("Interpret_Lang", typeof(string), "", MappingType.Element);
            this.m_dataColumnInterpretLang.MaxLength = 60;
            this.Columns.Add(this.m_dataColumnInterpretLang);
			this.m_dataColumnGuid = new DataColumn("Guid", typeof(string), "", MappingType.Element);
            this.m_dataColumnGuid.AllowDBNull = false;
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

	#region Class CDataRowInterpret

	public class CDataRowInterpret : DataRow
	{
		
		#region FieldsPrivate
		
		private CDataTableInterpret m_dataTableInterpret;

		#endregion

		#region Properties

		public int InterpretId
		{
			get 
			{
				return ((int)(this[this.m_dataTableInterpret.DataColumnInterpretId]));
			}
			set 
			{
				this[this.m_dataTableInterpret.DataColumnInterpretId] = value;
			}
		}
		
		public string Interpret
		{
			get 
			{
                try
                {
                    return ((string)(this[this.m_dataTableInterpret.DataColumnInterpret]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
			}
			set 
			{
				this[this.m_dataTableInterpret.DataColumnInterpret] = value;
			}
		}
		
		public string InterpretLang
		{
			get 
			{
				return ((string)(this[this.m_dataTableInterpret.DataColumnInterpretLang]));
			}
			set 
			{
				this[this.m_dataTableInterpret.DataColumnInterpretLang] = value;
			}
		}

		public string Guid
		{
			get 
			{
                try
                {
                    return ((string)(this[this.m_dataTableInterpret.DataColumnGuid]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
			}
			set 
			{
				this[this.m_dataTableInterpret.DataColumnGuid] = value;
			}
		}
		
		public System.DateTime TimeStamp
		{
			get 
			{
				return ((System.DateTime)(this[this.m_dataTableInterpret.DataColumnTimestamp]));
			}
			set 
			{
				this[this.m_dataTableInterpret.DataColumnTimestamp] = value;
			}
		}

        public bool IsInterpretNull()
        {
            return this.IsNull(this.m_dataTableInterpret.DataColumnInterpret);
        }

        public void SetInterpretNull()
        {
            this[this.m_dataTableInterpret.DataColumnInterpret] = Convert.DBNull;
        }

        public bool IsGuidNull()
        {
            return this.IsNull(this.m_dataTableInterpret.DataColumnGuid);
        }

        public void SetGuidNull()
        {
            this[this.m_dataTableInterpret.DataColumnGuid] = Convert.DBNull;
        }

		#endregion

		#region MethodsPrivate

		internal CDataRowInterpret(DataRowBuilder dataRowBuilder) : base(dataRowBuilder) 
		{
			this.m_dataTableInterpret = ((CDataTableInterpret)(base.Table));
		}

		#endregion

	}

	#endregion

	#region Class CInterpretChangeEvent

	public class InterpretChangeEventArgs : EventArgs
	{
		#region FieldsPrivate
		
		private CDataRowInterpret m_row;
		private System.Data.DataRowAction m_dataRowAction;

		#endregion

		#region Properties

		public CDataRowInterpret Row
		{
			get {return this.m_row;}
		}

		public DataRowAction DataRowAction
		{
			get {return this.m_dataRowAction;}
		}

		#endregion

		#region Constructor

		public InterpretChangeEventArgs(CDataRowInterpret row,DataRowAction dataRowAction)
		{
			this.m_row = row;
			this.m_dataRowAction = dataRowAction;
		}

		#endregion
	}

	#endregion
}
