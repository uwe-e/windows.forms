using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.BO;
using BSE.Platten.Common;
using BSE.Platten.Audio;
using System.Globalization;
using BSE.Platten.Admin.Properties;

namespace BSE.Platten.Admin
{
    public partial class EditLieder : BaseForm
    {
        #region FieldsPrivate

        private CDataRowTracks m_dataRowTracksOriginal;
        private CDataRowTracks m_dataRowTracksClone;
        private BSE.Platten.BO.Environment m_environment;


        #endregion

        #region MethodsPublic

        public EditLieder()
        {
            InitializeComponent();
        }

        public EditLieder(CDataRowTracks dataRowTracks, BSE.Platten.BO.Environment environment)
            : this()
        {
            if (dataRowTracks == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "dataRowTracks"));
            }

            if (environment == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "environment"));
            }

            this.m_dataRowTracksOriginal = dataRowTracks;
            this.m_dataRowTracksClone = (CDataRowTracks)dataRowTracks.Clone();
            this.m_environment = environment;

            this.m_txtLiedId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_dataRowTracksClone, "LiedId", true));
            this.m_txtTrack.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_dataRowTracksClone, "Track", true));
            this.m_txtLied.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.m_dataRowTracksClone, "Lied", true));
            if (this.m_dataRowTracksClone.IsDauerNull() == false)
            {
                this.m_txtDuration.DataBindings.Add("Text", this.m_dataRowTracksClone, "Dauer", true, System.Windows.Forms.DataSourceUpdateMode.Never, null, "T",CultureInfo.InvariantCulture);
            }
            if (this.m_dataRowTracksClone.IsLiedpfadNull() == false)
            {
                this.m_txtFile.DataBindings.Add("Text", this.m_dataRowTracksClone, "Liedpfad", true);
                this.m_txtFile.DataBindings[0].Format += new ConvertEventHandler(ChangeFileFormat);
            }
        }

        #endregion

        #region MethodsPrivate

        private void ChangeFileFormat(object sender, ConvertEventArgs e)
        {
            string tmpString = e.Value.ToString();
            if (string.IsNullOrEmpty(tmpString) == true)
            {
                return;
            }
            string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.m_environment);
                        tmpString = strAudioHomeDirectory + tmpString;
            try
            {
                CheckFile.FileExists(tmpString);
            }
            catch (System.IO.FileNotFoundException FileNotFoundException)
            {
                this.m_errorProvider.SetError(this.m_txtFile, FileNotFoundException.Message);
            }
            e.Value = tmpString;
        }
        
        private void FindFileClick(object sender, EventArgs e)
        {
            string strFileName = this.m_txtFile.Text;
            string strDirectoryName = strFileName;
            if (string.IsNullOrEmpty(strFileName) == false)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(strFileName);
                strDirectoryName = fileInfo.DirectoryName;
            }
            
            this.m_txtFile.TextChanged -= new System.EventHandler(FileTextChanged);
            this.m_ofdlgFileImport.InitialDirectory = strDirectoryName;
            this.m_ofdlgFileImport.CheckFileExists = true;
            this.m_ofdlgFileImport.CheckPathExists = true;
            this.m_ofdlgFileImport.RestoreDirectory = false;
            if (this.m_ofdlgFileImport.ShowDialog() == DialogResult.OK)
            {
                string strFileFullName = this.m_ofdlgFileImport.FileName;
                this.m_txtFile.TextChanged += new System.EventHandler(FileTextChanged);

                AudioData audioData = new WMFMediaData();
                AudioMetadata audioMetaData = audioData.GetMediaMetadata(strFileFullName);
                if (string.IsNullOrEmpty(audioMetaData.Title) == false)
                {
                    this.m_txtLied.Text = audioMetaData.Title;
                }
                this.m_txtDuration.Text = audioMetaData.Duration.ToString();
                this.m_txtFile.Text = strFileFullName;
            }
        }
        
        private void FileTextChanged(object sender, EventArgs e)
        {
            string strFileFullName = this.m_txtFile.Text;
            string strAudioHomeDirectory = Album.GetAudioHomeDirectory(this.m_environment);
            try
            {
                CheckFile.FileExists(strFileFullName);
                this.m_errorProvider.SetError(this.m_txtFile, "");
            }
            catch (System.IO.FileNotFoundException fileNotFoundException)
            {
                this.m_errorProvider.SetError(this.m_txtFile, fileNotFoundException.Message);
            }
            if (strFileFullName.StartsWith(strAudioHomeDirectory, StringComparison.OrdinalIgnoreCase))
            {
                strFileFullName = strFileFullName.Remove(0, strAudioHomeDirectory.Length);
            }
            this.m_dataRowTracksClone.Lied = this.m_txtLied.Text;
            if (String.IsNullOrEmpty(this.m_txtDuration.Text) == false)
            {
                this.m_dataRowTracksClone.Dauer = Convert.ToDateTime(this.m_txtDuration.Text,CultureInfo.InvariantCulture);
            }
            this.m_dataRowTracksClone.Liedpfad = strFileFullName;
        }

        private void BtnOKClick(object sender, EventArgs e)
        {
            if (this.m_dataRowTracksClone.Equals(this.m_dataRowTracksOriginal) == false)
            {
                if (this.m_dataRowTracksOriginal.IsLiedNull() == true)
                {
                    this.m_dataRowTracksOriginal.Lied = this.m_dataRowTracksClone.Lied;
                }
                else
                {
                    if (this.m_dataRowTracksOriginal.Lied.Equals(this.m_dataRowTracksClone.Lied) == false)
                    {
                        this.m_dataRowTracksOriginal.Lied = this.m_dataRowTracksClone.Lied;
                    }
                }
                if (this.m_dataRowTracksOriginal.IsDauerNull() == true)
                {
                    this.m_dataRowTracksOriginal.Dauer = this.m_dataRowTracksClone.Dauer;
                }
                else
                {
                    if (this.m_dataRowTracksOriginal.Dauer.Equals(this.m_dataRowTracksClone.Dauer) == false)
                    {
                        this.m_dataRowTracksOriginal.Dauer = this.m_dataRowTracksClone.Dauer;
                    }
                }
                if (this.m_dataRowTracksOriginal.IsLiedpfadNull() == true)
                {
                    this.m_dataRowTracksOriginal.Liedpfad = this.m_dataRowTracksClone.Liedpfad;
                }
                else
                {
                    if (this.m_dataRowTracksOriginal.Liedpfad.Equals(this.m_dataRowTracksClone.Liedpfad) == false)
                    {
                        this.m_dataRowTracksOriginal.Liedpfad = this.m_dataRowTracksClone.Liedpfad;
                    }
                }
            }
        }

        #endregion

    }
}