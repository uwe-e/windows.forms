using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Globalization;
using BSE.Platten.BO.Properties;
using System.Collections.ObjectModel;

namespace BSE.Platten.BO
{
    public class CTunesModel : ModelSql
    {
        #region MethodsPublic
        #region Albums

        public static Album GetAlbumById(string strConnection, int iTitelId)
        {
            Album album = null;

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                album = GetAlbumDetailByTitelId(iTitelId, mySqlConnection);
                album = GetAlbumTracksByTitelId(album, mySqlConnection);
            }
            return album;
        }

        public static CTrack GetTrackWithThumbNailById(string strConnection, CTrack track)
        {
            if (track == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "track"));
            }
            
            string strSelectSQL = "SELECT t.thumbnail FROM titel t" +
                " WHERE t.titelid = ?TitelId";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelId", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "titelid";
                    mySqlParameter.Value = track.TitelId;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            track.ThumbNail = CCoverData.GetImageFromDbReader(mySqlDataReader, "thumbnail");
                        }
                    }
                }
            }
            return track;
        }

        #endregion

        #region Trees

        public static CInterpretData[] GetInterpretsAndAlbums(string strConnection)
        {
            string strDataRelationName = "dataRelationInterpretAlbums";
            CInterpretData[] interprets = null;

            DataSet dataSetInterpretsAndAlbums = GetInterpretsAndAlbumsAsDataSet(strDataRelationName, strConnection);
            int iInterpretsCount = dataSetInterpretsAndAlbums.Tables["Interpret"].Rows.Count;
            interprets = new BSE.Platten.BO.CInterpretData[iInterpretsCount];

            for (int i = 0; i < iInterpretsCount; i++)
            {
                DataRow dataRowInterprets = dataSetInterpretsAndAlbums.Tables["Interpret"].Rows[i];
                interprets[i] = new CInterpretData();
                interprets[i].InterpretId = (int)dataRowInterprets["interpretid"];
                interprets[i].Interpret = dataRowInterprets["interpret"].ToString();

                DataRow[] dataRowsAlbums = dataRowInterprets.GetChildRows(strDataRelationName);
                int iAlbumsCount = dataRowsAlbums.Length;
                if (iAlbumsCount > 0)
                {
                    Album[] albums = new Album[iAlbumsCount];
                    for (int j = 0; j < iAlbumsCount; j++)
                    {
                        DataRow dataRowAlbums = dataRowsAlbums[j];
                        albums[j] = new Album();
                        albums[j].AlbumId = (int)dataRowAlbums["titelid"];
                        albums[j].Title = dataRowAlbums["titel"].ToString();
                        if (dataRowAlbums["thumbnail"] != System.DBNull.Value)
                        {
                            albums[j].CoverSource = CCoverData.GetBitmapSourceFromBytes((byte[])dataRowAlbums["thumbnail"]);
                        }
                        albums[j].InterpretId = (int)dataRowAlbums["interpretid"];
                    }
                    interprets[i].Albums = albums;
                }
            }
            return interprets;
        }

        public static BSE.Platten.BO.CGenreData[] GetGenresWithAlbums(string strConnection)
        {
            string strDataRelationName = "dataRelationGenreAlbums";
            BSE.Platten.BO.CGenreData[] genre = null;

            DataSet dataSetGenresWithAlbums = GetGenresWithAlbumsAsDataSet(strDataRelationName, strConnection);
            int iGenresCount = dataSetGenresWithAlbums.Tables["Genre"].Rows.Count;
            genre = new BSE.Platten.BO.CGenreData[iGenresCount];

            for (int i = 0; i < iGenresCount; i++)
            {
                DataRow dataRowGenre = dataSetGenresWithAlbums.Tables["Genre"].Rows[i];
                genre[i] = new CGenreData();
                genre[i].GenreId = Convert.ToInt32(dataRowGenre["genreid"],CultureInfo.InvariantCulture);
                genre[i].Genre = dataRowGenre["genre"].ToString();

                DataRow[] dataRowsAlbums = dataRowGenre.GetChildRows(strDataRelationName);
                int iAlbumsCount = dataRowsAlbums.Length;
                if (iAlbumsCount > 0)
                {
                    Album[] albums = new Album[iAlbumsCount];
                    for (int j = 0; j < iAlbumsCount; j++)
                    {
                        DataRow dataRowAlbums = dataRowsAlbums[j];
                        albums[j] = new Album();
                        albums[j].AlbumId = (int)dataRowAlbums["titelid"];
                        albums[j].Interpret = dataRowAlbums["interpret"].ToString();
                        albums[j].Title = dataRowAlbums["titel"].ToString();
                    }
                    genre[i].Albums = albums;
                }
            }
            return genre;
        }

        public static BSE.Platten.BO.CYearData[] GetYearsWithAlbums(string strConnection)
        {
            string strDataRelationName = "dataRelationYearAlbums";
            BSE.Platten.BO.CYearData[] years = null;

            DataSet dataSetYearsWithAlbums = GetYearsWithAlbumsAsDataSet(strDataRelationName, strConnection);
            int iYearsCount = dataSetYearsWithAlbums.Tables["Year"].Rows.Count;
            years = new BSE.Platten.BO.CYearData[iYearsCount];

            for (int i = 0; i < iYearsCount; i++)
            {
                DataRow dataRowYear = dataSetYearsWithAlbums.Tables["Year"].Rows[i];
                years[i] = new CYearData();
                years[i].Year = Convert.ToInt32(dataRowYear["erschdatum"],CultureInfo.InvariantCulture);

                DataRow[] dataRowsAlbums = dataRowYear.GetChildRows(strDataRelationName);
                int iAlbumsCount = dataRowsAlbums.Length;
                if (iAlbumsCount > 0)
                {
                    Album[] albums = new Album[iAlbumsCount];
                    for (int j = 0; j < iAlbumsCount; j++)
                    {
                        DataRow dataRowAlbums = dataRowsAlbums[j];
                        albums[j] = new Album();
                        albums[j].AlbumId = (int)dataRowAlbums["titelid"];
                        albums[j].Interpret = dataRowAlbums["interpret"].ToString();
                        albums[j].Title = dataRowAlbums["titel"].ToString();
                    }
                    years[i].Albums = albums;
                }
            }
            return years;
        }

        #endregion

        #region Favorites

        public static CFavorite[] GetFavoritesByFavoritId(int iLimit, int iFavoriteId, string strBenutzer, string strConnection)
        {
            CFavorite[] favorites = null;
            ArrayList aFavorites = new ArrayList();
            string strSelectSql = string.Empty;
            switch (iFavoriteId)
            {
                case 1:
                    //Lieder
                    strSelectSql = "SELECT Count(*) AS anzahl,h.titelid,h.liedid,i.interpret,t.titel,l.lied" +
                        " FROM history h" +
                        " JOIN titel t ON h.titelid = t.titelid" +
                        " JOIN interpreten i ON t.interpretid = i.interpretid" +
                        " LEFT JOIN lieder l ON h.liedid = l.liedid" +
                        " WHERE h.appid = ?AppId" +
                        " AND h.benutzer = ?Benutzer" +
                        " GROUP BY h.titelid,h.liedid" +
                        " ORDER BY anzahl desc" +
                        " LIMIT " + iLimit;
                    break;
                case 2:
                    //Alben
                    strSelectSql = "SELECT Count(*) AS anzahl,h.titelid,i.interpret,t.titel,l.lied" +
                        " FROM history h" +
                        " JOIN titel t ON h.titelid = t.titelid" +
                        " JOIN interpreten i ON t.interpretid = i.interpretid" +
                        " LEFT JOIN lieder l ON h.liedid = l.liedid" +
                        " WHERE h.appid = ?AppId" +
                        " AND h.benutzer = ?Benutzer" +
                        " GROUP BY h.titelid" +
                        " ORDER BY anzahl desc" +
                        " LIMIT " + iLimit;
                    break;
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    MySqlParameter mySqlParameterPlayerApp = mySqlCommand.Parameters.Add(new MySqlParameter("AppId", MySqlDbType.Int32, 0));
                    mySqlParameterPlayerApp.Direction = ParameterDirection.Input;
                    mySqlParameterPlayerApp.SourceColumn = "AppID";
                    mySqlParameterPlayerApp.Value = iFavoriteId;

                    MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("Benutzer", MySqlDbType.VarChar, 0));
                    mySqlParameterUser.Direction = ParameterDirection.Input;
                    mySqlParameterUser.SourceColumn = "Benutzer";
                    mySqlParameterUser.Value = strBenutzer;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            CFavorite favorite = new CFavorite();
                            //MySQL returns a count of the number of non-NULL values in the rows retrieved by a SELECT statement.
                            //The result is a BIGINT value. 
                            favorite.Count = Convert.ToInt32(GetInt64(mySqlDataReader, "Anzahl", true, favorite.Count));
                            favorite.TitelId = GetInt32(mySqlDataReader, "TitelId", false, favorite.TitelId);
                            favorite.Interpret = GetString(mySqlDataReader, "Interpret", false, favorite.Interpret);
                            favorite.Album = GetString(mySqlDataReader, "Titel", false, favorite.Album);
                            favorite.Title = GetString(mySqlDataReader, "Lied", true, favorite.Title);
                            aFavorites.Add(favorite);
                        }
                    }
                    favorites = new CFavorite[aFavorites.Count];
                    aFavorites.CopyTo(favorites);
                }
            }
            return favorites;
        }

        #endregion

        #region FullTextSearch

        public static SortableCollection<CTrack> GetFullTextSearchCollection(string strSearchstring, string strConnection)
        {
            SortableCollection<CTrack> trackCollection = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                trackCollection = new SortableCollection<CTrack>();
                trackCollection = GetFullTextSearchForTitleAndInterpretsCollection(strSearchstring, trackCollection, mySqlConnection);
                trackCollection = GetFullTextSearchForTitlesCollection(strSearchstring, trackCollection, mySqlConnection);
            }
            return trackCollection;
        }

        #endregion

        #region PlayList

        public static BSE.Platten.BO.CTrack[] GetAlbumTracksForPlayListByTitelId(string strConnection, int iTitelId)
        {
            BSE.Platten.BO.CTrack[] tracks = null;
            ArrayList albumTracks = new ArrayList();
            string strSelectSQL = "Select i.interpret,t.titelid,t.titel,t.erschdatum," +
                " g.genre,l.liedid,l.titelid,l.track,l.lied," +
                " l.dauer,l.liedpfad FROM lieder l" +
                " JOIN titel t ON l.titelid = t.titelid AND t.titelid = ?TitelID" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " LEFT JOIN genre g ON t.genreid = g.genreid" +
                " WHERE l.liedpfad IS NOT NULL" +
                " ORDER BY l.track";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "TitelID";
                    mySqlParameter.Value = iTitelId;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            BSE.Platten.BO.CTrack track = new BSE.Platten.BO.CTrack();

                            track.TitelId = GetInt32(mySqlDataReader, "titelid", false, track.TitelId);
                            track.Interpret = GetString(mySqlDataReader, "interpret", false, track.Interpret);
                            track.Album = GetString(mySqlDataReader, "titel", false, track.Album);
                            track.Genre = GetString(mySqlDataReader, "genre", true, track.Genre);
                            track.Year = GetInt32(mySqlDataReader, "erschdatum", true, track.Year);
                            track.LiedId = GetInt32(mySqlDataReader, "liedid", false, track.LiedId);
                            track.TrackNumber = GetInt32(mySqlDataReader, "track", false, track.TrackNumber);
                            track.Title = GetString(mySqlDataReader, "lied", false, track.Title);
                            //track.Duration = GetDateTime(mySqlDataReader, "dauer", false, track.Duration);
                            track.Duration = GetTimeSpan(mySqlDataReader, "dauer", false, track.Duration);
                            track.FileName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);
                            track.FileFullName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);

                            albumTracks.Add(track);
                        }
                    }
                    tracks = new BSE.Platten.BO.CTrack[albumTracks.Count];
                    albumTracks.CopyTo(tracks);
                }
            }
            return tracks;
        }

        public static BSE.Platten.BO.CTrack GetTrackForPlayListByLiedId(string strConnection, int iLiedId)
        {
            BSE.Platten.BO.CTrack track = null;
            string strSelectSQL = "Select i.interpret,t.titelid,t.titel,t.erschdatum," +
                " g.genre,l.liedid,l.titelid,l.track,l.lied," +
                " l.dauer,l.liedpfad FROM lieder l" +
                " JOIN titel t ON l.titelid = t.titelid" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " LEFT JOIN genre g ON t.genreid = g.genreid" +
                " WHERE l.liedpfad IS NOT NULL" +
                " AND l.liedid = ?LiedId";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("LiedId", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "LiedId";
                    mySqlParameter.Value = iLiedId;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            track = new CTrack();
                            track.TitelId = GetInt32(mySqlDataReader, "titelid", false, track.TitelId);
                            track.Interpret = GetString(mySqlDataReader, "interpret", false, track.Interpret);
                            track.Album = GetString(mySqlDataReader, "titel", false, track.Album);
                            track.Genre = GetString(mySqlDataReader, "genre", true, track.Genre);
                            track.Year = GetInt32(mySqlDataReader, "erschdatum", true, track.Year);
                            track.LiedId = GetInt32(mySqlDataReader, "liedid", false, track.LiedId);
                            track.TrackNumber = GetInt32(mySqlDataReader, "track", false, track.TrackNumber);
                            track.Title = GetString(mySqlDataReader, "lied", false, track.Title);
                            //track.Duration = GetDateTime(mySqlDataReader, "dauer", false, track.Duration);
                            track.Duration = GetTimeSpan(mySqlDataReader, "dauer", false, track.Duration);
                            track.FileName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);
                            track.FileFullName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);
                        }
                    }
                }
            }
            return track;
        }

        public static IList<Playlist> GetPlaylistsByUserName(string strConnection, string userName)
        {
            List<Playlist> playLists = null;
            string strSqlPlaylists = "SELECT listid,listname FROM playlist" +
                " WHERE user = ?User" +
                " ORDER BY listname";
            ArrayList aPlayLists = new ArrayList();

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSqlPlaylists, mySqlConnection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "User";
                    mySqlParameter.Value = userName;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            if (playLists == null)
                            {
                                playLists = new List<Playlist>();
                            }
                            playLists.Add(new Playlist
                            {
                                Id = GetInt32(mySqlDataReader, "ListId", false, 0),
                                Name = GetString(mySqlDataReader, "ListName", false, string.Empty)
                            });
                        }
                    }
                }
            }
            return playLists;
        }

        public static Playlist InsertPlaylist(string strConnection, Playlist playList)
        {
            if (playList == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "playList"));
            }
            
            string strInsertPlaylistSQL = "INSERT INTO playlist " +
                " (listid,listname,user,Guid)" +
                " VALUES(" +
                " 0,?ListName,?User,?Guid)";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strInsertPlaylistSQL, mySqlConnection))
                {
                    MySqlParameter mySqlParameterName = mySqlCommand.Parameters.Add(new MySqlParameter("ListName", MySqlDbType.VarChar, 100));
                    mySqlParameterName.Direction = ParameterDirection.Input;
                    mySqlParameterName.SourceColumn = "ListName";
                    mySqlParameterName.Value = playList.Name;

                    MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                    mySqlParameterUser.Direction = ParameterDirection.Input;
                    mySqlParameterUser.SourceColumn = "User";
                    mySqlParameterUser.Value = playList.User;

                    MySqlParameter mySqlParameterGuid = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
                    mySqlParameterGuid.Direction = ParameterDirection.Input;
                    mySqlParameterGuid.SourceColumn = "guid";
                    mySqlParameterGuid.Value = playList.Guid.ToString();

                    if (mySqlCommand.ExecuteNonQuery() > 0)
                    {
                        playList = GetPlayListByGuid(playList, mySqlConnection);
                    }
                }
            }
            return playList;
        }

        public static void SavePlayList(string strConnection, Playlist playList)
        {
            if (playList == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "playList"));
            }
            
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        if (DeletePlayListEntries(playList.Id, mySqlConnection))
                        {
                            InsertPlayListEntries(playList, mySqlConnection);
                            mySqlTransaction.Commit();
                        }
                    }
                    catch (MySqlException)
                    {
                        mySqlTransaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void DeletePlayList(string strConnection, int iPlayListId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                try
                {
                    using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                    {
                        try
                        {
                            if (DeletePlayListEntries(iPlayListId, mySqlConnection))
                            {
                                DeletePlayList(iPlayListId, mySqlConnection);
                                mySqlTransaction.Commit();
                            }
                        }
                        catch (MySqlException)
                        {
                            mySqlTransaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (MySqlException)
                {
                    throw;
                }
            }
        }

        public static Playlist GetPlayListByPlayListId(string strConnection, int iPlayListId)
        {
            Playlist playList = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                playList = GetPlayListByPlayListId(iPlayListId, mySqlConnection);
                if (playList != null)
                {
                    playList = GetPlayListEntriesByPlayListId(playList, mySqlConnection);
                }
            }
            return playList;
        }

        #endregion

        #region Filters

        public static CFilter[] GetFilterByFilterMode(string strConnection, FilterSettings.FilterMode filterMode)
        {
            CFilter[] filters = null;

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                switch (filterMode)
                {
                    case FilterSettings.FilterMode.Genre:
                        filters = GetFilterByFilterModeGenre(mySqlConnection);
                        break;
                    case FilterSettings.FilterMode.Year:
                        filters = GetFilterByFilterModeYear(mySqlConnection);
                        break;
                }
            }
            return filters;
        }

        public static TrackCollection GetTracksByFilterSettings(string strConnection, FilterSettings filterSettings)
        {
            if (filterSettings == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "filterSettings"));
            }
            
            string strSelectSql = string.Empty;
            TrackCollection trackCollection = new TrackCollection();
            switch (filterSettings.UsedFilterMode)
            {
                case FilterSettings.FilterMode.None:
                    strSelectSql = "SELECT l.liedid,t.titelid,i.interpret,t.titel,l.lied, l.liedpfad" +
                        " FROM lieder l" +
                        " JOIN titel t ON l.titelid = t.titelid" +
                        " JOIN interpreten i ON t.interpretid = i.interpretid" +
                        " WHERE l.liedpfad IS NOT NULL" +
                        " ORDER BY l.liedid";
                    break;
                case FilterSettings.FilterMode.Year:
                    strSelectSql = "SELECT l.liedId,t.titelid,i.interpret,t.titel,l.lied, l.liedpfad" +
                        " FROM lieder l" +
                        " JOIN titel t ON l.titelid = t.titelid" +
                        " JOIN interpreten i ON t.interpretid = i.interpretid" +
                        " WHERE t.erschdatum IN (" + filterSettings.Value + ")" +
                        " AND l.liedpfad IS NOT NULL";
                    break;
                case FilterSettings.FilterMode.Genre:
                    strSelectSql = "SELECT l.liedId,t.titelid,i.interpret,t.titel,l.lied, l.liedpfad" +
                        " FROM lieder l" +
                        " JOIN titel t ON l.titelid = t.titelid" +
                        " JOIN interpreten i ON t.interpretid = i.interpretid" +
                        " WHERE t.genreid IN (" + filterSettings.Value + ")" +
                        " AND l.liedpfad IS NOT NULL";
                    break;
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            CTrack track = new CTrack();

                            track.LiedId = GetInt32(mySqlDataReader,"liedId",false,track.LiedId);
                            track.TitelId = GetInt32(mySqlDataReader, "titelid", false, track.TitelId);
                            track.Interpret = GetString(mySqlDataReader, "interpret", false, track.Interpret);
                            track.Album = GetString(mySqlDataReader, "titel", false, track.Album);
                            track.Title = GetString(mySqlDataReader, "lied", false, track.Title);
                            track.FileName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);

                            trackCollection.Add(track);
                        }
                    }
                }
            }
            return trackCollection;
        }

        public static FilterSettings GetFilterSettings(string strConnection, FilterSettings.FilterMode filterMode, string strBenutzer)
        {
            FilterSettings filterSettings = null;

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                filterSettings = GetFilterSettings(mySqlConnection, filterMode, strBenutzer);
                if (filterSettings == null)
                {
                    InsertFilterSettings(mySqlConnection, filterMode, strBenutzer);
                }
            }
            return filterSettings;
        }

        public static void SaveFilterSettings(string strConnection, FilterSettings filterSettings)
        {
            if (filterSettings == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "filterSettings"));
            }
            
            string strUpdateSql = "UPDATE filtersettings" +
                " SET value = ?Value," +
                " isused = ?IsUsed" +
                " WHERE mode = ?Mode" +
                " AND benutzer = ?Benutzer";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strUpdateSql, mySqlConnection))
                {
                    MySqlParameter mySqlParameterFilterMode = mySqlCommand.Parameters.Add(new MySqlParameter("Mode", MySqlDbType.Int32));
                    mySqlParameterFilterMode.Direction = ParameterDirection.Input;
                    mySqlParameterFilterMode.SourceColumn = "mode";
                    mySqlParameterFilterMode.Value = filterSettings.UsedFilterMode;

                    MySqlParameter mySqlParameterValue = mySqlCommand.Parameters.Add(new MySqlParameter("Value", MySqlDbType.VarChar, 255));
                    mySqlParameterValue.Direction = ParameterDirection.Input;
                    mySqlParameterValue.SourceColumn = "value";
                    mySqlParameterValue.Value = filterSettings.Value;

                    MySqlParameter mySqlParameterUsed = mySqlCommand.Parameters.Add(new MySqlParameter("IsUsed", MySqlDbType.Bit));
                    mySqlParameterUsed.Direction = ParameterDirection.Input;
                    mySqlParameterUsed.SourceColumn = "isused";
                    mySqlParameterUsed.Value = filterSettings.IsUsed;

                    MySqlParameter mySqlParameterBenutzer = mySqlCommand.Parameters.Add(new MySqlParameter("Benutzer", MySqlDbType.VarChar, 50));
                    mySqlParameterBenutzer.Direction = ParameterDirection.Input;
                    mySqlParameterBenutzer.SourceColumn = "benutzer";
                    mySqlParameterBenutzer.Value = filterSettings.Benutzer;

                    mySqlCommand.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region History

        public static SortableCollection<CHistoryTrack> GetHistoryTrackCollection(string strConnection, string strUser)
        {
            SortableCollection<CHistoryTrack> trackCollection = new SortableCollection<CHistoryTrack>();

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                trackCollection = GetHistoryTrackCollection(mySqlConnection, trackCollection, strUser);
            }
            return trackCollection;
        }

        public static SortableCollection<CHistoryTrack> GetHistoryTrackCollection(string strConnection, HistoryData historyData)
        {
            SortableCollection<CHistoryTrack> trackCollection = new SortableCollection<CHistoryTrack>();
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                if (InsertHistoryData(mySqlConnection, historyData))
                {
                    trackCollection = GetHistoryTrackCollection(mySqlConnection, trackCollection, historyData.UserName);
                }
            }
            return trackCollection;
        }

        public static void UpdateHistory(string strConnection, HistoryData historyData)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                InsertHistoryData(mySqlConnection, historyData);
            }
        }

        public static IList<Album> GetHistoryAlbums(string strConnection, HistoryData historyData)
        {
            List<Album> albums = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                if (InsertHistoryData(mySqlConnection, historyData))
                {
                    albums = GetHistoryAlbums(mySqlConnection, historyData.UserName);
                }
            }
            return albums;
        }

        public static IList<Album> GetHistoryAlbums(string strConnection, string strUserName)
        {
            List<Album> albums = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                albums = GetHistoryAlbums(mySqlConnection, strUserName);
            }
            return albums;
        }

        public static void DeleteTracksFromHistory(string strConnection, string strUser)
        {
            int iAppId = 0; //Radio
            int iCountHistoryTracks = 0;
            int iPlayListLimit = 40;

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                int iLastId = SelectLastIdFromHistory(mySqlConnection, strUser, iPlayListLimit, out iCountHistoryTracks);
                if (iLastId > 0 && iCountHistoryTracks == iPlayListLimit)
                {
                    DeleteTracksFromHistory(mySqlConnection, strUser, iAppId, iLastId); //Radio
                    DeleteTracksFromHistory(mySqlConnection, strUser);//Lieder,Cds
                }
            }
        }

        #endregion

        #endregion

        #region MethodsPrivate

        #region Albums

        private static Album GetAlbumDetailByTitelId(int iTitelId, MySqlConnection mySqlConnection)
        {
            Album album = null;
            string strSelectSQL = "SELECT t.titelid, i.interpretid, i.interpret, t.titel," +
                " g.genre, t.cover, t.thumbnail, t.erschdatum, t.erstelldatum, m.beschreibung" +
                " FROM titel t" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " LEFT JOIN genre g ON t.genreid = g.genreid" +
                " LEFT JOIN medium m ON t.mediumid = m.mediumid" +
                " WHERE t.titelid = ?TitelID";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
            {
                MySqlParameter mySqlParamter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
                mySqlParamter.Direction = ParameterDirection.Input;
                mySqlParamter.SourceColumn = "TitelID";
                mySqlParamter.Value = iTitelId;
                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        album = new Album();

                        album.AlbumId = GetInt32(mySqlDataReader, "titelid", false, album.AlbumId);
                        album.InterpretId = GetInt32(mySqlDataReader, "interpretid", false, album.InterpretId);
                        album.Interpret = GetString(mySqlDataReader, "interpret", false, album.Interpret);
                        album.Title = GetString(mySqlDataReader, "titel", false, album.Title);
                        album.Medium = GetString(mySqlDataReader, "beschreibung", true, album.Medium);
                        album.Year = GetInt32(mySqlDataReader, "erschdatum", true, album.Year);
                        album.Genre = GetString(mySqlDataReader, "genre", true, album.Genre);
                        byte[] cover = GetBytes(mySqlDataReader, "thumbnail", true, null);
                        if (cover != null)
                        {
                            album.CoverSource = CCoverData.GetBitmapSourceFromBytes(cover);
                            album.CoverSource.Freeze();
                        }
                        //album.Cover = CCoverData.GetImageFromDbReader(mySqlDataReader, "cover");

                    }
                }
            }
            return album;
        }

        private static Album GetAlbumTracksByTitelId(Album album, MySqlConnection mySqlConnection)
        {
            string strSelectSQL = "Select l.liedid,l.titelid,l.track,l.lied," +
                " l.dauer,l.liedpfad FROM platten.lieder l" +
                " JOIN platten.titel t ON l.titelid = t.titelid" +
                " WHERE t.titelid = ?TitelID" +
                " ORDER BY l.track";
            ArrayList aTracks = new ArrayList();

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
            {
                MySqlParameter mySqlParamter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
                mySqlParamter.Direction = ParameterDirection.Input;
                mySqlParamter.SourceColumn = "TitelID";
                mySqlParamter.Value = album.AlbumId;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        CTrack track = new CTrack();
                        track.TitelId = album.AlbumId;
                        track.LiedId = GetInt32(mySqlDataReader, "liedid", false, track.LiedId);
                        track.TrackNumber = GetInt32(mySqlDataReader, "track", false, track.TrackNumber);
                        track.Title = GetString(mySqlDataReader, "lied", true, track.Title);
                        //track.Duration = GetDateTime(mySqlDataReader, "dauer", true, track.Duration);
                        track.Duration = GetTimeSpan(mySqlDataReader, "dauer", true, track.Duration);

track.FileName = GetString(mySqlDataReader, "liedpfad", true, track.FileName);
                        track.FileFullName = GetString(mySqlDataReader, "liedpfad", true, track.FileName);
                        aTracks.Add(track);
                    }
                }
                CTrack[] tracks = new CTrack[aTracks.Count];
                aTracks.CopyTo(tracks);
                album.Tracks = tracks;
            }
            return album;
        }
        #endregion

        #region Trees

        private static DataSet GetInterpretsAndAlbumsAsDataSet(string strDataRelationName, string strConnection)
        {
            DataSet dataSetInterpretsAndAlbums = null;
            string strSelectInterpretSQL = "SELECT DISTINCT i.interpretid,i.interpret" +
                " FROM interpreten i" +
                " INNER JOIN titel ti ON i.interpretid = ti.interpretid" +
                " INNER JOIN lieder l ON ti.titelid = l.titelid" +
                " WHERE l.liedpfad IS NOT NULL" +
                " ORDER by i.Interpret";

            string strSelectTitelSQL = "Select DISTINCT ti.titelid,ti.titel,ti.interpretid, ti.thumbnail" +
                " FROM titel ti" +
                " INNER JOIN lieder l ON ti.titelid = l.titelid" +
                " WHERE l.liedpfad IS NOT NULL" +
                " ORDER By ti.titel";

            dataSetInterpretsAndAlbums = new DataSet("Interpreten");
            dataSetInterpretsAndAlbums.Locale = CultureInfo.InvariantCulture;
            dataSetInterpretsAndAlbums.Relations.Clear();

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter mySqlDataAdapterInterpret = new MySqlDataAdapter())
                {
                    mySqlDataAdapterInterpret.SelectCommand = new MySqlCommand(strSelectInterpretSQL, mySqlConnection);
                    mySqlDataAdapterInterpret.Fill(dataSetInterpretsAndAlbums, "Interpret");
                }

                using (MySqlDataAdapter mySqlDataAdapterTitel = new MySqlDataAdapter())
                {
                    mySqlDataAdapterTitel.SelectCommand = new MySqlCommand(strSelectTitelSQL, mySqlConnection);
                    mySqlDataAdapterTitel.Fill(dataSetInterpretsAndAlbums, "Titel");
                }
                dataSetInterpretsAndAlbums.Relations.Add(
                    strDataRelationName,
                    dataSetInterpretsAndAlbums.Tables["Interpret"].Columns["InterpretID"],
                    dataSetInterpretsAndAlbums.Tables["Titel"].Columns["InterpretID"]);
            }
            return dataSetInterpretsAndAlbums;
        }

        private static DataSet GetGenresWithAlbumsAsDataSet(string strDataRelationName, string strConnection)
        {
            DataSet dataSetGenresWithAlbums = null;
            string strSelectGenreSQL = "SELECT DISTINCT g.genreid,g.genre" +
                " FROM genre g" +
                " JOIN titel t ON g.genreid = t.genreid" +
                " JOIN lieder l ON t.titelid = l.titelid AND l.liedpfad IS NOT NULL" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " WHERE t.genreid is not null" +
                " ORDER by g.genre,i.Interpret,t.titel";

            string strSelectAlbumSQL = "SELECT DISTINCT t.genreid,t.titelid,i.interpret,t.titel" +
                " FROM interpreten i" +
                " JOIN titel t ON i.interpretid = t.interpretid" +
                " JOIN lieder l ON t.titelid = l.titelid AND l.liedpfad IS NOT NULL" +
                " WHERE t.genreid is not null" +
                " ORDER by i.Interpret";


            dataSetGenresWithAlbums = new DataSet("Genres");
            dataSetGenresWithAlbums.Locale = CultureInfo.InvariantCulture;
            dataSetGenresWithAlbums.Relations.Clear();

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter mySqlDataAdapterInterpret = new MySqlDataAdapter())
                {
                    mySqlDataAdapterInterpret.SelectCommand = new MySqlCommand(strSelectGenreSQL, mySqlConnection);
                    mySqlDataAdapterInterpret.Fill(dataSetGenresWithAlbums, "Genre");
                }

                using (MySqlDataAdapter mySqlDataAdapterTitel = new MySqlDataAdapter())
                {
                    mySqlDataAdapterTitel.SelectCommand = new MySqlCommand(strSelectAlbumSQL, mySqlConnection);
                    mySqlDataAdapterTitel.Fill(dataSetGenresWithAlbums, "Album");
                }

                dataSetGenresWithAlbums.Relations.Add(
                    strDataRelationName,
                    dataSetGenresWithAlbums.Tables["Genre"].Columns["GenreId"],
                    dataSetGenresWithAlbums.Tables["Album"].Columns["GenreId"]);
            }
            return dataSetGenresWithAlbums;
        }

        private static DataSet GetYearsWithAlbumsAsDataSet(string strDataRelationName, string strConnection)
        {
            DataSet dataSetYearsWithAlbums = null;
            string strSelectYearsSQL = "SELECT DISTINCT t.erschdatum" +
                " FROM titel t" +
                " JOIN lieder l ON t.titelid = l.titelid AND l.liedpfad IS NOT NULL" +
                " WHERE t.erschdatum IS NOT NULL" +
                " ORDER by t.erschdatum DESC";

            string strSelectAlbumSQL = "SELECT DISTINCT t.erschdatum,t.titelid,i.interpret,t.titel" +
                " FROM interpreten i" +
                " JOIN titel t ON i.interpretid = t.interpretid" +
                " JOIN lieder l ON t.titelid = l.titelid AND l.liedpfad IS NOT NULL" +
                " WHERE t.erschdatum IS NOT NULL" +
                " ORDER by i.Interpret, t.titel";

            dataSetYearsWithAlbums = new DataSet("Years");
            dataSetYearsWithAlbums.Locale = CultureInfo.InvariantCulture;
            dataSetYearsWithAlbums.Relations.Clear();

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter mySqlDataAdapterInterpret = new MySqlDataAdapter())
                {
                    mySqlDataAdapterInterpret.SelectCommand = new MySqlCommand(strSelectYearsSQL, mySqlConnection);
                    mySqlDataAdapterInterpret.Fill(dataSetYearsWithAlbums, "Year");
                }

                using (MySqlDataAdapter mySqlDataAdapterTitel = new MySqlDataAdapter())
                {
                    mySqlDataAdapterTitel.SelectCommand = new MySqlCommand(strSelectAlbumSQL, mySqlConnection);
                    mySqlDataAdapterTitel.Fill(dataSetYearsWithAlbums, "Album");
                }

                dataSetYearsWithAlbums.Relations.Add(
                    strDataRelationName,
                    dataSetYearsWithAlbums.Tables["Year"].Columns["erschdatum"],
                    dataSetYearsWithAlbums.Tables["Album"].Columns["erschdatum"]);
            }
            return dataSetYearsWithAlbums;
        }

        #endregion

        #region FullTextSearch

        private static SortableCollection<CTrack> GetFullTextSearchForTitleAndInterpretsCollection(string strSearchstring,
            SortableCollection<CTrack> trackCollection,
            MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT DISTINCT t.titelid,i.interpret,t.titel,'' as lied" +
                " FROM titel t" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " JOIN lieder l ON t.titelid = l.titelid AND l.liedpfad IS NOT NULL" +
                " WHERE MATCH (i.interpret,t.titel) AGAINST (?InterpretTitel IN BOOLEAN MODE)" +
                " ORDER BY i.interpret ,t.titel";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
            {
                MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretTitel", MySqlDbType.VarChar, 60));
                mySqlParameter.Direction = ParameterDirection.Input;
                mySqlParameter.SourceColumn = "interpret,titel";
                mySqlParameter.Value = strSearchstring;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        CTrack track = new CTrack();

                        track.TitelId = GetInt32(mySqlDataReader, "titelid", false, track.TitelId);
                        track.Interpret = GetString(mySqlDataReader, "interpret", false, track.Interpret);
                        track.Album = GetString(mySqlDataReader, "titel", false, track.Album);

                        trackCollection.Add(track);
                    }
                }
            }
            return trackCollection;
        }

        private static SortableCollection<CTrack> GetFullTextSearchForTitlesCollection(string strSearchstring,
            SortableCollection<CTrack> trackCollection,
            MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT t.titelid, i.interpret,t.titel, l.liedid,l.lied" +
                " FROM lieder l" +
                " JOIN titel t ON l.titelId = t.titelid" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " WHERE MATCH (l.lied) AGAINST (?Lied IN BOOLEAN MODE)" +
                " AND l.liedpfad IS NOT NULL" +
                " ORDER BY i.interpret ,t.titel,l.lied";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
            {
                MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Lied", MySqlDbType.VarChar, 100));
                mySqlParameter.Direction = ParameterDirection.Input;
                mySqlParameter.SourceColumn = "lied";
                mySqlParameter.Value = strSearchstring;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        CTrack track = new CTrack();

                        track.TitelId = GetInt32(mySqlDataReader, "titelid", false, track.TitelId);
                        track.LiedId = GetInt32(mySqlDataReader, "liedid", false, track.LiedId);
                        track.Interpret = GetString(mySqlDataReader, "interpret", false, track.Interpret);
                        track.Album = GetString(mySqlDataReader, "titel", false, track.Album);
                        track.Title = GetString(mySqlDataReader, "lied", false, track.Title);

                        trackCollection.Add(track);
                    }
                }
            }
            return trackCollection;
        }

        #endregion

        #region PlayList

        private static Playlist GetPlayListByPlayListId(int iPlayListId, MySqlConnection mySqlConnection)
        {
            Playlist playList = null;
            string strSelectPlaylistSQL = "SELECT * FROM playlist" +
                " WHERE listid = ?ListId";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectPlaylistSQL, mySqlConnection))
            {
                MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ListId", MySqlDbType.Int32));
                mySqlParameter.Direction = ParameterDirection.Input;
                mySqlParameter.SourceColumn = "ListId";
                mySqlParameter.Value = iPlayListId;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        playList = new Playlist();
                        playList.Id = GetInt32(mySqlDataReader, "ListId", false, playList.Id);
                        playList.Name = GetString(mySqlDataReader, "ListName", false, playList.Name);
                        playList.User = GetString(mySqlDataReader, "User", false, playList.User);
                        playList.Guid = GetGuid(mySqlDataReader, "Guid", false, Guid.NewGuid());
                        playList.TimeStamp = GetDateTime(mySqlDataReader, "Timestamp", false, playList.TimeStamp);
                    }
                }
            }
            return playList;
        }

        private static Playlist GetPlayListEntriesByPlayListId(Playlist playList, MySqlConnection mySqlConnection)
        {
            string strSelectPlaylistEntriesSQL = @"Select pe.entryid,pe.playlistid,pe.liedid," +
                " pe.guid,i.interpret,t.titelid,t.titel,l.liedid,l.track,l.lied,l.dauer,l.liedpfad,g.genre,t.erschdatum,pe.timestamp" +
                " FROM playlistentries pe" +
                " JOIN playlist p ON pe.playlistid = p.listid" +
                " JOIN lieder l ON pe.liedid = l.liedid" +
                " JOIN titel t ON l.titelid = t.titelid" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " LEFT JOIN genre g ON t.genreid = g.genreid" +
                " WHERE pe.playlistid = ?PlaylistId" +
                " ORDER BY pe.entryid";

            ArrayList aTracks = new ArrayList();

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectPlaylistEntriesSQL, mySqlConnection))
            {
                MySqlParameter mySqlParameterGuid = mySqlCommand.Parameters.Add(new MySqlParameter("PlaylistId", MySqlDbType.Int32, 0));
                mySqlParameterGuid.Direction = ParameterDirection.Input;
                mySqlParameterGuid.SourceColumn = "PlaylistId";
                mySqlParameterGuid.Value = playList.Id;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        CTrack track = new CTrack();

                        track.TitelId = GetInt32(mySqlDataReader, "titelId", false, track.TitelId);
                        track.LiedId = GetInt32(mySqlDataReader, "LiedId", false, track.LiedId);
                        track.Interpret = GetString(mySqlDataReader, "interpret", false, track.Interpret);
                        track.Album = GetString(mySqlDataReader, "titel", false, track.Album);
                        track.TrackNumber = GetInt32(mySqlDataReader, "track", false, track.TrackNumber);
                        track.Title = GetString(mySqlDataReader, "lied", false, track.Title);
                        //track.Duration = GetDateTime(mySqlDataReader, "dauer", false, track.Duration);
                        track.Duration = GetTimeSpan(mySqlDataReader, "dauer", false, track.Duration);
                        track.Genre = GetString(mySqlDataReader, "genre", true, track.Genre);
                        track.Year = GetInt32(mySqlDataReader, "erschdatum", true, track.Year);
                        track.FileName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);
                        track.FileFullName = GetString(mySqlDataReader, "liedpfad", false, track.FileName);

                        aTracks.Add(track);
                    }
                    CTrack[] tracks = new CTrack[aTracks.Count];
                    aTracks.CopyTo(tracks);
                    playList.Tracks = tracks;
                }
            }
            return playList;
        }

        private static Playlist GetPlayListByGuid(Playlist playList, MySqlConnection mySqlConnection)
        {
            string strSelectSQL = "SELECT listId, timestamp FROM playlist" +
                " WHERE guid = ?Guid";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
            {
                MySqlParameter mySqlParameterGuid = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
                mySqlParameterGuid.Direction = ParameterDirection.Input;
                mySqlParameterGuid.SourceColumn = "guid";
                mySqlParameterGuid.Value = playList.Guid.ToString();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        playList.Id = GetInt32(mySqlDataReader, "listId", false, playList.Id);
                        playList.TimeStamp = GetDateTime(mySqlDataReader, "timestamp", false, playList.TimeStamp);
                    }
                }
            }
            return playList;
        }

        private static void InsertPlayListEntries(Playlist playList, MySqlConnection mySqlConnection)
        {
            string strInsertEntriesSQL = "INSERT INTO playlistentries (entryid,playlistid,liedid,guid)" +
                " VALUES (Null,?PlaylistId,?LiedId,?Guid)";

            foreach (PlaylistEntry playListEntries in playList.PlayListEntries)
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand(strInsertEntriesSQL, mySqlConnection))
                {

                    MySqlParameter mySqlParameterPlayListId = mySqlCommand.Parameters.Add(new MySqlParameter("PlayListId", MySqlDbType.Int32));
                    mySqlParameterPlayListId.Direction = ParameterDirection.Input;
                    mySqlParameterPlayListId.SourceColumn = "PlaylistId";
                    mySqlParameterPlayListId.Value = playList.Id;

                    MySqlParameter mySqlParameterLiedId = mySqlCommand.Parameters.Add(new MySqlParameter("LiedId", MySqlDbType.Int32));
                    mySqlParameterLiedId.Direction = ParameterDirection.Input;
                    mySqlParameterLiedId.SourceColumn = "LiedId";
                    mySqlParameterLiedId.Value = playListEntries.LiedId;

                    MySqlParameter mySqlParameterGuid = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
                    mySqlParameterGuid.Direction = ParameterDirection.Input;
                    mySqlParameterGuid.SourceColumn = "Guid";
                    mySqlParameterGuid.Value = playListEntries.Guid.ToString();

                    mySqlCommand.ExecuteNonQuery();
                }
            }
        }

        private static void DeletePlayList(int iPlayListId, MySqlConnection mySqlConnection)
        {
            string strDeleteEntriesSQL = "DELETE FROM playlist WHERE listid = ?ListId";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strDeleteEntriesSQL, mySqlConnection))
            {
                MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ListId", MySqlDbType.Int32, 0));
                mySqlParameter.Direction = ParameterDirection.Input;
                mySqlParameter.SourceColumn = "ListId";
                mySqlParameter.Value = iPlayListId;

                mySqlCommand.ExecuteNonQuery();
            }
        }

        private static bool DeletePlayListEntries(int iPlayListId, MySqlConnection mySqlConnection)
        {
            bool bDeleteOk = false;
            string strDeleteEntriesSQL = "DELETE FROM playlistentries WHERE playlistid = ?PlayListId";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strDeleteEntriesSQL, mySqlConnection))
            {
                MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("PlayListId", MySqlDbType.Int32));
                mySqlParameter.Direction = ParameterDirection.Input;
                mySqlParameter.SourceColumn = "PlaylistId";
                mySqlParameter.Value = iPlayListId;

                mySqlCommand.ExecuteNonQuery();
                bDeleteOk = true;
            }
            return bDeleteOk;
        }

        #endregion

        #region Filters

        private static CFilter[] GetFilterByFilterModeGenre(MySqlConnection mySqlConnection)
        {
            CFilter[] filters = null;
            ArrayList aFilters = new ArrayList();
            string strSelectSQL = "SELECT COUNT(l.lied) AS anzahl,g.genreid,g.genre" +
                " FROM lieder l" +
                " JOIN titel t ON l.titelid = t.titelid AND t.genreid IS NOT NULL" +
                " JOIN genre g ON t.genreid = g.genreid" +
                " AND l.liedpfad IS NOT Null" +
                " GROUP BY g.genre" +
                " ORDER BY g.genre";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
            {
                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        CFilter filter = new CFilter();

                        //MySQL returns a count of the number of non-NULL values in the rows retrieved by a SELECT statement.
                        //The result is a BIGINT value. 
                        filter.Number = Convert.ToInt32(GetInt64(mySqlDataReader, "anzahl", true, filter.Number));
                        filter.Id = GetInt32(mySqlDataReader, "genreid", true, filter.Id);
                        filter.Name = GetString(mySqlDataReader, "genre", false, filter.Name);

                        aFilters.Add(filter);
                    }
                    filters = new CFilter[aFilters.Count];
                    aFilters.CopyTo(filters);
                }
            }
            return filters;
        }

        private static CFilter[] GetFilterByFilterModeYear(MySqlConnection mySqlConnection)
        {
            CFilter[] filters = null;
            ArrayList aFilters = new ArrayList();
            string strSelectSQL = "SELECT COUNT(l.lied) AS anzahl,t.erschdatum" +
                " FROM lieder l" +
                " INNER JOIN titel t ON l.titelid = t.titelid AND (t.erschdatum <> 0 OR t.erschdatum IS NOT NULL)" +
                " WHERE l.liedpfad IS NOT Null" +
                " GROUP BY t.erschdatum" +
                " ORDER BY t.erschdatum DESC";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSQL, mySqlConnection))
            {
                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        BSE.Platten.BO.CFilter filter = new BSE.Platten.BO.CFilter();

                        //MySQL returns a count of the number of non-NULL values in the rows retrieved by a SELECT statement.
                        //The result is a BIGINT value. 
                        filter.Number = Convert.ToInt32(GetInt64(mySqlDataReader, "anzahl", true, filter.Number));
                        filter.Id = GetInt32(mySqlDataReader, "erschdatum", true, filter.Id);
                        filter.Name = GetInt32(mySqlDataReader, "erschdatum", true, 0).ToString(CultureInfo.InvariantCulture);

                        aFilters.Add(filter);
                    }
                    filters = new CFilter[aFilters.Count];
                    aFilters.CopyTo(filters);
                }
            }
            return filters;
        }

        private static FilterSettings GetFilterSettings(MySqlConnection mySqlConnection, FilterSettings.FilterMode filterMode, string strBenutzer)
        {
            FilterSettings filterSettings = null;
            string strSelectSql = "SELECT f.filterid, f.mode," +
                " f.value, f.isused, f.benutzer" +
                " FROM filtersettings f" +
                " WHERE f.mode = ?Mode" +
                " AND f.benutzer = ?Benutzer";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
            {
                MySqlParameter mySqlParameterFilterMode = mySqlCommand.Parameters.Add(new MySqlParameter("Mode", MySqlDbType.Int32));
                mySqlParameterFilterMode.Direction = ParameterDirection.Input;
                mySqlParameterFilterMode.SourceColumn = "mode";
                mySqlParameterFilterMode.Value = (int)filterMode;
                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("Benutzer", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "benutzer";
                mySqlParameterUser.Value = strBenutzer;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        filterSettings = new FilterSettings();

                        filterSettings.FilterId = GetInt32(mySqlDataReader,"filterid",false,filterSettings.FilterId);
                        int iIndexUsedFilterMode = mySqlDataReader.GetOrdinal("mode");
                        //filterSettings.UsedFilterMode = (FilterSettings.FilterMode)Enum.Parse(
                        //    typeof(FilterSettings.FilterMode),
                        //    mySqlDataReader.GetString(iIndexUsedFilterMode));
                        filterSettings.UsedFilterMode = (FilterSettings.FilterMode)Enum.Parse(
                            typeof(FilterSettings.FilterMode), iIndexUsedFilterMode.ToString());
                        filterSettings.Value = GetString(mySqlDataReader, "value", true, filterSettings.Value);
                        filterSettings.IsUsed = GetBoolean(mySqlDataReader, "isused", true, filterSettings.IsUsed);
                        filterSettings.Benutzer = GetString(mySqlDataReader, "benutzer", false, filterSettings.Benutzer);
                    }
                }
            }
            return filterSettings;
        }

        private static void InsertFilterSettings(MySqlConnection mySqlConnection, FilterSettings.FilterMode filterMode, string strBenutzer)
        {
            string strInsertSql = "INSERT INTO filtersettings" +
                " (mode, value, isused, benutzer)" +
                " VALUES(?Mode, ?Value, false, ?Benutzer)";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strInsertSql, mySqlConnection))
            {
                MySqlParameter mySqlParameterFilterMode = mySqlCommand.Parameters.Add(new MySqlParameter("Mode", MySqlDbType.Int32));
                mySqlParameterFilterMode.Direction = ParameterDirection.Input;
                mySqlParameterFilterMode.SourceColumn = "mode";
                mySqlParameterFilterMode.Value = (int)filterMode;

                MySqlParameter mySqlParameterValue = mySqlCommand.Parameters.Add(new MySqlParameter("Value", MySqlDbType.VarChar, 255));
                mySqlParameterValue.Direction = ParameterDirection.Input;
                mySqlParameterValue.SourceColumn = "value";
                mySqlParameterValue.Value = System.DBNull.Value;

                MySqlParameter mySqlParameterBenutzer = mySqlCommand.Parameters.Add(new MySqlParameter("Benutzer", MySqlDbType.VarChar, 50));
                mySqlParameterBenutzer.Direction = ParameterDirection.Input;
                mySqlParameterBenutzer.SourceColumn = "benutzer";
                mySqlParameterBenutzer.Value = strBenutzer;

                mySqlCommand.ExecuteNonQuery();
            }
        }

        #endregion

        #region History
        private static bool InsertHistoryData(MySqlConnection mySqlConnection, HistoryData historyData)
        {
            string strInsertSqlInfo = "INSERT INTO history" +
                " (appid,titelid,liedid,zeit,benutzer)" +
                " VALUES (?AppID,?TitelID,?LiedID,?Zeit,?Benutzer)";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strInsertSqlInfo, mySqlConnection))
            {
                MySqlParameter mySqlParameterApId = mySqlCommand.Parameters.Add(new MySqlParameter("AppID", MySqlDbType.Int32, 0));
                mySqlParameterApId.Direction = ParameterDirection.Input;
                mySqlParameterApId.SourceColumn = "AppID";
                mySqlParameterApId.Value = historyData.AppId;

                MySqlParameter mySqlParameterTitelId = mySqlCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
                mySqlParameterTitelId.Direction = ParameterDirection.Input;
                mySqlParameterTitelId.SourceColumn = "TitelID";
                mySqlParameterTitelId.Value = historyData.TitelId;

                MySqlParameter mySqlParameterLiedId = mySqlCommand.Parameters.Add(new MySqlParameter("LiedID", MySqlDbType.Int32, 0));
                mySqlParameterLiedId.Direction = ParameterDirection.Input;
                mySqlParameterLiedId.SourceColumn = "LiedID";
                mySqlParameterLiedId.Value = historyData.LiedId;

                MySqlParameter mySqlParameterPlayedAt = mySqlCommand.Parameters.Add(new MySqlParameter("Zeit", MySqlDbType.DateTime, 0));
                mySqlParameterPlayedAt.Direction = ParameterDirection.Input;
                mySqlParameterPlayedAt.SourceColumn = "Zeit";
                mySqlParameterPlayedAt.Value = historyData.PlayedAt;

                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("Benutzer", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "Benutzer";
                mySqlParameterUser.Value = historyData.UserName;

                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<Album> GetHistoryAlbums(MySqlConnection mySqlConnection, string strUserName)
        {
            List<Album> albums = null;
            int iLimit = 7;

            string strSelectSql = "SELECT h.titelid" +
                " FROM history h" +
                " WHERE h.benutzer = ?User" +
                " ORDER BY h.zeit DESC LIMIT " + iLimit;
            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
            {
                List<int> titles = null;

                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "Benutzer";
                mySqlParameterUser.Value = strUserName;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        if (titles == null)
                        {
                            titles = new List<int>();
                        }
                        titles.Add(GetInt32(mySqlDataReader, "titelid", false, 0));
                    }
                }
                if (titles != null)
                {
                    titles.ForEach(title =>
                        {
                            Album album = GetAlbumDetailByTitelId(title, mySqlConnection);
                            if (album != null)
                            {
                                if (albums == null)
                                {
                                    albums = new List<Album>();
                                }
                                albums.Add(album);
                            }
                        });
                }
            }
            return albums;
        }

        private static SortableCollection<CHistoryTrack> GetHistoryTrackCollection(
            MySqlConnection mySqlConnection,
            SortableCollection<CHistoryTrack> trackCollection,
            string strUser)
        {
            int iPlayListLimit = 40;
            string strSelectSql = "SELECT h.titelid, h.liedid, h.zeit, i.interpret, t.titel, l.lied" +
                " FROM history h" +
                " JOIN titel t ON h.titelid = t.titelid" +
                " JOIN interpreten i ON t.interpretid = i.interpretid" +
                " LEFT JOIN lieder l ON h.liedid = l.liedid" +
                " WHERE h.benutzer = ?User" +
                " ORDER BY h.zeit DESC LIMIT " + iPlayListLimit;

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
            {
                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "Benutzer";
                mySqlParameterUser.Value = strUser;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        CHistoryTrack historyTrack = new CHistoryTrack();

                        historyTrack.TitelId = GetInt32(mySqlDataReader, "titelid", false, historyTrack.TitelId);
                        historyTrack.LiedId = GetInt32(mySqlDataReader, "liedid", true, historyTrack.LiedId);
                        historyTrack.Interpret = GetString(mySqlDataReader, "interpret", false, historyTrack.Interpret);
                        historyTrack.Album = GetString(mySqlDataReader, "titel", false, historyTrack.Album);
                        historyTrack.Title = GetString(mySqlDataReader, "lied", true, historyTrack.Title);
                        historyTrack.PlayedAt = GetDateTime(mySqlDataReader, "zeit", false, historyTrack.PlayedAt);

                        trackCollection.Add(historyTrack);
                    }
                }
            }
            return trackCollection;
        }

        private static int SelectLastIdFromHistory(MySqlConnection mySqlConnection, string strUser, int iPlayListLimit, out int iHistoryCounter)
        {
            int iLastId = 0;
            int iCounter = 0;

            string strSelectSql = "SELECT playid FROM history" +
                " WHERE benutzer = ?User" +
                " ORDER BY zeit" +
                " LIMIT ?LIMIT";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
            {
                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "Benutzer";
                mySqlParameterUser.Value = strUser;

                MySqlParameter mySqlParameterLIMIT = mySqlCommand.Parameters.Add(new MySqlParameter("LIMIT", MySqlDbType.Int32));
                mySqlParameterLIMIT.Direction = ParameterDirection.Input;
                mySqlParameterLIMIT.SourceColumn = "LIMIT";
                mySqlParameterLIMIT.Value = iPlayListLimit;

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        iLastId = (int)mySqlDataReader["playid"];
                        iCounter++;
                    }
                    iHistoryCounter = iCounter;
                }
            }
            return iLastId;
        }

        private static void DeleteTracksFromHistory(MySqlConnection mySqlConnection, string strUser, int iAppId, int iLastId)
        {
            string strDeleteSql = "DELETE FROM history" +
                " WHERE benutzer = ?User" +
                " AND appid = ?AppId" +
                " AND playid < ?LastId";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strDeleteSql, mySqlConnection))
            {
                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "Benutzer";
                mySqlParameterUser.Value = strUser;

                MySqlParameter mySqlParameterAppId = mySqlCommand.Parameters.Add(new MySqlParameter("AppId", MySqlDbType.Int32));
                mySqlParameterAppId.Direction = ParameterDirection.Input;
                mySqlParameterAppId.SourceColumn = "appid";
                mySqlParameterAppId.Value = iAppId;

                MySqlParameter mySqlParameterLastId = mySqlCommand.Parameters.Add(new MySqlParameter("LastId", MySqlDbType.Int32));
                mySqlParameterLastId.Direction = ParameterDirection.Input;
                mySqlParameterLastId.SourceColumn = "playid";
                mySqlParameterLastId.Value = iLastId;

                mySqlCommand.ExecuteNonQuery();
            }
        }

        private static void DeleteTracksFromHistory(MySqlConnection mySqlConnection, string strUser)
        {
            string strDeleteSql = "DELETE FROM history" +
                " WHERE benutzer = ?User" +
                " AND ((YEAR(CURRENT_DATE) * 12 + MONTH(CURRENT_DATE)) - (YEAR(zeit) * 12 + MONTH(zeit))) > 3";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strDeleteSql, mySqlConnection))
            {
                MySqlParameter mySqlParameterUser = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar, 50));
                mySqlParameterUser.Direction = ParameterDirection.Input;
                mySqlParameterUser.SourceColumn = "Benutzer";
                mySqlParameterUser.Value = strUser;
                mySqlCommand.ExecuteNonQuery();
            }
        }

        #endregion
        
        #endregion
    }
}
