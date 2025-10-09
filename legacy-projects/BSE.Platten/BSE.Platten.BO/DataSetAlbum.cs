using System;
using System.Collections;
using System.Data;

namespace BSE.Platten.BO
{
    #region Class CDataSetAlbum

    [Serializable]
    public class CDataSetAlbum : DataSet
    {
        #region Konstanten

        public const string DATARELATIONNAME = "AlbumTracks";

        #endregion

        #region FieldsPrivate

        private CDataTableAlbum m_dataTableAlbum;
        private CDataTableTracks m_dataTableTracks;
        private DataRelation m_dataRelationAlbumTracks;

        #endregion

        #region Properties

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CDataTableAlbum Album
        {
            get
            {
                return this.m_dataTableAlbum;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CDataTableTracks Tracks
        {
            get
            {
                return this.m_dataTableTracks;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public DataRelation DataRelation
        {
            get
            {
                return this.m_dataRelationAlbumTracks;
            }
        }

        #endregion

        #region MethodsPublic

        public CDataSetAlbum()
        {
            this.InitClass();
        }

        #endregion
        
        #region MethodsProtected

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        #endregion

        #region MethodsPrivate

        private void InitClass()
        {
            this.DataSetName = "DataSetAlbum";
            this.Namespace = "";
            this.m_dataTableAlbum = new CDataTableAlbum();
            this.Tables.Add(this.m_dataTableAlbum);
            this.m_dataTableTracks = new CDataTableTracks();
            this.Tables.Add(this.m_dataTableTracks);
            this.m_dataTableTracks.Constraints.Add(
                new System.Data.ForeignKeyConstraint(DATARELATIONNAME,
                new DataColumn[] { this.m_dataTableAlbum.DataColumnTitelId },
                new DataColumn[] { this.m_dataTableTracks.DataColumnTitelId }));
            this.m_dataRelationAlbumTracks = new DataRelation(
                DATARELATIONNAME,
                new DataColumn[] { this.m_dataTableAlbum.DataColumnTitelId },
                new DataColumn[] { this.m_dataTableTracks.DataColumnTitelId },
                false);
            this.Relations.Add(this.m_dataRelationAlbumTracks);
        }

        #endregion
    }

    #endregion

    #region Class CDataTableAlbum

    public class CDataTableAlbum : DataTable, System.Collections.IEnumerable
    {
        #region Events

        public event EventHandler<AlbumChangeEventArgs> AlbumChanged;
        public event EventHandler<AlbumChangeEventArgs> AlbumChanging;

        #endregion

        #region FieldsPrivate

        private DataColumn m_dataColumnTitelId;
        private DataColumn m_dataColumnInterpretId;
        private DataColumn m_dataColumnInterpret;
        private DataColumn m_dataColumnTitel;
        private DataColumn m_dataColumnErschDatum;
        private DataColumn m_dataColumnMediumId;
        private DataColumn m_dataColumnGenreId;
        private DataColumn m_dataColumnMp3Tag;
        private DataColumn m_dataColumnGuid;
        private DataColumn m_dataColumnPictureFormat;
        private DataColumn m_dataColumnCover;
        private DataColumn m_dataColumnThumbNail;
        private DataColumn m_dataColumnErstellDatum;
        private DataColumn m_dataColumnErstelltDurch;
        private DataColumn m_dataColumnMutationDatum;
        private DataColumn m_dataColumnMutationDurch;
        private DataColumn m_dataColumnTimestamp;

        #endregion

        #region Properties

        public int Count
        {
            get { return this.Rows.Count; }
        }

        internal DataColumn DataColumnTitelId
        {
            get
            {
                return this.m_dataColumnTitelId;
            }
        }

        internal DataColumn DataColumnInterpretId
        {
            get
            {
                return this.m_dataColumnInterpretId;
            }
        }

        internal DataColumn DataColumnInterpret
        {
            get
            {
                return this.m_dataColumnInterpret;
            }
        }

        public DataColumn DataColumnTitel
        {
            get
            {
                return this.m_dataColumnTitel;
            }
        }

        internal DataColumn DataColumnErschDatum
        {
            get
            {
                return this.m_dataColumnErschDatum;
            }
        }

        internal DataColumn DataColumnMediumId
        {
            get
            {
                return this.m_dataColumnMediumId;
            }
        }

        internal DataColumn DataColumnGenreId
        {
            get
            {
                return this.m_dataColumnGenreId;
            }
        }

        internal DataColumn DataColumnGuid
        {
            get
            {
                return this.m_dataColumnGuid;
            }
        }

        internal DataColumn DataColumnThumbNail
        {
            get
            {
                return this.m_dataColumnThumbNail;
            }
        }

        internal DataColumn DataColumnPictureFormat
        {
            get
            {
                return this.m_dataColumnPictureFormat;
            }
        }

        internal DataColumn DataColumnCover
        {
            get
            {
                return this.m_dataColumnCover;
            }
        }

        internal DataColumn DataColumnErstellDatum
        {
            get
            {
                return this.m_dataColumnErstellDatum;
            }
        }

        internal DataColumn DataColumnErstelltDurch
        {
            get
            {
                return this.m_dataColumnErstelltDurch;
            }
        }

        internal DataColumn DataColumnMutationDatum
        {
            get
            {
                return this.m_dataColumnMutationDatum;
            }
        }

        internal DataColumn DataColumnMutationDurch
        {
            get
            {
                return this.m_dataColumnMutationDurch;
            }
        }

        internal DataColumn DataColumnTimestamp
        {
            get
            {
                return this.m_dataColumnTimestamp;
            }
        }

        public CDataRowAlbum this[int index]
        {
            get { return ((CDataRowAlbum)(this.Rows[index])); }
        }

        #endregion

        #region MethodsPublic

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this.Rows.GetEnumerator();
        }

        public void AddRow(CDataRowAlbum row)
        {
            this.Rows.Add(row);
        }

        public CDataRowAlbum FindByTitelId(int iTitelId)
        {
            return ((CDataRowAlbum)(this.Rows.Find(new Object[] { iTitelId })));
        }

        public new CDataRowAlbum NewRow()
        {
            return ((CDataRowAlbum)(base.NewRow()));
        }

        #endregion

        #region MethodsProtected

        protected override System.Type GetRowType()
        {
            return typeof(CDataRowAlbum);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            // We need to ensure that all Rows in the tabled are typed rows.
            // Table calls newRow whenever it needs to create a row.
            // So the following conditions are covered by Row newRow(Record record)
            // * Cursor calls table.addRecord(record) 
            // * table.addRow(object[] values) calls newRow(record)    
            return new CDataRowAlbum(builder);
        }

        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.AlbumChanged != null)
            {
                this.AlbumChanged(this, new AlbumChangeEventArgs(((CDataRowAlbum)(e.Row)), e.Action));
            }
        }

        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.AlbumChanging != null)
            {
                this.AlbumChanging(this, new AlbumChangeEventArgs(((CDataRowAlbum)(e.Row)), e.Action));
            }
        }

        #endregion

        #region MethodsPrivate

        internal CDataTableAlbum()
            : base("Album")
        {
                this.InitClass();
        }

        private void InitClass()
        {
            this.m_dataColumnTitelId = new DataColumn("TitelId", typeof(int), "", MappingType.Element);
            this.m_dataColumnTitelId.AllowDBNull = false;
            this.m_dataColumnTitelId.Unique = true;
            this.m_dataColumnTitelId.DefaultValue = -1;
            this.Columns.Add(this.m_dataColumnTitelId);
            this.m_dataColumnInterpretId = new DataColumn("InterpretId", typeof(int), "", MappingType.Element);
            this.m_dataColumnInterpretId.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnInterpretId);
            this.m_dataColumnInterpret = new DataColumn("Interpret", typeof(string), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnInterpret);
            this.m_dataColumnTitel = new DataColumn("Titel", typeof(string), "", MappingType.Element);
            this.m_dataColumnTitel.MaxLength = 60;
            this.m_dataColumnTitel.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnTitel);
            this.m_dataColumnErschDatum = new DataColumn("ErschDatum", typeof(int), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnErschDatum);
            this.m_dataColumnMediumId = new DataColumn("MediumId", typeof(int), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnMediumId);
            this.m_dataColumnGenreId = new DataColumn("GenreId", typeof(int), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnGenreId);
            this.m_dataColumnMp3Tag = new DataColumn("Mp3Tag", typeof(int), "", MappingType.Element);
            this.m_dataColumnMp3Tag.DefaultValue = 0;
            this.m_dataColumnMp3Tag.AllowDBNull = true;
            this.Columns.Add(this.m_dataColumnMp3Tag);
            this.m_dataColumnGuid = new DataColumn("Guid", typeof(string), "", MappingType.Element);
            this.m_dataColumnGuid.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnGuid);
            this.m_dataColumnPictureFormat = new DataColumn("PictureFormat", typeof(string), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnPictureFormat);
            this.m_dataColumnCover = new DataColumn("Cover", typeof(System.Byte[]), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnCover);
            this.m_dataColumnThumbNail = new DataColumn("ThumbNail", typeof(System.Byte[]), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnThumbNail);
            this.m_dataColumnErstellDatum = new DataColumn("ErstellDatum", typeof(System.DateTime), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnErstellDatum);
            this.m_dataColumnErstelltDurch = new DataColumn("ErstellerNm", typeof(System.String), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnErstelltDurch);
            this.m_dataColumnMutationDatum = new DataColumn("MutationDatum", typeof(System.DateTime), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnMutationDatum);
            this.m_dataColumnMutationDurch = new DataColumn("MutationNm", typeof(System.String), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnMutationDurch);
            this.m_dataColumnTimestamp = new DataColumn("Timestamp", typeof(DateTime), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnTimestamp);
            //Beim Merge können Rows nur zusammengeführt werden, wenn sie eine eindeutige
            //Beziehung haben. Diese Beziehung ist der Guid Wert
            this.PrimaryKey = new DataColumn[] { this.m_dataColumnGuid };
        }

        #endregion
    }

    #endregion

    #region Class CDataRowAlbum

    public class CDataRowAlbum : DataRow, ICloneable
    {
        #region FieldsPrivate

        private CDataTableAlbum m_dataTableAlbum;

        #endregion

        #region Properties

        public int TitelId
        {
            get
            {
                return ((int)(this[this.m_dataTableAlbum.DataColumnTitelId]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnTitelId] = value;
            }
        }

        public int InterpretId
        {
            get
            {
                return ((int)(this[this.m_dataTableAlbum.DataColumnInterpretId]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnInterpretId] = value;
            }
        }

        public string Interpret
        {
            get
            {
                return ((string)(this[this.m_dataTableAlbum.DataColumnInterpret]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnInterpret] = value;
            }
        }
        
        public string Titel
        {
            get
            {
                try
                {
                    return ((string)(this[this.m_dataTableAlbum.DataColumnTitel]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnTitel] = value;
            }
        }

        public int ErschDatum
        {
            get
            {
                return ((int)(this[this.m_dataTableAlbum.DataColumnErschDatum]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnErschDatum] = value;
            }
        }

        public int MediumId
        {
            get
            {
                try
                {
                    return ((int)(this[this.m_dataTableAlbum.DataColumnMediumId]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnMediumId] = value;
            }
        }

        public int GenreId
        {
            get
            {
                try
                {
                    return ((int)(this[this.m_dataTableAlbum.DataColumnGenreId]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnGenreId] = value;
            }
        }

        public string Guid
        {
            get
            {
                return ((string)(this[this.m_dataTableAlbum.DataColumnGuid]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnGuid] = value;
            }
        }

        public string PictureFormat
        {
            get
            {
                try
                {
                    return ((string)(this[this.m_dataTableAlbum.DataColumnPictureFormat]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnPictureFormat] = value;
            }
        }

        public System.Byte[] Cover
        {
            get
            {
                try
                {
                    return ((System.Byte[])(this[this.m_dataTableAlbum.DataColumnCover]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnCover] = value;
            }
        }

        public System.Byte[] ThumbNail
        {
            get
            {
                try
                {
                    return ((System.Byte[])(this[this.m_dataTableAlbum.DataColumnThumbNail]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnThumbNail] = value;
            }
        }

        public System.DateTime ErstellDatum
        {
            get
            {
                return ((DateTime)(this[this.m_dataTableAlbum.DataColumnErstellDatum]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnErstellDatum] = value;
            }
        }

        public System.String ErstelltDurch
        {
            get
            {
                return ((string)(this[this.m_dataTableAlbum.DataColumnErstelltDurch]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnErstelltDurch] = value;
            }
        }

        public System.DateTime MutationDatum
        {
            get
            {
                return ((DateTime)(this[this.m_dataTableAlbum.DataColumnMutationDatum]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnMutationDatum] = value;
            }
        }

        public System.String MutationDurch
        {
            get
            {
                return ((string)(this[this.m_dataTableAlbum.DataColumnMutationDurch]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnMutationDurch] = value;
            }
        }

        public System.DateTime TimeStamp
        {
            get
            {
                return ((System.DateTime)(this[this.m_dataTableAlbum.DataColumnTimestamp]));
            }
            set
            {
                this[this.m_dataTableAlbum.DataColumnTimestamp] = value;
            }
        }

        public CDataRowTracks[] GetTrackRows()
        {
            return ((CDataRowTracks[])(this.GetChildRows(this.Table.ChildRelations["AlbumTracks"])));
        }

        #endregion

        #region MethodsPublic

        public bool IsTitelNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnTitel);
        }

        public bool IsErschDatumNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnErschDatum);
        }

        public void SetErschDatumNull()
        {
            this[this.m_dataTableAlbum.DataColumnErschDatum] = Convert.DBNull;
        }

        public bool IsMediumIdNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnMediumId);
        }

        public void SetMediumIdNull()
        {
            this[this.m_dataTableAlbum.DataColumnMediumId] = Convert.DBNull;
        }

        public bool IsGenreIdNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnGenreId);
        }

        public void SetGenreIdNull()
        {
            this[this.m_dataTableAlbum.DataColumnGenreId] = Convert.DBNull;
        }

        public bool IsPictureFormatNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnPictureFormat);
        }

        public void SetPictureFormatNull()
        {
            this[this.m_dataTableAlbum.DataColumnPictureFormat] = Convert.DBNull;
        }

        public bool IsCoverNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnCover);
        }

        public void SetCoverNull()
        {
            this[this.m_dataTableAlbum.DataColumnCover] = Convert.DBNull;
        }

        public bool IsThumbNailNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnThumbNail);
        }

        public void SetThumbNailNull()
        {
            this[this.m_dataTableAlbum.DataColumnThumbNail] = Convert.DBNull;
        }

        public bool IsErstelltDurchNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnErstelltDurch);
        }

        public void SetErstelltDurchNull()
        {
            this[this.m_dataTableAlbum.DataColumnErstelltDurch] = Convert.DBNull;
        }

        public bool IsMutationDatumNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnMutationDatum);
        }

        public void SetMutationDatumNull()
        {
            this[this.m_dataTableAlbum.DataColumnMutationDatum] = Convert.DBNull;
        }

        public bool IsMutationDurchNull()
        {
            return this.IsNull(this.m_dataTableAlbum.DataColumnMutationDurch);
        }

        public void SetMutationDurchNull()
        {
            this[this.m_dataTableAlbum.DataColumnMutationDurch] = Convert.DBNull;
        }

        public object Clone()
        {
            CDataRowAlbum dataRowAlbum = this.m_dataTableAlbum.NewRow();
            dataRowAlbum.ItemArray = (object[])this.ItemArray.Clone();
            return dataRowAlbum;
        }

        public virtual bool Equals(CDataRowAlbum dataRowAlbum)
        {
            if (dataRowAlbum == null)
            {
                return false;
            }

            for (int i = 0; i < dataRowAlbum.ItemArray.Length; i++)
            {
                if (this.ItemArray[i].Equals(dataRowAlbum.ItemArray[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region MethodsPrivate

        internal CDataRowAlbum(DataRowBuilder dataRowBuilder)
            : base(dataRowBuilder)
        {
            this.m_dataTableAlbum = ((CDataTableAlbum)(this.Table));
        }

        #endregion
    }

    #endregion

    #region Class CAlbumChangeEventArgs
	
    public class AlbumChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private CDataRowAlbum m_row;
        private System.Data.DataRowAction m_dataRowAction;

        #endregion

        #region Properties

        public CDataRowAlbum Row
        {
            get { return this.m_row; }
        }

        public DataRowAction Action
        {
            get { return this.m_dataRowAction; }
        }

        #endregion

        #region MethodsPublic

        public AlbumChangeEventArgs(CDataRowAlbum row, DataRowAction dataRowAction)
        {
            this.m_row = row;
            this.m_dataRowAction = dataRowAction;
        }

        #endregion
    }

    #endregion

    #region Class CDataTableTracks

    public class CDataTableTracks : DataTable, System.Collections.IEnumerable
    {
        #region Events

        public event EventHandler<TrackChangeEventArgs> TrackChanged;
        public event EventHandler<TrackChangeEventArgs> TrackChanging;
        public event EventHandler<TrackChangeEventArgs> TrackDeleted;
        public event EventHandler<TrackChangeEventArgs> TrackDeleting;

        #endregion

        #region FieldsPrivate

        private DataColumn m_dataColumnLiedId;
        private DataColumn m_dataColumnTitelId;
        private DataColumn m_dataColumnTrack;
        private DataColumn m_dataColumnLied;
        private DataColumn m_dataColumnDauer;
        private DataColumn m_dataColumnLiedpfad;
        private DataColumn m_dataColumnGuid;
        private DataColumn m_dataColumnTimestamp;

        #endregion

        #region Properties

        public int Count
        {
            get { return this.Rows.Count; }
        }

        internal DataColumn DataColumnLiedId
        {
            get { return this.m_dataColumnLiedId; }
        }

        internal DataColumn DataColumnTitelId
        {
            get { return this.m_dataColumnTitelId; }
        }

        internal DataColumn DataColumnTrack
        {
            get { return this.m_dataColumnTrack; }
        }

        internal DataColumn DataColumnLied
        {
            get { return this.m_dataColumnLied; }
        }

        internal DataColumn DataColumnDauer
        {
            get { return this.m_dataColumnDauer; }
        }

        internal DataColumn DataColumnLiedpfad
        {
            get { return this.m_dataColumnLiedpfad; }
        }

        internal DataColumn DataColumnGuid
        {
            get { return this.m_dataColumnGuid; }
        }

        internal DataColumn DataColumnTimestamp
        {
            get { return this.m_dataColumnTimestamp; }
        }

        public CDataRowTracks this[int iIndex]
        {
            get { return ((CDataRowTracks)(this.Rows[iIndex])); }
        }

        #endregion

        #region MethodsPublic

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this.Rows.GetEnumerator();
        }

        public void AddRow(CDataRowTracks row)
        {
            this.Rows.Add(row);
        }

        public CDataRowTracks FindByLiedId(int iLiedId)
        {
            return ((CDataRowTracks)(this.Rows.Find(new Object[] { iLiedId })));
        }

        public new CDataRowTracks NewRow()
        {
            return ((CDataRowTracks)(base.NewRow()));
        }

        public void Remove(CDataRowTracks row)
        {
            this.Rows.Remove(row);
        }

        #endregion

        #region MethodsProtected

        protected override System.Type GetRowType()
        {
            return typeof(CDataRowTracks);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            // We need to ensure that all Rows in the tabled are typed rows.
            // Table calls newRow whenever it needs to create a row.
            // So the following conditions are covered by Row newRow(Record record)
            // * Cursor calls table.addRecord(record) 
            // * table.addRow(object[] values) calls newRow(record)    
            return new CDataRowTracks(builder);
        }

        protected override void OnRowChanged(DataRowChangeEventArgs e)
        {
            base.OnRowChanged(e);
            if (this.TrackChanged != null)
            {
                this.TrackChanged(this, new TrackChangeEventArgs(((CDataRowTracks)(e.Row)), e.Action));
            }
        }

        protected override void OnRowChanging(DataRowChangeEventArgs e)
        {
            base.OnRowChanging(e);
            if (this.TrackChanging != null)
            {
                this.TrackChanging(this, new TrackChangeEventArgs(((CDataRowTracks)(e.Row)), e.Action));
            }
        }

        protected override void OnRowDeleted(DataRowChangeEventArgs e)
        {
            base.OnRowDeleted(e);
            if (this.TrackDeleted != null)
            {
                this.TrackDeleted(this, new TrackChangeEventArgs(((CDataRowTracks)(e.Row)), e.Action));
            }
        }

        protected override void OnRowDeleting(DataRowChangeEventArgs e)
        {
            base.OnRowDeleting(e);  
            if (this.TrackDeleting != null)
            {
                this.TrackDeleting(this, new TrackChangeEventArgs(((CDataRowTracks)(e.Row)), e.Action));
            }
        }

        #endregion

        #region MethodsPrivate

        internal CDataTableTracks()
            : base("Tracks")
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.m_dataColumnLiedId = new DataColumn("LiedID", typeof(int), "", MappingType.Element);
            this.m_dataColumnLiedId.AutoIncrement = true;
            this.m_dataColumnLiedId.AllowDBNull = false;
            this.m_dataColumnLiedId.AutoIncrementSeed = 100000;
            this.m_dataColumnLiedId.AutoIncrementStep = 1;
            this.m_dataColumnLiedId.Unique = true;
            this.Columns.Add(this.m_dataColumnLiedId);
            this.m_dataColumnTitelId = new DataColumn("TitelId", typeof(int), "", MappingType.Element);
            this.m_dataColumnTitelId.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnTitelId);
            this.m_dataColumnTrack = new DataColumn("Track", typeof(int), "", MappingType.Element);
            this.m_dataColumnTrack.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnTrack);
            this.m_dataColumnLied = new DataColumn("Lied", typeof(string), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnLied);
            this.m_dataColumnDauer = new DataColumn("Dauer", typeof(System.DateTime), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnDauer);
            this.m_dataColumnLiedpfad = new DataColumn("Liedpfad", typeof(string), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnLiedpfad);
            this.m_dataColumnGuid = new DataColumn("Guid", typeof(string), "", MappingType.Element);
            this.m_dataColumnGuid.AllowDBNull = false;
            this.Columns.Add(this.m_dataColumnGuid);
            this.m_dataColumnTimestamp = new DataColumn("Timestamp", typeof(System.DateTime), "", MappingType.Element);
            this.Columns.Add(this.m_dataColumnTimestamp);
            this.PrimaryKey = new DataColumn[] { this.m_dataColumnGuid };
        }

        #endregion
    }

    #endregion

    #region Class CDataRowTracks

    public class CDataRowTracks : DataRow, ICloneable
    {
        #region FieldsPrivate

        private CDataTableTracks m_dataTableTracks;

        #endregion

        #region Properties

        public int LiedId
        {
            get
            {
                return ((int)(this[this.m_dataTableTracks.DataColumnLiedId]));
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnLiedId] = value;
            }
        }

        public int TitelId
        {
            get
            {
                return ((int)(this[this.m_dataTableTracks.DataColumnTitelId]));
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnTitelId] = value;
            }
        }

        public int Track
        {
            get
            {
                try
                {
                    return ((int)(this[this.m_dataTableTracks.DataColumnTrack]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnTrack] = value;
            }
        }

        public string Lied
        {
            get
            {
                try
                {
                    return ((string)(this[this.m_dataTableTracks.DataColumnLied]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnLied] = value;
            }
        }

        public System.DateTime Dauer
        {
            get
            {
                try
                {
                    return ((System.DateTime)(this[this.m_dataTableTracks.DataColumnDauer]));
                }
                catch (InvalidCastException e)
                {
                    throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                }
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnDauer] = value;
            }
        }

        public string Liedpfad
        {
            get
            {
                try
                {
                    return ((string)(this[this.m_dataTableTracks.DataColumnLiedpfad]));
                }
                catch (InvalidCastException)
                {
                    return null;
                }
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnLiedpfad] = value;
            }
        }
        
        public string Guid
        {
            get
            {
                return ((string)(this[this.m_dataTableTracks.DataColumnGuid]));
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnGuid] = value;
            }
        }

        public System.DateTime TimeStamp
        {
            get
            {
                return ((System.DateTime)(this[this.m_dataTableTracks.DataColumnTimestamp]));
            }
            set
            {
                this[this.m_dataTableTracks.DataColumnTimestamp] = value;
            }
        }

        public CDataRowAlbum DataRowAlbum
        {
            get { return ((CDataRowAlbum)(this.GetParentRow(this.Table.ParentRelations["AlbumTracks"]))); }
            set { this.SetParentRow(value, this.Table.ParentRelations["AlbumTracks"]); }
        }

        #endregion

        #region MethodsPublic

        public bool IsTrackNull()
        {
            return this.IsNull(this.m_dataTableTracks.DataColumnTrack);
        }

        public void SetTrackNull()
        {
            this[this.m_dataTableTracks.DataColumnTrack] = Convert.DBNull;
        }

        public bool IsLiedNull()
        {
            return this.IsNull(this.m_dataTableTracks.DataColumnLied);
        }

        public void SetLiedNull()
        {
            this[this.m_dataTableTracks.DataColumnLied] = Convert.DBNull;
        }

        public bool IsDauerNull()
        {
            return this.IsNull(this.m_dataTableTracks.DataColumnDauer);
        }

        public void SetDauerNull()
        {
            this[this.m_dataTableTracks.DataColumnDauer] = Convert.DBNull;
        }

        public bool IsLiedpfadNull()
        {
            return this.IsNull(this.m_dataTableTracks.DataColumnLiedpfad);
        }

        public void SetLiedpfadNull()
        {
            this[this.m_dataTableTracks.DataColumnLiedpfad] = Convert.DBNull;
        }

        public object Clone()
        {
            CDataRowTracks dataRowTracks = this.m_dataTableTracks.NewRow();
            dataRowTracks.ItemArray = (object[])this.ItemArray.Clone();
            return dataRowTracks;
        }

        public virtual bool Equals(CDataRowTracks dataRowTracks)
        {
            if (dataRowTracks == null)
            {
                return false;
            }

            for (int i = 0; i < dataRowTracks.ItemArray.Length; i++)
            {
                if (this.ItemArray[i].Equals(dataRowTracks.ItemArray[i]) ==  false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Equals(CDataRowTracks dataRowTracksA, CDataRowTracks dataRowTracksB)
        {
            if (dataRowTracksA != null)
            {
                return dataRowTracksA.Equals(dataRowTracksB);
            }
            else
            {
                if (dataRowTracksB == null)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion

        #region MethodsPrivate

        internal CDataRowTracks(DataRowBuilder dataRowBuilder)
            : base(dataRowBuilder)
        {
            this.m_dataTableTracks = ((CDataTableTracks)(this.Table));
        }

        #endregion
    }

    #endregion

    #region Class TrackChangeEventArgs
	
    public class TrackChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private CDataRowTracks m_row;
        private System.Data.DataRowAction m_dataRowAction;

        #endregion

        #region Properties

        public CDataRowTracks Row
        {
            get { return this.m_row; }
        }

        public DataRowAction Action
        {
            get { return this.m_dataRowAction; }
        }

        #endregion

        #region MethodsPublic

        public TrackChangeEventArgs(CDataRowTracks row, DataRowAction dataRowAction)
        {
            this.m_row = row;
            this.m_dataRowAction = dataRowAction;
        }

        #endregion

    }

    #endregion
}

