using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Specifies the buttons that are displayed on a message window. 
    /// </summary>
    public enum DialogButton
    {
        /// <summary>
        /// The message box displays an OK button.
        /// </summary>
        Ok = 0,
        /// <summary>
        /// The message box displays OK and Cancel buttons.
        /// </summary>
        OkCancel = 1,
        /// <summary>
        /// The message box displays Yes and No buttons.
        /// </summary>
        YesNo = 4,
    }
}
