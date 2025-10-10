using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.RemovableDrives
{
    /// <summary>
    /// Represents the method that will handle <see cref="DriveSelectedEvent"/> events of a form, control, or other component.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="DriveChangeEventArgs"/> that contains the event data.</param>
    public delegate void DriveChangeEventHandler(object sender, DriveChangeEventArgs e);
}
