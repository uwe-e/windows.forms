using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BSE.Wpf.Windows.Controls
{
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public static Int32 GWL_EXSTYLE = -20;
        public static Int32 WS_EX_LAYERED = 0x00080000;
        public static Int32 WS_EX_TRANSPARENT = 0x00000020;

        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <param name="pt">A pointer to a <see cref="POINT"/> structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);
        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the 32-bit (<b>DWORD</b>) value
        /// at the specified offset into the extra window memory. 
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">The zero-based offset to the value to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is the requested value.
        /// If the function fails, the return value is zero. </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 nIndex);
        /// <summary>
        /// Changes an attribute of the specified window. The function also sets the 32-bit (long) value
        /// at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">The zero-based offset to the value to be set.</param>
        /// <param name="newVal">The replacement value.</param>
        /// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer.
        /// If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 newVal);

    }
}
