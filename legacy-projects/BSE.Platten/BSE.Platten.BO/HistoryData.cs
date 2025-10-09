using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    public class HistoryData
    {
        #region Properties
        /// <summary>
        /// Gets or sets the AppId
        /// </summary>
        public int AppId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the time when the song was played
        /// </summary>
        public DateTime PlayedAt
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the TitelId
        /// </summary>
        public int TitelId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the LiedId
        /// </summary>
        public int LiedId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName
        {
            get;
            set;
        }
        #endregion
    }
}
