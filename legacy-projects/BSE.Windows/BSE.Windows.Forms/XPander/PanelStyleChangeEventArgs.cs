using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Provides data for the PanelStyleChange event.
    /// </summary>
    /// <copyright>Copyright © 2006-2008 Uwe Eichkorn
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
    /// REMAINS UNCHANGED. 
    /// </copyright>
    public class PanelStyleChangeEventArgs : EventArgs
    {
        #region FieldsPrivate

        private PanelStyle m_panelStyle;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the style of the panel.
        /// </summary>
        public PanelStyle PanelStyle
        {
            get { return this.m_panelStyle; }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Arguments used when a PanelStyleChange event occurs.
        /// </summary>
        /// <param name="panelStyle">the style of the panel.</param>
        public PanelStyleChangeEventArgs(PanelStyle panelStyle)
        {
            this.m_panelStyle = panelStyle;
        }

        #endregion
    }
}
