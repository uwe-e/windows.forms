using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Globalization;
using BSE.Platten.BO.Properties;

namespace BSE.Platten.BO
{
    public class CInterpretModel : ModelSql
    {
        #region MethodsPublic

		public CInterpretModel()
		{
		}

        public static CDataSetInterpret GetDataSetInterpretByQueryParams(string strConnection, CInterpretData queryParams)
        {
            if (queryParams == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.CurrentUICulture,
                    Resources.IDS_ArgumentException,
                    "queryParams"));
            }
            
            string strSelectSql = "SELECT * FROM platten.interpreten" +
                " WHERE interpret LIKE ?Interpret" +
                " AND interpret_lang LIKE ?InterpretLang" +
                " ORDER BY interpret,interpret_lang";

            CDataSetInterpret dataSet = null;
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                dataSet = new CDataSetInterpret();

                using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                {
                    mySqlDataAdapter.SelectCommand = new MySqlCommand(strSelectSql, mySqlConnection);

                    MySqlParameter mySqlParameter = mySqlDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("Interpret", MySqlDbType.VarChar, 60));
                    mySqlParameter.SourceColumn = "Interpret";
                    mySqlParameter.Value = queryParams.Interpret;
                    mySqlParameter = mySqlDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("InterpretLang", MySqlDbType.VarChar, 60));
                    mySqlParameter.SourceColumn = "Interpret_Lang";
                    mySqlParameter.Value = queryParams.InterpretLang;

                    mySqlDataAdapter.Fill(dataSet, CDataSetInterpret.SOURCETABLE);
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
                        UpdateInterprets(dataSet, mySqlConnection);
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

        public static Collection<CInterpretData> GetInterprets(string strConnection)
        {
            Collection<CInterpretData> interpretCollection = new Collection<CInterpretData>();
            string strSelectSql = "SELECT i.interpretid, i.interpret, i.interpret_lang," +
                " i.guid, i.timestamp" +
                " FROM interpreten i" +
                " ORDER BY i.interpret";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                {
                    using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            CInterpretData interpret = new CInterpretData();

                            interpret.InterpretId = GetInt32(mySqlDataReader, "interpretid", false, interpret.InterpretId);
                            interpret.Interpret = GetString(mySqlDataReader, "interpret", false, interpret.Interpret);
                            interpret.InterpretLang = GetString(mySqlDataReader, "interpret_lang", false, interpret.InterpretLang);
                            interpret.Guid = GetGuid(mySqlDataReader, "guid", false, Guid.NewGuid());
                            interpret.TimeStamp = GetDateTime(mySqlDataReader, "timestamp", false, new DateTime());

                            interpretCollection.Add(interpret);
                        }
                    }
                }
            }
            return interpretCollection;
        }

        #endregion

        #region MethodsPrivate

        private void UpdateInterprets(DataSet dataSet, MySqlConnection mySqlConnection)
        {
            string strSelectSql = "SELECT i.interpretid, i.interpret, i.interpret_lang," +
                " i.guid, i.timestamp" +
                " FROM interpreten i";

            string strInsertSql = "INSERT INTO interpreten " +
                " (interpretid,interpret,interpret_lang,guid) " +
                " VALUES(" +
                " 0,?Interpret,?InterpretLang,?Guid)";

            string strUpdateSql = "Update interpreten" +
                " Set interpret = ?Interpret," +
                " interpret_lang = ?InterpretLang" +
                " WHERE interpretid = ?InterpretId" +
                " AND guid = ?Guid" +
                " AND timestamp = ?Timestamp";

            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(strSelectSql, mySqlConnection))
            {
                mySqlDataAdapter.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                mySqlDataAdapter.InsertCommand = new MySqlCommand(strInsertSql, mySqlConnection);
                InsertInterpretParams(mySqlDataAdapter.InsertCommand);
                mySqlDataAdapter.UpdateCommand = new MySqlCommand(strUpdateSql, mySqlConnection);
                UpdateInterpretParams(mySqlDataAdapter.UpdateCommand);

                mySqlDataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(this.Interprets_RowUpdated);

                mySqlDataAdapter.Update(dataSet, CDataSetInterpret.SOURCETABLE);
            }
        }

        private void Interprets_RowUpdated(object sender, MySqlRowUpdatedEventArgs rue)
        {
            if (rue.Status == UpdateStatus.ErrorsOccurred)
            {
                rue.Status = UpdateStatus.Continue;
                rue.Row.RowError = rue.Errors.Message;
            }
            else
            {
                rue.Row.ClearErrors();
                string strSelectSql = "SELECT * FROM interpreten i" +
                " WHERE i.guid = ?guid";

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
                                rue.Row["InterpretId"] = GetInt32(mySqlDataReader, "InterpretId", false, -1);
                            }

                            rue.Row["Timestamp"] = GetDateTime(mySqlDataReader, "Timestamp", false, new DateTime());
                        }
                    }
                }
            }
        }

        private static void InsertInterpretParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "InterpretId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Interpret", MySqlDbType.VarChar, 60));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.IsNullable = false;
            mySqlParameter.SourceColumn = "Interpret";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretLang", MySqlDbType.VarChar, 60));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Interpret_Lang";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceVersion = System.Data.DataRowVersion.Original;
            mySqlParameter.IsNullable = false;
            mySqlParameter.SourceColumn = "Guid";
        }

        private static void UpdateInterpretParams(MySqlCommand mySqlCommand)
        {
            MySqlParameter mySqlParameter = null;
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretId", MySqlDbType.Int32, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "InterpretId";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Interpret", MySqlDbType.VarChar, 60));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.IsNullable = false;
            mySqlParameter.SourceColumn = "Interpret";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("InterpretLang", MySqlDbType.VarChar, 60));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Interpret_Lang";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Guid", MySqlDbType.VarChar, 36));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.IsNullable = false;
            mySqlParameter.SourceColumn = "Guid";
            mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("Timestamp", MySqlDbType.Timestamp, 0));
            mySqlParameter.Direction = ParameterDirection.Input;
            mySqlParameter.SourceColumn = "Timestamp";
        }

        #endregion
    }
}
