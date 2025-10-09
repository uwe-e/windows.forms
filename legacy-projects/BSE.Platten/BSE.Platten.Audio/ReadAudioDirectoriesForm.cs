using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using System.Globalization;
using BSE.Platten.Audio.Properties;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    public partial class ReadAudioDirectoriesForm : BaseForm
    {
        #region Events

        public event EventHandler<ReadDirectoriesEventArgs> FoundDirectory;
        public event EventHandler<ReadFilesEventArgs> FoundFile;
        public event System.EventHandler ReadingComplete;

        #endregion

        #region Delegates

        private delegate void CloseWindowHandler();
        private delegate void WriteCaptionHandler(string strText);

        #endregion

        #region FieldsPrivate

        private System.IO.DirectoryInfo m_directoryInfo;
        private string m_strSearchPattern;
        private bool m_bOnlyScanFolders;
        private ReadDirectoriesAndFiles m_readDirectoriesAndFiles;
        private bool m_bCancelReading;

        #endregion

        #region MethodsPublic

        public ReadAudioDirectoriesForm()
        {
            InitializeComponent();
        }
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public ReadAudioDirectoriesForm(System.IO.DirectoryInfo directoryInfo, string strSearchPattern, bool bOnlyScanFolders)
            : this()
        {
            this.m_directoryInfo = directoryInfo;
            this.m_strSearchPattern = strSearchPattern;
            this.m_bOnlyScanFolders = bOnlyScanFolders;
        }

        #endregion

        #region MethodsPrivate

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (this.m_readDirectoriesAndFiles != null)
            {
                this.m_readDirectoriesAndFiles.CancelRead();
            }
        }
        
        private void CReadAudioDirectories_Load(object sender, EventArgs e)
        {
            if (this.m_bOnlyScanFolders)
            {
                this.m_readDirectoriesAndFiles = new ReadDirectories(this, this.m_strSearchPattern, this.m_directoryInfo);
            }
            else
            {
                this.m_readDirectoriesAndFiles = new ReadFiles(this, this.m_strSearchPattern, this.m_directoryInfo);
            }
            this.m_readDirectoriesAndFiles.CancelReading += new System.EventHandler(
                this.readDirectoriesAndFiles_CancelReading);
            this.m_readDirectoriesAndFiles.ReadingComplete += new System.EventHandler(
                this.readDirectoriesAndFiles_EndReading);
            this.m_readDirectoriesAndFiles.ReadDirectory += new EventHandler<ReadDirectoriesEventArgs>(
                this.ReadDirectoriesAndFiles_ReadDirectory);
            this.m_readDirectoriesAndFiles.FoundDirectory += new EventHandler<ReadDirectoriesEventArgs>(
                this.ReadDirectoriesAndFiles_FoundDirectory);
            this.m_readDirectoriesAndFiles.ReadFile += new EventHandler<ReadFilesEventArgs>(
                this.ReadDirectoriesAndFiles_ReadFile);
            this.m_readDirectoriesAndFiles.FoundFile += new EventHandler<ReadFilesEventArgs>(
                this.ReadDirectoriesAndFiles_FoundFile);
        }

        private void CReadAudioDirectories_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_readDirectoriesAndFiles != null)
            {
                this.m_readDirectoriesAndFiles.CancelRead();
            }
        }

        private void readDirectoriesAndFiles_CancelReading(object sender, System.EventArgs e)
        {
            if (this.m_bCancelReading == false)
            {
                System.Diagnostics.Trace.WriteLine("CReadAudioDirectories - CancelReading");
                this.m_bCancelReading = true;
                this.Invoke(new CloseWindowHandler(CloseWindow));
            }
        }

        private void readDirectoriesAndFiles_EndReading(object sender, System.EventArgs e)
        {
            if (this.ReadingComplete != null)
            {
                this.ReadingComplete(this, e);
            }
            this.Invoke(new CloseWindowHandler(CloseWindow));
        }

        private void ReadDirectoriesAndFiles_ReadDirectory(object sender, ReadDirectoriesEventArgs e)
        {
            //die Caption des Dialogs wird geschrieben
            this.Invoke(new WriteCaptionHandler(WriteCaptionText), e.DirectoryInfo.FullName);
        }

        private void ReadDirectoriesAndFiles_FoundDirectory(object sender, ReadDirectoriesEventArgs e)
        {
            //der Event bei gefundenem Directory wird weitergegeben
            if (this.FoundDirectory != null)
            {
                this.FoundDirectory(sender, e);
            }

        }

        private void ReadDirectoriesAndFiles_ReadFile(object sender, ReadFilesEventArgs e)
        {
            //die Caption des Dialogs wird geschrieben
            this.Invoke(new WriteCaptionHandler(WriteCaptionText), e.FileInfo.FullName);
        }

        private void ReadDirectoriesAndFiles_FoundFile(object sender, ReadFilesEventArgs e)
        {
            //der Event bei gefundenem File wird weitergegeben
            //OnFoundFile(sender, e);
            if (this.FoundFile != null)
            {
                this.FoundFile(sender, e);
            }
        }
        
        private void CloseWindow()
        {
            this.Close();
        }

        private void WriteCaptionText(string strFileOrDirectoryFullName)
        {
            string strCaptionText = string.Format(
                CultureInfo.CurrentUICulture,
                Resources.IDS_ReadAudioDirectoriesRead,
                strFileOrDirectoryFullName);
            //this.Text = strCaptionText;
            this.m_lblReaderMessage.Text = strCaptionText;
        }

        #endregion
        
    }
}