using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
    public class CInterpretBusinessObject
    {
        #region FieldsPrivate

        private string m_strConnection;

        #endregion

        #region MethodsPublic

		public CInterpretBusinessObject(string strConnection)
		{
			this.m_strConnection = strConnection;
		}

        public CDataSetInterpret GetDataSetInterpretByQueryParams(CInterpretData queryParams)
        {
            return CInterpretModel.GetDataSetInterpretByQueryParams(this.m_strConnection, queryParams);
        }

        public DataSet Update(DataSet dataSet)
        {
            CInterpretModel interpretBusinessModel = new CInterpretModel();
            return interpretBusinessModel.Update(this.m_strConnection, dataSet);
        }

        public Collection<CInterpretData> GetInterprets()
        {
            return CInterpretModel.GetInterprets(this.m_strConnection);
        }

        #endregion
    }
}
