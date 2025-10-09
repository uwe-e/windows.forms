using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace BSE.Windows.Forms.Form
{
    public class MetroForm : System.Windows.Forms.Form
    {
        #region Enums
        //private enum ResizeDirectionMode
        //{
        //    Bottom = 0x40,
        //    BottomLeft = 0x80,
        //    BottomRight = 0x20,
        //    Left = 1,
        //    None = 0,
        //    Right = 0x10,
        //    Top = 4,
        //    TopLeft = 2,
        //    TopRight = 8
        //}

        ///// <summary>
        ///// Possible results of a hit test on the non client area of a form
        ///// </summary>
        //public enum NonClientHitTestResult
        //{
        //    Nowhere = 0,
        //    Client = 1,
        //    Caption = 2,
        //    GrowBox = 4,
        //    MinimizeButton = 8,
        //    MaximizeButton = 9,
        //    Left = 10,
        //    Right = 11,
        //    Top = 12,
        //    TopLeft = 13,
        //    TopRight = 14,
        //    Bottom = 15,
        //    BottomLeft = 16,
        //    BottomRight = 17
        //}
        #endregion

        #region Constants
        private const int m_formResizeMargin = 1;
        private const int InnerControlMargin = 1;
        #endregion

        #region FieldsPrivate
        private Padding m_formThickness;
        private bool m_hasMarginsChecked;
        private NativeMethods.MARGINS m_marginInset;
        //private ResizeDirectionMode m_resizeDirectionMode;
        //private Rectangle m_topResizeRectangle = Rectangle.Empty;
        //private Rectangle m_topLeftResizeRectangle = Rectangle.Empty;
        //private Rectangle m_leftResizeRectangle = Rectangle.Empty;
        //private Rectangle m_topRightResizeRectangle = Rectangle.Empty;
        //private Rectangle m_rightResizeRectangle = Rectangle.Empty;
        //private Rectangle m_bottomLeftResizeRectangle = Rectangle.Empty;
        //private Rectangle m_bottomResizeRectangle = Rectangle.Empty;
        //private Rectangle m_bottomRightResizeRectangle = Rectangle.Empty;
        private bool m_bDisableBoundsCore;
        #endregion

        #region Properties

        public int CaptionHeight
        {
            get;
            set;
        }
        public Caption Caption
        {
            get;
            set;
        }
        public Color BorderColor
        {
            get;
            set;
        }
        public Color IconColor
        {
            get;
            set;
        }
        public Color IconColorHover
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the margins of the non-client area
        /// </summary>
        public Padding FormThickness
        {
            get { return this.m_formThickness; }
        }
        //public override Rectangle DisplayRectangle
        //{
        //    get
        //    {
        //        return new Rectangle(
        //            base.DisplayRectangle.Left + m_formResizeMargin + InnerControlMargin,
        //            base.DisplayRectangle.Top + m_formResizeMargin + InnerControlMargin,
        //            base.DisplayRectangle.Width - (2 * (m_formResizeMargin + InnerControlMargin)),
        //            base.DisplayRectangle.Height - (2 * (m_formResizeMargin + InnerControlMargin)));
        //    }
        //}
        //public virtual NonClientHitTestResult NonClientHitTest(Point hitPoint)
        //{

        //    Rectangle topleft = this.RectangleToScreen(new Rectangle(0, 0, FormThickness.Left, FormThickness.Left));

        //    if (topleft.Contains(hitPoint))
        //        return NonClientHitTestResult.TopLeft;

        //    Rectangle topright = this.RectangleToScreen(new Rectangle(this.Width - FormThickness.Right, 0, FormThickness.Right, FormThickness.Right));

        //    if (topright.Contains(hitPoint))
        //        return NonClientHitTestResult.TopRight;

        //    Rectangle botleft = this.RectangleToScreen(new Rectangle(0, this.Height - FormThickness.Bottom, FormThickness.Left, FormThickness.Bottom));

        //    if (botleft.Contains(hitPoint))
        //        return NonClientHitTestResult.BottomLeft;

        //    Rectangle botright = this.RectangleToScreen(new Rectangle(this.Width - FormThickness.Right, this.Height - FormThickness.Bottom, FormThickness.Right, FormThickness.Bottom));

        //    if (botright.Contains(hitPoint))
        //        return NonClientHitTestResult.BottomRight;

        //    Rectangle top = this.RectangleToScreen(new Rectangle(0, 0, this.Width, FormThickness.Left));

        //    if (top.Contains(hitPoint))
        //        return NonClientHitTestResult.Top;

        //    Rectangle cap = this.RectangleToScreen(new Rectangle(0, FormThickness.Left, this.Width, FormThickness.Top - FormThickness.Left));

        //    if (cap.Contains(hitPoint))
        //        return NonClientHitTestResult.Caption;

        //    Rectangle left = this.RectangleToScreen(new Rectangle(0, 0, FormThickness.Left, this.Height));

        //    if (left.Contains(hitPoint))
        //        return NonClientHitTestResult.Left;

        //    Rectangle right = this.RectangleToScreen(new Rectangle(this.Width - FormThickness.Right, 0, FormThickness.Right, this.Height));

        //    if (right.Contains(hitPoint))
        //        return NonClientHitTestResult.Right;

        //    Rectangle bottom = this.RectangleToScreen(new Rectangle(0, this.Height - FormThickness.Bottom, this.Width, FormThickness.Bottom));

        //    if (bottom.Contains(hitPoint))
        //        return NonClientHitTestResult.Bottom;

        //    return NonClientHitTestResult.Client;
        //}
        //private ResizeDirectionMode ResizeDirection
        //{
        //    get
        //    {
        //        return this.m_resizeDirectionMode;
        //    }
        //    set
        //    {
        //        this.m_resizeDirectionMode = value;
        //        ResizeDirectionMode resizeDirection = value;
        //        if (resizeDirection == ResizeDirectionMode.Left)
        //        {
        //            this.Cursor = Cursors.SizeWE;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.Right)
        //        {
        //            this.Cursor = Cursors.SizeWE;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.Top)
        //        {
        //            this.Cursor = Cursors.SizeNS;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.Bottom)
        //        {
        //            this.Cursor = Cursors.SizeNS;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.BottomLeft)
        //        {
        //            this.Cursor = Cursors.SizeNESW;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.TopRight)
        //        {
        //            this.Cursor = Cursors.SizeNESW;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.BottomRight)
        //        {
        //            this.Cursor = Cursors.SizeNWSE;
        //        }
        //        else if (resizeDirection == ResizeDirectionMode.TopLeft)
        //        {
        //            this.Cursor = Cursors.SizeNWSE;
        //        }
        //        else
        //        {
        //            this.Cursor = Cursors.Default;
        //        }
        //    }
        //}
        #endregion

        #region MethodsPublic
        public MetroForm()
        {
			SetStyle(ControlStyles.AllPaintingInWmPaint |
					 ControlStyles.OptimizedDoubleBuffer |
					 ControlStyles.ResizeRedraw |
					 ControlStyles.UserPaint, true);


            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(239, 239, 242);
            this.CaptionHeight = 30;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconColor = Color.FromArgb(184, 182, 183);
            this.IconColorHover = Color.FromArgb(255, 255, 255);
            this.Caption = new Caption();
            this.Caption.Height = this.CaptionHeight;
            this.Caption.Dock = DockStyle.Top;
            this.Caption.WindowStateChanging += new EventHandler<EventArgs>(OnWindowStateChanging);
        }
        
        private void OnWindowStateChanging(object sender, EventArgs e)
        {
            this.m_bDisableBoundsCore = true;
            this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the CreateControl event. 
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Controls.Add(this.Caption);
        }
        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"/> that contains the event data.</param>
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    if (e != null)
        //    {
        //        base.OnMouseDown(e);
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            if (((this.Width - m_formResizeMargin) > e.Location.X)
        //                && (e.Location.X > m_formResizeMargin)
        //                && (e.Location.Y > m_formResizeMargin)
        //                && (e.Location.Y <= CaptionHeight))
        //            {
        //                MoveControl(this.Handle);
        //            }
        //            else if (this.WindowState != FormWindowState.Maximized)
        //            {
        //                this.ResizeForm(this.m_resizeDirectionMode);
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// Paints the background of the form.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains information about the control to paint. </param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e != null)
            {
                base.OnPaintBackground(e);
                if (this.BorderColor != null)
                {
                    Rectangle borderRectangle = this.ClientRectangle;
                    borderRectangle.Inflate(-1, -1);
                    
                    using (Pen borderPen = new Pen(this.BorderColor))
                    {
                        e.Graphics.DrawRectangle(borderPen, borderRectangle);
                    }
                }
            }
        }
        ///// <summary>
        ///// Raises the MouseLeave event.
        ///// </summary>
        ///// <param name="e">An <see cref="EventArgs"/> that contains the event data. </param>
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    System.Diagnostics.Trace.WriteLine("mouseLeave:" + DateTime.Now.Ticks);
        //    base.OnMouseLeave(e);
        //    this.OnResizeNotifierChanged(ResizeDirectionMode.None);
        //}
        /// <summary>
        /// Performs the work of setting the specified bounds of this form. 
        /// </summary>
        /// <param name="x">The new Left property value of the form.</param>
        /// <param name="y">The new Top property value of the form.</param>
        /// <param name="width">The new Width property value of the form.</param>
        /// <param name="height">The new Height property value of the form.</param>
        /// <param name="specified">A bitwise combination of the BoundsSpecified values.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            //Because a wrong resizing after a change of the WindowState the SetBoundsCore sometimes must
            //be disabled. For restoring the form size at form onload the SetBoundsCore should be executed. 
            if (this.m_bDisableBoundsCore == false)
            {
                base.SetBoundsCore(x, y, width, height, specified);
            }
            this.m_bDisableBoundsCore = false;
        }
        /// <summary>
        /// Processes Windows messages. 
        /// </summary>
        /// <param name="m">The Windows <see cref="Message"/> to process. </param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            IntPtr result = IntPtr.Zero;
            if (m.Msg == NativeMethods.WM_CREATE)
            {
                BSE.Windows.Forms.Form.NativeMethods.RECT rcClient;
                NativeMethods.GetWindowRect(m.HWnd, out rcClient);

                NativeMethods.SetWindowPos(m.HWnd,
                 IntPtr.Zero,
                 rcClient.Left, rcClient.Top,
                 rcClient.Right - rcClient.Left, rcClient.Bottom - rcClient.Top,
                 NativeMethods.SetWindowPosFlags.SWP_FRAMECHANGED);

                m.Result = IntPtr.Zero;
            }
            else if (m.Msg == NativeMethods.WM_SYSCOMMAND && (int)m.WParam == NativeMethods.SC_RESTORE)
            {
                this.m_bDisableBoundsCore = true;
                base.WndProc(ref m);
            }
            //The functionality to extend the frame into the client area is exposed by the
            //DwmExtendFrameIntoClientArea function. To extend the frame, pass the handle of the target
            //window together with the margin inset values to DwmExtendFrameIntoClientArea. The margin inset
            //values determine how far to extend the frame on the four sides of the window.
            else if (m.Msg == NativeMethods.WM_ACTIVATE)
            {
                BSE.Windows.Forms.Form.NativeMethods.MARGINS margins;
                margins.cxLeftWidth = 0;
                margins.cxRightWidth = 0;
                margins.cyBottomHeight = 1;
                margins.cyTopHeight = 0;

                NativeMethods.DwmExtendFrameIntoClientArea(m.HWnd, ref margins);
                m.Result = IntPtr.Zero;
            }
            else if (NativeMethods.DwmDefWindowProc(m.HWnd, m.Msg, m.WParam, m.LParam, ref result) == 1)
            {
                m.Result = result;
            }
            else if ((m.Msg == NativeMethods.WM_NCCALCSIZE) && (((int)m.WParam) == 1))
            {
                NativeMethods.NCCALCSIZE_PARAMS nccsp =
                    (NativeMethods.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));

                if (!this.m_hasMarginsChecked)
                {
                    //Set what client area would be for passing to DwmExtendIntoClientArea
                    SetMargins(new Padding(
                         nccsp.rect2.Left - nccsp.rect1.Left,
                         nccsp.rect2.Top - nccsp.rect1.Top,
                         nccsp.rect1.Right - nccsp.rect2.Right,
                         nccsp.rect1.Bottom - nccsp.rect2.Bottom));

                    this.m_hasMarginsChecked = true;
                }
                
                //nccsp.rect0.Bottom -= 1;
                //
                Marshal.StructureToPtr(nccsp, m.LParam, false);
                this.m_marginInset.cyBottomHeight = 1;
                m.Result = IntPtr.Zero;
            }
            else if ((m.Msg == NativeMethods.WM_NCHITTEST) && (((int)m.Result) == 0))
            {
                //m.Result = new IntPtr(Convert.ToInt32(NonClientHitTest(new Point(LoWord((int)m.LParam), HiWord((int)m.LParam)))));

                m.Result = this.HitTestNCA(m.HWnd, m.WParam, m.LParam);
            }
            //else if (m.Msg == NativeMethods.WM_NCMOUSEMOVE)
            //{
            //    this.CalculateBorders();
            //    Point point = new Point(m.LParam.ToInt32());
            //    if (this.m_topLeftResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.TopLeft);
            //    }
            //    else if (this.m_topResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.Top);
            //    }
            //    else if (this.m_topRightResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.TopRight);
            //    }
            //    else if (this.m_rightResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.Right);
            //    }
            //    else if (this.m_bottomRightResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.BottomRight);
            //    }
            //    else if (this.m_bottomResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.Bottom);
            //    }
            //    else if (this.m_bottomLeftResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.BottomLeft);
            //    }
            //    else if (this.m_leftResizeRectangle.Contains(point) == true)
            //    {
            //        this.OnResizeNotifierChanged(ResizeDirectionMode.Left);
            //    }
            //}
            else
            {
                base.WndProc(ref m);
            }
        }
        #endregion

        #region MethodsPrivate
        //private void OnResizeNotifierChanged(ResizeDirectionMode resizeDirectionMode)
        //{
        //    if (this.ResizeDirection != resizeDirectionMode)
        //    {
        //        this.ResizeDirection = resizeDirectionMode;
        //    }
        //}
        //private static void MoveControl(IntPtr hWnd)
        //{
        //    NativeMethods.ReleaseCapture();
        //    NativeMethods.SendMessage(hWnd, 0xa1, 2, 0);
        //}
        //private void CalculateBorders()
        //{
        //    this.m_topResizeRectangle = this.ClientRectangle;
        //    this.m_topResizeRectangle.X = m_formResizeMargin;
        //    this.m_topResizeRectangle.Height = m_formResizeMargin;
        //    this.m_topResizeRectangle.Width -= (2 * m_formResizeMargin);

        //    this.m_topLeftResizeRectangle = this.m_topResizeRectangle;
        //    this.m_topLeftResizeRectangle.X -= m_formResizeMargin;
        //    this.m_topLeftResizeRectangle.Width = m_formResizeMargin;

        //    this.m_leftResizeRectangle = this.ClientRectangle;
        //    this.m_leftResizeRectangle.Y = m_formResizeMargin;
        //    this.m_leftResizeRectangle.Width = m_formResizeMargin;
        //    this.m_leftResizeRectangle.Height -= (2 * m_formResizeMargin);

        //    this.m_topRightResizeRectangle = this.m_topLeftResizeRectangle;
        //    this.m_topRightResizeRectangle.X = this.ClientRectangle.Width - m_formResizeMargin;

        //    this.m_rightResizeRectangle = this.m_leftResizeRectangle;
        //    this.m_rightResizeRectangle.X = this.ClientRectangle.Width - m_formResizeMargin;

        //    this.m_bottomLeftResizeRectangle = this.m_topLeftResizeRectangle;
        //    this.m_bottomLeftResizeRectangle.Y = this.ClientRectangle.Height - m_formResizeMargin;

        //    this.m_bottomResizeRectangle = this.m_topResizeRectangle;
        //    this.m_bottomResizeRectangle.Y = this.ClientRectangle.Height - m_formResizeMargin;

        //    this.m_bottomRightResizeRectangle = this.m_topRightResizeRectangle;
        //    this.m_bottomRightResizeRectangle.Y = this.ClientRectangle.Height - m_formResizeMargin;
        //}
        
        //private void ResizeForm(ResizeDirectionMode direction)
        //{
        //    int iDirection = -1;
        //    switch (direction)
        //    {
        //        case ResizeDirectionMode.Left:
        //            iDirection = 10;
        //            break;

        //        case ResizeDirectionMode.TopLeft:
        //            iDirection = 13;
        //            break;

        //        case ResizeDirectionMode.Top:
        //            iDirection = 12;
        //            break;

        //        case ResizeDirectionMode.TopRight:
        //            iDirection = 14;
        //            break;

        //        case ResizeDirectionMode.Right:
        //            iDirection = 11;
        //            break;

        //        case ResizeDirectionMode.BottomRight:
        //            iDirection = 0x11;
        //            break;

        //        case ResizeDirectionMode.Bottom:
        //            iDirection = 15;
        //            break;

        //        case ResizeDirectionMode.BottomLeft:
        //            iDirection = 0x10;
        //            break;
        //    }
        //    if (iDirection != -1)
        //    {
        //        NativeMethods.ReleaseCapture();
        //        NativeMethods.SendMessage(this.Handle, 0xa1, iDirection, 0);
        //    }
        //}
        private static int HiWord(int dwValue)
        {
            return ((dwValue >> 0x10) & 0xffff);
        }

        private static int LoWord(int dwValue)
        {
            return (dwValue & 0xffff);
        }

        private IntPtr HitTestNCA(IntPtr hwnd, IntPtr wparam, IntPtr lparam)
        {
            int HTCLIENT = 1;
            int HTCAPTION = 2;
//            int HTMINBUTTON = 8;
//            int HTMAXBUTTON = 9;
            int HTLEFT = 10;
            int HTRIGHT = 11;
            int HTTOP = 12;
            int HTTOPLEFT = 13;
            int HTTOPRIGHT = 14;
            int HTBOTTOM = 15;
            int HTBOTTOMLEFT = 0x10;
            int HTBOTTOMRIGHT = 0x11;
//            int HTREDUCE = HTMINBUTTON;
//            int HTZOOM = HTMAXBUTTON;
//            int HTSIZEFIRST = HTLEFT;
//            int HTSIZELAST = HTBOTTOMRIGHT;
            Point p = new Point(LoWord((int)lparam), HiWord((int)lparam));
            Rectangle rectangle = new Rectangle(0, 0, this.FormThickness.Left, this.FormThickness.Left);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTTOPLEFT);
            }
            rectangle = new Rectangle(this.Width - this.FormThickness.Right, 0, this.FormThickness.Right, this.FormThickness.Right);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTTOPRIGHT);
            }
            rectangle = new Rectangle(0, this.Height - this.FormThickness.Bottom, this.FormThickness.Left, this.FormThickness.Bottom);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTBOTTOMLEFT);
            }
            rectangle = new Rectangle(this.Width - this.FormThickness.Right, this.Height - this.FormThickness.Bottom, this.FormThickness.Right, this.FormThickness.Bottom);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTBOTTOMRIGHT);
            }
            rectangle = new Rectangle(0, 0, this.Width, this.FormThickness.Left);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTTOP);
            }
            rectangle = new Rectangle(0, this.FormThickness.Left, this.Width, this.FormThickness.Top - this.FormThickness.Left);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTCAPTION);
            }
            rectangle = new Rectangle(0, 0, this.FormThickness.Left, this.Height);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTLEFT);
            }
            rectangle = new Rectangle(this.Width - this.FormThickness.Right, 0, this.FormThickness.Right, this.Height);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTRIGHT);
            }
            rectangle = new Rectangle(0, this.Height - this.FormThickness.Bottom, this.Width, this.FormThickness.Bottom);
            if (this.RectangleToScreen(rectangle).Contains(p))
            {
                return new IntPtr(HTBOTTOM);
            }
            return new IntPtr(HTCLIENT);
        }
        private void SetMargins(Padding p)
        {
            m_formThickness = p;

            Padding formPadding = p;
            formPadding.Top = p.Bottom - 1;

            if (!this.DesignMode)
            {
                this.Padding = formPadding;
            }
        }
        #endregion

    }
}
