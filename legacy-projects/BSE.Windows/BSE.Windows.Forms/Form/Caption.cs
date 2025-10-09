using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace BSE.Windows.Forms.Form
{
    public class Caption : ContainerControl
    {
        #region Events
        public event EventHandler<EventArgs> WindowStateChanging;
        #endregion

        #region FieldsPrivate
        private Rectangle m_closeButtonRectangle = Rectangle.Empty;
        private Rectangle m_maximizeButtonRectangle = Rectangle.Empty;
        private Rectangle m_minimizeButtonRectangle = Rectangle.Empty;
        #endregion

        #region Properties
        private static Rectangle ButtonRecangle
        {
            get
            {
                return new Rectangle(0, 0, 10, 10);
            }
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
        public override Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle
                    (0, 0, this.Width - 50, this.Height);
            }
        }
        private HoverState HoverStateCloseButton
        {
            get;
            set;
        }
        private HoverState HoverStateMaximizeButton
        {
            get;
            set;
        }
        private HoverState HoverStateMinimizeButton
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        public Caption()
        {
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
            this.IconColor = Color.FromArgb(184, 182, 183);
            this.IconColorHover = Color.FromArgb(255, 255, 255);
            base.SuspendLayout();
            base.ResumeLayout(true);
        }
        #endregion

        #region MethodsProtected
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e != null)
            {
                base.OnMouseDown(e);
                if (e.Button == MouseButtons.Left)
                {
                    if (this.m_closeButtonRectangle.Contains(e.X, e.Y) == true)
                    {
                        this.ParentForm.Close();
                    }
                    else if (this.m_maximizeButtonRectangle.Contains(e.X, e.Y) == true)
                    {
                        if (this.WindowStateChanging != null)
                        {
                            this.WindowStateChanging(this, EventArgs.Empty);
                        }
                    }
                    else if (this.m_minimizeButtonRectangle.Contains(e.X, e.Y) == true)
                    {
                        this.ParentForm.WindowState = FormWindowState.Minimized;
                    }
                    else
                    {
                        NativeMethods.ReleaseCapture();
                        NativeMethods.SendMessage(this.ParentForm.Handle, 0xa1, 2, 0);
                    }
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e != null)
            {
                base.OnMouseMove(e);
                if (this.HoverStateCloseButton == HoverState.Hover)
                {
                    this.HoverStateCloseButton = HoverState.None;
                    this.Invalidate(this.m_closeButtonRectangle);
                }
                if (this.HoverStateMaximizeButton == HoverState.Hover)
                {
                    this.HoverStateMaximizeButton = HoverState.None;
                    this.Invalidate(this.m_maximizeButtonRectangle);
                }
                if (this.HoverStateMinimizeButton == HoverState.Hover)
                {
                    this.HoverStateMinimizeButton = HoverState.None;
                    this.Invalidate(this.m_minimizeButtonRectangle);
                }
                if (this.m_closeButtonRectangle.Contains(e.X, e.Y) == true)
                {
                    this.HoverStateCloseButton = HoverState.Hover;
                    this.Invalidate(this.m_closeButtonRectangle);
                }
                else if (this.m_maximizeButtonRectangle.Contains(e.X, e.Y) == true)
                {
                    this.HoverStateMaximizeButton = HoverState.Hover;
                    this.Invalidate(this.m_maximizeButtonRectangle);
                }
                else if (this.m_minimizeButtonRectangle.Contains(e.X, e.Y) == true)
                {
                    this.HoverStateMinimizeButton = HoverState.Hover;
                    this.Invalidate(this.m_minimizeButtonRectangle);
                }


            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e != null)
            {
                base.OnPaint(e);

                this.m_closeButtonRectangle = ButtonRecangle;
                this.m_closeButtonRectangle.X = this.Width - 19;
                this.m_closeButtonRectangle.Y = 7;

                Rectangle innerCloseButtonRectangle = this.m_closeButtonRectangle;
                innerCloseButtonRectangle.X += 2;
                innerCloseButtonRectangle.Y += 3;
                innerCloseButtonRectangle.Width = 7;
                innerCloseButtonRectangle.Height = 6;

                this.m_maximizeButtonRectangle = ButtonRecangle;
                this.m_maximizeButtonRectangle.X = this.m_closeButtonRectangle.X - 14;
                this.m_maximizeButtonRectangle.Y = this.m_closeButtonRectangle.Y;

                Rectangle innerMaximizeButtonRectangle = this.m_maximizeButtonRectangle;
                innerMaximizeButtonRectangle.X += 1;
                innerMaximizeButtonRectangle.Y += 1;
                innerMaximizeButtonRectangle.Width = 8;
                innerMaximizeButtonRectangle.Height = 9;

                this.m_minimizeButtonRectangle = ButtonRecangle;
                this.m_minimizeButtonRectangle.X = this.m_maximizeButtonRectangle.X - 14;
                this.m_minimizeButtonRectangle.Y = this.m_closeButtonRectangle.Y;

                Rectangle innerMinimizeButtonRectangle = this.m_minimizeButtonRectangle;
                innerMinimizeButtonRectangle.X += 2;
                innerMinimizeButtonRectangle.Y += 9;
                innerMinimizeButtonRectangle.Width = 7;
                innerMinimizeButtonRectangle.Height = 2;

                using (Pen penCloseButton = new Pen(this.IconColor))
                {
                    penCloseButton.Width = 1.8f;
                    if (this.HoverStateCloseButton == HoverState.Hover)
                    {
                        penCloseButton.Color = this.IconColorHover;
                    }
                    e.Graphics.DrawLine(penCloseButton,
                        innerCloseButtonRectangle.Left,
                        innerCloseButtonRectangle.Top,
                        innerCloseButtonRectangle.Left + innerCloseButtonRectangle.Width,
                        innerCloseButtonRectangle.Top + innerCloseButtonRectangle.Height);

                    e.Graphics.DrawLine(penCloseButton,
                        innerCloseButtonRectangle.Left,
                        innerCloseButtonRectangle.Top + innerCloseButtonRectangle.Height,
                        innerCloseButtonRectangle.Left + innerCloseButtonRectangle.Width,
                        innerCloseButtonRectangle.Top);

                    penCloseButton.Width = 1;
                    Rectangle terminationRectangle = new Rectangle();
                    terminationRectangle.X = innerCloseButtonRectangle.Left;
                    terminationRectangle.Y = innerCloseButtonRectangle.Top;
                    terminationRectangle.Width = 1;
                    terminationRectangle.Height = 1;

                    e.Graphics.DrawRectangle(penCloseButton, terminationRectangle);

                    terminationRectangle.Y += 5;
                    e.Graphics.DrawRectangle(penCloseButton, terminationRectangle);

                }

                if (this.ParentForm.FormBorderStyle != FormBorderStyle.FixedToolWindow)
                {
                    using (Pen penMaximizeButton = new Pen(this.IconColor))
                    {
                        if (this.HoverStateMaximizeButton == HoverState.Hover)
                        {
                            penMaximizeButton.Color = this.IconColorHover;
                        }
                        if (this.ParentForm.WindowState == FormWindowState.Maximized)
                        {
                            innerMaximizeButtonRectangle.X += 3;
                            innerMaximizeButtonRectangle.Y += 1;
                            innerMaximizeButtonRectangle.Width = 6;
                            innerMaximizeButtonRectangle.Height = 6;
                            e.Graphics.DrawRectangle(penMaximizeButton,
                                innerMaximizeButtonRectangle);

                            innerMaximizeButtonRectangle.X -= 1;
                            innerMaximizeButtonRectangle.Y += 3;
                            innerMaximizeButtonRectangle.Width = 5;
                            innerMaximizeButtonRectangle.Height = 5;
                            penMaximizeButton.Width = 2;
                            e.Graphics.DrawRectangle(penMaximizeButton,
                                innerMaximizeButtonRectangle);
                        }
                        else
                        {
                            innerMaximizeButtonRectangle.Height = 7;
                            innerMaximizeButtonRectangle.Y += 2;
                            e.Graphics.DrawRectangle(penMaximizeButton, innerMaximizeButtonRectangle);
                            penMaximizeButton.Width = 2;
                            e.Graphics.DrawLine(penMaximizeButton,
                                innerMaximizeButtonRectangle.Left,
                                innerMaximizeButtonRectangle.Top + 1,
                                innerMaximizeButtonRectangle.Left + innerMaximizeButtonRectangle.Width,
                                innerMaximizeButtonRectangle.Top + 1);
                        }
                    }
                    using (SolidBrush solidBrush = new SolidBrush(this.IconColor))
                    {
                        if (this.HoverStateMinimizeButton == HoverState.Hover)
                        {
                            solidBrush.Color = this.IconColorHover;
                        }
                        e.Graphics.FillRectangle(solidBrush, innerMinimizeButtonRectangle);
                    }
                }
            }
        }
        #endregion
    }
}
