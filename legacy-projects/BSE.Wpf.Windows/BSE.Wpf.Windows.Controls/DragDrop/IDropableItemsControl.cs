using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.Windows.Controls.DragDrop
{
    public interface IDropableItemsControl
    {
        event ItemDropEventHandler ItemDrop;
    }
}
