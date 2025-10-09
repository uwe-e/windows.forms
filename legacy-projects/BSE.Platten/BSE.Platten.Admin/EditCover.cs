using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using BSE.Platten.BO;

namespace BSE.Platten.Admin
{
    public partial class EditCover : BaseForm
    {
        #region FieldsPrivate

        private CCoverData m_coverData;
        private bool m_bHasCoverChanged;

        #endregion

        #region Properties

        public CCoverData CoverData
        {
            get { return this.m_coverData; }
        }

        #endregion

        #region MethodsPublic

        public EditCover()
        {
            InitializeComponent();
        }

        public EditCover(CCoverData coverData) : this()
        {
            this.m_coverData = coverData;
            this.m_btnTools_Bildexport.Enabled = false;
            if (this.m_coverData != null)
            {
                this.Text = this.m_coverData.Interpret + " - " + this.m_coverData.Titel;
                if (this.m_coverData.Image != null)
                {
                    this.m_btnTools_Bildexport.Enabled = true;
                    this.m_coverData.ImageFileName = this.m_coverData.Interpret +
                        " " + this.m_coverData.Titel +
                        this.m_coverData.Extension;
                    this.m_picCover.Image = this.m_coverData.Image;
                }
            }
        }

        public bool HasCoverChanged()
        {
            return this.m_bHasCoverChanged;
        }

        #endregion
        
        #region MethodsPrivate
        
        private void m_btnTools_Bildimport_Click(object sender, EventArgs e)
        {
            try
            {
                ImportCover();
            }
            catch (Exception exception)
            {
                GlobalizedMessageBox.Show(this, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_btnTools_Bildexport_Click(object sender, EventArgs e)
        {
            ExportCover();
        }

        private void ImportCover()
        {
            if (this.m_ofdlgPictureImport.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_ofdlgPictureImport.FileName);
                if (CCoverData.IsAllowedCoverExtension(fileInfo.Extension) == true)
                {
                    this.m_picCover.Image = CCoverData.GetImageFromFile(fileInfo);
                    this.m_coverData.Extension = fileInfo.Extension;
                    this.m_coverData.ImageFileName = fileInfo.FullName;
                    this.m_coverData.Image = this.m_picCover.Image;
                    this.m_bHasCoverChanged = true;
                    this.m_btnTools_Bildexport.Enabled = true;
                }
            }
        }

        private void ExportCover()
        {
            if (this.m_picCover.Image != null)
            {
                this.m_sfdlgPictureExport.FileName = this.m_coverData.ImageFileName;
                if (this.m_sfdlgPictureExport.ShowDialog() == DialogResult.OK)
                {
                    this.m_picCover.Image.Save(this.m_sfdlgPictureExport.FileName);
                }
            }
        }
        #endregion
    }
}