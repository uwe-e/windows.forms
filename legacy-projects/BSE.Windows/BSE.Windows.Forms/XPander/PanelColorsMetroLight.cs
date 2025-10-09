using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Provide black theme colors for a Panel or XPanderPanel display element.
    /// </summary>
    /// <copyright>Copyright © 2006-2008 Uwe Eichkorn
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
    /// REMAINS UNCHANGED.
    /// </copyright>
    public class PanelColorsMetroLight : PanelColorsBse
    {
        #region MethodsPublic
        /// <summary>
        /// Initialize a new instance of the PanelColorsBlack class.
        /// </summary>
        public PanelColorsMetroLight()
			: base()
		{
		}
        /// <summary>
        /// Initialize a new instance of the PanelColorsBlack class.
        /// </summary>
        /// <param name="basePanel">Base class for the panel or xpanderpanel control.</param>
        public PanelColorsMetroLight(BasePanel basePanel)
            : base(basePanel)
        {
        }

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Initialize a color Dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<PanelColors.KnownColors, Color> rgbTable)
        {
            base.InitColors(rgbTable);
            rgbTable[KnownColors.BorderColor] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.PanelCaptionCloseIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCaptionExpandIcon] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCaptionGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.PanelCaptionGradientEnd] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.PanelCaptionGradientMiddle] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.PanelActiveCaptionGradientBegin] = Color.FromArgb(0, 122, 204);
            rgbTable[KnownColors.PanelActiveCaptionGradientEnd] = Color.FromArgb(0, 122, 204);
            rgbTable[KnownColors.PanelActiveCaptionGradientMiddle] = Color.FromArgb(0, 122, 204);
            rgbTable[KnownColors.PanelContentGradientBegin] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelContentGradientEnd] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.PanelCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelActiveCaptionText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.PanelCollapsedCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.PanelCaptionSelectedGradientBegin] = Color.FromArgb(205, 230, 247);
            rgbTable[KnownColors.PanelCaptionSelectedGradientEnd] = Color.FromArgb(205, 230, 247);
            rgbTable[KnownColors.InnerBorderColor] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.XPanderPanelBackColor] = Color.FromArgb(240, 241, 242);
            rgbTable[KnownColors.XPanderPanelCaptionCloseIcon] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.XPanderPanelCaptionExpandIcon] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.XPanderPanelCaptionText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionText] = Color.FromArgb(0, 0, 0);

            rgbTable[KnownColors.XPanderPanelSelectedCaptionBegin] = Color.FromArgb(205, 230, 247);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionEnd] = Color.FromArgb(205, 230, 247);
            rgbTable[KnownColors.XPanderPanelSelectedCaptionMiddle] = Color.FromArgb(205, 230, 247);

            rgbTable[KnownColors.XPanderPanelActiveCaptionText] = Color.FromArgb(255, 255, 255);
            rgbTable[KnownColors.XPanderPanelCaptionGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.XPanderPanelCaptionGradientEnd] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.XPanderPanelCaptionGradientMiddle] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.XPanderPanelActiveCheckedCaptionBegin] = Color.FromArgb(51, 153, 255);
            rgbTable[KnownColors.XPanderPanelActiveCheckedCaptionEnd] = Color.FromArgb(51, 153, 255);
            rgbTable[KnownColors.XPanderPanelActiveCheckedCaptionMiddle] = Color.FromArgb(51, 153, 255);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionBegin] = Color.FromArgb(204, 206, 219);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionEnd] = Color.FromArgb(204, 206, 219);
            rgbTable[KnownColors.XPanderPanelCheckedCaptionMiddle] = Color.FromArgb(204, 206, 219);
            rgbTable[KnownColors.XPanderPanelFlatCaptionGradientBegin] = Color.FromArgb(90, 90, 90);
            rgbTable[KnownColors.XPanderPanelFlatCaptionGradientEnd] = Color.FromArgb(155, 155, 155);
        }

        #endregion
    }
}
