using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace BSE.Platten.Audio
{
    /// <summary>
    /// Represents a Windows <see cref="BSE.Platten.Audio.Trackbar"/> control contained in a StatusStrip.
    /// </summary>
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    [ToolboxBitmap(typeof(System.Windows.Forms.TrackBar))]
    public class ToolStripTrackBar : ToolStripControlHost
    {
        #region Events
        /// <summary>
        /// Occurs when the Value property of a TrackBar changes.
        /// </summary>
        [Description("Occurs when the Value property of a TrackBar changes.")]
        public event EventHandler<EventArgs> ValueChanged;
        /// <summary>
        /// Occurs when either a mouse action moves the TrackBar slider.
        /// </summary>
        [Description("Occurs when either a mouse action moves the TrackBar slider.")]
        public event EventHandler<EventArgs> Scroll;
        /// <summary>
        /// Occurs when the ThumbState on the TrackBar changes.
        /// </summary>
        [Description("Occurs when the ThumbState on the TrackBar changes.")]
        public event EventHandler<ThumbStateChangedEventArgs> ThumbStateChanged;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the TrackBar
        /// </summary>
        public TrackBar TrackBar
        {
            get { return Control as TrackBar; }
        }
        /// <summary>
        /// Gets or sets the displayed text on the trackbar.
        /// </summary>
        ///<value>
        /// Type: <see cref="System.String"/>
        /// </value>
        public new string Text
        {
            get { return TrackBar.Text; }
            set { TrackBar.Text = value; }
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
			get { return TrackBar.Maximum; }
			set { TrackBar.Maximum = value; }
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
			get { return TrackBar.Minimum; }
			set { TrackBar.Minimum = value; }
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
			get { return TrackBar.Value; }
			set { TrackBar.Value = value; }
		}
        /// <summary>
        /// Gets or sets the starting color of the gradient used in the Slider.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the starting color of the gradient used in the Slider.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.OverflowButtonGradientEnd")]
        public Color SliderGradientBegin
        {
            get { return TrackBar.SliderGradientBegin; }
            set { TrackBar.SliderGradientBegin = value; }
        }
         /// <summary>
        /// Gets or sets the end color of the gradient used in the Slider.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the end color of the gradient used in the Slider.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.OverflowButtonGradientBegin")]
        public Color SliderGradientEnd
        {
            get { return TrackBar.SliderGradientEnd; }
            set { TrackBar.SliderGradientEnd = value; }
        }
        /// <summary>
        /// Gets or sets the starting color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the starting color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.ToolStripGradientBegin")]
        public Color TrackLineGradientBegin
        {
            get { return TrackBar.TrackLineGradientBegin; }
            set { TrackBar.TrackLineGradientBegin = value; }
        }
        /// <summary>
        /// Gets or sets the end color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the end color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(ProfessionalColors), "System.Windows.Forms.ProfessionalColors.ToolStripGradientEnd")]
        public Color TrackLineGradientEnd
        {
            get { return TrackBar.TrackLineGradientEnd; }
            set { TrackBar.TrackLineGradientEnd = value; }
        }
        /// <summary>
        /// Gets or sets the tracker color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the tracker color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(Color), "System.Drawing.Color.Blue")]
        public Color TrackLine
        {
            get { return TrackBar.TrackLine; }
            set { TrackBar.TrackLine = value; }
        }
        /// <summary>
        /// Gets or sets the elapsed tracker color of the gradient used in the TrackLine.
        /// </summary>
        [Category("Behavior")]
        [Description("Gets or sets the elapsed tracker color of the gradient used in the TrackLine.")]
        [DefaultValue(typeof(Color), "System.Drawing.Color.Lime")]
        public Color ElapsedTrackLine
        {
            get { return TrackBar.ElapsedTrackLine; }
            set { TrackBar.ElapsedTrackLine = value; }
        }
        /// <summary>
        /// Gets the default margin of an item.
        /// </summary>
        protected override Padding DefaultMargin
        {
            get
            {
                if ((base.Owner != null) && (base.Owner is StatusStrip))
                {
                    return new Padding(1, 3, 1, 3);
                }
                return new Padding(1, 2, 1, 1);
            }
        }
        /// <summary>
        /// Gets the default size of the item.
        /// </summary>
        protected override Size DefaultSize
        {
            get { return new Size(200, 22); }
        }
        #endregion

        #region MethodsPublic
        /// <summary>
        /// Initializes a new instance of the ToolStripTrackBar class.
        /// </summary>
        public ToolStripTrackBar()
            : base(CreateControlInstance())
        {
        }
        /// <summary>
        /// Starts the slider on the TrackBar.
        /// </summary>
        public void Start()
		{
            if (this.TrackBar != null)
            {
                this.TrackBar.Start();
            }
		}
        /// <summary>
        /// Starts the slider on the TrackBar.
        /// </summary>
        /// <param name="strText">The displayed text of the TrackBar</param>
		public void Start(string strText)
		{
            if (this.TrackBar != null)
            {
                this.TrackBar.Start(strText);
            }
		}

        #endregion

        #region MethodsProtected
        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            TrackBar trackBar = control as TrackBar;
            if (trackBar != null)
            {
                trackBar.ValueChanged += new EventHandler<EventArgs>(TrackBarValueChanged);
                trackBar.Scroll += new EventHandler<EventArgs>(TrackBarScroll);
                trackBar.ThumbStateChanged += new EventHandler<ThumbStateChangedEventArgs>(TrackBarThumbStateChanged);
            }
        }
        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            TrackBar trackBar = control as TrackBar;
            if (trackBar != null)
            {
                trackBar.ValueChanged -= new EventHandler<EventArgs>(TrackBarValueChanged);
                trackBar.Scroll -= new EventHandler<EventArgs>(TrackBarScroll);
                trackBar.ThumbStateChanged -= new EventHandler<ThumbStateChangedEventArgs>(TrackBarThumbStateChanged);
            }
        }
        /// <summary>
        /// Raises the TrackBarScroll event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected void TrackBarScroll(object sender, EventArgs e)
        {
            if (this.Scroll != null)
            {
                this.Scroll(sender, e);
            }
        }
        /// <summary>
        /// Raises the TrackBarValueChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected void TrackBarValueChanged(object sender,EventArgs e)
        {
            if (this.ValueChanged != null)
            {
                this.ValueChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the TrackBarThumbStateChanged event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected void TrackBarThumbStateChanged(object sender, ThumbStateChangedEventArgs e)
        {
            if (this.ThumbStateChanged != null)
            {
                this.ThumbStateChanged(sender, e);
            }
        }
        /// <summary>
        /// Raises the EnabledChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            if (TrackBar != null)
            {
                TrackBar.Enabled = this.Enabled;
            }
            base.OnEnabledChanged(e);
        }
        // <summary>
        /// Raises the OwnerChanged event. 
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnOwnerChanged(EventArgs e)
        {
            if (base.Owner != null)
            {
                base.Owner.RendererChanged += new EventHandler(OwnerRendererChanged);
            }
            base.OnOwnerChanged(e);
        }
        #endregion

        #region MethodsPrivate
        
        private void OwnerRendererChanged(object sender, EventArgs e)
        {
            ToolStripProfessionalRenderer toolsTripRenderer = this.Owner.Renderer as ToolStripProfessionalRenderer;
            if (toolsTripRenderer != null)
            {
                BSE.Windows.Forms.ProfessionalColorTable colorTable = toolsTripRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
                if (colorTable != null)
                {
                    this.TrackBar.ForeColor = colorTable.ToolStripText;
                }
            }
        }
        
        private static Control CreateControlInstance()
        {
            TrackBar trackBar = new TrackBar();
            trackBar.Size = new Size(200, 22);

            return trackBar;
        }
       
        #endregion
    }
}
