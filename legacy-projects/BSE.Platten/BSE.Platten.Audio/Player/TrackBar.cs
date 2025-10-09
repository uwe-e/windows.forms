using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using BSE.Platten.Audio.Properties;
using System.Diagnostics.CodeAnalysis;

namespace BSE.Platten.Audio
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ToolStripLabel))]    
    public class TrackBar : Control
    {
        #region Events
        /// <summary>
        /// Occurs when either a mouse action moves the slider.
        /// </summary>
        [Description("Occurs when either a mouse action moves the slider.")]
        public event EventHandler<EventArgs> Scroll;
        /// <summary>
        /// Occurs when the Value property of a TrackBar changes.
        /// </summary>
        [Description("Occurs when the Value property of a TrackBar changes.")]
        public event EventHandler<EventArgs> ValueChanged;
        /// <summary>
        /// Occurs when the value of the SliderGradientBegin property changes.
        /// </summary>
        [Description("Occurs when the value of the SliderGradientBegin property changes.")]
        public event EventHandler<EventArgs> SliderGradientBeginChanged;
        /// <summary>
        /// Occurs when the value of the SliderGradientEnd property changes.
        /// </summary>
        [Description("Occurs when the value of the SliderGradientEnd property changes.")]
        public event EventHandler<EventArgs> SliderGradientEndChanged;
        /// <summary>
        /// Occurs when the value of the TrackLineGradientBegin property changes.
        /// </summary>
        [Description("Occurs when the value of the TrackLineGradientBegin property changes.")]
        public event EventHandler<EventArgs> TrackLineGradientBeginChanged;
        /// <summary>
        /// Occurs when the value of the TrackLineGradientEnd property changes.
        /// </summary>
        [Description("Occurs when the value of the TrackLineGradientEnd property changes.")]
        public event EventHandler<EventArgs> TrackLineGradientEndChanged;
        /// <summary>
        /// Occurs when the value of the TrackLine property changes.
        /// </summary>
        [Description("Occurs when the value of the TrackLine property changes.")]
        public event EventHandler<EventArgs> TrackLineChanged;
        /// <summary>
        /// Occurs when the ThumbState on the TrackBar changes.
        /// </summary>
        [Description("Occurs when the ThumbState on the TrackBar changes.")]
        public event EventHandler<ThumbStateChangedEventArgs> ThumbStateChanged;
        #endregion

        #region Constants

        private const int TrackAreaPadding = 2;

		#endregion

		#region FieldsPrivate

        private ToolTip m_ttTicker;
        private int m_iMinimum;
        private int m_iMaximum;
        private int m_iValue;
        private int m_iCurrentTrackerPosition;
        private ThumbState m_thumbState;
        private Rectangle m_thumbArea = Rectangle.Empty;
        private Rectangle m_trackArea = Rectangle.Empty;
		private Rectangle m_trackLineArea = Rectangle.Empty;
		private Padding m_paddingTrackArea = new Padding(1, 2, 1, 2);
		private Image m_imgSlider;
        private Color m_colorSliderGradientBegin;
        private Color m_colorSliderGradientEnd;
        private Image m_imgTrackLine;
        private Color m_colorTrackLineGradientBegin;
        private Color m_colorTrackLineGradientEnd;
        private Color m_colorTrackLine;
        private Color m_colorElapsedTrackLine;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>
        /// The foreground <see cref="Color"/> of the control. The default is the value of the <see cref="DefaultForeColor"/> property.
        /// </value>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                if (base.ForeColor.Equals(value) == false)
                {
                    base.ForeColor = value;
                    Invalidate(false);
                }
            }
        }
        /// <summary>
        /// Gets or sets the lower limit of the range this <see cref="TrackBar"/> is working with.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.Int32"/>
        /// The minimum value for the <see cref="TrackBar"/>. The default is 0.
        /// </value>
        [Category("Appearance")]
        [Description("The minimum value for the position of the slider on the TrackBar")]
        [DefaultValue(0)]
        [RefreshProperties(RefreshProperties.All)]
        public int Minimum
        {
            get { return this.m_iMinimum; }
            set
            {

                if (this.m_iMinimum != value)
                {
                    this.m_iMinimum = value;
					if (this.m_iMinimum > this.m_iMaximum)
					{
						this.m_iMaximum = this.m_iMinimum;
					}
                }
            }
        }
        /// <summary>
        /// Gets or sets the upper limit of the range this <see cref="TrackBar"/> is working with.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.Int32"/>
        /// The maximum value for the <see cref="TrackBar"/>. The default is 10.
        /// </value>
        [Category("Appearance")]
        [Description("The maximum value for the position of the slider on the TrackBar")]
        [DefaultValue(10)]
        [RefreshProperties(RefreshProperties.All)]
        public int Maximum
        {
            get { return this.m_iMaximum; }
            set
            {
                if (this.m_iMaximum != value)
                {
                    this.m_iMaximum = value;
                    if (this.m_iMaximum < this.m_iMinimum)
                    {
                        this.m_iMinimum = this.m_iMaximum;
                    }
                }
            }
        }
        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
        /// </summary>
        /// <value>
        /// Type: <see cref="System.Int32"/>
        /// A numeric value that is within the <see cref="Minimum"/> and <see cref="Maximum"/> range. The default value is 0.
        /// </value>
        [Category("Behavior")]
        [Description("The position of the slider")]
        [DefaultValue(0)]
        public int Value
        {
            get { return this.m_iValue; }
            set
            {
                if (this.m_iValue != value)
                {
                    this.m_iValue = value;
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used in the Slider.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the starting color of the gradient used in the Slider.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.OverflowButtonGradientEnd")]
        public Color SliderGradientBegin
        {
            get { return this.m_colorSliderGradientBegin; }
            set
            {
                if (value.Equals(this.m_colorSliderGradientBegin) == false)
                {
                    this.m_colorSliderGradientBegin = value;
                    OnSliderGradientBeginChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used in the Slider.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the end color of the gradient used in the Slider.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.OverflowButtonGradientBegin")]
        public Color SliderGradientEnd
        {
            get { return this.m_colorSliderGradientEnd; }
            set
            {
                if (value.Equals(this.m_colorSliderGradientEnd) == false)
                {
                    this.m_colorSliderGradientEnd = value;
                    OnSliderGradientEndChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the starting color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.ToolStripGradientBegin")]
        public Color TrackLineGradientBegin
        {
            get { return this.m_colorTrackLineGradientBegin; }
            set
            {
                if (value.Equals(this.m_colorTrackLineGradientBegin) == false)
                {
                    this.m_colorTrackLineGradientBegin = value;
                    OnTrackLineGradientBeginChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the end color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.ToolStripGradientEnd")]
        public Color TrackLineGradientEnd
        {
            get { return this.m_colorTrackLineGradientEnd; }
            set
            {
                if (value.Equals(this.m_colorTrackLineGradientEnd) == false)
                {
                    this.m_colorTrackLineGradientEnd = value;
                    OnTrackLineGradientEndChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the tracker color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the tracker color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(Color), "System.Drawing.Color.Blue")]
        public Color TrackLine
        {
            get { return this.m_colorTrackLine; }
            set
            {
                if (value.Equals(this.m_colorTrackLine) == false)
                {
                    this.m_colorTrackLine = value;
                    OnTrackLineChanged(this, EventArgs.Empty);
                }
            }
        }
        /// <summary>
        /// Gets or sets the elapsed tracker color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the elapsed tracker color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(Color), "System.Drawing.Color.Lime")]
        public Color ElapsedTrackLine
        {
            get { return this.m_colorElapsedTrackLine; }
            set
            {
                if (value.Equals(this.m_colorElapsedTrackLine) == false)
                {
                    this.m_colorElapsedTrackLine = value;
                }
            }
        }
        /// <summary>
        /// Gets the default size of the TrackBar
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(300, 22);
            }
        }
        internal Rectangle ThumbArea
        {
            get { return this.m_thumbArea; }
            set { this.m_thumbArea = value; }
        }
        internal Rectangle TrackArea
        {
            get { return this.m_trackArea; }
            set { this.m_trackArea = value; }
        }
		internal Rectangle TrackLineArea
		{
			get { return this.m_trackLineArea; }
			set { this.m_trackLineArea = value; }
		}
        internal static Size ThumbSize
        {
            get { return new Size(21, 8); }
        }

        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the TrackBar class.
        /// </summary>
        public TrackBar()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            Control.CheckForIllegalCrossThreadCalls = false;

            this.m_ttTicker = new ToolTip();
            this.m_colorSliderGradientBegin = ProfessionalColors.OverflowButtonGradientEnd;
            this.m_colorSliderGradientEnd = ProfessionalColors.OverflowButtonGradientBegin;
            this.m_colorTrackLineGradientBegin = ProfessionalColors.ToolStripGradientBegin;
            this.m_colorTrackLineGradientEnd = ProfessionalColors.ToolStripGradientEnd;
            this.m_colorTrackLine = Color.Blue;
            this.m_colorElapsedTrackLine = Color.Lime;
            this.m_iMaximum = 100;

        }
        /// <summary>
        /// Starts the slider on the TrackBar.
        /// </summary>
		public void Start()
		{
            this.Invalidate(false);
		}
        /// <summary>
        /// Starts the slider on the TrackBar.
        /// </summary>
        /// <param name="strText">The displayed text of the TrackBar</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public void Start(string strText)
		{
            this.Text = strText;
            this.Start();
		}

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Raises the SliderGradientBegin changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnSliderGradientBeginChanged(object sender, EventArgs e)
        {
            if (this.m_imgSlider != null)
            {
                this.m_imgSlider = null;
            }
            if (this.SliderGradientBeginChanged != null)
            {
                this.SliderGradientBeginChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the SliderGradientEnd changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnSliderGradientEndChanged(object sender, EventArgs e)
        {
            if (this.m_imgSlider != null)
            {
                this.m_imgSlider = null;
            }
            if (this.SliderGradientEndChanged != null)
            {
                this.SliderGradientEndChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the TrackLineGradientBegin changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnTrackLineGradientBeginChanged(object sender, EventArgs e)
        {
            if (this.m_imgTrackLine != null)
            {
                this.m_imgTrackLine = null;
            }
            if (this.TrackLineGradientBeginChanged != null)
            {
                this.TrackLineGradientBeginChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the TrackLineGradientEnd changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnTrackLineGradientEndChanged(object sender, EventArgs e)
        {
            if (this.m_imgTrackLine != null)
            {
                this.m_imgTrackLine = null;
            }
            if (this.TrackLineGradientEndChanged != null)
            {
                this.TrackLineGradientEndChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the TrackLine changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A EventArgs that contains the event data.</param>
        protected virtual void OnTrackLineChanged(object sender, EventArgs e)
        {
            if (this.m_imgTrackLine != null)
            {
                this.m_imgTrackLine = null;
            }
            if (this.TrackLineChanged != null)
            {
                this.TrackLineChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the MouseMove event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.m_thumbArea.Contains(e.Location) == true)
            {
                Cursor.Current = Cursors.Hand;
            }

            if (this.m_thumbState == ThumbState.Pressed)
            {
                CalculateValue(new Point(e.X, e.Y));
                OnScroll(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (this.m_thumbArea.Contains(e.Location) == true)
                {
                    if (this.m_thumbState != ThumbState.Pressed)
                    {
                        this.m_thumbState = ThumbState.Pressed;
                        if (this.ThumbStateChanged != null)
                        {
                            this.ThumbStateChanged(this, new ThumbStateChangedEventArgs(ThumbState.None, ThumbState.Pressed));
                        }
                    }
                    Cursor.Current = Cursors.Hand;
                }
                else
                {
                    this.m_thumbState = ThumbState.None;
                }
            }
        }
        /// <summary>
        /// Raises the MouseUp event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.m_thumbState == ThumbState.Pressed)
            {
                CalculateValue(new Point(e.X, e.Y));
                this.m_thumbState = ThumbState.None;
                if (this.ThumbStateChanged != null)
                {
                    this.ThumbStateChanged(this, new ThumbStateChangedEventArgs(ThumbState.Pressed, ThumbState.None));
                }
            }
        }
        /// <summary>
        /// Raises the MouseHover event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            if (String.IsNullOrEmpty(this.Text) == false)
            {
                this.m_ttTicker.SetToolTip(this, this.Text);
            }
        }
        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Color foreColor = this.ForeColor;
            if (this.Enabled == false)
            {
                foreColor = SystemColors.GrayText;
            }

            using (BSE.Windows.Forms.UseClearTypeGridFit useClearTypeGridFit = new BSE.Windows.Forms.UseClearTypeGridFit(graphics))
            {
                using (SolidBrush textBrush = new SolidBrush(foreColor))
                {
                    using (StringFormat stringFormat = new StringFormat())
                    {
                        stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                        stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                        stringFormat.LineAlignment = StringAlignment.Center;

                        Rectangle stringRectangle = this.ClientRectangle;
                        stringRectangle.Height = this.ClientRectangle.Height - this.m_trackArea.Height;
                        stringRectangle.Inflate(-TrackAreaPadding, 0);

                        graphics.DrawString(this.Text, this.Font, textBrush, stringRectangle, stringFormat);
                    }
                }
            }
            // Creates the trackline bitmap
            if (this.m_imgTrackLine == null)
            {
                this.m_imgTrackLine = GetTrackLine(
                    graphics,
                    this.m_trackLineArea,
                    this.m_colorTrackLineGradientBegin,
                    this.m_colorTrackLineGradientEnd,
                    this.m_colorTrackLine);
            }
            // Creates the slider bitmap
            if (this.m_imgSlider == null)
            {
                this.m_imgSlider = GetSlider(
                    graphics,
                    this.m_thumbArea,
                    this.m_colorSliderGradientBegin,
                    this.m_colorSliderGradientEnd);
            }

            if (this.Enabled == true)
            {
                // draws the trackline bitmap
                graphics.DrawImage(this.m_imgTrackLine, this.m_trackLineArea);
                // draws the elapsed trackline
                DrawTrackLine(
                    graphics,
                    this.m_colorElapsedTrackLine,
                    this.m_trackLineArea.X + 1,
                    this.m_trackLineArea.Y + 2,
                    this.m_iCurrentTrackerPosition,
                    this.m_trackLineArea.Y + 2);
                // draws the slider
                graphics.DrawImage(this.m_imgSlider, this.m_thumbArea);
            }
            else
            {
                // draws the disabled trackline
                ControlPaint.DrawImageDisabled(
                    graphics,
                    this.m_imgTrackLine,
                    this.m_trackLineArea.X,
                    this.m_trackLineArea.Y,
                    Color.Transparent);
                // draws the disabled slider
                ControlPaint.DrawImageDisabled(
                    graphics,
                    this.m_imgSlider,
                    this.m_thumbArea.X,
                    this.m_thumbArea.Y,
                    Color.Transparent);
            }
        }
        /// <summary>
        /// Raises the Scroll event.
        /// </summary>
        /// <param name="e">The EventArgs that contains the event data.</param>
        protected virtual void OnScroll(EventArgs e)
        {
            if (this.Scroll != null)
            {
                this.Scroll(this, e);
            }
        }
        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="e">The EventArgs that contains the event data.</param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            // Calculate the current position of the slider
            this.m_iCurrentTrackerPosition = CalculateSliderPosition();

            this.m_thumbArea = new Rectangle(
                this.m_trackArea.X + this.m_iCurrentTrackerPosition,
                this.m_trackArea.Y,
                ThumbSize.Width,
                ThumbSize.Height);

            this.Invalidate(this.m_trackArea);
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, e);
            }
        }
        /// <summary>
        /// Raises the SizeChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            this.m_trackArea = this.ClientRectangle;
            this.m_trackArea.Height = ThumbSize.Height;
            this.m_trackArea.Y = this.ClientRectangle.Height - ThumbSize.Height - this.m_paddingTrackArea.Top;

            this.m_thumbArea = new Rectangle(
                this.m_trackArea.X + this.m_iCurrentTrackerPosition,
                this.m_trackArea.Y,
                ThumbSize.Width,
                ThumbSize.Height);

            this.m_trackLineArea = Rectangle.Inflate(
                this.m_trackArea,
                -this.m_paddingTrackArea.Left,
                -this.m_paddingTrackArea.Top);
            
            base.OnSizeChanged(e);
        }

        #endregion

        #region MethodsPrivate
        
        private void CalculateValue(Point ptPosition)
        {
            double dValue = (double)this.m_iMaximum / this.m_trackArea.Width * ptPosition.X;
            int iValue = (int)Math.Round(dValue, 1);
            if (iValue > this.Maximum)
            {
                iValue = this.Maximum;
            }
            if (iValue < this.Minimum)
            {
                iValue = this.Minimum + 1;
            }
            this.Value = iValue;
        }
        
        private int CalculateSliderPosition()
        {
            int iSliderPosition = 0;
            if (this.m_iValue > 0 && this.m_iMaximum > 0)
            {
                iSliderPosition =
                    this.m_trackArea.Width
                    * (this.m_iValue - this.m_iMinimum)
                    / (this.m_iMaximum - this.m_iMinimum) -
                    (ThumbSize.Width / 2);
            }

            if (iSliderPosition >= this.m_trackArea.Width - ThumbSize.Width)
            {
                iSliderPosition = this.m_trackArea.Width - ThumbSize.Width;
            }
            if (iSliderPosition <= 0)
            {
                iSliderPosition = this.m_paddingTrackArea.Left;
            }
            return iSliderPosition;
        }
        
        private static void DrawTrackLine(Graphics graphics, Color colorElapsedTrackLine, int x1, int y1, int x2, int y2)
        {
            using (Pen elapsedTrackLinePen = new Pen(colorElapsedTrackLine,2))
            {
                graphics.DrawLine(elapsedTrackLinePen, x1, y1, x2, y2);
            }
        }
        
        private static Bitmap GetTrackLine(Graphics graphics, Rectangle rectangleTrackLine, Color colorGradientBegin, Color colorGradientEnd, Color colorTrackLine)
        {
            Bitmap bitmap = new Bitmap(rectangleTrackLine.Width, rectangleTrackLine.Height, graphics);
            using (Graphics bitmapGraphics = Graphics.FromImage(bitmap))
            {
                Rectangle rectangle = rectangleTrackLine;
                rectangle.X = 0;
                rectangle.Y = 0;
                rectangle.Width -= 1;
                // draws the transparent background
                using (SolidBrush backgroundBrush = new SolidBrush(Color.Transparent))
                {
                    bitmapGraphics.FillRectangle(backgroundBrush, rectangle);
                }
                // draws the trackline border
                using (GraphicsPath outerGraphicsPath = GetPath(rectangle, 2))
                {
                    SmoothingMode smoothingMode = bitmapGraphics.SmoothingMode;
                    bitmapGraphics.SmoothingMode = SmoothingMode.HighQuality;
                    using (LinearGradientBrush outerLinearGradientBrush = new LinearGradientBrush(
                            rectangle,
                            colorGradientBegin,
                            colorGradientEnd,
                            LinearGradientMode.Vertical))
                    {
                        bitmapGraphics.FillPath(outerLinearGradientBrush, outerGraphicsPath); //draw top bubble
                    }
                    bitmapGraphics.SmoothingMode = smoothingMode;
                }
                // draws the inner trackline
                DrawTrackLine(
                    bitmapGraphics,
                    colorTrackLine,
                    rectangle.X + 1,
                    rectangle.Y + 2,
                    rectangle.Width,
                    rectangle.Y + 2);
            }
            return bitmap;
        }

        private static Bitmap GetSlider(Graphics graphics, Rectangle sliderRectancle, Color colorGradientBegin, Color colorGradientEnd)
        {
            Bitmap bitmap = new Bitmap(sliderRectancle.Width, sliderRectancle.Height, graphics);

            using (Graphics bitmapGraphics = Graphics.FromImage(bitmap))
            {
                bitmapGraphics.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle rectangle = sliderRectancle;
                rectangle.X = 0;
                rectangle.Y = 0;
                rectangle.Width -= 1;

                using (SolidBrush backgroundBrush = new SolidBrush(Color.Transparent))
                {
                    bitmapGraphics.FillRectangle(backgroundBrush, rectangle);
                }

                using (GraphicsPath outerGraphicsPath = GetPath(rectangle, 4))
                {
                    using (LinearGradientBrush outerLinearGradientBrush = new LinearGradientBrush(
                        rectangle,
                        colorGradientBegin,
                        colorGradientEnd,
                        LinearGradientMode.Vertical))
                    {
                        bitmapGraphics.FillPath(outerLinearGradientBrush, outerGraphicsPath); //draw top bubble
                    }
                }

                Rectangle innerRectangle = rectangle;
                innerRectangle.Inflate(-1, 0);
                innerRectangle.Height = 5;

                using (GraphicsPath innerGraphicsPath = GetPath(innerRectangle, 4))
                {
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(
                        innerRectangle,
                        Color.FromArgb(255, Color.White),
                        Color.FromArgb(0, Color.White),
                        LinearGradientMode.Vertical))
                    {
                        //draw shapes
                        bitmapGraphics.FillPath(linearGradientBrush, innerGraphicsPath); //draw top bubble
                    }
                }
            }
            return bitmap;
        }
        /// <summary>
        /// Gets a GraphicsPath. 
        /// </summary>
        /// <param name="bounds">Rectangle structure that specifies the backgrounds location.</param>
        /// <param name="radius">The radius in the graphics path</param>
        /// <returns>the specified graphics path</returns>
        private static GraphicsPath GetPath(Rectangle bounds, int radius)
        {
            int x = bounds.X;
            int y = bounds.Y;
            int width = bounds.Width;
            int height = bounds.Height;
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(x, y, radius, radius, 180, 90);				                    //Upper left corner
            graphicsPath.AddArc(x + width - radius, y, radius, radius, 270, 90);			    //Upper right corner
            graphicsPath.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);//Lower right corner
            graphicsPath.AddArc(x, y + height - radius, radius, radius, 90, 90);			    //Lower left corner
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        #endregion
    }
}
