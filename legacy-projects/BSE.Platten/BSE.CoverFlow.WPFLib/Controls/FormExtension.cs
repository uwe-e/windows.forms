using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Forms.Integration;

namespace BSE.CoverFlow.WPFLib.Controls
{
    public static class FormExtension
    {
        public static Form FindForm(this Visual element)
        {
            HwndSource wpfHandle = PresentationSource.FromVisual(element) as HwndSource;

            if (wpfHandle == null)
            {
                return null;
            }

            ElementHost elementHost = System.Windows.Forms.Control.FromChildHandle(wpfHandle.Handle) as ElementHost;
            return elementHost.FindForm();
        }
    }
}
