using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows;

namespace BSE.Wpf.RemovableDrives
{
    public static class WindowsFormsHelper
    {
        public static System.Windows.Forms.Form FindForm(this Visual element)
        {
            if (element == null)
            {
                return null;
            }
            HwndSource wpfHandle = PresentationSource.FromVisual(element) as HwndSource;
            if(wpfHandle == null)
            {
                return null;
            }
            
            System.Windows.Forms.Integration.ElementHost elementHost = System.Windows.Forms.Control.FromChildHandle(wpfHandle.Handle) as System.Windows.Forms.Integration.ElementHost;
            return elementHost.FindForm();
        }
    
    }
}
