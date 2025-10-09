using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Tunes
{
    public class SearchExecuteEventArgs : EventArgs
    {
        #region FieldsPrivate

        private string m_strSearchTerm;

        #endregion

        #region Properties

        public string SearchTerm
        {
            get { return this.m_strSearchTerm; }
        }

        #endregion

        #region MethodsPublic

        public SearchExecuteEventArgs(string strSearchTerm)
        {
            this.m_strSearchTerm = strSearchTerm;
        }

        #endregion
    }
}
