using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
	[Designer(typeof(XPanderListDesigner)),
	DesignTimeVisibleAttribute(true)]
	[ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
	public partial class XPanderList : ScrollableControl, IIndex
	{
		#region Constants

        private const int m_iMarginTop = 10;
        private const int m_iMarginLeft = 8;

		private const int m_iVerticalSpacing = 14;      //Y gap between XPander controls
		private static readonly Color m_colorLightBackColor = Color.FromArgb(123, 162, 239);
		private static readonly Color m_colorDarkBackColor = Color.FromArgb(99, 117, 222);

		#endregion
		
		#region FieldsPrivate

        private BorderStyle m_borderStyle;
        private Color m_BackColorLight = m_colorLightBackColor;
		private Color m_BackColorDark  = m_colorDarkBackColor;
		private bool m_bAntiAlias = false;
        private XPanderCollection m_xpanderCollection;

		#endregion

		#region Properties

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public XPanderCollection XPanders
        {
            get
            {
                return this.m_xpanderCollection;
            }
        }

        [Description("Margin-Top for the first XPander")]
        [Browsable(false)]
        public int MarginTop
        {
            get { return m_iMarginTop; }
        }

        [Description("Margin-Left for the XPanders")]
        [Browsable(false)]
        public int MarginLeft
        {
            get { return m_iMarginLeft; }
        }

		[Description("Quality of drawing"),
		DefaultValue(true),
		Category("Appearance")]
		public bool AntiAliasing
		{
			get {return this.m_bAntiAlias;}
			set
			{
				this.m_bAntiAlias = value;
				IEnumerator enumerator = this.XPanders.GetEnumerator();
				while (enumerator.MoveNext())
				{
					BSE.Windows.Forms.XPander xpander = (BSE.Windows.Forms.XPander)enumerator.Current;
					xpander.AntiAliasing = this.m_bAntiAlias;
				}
                Invalidate();
			}
		}

		[Description("Light color used in gradient for background."),
		DefaultValue("123,162,239"),
		Category("Appearance")]
		public Color BackColorLight
		{
			get {return this.m_BackColorLight;}
			set 
			{
				this.m_BackColorLight = value;
				Invalidate();
			}
		}

		[Description("Dark color used in gradient for background."),
		DefaultValue("99,117,222"),
		Category("Appearance")]
		public Color BackColorDark
		{
			get {return this.m_BackColorDark;}
			set 
			{
				this.m_BackColorDark = value;
				Invalidate();
			}
		}

        [Description("Specifies the border style for a control."),
        DefaultValue(System.Windows.Forms.BorderStyle.None),
        Category("Appearance")]
        public BorderStyle BorderStyle
        {
            get { return this.m_borderStyle; }
            set
            {
                if (this.m_borderStyle != value)
                {
                    if (!Enum.IsDefined(typeof(BorderStyle), value))
                    {
                        throw new InvalidEnumArgumentException("value", (int)value, typeof(BorderStyle));
                    }
                    this.m_borderStyle = value;
                    UpdateStyles();
                }
            }
        }

		#endregion

		#region MethodsPublic

		public XPanderList()
		{
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, false);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.m_xpanderCollection = new XPanderCollection(this);

            this.AntiAliasing = true;
            this.BackColor = this.m_BackColorDark;
            this.AutoScroll = true;
		}

		public int GetIndex()
		{
            return this.Controls.Count;
		}
        
        public int GetTopPosition()
        {
            int iPositionMax = this.MarginTop;
            int iPositionY = 0;

            //The next top position is the highest top value + that controls height, with a
            //little vertical spacing thrown in for good measure
            IEnumerator enumerator = this.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XPander xPander = (XPander)enumerator.Current;
                iPositionY = xPander.Top + xPander.Height;
                if (iPositionY > iPositionMax)
                {
                    iPositionMax = iPositionY;
                }
            }
            if (iPositionMax != this.MarginTop)
            {
                iPositionMax += m_iVerticalSpacing;
            }
            return iPositionMax;
        }

		#endregion
		
		#region MethodsProtected

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			//Draw gradient background
			Rectangle rc = new Rectangle(0, 0, this.Width, this.Height);
			LinearGradientBrush b = new LinearGradientBrush(
				rc,
				this.m_BackColorLight,
				this.m_BackColorDark,
				LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(b, rc);
		}

		protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
		{
            base.OnControlAdded(e);

            //We'll only keep track of XPander controls in our list
            BSE.Windows.Forms.XPander xPander = e.Control as BSE.Windows.Forms.XPander;
            if (xPander != null)
            {
                xPander.XPanderCollapsed += new BSE.Windows.Forms.XPander.XPanderCollapsedEventHandler(this.xpander_XPanderCollapsed);
                xPander.XPanderExpanded += new BSE.Windows.Forms.XPander.XPanderExpandedEventHandler(this.xpander_XPanderExpanded);
            }
            else
            {
                throw new InvalidOperationException("Can only add BSE.Windows.Forms.XPander");
            }
		}

		protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
		{
            BSE.Windows.Forms.XPander xPander = e.Control as BSE.Windows.Forms.XPander;
            if (xPander != null)
            {
                Control control;
                int iPreviosTopPosition = xPander.Top;
			    int iNewTopPosition = 0;
                IEnumerator enumerator = this.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    control = (Control)enumerator.Current;
                    if (control.Top > iPreviosTopPosition)
                    {
                        iNewTopPosition = iPreviosTopPosition;
                        iPreviosTopPosition = control.Top;
                        control.Top = iNewTopPosition;
                    }
                }
                xPander.XPanderCollapsed -= new BSE.Windows.Forms.XPander.XPanderCollapsedEventHandler(this.xpander_XPanderCollapsed);
                xPander.XPanderExpanded -= new BSE.Windows.Forms.XPander.XPanderExpandedEventHandler(this.xpander_XPanderExpanded);
            }
		}

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle &= (~NativeMethods.WS_EX_CLIENTEDGE);
                createParams.Style &= (~NativeMethods.WS_BORDER);

                switch (m_borderStyle)
                {
                    case BorderStyle.Fixed3D:
                        createParams.ExStyle |= NativeMethods.WS_EX_CLIENTEDGE;
                        break;
                    case BorderStyle.FixedSingle:
                        createParams.Style |= NativeMethods.WS_BORDER;
                        break;
                }
                return createParams;
            }
        }

		#endregion

		#region MethodsPrivate

		private void xpander_XPanderExpanded(XPander xpander)
		{
			Control control;
			IEnumerator enumerator = this.Controls.GetEnumerator();
			while (enumerator.MoveNext())
			{
				control = (Control)enumerator.Current;
				if (control.Top > xpander.Top)
				{
					control.Top += xpander.ExpandedHeight - xpander.CaptionHeight;
				}
			}
		}

		private void xpander_XPanderCollapsed(XPander xpander)
		{
            Control control;
			IEnumerator enumerator = this.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                control = (Control)enumerator.Current;
                if (control.Top > xpander.Top)
                {
                    control.Top -= xpander.ExpandedHeight - xpander.CaptionHeight;
                }
            }
		}
		
		#endregion

        #region NativeMethods

        internal class NativeMethods
        {
            public const int WS_EX_CLIENTEDGE = unchecked((int)0x00000200);
            public const int WS_BORDER = unchecked((int)0x00800000);
        }

        #endregion

    }

    #region class XPanders

	public class XPanderCollection : CollectionBase
	{
		#region FieldsPrivate

		private XPanderList m_xpanderList;

		#endregion

		#region Constructor

		internal XPanderCollection(XPanderList xpanderList)
		{
			this.m_xpanderList = xpanderList;
		}

		#endregion

		#region Properties

		public XPander this[int iIndex]
		{
			get	{ return (XPander)this.m_xpanderList.Controls[iIndex]; }
		}

		#endregion

		#region MethodsPublic

		public bool Contains(XPander xpander)
		{
			return this.m_xpanderList.Controls.Contains(xpander);
		}

		public XPander Add(XPander xpander)
		{
			this.m_xpanderList.Controls.Add(xpander);
			return xpander;
		}

		public void Remove(XPander xpander)
		{
			this.m_xpanderList.Controls.Remove(xpander);
		}

		#endregion
	}

    #endregion

    #region class XPanderListDesigner

    internal class XPanderListDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        #region Konstanten

        private const int m_iMargingLeft = 8;

        #endregion

        #region FieldsPrivate

        private Pen m_borderPen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark));
        private XPanderList m_xpanderList;

        #endregion

        #region MethodsPublic

        public XPanderListDesigner()
        {
            this.m_borderPen.DashStyle = DashStyle.Dash;
        }

        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.m_xpanderList = (XPanderList)this.Control;

            //Disable the autoscroll feature for the control during design time.  The control
            //itself sets this property to true when it initializes at run time.  Trying to position
            //controls in this control with the autoscroll property set to True is problematic.
            this.m_xpanderList.AutoScroll = false;
        }

        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                System.ComponentModel.Design.DesignerVerbCollection designerVerbCollection
                    = new System.ComponentModel.Design.DesignerVerbCollection();

                // Verb to add XPander
                designerVerbCollection.Add(new System.ComponentModel.Design.DesignerVerb("&Add XPander", new EventHandler(OnAddXPander)));

                return designerVerbCollection;
            }
        }

        #endregion

        #region MethodsProtected

        protected override void OnPaintAdornments(PaintEventArgs e)
        {
            base.OnPaintAdornments(e);
            e.Graphics.DrawRectangle(this.m_borderPen, 0, 0, this.m_xpanderList.Width - 2, this.m_xpanderList.Height - 2);
        }

        #endregion

        #region MethodsPrivate

        private void OnAddXPander(object sender, System.EventArgs e)
        {
            System.ComponentModel.Design.IDesignerHost designerHost
                = (System.ComponentModel.Design.IDesignerHost)GetService(typeof(System.ComponentModel.Design.IDesignerHost));

            // Add a new XPander to the collection
            System.ComponentModel.Design.DesignerTransaction designerTransaction = designerHost.CreateTransaction();
            XPander xPander = (XPander)designerHost.CreateComponent(typeof(XPander));
            xPander.Left = this.m_xpanderList.MarginLeft;
            xPander.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            xPander.Width = this.m_xpanderList.Width - 2 * this.m_xpanderList.MarginLeft;
            xPander.Index = this.m_xpanderList.GetIndex();
            xPander.Top = this.m_xpanderList.GetTopPosition();
            xPander.Text = xPander.Name;
            xPander.AntiAliasing = this.m_xpanderList.AntiAliasing;
            xPander.Parent = this.m_xpanderList;
            designerTransaction.Commit();
        }

        #endregion

    }

    #endregion
}
