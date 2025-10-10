using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Contains the constants for the <see cref="BSE.Wpf.Windows.Controls.ImageFlow"/> controls.
    /// </summary>
    public static class Constants
    {
        #region FieldsPublic
        /// <summary>
        /// The height or width dimension on an image.
        /// </summary>
        public static readonly int ImageStretchExtension = 300;
        /// <summary>
        /// The fileformat sufix for an png cache image.
        /// </summary>
        public static readonly string PngFileFormatSuffix = ".png";
        /// <summary>
        /// The name of the default directory that contains the application data.
        /// </summary>
        public static readonly string ApplicationBaseDataDirectoryName = "BSE";
        /// <summary>
        /// The a abbreviation value when the coverflowitem is moved a large distance.
        /// </summary>
        public static readonly int MaxScrollStep = 20;
        #endregion
    }
}
