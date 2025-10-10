using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// The State in which the coverflow selection decides.
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
