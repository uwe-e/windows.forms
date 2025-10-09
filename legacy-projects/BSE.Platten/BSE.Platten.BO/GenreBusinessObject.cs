using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
    public class CGenreBusinessObject
    {
        #region FieldsPrivate

        private string m_strConnection;

        #endregion

        #region MethodsPublic

        public CGenreBusinessObject(string strConnection)
        {
            this.m_strConnection = strConnection;
        }

        public CDataSetGenre GetDataSetGenreByQueryParams(CGenreData queryParams)
        {
            return CGenreModel.GetDataSetGenreByQueryParams(this.m_strConnection, queryParams);
        }

        public DataSet Update(DataSet dataSet)
        {
            CGenreModel genreBusinessModel = new CGenreModel();
            return genreBusinessModel.Update(this.m_strConnection, dataSet);
        }

        public Collection<CGenreData> GetGenres()
        {
            return CGenreModel.GetGenres(this.m_strConnection);
        }
        public CGenreData GetGenreByGenreId(int iGenreId)
        {
            return CGenreModel.GetGenreByGenreId(this.m_strConnection, iGenreId);
        }
        #endregion
    }
}
