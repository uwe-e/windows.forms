using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.BO
{
    /// <summary>
    /// Dataobject that contains all properties for an history track
    /// </summary>
    public class CHistoryTrack : CTrack
    {
        /// <summary>
        /// Gets or sets a information when the track was played
        /// </summary>
        public DateTime PlayedAt
        {
            get;
            set;
        }
    }
}
