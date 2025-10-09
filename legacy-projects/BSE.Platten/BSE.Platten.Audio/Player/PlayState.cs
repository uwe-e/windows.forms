using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Audio
{
    /// <summary>
    /// The PlayState enumeration type defines the possible operational states of an Audio Player
    /// as it plays a digital media file.
    /// </summary>
    public enum PlayState
    {
        /// <summary>
        /// The Audio Player is in an undefined state.
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Playback is stopped.
        /// </summary>
        Stopped = 1,
        /// <summary>
        /// Playback is paused.
        /// </summary>
        Paused = 2,
        /// <summary>
        /// Stream is playing.
        /// </summary>
        Playing = 3,
        /// <summary>
        /// The end of the media item has been reached.
        /// </summary>
        Ended = 8,
        /// <summary>
        /// The Audio Player has been closed.
        /// </summary>
        Closed = 5,
    }
}
