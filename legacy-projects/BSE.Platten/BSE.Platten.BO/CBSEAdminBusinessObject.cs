using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
    public class CBSEAdminBusinessObject
    {
        #region FieldsPrivate

        private string m_strConnection;

        #endregion

        #region MethodsPublic

        public CBSEAdminBusinessObject(string strConnection)
        {
            this.m_strConnection = strConnection;
        }

        #region Albums

        public CDataSetAlbum GetDataSetAlbumByQueryParams(Album queryParamsAlbum)
        {
            return CBSEAdminModel.GetDataSetAlbumByQueryParams(this.m_strConnection, queryParamsAlbum);
        }

        public CDataSetAlbum GetDataSetAlbumByTitelId(int iTitelId)
        {
            return CBSEAdminModel.GetDataSetAlbumByTitelId(this.m_strConnection, iTitelId);
        }

        public DataSet Update(DataSet dataSet)
        {
            CBSEAdminModel bseAdminBusinessModel = new CBSEAdminModel();
            return bseAdminBusinessModel.Update(this.m_strConnection, dataSet);
        }

        public CGenreData GetGenreByGenreId(int iGenreId)
        {
            CGenreBusinessObject genreBusinessObject = new CGenreBusinessObject(
                this.m_strConnection);
            return genreBusinessObject.GetGenreByGenreId(iGenreId);
        }

        #endregion

        #region Interprets

        public Collection<CInterpretData> GetInterprets()
        {
            CInterpretBusinessObject interpretBusinessObject = new CInterpretBusinessObject(this.m_strConnection);
            return interpretBusinessObject.GetInterprets();
        }

        #endregion

        #region Media(Datenträger)

        public Collection<CMediumData> GetMedia()
        {
            CMediumBusinessObject mediumBusinessObject = new CMediumBusinessObject(this.m_strConnection);
            return mediumBusinessObject.GetMedia();
        }

        #endregion

        #region Genre

        public Collection<CGenreData> GetGenres()
        {
            CGenreBusinessObject genreBusinessObject = new CGenreBusinessObject(this.m_strConnection);
            return genreBusinessObject.GetGenres();
        }

        #endregion

        #region Host

        public bool IsHostAvailable()
        {
            CHostBusinessObject hostBusinessObject = new CHostBusinessObject(this.m_strConnection);
            return hostBusinessObject.IsHostAvailable();
        }

        public CUserGrant GetUserGrant(string userName)
        {
            CHostBusinessObject hostBusinessObject = new CHostBusinessObject(this.m_strConnection);
            return hostBusinessObject.GetUserGrant(userName);
        }

        #endregion

        #region Covers

        public BSE.Platten.BO.Album[] GetNewestAlbumsWithCovers(int iLimit)
        {
            CCoversBusinessObject coversBusinessObject
                = new CCoversBusinessObject(this.m_strConnection);
            return coversBusinessObject.GetNewestAlbumsWithCovers(iLimit);
        }
        
        #endregion
        #endregion
    }
}
