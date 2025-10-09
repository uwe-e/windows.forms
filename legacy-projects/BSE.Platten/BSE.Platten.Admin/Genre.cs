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
    public partial class Genre : BSE.Platten.Admin.BaseDataForm
    {
        #region MethodsPublic

        public Genre()
        {
            InitializeComponent();

            this.m_txtGenre.MaxLength = this.m_dataSetGenre.Genre.DataColumnGenre.MaxLength;

            this.ToolStripDateBase.AutoSize = true;
            this.ToolStripDateBase.Stretch = true;
            this.ToolStripDateBase.GripStyle = ToolStripGripStyle.Hidden;
        }

        public Genre(BSE.Platten.BO.Environment environment)
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
                this.ErrorProvider.SetError(this.m_txtGenre, string.Empty);
                if (this.m_txtGenre.Text != null)
                {
                    this.m_txtGenre.Text = this.m_txtGenre.Text.Trim();
                }
                if (string.IsNullOrEmpty(this.m_txtGenre.Text) == true)
                {
                    bIsValidate = false;
                    string strMessage = String.Format(
                        CultureInfo.CurrentUICulture,
                        Resources.IDS_FormFieldNoNullAllowedException,
                        this.m_lblGenre.Text.Replace(":", ""));
                    this.ErrorProvider.SetError(this.m_txtGenre, strMessage);
                }
            }
            return bIsValidate;
        }

        #endregion

        #region MethodsPrivate

        private void CGenreLoad(object sender, EventArgs e)
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
        
        private void TxtGenreValidating(object sender, CancelEventArgs e)
        {
            ValidateForm();
        }

        private void CGenreNewRecord(object sender, EventArgs e)
        {
            //die aktuelle DataRow mit den Werten für den Insert füllen
            DataRowView dataRowView = (DataRowView)this.BindingSource.Current;
            CDataRowGenre dataRowGenre = (CDataRowGenre)dataRowView.Row;
            dataRowGenre.Guid = System.Guid.NewGuid().ToString();

            this.BindingSource.EndEdit();
        }
        
        private void CGenreExecuteSearch(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CGenreData queryParams = new CGenreData();
            queryParams.Genre = "%" + this.m_txtGenre.Text + "%";

            try
            {
                this.BindingSource.PositionChanged -= OnPositionChanged;
                this.m_dataSetGenre.Genre.ColumnChanged -= OnColumnChanged;
                
                CGenreBusinessObject genreBusinessObject = new CGenreBusinessObject(this.ConnectionString);
                CDataSetGenre dataSet = genreBusinessObject.GetDataSetGenreByQueryParams(queryParams);
                
                this.DataSet.Merge(dataSet);
                
                if (this.m_dataSetGenre.Genre.Count > 0)
                {
                    this.m_dataSetGenre.AcceptChanges();
                    base.OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Select));
                    this.BindingSource.PositionChanged += OnPositionChanged;
                    this.m_dataSetGenre.Genre.ColumnChanged += OnColumnChanged;
                    base.OnPositionChanged(sender, e);
                }
                else
                {
                    GlobalizedMessageBox.Show(this, Resources.IDS_FormFoundNoRecordInformation, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        private void CGenreSaveRecords(object sender, EventArgs e)
        {
            DataSet changedDataSet = this.m_dataSetGenre.GetChanges();
            if (changedDataSet != null)
            {
                foreach (DataRow dataRow in changedDataSet.Tables[0].Rows)
                {
                    //Das Genre muss angegeben werden
                    if (dataRow[1] != null)
                    {
                        string strGenre = (string)dataRow[1];
                        dataRow[1] = strGenre.Trim();
                    }
                    if (String.IsNullOrEmpty(dataRow[1].ToString()))
                    {
                        GlobalizedMessageBox.Show(this, Resources.IDS_FormExceptions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string strMessage = String.Format(
                            CultureInfo.CurrentUICulture,
                            Resources.IDS_FormFieldNoNullAllowedException,
                            this.m_lblGenre.Text.Replace(":", ""));
                        this.ErrorProvider.SetError(this.m_txtGenre, strMessage);
                        return;
                    }
                }

                CGenreBusinessObject genreBusinessObject = new CGenreBusinessObject(this.ConnectionString);
                try
                {
                    DataSet dataSet = genreBusinessObject.Update(changedDataSet);
                    this.m_dataSetGenre.Merge(dataSet, false);

                    if (this.m_dataSetGenre.Genre.HasErrors)
                    {
                        string strException = string.Empty;

                        foreach (DataRow tmpRow in this.m_dataSetGenre.Genre.Rows)
                        {
                            if (tmpRow.HasErrors)
                            {
                                strException = System.Environment.NewLine + tmpRow.RowError.ToString();
                            }
                        }
                        GlobalizedMessageBox.Show(this, Resources.IDS_FormSaveExceptions + strException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //Clear all old errors in the Interpret datatable
                        foreach (DataRow tmpRow in this.m_dataSetGenre.Genre.GetErrors())
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
                        this.m_dataSetGenre.AcceptChanges();
                        base.OnPositionChanged(sender, e);
                        base.OnDataChanged(this, new System.EventArgs());
                        this.SetPanelInformation(Resources.IDS_FormSaveCompleteInformation);
                        this.SetUnDo(false);
                    }
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        #endregion
    }
}

