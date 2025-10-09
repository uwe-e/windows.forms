using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.Globalization;

namespace BSE.Platten.BO
{
	/// <summary>
    /// The mysql model class in which all the relevant database operation
    /// for the statistic system informations are implemented.
	/// </summary>
    public class StatisticModel : ModelSql
	{
		#region MethodsPublic
        /// <summary>
        /// Gets a <see cref="StatisticData"/> object with the statistic informations.
        /// </summary>
        /// <param name="strConnection">The connection string for the database queries.</param>
        /// <returns>A <see cref="StatisticData"/> object with the informations.</returns>
        public static StatisticData GetStatisticInformation(string strConnection)
        {
            StatisticData statisticData = new StatisticData();
            using (MySqlConnection mySqlConnection = new MySqlConnection(strConnection))
            {
                mySqlConnection.Open();
                GetCountAlbumsGroupedByMedium(mySqlConnection,statisticData);
                GetTotalDuration(mySqlConnection,statisticData);
                GetCountAlbumsTotal(mySqlConnection,statisticData);
                GetCountAlbumsRecorded(mySqlConnection,statisticData);
                GetCountTracksTotal(mySqlConnection,statisticData);
            }
            return statisticData;
        }

		#endregion

		#region MethodsPrivate
        
        private static void GetCountAlbumsGroupedByMedium(MySqlConnection mySqlConnection, StatisticData statisticData)
        {
            ArrayList aCountAlbumsGroupedByMedium = new ArrayList();

            string strSelectAlbumsGroupedByMedium = "SELECT CONVERT(count(*), SIGNED INTEGER) AS count, m.medium " +
                "FROM titel t " +
                "INNER JOIN medium m ON t.mediumId = m.mediumId " +
                "GROUP BY m.medium " +
                "ORDER BY count DESC";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectAlbumsGroupedByMedium, mySqlConnection))
            {
                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        StatisticCountAlbumsGroupedByMedium statistikAlbumsGroupedByMedium = new StatisticCountAlbumsGroupedByMedium
                        {
                            Count = Convert.ToInt32(GetInt64(mySqlDataReader, "count", false, 0)),
                            Medium = GetString(mySqlDataReader, "medium", true, null)
                        };
                        aCountAlbumsGroupedByMedium.Add(statistikAlbumsGroupedByMedium);
                    }
                }
            }

            if (aCountAlbumsGroupedByMedium.Count > 0)
            {
                statisticData.CountAlbumsGroupedByMedium = new StatisticCountAlbumsGroupedByMedium[aCountAlbumsGroupedByMedium.Count];
                aCountAlbumsGroupedByMedium.CopyTo(statisticData.CountAlbumsGroupedByMedium);
            }
        }

        private static void GetTotalDuration(MySqlConnection mySqlConnection, StatisticData statisticData)
        {
            string strSelectDuration = "SELECT CAST(SUM(HOUR(dauer)) * 3600 + SUM(MINUTE(dauer)) * 60 + SUM(SECOND(dauer)) AS SIGNED INTEGER) AS second " +
                "FROM lieder l WHERE Liedpfad IS NOT NULL";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectDuration, mySqlConnection))
            {
                object objSecond = mySqlCommand.ExecuteScalar();
                if (objSecond is long)
                {
                    long ticksPerSecond = (long)objSecond * 0x989680L;
                    statisticData.TotalDuration = new TimeSpan(ticksPerSecond);
                }
            }
        }

        private static void GetCountAlbumsTotal(MySqlConnection mySqlConnection, StatisticData statisticData)
        {
            string strSelectCountAlbumsTotal = "SELECT COUNT(*) AS count FROM titel t ";
            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectCountAlbumsTotal, mySqlConnection))
            {
                object objCount = mySqlCommand.ExecuteScalar();
                if (objCount is long)
                {
                    statisticData.CountAlbumsTotal = Convert.ToInt32((long)objCount);
                }
            }
        }

        private static void GetCountAlbumsRecorded(MySqlConnection mySqlConnection, StatisticData statisticData)
        {
            string strSelectCountAlbumsRecorded = "SELECT count(DISTINCT t.titelId) as count " +
                " FROM titel t" +
                " INNER JOIN lieder l ON t.titelid = l.titelid AND l.liedpfad IS NOT NULL";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectCountAlbumsRecorded, mySqlConnection))
            {
                object objCount = mySqlCommand.ExecuteScalar();
                if (objCount is long)
                {
                    statisticData.CountAlbumsRecorded = Convert.ToInt32((long)objCount);
                }
            }
        }

        private static void GetCountTracksTotal(MySqlConnection mySqlConnection, StatisticData statisticData)
        {
            string strSelectCountTracksTotal = "SELECT COUNT(*) AS count FROM lieder t WHERE liedpfad IS NOT NULL";

            using (MySqlCommand mySqlCommand = new MySqlCommand(strSelectCountTracksTotal, mySqlConnection))
            {
                object objCount = mySqlCommand.ExecuteScalar();
                if (objCount is long)
                {
                    statisticData.CountTracksTotal = Convert.ToInt32((long)objCount);
                }
            }
        }

		#endregion
	}
}
