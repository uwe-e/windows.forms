using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BSE.Charts
{
	#region Class Charts

	[Designer(typeof(ChartsDesigner)),
	DesignTimeVisibleAttribute(true)]
	[ToolboxBitmap(typeof(Chart))]
	public partial class Chart : ScrollableControl, IIndex
    {
        #region Konstanten

        //How many pixels a chart item expands.
        public static Point ExpandSize = new Point(10,0);
        //Size of 3D shadow.
        public static Point ShadowSize = new Point(3,3);
		private const int m_iLegendDistanceRectangleToValue = 5;
		private const int m_iLegendDistanceValueToLabel = 5;

        #endregion

		#region Events

		public event ChartItemClickEventHandler ChartItemClick;

		#endregion

		#region FieldsPrivate

		private IDrawCharts m_drawCharts;
        private ChartItemCollection m_chartItems;
		private bool m_bShowToolTip;
		private bool m_bShowLegend;
		private Bitmap m_bmpHitTest;
        private Color m_selectedColor;

        #endregion

        #region Properties

        [RefreshProperties(RefreshProperties.Repaint),
        Category("Collections"),
        Browsable(true),
        Description("Collection containing all the ChartItems for the chart."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor(typeof(ChartItemCollectionEditor), typeof(UITypeEditor))]
        public ChartItemCollection ChartItems
        {
            get { return m_chartItems; }
        }

		[Description("Set tooltips on every chartitem"),
		DefaultValue(false),
		Category("Appearance")]
		public bool ShowToolTip
		{
			get { return this.m_bShowToolTip; }
			set { this.m_bShowToolTip = value; 	}
		}

		[Description("Show the chart legend"),
		DefaultValue(false),
		Category("Appearance")]
		public bool ShowLegend
		{
			get { return this.m_bShowLegend; }
			set
			{
				this.m_bShowLegend = value;
				this.m_picCharts.Invalidate();
			}
		}

		internal Size LegendRectangle
		{
			get { return new Size(this.Font.Height,this.Font.Height); }
		}

		internal int LegendDistanceRectangleToValue
		{
			get { return m_iLegendDistanceRectangleToValue; }
		}

		internal int LegendDistanceValueToLabel
		{
			get { return m_iLegendDistanceValueToLabel; }
		}

		internal StringFormat LegendValueFormat
		{
			get
			{
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Far;
				return stringFormat;
			}
		}

		internal StringFormat LegendTextFormat
		{
			get
			{
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Near;
				return stringFormat;
			}
		}

        #endregion

        #region MethodsPublic

        public Chart()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            this.m_drawCharts = new DrawPie(this);
            this.m_chartItems = new ChartItemCollection(this);
            this.m_picCharts.BackColor = Color.Transparent;
			this.m_bShowToolTip = false;
			this.m_bShowLegend = false;
        }

        public int GetIndex()
        {
			return GetIndex(0);
        }

        #endregion

        #region MethodsProtected

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics graphics = e.Graphics;
            using (UseAntiAlias antiAlias = new UseAntiAlias(graphics))
            {
                float fValueTotal = this.m_drawCharts.GetValueTotal();
                //Border space around chart.
                int iBorderSpace = ExpandSize.X + ShadowSize.X + 1;
                Rectangle rectangle = new Rectangle(
                    (this.Width / 2) - (this.Height / 2) + iBorderSpace,
                    iBorderSpace,
                    this.Height - iBorderSpace * 2,
                    this.Height - iBorderSpace * 2);

                this.m_drawCharts.LayoutItems(rectangle, fValueTotal);

                if (this.m_chartItems.Count == 0)
                {
                    this.m_drawCharts.DrawEmptyChart(graphics, rectangle);
                }
                else
                {
                    //Drawing surface for hit testing
                    Graphics hitTestGraphics = Graphics.FromImage(this.m_bmpHitTest);
                    this.m_drawCharts.Draw(this.Width, this.Height, rectangle, e.Graphics, hitTestGraphics);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.m_picCharts.Size = this.Size;
            this.m_picCharts.Image = new Bitmap(this.Width, this.Height);
            this.m_bmpHitTest = new Bitmap(this.Width, this.Height);
            this.Invalidate();
        }

		protected virtual void OnChartClick(object sender, ChartItemClickEventArgs e)
		{
			if (this.ChartItemClick != null)
			{
				this.ChartItemClick(sender, e);
			}
		}

        #endregion

        #region MethodsPrivate

        private void ChartsPictureMouseMove(object sender, MouseEventArgs e)
        {
            if (this.m_bmpHitTest != null)
            {
                Color selectedcolor = this.m_bmpHitTest.GetPixel(e.X, e.Y);
                if (selectedcolor != this.m_selectedColor)
                {
                    this.m_selectedColor = selectedcolor;
                    IEnumerator enumerator = this.m_chartItems.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ChartItem chartItem = (ChartItem)enumerator.Current;
                        if (chartItem.Color.ToArgb() == selectedcolor.ToArgb())
                        {
                            this.m_tltCharts.SetToolTip(this.m_picCharts, chartItem.Text);
                            this.m_tltCharts.Active = this.m_bShowToolTip;
                        }
                    }
                }
            }
        }

        private void ChartsPictureClick(object sender, EventArgs e)
        {
            ChartItem chartItem = HitTest();
            if (chartItem != null)
            {
                if (chartItem.IsExpanded)
                {
					chartItem.IsExpanded = false;
				}
				else
				{
					//Resetting the isexpanded properties of each chartitem
					foreach (ChartItem item in this.m_chartItems)
					{
						item.IsExpanded = false;
					}
					chartItem.IsExpanded = true;
                }
				this.m_picCharts.Invalidate();
				OnChartClick(sender,new ChartItemClickEventArgs(chartItem));
            }
        }

        //Use colors on memory bitmap for hit testing. That allows 
        //precise hit testing for pie shapes
        private ChartItem HitTest()
        {
            //Get cursor position relative to the chart
            Point point = m_picCharts.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
            Color color = this.m_bmpHitTest.GetPixel(point.X, point.Y);

            //Loop through each item and see if matching color
            ChartItem selectedChartItem = null;
            IEnumerator enumerator = this.m_chartItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ChartItem chartItem = (ChartItem)enumerator.Current;
                if (chartItem.Color.ToArgb() == color.ToArgb())
                {
                    selectedChartItem = chartItem;
                    break;
                }
            }
            return selectedChartItem;
        }

        private int GetIndex(int iIndex)
        {
            IEnumerator enumerator = this.m_chartItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ChartItem chartItem = (ChartItem)enumerator.Current;
                if (chartItem.Index == iIndex)
                {
                    return GetIndex(iIndex + 1);
                }
            }
			return iIndex;
        }

        #endregion

	}

	#endregion

	#region Class ChartsDesigner

	internal class ChartsDesigner : System.Windows.Forms.Design.ParentControlDesigner
	{
		#region FieldsPrivate

		private Chart m_charts;

		#endregion
			
		#region MethodsPublic

		public ChartsDesigner()
		{

		}

		public override void Initialize(System.ComponentModel.IComponent component)
		{
			base.Initialize(component);
			this.m_charts = (Chart)this.Control;
		}

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				// Create action list collection
				DesignerActionListCollection actionLists = new DesignerActionListCollection();

				// Add custom action list
				actionLists.Add(new ChartsDesignerActionList(this.Component));

				// Return to the designer action service
				return actionLists;
			}
		}

		#endregion

		#region MethodsProtected

		protected override void OnPaintAdornments(PaintEventArgs e)
		{
			base.OnPaintAdornments(e);
		}

		#endregion
	}

	#endregion

	#region Class ChartsDesignerActionList

	internal class ChartsDesignerActionList : DesignerActionList, IIndex
	{
		public ChartsDesignerActionList(System.ComponentModel.IComponent component)
	        : base(component)
	    {
	        // Automatically display smart tag panel when
	        // design-time component is dropped onto the
	        // Windows Forms Designer
	        this.AutoShow = true;
	    }

		public int GetIndex()
		{
			return this.Charts.GetIndex();
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			// Create list to store designer action items
			DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

			actionItems.Add(
			  new DesignerActionMethodItem(
				this,
				"ToggleDockStyle",
				GetDockStyleText(),
				"Design",
				"Dock or undock this control in it's parent container.",
				true));

			actionItems.Add(
			  new DesignerActionPropertyItem(
				"ChartItems",
				"Edit ChartItems",
				GetCategory(this.Charts, "ChartItems")));

            actionItems.Add(
              new DesignerActionPropertyItem(
                "ShowToolTip",
                "Show ToolTips",
                GetCategory(this.Charts, "ShowToolTip")));

            actionItems.Add(
             new DesignerActionPropertyItem(
               "ShowLegend",
               "Show Legend",
               GetCategory(this.Charts, "ShowLegend")));

			return actionItems;
		}

		// Dock/Undock designer action method implementation
		//[CategoryAttribute("Design")]
		//[DescriptionAttribute("Dock/Undock in parent container.")]
		//[DisplayNameAttribute("Dock/Undock in parent container")]
		public void ToggleDockStyle()
		{
			// Toggle chart control's Dock property
			if (this.Charts.Dock != DockStyle.Fill)
			{
				SetProperty("Dock", DockStyle.Fill);
			}
			else
			{
				SetProperty("Dock", DockStyle.None);
			}
		}

		[Editor(typeof(ChartItemCollectionEditor), typeof(UITypeEditor))]
		public Chart.ChartItemCollection ChartItems
		{
			get { return this.Charts.ChartItems; }
		}

        public bool ShowToolTip
        {
            get { return this.Charts.ShowToolTip; }
            set { SetProperty("ShowToolTip", value); }
        }

        public bool ShowLegend
        {
            get { return this.Charts.ShowLegend; }
            set { SetProperty("ShowLegend", value); }
        }

		// Helper method that returns an appropriate
		// display name for the Dock/Undock property,
		// based on the ClockControl's current Dock 
		// property value
		private string GetDockStyleText()
		{
			if (this.Charts.Dock == DockStyle.Fill)
			{
				return "Undock in parent container";
			}
			else
			{
				return "Dock in parent container";
			}
		}

		private Chart Charts
		{
			get { return (Chart)this.Component; }
		}

		// Helper method to safely set a component’s property
		private void SetProperty(string propertyName, object value)
		{
			// Get property
			System.ComponentModel.PropertyDescriptor property
				= System.ComponentModel.TypeDescriptor.GetProperties(this.Charts)[propertyName];
			// Set property value
			property.SetValue(this.Charts, value);
		}

		// Helper method to return the Category string from a
		// CategoryAttribute assigned to a property exposed by 
		//the specified object
		private string GetCategory(object source, string propertyName)
		{
			System.Reflection.PropertyInfo property = source.GetType().GetProperty(propertyName);
			CategoryAttribute attribute = (CategoryAttribute)property.GetCustomAttributes(typeof(CategoryAttribute), false)[0];
			if (attribute == null) return null;
			return attribute.Category;
		}
	}

	#endregion
}
