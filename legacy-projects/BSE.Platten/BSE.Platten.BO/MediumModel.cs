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
    public class CMediumModel : ModelSql
    {
        #region MethodsPublic

        public CMediumModel()
        {
        }

        public static CDataSetMedium GetDataSetByQueryParams(string strConnection, CMediumData queryParams)
        {
            if (queryParams == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "queryParams"));
            }
            
            string strSelectSql = "SELECT * FROM medium m" +
                " WHERE m.medium LIKE ?Medium" +
                " AND m.beschreibung LIKE ?Beschreibung" +
                " ORDER BY m.medium,m.beschreibung";

            CDataSetMedium dataSet = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                {
                    dataSet = new CDataSetMedium();

                    mySqlDataAdapter.SelectCommand = new MySqlCommand(strSelectSql, mySqlConnection);
                    MySqlParameter mySqlParameter = mySqlDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("Medium", MySqlDbType.VarChar, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "Medium";
                    mySqlParameter.Value = queryParams.Medium;
                    mySqlParameter = mySqlDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("Beschreibung", MySqlDbType.VarChar, 0));
                    mySqlParameter.Direction = ParameterDirection.Input;
                    mySqlParameter.SourceColumn = "Beschreibung";
                    mySqlParameter.Value = queryParams.Beschreibung;

                    mySqlDataAdapter.Fill(dataSet, CDataSetMedium.SOURCETABLE);
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
                    if (!dataSet.HasErrors)
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

        public static Collection<CMediumData> GetMedia(string strConnection)
        {
            Collection<CMediumData> mediaCollection = new Collection<CMediumData>();
            string strSelectSql = "SELECT m.mediumid, m.medium, m.beschreibung," +
               " m.guid, m.timestamp" +
               " FROM medium m" +
               " ORDER BY m.medium";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            CMediumData medium = new CMediumData();

                            medium.MediumId = GetInt32(mySqlDataReader, "mediumid", false, medium.MediumId);
                            medium.Medium = GetString(mySqlDataReader, "medium", false, medium.Medium);
                            medium.Beschreibung = GetString(mySqlDataReader, "beschreibung", true, medium.Beschreibung);
                            medium.Guid = GetGuid(mySqlDataReader, "guid", false, Guid.NewGuid());
                            medium.TimeStamp = GetDateTime(mySqlDataReader, "timestamp", false, new DateTime());

                            mediaCollection.Add(medium);
                        }
                    }
                }
            }
            return mediaCollection;
        }

        #endregion

        #region MethodsPrivate

        private void Update(DataSet dataSet, MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT * FROM medium";

            string strInsertSql = "INSERT INTO medium " +
                " (mediumid,medium,beschreibung,guid) " +
                " VALUES(" +
                " 0,?Medium,?Beschreibung,?Guid)";

            string strUpdateSql = "UPDATE platten.medium" +
                " SET medium =?Medium, beschreibung = ?Beschreibung" +
                " WHERE mediumid =?MediumId" +
                " AND guid = ?Guid" +
                " AND timestamp = ?Timestamp";

            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(strSelectSql, mySqlConnection))
            {
                mySqlDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                mySqlDataAdapter.InsertCommand = new MySqlCommand(strInsertSql, mySqlConnection);
                InsertParams(mySqlDataAdapter.InsertCommand);
                mySqlDataAdapter.UpdateCommand = new MySqlCommand(strUpdateSql, mySqlConnection);
                UpdateParams(mySqlDataAdapter.UpdateCommand);

                mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(this.RowUpdated);

                mySqlDataAdapter.Update(dataSet, CDataSetMedium.SOURCETABLE);
            }
        }
        private void RowUpdated(object sender, MySqlRowUpdatedEventArgs rue)
        {

            if (rue.Status == UpdateStatus.ErrorsOccurred)
            {
                rue.Status = UpdateStatus.Continue;
                rue.Row.RowError = rue.Errors.Message;
            }
            else
            {
                rue.Row.ClearErrors();
                string strSelectSql = "SELECT * FROM medium m" +
                " WHERE m.guid = ?guid";

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
                                rue.Row["MediumId"] = GetInt32(mySqlDataReader, "MediumId", false, -1);
                            }
                            rue.Row["Timestamp"] = GetDateTime(mySqlDataReader, "Timestamp", false, new DateTime());
                        }
                    }
                }
            }
        }

        private static void InsertParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("MediumId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "MediumId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Medium", MySqlDbType.VarChar, 5));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Medium";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Beschreibung", MySqlDbType.VarChar, 50));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Beschreibung";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceVersion = System.Data.DataRowVersion.Original;
            mySqlParameter.IsNullable = false;
            mySqlParameter.SourceColumn = "Guid";
        }

        private static void UpdateParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("MediumId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "MediumId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Medium", MySqlDbType.VarChar, 5));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Medium";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Beschreibung", MySqlDbType.VarChar, 50));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Beschreibung";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Guid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Timestamp", MySqlDbType.Timestamp, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Timestamp";
        }
        #endregion
    }
}
