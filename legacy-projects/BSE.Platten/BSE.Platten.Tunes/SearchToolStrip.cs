using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BSE.Platten.Tunes
{
    public partial class SearchToolStrip : ToolStrip
    {
        #region Events

        public event EventHandler<SearchExecuteEventArgs> SearchExecuting;

        #endregion

        #region MethodsPublic

        public SearchToolStrip()
        {
            InitializeComponent();
        }

        public void SetSearchTerm(string strSearchTerm)
        {
            this.m_txtSearch.Text = strSearchTerm;
            this.m_txtSearch.SelectAll();
        }

        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate

        private void btnSearchClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.m_txtSearch.Text) == false)
            {
                if (SearchExecuting != null)
                {
                    SearchExecuting(sender, new SearchExecuteEventArgs(this.m_txtSearch.Text));
                }
            }
        }

        private void txtSearchKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.btnSearchClick(this, new System.EventArgs());
                    break;
            }
        }

        #endregion
    }
}
