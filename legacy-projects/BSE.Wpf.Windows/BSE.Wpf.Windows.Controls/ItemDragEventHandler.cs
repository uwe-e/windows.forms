using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.Windows.Controls
{
    /// <summary>
    /// Represents the method that will handle <see cref="ItemDragEvent"/> events of a form, control, or other component.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="ItemDragEventArgs"/> that contains the event data.</param>
    public delegate void ItemDragEventHandler(object sender, ItemDragEventArgs e);
}
