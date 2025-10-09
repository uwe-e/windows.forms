using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class CHostBusinessObject
    {
        #region FieldsPrivate

        private string m_strConnection;

        #endregion

        #region MethodsPublic

        public CHostBusinessObject(string strConnection)
        {
            this.m_strConnection = strConnection;
        }

        public bool IsHostAvailable()
        {
            return CHostModel.IsHostAvailable(this.m_strConnection);
        }

        public CUserGrant GetUserGrant(string userName)
        {
            return CHostModel.GetUserGrant(this.m_strConnection, userName);
        }
        #endregion
    }
}
