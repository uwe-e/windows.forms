using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.FreeDb
{
    public enum MatchCode
    {
        /// <summary>
        /// No match found
        /// </summary>
        NoMatch = 0,
        /// <summary>
        /// Found multiple matches
        /// </summary>
        MultipleMatches = 1,
        /// <summary>
        /// Found exact match
        /// </summary>
        ExactMatch = 2
    }
}
