using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BSE.Windows.Forms.Form
{
    internal class NativeMethods
    {
        public const int WM_NCMOUSEMOVE = 0x0200;
        /// <summary>
        /// Posted to a window when the cursor leaves the nonclient area of the window
        /// </summary>
        public const int WM_NCMOUSELEAVE = 0x02A2;
        /// <summary>
        /// Sent when the size and position of a window's client area must be calculated. By processing this message, an application can control the content
        /// of the window's client area when the size or position of the window changes.
        /// </summary>
        public const int WM_NCCALCSIZE = 0x0083;
        /// <summary>
        /// Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate. This can happen, for example, when
        /// the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as WindowFromPoint. If the mouse
        /// is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
        /// </summary>
        public const int WM_NCHITTEST = 0x0084;
        /// <summary>
        /// Used by the TrackMouseEvent function to track when the mouse pointer leaves a window or hovers over a window for a specified amount of time.
        /// </summary>
        public const int WM_ACTIVATE = 0x0006;
        /// <summary>
        /// Sent when an application requests that a window be created by calling the CreateWindowEx
        /// or CreateWindow function. (The message is sent before the function returns.) The window
        /// procedure of the new window receives this message after the window is created, but before 
        /// the window becomes visible.
        /// </summary>
        public const int WM_CREATE = 0x0001;
        /// <summary>
        /// The WM_SIZE message is sent to a window after its size has changed.
        /// </summary>
        public const int WM_SIZE = 0x05;
        /// <summary>
        /// A window receives this message when the user chooses a command from the Window menu
        /// (formerly known as the system or control menu) or when the user chooses the maximize button,
        /// minimize button, restore button, or close button.
        /// /// </summary>
        public const int WM_SYSCOMMAND = 0x0112;
        /// <summary>
        /// Restores the window to its normal position and size. It's a part of <see cref="WM_SYSCOMMAND"/>
        /// </summary>
        public const int SC_RESTORE = 0xF120;
        /// <summary>
        /// The NCCALCSIZE_PARAMS structure contains information that an application can use while processing the WM_NCCALCSIZE message to calculate the size,
        /// position, and valid contents of the client area of a window. 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            public RECT rect0;
            public RECT rect1;
            public RECT rect2;
            public IntPtr lppos;
        }
        /// <summary>
        /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a
        /// rectangle.
        /// /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        /// <summary>
        /// Returned by the GetThemeMargins function to define the margins of windows that have visual styles applied.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }
        [Flags]
        public enum SetWindowPosFlags : uint
        {
            // ReSharper disable InconsistentNaming
            /// <summary>
            ///     If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,
            /// <summary>
            ///     Prevents generation of the WM_SYNCPAINT message.
            /// </summary>
            SWP_DEFERERASE = 0x2000,
            /// <summary>
            ///     Draws a frame (defined in the window's class description) around the window.
            /// </summary>
            SWP_DRAWFRAME = 0x0020,
            /// <summary>
            ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,
            /// <summary>
            ///     Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,
            /// <summary>
            ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOACTIVATE = 0x0010,
            /// <summary>
            ///     Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,
            /// <summary>
            ///     Retains the current position (ignores X and Y parameters).
            /// </summary>
            SWP_NOMOVE = 0x0002,
            /// <summary>
            ///     Does not change the owner window's position in the Z order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,
            /// <summary>
            ///     Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
            /// </summary>
            SWP_NOREDRAW = 0x0008,
            /// <summary>
            ///     Same as the SWP_NOOWNERZORDER flag.
            /// </summary>
            SWP_NOREPOSITION = 0x0200,
            /// <summary>
            ///     Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,
            /// <summary>
            ///     Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            SWP_NOSIZE = 0x0001,
            /// <summary>
            ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOZORDER = 0x0004,
            /// <summary>
            ///     Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,
            // ReSharper restore InconsistentNaming
        }
        /// <summary>
        /// Extends the window frame into the client area.
        /// </summary>
        /// <param name="hdc">The handle to the window in which the frame will be extended into the client area.</param>
        /// <param name="marInset">A pointer to a <see cref="MARGINS"/> structure that describes the margins to use when extending the frame into the client area.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);
        /// <summary>
        /// Default window procedure for Desktop Window Manager (DWM) hit testing within the non-client area.
        /// </summary>
        /// <param name="hwnd">A handle to the window procedure that received the message.</param>
        /// <param name="msg">The message.</param>
        /// <param name="wParam">Specifies additional message information. The content of this parameter depends on the value of the msg parameter.</param>
        /// <param name="lParam">Specifies additional message information. The content of this parameter depends on the value of the msg parameter.</param>
        /// <param name="result">A pointer to an LRESULT value that, when this method returns successfully,receives the result of the hit test.</param>
        /// <returns>TRUE if DwmDefWindowProc handled the message; otherwise, FALSE.</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref IntPtr result);
        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window
        /// procedure for the specified window and does not return until the window procedure has processed
        /// the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message.
        /// If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows
        /// in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up
        /// windows; but the message is not sent to child windows.</param>
        /// <param name="Msg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on 
        /// the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        /// <summary>
        /// Releases the mouse capture from a window in the current thread and restores normal mouse input
        /// processing. A window that has captured the mouse receives all mouse input, regardless of the
        /// position of the cursor, except when a mouse button is clicked while the cursor hot spot is
        /// in the window of another thread. 
        /// </summary>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are
        /// given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hWnd">A handle to the window. </param>
        /// <param name="lpRect">A pointer to a RECT structure that receives the screen coordinates of the
        /// upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32")]
        public static extern bool GetWindowRect([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, [System.Runtime.InteropServices.OutAttribute()] out RECT lpRect);
        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows
        /// are ordered according to their appearance on the screen. The topmost window receives the highest
        /// rank and is the first window in the Z order.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
    }
}
