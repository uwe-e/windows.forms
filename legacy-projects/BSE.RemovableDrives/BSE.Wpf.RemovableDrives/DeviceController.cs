using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSE.Wpf.RemovableDrives
{
    internal class DeviceController : System.Windows.Forms.NativeWindow
    {
        public event EventHandler<EventArgs> DeviceChanged;

        public DeviceController(IntPtr handle)
        {
            this.AssignHandle(handle);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == NativeMethods.WM_DEVICECHANGE)
            {
                if (this.DeviceChanged != null)
                {
                    this.DeviceChanged(this, EventArgs.Empty);
                }
            }
            base.WndProc(ref m);
        }
    }
}
