using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    /// <summary>
    /// This class contains all properties used for statistic informations.
    /// </summary>
    public class StatisticData
    {
        /// <summary>
        /// Gets or sets the total duration of all available tracks.
        /// </summary>
        public TimeSpan TotalDuration
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the count of all albums.
        /// </summary>
        public int CountAlbumsTotal
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the count of all recorded albums.
        /// </summary>
        public int CountAlbumsRecorded
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the count of all recorded tracks.
        /// </summary>
        public int CountTracksTotal
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the count and the name of all grouped medium types 
        /// </summary>
        public StatisticCountAlbumsGroupedByMedium[] CountAlbumsGroupedByMedium
        {
            get;
            set;
        }
    }
}
