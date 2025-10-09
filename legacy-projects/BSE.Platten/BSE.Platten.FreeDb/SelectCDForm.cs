using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BSE.Platten.Common;
using System.Collections.ObjectModel;
using System.Globalization;

namespace BSE.Platten.FreeDb
{
    public partial class SelectCDForm : BaseForm
    {
        #region Properties
        public string SelectedCD
        {
            get;
            private set;
        }
        #endregion

        #region MethodsPublic
        public SelectCDForm()
        {
            InitializeComponent();
        }
        public SelectCDForm(Collection<string> freeDBResponse)
            : this()
		{
			this.m_btnOK.Enabled = false;
            GetCDSelection(freeDBResponse);
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
                    this.SelectedCD = listViewItem.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        
        private void m_btnOK_Click(object sender, EventArgs e)
        {
            if (this.m_lstvSelectCD.SelectedItems.Count > 0)
            {
                this.SelectedCD = this.m_lstvSelectCD.SelectedItems[0].Text;
            }
        }

        private void GetCDSelection(Collection<string> freeDbResponse)
        {
            for (int i = 1; i < freeDbResponse.Count - 1; i++)
            {
                string strResponse = freeDbResponse[i];
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = strResponse;
                this.m_lstvSelectCD.Items.Add(listViewItem);
            }
        }
        private void FormLoad(object sender, EventArgs e)
        {
            this.m_columnHeader.Width = m_lstvSelectCD.Width - (2 * SystemInformation.Border3DSize.Width);
        }
        #endregion

        
        
    }
}