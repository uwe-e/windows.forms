using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;

namespace BSE.Platten.FreeDb
{
    public partial class SelectCD : BaseForm
    {
        #region FieldsPrivate

        private string m_strSelectedCd;

        #endregion

        #region Properties

        public string SelectedCD
        {
            get { return this.m_strSelectedCd; }
        }

        #endregion

        #region MethodsPublic

        public SelectCD()
        {
            InitializeComponent();
        }

        public SelectCD(ArrayList arrayCDSelection) : this()
		{
			this.m_btnOK.Enabled = false;
			GetCDSelection(arrayCDSelection);
        }

        #endregion

        #region MethodsPrivate

        private void m_lstvSelectCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_btnOK.Enabled = false;
            if (this.m_lstvSelectCD.SelectedIndices.Count > 0)
            {
                this.m_btnOK.Enabled = true;
            }
        }
        
        private void m_lstvSelectCD_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 2))
            {
                ListViewItem listViewItem = this.m_lstvSelectCD.GetItemAt(e.X, e.Y) as ListViewItem;
                if (listViewItem != null)
                {
                    this.m_strSelectedCd = listViewItem.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            if (this.m_lstvSelectCD.SelectedItems.Count > 0)
            {
                this.m_strSelectedCd = this.m_lstvSelectCD.SelectedItems[0].Text;
            }
        }
        
        private void GetCDSelection(ArrayList arrayCDSelection)
        {
            ColumnHeader freeDbHeader = new ColumnHeader();
            freeDbHeader.Width = m_lstvSelectCD.Width - (2 * SystemInformation.Border3DSize.Width);
            for (int i = 0; i < arrayCDSelection.Count - 1; i++)
            {
                if (i == 0)
                {
                    freeDbHeader.Text = arrayCDSelection[i].ToString();
                    this.m_lstvSelectCD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   freeDbHeader});
                }
                else
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = arrayCDSelection[i].ToString();
                    this.m_lstvSelectCD.Items.Add(listViewItem);
                }
            }
        }

        #endregion
        
    }
}