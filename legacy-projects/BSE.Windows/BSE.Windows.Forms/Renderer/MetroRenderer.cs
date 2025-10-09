using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
    public class MetroRenderer : BseRenderer
    {
        #region MethodsPublic
        static MetroRenderer()
        {
        }
        /// <summary>
        /// Initialize a new instance of the BseRenderer class.
        /// </summary>
        public MetroRenderer()
            : base(new BSE.Windows.Forms.ColorTableMetroLight())
        {
        }
        /// <summary>
        /// Initializes a new instance of the BseRenderer class.
        /// </summary>
        /// <param name="professionalColorTable">A <see cref="BSE.Windows.Forms.ProfessionalColorTable"/> to be used for painting.</param>
        public MetroRenderer(ProfessionalColorTable professionalColorTable)
            : base(professionalColorTable)
        {
        }
        #endregion
    }
}
