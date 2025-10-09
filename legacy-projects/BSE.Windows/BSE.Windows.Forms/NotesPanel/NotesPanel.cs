using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Collections;

namespace BSE.Windows.Forms
{
    /// <summary>
    /// Used to display collections of notes. 
    /// </summary>
    /// <remarks>The Panel is a control that contains other controls.
    /// You can use a Panel to group collections of controls such as the XPanderPanelList control.
    /// On top of the Panel there is the captionbar. This captionbar may contain an image and text.
    /// According to it's dockstyle and properties the panel is collapsable and/or closable.</remarks>
    /// <copyright>Copyright © 2009 Uwe Eichkorn
    /// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
    /// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    /// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
    /// PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
    /// REMAINS UNCHANGED.
    /// </copyright>
    public partial class NotesPanel : ScrollableControl

    {
        #region Events
        #endregion

        #region Constants
        #endregion

        #region FieldsPrivate
        private Color m_colorGradientBegin;
        private Color m_colorGradientEnd;
        private Color m_pressedBorderColor;
        private Color m_borderColor;
        private bool m_bIsClickable;
        private bool m_bMouseDown;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the border color of a NotesPanel.
        /// </summary>
        [Description("The border color of a NotesPanel.")]
        public Color BorderColor
        {
            get { return this.m_borderColor; }
            set
            {
                if (value.Equals(this.m_borderColor) == false)
                {
                    this.m_borderColor = value;
                    OnBorderColorChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the border color of a NotesPanel when the NotesPanel is pressed down.
        /// </summary>
        [Description("The border color of a NotesPanel when the NotesPanel is pressed down.")]
        public Color PressedBorderColor
        {
            get { return this.m_pressedBorderColor; }
            set
            {
                if (value.Equals(this.m_pressedBorderColor) == false)
                {
                    this.m_pressedBorderColor = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient on a NotesPanel.
        /// </summary>
        [Description("The starting color of the gradient on a NotesPanel")]
        public Color ColorGradientBegin
        {
            get { return this.m_colorGradientBegin; }
            set
            {
                if (value.Equals(this.m_colorGradientBegin) == false)
                {
                    this.m_colorGradientBegin = value;
                    OnColorGradientBeginChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient on a NotesPanel.
        /// </summary>
        [Description("The end color of the gradient on a NotesPanel")]
        public Color ColorGradientEnd
        {
            get { return this.m_colorGradientEnd; }
            set
            {
                if (value.Equals(this.m_colorGradientEnd) == false)
                {
                    this.m_colorGradientEnd = value;
                    OnColorGradientEndChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets a value whether the control is clickable.
        /// </summary>
        [Description("A value whether the control is clickable.")]
        [DefaultValue(false)]
        public bool IsClickable
        {
            get { return this.m_bIsClickable; }
            set
            {
                if (value.Equals(this.m_bIsClickable) == false)
                {
                    this.m_bIsClickable = value;
                }
            }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the NotesPanel class.
        /// </summary>
        public NotesPanel()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ContainerControl, true);
            
            InitializeComponent();

            this.Padding = new Padding(5);
            this.m_colorGradientBegin = Color.FromArgb(180, 199, 237);
            this.m_colorGradientEnd = Color.FromArgb(115, 156, 217);
            this.m_borderColor = Color.FromArgb(40, 81, 142);
            this.m_pressedBorderColor = Color.Black;
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the Click event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            if (this.m_bIsClickable == true)
            {
                base.OnClick(e);
            }
        }
        /// <summary>
        /// Raises the CreateControl method.
        /// </summary>
        protected override void OnCreateControl()
        {
            ArrayList controlsArray = FindControls(typeof(Control), true, this.Controls, new ArrayList());
            foreach (Control control in controlsArray)
            {
                control.Click += new EventHandler(ControlClick);
                control.MouseDown += new MouseEventHandler(ControlMouseDown);
                control.MouseUp += new MouseEventHandler(ControlMouseUp);
            }
            base.OnCreateControl();
        }
        /// <summary>
        /// Raises the MouseDown event
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains data about the OnMouseDown event.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.m_bIsClickable == true)
            {
                this.m_bMouseDown = true;
                Invalidate(false);
                base.OnMouseDown(e);
            }
        }
        /// <summary>
        /// Raises the MouseUp event
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains data about the OnMouseUp event.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.m_bIsClickable == true)
            {
                this.m_bMouseDown = false;
                Invalidate(false);
                base.OnMouseDown(e);
            }
        }
        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle clientRectangle = this.ClientRectangle;
            clientRectangle.Height -= Constants.BorderThickness;
            clientRectangle.Width -= Constants.BorderThickness;

            if (LayoutUtils.IsZeroWidthOrHeight(clientRectangle) == true)
            {
                return;
            }

            Graphics graphics = e.Graphics;

            using (UseAntiAlias useAntiAlias = new UseAntiAlias(graphics))
            {
                using (GraphicsPath graphicsPath = LayoutUtils.GetBackgroundPath(clientRectangle, 10))
                {
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                        clientRectangle,
                        this.m_colorGradientBegin,
                        this.m_colorGradientEnd,
                        LinearGradientMode.Vertical))
                    {
                        graphics.FillPath(linearGradientBrush, graphicsPath);
                    }

                    Color borderColor = this.m_borderColor;
                    if (this.m_bMouseDown == true)
                    {
                        borderColor = this.m_pressedBorderColor;
                    }

                    using (Pen borderPen = new Pen(borderColor))
                    {
                        graphics.DrawPath(borderPen, graphicsPath);
                    }
                }
            }
        }
        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A PaintEventArgs that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            this.BackColor = Color.Transparent;
            base.OnPaintBackground(pevent);
        }
        #endregion

        #region MethodsPrivate
        
        private void OnBorderColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        
        private void OnColorGradientBeginChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        
        private void OnColorGradientEndChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ControlClick(object sender, EventArgs e)
        {
            OnClick(e);
        }
        
        private void ControlMouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void ControlMouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private static ArrayList FindControls(Type baseType, bool searchAllChildren, Control.ControlCollection controlsToLookIn, ArrayList foundControls)
        {
            if ((controlsToLookIn == null) || (foundControls == null))
            {
                return null;
            }
            try
            {
                for (int i = 0; i < controlsToLookIn.Count; i++)
                {
                    if ((controlsToLookIn[i] != null) && baseType.IsAssignableFrom(controlsToLookIn[i].GetType()))
                    {
                        foundControls.Add(controlsToLookIn[i]);
                    }
                }
                if (searchAllChildren == false)
                {
                    return foundControls;
                }
                for (int j = 0; j < controlsToLookIn.Count; j++)
                {
                    if (((controlsToLookIn[j] != null) && !(controlsToLookIn[j] is System.Windows.Forms.Form)) && ((controlsToLookIn[j].Controls != null) && (controlsToLookIn[j].Controls.Count > 0)))
                    {
                        foundControls = FindControls(baseType, searchAllChildren, controlsToLookIn[j].Controls, foundControls);
                    }
                }
            }
            catch (Exception exception)
            {
                if (IsCriticalException(exception))
                {
                    throw;
                }
            }
            return foundControls;
        }

        private static bool IsCriticalException(Exception exception)
        {
            return (((((exception is NullReferenceException) ||
                (exception is StackOverflowException)) ||
                ((exception is OutOfMemoryException) ||
                (exception is System.Threading.ThreadAbortException))) ||
                ((exception is ExecutionEngineException) ||
                (exception is IndexOutOfRangeException))) ||
                (exception is AccessViolationException));
        }
        #endregion
    }
}
