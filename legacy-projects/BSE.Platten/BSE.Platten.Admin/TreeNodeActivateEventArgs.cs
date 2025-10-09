using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Admin
{
    public class TreeNodeActivateEventArgs : EventArgs
    {
        #region FieldsPrivate

        private Type m_type;

        #endregion

        #region Properties

        public Type Type
        {
            get { return this.m_type; }
        }

        #endregion

        #region MethodsPublic

        public TreeNodeActivateEventArgs(Type type)
		{
            this.m_type = type;
		}

        #endregion
    }
}
