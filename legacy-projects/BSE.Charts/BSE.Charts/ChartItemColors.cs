using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BSE.Charts
{
    internal class ChartItemColors
    {
        #region FieldsPrivate

        private Color[] m_colors = {Color.Tomato,
            Color.LimeGreen,
            Color.Orange,
			Color.DarkSeaGreen,
			Color.SteelBlue,
			Color.MediumOrchid,
			Color.Goldenrod,
			Color.LightBlue,
			Color.LightGreen,
			Color.Coral,
			Color.Aquamarine, 
			Color.DeepSkyBlue,
			Color.LightSalmon, 
			Color.SkyBlue};

        #endregion

        #region MethodsPublic

        public void SetColor(int iIndex, Color color)
        {
            //Return right away if passed in an invalid index.
            if ((iIndex < 0) || (iIndex >= m_colors.Length))
            {
                return;
            }
            m_colors[iIndex] = color;
        }

        public Color GetColor(int iIndex)
        {
            Color color = m_colors[(iIndex % m_colors.Length)];
            int x = iIndex / m_colors.Length;
            if (x > 0)
            {
                //Asked for a color larger than our internal table.
                color = Color.FromArgb(Math.Min(color.R + x, 255),
                    Math.Min(color.G + x, 255),
                    Math.Min(color.B + x, 255));
            }
            return color;
        }

        #endregion
    }
}
