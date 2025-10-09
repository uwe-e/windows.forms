using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.CoverFlow.WPFLib
{
    /// <summary>
    /// The Mode in which the StartButton runs.
    /// </summary>
    public enum DisplayState
    {
        /// <summary>
        /// The DisplayState is in an undefined state.
        /// </summary>
        None = 0,
        /// <summary>
        /// A Stream is playing.
        /// </summary>
        Playing = 1,
        /// <summary>
        /// Playback is paused.
        /// </summary>
        Paused = 2
    }
}
