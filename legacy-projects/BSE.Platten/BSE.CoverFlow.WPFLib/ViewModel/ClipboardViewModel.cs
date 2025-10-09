using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GongSolutions.Wpf.DragDrop;
using BSE.Platten.BO;
using System.Windows;
using System.Collections.ObjectModel;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public class ClipboardViewModel : ListViewModelBase
    {
        #region MethodsPublic
        public ClipboardViewModel(BSE.Platten.BO.Environment environment)
            : base(environment)
        {
        }
        #endregion
    }
}
