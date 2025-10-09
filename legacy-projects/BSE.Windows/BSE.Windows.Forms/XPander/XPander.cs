using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace BSE.Windows.Forms
{
    [DesignTimeVisible(false)]
    public partial class XPander : ScrollableControl
	{
		#region FieldsPublic
		
		//Fired when the XPander is completely collapsed
		public delegate void XPanderCollapsedEventHandler(XPander x);
		public event XPanderCollapsedEventHandler XPanderCollapsed;

		public delegate void XPanderExpandedEventHandler(XPander x);
        public event XPanderExpandedEventHandler XPanderExpanded;
		
		#endregion
		
		#region FieldsPrivate

		private int m_CaptionHeight = 25;
		private bool m_bAntiAlias = false;
		private int m_iIndex = 0;
		private Color m_CaptionTextColor = Color.FromArgb(33, 93, 198);
		private Color m_CaptionTextHighlightColor = Color.FromArgb(66, 142, 255);
		private Font m_CaptionFont = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
		private Color m_CaptionColor = Color.FromArgb(198, 210, 248);
		private bool m_Expanded = true;
		private bool m_IsCaptionHighlighted = false;
		private int m_Height;
		private Bitmap[] m_Images = new Bitmap[4];

		#endregion

		#region Properties

		[Description("Quality of drawing"),
		DefaultValue(true),
		Category("Appearance")]
		public bool AntiAliasing
		{
			get {return this.m_bAntiAlias;}
			set
			{
				this.m_bAntiAlias = value;
				Invalidate();
			}
		}

		[Description("Height of caption."),
		DefaultValue(25),
		Category("Appearance")]
		public int CaptionHeight
		{
			get {return this.m_CaptionHeight;}
			set 
			{
				this.m_CaptionHeight = value;
				Invalidate();
			}
		}

		[Description("Caption color."),
		DefaultValue("180,190,240"),
		Category("Appearance")]
		public Color CaptionColor
		{
			get {return this.m_CaptionColor;}
			set 
			{
				this.m_CaptionColor = value;
				Invalidate();
			}
		}

		[Description("Caption text color."),
		DefaultValue("33,93,198"),
		Category("Appearance")]
		public Color CaptionTextColor
		{
			get {return this.m_CaptionTextColor;}
			set 
			{
				this.m_CaptionTextColor = value;
				Invalidate();
			}
		}

		[Description("Caption text color when the mouse is hovering over it."),
		DefaultValue("66, 142, 255"),
		Category("Appearance")]
		public Color CaptionTextHighlightColor
		{
			get {return this.m_CaptionTextHighlightColor;}
			set 
			{
				this.m_CaptionTextHighlightColor = value;
				Invalidate();
			}
		}

		[Description("Caption font."),
		Category("Appearance")]
		public Font CaptionFont
		{
			get {return this.m_CaptionFont;}
			set 
			{
				this.m_CaptionFont = value;
				Invalidate();
			}
		}

		public bool IsExpanded
		{
			get {return this.m_Expanded;}
		}

		[Browsable(false),
		DesignOnly(true)]
		public int ExpandedHeight
		{
			get {return this.m_Height;}
			set {this.m_Height = value;}
		}

		#endregion
		
		#region MethodsPublic

		public XPander()
		{
			InitializeComponent();

			this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.ContainerControl, true);

            this.m_Images[0] = global::BSE.Windows.Forms.Properties.Resources.Collapse;
            this.m_Images[1] = global::BSE.Windows.Forms.Properties.Resources.Collapse_h;
            this.m_Images[2] = global::BSE.Windows.Forms.Properties.Resources.Expand;
            this.m_Images[3] = global::BSE.Windows.Forms.Properties.Resources.Expand_h;

            this.AntiAliasing = true;
            this.DockPadding.Top = this.m_CaptionHeight;
			
		}

		public void Expand()
		{
			if (!this.m_Expanded)
			{
				this.m_Expanded = true;
				ChangeHeight();
			}
		}
		
		public void Collapse()
		{
			if (this.m_Expanded)
			{
				this.m_Expanded = false;
				ChangeHeight();
			}
		}

		/// <summary>
		/// Gets the zero-based index of the item within the XPanderPanelList control.
		/// </summary>
		public int Index
		{
			get {return this.m_iIndex;}
			set {this.m_iIndex = value;}
		}
		
		#endregion

		#region MethodsProtected

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rc = new Rectangle(0, 0, this.Width, CaptionHeight);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.White, CaptionColor, LinearGradientMode.Horizontal))
            {
                //Now draw the caption areas with the rounded corners at the top
                e.Graphics.FillRectangle(brush, rc);
            }
			
            Size fontSize = e.Graphics.MeasureString(this.Text, CaptionFont).ToSize();
            
            if (this.m_bAntiAlias)
			{
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				e.Graphics.TextRenderingHint  = System.Drawing.Text.TextRenderingHint.AntiAlias;
			}

			//Draw the outline around the work area
			if (this.Height > m_CaptionHeight)
			{
                Pen pen = new Pen(Color.FromKnownColor(KnownColor.Window));
                e.Graphics.DrawLine(pen,
					0, this.CaptionHeight, 0, this.Height);
				e.Graphics.DrawLine(pen,
					this.Width - 1, this.CaptionHeight, this.Width - 1, this.Height);
				e.Graphics.DrawLine(pen,
					0, this.Height - 1, this.Width - 1, this.Height - 1);
                pen.Dispose();
			}

			//Caption text.
			if (m_IsCaptionHighlighted)
			{
                e.Graphics.DrawString(this.Text, CaptionFont, new SolidBrush(m_CaptionTextHighlightColor),
                    (float)(10), (float)((this.CaptionHeight - 2 - fontSize.Height) / 2));
			}
			else
			{
                e.Graphics.DrawString(this.Text, CaptionFont, new SolidBrush(m_CaptionTextColor),
                    (float)(10), (float)((this.CaptionHeight - 2 - fontSize.Height) / 2));
			}

			//Expand / Collapse Icon
			if (m_Expanded)
			{
				if (m_IsCaptionHighlighted)
				{
					e.Graphics.DrawImage(m_Images[1], this.Width - m_Images[0].Width - 8, 4);
				}
				else
				{
					e.Graphics.DrawImage(m_Images[0], this.Width - m_Images[0].Width - 8, 4);
				}
			}
			else
			{
				if (m_IsCaptionHighlighted)
				{
					e.Graphics.DrawImage(m_Images[3], this.Width - m_Images[1].Width - 8, 3);
				}
				else
				{
					e.Graphics.DrawImage(m_Images[2], this.Width - m_Images[1].Width - 8, 3);
				}
			}
			e.Graphics.TextRenderingHint  = System.Drawing.Text.TextRenderingHint.SystemDefault;
		}

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.m_IsCaptionHighlighted = false;
            this.Invalidate();
        }

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			//Change cursor to hand when over caption area.
			if (e.Y <= this.CaptionHeight)
			{
				Cursor.Current = Cursors.Hand;
				this.m_IsCaptionHighlighted = true;
			}
			else
			{
				Cursor.Current = Cursors.Default;
				this.m_IsCaptionHighlighted = false;
			}
			Invalidate();
		}
		
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			//Don't do anything if did not click on caption.
			if (e.Y > this.CaptionHeight)
			{
				return;
			}

			//Toggle expanded flag.
			this.m_Expanded = !this.m_Expanded;

			//Expand or collapse the control based on its current state
			ChangeHeight();
			this.Refresh();
		}
		
		#endregion

		#region MethodsPrivate

		private void ChangeHeight()
		{
			if (!this.m_Expanded)
			{
				//Remember height so we can restore it later.
				this.m_Height = this.Height;

				//Set the new height and let others know we have been collapsed
				this.Height = this.CaptionHeight;
				//RaiseEvent XPanderCollapsed(Me)
				//event XPanderCollapsed(this);
                if (this.XPanderCollapsed != null)
                {
                    this.XPanderCollapsed(this);
                }
			}
			else
			{
				this.Height = this.m_Height;
				//RaiseEvent XPanderExpanded(Me)
                if (this.XPanderExpanded != null)
                {
                    this.XPanderExpanded(this);
                }
			}
		}

		#endregion
		
	}

}
