using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Provide Metro theme colors
    /// </summary>
    public class ColorTableMetroLight : BSE.Windows.Forms.BseColorTable
    {
        #region FieldsPrivate
        private PanelColors m_panelColorTable;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the associated ColorTable for the XPanderControls
        /// </summary>
        public override PanelColors PanelColorTable
        {
            get
            {
                if (this.m_panelColorTable == null)
                {
                    this.m_panelColorTable = new PanelColorsMetroLight();
                }
                return this.m_panelColorTable;
            }
        }
        #endregion
        
        #region MethodsProtected
        /// <summary>
        /// Initializes a color dictionary with defined colors
        /// </summary>
        /// <param name="rgbTable">Dictionary with defined colors</param>
        protected override void InitColors(Dictionary<ProfessionalColorTable.KnownColors, Color> rgbTable)
        {
            base.InitColors(rgbTable);
            //rgbTable[KnownColors.ButtonPressedBorder] = Color.FromArgb(0, 122, 204);
            //rgbTable[KnownColors.ButtonPressedGradientBegin] = Color.FromArgb(0, 122, 204);
            //rgbTable[KnownColors.ButtonPressedGradientEnd] = Color.FromArgb(0, 122, 204);
            //rgbTable[KnownColors.ButtonPressedGradientMiddle] = Color.FromArgb(0, 122, 204);
            rgbTable[KnownColors.ButtonPressedHighlightBorder] = Color.FromArgb(0, 122, 204);
            //rgbTable[KnownColors.ButtonPressedText] = Color.FromArgb(254, 254, 254);


            //rgbTable[KnownColors.ButtonSelectedBorder] = Color.FromArgb(231, 232, 236);
            rgbTable[KnownColors.ButtonSelectedGradientBegin] = Color.FromArgb(254, 254, 254);
            rgbTable[KnownColors.ButtonSelectedGradientEnd] = Color.FromArgb(254, 254, 254);

            rgbTable[KnownColors.ButtonSelectedHighlightBorder] = Color.FromArgb(254, 254, 254);

            //rgbTable[KnownColors.GripDark] = Color.FromArgb(102, 102, 102);
            //rgbTable[KnownColors.GripLight] = Color.FromArgb(182, 182, 182);
            //rgbTable[KnownColors.ImageMarginGradientBegin] = Color.FromArgb(239, 239, 239);
            //rgbTable[KnownColors.MenuBorder] = Color.FromArgb(0, 0, 0);

            rgbTable[KnownColors.CheckBackground] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.CheckPressedBackground] = Color.FromArgb(254, 254, 254);
            rgbTable[KnownColors.CheckSelectedBackground] = Color.FromArgb(254, 254, 254);

            rgbTable[KnownColors.ImageMarginGradientBegin] = Color.FromArgb(231, 232, 236);

            rgbTable[KnownColors.MenuBorder] = Color.FromArgb(204, 206, 219);
            rgbTable[KnownColors.MenuItemBorder] = Color.FromArgb(254, 254, 254);

            rgbTable[KnownColors.MenuItemPressedGradientBegin] = Color.FromArgb(0, 122, 204);
            rgbTable[KnownColors.MenuItemPressedGradientEnd] = Color.FromArgb(0, 122, 204);

            rgbTable[KnownColors.MenuItemSelected] = Color.FromArgb(254, 254, 254);

            //rgbTable[KnownColors.MenuItemSelectedGradientBegin] = Color.FromArgb(231, 239, 243);
            //rgbTable[KnownColors.MenuItemSelectedGradientEnd] = Color.FromArgb(218, 235, 243);
            //rgbTable[KnownColors.MenuItemSelectedGradientBegin] = Color.FromArgb(254, 254, 254);
            //rgbTable[KnownColors.MenuItemSelectedGradientEnd] = Color.FromArgb(254, 254, 254);

            rgbTable[KnownColors.MenuItemText] = Color.FromArgb(0, 0, 0);
            rgbTable[KnownColors.MenuItemTopLevelSelectedBorder] = Color.FromArgb(254, 254, 254);
            rgbTable[KnownColors.MenuItemTopLevelSelectedGradientBegin] = Color.FromArgb(254, 254, 254);
            rgbTable[KnownColors.MenuItemTopLevelSelectedGradientEnd] = Color.FromArgb(254, 254, 254);

            rgbTable[KnownColors.MenuItemTopLevelPressedGradientBegin] = Color.FromArgb(231, 232, 236);
            rgbTable[KnownColors.MenuItemTopLevelPressedGradientEnd] = Color.FromArgb(231, 232, 236);


            rgbTable[KnownColors.MenuItemTopLevelPressedBorder] = Color.FromArgb(231, 232, 236);
            rgbTable[KnownColors.MenuStripGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.MenuStripGradientEnd] = Color.FromArgb(239, 239, 242);

            //rgbTable[KnownColors.OverflowButtonGradientBegin] = Color.FromArgb(136, 144, 254);
            //rgbTable[KnownColors.OverflowButtonGradientEnd] = Color.FromArgb(111, 145, 255);
            //rgbTable[KnownColors.OverflowButtonGradientMiddle] = Color.FromArgb(42, 52, 254);
            //rgbTable[KnownColors.RaftingContainerGradientBegin] = Color.FromArgb(83, 83, 83);
            //rgbTable[KnownColors.RaftingContainerGradientEnd] = Color.FromArgb(83, 83, 83);
            //rgbTable[KnownColors.SeparatorDark] = Color.FromArgb(102, 102, 102);
            //rgbTable[KnownColors.SeparatorLight] = Color.FromArgb(182, 182, 182);
            //rgbTable[KnownColors.StatusStripGradientBegin] = Color.FromArgb(100, 100, 100);
            rgbTable[KnownColors.StatusStripGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.StatusStripGradientEnd] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.StatusStripText] = Color.FromArgb(0,0,0);
            //rgbTable[KnownColors.ToolStripBorder] = Color.FromArgb(102, 102, 102);
            
            //rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = Color.FromArgb(42, 42, 42);
            //rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = Color.FromArgb(10, 10, 10);
            rgbTable[KnownColors.ToolStripContentPanelGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.ToolStripContentPanelGradientEnd] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.ToolStripDropDownBackground] = Color.FromArgb(231, 232, 236);
            //rgbTable[KnownColors.ToolStripGradientBegin] = Color.FromArgb(102, 102, 102);
            //rgbTable[KnownColors.ToolStripGradientEnd] = Color.FromArgb(0, 0, 0);
            //rgbTable[KnownColors.ToolStripGradientMiddle] = Color.FromArgb(52, 52, 52);
            rgbTable[KnownColors.ToolStripGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.ToolStripGradientEnd] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.ToolStripGradientMiddle] = Color.FromArgb(239, 239, 242);

            //rgbTable[KnownColors.ToolStripPanelGradientBegin] = Color.FromArgb(12, 12, 12);
            //rgbTable[KnownColors.ToolStripPanelGradientEnd] = Color.FromArgb(2, 2, 2);
            rgbTable[KnownColors.ToolStripPanelGradientBegin] = Color.FromArgb(239, 239, 242);
            rgbTable[KnownColors.ToolStripPanelGradientEnd] = Color.FromArgb(239, 239, 242);

            rgbTable[KnownColors.ToolStripText] = Color.FromArgb(0, 0, 0);
        }

        #endregion
    }
}
