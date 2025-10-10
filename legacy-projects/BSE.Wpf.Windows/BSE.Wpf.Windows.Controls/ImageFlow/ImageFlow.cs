using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.Windows.Controls.ImageFlow
{
    /// <summary>
    /// Represents the method that will handle <see cref="ImageFlowPanel"/> events of a form, control, or other component.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="ImageFlowItemEventArgs"/> that contains the event data.</param>
    public delegate void ImageFlowItemEventHandler(object sender, ImageFlowItemEventArgs e);
    /// <summary>
    /// Represents the method that will handle mouse button related routed events on <see cref="IImageFlowItem"/> objects.
    /// </summary>
    /// <param name="sender">The object where the event handler is attached.</param>
    /// <param name="e">The event data.</param>
    public delegate void ImageFlowItemMouseEventHandler(object sender, ImageFlowItemMouseEventArgs e);
}
