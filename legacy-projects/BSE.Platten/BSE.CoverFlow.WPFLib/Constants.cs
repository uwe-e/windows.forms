using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.CoverFlow.WPFLib
{
    public static class Constants
    {
        #region FieldsPublic
        /// <summary>
        /// The height or width dimension on an image.
        /// </summary>
        public static readonly int ImageStretchExtension = 200;
        #endregion
        
        #region Constants
        /// <summary>
        /// The name of the default directory that contains the application data.
        /// </summary>
        public const string ApplicationBaseDataDirectoryName = "BSE";

        /// <summary>
        /// The fileformat sufix for an png cache image.
        /// </summary>
        public const string PngFileFormatSuffix = ".png";
        /// <summary>
        /// The a abbreviation value when the coverflowitem is moved a large distance.
        /// </summary>
        public const int MaxScrollStep = 20;
        /// <summary>
        /// The resource path for the button BtnNextEnabled image.
        /// </summary>
        public const string ImageSourceBtnNextEnabled = ";component/Images/next.png";
        /// <summary>
        /// The resource path for the button BtnNextDisabled image.
        /// </summary>
        public const string ImageSourceBtnNextDisabled = ";component/Images/next_disabled.png";
        /// <summary>
        /// The resource path for the button BtnPreviousEnabled image.
        /// </summary>
        public const string ImageSourceBtnPreviousEnabled = ";component/Images/previous.png";
        /// <summary>
        /// The resource path for the button BtnPreviousDisabled image.
        /// </summary>
        public const string ImageSourceBtnPreviousDisabled = ";component/Images/previous_disabled.png";
        /// <summary>
        /// The resource path for the button play image.
        /// </summary>
        public const string ImageSourceBtnPlay = ";component/Images/PlayButton.png";
        /// <summary>
        /// The resource path for the button pause image.
        /// </summary>
        public const string ImageSourceBtnPause = ";component/Images/pause.png";
        #endregion
    }
}
