using System;
using System.Drawing;

namespace BSE.Platten.Common
{
	/// <summary>
	/// Zusammenfassung für CColors.
	/// </summary>
	public static class BSEColors
    {
        #region Constants
        
        private static Color m_alternatingBackColor = SystemColors.Control;
        private static Color m_gridBackgroundColor = SystemColors.Window;
        
        #endregion

        #region FieldsPublic
        //public static readonly Color FormBorderColor = Color.FromArgb(184, 182, 183);
        public static readonly Color FormBorderColor = Color.FromArgb(1, 122, 204);
        //public static readonly Color FormBackroundColor = Color.FromArgb(17,9,15);
        public static readonly Color FormBackroundColor = Color.FromArgb(239, 239, 242);
        public static Color AlternatingBackColor
        {
            get { return m_alternatingBackColor; }
        }
        public static Color GridBackgroundColor
        {
            get { return m_gridBackgroundColor; }
        }
		
		#endregion
	}
}
