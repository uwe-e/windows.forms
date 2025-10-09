using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Admin
{
    public class ViewStateChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private DataFormViewMode m_eDataFormViewMode;

        #endregion

        #region Properties

        public DataFormViewMode DataFormViewMode
        {
            get { return this.m_eDataFormViewMode; }
        }

        #endregion

        #region MethodsPublic

        public ViewStateChangeEventArgs(DataFormViewMode dataFormViewMode) : base()
        {
            this.m_eDataFormViewMode = dataFormViewMode;
        }
        #endregion
    }
}
