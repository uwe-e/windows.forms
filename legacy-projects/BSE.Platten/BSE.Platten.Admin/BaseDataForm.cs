using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Admin.Properties;
using BSE.Platten.BO;
using BSE.Platten.Common;
using System.Globalization;
using System.Security.Permissions;

namespace BSE.Platten.Admin
{
    public partial class BaseDataForm : BaseForm, IConfigurationSettings
    {
        #region Constants

        private const string m_strSettingsFileNameSettingsPart = ".Settings";

        #endregion

        #region Events

        public event EventHandler<HostAvailableEventArgs> HostAvailable;
        public event EventHandler NewRecord;
        public event EventHandler ClearSearch;
        public event EventHandler ExecuteSearch;
        public event EventHandler SaveRecords;
        public event EventHandler UnDo;
        public event EventHandler PositionChanged;
        public event EventHandler<ViewStateChangeEventArgs> ViewStateChanged;
        public event EventHandler DataChanged;
        public event DataColumnChangeEventHandler ColumnChanged;
        public event DataColumnChangeEventHandler ColumnChanging;

        #endregion

        #region FieldsPrivate

        private BSE.Platten.BO.Environment m_environment;
        private BSE.Platten.Common.CToolStripStatusLabelCheckDB m_ttslCheckDb;
        private VScrollBar m_vsbPaging;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the File MenuItem
        /// </summary>
        public ToolStripMenuItem MenuFile
        {
            get
            {
                return m_mnuDatei;
            }
        }
        #region IConfigurationSettings

        public string ConfigurationFolder
        {
            get { return this.GetType().Namespace; }
        }

        public string ConfigurationFileName
        {
            get { return this.GetType().Namespace; }
        }

        public string SettingsFileName
        {
            get { return ConfigurationFileName + m_strSettingsFileNameSettingsPart; }
        }
        
        #endregion
        /// <summary>
        /// Gets or sets the <see cref="BSE.Configuration.Configuration"/> object with the system environment settings.
        /// </summary>
        public BSE.Configuration.Configuration Configuration
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the <see cref="BSE.Configuration.Configuration"/> object with the form settings.
        /// </summary>
        public BSE.Configuration.Configuration Settings
        {
            get;
            set;
        }

        public BSE.Platten.BO.Environment Environment
        {
            get { return this.m_environment; }
            set
            {
                this.m_environment = value;
                if (this.m_ttslCheckDb != null)
                { 
                    this.m_ttslCheckDb.Environment = this.m_environment;
                }
            }
        }

        public VScrollBar VScrollBar
        {
            get { return m_vsbPaging; }
            set
            {
                this.m_vsbPaging = value;
                this.m_vsbPaging.Scroll += new ScrollEventHandler(VScrollBarScroll);
                this.m_vsbPaging.ValueChanged += new EventHandler(VScrollBarValueChanged);
            }
        }
        /// <summary>
        /// Gets or sets the <see cref="DataSet"/> object for the forms data.
        /// </summary>
        public DataSet DataSet
        {
            get;
            set;
        }

        public BindingSource BindingSource
        {
            get { return this.m_bindingSource; }
        }
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        protected string ConnectionString
        {
            get;
            set;
        }

        public ErrorProvider ErrorProvider
        {
            get { return this.m_errProvider; }
        }
        /// <summary>
        /// Gets or sets the <see cref="DataFormViewMode"/>
        /// </summary>
        protected DataFormViewMode DataFormViewMode
        {
            get;
            set;
        }

        public ToolStrip ToolStripDateBase
        {
            get { return this.m_tsDataBase; }
            set { this.m_tsDataBase = value; }
        }

        public MenuStrip MenuStripBase
        {
            get { return this.m_msBase; }
            set { this.m_msBase = value; }
        }

        public ToolStripPanel ToolStripPanelLeft
        {
            get { return this.m_tspLeft; }
            set { this.m_tspLeft = value; }
        }

        public ToolStripPanel ToolStripPanelRight
        {
            get { return this.m_tspRight; }
            set { this.m_tspRight = value; }
        }

        public ToolStripPanel ToolStripPanelTop
        {
            get { return this.m_tspTop; }
            set { this.m_tspTop = value; }
        }

        public ToolStripPanel ToolStripPanelBottom
        {
            get { return this.m_tspBottom; }
            set { this.m_tspBottom = value; }
        }
        protected DatabaseHostAvailability DatabaseHostAvailability
        {
            get { return this.m_ttslCheckDb.DatabaseHostAvailability; }
        }
        #endregion

        #region MethodsPublic

        public BaseDataForm()
        {
            InitializeComponent();
            this.m_tspTop.Join(this.m_tsDataBase);

            this.m_ttslCheckDb = new BSE.Platten.Common.CToolStripStatusLabelCheckDB();
            this.m_ttslCheckDb.TextAlign = ContentAlignment.MiddleLeft;
            this.m_ssBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.m_ttslCheckDb});

            this.DataFormViewMode = DataFormViewMode.Clear;
        }

        #endregion

        #region MethodsProtected
        protected override void Localize()
        {
            this.m_btnSuche_Neu.Text = Resources.ButtonClearSearch_Text;
            this.m_btnSuchen_Ausführen.Text = Resources.ButtonExecuteSearch_Text;
            this.m_btnDatensatz_Neu.Text = Resources.ButtonNewRecord_Text;
            this.m_btnDatensatz_Speichern.Text = Resources.ButtonSaveRecord_Text;
        }
        protected void SetUnDo(bool bUnDo)
        {
            this.ErrorProvider.Clear();
            this.m_btnEdit_Undo.Enabled = this.m_mnuEdit_Undo.Enabled = bUnDo;
        }

        protected void SetPanelInformation(string strInformation)
        {
            this.m_tslblComment.Text = strInformation;
        }

        protected bool IsHostAvailable(BSE.Platten.BO.Environment environment)
        {
            return this.m_ttslCheckDb.IsHostAvailable(environment);
        }

        protected virtual bool ValidateForm()
        {
            // Code logic in derived Form
            return true;
        }

        protected virtual bool ConfirmChanges()
        {
            // Code logic in derived Form
            return true;
        }

        protected void ResetBinding()
        {
            this.ErrorProvider.Clear();
            if (this.BindingSource != null)
            {
                this.BindingSource.EndEdit();
                this.BindingSource.PositionChanged -= OnPositionChanged;

                if (this.DataSet != null)
                {
                    this.DataSet.Clear();
                }
            }
        }
        /// <summary>
        /// Raises the Load event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(MenuStrip))
                {
                    MenuStrip childMenuStrip = (MenuStrip)control;
                    if (childMenuStrip != this.m_msBase)
                    {
                        childMenuStrip.Visible = false;
                        ToolStripManager.Merge(childMenuStrip, this.m_msBase);
                    }
                }
            }

            if (this.m_environment != null)
            {
                try
                {
                    this.ConnectionString = this.m_environment.GetConnectionString();
                    this.m_ttslCheckDb.HostAvailabilityChanged += OnHostAvailable;

                    if (this.IsHostAvailable(this.m_environment) == true)
                    {
                        base.OnLoad(e);
                    }
                }
                catch (BSE.Configuration.ConfigurationValueNotFoundException)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Raises the Closing event.
        /// </summary>
        /// <param name="e">A <see cref="CancelEventArgs"/> that contains the event data.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.m_ttslCheckDb.HostAvailabilityChanged -= OnHostAvailable;
            if (this.VScrollBar != null)
            {
                this.VScrollBar.Scroll -= new ScrollEventHandler(VScrollBarScroll);
                this.VScrollBar.ValueChanged -= new EventHandler(VScrollBarValueChanged);
            }
            base.OnClosing(e);
        }
        /// <summary>
        /// Raises the HostAvailable event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="HostAvailableEventArgs"/> that contains the event data.</param>
        protected virtual void OnHostAvailable(object sender,HostAvailableEventArgs e)
        {
            this.ResetBinding();
            DatabaseHostAvailability databaseHostAvailability = e.DatabaseHostAvailability;
            if (databaseHostAvailability != null)
            {
                if (databaseHostAvailability.IsAvailable == false)
                {
                    //All controls which could manipulate data are disabled.
                    foreach (ToolStripItem item in this.m_msBase.Items)
                    {
                        if (item != this.m_mnuDatei)
                        {
                            item.Enabled = false;
                        }
                    }
                    this.m_tsDataBase.Enabled = false;
                }
                else
                {
                    this.Environment.UserGrant = databaseHostAvailability.UserGrant;
                    //All controls which could manipulate data are enabled.
                    foreach (ToolStripItem item in this.m_msBase.Items)
                    {
                        item.Enabled = true;
                    }
                    this.m_tsDataBase.Enabled = true;
                }

                if (HostAvailable != null)
                {
                    HostAvailable(this, e);
                }
            }
        }
        /// <summary>
        /// Raises the DataChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnDataChanged(object sender, System.EventArgs e)
        {
            if (this.DataChanged != null)
            {
                this.DataChanged(this, e);
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual void OnClearSearch(object sender, EventArgs e)
        {
            if (ClearSearch != null)
            {
                ClearSearch(sender, e);
            }

            this.m_tslblNavigation.Text = string.Empty;
            if (this.VScrollBar != null)
            {
                this.VScrollBar.Enabled = false;
            }

            this.ResetBinding();
            OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Clear));
        }

        protected virtual void OnExecuteSearch(object sender, EventArgs e)
        {
            if (ExecuteSearch != null)
            {
                ExecuteSearch(sender, e);
            }
        }
        
        protected virtual void OnNewRecord(object sender, EventArgs e)
        {
            OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Insert));
            this.m_bindingSource.AddNew();

            if (NewRecord != null)
            {
                NewRecord(sender, e);
            }
        }

        protected virtual void OnSaveRecords(object sender, EventArgs e)
        {
            if (ValidateForm() == true)
            {
                this.BindingSource.EndEdit();
                if (SaveRecords != null)
                {
                    SaveRecords(sender, e);
                }
            }
        }

        protected virtual void OnUnDo(object sender, EventArgs e)
        {
            this.BindingSource.CancelEdit();
            //Clear all old errors
            foreach (DataTable dataTable in this.DataSet.Tables)
            {
                DataRow[] dataRowErrors = dataTable.GetErrors();
                foreach (DataRow dataRow in dataRowErrors)
                {
                    dataRow.ClearErrors();
                }
            }
            //Reset the dataset
            this.DataSet.RejectChanges();
            this.ErrorProvider.Clear();
            this.m_tslblComment.Text = string.Empty;
            this.m_mnuEdit_Undo.Enabled = this.m_btnEdit_Undo.Enabled = false;
            //ist die aktuelle Position = -1,
            //dann wurde vor dem Insert kein Datensatz selektiert
            if (this.BindingSource.Position == -1)
            {
                //und der auf neue Suche umgeschaltet
                OnClearSearch(sender, e);
            }
            if (this.BindingSource.Position != -1)
            {
                //wenn der Insert abgebrochen wird,
                if (this.DataFormViewMode == DataFormViewMode.Insert)
                {
                    //dann wird der DataViewMode zurückgesetzt
                    //this.DataViewMode = DataFormViewMode.Select;
                    OnViewStateChanged(sender,new ViewStateChangeEventArgs(DataFormViewMode.Select));
                    //die Position nachgeführt
                    OnPositionChanged(sender, e);
                    //und der ViewState neu gesetzt
                    
                }
            }

            if (UnDo != null)
            {
                UnDo(sender, e);
            }
        }

        protected virtual void OnViewStateChanged(object sender, ViewStateChangeEventArgs e)
        {
            this.DataFormViewMode = e.DataFormViewMode;
            switch (this.DataFormViewMode)
            {
                case DataFormViewMode.Clear:
                    this.m_mnuEdit_Undo.Enabled = this.m_btnEdit_Undo.Enabled = false;
                    this.m_mnuSuchen_Neu.Enabled = this.m_btnSuche_Neu.Enabled = false;
                    this.m_mnuSuchen_Ausführen.Enabled = this.m_btnSuchen_Ausführen.Enabled = true;
                    this.m_mnuDatensatz_Speichern.Enabled = this.m_btnDatensatz_Speichern.Enabled = false;
                    this.m_btnFirstRecord.Enabled = false;
                    this.m_btnPreviousRecord.Enabled = false;
                    this.m_btnNextRecord.Enabled = false;
                    this.m_btnLastRecord.Enabled = false;

                    this.m_tslblComment.Text = String.Empty;

                    if (this.Environment.UserGrant != null)
                    {
                        if (this.Environment.UserGrant.Grant == true)
                        {
                            this.m_mnuDatensatz_Neu.Enabled = this.m_btnDatensatz_Neu.Enabled = true;
                        }
                        else
                        {
                            this.m_mnuDatensatz_Neu.Enabled = this.m_btnDatensatz_Neu.Enabled = false;
                        }
                    }
                    break;
                case DataFormViewMode.Select:
                    this.m_mnuSuchen_Neu.Enabled = this.m_btnSuche_Neu.Enabled = true;
                    this.m_mnuSuchen_Ausführen.Enabled = this.m_btnSuchen_Ausführen.Enabled = false;

                    if (this.Environment.UserGrant.Grant == true)
                    {
                        this.m_mnuDatensatz_Neu.Enabled = this.m_btnDatensatz_Neu.Enabled = true;
                        this.m_mnuDatensatz_Speichern.Enabled = this.m_btnDatensatz_Speichern.Enabled = true;
                    }
                    else
                    {
                        this.m_mnuDatensatz_Neu.Enabled = this.m_btnDatensatz_Neu.Enabled = false;
                        this.m_mnuDatensatz_Speichern.Enabled = this.m_btnDatensatz_Speichern.Enabled = false;
                    }
                    break;
                case DataFormViewMode.Insert:
                    this.m_mnuSuchen_Neu.Enabled = this.m_btnSuche_Neu.Enabled = true;
                    this.m_mnuSuchen_Ausführen.Enabled = this.m_btnSuchen_Ausführen.Enabled = false;
                    this.m_mnuDatensatz_Neu.Enabled = this.m_btnDatensatz_Neu.Enabled = false;
                    this.m_mnuDatensatz_Speichern.Enabled = this.m_btnDatensatz_Speichern.Enabled = true;
                    this.m_mnuEdit_Undo.Enabled = this.m_btnEdit_Undo.Enabled = true;

                    if (this.m_vsbPaging != null)
                    {
                        this.m_vsbPaging.Enabled = false;
                    }

                    this.m_btnFirstRecord.Enabled =
                        this.m_btnPreviousRecord.Enabled =
                        this.m_btnNextRecord.Enabled =
                        this.m_btnLastRecord.Enabled = false;
                    break;
            }
            if (ViewStateChanged != null)
            {
                ViewStateChanged(sender, e);
            }
        }

        protected virtual void OnPositionChanged(object sender, EventArgs e)
        {
            if (this.DataFormViewMode == DataFormViewMode.Insert)
            {
                return;
            }

            if (this.m_bindingSource.Count == 0)
            {
                this.VScrollBar.Enabled = false;
            }
            else
            {
                this.VScrollBar.Enabled = true;
                this.VScrollBar.Minimum = 1;
                this.VScrollBar.Maximum = this.m_bindingSource.Count;
                this.VScrollBar.Value = this.m_bindingSource.Position + 1;

                if (this.m_bindingSource.Position == 0)
                {
                    this.m_btnFirstRecord.Enabled = false;
                    this.m_btnPreviousRecord.Enabled = false;
                }
                else
                {
                    this.m_btnFirstRecord.Enabled = true;
                    this.m_btnPreviousRecord.Enabled = true;
                }

                if (this.m_bindingSource.Position == this.m_bindingSource.Count - 1)
                {
                    this.m_btnNextRecord.Enabled = false;
                    this.m_btnLastRecord.Enabled = false;
                }
                else
                {
                    this.m_btnNextRecord.Enabled = true;
                    this.m_btnLastRecord.Enabled = true;
                }
            }

            this.m_tslblNavigation.Text = String.Format(CultureInfo.CurrentUICulture,Resources.IDS_FormRecordCountInformation,
                this.m_bindingSource.Position + 1,
                this.m_bindingSource.Count);

            if (this.PositionChanged != null)
            {
                this.PositionChanged(sender, e);
            }
        }

        protected virtual void OnColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            this.m_mnuEdit_Undo.Enabled = this.m_btnEdit_Undo.Enabled = true;
            this.m_tslblComment.Text = Resources.IDS_FormRecordChangedInformation;
            if (this.ColumnChanged != null)
            {
                this.ColumnChanged(sender, e);
            }
        }

        protected virtual void OnColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (this.ColumnChanging != null)
            {
                this.ColumnChanging(sender, e);
            }
        }

        #endregion

        #region MethodsPrivate

        private void m_mnuDatei_Beenden_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void m_mnuEdit_Undo_Click(object sender, EventArgs e)
        {
            OnUnDo(sender, e);
        }
        
        private void m_mnuSuchen_Neu_Click(object sender, EventArgs e)
        {
            OnClearSearch(sender, e);
        }

        private void m_mnuSuchen_Ausführen_Click(object sender, EventArgs e)
        {
            OnExecuteSearch(sender, e);
        }
        
        private void m_mnuDatensatz_Neu_Click(object sender, EventArgs e)
        {
            OnNewRecord(sender, e);
        }
        
        private void m_mnuDatensatz_Speichern_Click(object sender, EventArgs e)
        {
            OnSaveRecords(sender, e);
        }

        private void m_btnFirstRecord_Click(object sender, EventArgs e)
        {
            MoveFirst();
        }

        private void m_btnPreviousRecord_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void m_btnNextRecord_Click(object sender, EventArgs e)
        {
            MoveNext();
        }

        private void m_btnLastRecord_Click(object sender, EventArgs e)
        {
            MoveLast();
        }

        private void MoveFirst()
        {
            if (ValidateForm() == true)
            {
                this.m_bindingSource.MoveFirst();
            }
        }

        private void MovePrevious()
        {
            if (ValidateForm() == true)
            {
                this.m_bindingSource.MovePrevious();
            }
        }

        private void MoveNext()
        {
            if (ValidateForm() == true)
            {
                this.m_bindingSource.MoveNext();
            }
        }

        private void MoveLast()
        {
            if (ValidateForm() == true)
            {
                this.m_bindingSource.MoveLast();
            }
        }

        private void CBaseDataForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Next:
                    if (this.DataFormViewMode == DataFormViewMode.Insert)
                    {
                        return;
                    }
                    if (e.Modifiers == Keys.None)
                    {
                        MoveNext();
                    }
                    if (e.Modifiers == Keys.Control)
                    {
                        MoveLast();
                    }
                    break;
                case Keys.Prior:
                    if (this.DataFormViewMode == DataFormViewMode.Insert)
                    {
                        return;
                    }
                    if (e.Modifiers == Keys.None)
                    {
                        MovePrevious();
                    }
                    if (e.Modifiers == Keys.Control)
                    {
                        MoveFirst();
                    }
                    break;
            }
        }

        private void VScrollBarScroll(object sender, ScrollEventArgs e)
        {
            if (ValidateForm() == true)
            {
                this.m_bindingSource.Position = this.m_vsbPaging.Value - 1;
            }
        }
        private void VScrollBarValueChanged(object sender, EventArgs e)
        {
            if (ValidateForm() == false)
            {
                this.VScrollBar.Value = this.BindingSource.Position + 1;
            }
        }
        private void PanelContentResize(object sender, EventArgs e)
        {
            this.m_toolstripContentPanel.ClientSize = this.ContentPanel.ClientSize;
        }
        #endregion

        

    }
}