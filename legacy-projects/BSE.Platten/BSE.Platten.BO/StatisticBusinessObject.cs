using System;
using System.Data;

namespace BSE.Platten.BO
{
    /// <summary>
    /// A class that contains all the bussiness objects for statistic system informations.
    /// </summary>
    public class StatisticBusinessObject
    {
        #region Properties
        /// <summary>
        /// Gets or sets the connection string for the database queries.
        /// </summary>
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the <see cref="StatistikBusinessObject"/> class.
        /// </summary>
        public StatisticBusinessObject()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StatistikBusinessObject"/> class.
        /// </summary>
        /// <param name="strConnection">The connection string for the database queries.</param>
        public StatisticBusinessObject(string strConnection)
            : this()
        {
            this.ConnectionString = strConnection;
        }
        /// <summary>
        /// Gets a <see cref="StatisticData"/> object with the statistic system informations.
        /// </summary>
        /// <returns>A <see cref="StatisticData"/> object with the informations.</returns>
        public StatisticData GetStatisticInformation()
        {
            return StatisticModel.GetStatisticInformation(this.ConnectionString);
        }
        #endregion
    }
}
