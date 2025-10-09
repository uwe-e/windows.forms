using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Platten.Admin.Properties;
using System.Collections.ObjectModel;
using System.Globalization;

namespace BSE.Platten.Admin
{
    public partial class Admin : BSE.Platten.Admin.BaseDataForm
    {
        #region Delegates

        private delegate void RefreshControlsHandler();

        #endregion

        #region Enums

        public enum EStartOption
        {
            InitializeComponents
        }

        #endregion

        #region FieldsPrivate

        private BSE.Platten.BO.Album m_currentAlbum;
        private string m_strAudioHomeDirectory;
        private int m_iTitleId;
        private bool m_bStartWithTitelId;
        private Image m_imgSong;

        #endregion

        #region Properties

        internal string AudioHomeDirectory
        {
            get { return this.m_strAudioHomeDirectory; }
            set { this.m_strAudioHomeDirectory = value; }
        }

        internal BSE.Platten.BO.Album CurrentAlbum
        {
            get { return this.m_currentAlbum; }
        }

        internal int TitelId
        {
            get { return this.m_iTitleId; }
        }

        #endregion

        #region MethodsPublic

        public Admin()
        {
        }

        public Admin(Admin.EStartOption eStartOptions)
            : this()
        {
            InitializeComponent();

            this.DataSet = this.m_dataSetAlbum;
            this.m_dataSetAlbum.Tracks.TableNewRow += new DataTableNewRowEventHandler(TracksTableNewRow);

            //Die Textbox m_txtErchDatum kann nur mit Int- Werten beschrieben werden.
            //Wird ein Stringwert in das Textfeld geschrieben, kann der Benutzer die Textbox nicht mehr verlassen.
            //Um dieses zu ermöglichen muss dieser Workaround durchgeführt werden
            Binding bindingErschDatum = new Binding("Text", this.m_bindingSource, "ErschDatum", true);
            this.m_txtErschDatum.DataBindings.Clear();
            this.m_txtErschDatum.DataBindings.Add(bindingErschDatum);
            bindingErschDatum.BindingComplete += delegate (object bind, BindingCompleteEventArgs e)
            {
                /* Allow user to Tab off */
                if (string.IsNullOrEmpty(this.m_txtErschDatum.Text) == true)
                {
                    e.Cancel = false;
                }
            };

            this.m_grdLieder.DataSource = this.m_bindingSource;
            this.m_grdLieder.DataMember = "AlbumTracks";

            this.m_txtTitel.MaxLength = this.m_dataSetAlbum.Album.DataColumnTitel.MaxLength;
            //this.m_txtTitel.Top = this.m_lblTitel.Top = this.m_cboInterpreten.Top;
            //this.m_lblTitel.Top += 4;
            //this.m_cboMedium.Top = this.m_lblMedium.Top = this.m_txtTitel.Top + 25;
            //this.m_cboGenre.Top = this.m_lblGenre.Top = this.m_cboMedium.Top;
            //this.m_lblGenre.Top = this.m_lblMedium.Top += 4;
            //this.m_txtErschDatum.Top = this.m_lblErschDatum.Top = this.m_cboMedium.Top + 26;
            //this.m_lblErschDatum.Top += 4;

            this.m_settings.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_settings.ConfigFileName = this.SettingsFileName;

            this.Settings = this.m_settings;
            this.m_imgSong = Resources.song;
            this.AllowDrop = true;
            this.m_tsTools.Visible = false;
            base.ToolStripDateBase.GripStyle = ToolStripGripStyle.Hidden;
            base.ToolStripDateBase.Stretch = true;
            ToolStripManager.Merge(this.m_tsTools, base.ToolStripDateBase);
            //this.m_tsAudioPlayer.Visible = false;
            //ToolStripManager.Merge(this.m_tsAudioPlayer, base.ToolStripDateBase);
            ToolStripManager.Merge(this.m_msAdmin, this.MenuStripBase);
            MenuFile.DropDownItems.Insert(0, new ToolStripSeparator());
            MenuFile.DropDownItems.Insert(0, new ToolStripMenuItem("Media Management", Resources.cd, OnMediaManagementToolStripMenuItemClick));
            MenuFile.DropDownItems.Insert(0, new ToolStripMenuItem("Genre Management", Resources.painters_palette, OnGenreManagementToolStripMenuItemClick));
            MenuFile.DropDownItems.Insert(0, new ToolStripMenuItem("Artist Management", Resources.user, OnArtistManagementToolStripMenuItemClick));
            
        }
        public Admin(bool bCompleteStart)
            : this(Admin.EStartOption.InitializeComponents)
        {
            //if (ToolStripManager.VisualStylesEnabled == true)
            //{
            //    this.ProfessionalColorTable = new BSE.Windows.Forms.Office2007BlueColorTable();
            //    //ToolStripManager.Renderer = new BSE.Windows.Forms.Office2007Renderer(this.ProfessionalColorTable);
            //    ToolStripProfessionalRenderer toolStripRenderer = new BSE.Windows.Forms.MetroRenderer();
            //    ToolStripManager.Renderer = toolStripRenderer;
            //    BSE.Windows.Forms.ProfessionalColorTable colorTable = toolStripRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
            //    if (colorTable != null)
            //    {
            //        BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
            //        if (panelColorTable != null)
            //        {
            //            BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
            //                this.Controls,
            //                panelColorTable);
            //        }
            //    }
            //}

            BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                            this.Controls,
                            this.PanelColors);


            this.m_configuration.ApplicationSubDirectory = this.ConfigurationFolder;
            this.m_configuration.ConfigFileName = this.ConfigurationFileName;

            this.Environment = new BSE.Platten.BO.Environment(this.m_configuration);
        }

        public Admin(BSE.Configuration.Configuration configuration)
            : this(Admin.EStartOption.InitializeComponents)
        {
            this.m_configuration = configuration;
            this.Environment = new BSE.Platten.BO.Environment(this.m_configuration);
        }

        public Admin(BSE.Configuration.Configuration configuration, int iTitleId)
            : this(configuration)
        {
            this.m_bStartWithTitelId = true;
            this.m_iTitleId = iTitleId;
        }

        public Admin(BSE.Configuration.Configuration configuration, Album album)
            : this(configuration)
        {
            if (album != null)
            {
                this.m_bStartWithTitelId = true;
                this.m_iTitleId = album.AlbumId;
            }
        }

        #endregion

        #region MethodsProtected
        protected override void Localize()
        {
            base.Localize();
            toolStripDropDownButton1.Text = Resources.ButtonSystemInformations_Text;
        }
        protected override bool ValidateForm()
        {
            bool bIsValid = true;
            if (this.BindingSource.Current != null)
            {
                //Validation TxtTitel
                this.ErrorProvider.SetError(this.m_txtTitel, string.Empty);
                if (this.m_txtTitel.Text != null)
                {
                    this.m_txtTitel.Text = this.m_txtTitel.Text.Trim();
                }
                if (string.IsNullOrEmpty(this.m_txtTitel.Text) == true)
                {
                    bIsValid = false;
                    string strMessage = String.Format(CultureInfo.CurrentCulture,Resources.IDS_FormFieldNoNullAllowedException, this.m_lblTitel.Text.Replace(":", ""));
                    this.ErrorProvider.SetError(this.m_txtTitel, strMessage);
                }

                //Validation TxtErschdatum
                this.ErrorProvider.SetError(this.m_txtErschDatum, string.Empty);
                if (this.m_txtErschDatum.Text != null)
                {
                    this.m_txtErschDatum.Text = this.m_txtErschDatum.Text.Trim();
                }
                if (string.IsNullOrEmpty(this.m_txtErschDatum.Text) == false)
                {
                    string strExpression = @"^(\d{4})?$";
                    if (System.Text.RegularExpressions.Regex.Match(this.m_txtErschDatum.Text, strExpression).Success == false)
                    {
                        bIsValid = false;
                        string strMessage = String.Format(CultureInfo.CurrentCulture,Resources.IDS_FormMaskInputTxtErschDatum, this.m_lblErschDatum.Text.Replace(":", ""));
                        this.ErrorProvider.SetError(this.m_txtErschDatum, strMessage);
                    }
                }
            }
            return bIsValid;
        }

        protected override bool ConfirmChanges()
        {
            bool bConfirmChanges = base.ConfirmChanges();
            this.BindingSource.EndEdit();
            if (this.DataSet.GetChanges() != null)
            {
                DialogResult dialogResult = GlobalizedMessageBox.Show(
                    this,
                    this.GetChangedDataInformation(),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.No)
                {
                    bConfirmChanges = false;
                }
                else
                {
                    //die Änderungen werden verworfen
                    OnUnDo(this, new EventArgs());
                }
            }
            return bConfirmChanges;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                int iSplashStep = 0;
                int iSplashStepsTotal = 7;
                CSplashScreen.ShowSplashScreen();
                CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageLoadSystemSettings, iSplashStep++, iSplashStepsTotal);
                LoadSettings();
                try
                {
                    CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageCheckDatabaseConnection, iSplashStep++, iSplashStepsTotal);
                    base.OnLoad(e);
                    CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageCheckAudiodirectory, iSplashStep++, iSplashStepsTotal);
                    this.AudioHomeDirectory = this.Environment.GetAudioHomeDirectory();

                }
                catch (BSE.Configuration.ConfigurationValueNotFoundException configurationValueNotFoundException)
                {
                    CSplashScreen.CloseSplashScreen(this);
                    DialogResult dialogResult = GlobalizedMessageBox.Show(
                        this, configurationValueNotFoundException.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.OK)
                    {
                        OpenOptions();
                        return;
                    }
                }

                if (this.IsHostAvailable(this.Environment) == true)
                {
                    CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageLoadCovers, iSplashStep++, iSplashStepsTotal);
                    GetCovers();
                    CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageLoadMedia, iSplashStep++, iSplashStepsTotal);
                    GetMedia();
                    CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageLoadGenres, iSplashStep++, iSplashStepsTotal);
                    GetGenres();
                    CSplashScreen.SetStatusMessage(Resources.IDS_AdminLoadMessageLoadArtists, iSplashStep++, iSplashStepsTotal);
                    GetInterpreten();

                    // Wird BSEadmin von BSEtunes aus aufgerufen, dann wird der
                    // Datensatz mit der übergebenen TitelId angezeigt
                    if (this.m_bStartWithTitelId == true)
                    {
                        GetRecordSelectedByTitelId(this.TitelId);
                    }
                    else
                    {
                        OnClearSearch(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception exception)
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (CSplashScreen.SplashScreen != null)
                {
                    CSplashScreen.CloseSplashScreen(this);
                }
            }
        }

        protected override void OnClearSearch(object sender, EventArgs e)
        {
            if (ConfirmChanges() == true)
            {
                base.OnClearSearch(sender, e);
            }
        }

        protected override void OnNewRecord(object sender, EventArgs e)
        {
            using (Interpreten interpreten = new Interpreten(this.Environment))
            {
                interpreten.ProfessionalColorTable = this.ProfessionalColorTable;
                interpreten.PanelColors = this.PanelColors;
                interpreten.ShowAction = true;
                if (interpreten.ShowDialog() == DialogResult.OK)
                {
                    base.OnNewRecord(sender, e);
                    this.m_picCover.Image = null;
                    //die aktuelle DataRow mit den Werten für den Insert füllen
                    DataRowView dataRowView = (DataRowView)this.BindingSource.Current;
                    CDataRowAlbum dataRowAlbum = (CDataRowAlbum)dataRowView.Row;
                    dataRowAlbum.Interpret = interpreten.GetInterpretData().Interpret;
                    dataRowAlbum.InterpretId = interpreten.GetInterpretData().InterpretId;
                    dataRowAlbum.Titel = string.Empty;
                    dataRowAlbum.Guid = System.Guid.NewGuid().ToString();
                    dataRowAlbum.ErstellDatum = DateTime.Now;
                    dataRowAlbum.ErstelltDurch = this.Environment.UserName;

                    this.BindingSource.EndEdit();

                    this.m_txtTitel.Focus();
                }
            }
        }

        #endregion

        #region MethodsPrivate

        private void CAdminFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !ConfirmChanges();
        }

        private void CAdminFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        
        private void PanelAlbumResize(object sender, EventArgs e)
        {
            this.m_tbcAlbum.Height = this.m_pnlContent.Height
                - this.m_tbcAlbum.Top
                - this.m_tbcAlbum.Left;
        }

        private void CAdminViewStateChanged(object sender, ViewStateChangeEventArgs e)
        {
            DataFormViewMode dataFormViewMode = e.DataFormViewMode;
            switch (dataFormViewMode)
            {
                case DataFormViewMode.Clear:
                    this.m_btnEditImage.Enabled = this.m_btnTools_Bildimport.Enabled = this.m_mnuTools_Bildimport.Enabled = false;
                    this.m_mnuTools.Enabled = false;
                    this.m_btnTools_Bildexport.Enabled = this.m_mnuTools_Bildexport.Enabled = false;
                    this.m_btnTools_RipCD.Enabled = this.m_mnuTools_RipCD.Enabled = false;
                    this.m_btnTools_AudioImport.Enabled = this.m_mnuTools_AudioImport.Enabled = false;
                    this.m_btnTools_WriteTags.Enabled = this.m_mnuTools_WriteTags.Enabled = false;
                    this.m_txtInterpret.ReadOnly = false;
                    break;
                case DataFormViewMode.Select:
                    if (this.Environment.UserGrant.Grant == true)
                    {
                        this.m_btnEditImage.Enabled = this.m_btnTools_Bildimport.Enabled = this.m_mnuTools_Bildimport.Enabled = true;
                        this.m_btnShowInterprets.Enabled = true;
                        this.m_mnuTools.Enabled = true;
                        this.m_btnTools_RipCD.Enabled = this.m_mnuTools_RipCD.Enabled = true;
                        this.m_btnTools_AudioImport.Enabled = this.m_mnuTools_AudioImport.Enabled = true;

                        this.m_txtInterpret.ReadOnly = true;
                        if (this.m_grdLieder.Enabled == false)
                        {
                            this.m_grdLieder.Enabled = true;
                        }
                    }
                    else
                    {
                        this.m_btnEditImage.Enabled = false;
                    }
                    break;
                case DataFormViewMode.Insert:
                    this.m_mnuTools.Enabled = this.m_tsTools.Enabled = true;
                    this.m_btnEditImage.Enabled = this.m_btnTools_Bildimport.Enabled = this.m_mnuTools_Bildimport.Enabled = true;
                    this.m_btnShowInterprets.Enabled = true;
                    this.m_txtInterpret.ReadOnly = true;
                    this.m_mnuTools_RipCD.Enabled = this.m_btnTools_RipCD.Enabled = false;
                    this.m_mnuTools_AudioImport.Enabled = this.m_btnTools_AudioImport.Enabled = false;
                    this.m_btnTools_WriteTags.Enabled = this.m_mnuTools_WriteTags.Enabled = false;
                    break;
            }
        }
        
        private void CAdminExecuteSearch(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Album queryParams = new Album();

            queryParams.Interpret = "%" + m_txtInterpret.Text + "%";
            queryParams.Title = "%" + m_txtTitel.Text + "%";
            if (this.m_cboMedium.SelectedValue != null)
            {
                queryParams.MediumId = (int)this.m_cboMedium.SelectedValue;
            }
            if (this.m_cboGenre.SelectedValue != null)
            {
                queryParams.GenreId = (int)this.m_cboGenre.SelectedValue;
            }
            if (String.IsNullOrEmpty(this.m_txtErschDatum.Text) == false)
            {
                string strExpression = @"^(\d{4})?$";
                if (System.Text.RegularExpressions.Regex.Match(this.m_txtErschDatum.Text, strExpression).Success == false)
                {
                    string strMessage = String.Format(CultureInfo.CurrentCulture,Resources.IDS_FormMaskInputTxtErschDatum, this.m_lblErschDatum.Text.Replace(":", ""));
                    GlobalizedMessageBox.Show(this, strMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    queryParams.Year = int.Parse(this.m_txtErschDatum.Text,CultureInfo.InvariantCulture);
                }
            }

            try
            {
                this.BindingSource.PositionChanged -= OnPositionChanged;
                this.m_dataSetAlbum.Album.ColumnChanged -= OnColumnChanged;
                this.m_dataSetAlbum.Tracks.TrackChanging -= new  EventHandler<TrackChangeEventArgs>(TrackChanging);
                this.m_dataSetAlbum.Tracks.TrackDeleting -= new EventHandler<TrackChangeEventArgs>(TrackDeleting);

                BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
                BSE.Platten.BO.CDataSetAlbum dataSet = bseAdminBusinessObject.GetDataSetAlbumByQueryParams(queryParams);

                this.DataSet.Merge(dataSet);

                if (this.m_dataSetAlbum.Album.Count > 0)
                {
                    this.m_dataSetAlbum.AcceptChanges();

                    base.OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Select));
                    this.BindingSource.PositionChanged += OnPositionChanged;
                    this.m_dataSetAlbum.Album.ColumnChanged += OnColumnChanged;
                    this.m_dataSetAlbum.Tracks.TrackChanging += new EventHandler<TrackChangeEventArgs>(TrackChanging);
                    this.m_dataSetAlbum.Tracks.TrackDeleting += new EventHandler<TrackChangeEventArgs>(TrackDeleting);
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

        private void CAdminSaveRecords(object sender, EventArgs e)
        {
            DataSet changedDataSet = this.DataSet.GetChanges();
            if (changedDataSet != null)
            {
                foreach (DataRow dataRow in changedDataSet.Tables[0].Rows)
                {
                    //Damit das Einfügen der Interpretendaten funktioniert, musste der Insertwert des Titelfeldes
                    //auf string.empty gesetzt werden
                    if (dataRow["Titel"] != null)
                    {
                        string strTitel = (string)dataRow["Titel"];
                        dataRow["Titel"] = strTitel.Trim();
                    }
                    if (String.IsNullOrEmpty(dataRow["Titel"].ToString()) == true)
                    {
                        GlobalizedMessageBox.Show(this, Resources.IDS_FormExceptions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string strMessage = String.Format(Resources.IDS_FormFieldNoNullAllowedException, this.m_lblTitel.Text.Replace(":", ""));
                        this.ErrorProvider.SetError(this.m_txtTitel, strMessage);
                        return;
                    }
                    //Das Mutationsdatum sowie der Name des Mutierers werden eingetragen
                    if (this.DataFormViewMode == DataFormViewMode.Select)
                    {
                        dataRow["MutationDatum"] = DateTime.Now;
                        dataRow["MutationNm"] = this.Environment.UserName;
                    }
                }

                BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject
                        = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
                try
                {
                    DataSet dataSet = bseAdminBusinessObject.Update(changedDataSet);
                    this.m_dataSetAlbum.Merge(dataSet, false);

                    if (this.m_dataSetAlbum.HasErrors == true)
                    {
                        string strException = string.Empty;

                        if (this.m_dataSetAlbum.Album.HasErrors == true)
                        {
                            foreach (DataRow tmpRow in this.m_dataSetAlbum.Album.Rows)
                            {
                                if (tmpRow.HasErrors == true)
                                {
                                    strException = System.Environment.NewLine + tmpRow.RowError.ToString();
                                }
                            }
                            GlobalizedMessageBox.Show(this, Resources.IDS_FormSaveExceptions + strException, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Clear all old errors in the Interpret datatable
                            foreach (DataRow tmpRow in this.m_dataSetAlbum.Album.GetErrors())
                            {
                                tmpRow.ClearErrors();
                            }
                        }
                        if (this.m_dataSetAlbum.Tracks.HasErrors == true)
                        {
                            GlobalizedMessageBox.Show(this, Resources.IDS_FormSaveTracksExceptions, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (this.DataFormViewMode == DataFormViewMode.Insert)
                        {
                            base.OnViewStateChanged(sender, new ViewStateChangeEventArgs(DataFormViewMode.Select));
                        }

                        this.m_dataSetAlbum.AcceptChanges();
                        base.OnPositionChanged(sender, e);
                        GetCovers();
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

        private void CAdminPositionChanged(object sender, EventArgs e)
        {
            if (this.m_cboInterpreten.Visible == true)
            {
                this.m_cboInterpreten.Visible = false;
            }
            if (this.m_cboMedium.Focus() == true)
            {
                this.m_txtInterpret.Focus();
            }
            if (this.m_cboGenre.Focus() == true)
            {
                this.m_txtInterpret.Focus();
            }

            SetCurrentAlbum();
        }

        private void HostAvailabilityChanged(object sender, HostAvailableEventArgs e)
        {
            this.m_mnuExtras.Enabled = true;
            DatabaseHostAvailability databaseHostAvailability = e.DatabaseHostAvailability;
            if (databaseHostAvailability != null)
            {
                if (databaseHostAvailability.IsAvailable == false)
                {
                    //Alle Controls die Daten manipulieren können werden disabled
                    this.m_pnlAlbum.Enabled = false;
                    this.m_pnlCovers.Enabled = false;
                    this.m_tsTools.Enabled = false;
                }
                else
                {
                    this.m_pnlAlbum.Enabled = true;
                    this.m_pnlCovers.Enabled = true;
                    this.m_tsTools.Enabled = true;

                    this.Invoke(new RefreshControlsHandler(RefreshControls));
                }
            }
        }

        private void RefreshControls()
        {
            GetCovers();
            GetMedia();
            GetGenres();
            GetInterpreten();

            OnClearSearch(this, EventArgs.Empty);
        }

        private void GridLiederRowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dataSetAlbum == null)
            {
                return;
            }
            BindingManagerBase bindingManagerTracks = this.m_grdLieder.BindingContext[this.m_grdLieder.DataSource, this.m_grdLieder.DataMember];
            if (bindingManagerTracks.Count == 0)
            {
                return;
            }
            CDataRowTracks dataRowTracks = ((CDataRowTracks)((DataRowView)bindingManagerTracks.Current).Row);
            if (dataRowTracks != null)
            {
                EditLieder editLieder = new EditLieder(dataRowTracks, this.Environment);
                editLieder.ProfessionalColorTable = this.ProfessionalColorTable;
                editLieder.PanelColors = this.PanelColors;
                editLieder.ShowDialog();
            }
        }

        private void GridLiederDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strException = string.Empty;
            if (e.Exception is FormatException)
            {
                Type type = this.m_grdLieder.Columns[e.ColumnIndex].ValueType;
                if (type == typeof(Int32))
                {
                    strException = Resources.IDS_GrdLiederNoNullAllowedException;
                }
                else
                {
                    strException = e.Exception.Message;
                }
            }
            else if (e.Exception is NoNullAllowedException)
            {
                strException = Resources.IDS_GrdLiederNoNullAllowedException;
            }
            else
            {
                strException = e.Exception.Message;
            }

            DataRowView dataRowView = this.m_grdLieder.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (dataRowView.IsNew == true)
            {
                e.Cancel = true;
            }

            this.m_grdLieder.Rows[e.RowIndex].ErrorText = strException;
        }
        
        private void GridLiederCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the error icon in the row header is hidden.
            this.m_grdLieder.Rows[e.RowIndex].ErrorText = string.Empty;
        }
        
        private void GridLiederKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                foreach (DataGridViewRow dataGridViewRow in this.m_grdLieder.Rows)
                {
                    dataGridViewRow.ErrorText = string.Empty;
                }
            }
        }

        private void GridLiederCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.Value is DateTime)
                {
                    DateTime dateTime = (DateTime)e.Value;
                    e.Value = new TimeSpan(
                        dateTime.Hour,
                        dateTime.Minute,
                        dateTime.Second);
                }
            }
        }

        private void OnArtistManagementToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (BaseDataForm baseDataForm = new Interpreten(this.Environment))
            {
                baseDataForm.ProfessionalColorTable = this.ProfessionalColorTable;
                baseDataForm.PanelStyle = this.PanelStyle;
                baseDataForm.PanelColors = this.PanelColors;
                baseDataForm.ShowDialog();
            }
        }
        private void OnGenreManagementToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (Genre baseDataForm = new Genre(this.Environment))
            {
                baseDataForm.DataChanged += new EventHandler(GenreDataChanged);
                baseDataForm.ProfessionalColorTable = this.ProfessionalColorTable;
                baseDataForm.PanelStyle = this.PanelStyle;
                baseDataForm.PanelColors = this.PanelColors;
                baseDataForm.ShowDialog();
            }
        }
        private void OnMediaManagementToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (Datentraeger baseDataForm = new Datentraeger(this.Environment))
            {
                baseDataForm.DataChanged += new EventHandler(DatentraegerDataChanged);
                baseDataForm.ProfessionalColorTable = this.ProfessionalColorTable;
                baseDataForm.PanelStyle = this.PanelStyle;
                baseDataForm.PanelColors = this.PanelColors;
                baseDataForm.ShowDialog();
            }
        }
        private void OnDiskInformationToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (BaseForm baseDataForm = new DiskInfo(this.Environment))
            {
                baseDataForm.ProfessionalColorTable = this.ProfessionalColorTable;
                baseDataForm.ShowDialog();
            }
        }
        private void OnSystemStatisticToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (BaseForm baseDataForm = new Statistic
            {
                ConnectionString = this.ConnectionString
            })
            {
                baseDataForm.ProfessionalColorTable = this.ProfessionalColorTable;
                baseDataForm.ShowDialog();
            }
        }

        private void m_mnuExtras_Optionen_Click(object sender, EventArgs e)
        {
            OpenOptions();
        }

        private void TxtInterpretReadOnlyChanged(object sender, EventArgs e)
        {
            if (this.m_txtInterpret.ReadOnly == true)
            {
                Color backColor = ProfessionalColors.ToolStripContentPanelGradientBegin;
                if (this.ProfessionalColorTable != null)
                {
                    this.m_txtInterpret.BackColor = this.ProfessionalColorTable.ToolStripContentPanelGradientBegin;
                    if (typeof(BSE.Windows.Forms.ProfessionalColorTable).IsAssignableFrom(this.ProfessionalColorTable.GetType()))
                    {
                        this.m_txtInterpret.ForeColor = this.ProfessionalColorTable.MenuItemText;
                    }
                }
            }
            else
            {
                this.m_txtInterpret.BackColor = SystemColors.Window;
                this.m_txtInterpret.ForeColor = SystemColors.WindowText;
            }
        }

        private void TxtErschDatumValidating(object sender, CancelEventArgs e)
        {
            ValidateForm();
        }
        
        private void TxtTitelValidating(object sender, CancelEventArgs e)
        {
            ValidateForm();
        }
        
        private void m_btnShowInterprets_Click(object sender, EventArgs e)
        {
            this.m_cboInterpreten.Visible = !this.m_cboInterpreten.Visible;
            if (this.m_cboInterpreten.Visible == true)
            {
                this.m_cboInterpreten.Focus();
            }
        }

        private void CboInterpretenVisibleChanged(object sender, EventArgs e)
        {
            int iControlsTop = this.m_cboInterpreten.Top;
            this.m_cboInterpreten.SelectedIndexChanged -= new System.EventHandler(this.CboInterpretenSelectedIndexChanged);
            if (m_cboInterpreten.Visible)
            {
                this.m_cboInterpreten.SelectedIndexChanged += new System.EventHandler(this.CboInterpretenSelectedIndexChanged);
                iControlsTop += 26;
            }
            else
            {
                this.m_txtInterpret.Focus();
            }
            this.m_lblInterpreten.Visible = this.m_cboInterpreten.Visible;
            this.m_txtTitel.Top = this.m_lblTitel.Top = iControlsTop;
            this.m_lblTitel.Top += 4;
            this.m_cboMedium.Top = this.m_lblMedium.Top = this.m_txtTitel.Top + 26;
            this.m_lblMedium.Top += 4;
            this.m_cboGenre.Top = this.m_lblGenre.Top = this.m_cboMedium.Top;
            this.m_lblGenre.Top += 4;
            this.m_txtErschDatum.Top = this.m_lblErschDatum.Top = this.m_cboMedium.Top + 26;
            this.m_lblErschDatum.Top += 4;
        }

        private void CboInterpretenSelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.m_txtInterpret.Text = this.m_cboInterpreten.GetItemText(this.m_cboInterpreten.SelectedItem);
            if (this.DataFormViewMode != DataFormViewMode.Clear)
            {
                this.m_dataSetAlbum.Album[this.BindingSource.Position].InterpretId = (int)this.m_cboInterpreten.SelectedValue;
                this.m_dataSetAlbum.Album[this.BindingSource.Position].Interpret = this.m_cboInterpreten.Text;
            }
            if (this.DataFormViewMode == DataFormViewMode.Select)
            {
                this.m_cboInterpreten.Visible = false;
            }
            this.m_cboInterpreten.Visible = false;
        }

        private void m_btnEditImage_Click(object sender, EventArgs e)
        {
            CCoverData coverData = new CCoverData();
            coverData.Interpret = this.m_dataSetAlbum.Album[this.BindingSource.Position].Interpret;
            if (String.IsNullOrEmpty(this.m_dataSetAlbum.Album[this.BindingSource.Position].Titel) == false)
            {
                coverData.Titel = this.m_dataSetAlbum.Album[this.BindingSource.Position].Titel;
            }
            if (this.m_picCover.Image != null)
            {
                coverData.Image = this.m_picCover.Image;
            }
            if (this.m_dataSetAlbum.Album[this.BindingSource.Position].IsPictureFormatNull() == false)
            {
                string strImagingExtension = this.m_dataSetAlbum.Album[this.BindingSource.Position].PictureFormat;
                coverData.Extension = strImagingExtension;
            }
            try
            {
                using (EditCover editCover = new EditCover(coverData))
                {

                    editCover.ProfessionalColorTable = this.ProfessionalColorTable;
                    editCover.PanelColors = this.PanelColors;
                    if (editCover.ShowDialog() == DialogResult.OK)
                    {
                        if (editCover.HasCoverChanged())
                        {
                            coverData = null;
                            coverData = editCover.CoverData;
                            if (coverData.Image != null)
                            {
                                this.m_dataSetAlbum.Album[this.BindingSource.Position].PictureFormat
                                    = coverData.Extension;
                                this.m_picCover.Image = coverData.Image;

                                Size calculatedThumbNailSize = CCoverData.GetCalculatedImageSize(coverData.Image);

                                Image imageThumbNail = CCoverData.GetThumbNailFromImage(
                                    coverData.Image,
                                    calculatedThumbNailSize);

                                Byte[] bytesCover = CCoverData.GetBytesFromImage(coverData.Image, null);
                                System.Drawing.Imaging.ImageFormat imageFormat = CCoverData.GetImageFormat(coverData.Image);
                                Byte[] bytesThumbNail = CCoverData.GetBytesFromImage(imageThumbNail, imageFormat);

                                this.m_dataSetAlbum.Album[this.BindingSource.Position].Cover = bytesCover;
                                this.m_dataSetAlbum.Album[this.BindingSource.Position].ThumbNail = bytesThumbNail;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_btnTools_Bildimport_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (this.m_ofdlgPictureImport.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_ofdlgPictureImport.FileName);
                if (CCoverData.IsAllowedCoverExtension(fileInfo.Extension) == true)
                {
                    try
                    {
                        Image imageCover = CCoverData.GetImageFromFile(fileInfo);

                        Size calculatedThumbNailSize = CCoverData.GetCalculatedImageSize(imageCover);
                        Image imageThumbNail = CCoverData.GetThumbNailFromImage(
                            imageCover,
                            calculatedThumbNailSize);

                        Byte[] bytesCover = CCoverData.GetBytesFromImage(imageCover, null);
                        System.Drawing.Imaging.ImageFormat imageFormat = CCoverData.GetImageFormat(imageCover);
                        Byte[] bytesThumbNail = CCoverData.GetBytesFromImage(imageThumbNail, imageFormat);

                        this.m_dataSetAlbum.Album[this.BindingSource.Position].PictureFormat
                            = fileInfo.Extension.Substring(1, fileInfo.Extension.Length - 1);
                        this.m_dataSetAlbum.Album[this.BindingSource.Position].Cover = bytesCover;
                        this.m_dataSetAlbum.Album[this.BindingSource.Position].ThumbNail = bytesThumbNail;
                    }
                    catch (Exception exception)
                    {
                        GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void m_btnTools_Bildexport_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (this.m_picCover.Image != null)
            {
                string strImageFileName = string.Empty;
                if (String.IsNullOrEmpty(this.m_dataSetAlbum.Album[this.BindingSource.Position].Interpret) == false)
                {
                    strImageFileName += this.m_dataSetAlbum.Album[this.BindingSource.Position].Interpret;
                }
                if (String.IsNullOrEmpty(this.m_dataSetAlbum.Album[this.BindingSource.Position].Titel) == false)
                {
                    strImageFileName += " " + this.m_dataSetAlbum.Album[this.BindingSource.Position].Titel;
                }
                if (this.m_dataSetAlbum.Album[this.BindingSource.Position].IsPictureFormatNull() == false)
                {
                    string strExtension = this.m_dataSetAlbum.Album[this.BindingSource.Position].PictureFormat;
                    if (strExtension.StartsWith(".") == false)
                    {
                        strExtension = "." + strExtension;
                    }
                    strImageFileName += strExtension;
                }

                this.m_sfdlgPictureExport.FileName = strImageFileName;
                if (this.m_sfdlgPictureExport.ShowDialog() == DialogResult.OK)
                {
                    this.m_picCover.Image.Save(this.m_sfdlgPictureExport.FileName);
                }
            }
        }

        private void m_btnTools_RipCD_Click(object sender, EventArgs e)
        {
            if (this.CurrentAlbum != null)
            {
                string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
                using (BSE.Platten.Ripper.MainForm rippingMain = new BSE.Platten.Ripper.MainForm(this.m_configuration))
                {
                    rippingMain.ProfessionalColorTable = this.ProfessionalColorTable;
                    rippingMain.PanelStyle = this.PanelStyle;
                    rippingMain.PanelColors = this.PanelColors;
                    rippingMain.Icon = this.Icon;
                    rippingMain.Album = this.CurrentAlbum;
                    rippingMain.TrackName = BSE.Platten.BO.Environment.GetDefaultAudioTrackName(this.CurrentAlbum.AlbumId);
                    rippingMain.HomeDirectory = strAudioHomeDirectory;
                    try
                    {
                        if (rippingMain.ShowDialog() == DialogResult.OK)
                        {
                            ImportTracks(rippingMain.ImportTrackCollection);
                        }
                    }
                    catch (Exception exception)
                    {
                        GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void m_btnTools_AudioImport_Click(object sender, EventArgs e)
        {
            if (this.CurrentAlbum != null)
            {
                string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
                using (BSE.Platten.Audio.MainForm audioMain = new BSE.Platten.Audio.MainForm(this.m_configuration, this.CurrentAlbum))
                {
                    audioMain.ProfessionalColorTable = this.ProfessionalColorTable;
                    audioMain.PanelStyle = this.PanelStyle;
                    audioMain.PanelColors = this.PanelColors;
                    audioMain.Icon = this.Icon;
                    audioMain.TrackName = BSE.Platten.BO.Environment.GetDefaultAudioTrackName(this.CurrentAlbum.AlbumId);
                    audioMain.HomeDirectory = strAudioHomeDirectory;
                    try
                    {
                        if (audioMain.ShowDialog(this) == DialogResult.OK)
                        {
                            ImportTracks(audioMain.ImportTrackCollection);
                        }
                    }
                    catch (Exception exception)
                    {
                        GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void m_btnTools_WriteTags_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (this.CurrentAlbum.Tracks != null)
            {
                string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
                Album album = Album.GetAlbumDataByDataRow(this.m_dataSetAlbum.Album[this.BindingSource.Position], strAudioHomeDirectory).Clone() as Album;
                CBSEAdminBusinessObject adminBusinessObject
                    = new CBSEAdminBusinessObject(this.ConnectionString);
                try
                {
                    CGenreData genreData = adminBusinessObject.GetGenreByGenreId(album.GenreId);
                    if (genreData != null)
                    {
                        album.Genre = genreData.Genre;
                    }
                    if (string.IsNullOrEmpty(album.Genre) == true)
                    {
                        album.Genre = string.Empty;
                    }
                    using (BSE.Platten.Audio.TagForm tagger = new BSE.Platten.Audio.TagForm(album))
                    {
                        tagger.ProfessionalColorTable = this.ProfessionalColorTable;
                        tagger.ReadingComplete += new System.EventHandler(TaggerReadingComplete);
                        try
                        {
                            tagger.ShowDialog();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                catch (Exception exception)
                {
                    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TaggerReadingComplete(object sender, EventArgs e)
        {
            BSE.Platten.Audio.TagForm tagger = sender as BSE.Platten.Audio.TagForm;
            if (tagger != null)
            {
                tagger.ReadingComplete -= new System.EventHandler(TaggerReadingComplete);
            }
        }

        private void ImportTracks(List<CTrack> importCollection)
        {
            string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
            if (importCollection != null || importCollection.Count < 0)
            {
                foreach (CTrack track in importCollection)
                {
                    string strFileFullName = track.FileFullName;
                    if (String.IsNullOrEmpty(strFileFullName) == false)
                    {
                        if (strFileFullName.StartsWith(strAudioHomeDirectory))
                        {
                            track.FileFullName = strFileFullName.Remove(0, strAudioHomeDirectory.Length);
                        }
                    }
                    if (UpdateLiederFromImport(track) == false)
                    {
                        CDataRowTracks newDataRow = this.m_dataSetAlbum.Tracks.NewRow();
                        newDataRow.TitelId = this.CurrentAlbum.AlbumId;
                        newDataRow.Track = track.TrackNumber;
                        string strTitle = track.Title as string;
                        if (String.IsNullOrEmpty(strTitle) == false)
                        {
                            newDataRow.Lied = strTitle;
                        }

                        if (track.Duration > TimeSpan.Zero)
                        {
                            newDataRow.Dauer = new DateTime(track.Duration.Ticks);
                        }
                        string strFileName = track.FileFullName as string;
                        if (String.IsNullOrEmpty(strFileName) == false)
                        {
                            newDataRow.Liedpfad = strFileName;
                        }
                        this.m_dataSetAlbum.Tracks.AddRow(newDataRow);
                    }
                }
            }
            SetCurrentAlbum();
        }

        private bool UpdateLiederFromImport(BSE.Platten.BO.CTrack track)
        {
            bool bUpdate = false;
            CDataRowTracks[] dataRows
                = (CDataRowTracks[])this.m_dataSetAlbum.Album[this.BindingSource.Position].GetChildRows(this.m_dataSetAlbum.DataRelation.RelationName);
            foreach (CDataRowTracks dataRow in dataRows)
            {
                if (track.TrackNumber == dataRow.Track)
                {
                    if (dataRow.IsLiedNull() == true)
                    {
                        dataRow.Lied = track.Title;
                    }
                    else
                    {
                        if (dataRow.Lied.Equals(track.Title) == false)
                        {
                            dataRow.Lied = track.Title;
                        }
                    }
                    //if (dataRow.IsDauerNull() == true)
                    //{
                    //    dataRow.Dauer = track.Duration;
                    //}
                    //else
                    //{
                    //    if (dataRow.Dauer.Equals(track.Duration) == false)
                    //    {
                    //        dataRow.Dauer = track.Duration;
                    //    }
                    //}
                    if (dataRow.IsLiedpfadNull() == true)
                    {
                        dataRow.Liedpfad = track.FileFullName;
                    }
                    else
                    {
                        //Beim Import von Freedb- Daten ist der Filename = null
                        if ((dataRow.Liedpfad.Equals(track.FileFullName) == false) && (String.IsNullOrEmpty(track.FileFullName) == false))
                        {
                            dataRow.Liedpfad = track.FileFullName;
                        }
                    }
                    bUpdate = true;
                    break;
                }
            }
            return bUpdate;
        }

        private void OpenOptions()
        {
            try
            {
                using (Options options = new Options(this.m_configuration))
                {
                    options.ConfigurationChanged += new EventHandler(this.OptionsConfigurationChanged);
                    options.AudioPlayerChanged += new EventHandler(this.AudioPlayerChanged);
                    options.ShowDialog(this);
                }
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OptionsConfigurationChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //If the AudioHome Directory has changed
                string strAudioHomeDirectory = this.Environment.GetAudioHomeDirectory();
                if (string.Compare(this.AudioHomeDirectory,strAudioHomeDirectory,StringComparison.OrdinalIgnoreCase) != 0)
                {
                    this.AudioHomeDirectory = strAudioHomeDirectory;
                }
                
                //If the ConnectionString has changed
                string strConnection = this.Environment.GetConnectionString();
                if (string.Compare(this.ConnectionString, strConnection, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    this.ConnectionString = strConnection;
                    if (this.IsHostAvailable(this.Environment) == true)
                    {
                        ResetBinding();
                    }
                    //HostAvailabilityChanged(sender, new HostAvailableEventArgs(base.DatabaseHostAvailability));
                    base.OnHostAvailable(sender, new HostAvailableEventArgs(base.DatabaseHostAvailability));
                }
            }
            catch (BSE.Configuration.ConfigurationValueNotFoundException ex)
            {
                DialogResult dialogResult = GlobalizedMessageBox.Show(this, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    OpenOptions();
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

        private void AudioPlayerChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.m_playerManager.LoadPlayer(this.m_configuration);
            //}
            //catch (Exception exception)
            //{
            //    GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void TracksTableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            CDataRowTracks newRow = (CDataRowTracks)e.Row;
            newRow.Guid = System.Guid.NewGuid().ToString();
        }

        private void TrackChanging(object sender, TrackChangeEventArgs e)
        {
            this.SetPanelInformation(Resources.IDS_FormRecordChangedInformation);
            this.SetUnDo(true);
        }

        private void TrackDeleting(object sender, TrackChangeEventArgs e)
        {
            if (e.Row.IsLiedpfadNull() == false)
            {
                string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
                if (String.IsNullOrEmpty(strAudioHomeDirectory) == false)
                {
                    String[] sourceFiles = new String[1];

                    sourceFiles[0] = strAudioHomeDirectory + e.Row.Liedpfad;
                    try
                    {
                        //nur wenn die Datei existiert wird sie auch gelöscht
                        if (BSE.Platten.Audio.CheckFile.FileExists(sourceFiles[0]))
                        {
                            BSE.Shell.ShellFileOperation shellFileOperation = new BSE.Shell.ShellFileOperation();
                            shellFileOperation.Operation = BSE.Shell.FileOperation.FO_DELETE;
                            shellFileOperation.SourceFiles = sourceFiles;

                            shellFileOperation.DoOperation();
                        }
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                    }
                }
            }
        }

        private void GetRecordSelectedByTitelId(int iTitelId)
        {
            if (ConfirmChanges() == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                OnClearSearch(this, new EventArgs());

                this.BindingSource.PositionChanged -= OnPositionChanged;
                this.m_dataSetAlbum.Album.ColumnChanged -= OnColumnChanged;
                this.m_dataSetAlbum.Tracks.TrackChanging -= new EventHandler<TrackChangeEventArgs>(TrackChanging);
                this.m_dataSetAlbum.Tracks.TrackDeleting -= new EventHandler<TrackChangeEventArgs>(TrackDeleting);

                BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
                try
                {
                    BSE.Platten.BO.CDataSetAlbum dataSet = bseAdminBusinessObject.GetDataSetAlbumByTitelId(iTitelId);
                    this.m_dataSetAlbum.Merge(dataSet);
                    if (this.m_dataSetAlbum.Album.Count > 0)
                    {
                        this.m_dataSetAlbum.AcceptChanges();
                        OnViewStateChanged(this, new ViewStateChangeEventArgs(DataFormViewMode.Select));
                        this.BindingSource.PositionChanged += OnPositionChanged;
                        this.m_dataSetAlbum.Album.ColumnChanged += OnColumnChanged;
                        this.m_dataSetAlbum.Tracks.TrackChanging += new EventHandler<TrackChangeEventArgs>(TrackChanging);
                        this.m_dataSetAlbum.Tracks.TrackDeleting += new EventHandler<TrackChangeEventArgs>(TrackDeleting);
                        base.OnPositionChanged(this, new EventArgs());
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
        }

        private void GetCovers()
        {
            BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
            try
            {
                BSE.Platten.BO.Album[] albumsWithCovers = bseAdminBusinessObject.GetNewestAlbumsWithCovers(20);
                this.m_Covers.LoadCoverBoxes(albumsWithCovers);
                this.m_Covers.Invalidate();
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_Covers_CoverClick(object sender, BSE.Platten.Covers.CoverBoxClickEventArgs e)
        {
            GetRecordSelectedByTitelId(e.TitelId);
        }

        private void GetMedia()
        {
            BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject
                    = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
            try
            {
                Collection<CMediumData> mediaList = bseAdminBusinessObject.GetMedia();
                this.m_cboMedium.DataSource = mediaList;
                this.m_cboMedium.DisplayMember = "Medium";
                this.m_cboMedium.ValueMember = "MediumId";
                this.m_cboMedium.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatentraegerDataChanged(object sender, EventArgs e)
        {
            GetMedia();
        }

        private void GetGenres()
        {
            BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject
                    = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
            try
            {
                Collection<CGenreData> genreList = bseAdminBusinessObject.GetGenres();
                this.m_cboGenre.DataSource = genreList;
                this.m_cboGenre.DisplayMember = "Genre";
                this.m_cboGenre.ValueMember = "GenreId";
                this.m_cboGenre.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenreDataChanged(object sender, EventArgs e)
        {
            GetGenres();
        }

        private void GetInterpreten()
        {
            BSE.Platten.BO.CBSEAdminBusinessObject bseAdminBusinessObject
                    = new BSE.Platten.BO.CBSEAdminBusinessObject(this.ConnectionString);
            try
            {
                Collection<CInterpretData> interpretList = bseAdminBusinessObject.GetInterprets();
                this.m_cboInterpreten.DataSource = interpretList;
                this.m_cboInterpreten.DisplayMember = "Interpret";
                this.m_cboInterpreten.ValueMember = "InterpretId";
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCurrentAlbum()
        {
            this.m_currentAlbum = new BSE.Platten.BO.Album();
            string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.Environment);
            this.m_currentAlbum = Album.GetAlbumDataByDataRow(
                this.m_dataSetAlbum.Album[this.BindingSource.Position],
                strAudioHomeDirectory);

            if (this.Environment.UserGrant.Grant != true)
            {
                return;
            }
            if (this.m_currentAlbum.Cover == null)
            {
                this.m_btnTools_Bildexport.Enabled = this.m_mnuTools_Bildexport.Enabled = false;
            }
            else
            {
                this.m_btnTools_Bildexport.Enabled = this.m_mnuTools_Bildexport.Enabled = true;
            }

            bool bHasRecords = false;
            if (this.m_currentAlbum.Tracks == null)
            {
                this.m_btnTools_WriteTags.Enabled = this.m_mnuTools_WriteTags.Enabled = false;
            }
            else
            {
                foreach (CTrack track in this.m_currentAlbum.Tracks)
                {
                    if (String.IsNullOrEmpty(track.FileFullName) == false)
                    {
                        if (bHasRecords == false)
                        {
                            bHasRecords = true;
                            this.m_btnTools_WriteTags.Enabled = this.m_mnuTools_WriteTags.Enabled = true;
                        }
                    }
                }
            }
        }

        private string GetChangedDataInformation()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            if (this.DataSet.GetChanges() != null)
            {
                stringBuilder.Append(Resources.IDS_FormNotSaveInformation);
                stringBuilder.Append(System.Environment.NewLine);
                if (this.m_dataSetAlbum.Album.GetChanges() != null)
                {
                    stringBuilder.Append(System.Environment.NewLine);
                    stringBuilder.Append(Resources.IDS_FormAdminAlbumChangedInformation);
                    stringBuilder.Append(System.Environment.NewLine);
                    stringBuilder.Append(System.Environment.NewLine);

                    foreach (CDataRowAlbum dataRow in this.m_dataSetAlbum.Album.Rows)
                    {
                        if ((dataRow.RowState == DataRowState.Modified) ||
                            (dataRow.RowState == DataRowState.Added))
                        {
                            stringBuilder.Append(this.m_lblTitel.Text + " " + dataRow.Interpret + " - " + dataRow.Titel);
                            stringBuilder.Append(System.Environment.NewLine);

                            CDataRowTracks[] dataRowTracks = (CDataRowTracks[])dataRow.GetChildRows(this.m_dataSetAlbum.DataRelation.RelationName);
                            foreach (CDataRowTracks dataRowTrack in dataRowTracks)
                            {
                                if (dataRowTrack.RowState == DataRowState.Modified ||
                                    dataRowTrack.RowState == DataRowState.Added)
                                {
                                    stringBuilder.Append(this.m_dgvColumnLied.HeaderText + ": " + dataRowTrack.Track + " " + dataRowTrack.Lied);
                                    stringBuilder.Append(System.Environment.NewLine);
                                }
                            }
                        }
                    }
                }
                stringBuilder.Append(System.Environment.NewLine);
                stringBuilder.Append(Resources.IDS_FormNotSaveConfirmation);
                stringBuilder.Append(System.Environment.NewLine);
            }
            return stringBuilder.ToString();
        }

        private void LoadSettings()
        {
            AdminSettingsData adminSettingsData = new AdminSettingsData();
            //-------------------------------------------------------------------------------
            // Default Values
            //-------------------------------------------------------------------------------
            adminSettingsData.PanelWidthLeft = this.m_pnlLeft.Width;
            adminSettingsData = adminSettingsData.LoadSettings(this, this.m_settings, adminSettingsData) as AdminSettingsData;
            if (adminSettingsData != null)
            {
                //-------------------------------------------------------------------------------
                // Background Image des Contents
                //-------------------------------------------------------------------------------
                this.ContentPanel.BackgroundImage = adminSettingsData.BackgroundImage;
                if (this.ContentPanel.BackgroundImage != null)
                {
                    this.ContentPanel.BackgroundImageLayout = ImageLayout.Tile;
                }
                //-------------------------------------------------------------------------------
                // Zuordnung der Toolstrips zu den Panels
                //-------------------------------------------------------------------------------
                if (adminSettingsData.ToolStripSettingsCollection != null)
                {
                    ToolStripSettingsManager.Load(this.Controls, adminSettingsData.ToolStripSettingsCollection);
                }
                //-------------------------------------------------------------------------------
                // Breite des linken Panels
                //-------------------------------------------------------------------------------
                if (adminSettingsData.PanelWidthLeft > 0)
                {
                    this.m_pnlLeft.Width = adminSettingsData.PanelWidthLeft;
                }
                //-------------------------------------------------------------------------------
                // Spaltenbreite neu setzen.
                //-------------------------------------------------------------------------------
                int iSize = this.m_grdLieder.Columns.Count;
                int[] columnWidths = adminSettingsData.ColumnWidthsLieder;
                if (columnWidths != null)
                {
                    int iSizeIntArray = columnWidths.Length;
                    for (int i = 0; i < iSize; ++i)
                    {
                        if (i < iSizeIntArray)
                        {
                            this.m_grdLieder.Columns[i].Width = columnWidths[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                //-------------------------------------------------------------------------------
                // DisplayIndex des DataGridViews neu setzen.
                //-------------------------------------------------------------------------------
                iSize = this.m_grdLieder.Columns.Count;
                int[] displayIndexes = adminSettingsData.DisplayIndexesLieder;
                if (displayIndexes != null)
                {
                    int iSizeIntArray = displayIndexes.Length;
                    for (int i = 0; i < iSize; ++i)
                    {
                        if (i < iSizeIntArray)
                        {
                            this.m_grdLieder.Columns[i].DisplayIndex = displayIndexes[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void SaveSettings()
        {
            AdminSettingsData adminSettingsData = new AdminSettingsData();
            adminSettingsData.BackgroundImage = this.ContentPanel.BackgroundImage;
            adminSettingsData.ToolStripSettingsCollection = ToolStripSettingsManager.Save(this.Controls);

            int iSize = this.m_grdLieder.Columns.Count;
            int[] columnWiths = new int[iSize];
            int[] displayIndexes = new int[iSize];
            for (int i = 0; i < iSize; ++i)
            {
                columnWiths[i] = this.m_grdLieder.Columns[i].Width;
                displayIndexes[i] = this.m_grdLieder.Columns[i].DisplayIndex;
            }
            adminSettingsData.ColumnWidthsLieder = columnWiths;
            adminSettingsData.DisplayIndexesLieder = displayIndexes;

            if (this.WindowState == FormWindowState.Normal)
            {
                adminSettingsData.PanelWidthLeft = this.m_pnlLeft.Width;
            }

            adminSettingsData.SaveSettings(this, this.m_settings, adminSettingsData);

        }
        
        #endregion

        
    }

    public class AdminSettingsData : BaseFormSettingsData
    {
        #region FieldsPrivate
        /// <summary>
        /// Spaltenbreiten für DataGridView Lieder
        /// </summary>
        private int[] m_iarColumnWidthsDataGridLieder;
        /// <summary>
        /// DisplayIndex für DataGridView Lieder
        /// </summary>
        private int[] m_iarDisplayIndexesDataGridLieder;
        /// <summary>
        /// Höhe des Admin Panels
        /// </summary>
        private int m_iPanelHeightAdmin;
        /// <summary>
        /// Breite des linken Panels
        /// </summary>
        private int m_iPanelLeftWidth;
        /// <summary>
        /// Collection of ToolStripSettings
        /// </summary>
        private System.Collections.ObjectModel.Collection<ToolStripSettings> m_toolStripSettingsCollection;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a collection of ToolStripSettings 
        /// </summary>
        public System.Collections.ObjectModel.Collection<ToolStripSettings> ToolStripSettingsCollection
        {
            get { return this.m_toolStripSettingsCollection; }
            set { this.m_toolStripSettingsCollection = value; }
        }
        /// <summary>
        /// Spaltenbreiten für DataGridView Lieder
        /// </summary>
        /// <value>
        /// Spaltenbreiten für DataGridView Lieder
        /// </value>
        public int[] ColumnWidthsLieder
        {
            get { return this.m_iarColumnWidthsDataGridLieder; }
            set { this.m_iarColumnWidthsDataGridLieder = value; }
        }
        /// <summary>
        /// DisplayIndex für Lieder DataGridView
        /// </summary>
        /// <value>
        /// DisplayIndex für Lieder DataGridView
        /// </value>
        public int[] DisplayIndexesLieder
        {
            get { return this.m_iarDisplayIndexesDataGridLieder; }
            set { this.m_iarDisplayIndexesDataGridLieder = value; }
        }
        /// <summary>
        /// Höhe des Admin Panels
        /// </summary>
        public int PanelHeightAdmin
        {
            get { return this.m_iPanelHeightAdmin; }
            set { this.m_iPanelHeightAdmin = value; }
        }
        /// <summary>
        /// Breite des linken Panels
        /// </summary>
        public int PanelWidthLeft
        {
            get { return this.m_iPanelLeftWidth; }
            set { this.m_iPanelLeftWidth = value; }
        }
        #endregion
    }
}

