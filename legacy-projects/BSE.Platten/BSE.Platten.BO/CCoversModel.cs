using System;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;

namespace BSE.Platten.BO
{
	/// <summary>
	/// Zusammenfassung für CCoversBusinessModel.
	/// </summary>
	public class CCoversModel : ModelSql
	{
		#region MethodsPublic

        public static BSE.Platten.BO.Album[] GetNewestAlbumsWithCoverSources(int iLimit, string strConnection)
        {
            BSE.Platten.BO.Album[] albums = null;
            System.Collections.ArrayList albumList = new System.Collections.ArrayList();

            string strSelectSql = "SELECT t.titelid,i.interpret,t.titel," +
                " g.Genre,t.erschdatum,m.medium,t.thumbnail FROM platten.titel t" +
                " JOIN platten.interpreten i ON t.interpretid = i.interpretid" +
                " LEFT JOIN platten.medium m ON t.mediumId = m.mediumId " +
                " LEFT JOIN platten.genre g ON t.genreid = g.genreid" +
                " WHERE t.cover is not null " +
                " ORDER BY t.titelid DESC limit ?iLimit";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("iLimit", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.Value = iLimit;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            BSE.Platten.BO.Album album = new BSE.Platten.BO.Album();

                            album.AlbumId = GetInt32(mySqlDataReader, "titelid", false, album.AlbumId);
                            album.Interpret = GetString(mySqlDataReader, "interpret", false, album.Interpret);
                            album.Title = GetString(mySqlDataReader, "titel", false, album.Title);
                            album.Medium = GetString(mySqlDataReader, "medium", true, album.Medium);
                            album.Year = GetInt32(mySqlDataReader, "erschdatum", true, album.Year);
                            album.Genre = GetString(mySqlDataReader, "genre", true, album.Genre);

                            byte[] cover = GetBytes(mySqlDataReader, "thumbnail", true, null);
                            if (cover != null)
                            {
                                album.CoverSource = CCoverData.GetBitmapSourceFromBytes(cover);
                                album.CoverSource.Freeze();
                            }
                            albumList.Add(album);
                        }
                        albums = new BSE.Platten.BO.Album[albumList.Count];
                        albumList.CopyTo(albums);
                    }
                }
            }
            return albums;
        }

		public static BSE.Platten.BO.Album[] GetNewestAlbumsWithCovers(int iLimit,string strConnection)
		{
			BSE.Platten.BO.Album[] albums = null;
			System.Collections.ArrayList albumList = new System.Collections.ArrayList();
			
			string strSelectSql = "SELECT t.titelid,i.interpret,t.titel," +
                " g.Genre,t.erschdatum,m.medium,t.cover FROM platten.titel t" +
				" JOIN platten.interpreten i ON t.interpretid = i.interpretid" +
				" LEFT JOIN platten.medium m ON t.mediumId = m.mediumId " +
				" LEFT JOIN platten.genre g ON t.genreid = g.genreid" +				
				" WHERE t.cover is not null " +
				" ORDER BY t.titelid DESC limit ?iLimit";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("iLimit", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.Value = iLimit;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            BSE.Platten.BO.Album album = new BSE.Platten.BO.Album();

                            album.AlbumId = GetInt32(mySqlDataReader, "titelid", false, album.AlbumId);
                            album.Interpret = GetString(mySqlDataReader, "interpret", false, album.Interpret);
                            album.Title = GetString(mySqlDataReader, "titel", false, album.Title);
                            album.Medium = GetString(mySqlDataReader, "medium", true, album.Medium);
                            album.Year = GetInt32(mySqlDataReader, "erschdatum", true, album.Year);
                            album.Genre = GetString(mySqlDataReader, "genre", true, album.Genre);

                            //byte[] cover = GetBytes(mySqlDataReader, "thumbnail", true, null);
                            //if (cover != null)
                            //{
                            //    album.CoverSource = CCoverData.GetBitmapSourceFromBytes(cover);
                            //    album.CoverSource.Freeze();
                            //}

                            byte[] bytesThumbNail = GetBytes(mySqlDataReader, "cover", true, new byte[0]);
                            if (bytesThumbNail.Length > 0)
                            {
                                using (System.Drawing.Image imgCover = System.Drawing.Bitmap.FromStream(new System.IO.MemoryStream((byte[])bytesThumbNail)))
                                {
                                    album.Thumbnail = imgCover.GetThumbnailImage(album.ThumbnailSize.Width, album.ThumbnailSize.Height, null, IntPtr.Zero);
                                }
                            }
                            albumList.Add(album);
                        }
                        albums = new BSE.Platten.BO.Album[albumList.Count];
                        albumList.CopyTo(albums);
                    }
                }
            }
			return albums;
		}
        /// <summary>
        /// Gets the <see cref="System.Drawing.Image"/> object of an album cover.
        /// </summary>
        /// <param name="iAlbumId">The id of the album.</param>
        /// <param name="strConnection">The connection string to the database.</param>
        /// <returns>The <see cref="System.Drawing.Image"/> object with the album cover.</returns>
        public static System.Drawing.Image GetCoverImageByAlbumId(int iAlbumId, string strConnection)
        {
            System.Drawing.Image coverImage = null;
            string strSelectSQL = "SELECT t.cover FROM titel t" +
                " WHERE t.titelid = ?TitelId";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelId", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "titelid";
                    mySqlParameter.Value = iAlbumId;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            coverImage = CCoverData.GetImageFromDbReader(mySqlDataReader, "cover");
                        }
                    }
                }
            }
            return coverImage;
        }
		#endregion

	}
}
