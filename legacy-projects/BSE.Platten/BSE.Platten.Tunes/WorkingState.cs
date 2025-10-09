using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Platten.Tunes
{
    /// <summary>
    /// The state in which the working progress decides.
    /// </summary>
    public enum WorkingState
    {
        /// <summary>
        /// The WorkingState is in an undefined state.
        /// </summary>
        None = 0,
        /// <summary>
        /// The WorkingState is in the working state.
        /// </summary>
        Working = 1
    }
}
