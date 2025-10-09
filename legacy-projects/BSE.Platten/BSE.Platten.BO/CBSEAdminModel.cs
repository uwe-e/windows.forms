using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using BSE.Platten.BO.Properties;

namespace BSE.Platten.BO
{
    public class CBSEAdminModel : ModelSql
    {
        #region MethodsPublic

        public static CDataSetAlbum GetDataSetAlbumByQueryParams(string strConnection, Album queryParamsAlbum)
        {
            if (queryParamsAlbum == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    typeof(Album).Name));
            }
            
            string strSelectAlbumSql = "SELECT t.titelid, i.interpret, t.titel," +
                " t.interpretid, t.erschdatum, t.mediumid, t.genreid, t.mp3tag, t.guid," +
                " t.pictureformat, t.cover,t.thumbnail, t.erstelldatum," +
                " t.erstellernm, t.mutationdatum, t.mutationnm, t.timestamp" +
                " FROM platten.titel t" +
                " JOIN platten.interpreten i ON t.interpretid = i.interpretid" +
                " WHERE i.interpret LIKE ?interpret" +
                " AND t.titel LIKE ?Titel";
            if (queryParamsAlbum.MediumId > 0)
            {
                strSelectAlbumSql += " AND t.mediumid = ?MediumId";
            }
            if (queryParamsAlbum.GenreId > 0)
            {
                strSelectAlbumSql += " AND t.genreid = ?GenreId";
            }
            if (queryParamsAlbum.Year > 0)
            {
                strSelectAlbumSql += " AND t.erschdatum = ?ErschDatum";
            }
            strSelectAlbumSql += " ORDER BY i.interpret,t.titel";

            string strSelectTracksSql = "Select l.liedid,l.titelid,l.track,l.lied," +
                " l.dauer,l.liedpfad,l.guid,l.timestamp FROM platten.lieder l" +
                " JOIN platten.titel t ON l.titelid = t.titelid" +
                " JOIN platten.interpreten i ON t.interpretid = i.interpretid" +
                " WHERE i.interpret LIKE ?Interpret" +
                " AND t.titel LIKE ?Titel";
            if (queryParamsAlbum.MediumId > 0)
            {
                strSelectTracksSql += " AND t.mediumid = ?mediumID";
            }
            if (queryParamsAlbum.GenreId > 0)
            {
                strSelectTracksSql += " AND t.genreid = ?GenreId";
            }
            if (queryParamsAlbum.Year > 0)
            {
                strSelectTracksSql += " AND t.erschdatum = ?ErschDatum";
            }
            strSelectTracksSql += " ORDER BY l.track";

            CDataSetAlbum dataSet = null;

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                dataSet = new CDataSetAlbum();

                using (MySqlDataAdapter mySqlDataAdapterAlbum = new MySqlDataAdapter())
                {
                    mySqlDataAdapterAlbum.SelectCommand = new MySqlCommand(strSelectAlbumSql, mySqlConnection);
                    SelectAlbumParams(mySqlDataAdapterAlbum.SelectCommand, queryParamsAlbum);
                    mySqlDataAdapterAlbum.Fill(dataSet, "Album");
                }

                using (MySqlDataAdapter mySqlDataAdapterTracks = new MySqlDataAdapter())
                {
                    mySqlDataAdapterTracks.SelectCommand = new MySqlCommand(strSelectTracksSql, mySqlConnection);
                    SelectAlbumParams(mySqlDataAdapterTracks.SelectCommand, queryParamsAlbum);
                    mySqlDataAdapterTracks.Fill(dataSet, "Tracks");
                }
            }
            return dataSet;
        }

        public static CDataSetAlbum GetDataSetAlbumByTitelId(string strConnection, int iTitelId)
        {
            string strSelectAlbumSql = "SELECT t.titelid, i.interpret, t.titel," +
                " t.interpretid, t.erschdatum, t.mediumid, t.genreid, t.mp3tag, t.guid," +
                " t.pictureformat, t.cover, t.thumbnail , t.erstelldatum," +
                " t.erstellernm, t.mutationdatum, t.mutationnm, t.timestamp" +
                " FROM platten.titel t" +
                " JOIN platten.interpreten i ON t.interpretid = i.interpretid" +
                " WHERE t.titelid = ?TitelID";

            string strSelectTracksSql = "Select l.liedid,l.titelid,l.track,l.lied," +
                " l.dauer,l.liedpfad,l.guid,l.timestamp FROM platten.lieder l" +
                " JOIN platten.titel t ON l.titelid = t.titelid" +
                " JOIN platten.interpreten i ON t.interpretid = i.interpretid" +
                " WHERE t.titelid = ?TitelID" +
                " ORDER BY l.track";

            CDataSetAlbum dataSet = null;

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                dataSet = new CDataSetAlbum();

                using (MySqlDataAdapter mySqlDataAdapterAlbum = new MySqlDataAdapter())
                {
                    mySqlDataAdapterAlbum.SelectCommand = new MySqlCommand(strSelectAlbumSql, mySqlConnection);
                    MySqlParameter mySqlParameter = mySqlDataAdapterAlbum.SelectCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "TitelID";
                    mySqlParameter.Value = iTitelId;
                    mySqlDataAdapterAlbum.Fill(dataSet, "Album");
                }

                using (MySqlDataAdapter mySqlDataAdapterTracks = new MySqlDataAdapter())
                {
                    mySqlDataAdapterTracks.SelectCommand = new MySqlCommand(strSelectTracksSql, mySqlConnection);
                    MySqlParameter mySqlParameter = mySqlDataAdapterTracks.SelectCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "TitelID";
                    mySqlParameter.Value = iTitelId;
                    mySqlDataAdapterTracks.Fill(dataSet, "Tracks");
                }
            }
            return dataSet;
        }

        public DataSet Update(string strConnection, DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    typeof(DataSet).Name));
            }
            
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                try
                {
                    using (MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction())
                    {
                        bool bHasError = false;
                        if (dataSet.Tables[0].GetChanges() != null)
                        {
                            UpdateAlbum(dataSet, mySqlConnection);
                            //Workaround
                            //Die MySql MyISAM Engine kann nicht mit Transactions umgehen.
                            //Da bei Änderungen der Tracks das Mutationsdatum in den Titel Datensatz geschrieben wird
                            //kann so die Mutation des Tracks verhindert werden
                            if (dataSet.Tables[0].HasErrors == true)
                            {
                                bHasError = true;
                            }
                        }
                        if (dataSet.Tables[1].GetChanges() != null)
                        {
                            if (bHasError == false)
                            {
                                UpdateTracks(dataSet, mySqlConnection);
                            }
                        }
                        if (dataSet.HasErrors == false)
                        {
                            mySqlTransaction.Commit();
                            dataSet.AcceptChanges();
                        }
                    }
                }
                catch (MySqlException)
                {
                    throw;
                }
            }
            return dataSet;
        }

        #endregion

        #region MethodsPrivate

        private void UpdateAlbum(DataSet dataSet, MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT t.titelid, i.interpret, t.titel," +
                " t.interpretid, t.erschdatum, t.mediumid, t.genreid, t.mp3tag, t.guid," +
                " t.pictureformat, t.cover, t.thumbnail, t.erstelldatum," +
                " t.erstellernm, t.mutationdatum, t.mutationnm, t.timestamp" +
                " FROM platten.titel t" +
                " JOIN platten.interpreten i ON t.interpretid = i.interpretid";

            string strInsertSql = "INSERT INTO platten.titel " +
                " (titelid,titel,interpretid,erschdatum,mediumid,genreid,mp3tag,guid," +
                " pictureformat,cover,thumbnail,erstelldatum,erstellernm) " +
                " VALUES(" +
                " 0,?Titel,?InterpretId,?ErschDatum,?MediumID,?GenreId,0,?Guid," +
                " ?PictureFormat,?Cover,?ThumbNail,now(),?ErstellerNm)";

            string strUpdateSql = "Update platten.titel" +
                " Set interpretid =?InterpretId, titel = ?Titel," +
                "erschDatum = ?ErschDatum, mediumid = ?MediumID, genreid = ?GenreId," +
                "mp3tag = ?mp3Tag," +
                "pictureformat = ?PictureFormat,cover = ?Cover,thumbnail = ?ThumbNail,mutationdatum = now(),mutationnm = ?MutationNm " +
                " WHERE titelid = ?TitelId AND guid = ?Guid AND timestamp = ?Timestamp";

            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(strSelectSql, mySqlConnection))
            {
                mySqlDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                mySqlDataAdapter.InsertCommand = new MySqlCommand(strInsertSql, mySqlConnection);
                InsertAlbumParams(mySqlDataAdapter.InsertCommand);
                mySqlDataAdapter.UpdateCommand = new MySqlCommand(strUpdateSql, mySqlConnection);
                UpdateAlbumParams(mySqlDataAdapter.UpdateCommand);

                mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(this.Albums_Updated);

                mySqlDataAdapter.Update(dataSet, "Album");
            }
        }

        private void Albums_Updated(object sender, MySqlRowUpdatedEventArgs rue)
        {
            if (rue.Status == UpdateStatus.ErrorsOccurred)
            {
                rue.Status = UpdateStatus.Continue;
                rue.Row.RowError = rue.Errors.Message;
            }
            else
            {
                rue.Row.ClearErrors();
                string strSelectSql = "SELECT * FROM titel t" +
                " WHERE t.guid = ?guid";

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, rue.Command.Connection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "guid";
                    mySqlParameter.Value = rue.Row["guid"];

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            if (rue.StatementType == StatementType.Insert)
                            {
                                rue.Row["TitelId"] = GetInt32(mySqlDataReader, "TitelId", false, -1);
                                rue.Row["ErstellDatum"] = GetDateTime(mySqlDataReader, "ErstellDatum", true, new DateTime());
                                rue.Row["ErstellerNm"] = GetString(mySqlDataReader, "ErstellerNm", true, System.Environment.UserName);
                            }

                            if (rue.StatementType == StatementType.Update)
                            {
                                rue.Row["MutationDatum"] = GetDateTime(mySqlDataReader, "MutationDatum", true, new DateTime());
                                rue.Row["MutationNm"] = GetString(mySqlDataReader, "MutationNm", true, System.Environment.UserName);
                            }
                            rue.Row["Timestamp"] = GetDateTime(mySqlDataReader, "Timestamp", false, new DateTime());
                        }
                    }
                }
            }
        }

        private void UpdateTracks(DataSet dataSet, MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT * FROM platten.lieder WHERE liedid = ?LiedID";

            string strInsertSql = "INSERT INTO platten.lieder (liedid,titelid,track,lied,dauer,liedpfad,guid)" +
                " VALUES (0,?TitelId,?Track,?Lied,?Dauer,?Liedpfad,?guid)";

            string strUpdateSql = "UPDATE platten.lieder SET track = ?Track,lied = ?Lied,dauer = ?Dauer," +
                "liedpfad = ?Liedpfad" +
                " WHERE liedid = ?LiedID AND timestamp =?TimeStamp";

            string strDeleteSql = "DELETE FROM platten.lieder WHERE liedid = ?LiedID";

            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
            {
                mySqlDataAdapter.SelectCommand = new MySqlCommand(strSelectSql, mySqlConnection);
                SelectTracksParams(mySqlDataAdapter.SelectCommand);
                mySqlDataAdapter.InsertCommand = new MySqlCommand(strInsertSql, mySqlConnection);
                InsertTracksParams(mySqlDataAdapter.InsertCommand);
                mySqlDataAdapter.UpdateCommand = new MySqlCommand(strUpdateSql, mySqlConnection);
                UpdateTracksParams(mySqlDataAdapter.UpdateCommand);
                mySqlDataAdapter.DeleteCommand = new MySqlCommand(strDeleteSql, mySqlConnection);
                DeleteTracksParams(mySqlDataAdapter.DeleteCommand);

                mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(this.Tracks_Updated);
                mySqlDataAdapter.Update(dataSet, "Tracks");
            }
        }

        private void Tracks_Updated(object sender, MySqlRowUpdatedEventArgs rue)
        {
            if (rue.Status == UpdateStatus.ErrorsOccurred)
            {
                rue.Status = UpdateStatus.Continue;
                rue.Row.RowError = rue.Errors.Message;
            }
            else
            {
                rue.Row.ClearErrors();
                if (rue.StatementType == StatementType.Delete)
                {
                    return;
                }
                string strSelectSql = "SELECT * FROM lieder l" +
                " WHERE l.guid = ?guid";


                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, rue.Command.Connection))
                {
                    MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "guid";
                    mySqlParameter.Value = rue.Row["guid"];

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            if (rue.StatementType == StatementType.Insert)
                            {
                                rue.Row["LiedID"] = GetInt32(mySqlDataReader, "LiedID", false, -1);
                            }
                            rue.Row["Timestamp"] = GetDateTime(mySqlDataReader, "Timestamp", false, new DateTime());
                        }
                    }
                }
            }
        }

        private static void SelectAlbumParams(MySqlCommand mySqlCommand, Album queryParamsAlbum)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Interpret", MySqlDbType.VarChar, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Interpret";
            mySqlParameter.Value = queryParamsAlbum.Interpret;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Titel", MySqlDbType.VarChar, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Titel";
            mySqlParameter.Value = queryParamsAlbum.Title;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("MediumID", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "MediumID";
            mySqlParameter.Value = queryParamsAlbum.MediumId;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("GenreId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "genreid";
            mySqlParameter.Value = queryParamsAlbum.GenreId;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ErschDatum", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "ErschDatum";
            mySqlParameter.Value = queryParamsAlbum.Year;
        }

        private static void InsertAlbumParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "InterpretId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Titel", MySqlDbType.VarChar, 60));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Titel";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ErschDatum", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "ErschDatum";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("MediumId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "MediumId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("GenreId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "GenreId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceVersion = System.Data.DataRowVersion.Original;
            mySqlParameter.SourceColumn = "Guid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("PictureFormat", MySqlDbType.VarChar, 5));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "PictureFormat";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Cover", MySqlDbType.Blob, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Cover";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ThumbNail", MySqlDbType.MediumBlob, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "ThumbNail";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ErstellerNm", MySqlDbType.VarChar, 50));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "ErstellerNm";
        }

        private static void UpdateAlbumParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "TitelId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "InterpretId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Titel", MySqlDbType.VarChar, 60));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Titel";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ErschDatum", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "ErschDatum";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("MediumId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "MediumId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("GenreId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "GenreId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Guid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("PictureFormat", MySqlDbType.VarChar, 5));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "PictureFormat";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Cover", MySqlDbType.Blob, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Cover";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("ThumbNail", MySqlDbType.MediumBlob, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "ThumbNail";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("MutationNm", MySqlDbType.VarChar, 50));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "MutationNm";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Timestamp", MySqlDbType.Timestamp, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Timestamp";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Mp3Tag", MySqlDbType.Bit, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Mp3Tag";
        }

        private static void SelectTracksParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("LiedID", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "LiedID";
        }

        private static void InsertTracksParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("LiedID", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "LiedID";
            mySqlParameter.SourceVersion = DataRowVersion.Original;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("TitelID", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "TitelID";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Track", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Track";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Lied", MySqlDbType.VarChar, 100));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Lied";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Dauer", MySqlDbType.DateTime, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Dauer";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Liedpfad", MySqlDbType.VarChar, 255));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Liedpfad";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Guid";
        }

        private static void UpdateTracksParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("LiedID", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "LiedID";
            mySqlParameter.SourceVersion = DataRowVersion.Original;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Track", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Track";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Lied", MySqlDbType.VarChar, 100));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Lied";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Dauer", MySqlDbType.DateTime, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Dauer";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Liedpfad", MySqlDbType.VarChar, 255));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Liedpfad";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Timestamp", MySqlDbType.Timestamp, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Timestamp";
        }

        private static void DeleteTracksParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("LiedID", MySqlDbType.Int32, 11));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "LiedID";
        }

        #endregion
    }
}
