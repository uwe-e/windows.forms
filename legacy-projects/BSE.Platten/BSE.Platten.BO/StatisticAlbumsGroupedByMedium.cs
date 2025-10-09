using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    /// <summary>
    /// This class contains the count and the name of a specific medium.
    /// </summary>
    public class StatisticCountAlbumsGroupedByMedium
    {
        #region Properties
        /// <summary>
        /// Gets or sets the count of a specific medium.
        /// </summary>
        public int Count
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name of a specific medium.
        /// </summary>
        public string Medium
        {
            get;
            set;
        }
        #endregion
    }
}
