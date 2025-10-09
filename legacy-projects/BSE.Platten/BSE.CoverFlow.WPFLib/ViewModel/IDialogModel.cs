using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BSE.CoverFlow.WPFLib.ViewModel
{
    public interface IDialogModel
    {
        ICommand DialogOkCommand { get; }
        ICommand DialogCancelCommand { get; }
        bool IsOpen { get; set; }
        bool? DialogResult { get; set; }
        bool SaveData();
    }
}
