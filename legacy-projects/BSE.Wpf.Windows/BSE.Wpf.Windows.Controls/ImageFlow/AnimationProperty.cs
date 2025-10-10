using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// The dependency properties for the animation.
    /// </summary>
    public enum AnimationProperty
    {
        /// <summary>
        /// The AnimationProperty is in an undefined state.
        /// </summary>
        None = 0,
        /// <summary>
        /// OffsetX dependency property
        /// </summary>
        AxisAngleRotation3D = 1,
        /// <summary>
        /// Angle dependency property for the storyboard.
        /// </summary>
        OffsetX = 2,
        /// <summary>
        /// OffsetY dependency property for the storyboard.
        /// </summary>
        OffsetY = 3,
        /// <summary>
        /// Offsetz dependency property for the storyboard.
        /// </summary>
        OffsetZ = 4
    }
}
