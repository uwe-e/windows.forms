using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Globalization;
using BSE.Platten.BO.Properties;

namespace BSE.Platten.BO
{
    public class CGenreModel : ModelSql
    {
        #region MethodsPublic

        public CGenreModel()
        {
        }

        public static CDataSetGenre GetDataSetGenreByQueryParams(string strConnection, CGenreData queryParams)
        {
            if (queryParams == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "queryParams"));
            }
            
            string strSelectSql = "SELECT * FROM genre g" +
                " WHERE g.genre LIKE ?Genre" +
                " ORDER BY g.genre";

            CDataSetGenre dataSet = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                {
                    dataSet = new CDataSetGenre();

                    mySqlDataAdapter.SelectCommand = new MySqlCommand(strSelectSql, mySqlConnection);
                    MySqlParameter mySqlParameter = mySqlDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("Genre", MySqlDbType.VarChar, 100));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "Genre";
                    mySqlParameter.Value = queryParams.Genre;

                    mySqlDataAdapter.Fill(dataSet, CDataSetGenre.SOURCETABLE);
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
                    "dataSet"));
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                try
                {
                    if (dataSet.Tables[0].GetChanges() != null)
                    {
                        Update(dataSet, mySqlConnection);
                    }
                    if (dataSet.HasErrors == false)
                    {
                        dataSet.AcceptChanges();
                    }
                }
                catch (MySqlException)
                {
                    throw;
                }
            }
            return dataSet;
        }
        public static CGenreData GetGenreByGenreId(string strConnection, int iGenreId)
        {
            CGenreData genreData = null;
            string strSelectSql = "SELECT * FROM genre g" +
                " WHERE g.genreid = ?GenreId";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    MySqlParameter mySqlParamter = mySqlCommand.Parameters.Add(new MySqlParameter("GenreId", MySqlDbType.Int32, 0));
                    mySqlParamter.Direction = ParameterDirection.Input;
                    mySqlParamter.SourceColumn = "genreid";
                    mySqlParamter.Value = iGenreId;

                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        if (mySqlDataReader.Read())
                        {
                            genreData = new CGenreData{
                                GenreId = GetInt32(mySqlDataReader, "genreid", false, 0),
                                Genre = GetString(mySqlDataReader, "genre", false, null),
                            };
                        }
                    }
                }
            }
            return genreData;
        }
        public static Collection<CGenreData> GetGenres(string strConnection)
        {
            Collection<CGenreData> genreCollection = new Collection<CGenreData>();
            string strSelectSql = "SELECT g.genreid, g.genre, g.guid, g.timestamp" +
                " FROM genre g" +
                " ORDER BY g.genre";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            CGenreData genre = new CGenreData();

                            genre.GenreId = GetInt32(mySqlDataReader, "genreid", false, genre.GenreId);
                            genre.Genre = GetString(mySqlDataReader, "genre", false, genre.Genre);
                            genre.Guid = GetGuid(mySqlDataReader, "guid", false, Guid.NewGuid());
                            genre.TimeStamp = GetDateTime(mySqlDataReader, "timestamp", false, new DateTime());

                            genreCollection.Add(genre);
                        }
                    }
                }
            }
            return genreCollection;
        }

        #endregion

        #region MethodsPrivate

        private void Update(DataSet dataSet, MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT * FROM genre g";

            string strInsertSql = "INSERT INTO genre " +
                " (genreid,genre,guid) " +
                " VALUES(" +
                "0,?Genre,?Guid)";

            string strUpdateSql = "UPDATE genre" +
                " SET genre = ?Genre" +
                " WHERE genreid = ?GenreId" +
                " AND guid = ?Guid" +
                " AND timestamp = ?Timestamp";

            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(strSelectSql, mySqlConnection))
            {
                mySqlDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                mySqlDataAdapter.InsertCommand = new MySqlCommand(strInsertSql, mySqlConnection);
                InsertGenreParams(mySqlDataAdapter.InsertCommand);
                mySqlDataAdapter.UpdateCommand = new MySqlCommand(strUpdateSql, mySqlConnection);
                UpdateGenreParams(mySqlDataAdapter.UpdateCommand);

                mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(GenreRowUpdated);
                mySqlDataAdapter.Update(dataSet, CDataSetGenre.SOURCETABLE);
            }
        }

        private void GenreRowUpdated(object sender, MySqlRowUpdatedEventArgs rue)
        {
            if (rue.Status == UpdateStatus.ErrorsOccurred)
            {
                rue.Status = UpdateStatus.Continue;
                rue.Row.RowError = rue.Errors.Message;
            }
            else
            {
                rue.Row.ClearErrors();
                string strSelectSql = "SELECT * FROM genre g" +
                " WHERE g.guid = ?guid";

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
                                rue.Row["GenreId"] = GetInt32(mySqlDataReader, "GenreId", false, -1);
                            }
                            rue.Row["Timestamp"] = GetDateTime(mySqlDataReader, "Timestamp", false, new DateTime());
                        }
                    }
                }
            }
        }

        private static void InsertGenreParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("GenreId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "genreid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Genre", MySqlDbType.VarChar, 100));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "genre";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceVersion = System.Data.DataRowVersion.Original;
            mySqlParameter.IsNullable = false;
            mySqlParameter.SourceColumn = "guid";
        }

        private static void UpdateGenreParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("GenreId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "genreid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Genre", MySqlDbType.VarChar, 100));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "genre";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "guid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Timestamp", MySqlDbType.Timestamp, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "timestamp";
        }

        #endregion
    }
}
