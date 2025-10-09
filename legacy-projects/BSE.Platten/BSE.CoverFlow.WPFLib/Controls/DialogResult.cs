using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.CoverFlow.WPFLib.Controls
{
    /// <summary>
    /// Specifies identifiers to indicate the return value of a dialog box.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// <b>Nothing</b> is returned from the dialog box. This means that the modal dialog continues running.
        /// </summary>
        None = 0,
        /// <summary>
        /// The dialog box return value is <b>OK</b> (usually sent from a button labeled OK).
        /// </summary>
        Ok = 1,
        /// <summary>
        /// The dialog box return value is <b>Cancel</b> (usually sent from a button labeled Cancel).
        /// </summary>
        Cancel = 2,
        /// <summary>
        /// The dialog box return value is <b>Yes</b> (usually sent from a button labeled Yes).
        /// </summary>
        Yes = 6,
        /// <summary>
        /// The dialog box return value is <b>No</b> (usually sent from a button labeled No).
        /// </summary>
        No = 7
    }
}
