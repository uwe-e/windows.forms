using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BSE.Platten.Admin
{
    interface IIsInAdminForm
    {
        bool ShowInTreeView { get;set;}
        bool ShowInToolsNode { get;set;}
        bool ShowInStatisticNode { get;set;}
        Image TreeNodeImage { get;set;}
    }
}
