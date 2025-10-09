using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Specifies whether the size of the image on a <see cref="Panel"/> or <see cref="XPanderPanel"/> is
    /// automatically adjusted to fit in the captionbar while retaining the original image proportions.
    /// </summary>
    public enum ImageScaling
    {
        /// <summary>
        /// Specifies that the size of the image on a <see cref="Panel"/> or <see cref="XPanderPanel"/> is
        /// not automatically adjusted to fit in the captionbar.
        /// </summary>
        None,
        /// <summary>
        /// Specifies that the size of the image on a <see cref="Panel"/> or <see cref="XPanderPanel"/> is
        /// automatically adjusted to fit in the captionbar.
        /// </summary>
        SizeToFit
    }
}
