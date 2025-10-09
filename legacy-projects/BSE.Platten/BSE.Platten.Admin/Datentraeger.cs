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

namespace BSE.Platten.Admin
{
    public partial class Datentraeger : BSE.Platten.Admin.BaseDataForm
    {
        
        #region MethodsPublic
        
        public Datentraeger()
        {
            InitializeComponent();

            this.m_txtMedium.MaxLength = this.m_dataSetMedium.Medium.DataColumnMedium.MaxLength;
            this.m_txtMediumDescription.MaxLength = this.m_dataSetMedium.Medium.DataColumnBeschreibung.MaxLength;

            this.ToolStripDateBase.AutoSize = true;
            this.ToolStripDateBase.Stretch = true;
            this.ToolStripDateBase.GripStyle = ToolStripGripStyle.Hidden;
        }
        public Datentraeger(BSE.Platten.BO.Environment environment)
            : this()
        {
            this.Environment = environment;
            this.Configuration = this.Environment.GetConfiguration();
        }
        
        #endregion

        #region MethodsProtected

        protected override bool ValidateForm()
        {
            bool bIsValidate = true;
            if (this.BindingSource.Current != null)
            {
                this.ErrorProvider.SetError(this.m_txtMedium, string.Empty);
                if (this.m_txtMedium.Text != null)
                {
                    this.m_txtMedium.Text = this.m_txtMedium.Text.Trim();
                }
                if (string.IsNullOrEmpty(this.m_txtMedium.Text) == true)
                {
                    bIsValidate = false;
                    string strMessage = String.Format(CultureInfo.CurrentUICulture,Resources.IDS_FormFieldNoNullAllowedException, this.m_lblMedium.Text.Replace(":", ""));
                    this.ErrorProvider.SetError(this.m_txtMedium, strMessage);
                }
            }
            return bIsValidate;
        }

        #endregion

        #region MethodsPrivate
        
        private void CDatentraegerLoad(object sender, EventArgs e)
        {
            try
            {
                if (this.Configuration != null)
                {
                    this.ConnectionString = this.Environment.GetConnectionString();
                }
                OnClearSearch(this, EventArgs.Empty);
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException configurationValueNotFoundException)
            {
                GlobalizedMessageBox.Show(this, configurationValueNotFoundException.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void TxtMediumValidating(object sender, CancelEventArgs e)
        {
            ValidateForm();
        }
        
        private void CDatentraegerExecuteSearch(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            CMediumData queryParams = new CMediumData();
            queryParams.Medium = "%" + this.m_txtMedium.Text + "%";
            queryParams.Beschreibung = "%" + this.m_txtMediumDescription.Text + "%";

            try
            {
                this.BindingSource.PositionChanged -= OnPositionChanged;
                this.m_dataSetMedium.Medium.ColumnChanged -= OnColumnChanged;
                
                CMediumBusinessObject mediumBusinessObject = new CMediumBusinessObject(this.ConnectionString);
                CDataSetMedium dataSet = mediumBusinessObject.GetDataSetByQueryParams(queryParams);
                
                this.DataSet.Merge(dataSet);
                
                if (this.m_dataSetMedium.Medium.Count > 0)
                {
                    this.m_dataSetMedium.AcceptChanges();
                    base.OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Select));
                    this.BindingSource.PositionChanged += OnPositionChanged;
                    this.m_dataSetMedium.Medium.ColumnChanged += OnColumnChanged;
                    base.OnPositionChanged(sender, e);
                }
                else
                {
                    GlobalizedMessageBox.Show(this, Resources.IDS_FormFoundNoRecordInformation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CDatentraegerNewRecord(object sender, EventArgs e)
        {
            //die aktuelle DataRow mit den Werten für den Insert füllen
            DataRowView dataRowView = (DataRowView)this.BindingSource.Current;
            CDataRowMedium dataRowMedium = (CDataRowMedium)dataRowView.Row;
            dataRowMedium.Guid = System.Guid.NewGuid().ToString();
            
            this.BindingSource.EndEdit();
        }

        private void CDatentraegerSaveRecords(object sender, EventArgs e)
        {
            DataSet changedDataSet = this.m_dataSetMedium.GetChanges();
            if (changedDataSet != null)
            {
                foreach (DataRow dataRow in changedDataSet.Tables[0].Rows)
                {
                    //Der Datenträger muss angegeben werden
                    if (dataRow[1] != null)
                    {
                        string strDatentraeger = (string)dataRow[1];
                        dataRow[1] = strDatentraeger.Trim();
                    }
                    if (String.IsNullOrEmpty(dataRow[1].ToString()))
                    {
                        GlobalizedMessageBox.Show(this, Resources.IDS_FormExceptions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string strMessage = String.Format(CultureInfo.CurrentUICulture, Resources.IDS_FormFieldNoNullAllowedException, this.m_lblMedium.Text.Replace(":", ""));
                        this.ErrorProvider.SetError(this.m_txtMedium, strMessage);
                        return;
                    }
                }

                CMediumBusinessObject mediumBusinessObject = new CMediumBusinessObject(this.ConnectionString);
                DataSet dataSet = mediumBusinessObject.Update(changedDataSet);
                this.m_dataSetMedium.Merge(dataSet, false);

                if (this.m_dataSetMedium.Medium.HasErrors)
                {
                    string strException = string.Empty;

                    foreach (DataRow tmpRow in this.m_dataSetMedium.Medium.Rows)
                    {
                        if (tmpRow.HasErrors)
                        {
                            strException = System.Environment.NewLine + tmpRow.RowError.ToString();
                        }
                    }
                    GlobalizedMessageBox.Show(this, Resources.IDS_FormSaveExceptions + strException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Clear all old errors in the Medium datatable
                    foreach (DataRow tmpRow in this.m_dataSetMedium.Medium.GetErrors())
                    {
                        tmpRow.ClearErrors();
                    }
                }
                else
                {
                    if (this.DataFormViewMode == DataFormViewMode.Insert)
                    {
                        base.OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Select));
                    }
                    this.m_dataSetMedium.AcceptChanges();
                    base.OnPositionChanged(sender, e);
                    base.OnDataChanged(this, new System.EventArgs());
                    this.SetPanelInformation(Resources.IDS_FormSaveCompleteInformation);
                    this.SetUnDo(false);
                }
            }
        }

        #endregion

    }
}

