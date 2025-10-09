using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BSE.Charts
{
    abstract class DrawCharts : IDrawCharts
    {
        #region FieldsPrivate

        private Chart m_parentCharts;

        #endregion

        #region Properties

        protected Chart ParentCharts
        {
            get { return this.m_parentCharts; }
            set { this.m_parentCharts = value; }
        }

        #endregion

        #region MethodsPublic

        public DrawCharts()
        {
        }

        public DrawCharts(Chart parentCharts) : this()
        {
            this.m_parentCharts = parentCharts;
        }

        public abstract void Draw(int Width, int Height, Rectangle rectangle, Graphics graphics, Graphics graphicsHitTest);

		public virtual int DrawLegend(Graphics graphics, Rectangle rectangle)
		{
			int iWidthLegend = 0;
			if (this.m_parentCharts.ShowLegend)
			{
				SizeF sizeValueTotal = graphics.MeasureString(this.GetValueTotal().ToString(), this.m_parentCharts.Font);
				int iWidthValue = (int)sizeValueTotal.Width;
				int iWidthText = (int)this.GetLegendTextSize(graphics).Width;

				iWidthLegend = this.m_parentCharts.LegendRectangle.Width
					+ this.m_parentCharts.LegendDistanceRectangleToValue
					+ iWidthValue
					+ this.m_parentCharts.LegendDistanceValueToLabel
					+ iWidthText;

				int iPositionY = (this.m_parentCharts.Height - (this.m_parentCharts.ChartItems.Count * this.m_parentCharts.Font.Height)) / 2;
				int iPositionX = this.m_parentCharts.Width - iWidthLegend;
				int iPositionValueX = iPositionX + this.m_parentCharts.LegendRectangle.Width + this.m_parentCharts.LegendDistanceRectangleToValue + iWidthValue;
				int iPositionTextX = iPositionValueX + this.m_parentCharts.LegendDistanceValueToLabel;
                
				IEnumerator enumerator = this.m_parentCharts.ChartItems.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ChartItem chartItem = (ChartItem)enumerator.Current;
                    SolidBrush brush;
                    if (chartItem.IsExpanded)
                    {
                        brush = new SolidBrush(chartItem.HighlightColor);
                    }
                    else
                    {
                        brush = new SolidBrush(chartItem.Color);
                    }
                    graphics.FillRectangle(brush, iPositionX, iPositionY, this.m_parentCharts.LegendRectangle.Width, this.m_parentCharts.LegendRectangle.Height);
                    brush.Dispose();

                    //draw border of the legend's rectangles
                    System.Windows.Forms.ControlPaint.DrawBorder(
                        graphics,
                        new Rectangle(iPositionX, iPositionY, this.m_parentCharts.LegendRectangle.Width, this.m_parentCharts.LegendRectangle.Height),
                        SystemColors.ActiveBorder,
                        System.Windows.Forms.ButtonBorderStyle.Solid);

                    //draw text of the legend's values
                    using (UseClearTypeGridFit clearTypeGridFit = new UseClearTypeGridFit(graphics))
                    {

                        using (SolidBrush textBrush = new SolidBrush(this.m_parentCharts.ForeColor))
                        {
                            graphics.DrawString(
                                chartItem.Value.ToString(),
                                this.m_parentCharts.Font,
                                textBrush,
                                iPositionValueX,
                                iPositionY,
                                this.m_parentCharts.LegendValueFormat);

                            //draw text of the legend's texts
                            graphics.DrawString(
                                chartItem.Text,
                                this.m_parentCharts.Font,
                                textBrush,
                                iPositionTextX,
                                iPositionY,
                                this.m_parentCharts.LegendTextFormat);

                        }
                    }
                    iPositionY += this.m_parentCharts.Font.Height + (int)this.m_parentCharts.Font.Height / 2;
                }
			}
			return iWidthLegend;
		}

        //Return bounding rectangle for entire chart.
        public virtual Rectangle GetChartRectangle(int Width, int Height)
        {
            return new Rectangle(0, 0, Width, Height);
        }

		public float GetValueTotal()
		{
			float fValueTotal = 0.0F;
			IEnumerator enumerator = this.m_parentCharts.ChartItems.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ChartItem chartItem = (ChartItem)enumerator.Current;
				fValueTotal += chartItem.Value;
			}

			return fValueTotal;
		}

        public abstract void DrawShape(Graphics graphics, Rectangle rectangle, Brush brush, ChartItem chartItem);
		public abstract void LayoutItems(Rectangle rectangle, float fTotalValue);
        public abstract void DrawEmptyChart(Graphics graphics, Rectangle rectangle);

        #endregion

        #region MethodsPrivate

		private SizeF GetLegendTextSize(Graphics graphics)
		{
			SizeF newTextSize = new SizeF(0, this.m_parentCharts.Font.Height);
			SizeF usedTextSize = new SizeF(0, this.m_parentCharts.Font.Height);

			IEnumerator enumerator = this.m_parentCharts.ChartItems.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ChartItem chartItem = (ChartItem)enumerator.Current;
				newTextSize = graphics.MeasureString(chartItem.Text, this.m_parentCharts.Font);
				if (newTextSize.Width > usedTextSize.Width)
				{
					usedTextSize = newTextSize;
				}
			}
			return usedTextSize;
		}

        #endregion
    }
}
