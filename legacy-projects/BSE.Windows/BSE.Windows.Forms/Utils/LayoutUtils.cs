using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BSE.Windows.Forms
{
    public class LayoutUtils
    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        #endregion

        #region Properties
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Checks if the rectangle width or height is equal to 0.
        /// </summary>
        /// <param name="rectangle">the rectangle to check</param>
        /// <returns>true if the with or height of the rectangle is 0 else false</returns>
        public static bool IsZeroWidthOrHeight(Rectangle rectangle)
        {
            if (rectangle.Width != 0)
            {
                return (rectangle.Height == 0);
            }
            return true;
        }
        /// <summary>
        /// Gets a GraphicsPath with round corners.
        /// </summary>
        /// <param name="bounds">Rectangle structure that specifies the backgrounds location.</param>
        /// <param name="radius">The radius in the graphics path</param>
        /// <returns>The specified graphics path</returns>
        public static GraphicsPath GetBackgroundPath(Rectangle bounds, int radius)
        {
            int x = bounds.X;
            int y = bounds.Y;
            int width = bounds.Width;
            int height = bounds.Height;
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(x, y, radius, radius, 180, 90);				                    //Upper left corner
            graphicsPath.AddArc(x + width - radius, y, radius, radius, 270, 90);			    //Upper right corner
            graphicsPath.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);//Lower right corner
            graphicsPath.AddArc(x, y + height - radius, radius, radius, 90, 90);			    //Lower left corner
            graphicsPath.CloseFigure();
            return graphicsPath;
        }
        #endregion

        #region MethodsProtected
        #endregion

        #region MethodsPrivate
        #endregion

    }
}
