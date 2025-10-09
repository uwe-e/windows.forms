using System;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CCoversBusinessObject.
	/// </summary>
	public class CCoversBusinessObject
	{
		#region FieldsPrivate
		
		private string m_strConnection;
		
		#endregion

		#region MethodsPublic

		public CCoversBusinessObject(string strConnection)
		{
			this.m_strConnection = strConnection;
		}

		public BSE.Platten.BO.Album[] GetNewestAlbumsWithCovers(int iLimit)
		{
            return CCoversModel.GetNewestAlbumsWithCovers(iLimit, this.m_strConnection);
		}

        public BSE.Platten.BO.Album[] GetNewestAlbumsWithCoverSources(int iLimit)
        {
            return CCoversModel.GetNewestAlbumsWithCoverSources(iLimit, this.m_strConnection);
        }
        /// <summary>
        /// Gets the <see cref="System.Drawing.Image"/> object of an album cover.
        /// </summary>
        /// <param name="iAlbumId">The id of the album.</param>
        /// <returns>The <see cref="System.Drawing.Image"/> object with the album cover.</returns>
        public System.Drawing.Image GetCoverImageByAlbumId(int iAlbumId)
        {
            return CCoversModel.GetCoverImageByAlbumId(iAlbumId, this.m_strConnection);
        }
		#endregion

	}
}
