using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
    public class CMediumBusinessObject
    {
        #region FieldsPrivate

        private string m_strConnection;

        #endregion

        #region MethodsPublic

        public CMediumBusinessObject(string strConnection)
        {
            this.m_strConnection = strConnection;
        }
        public CDataSetMedium GetDataSetByQueryParams(CMediumData queryParams)
        {
            return CMediumModel.GetDataSetByQueryParams(this.m_strConnection, queryParams);
        }
        public DataSet Update(DataSet dataSet)
        {
            CMediumModel mediumBusinessModel = new CMediumModel();
            return mediumBusinessModel.Update(this.m_strConnection, dataSet);
        }
        public Collection<CMediumData> GetMedia()
        {
            return CMediumModel.GetMedia(this.m_strConnection);
        }

        #endregion
    }
}
