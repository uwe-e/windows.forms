using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BSE.Wpf.Windows.Controls.DragDrop
{
    public class SharedEvents
    {
        /// <summary>
        /// Identifies the <see cref="ItemDrop"/> routed event.
        /// </summary>
        public static readonly RoutedEvent ItemDropEvent = EventManager.RegisterRoutedEvent(
                    "ItemDrop", RoutingStrategy.Bubble,
                    typeof(ItemDropEventHandler), typeof(SharedEvents));
    }
}
