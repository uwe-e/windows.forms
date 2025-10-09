using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BSE.Platten.BO
{
    public class CHostModel
    {
        #region MethodsPublic

        public CHostModel()
        {
        }

        public static bool IsHostAvailable(string strConnection)
        {
            bool bHostIsAvailable = false;
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
                {
                    mySqlConnection.Open();
                    bHostIsAvailable = true;
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                bHostIsAvailable = false;
            }
            catch (MySqlException)
            {
                bHostIsAvailable = false;
            }
            return bHostIsAvailable;
        }

        public static CUserGrant GetUserGrant(string strConnection, string userName)
        {
            CUserGrant userGrant = new CUserGrant();
            string strSelectSql = "show grants for ?User";

            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();

                try
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectSql, mySqlConnection))
                    {
                        MySqlParameter mySqlParameter = mySqlCommand.Parameters.Add(new MySqlParameter("User", MySqlDbType.VarChar));
                        mySqlParameter.Direction = System.Data.ParameterDirection.Input;
                        mySqlParameter.SourceColumn = "User";
                        mySqlParameter.Value = userName;

                        using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                        {
                            while (mySqlDataReader.Read())
                            {
                                string strGrants = mySqlDataReader[0] as string;
                                if (string.IsNullOrEmpty(strGrants) == false)
                                {
                                    if (strGrants.StartsWith(CUserGrant.GrantPlattenTitel) == true)
                                    {
                                        userGrant.Grant = true;
                                        break;
                                    }
                                    if (strGrants.StartsWith(CUserGrant.GrantPlatten) == true)
                                    {
                                        userGrant.Grant = true;
                                        break;
                                    }
                                    if (strGrants.StartsWith(CUserGrant.GrantRoot) == true)
                                    {
                                        userGrant.Grant = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (MySqlException)
                {
                    throw;
                }
            }
            return userGrant;
        }

        #endregion
    }
}
