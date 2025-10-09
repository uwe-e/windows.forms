using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Admin.Properties;
using BSE.Platten.BO;
using System.Globalization;
using BSE.Platten.Common;

namespace BSE.Platten.Admin
{
    public partial class Interpreten : BSE.Platten.Admin.BaseDataForm
    {
        #region FieldsPrivate

        private bool m_bShowAction;

        #endregion

        #region Properties

        public bool ShowAction
        {
            get { return this.m_bShowAction; }
            set
            {
                this.m_bShowAction = value;
                if (!this.m_bShowAction)
                {
                    this.m_pnlAction.Visible = false;
                    this.Height -= this.m_pnlAction.Height;
                }
                else
                {
                    this.m_pnlAction.Visible = true;
                    this.Height += this.m_pnlAction.Height;
                }
            }
        }

        #endregion

        #region MethodsPublic

        public Interpreten()
        {
            InitializeComponent();

            this.m_txtInterpret.MaxLength = this.m_dataSetInterpret.Interpret.DataColumnInterpret.MaxLength;
            this.m_txtInterpretLang.MaxLength = this.m_dataSetInterpret.Interpret.DataColumnInterpretLang.MaxLength;

            this.ToolStripDateBase.AutoSize = true;
            this.ToolStripDateBase.Stretch = true;
            this.ToolStripDateBase.GripStyle = ToolStripGripStyle.Hidden;
        }

        public Interpreten(BSE.Platten.BO.Environment environment)
            : this()
        {
            this.Environment = environment;
            this.Configuration = this.Environment.GetConfiguration();
            this.ShowAction = false;
            this.m_btnOK.Enabled = false;
        }

        public BSE.Platten.BO.CInterpretData GetInterpretData()
        {
            BSE.Platten.BO.CInterpretData interpretData = new BSE.Platten.BO.CInterpretData();
            interpretData.InterpretId = this.m_dataSetInterpret.Interpret[this.BindingSource.Position].InterpretId;
            interpretData.Interpret = this.m_dataSetInterpret.Interpret[this.BindingSource.Position].Interpret;

            return interpretData;
        }

        #endregion

        #region MethodsProtected

        protected override bool ValidateForm()
        {
            bool bIsValidate = true;
            if (this.BindingSource.Current != null)
            {
                this.ErrorProvider.SetError(this.m_txtInterpret, string.Empty);
                if (this.m_txtInterpret.Text != null)
                {
                    this.m_txtInterpret.Text = this.m_txtInterpret.Text.Trim();
                }
                if (string.IsNullOrEmpty(this.m_txtInterpret.Text) == true)
                {
                    bIsValidate = false;
                    string strMessage = String.Format(
                        CultureInfo.CurrentUICulture,
                        Resources.IDS_FormFieldNoNullAllowedException,
                        this.m_lblInterpret.Text.Replace(":", ""));
                    this.ErrorProvider.SetError(this.m_txtInterpret, strMessage);
                }

                this.ErrorProvider.SetError(this.m_txtInterpretLang, string.Empty);
                if (this.m_txtInterpretLang.Text != null)
                {
                    this.m_txtInterpretLang.Text = this.m_txtInterpretLang.Text.Trim();
                }
                if (string.IsNullOrEmpty(this.m_txtInterpretLang.Text) == true)
                {
                    bIsValidate = false;
                    string strMessage = String.Format(
                        CultureInfo.CurrentUICulture,
                        Resources.IDS_FormFieldNoNullAllowedException,
                        this.m_lblInterpretLang.Text.Replace(":", ""));
                    this.ErrorProvider.SetError(this.m_txtInterpretLang, strMessage);
                }
            }
            return bIsValidate;
        }

        #endregion

        #region MethodsPrivate

        private void CInterpretenLoad(object sender, EventArgs e)
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
        
        private void TxtInterpretValidating(object sender, CancelEventArgs e)
        {
            ValidateForm();
        }

        private void TxtInterpretLangValidating(object sender, CancelEventArgs e)
        {
            ValidateForm();
        }
        
        private void CInterpretenClearSearch(object sender, EventArgs e)
        {
            this.m_btnOK.Enabled = false;
        }
        
        private void CInterpretenExecuteSearch(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            CInterpretData queryParams = new CInterpretData();
            queryParams.Interpret = "%" + this.m_txtInterpret.Text + "%";
            queryParams.InterpretLang = "%" + this.m_txtInterpretLang.Text + "%";
            
            try
            {
                this.BindingSource.PositionChanged -= OnPositionChanged;
                this.m_dataSetInterpret.Interpret.ColumnChanged -= OnColumnChanged;
                
                BSE.Platten.BO.CInterpretBusinessObject interpretBusinessObject = new BSE.Platten.BO.CInterpretBusinessObject(this.ConnectionString);
                BSE.Platten.BO.CDataSetInterpret dataSet = interpretBusinessObject.GetDataSetInterpretByQueryParams(queryParams);
                
                this.DataSet.Merge(dataSet);
                
                if (this.m_dataSetInterpret.Interpret.Count > 0)
                {
                    this.m_dataSetInterpret.AcceptChanges();

                    OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Select));

                    this.BindingSource.PositionChanged += OnPositionChanged;
                    this.m_dataSetInterpret.Interpret.ColumnChanged += OnColumnChanged;

                    OnPositionChanged(sender, e);
                    
                    this.m_btnOK.Enabled = true;
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

        private void CInterpretenNewRecord(object sender, EventArgs e)
        {
            this.m_btnOK.Enabled = false;

            //die aktuelle DataRow mit den Werten für den Insert füllen
            DataRowView dataRowView = (DataRowView)this.BindingSource.Current;
            CDataRowInterpret dataRowInterpret = (CDataRowInterpret)dataRowView.Row;
            dataRowInterpret.Interpret = string.Empty;
            dataRowInterpret.Guid = System.Guid.NewGuid().ToString();
            
            this.BindingSource.EndEdit();
        }

        private void CInterpretenSaveRecords(object sender, EventArgs e)
        {
            DataSet changedDataSet = this.m_dataSetInterpret.GetChanges();
            if (changedDataSet != null)
            {
                foreach (DataRow dataRow in changedDataSet.Tables[0].Rows)
                {
                    //Der "Interpret" muss angegeben werden
                    if (dataRow[1] != null)
                    {
                        string strInterpret = (string)dataRow[1];
                        dataRow[1] = strInterpret.Trim();
                    }
                    if (String.IsNullOrEmpty(dataRow[1].ToString()))
                    {
                        GlobalizedMessageBox.Show(this, Resources.IDS_FormExceptions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string strMessage = String.Format(
                            CultureInfo.CurrentUICulture,
                            Resources.IDS_FormFieldNoNullAllowedException,
                            this.m_lblInterpret.Text.Replace(":", ""));
                        this.ErrorProvider.SetError(this.m_txtInterpret, strMessage);
                        return;
                    }
                    //Der "Interpret Lang" muss angegeben werden
                    if (dataRow[1] != null)
                    {
                        string strInterpretLang = (string)dataRow[1];
                        dataRow[1] = strInterpretLang.Trim();
                    }
                    if (String.IsNullOrEmpty(dataRow[2].ToString()))
                    {
                        GlobalizedMessageBox.Show(this, Resources.IDS_FormExceptions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string strMessage = String.Format(
                            CultureInfo.CurrentUICulture,
                            Resources.IDS_FormFieldNoNullAllowedException,
                            this.m_lblInterpretLang.Text.Replace(":", ""));
                        this.ErrorProvider.SetError(this.m_txtInterpretLang, strMessage);
                        return;
                    }
                }

                BSE.Platten.BO.CInterpretBusinessObject interpretBusinessObject
                        = new BSE.Platten.BO.CInterpretBusinessObject(this.ConnectionString);
                DataSet dataSet = interpretBusinessObject.Update(changedDataSet);
                this.m_dataSetInterpret.Merge(dataSet, false);

                if (this.m_dataSetInterpret.Interpret.HasErrors)
                {
                    string strException = string.Empty;

                    foreach (DataRow tmpRow in this.m_dataSetInterpret.Interpret.Rows)
                    {
                        if (tmpRow.HasErrors)
                        {
                            strException = System.Environment.NewLine + tmpRow.RowError.ToString();
                        }
                    }
                    GlobalizedMessageBox.Show(this, Resources.IDS_FormSaveExceptions + strException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Clear all old errors in the Interpret datatable
                    foreach (DataRow tmpRow in this.m_dataSetInterpret.Interpret.GetErrors())
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
                    this.m_dataSetInterpret.AcceptChanges();
                    base.OnPositionChanged(sender, e);
                    this.SetPanelInformation(Resources.IDS_FormSaveCompleteInformation);
                    this.SetUnDo(false);
                    this.m_btnOK.Enabled = true;
                }
            }
        }

        #endregion

    }
}

