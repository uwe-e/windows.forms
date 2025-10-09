using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BSE.Charts
{
    class DrawPie : DrawCharts
    {
        #region FieldsPrivate

        #endregion

        #region MethodsPublic

        public DrawPie(Chart parentCharts)
        {
            this.ParentCharts = parentCharts;
        }

		public override void LayoutItems(Rectangle rectangle, float fTotalValue)
        {
            if ((rectangle.Width <= 1) || (rectangle.Height <= 1))
            {
                return;
            }

            float fStartAngle = 0.0F;
            float fSweepAngle = 0.0F;

            IEnumerator enumerator = this.ParentCharts.ChartItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ChartItem chartItem = (ChartItem)enumerator.Current;
                
                //Calculate the sweep angle for this item.
				fSweepAngle = (chartItem.Value * 360) / fTotalValue;
                
                //Calculate the offset when this item is expanded.
                Point shiftPoint = GetPoint(fStartAngle + fSweepAngle / 2, rectangle.Width, rectangle.Height);

                //Relative to center of chart.
                shiftPoint.X -= (rectangle.Width / 2);
                shiftPoint.Y -= (rectangle.Height / 2);

                //Now convert to max offset.
                float x = (float)Chart.ExpandSize.X / Math.Max(Math.Abs(shiftPoint.X), Math.Abs(shiftPoint.Y));

                shiftPoint.X = (int)((float)shiftPoint.X * x);
                shiftPoint.Y = (int)((float)shiftPoint.Y * x);
				chartItem.ExpandingOffset = shiftPoint;

                //Calculate center of pie slice.
                Point centerPoint = GetPoint(fStartAngle + fSweepAngle / 2, rectangle.Width, rectangle.Height);

                centerPoint.X = (((rectangle.Right - rectangle.Left) / 2 + centerPoint.X) / 2) + rectangle.Left;
                centerPoint.Y = (((rectangle.Bottom - rectangle.Top) / 2 + centerPoint.Y) / 2);
                //item.CenterPoint = center;

                //Starting position and sweep size, both in degrees.
                chartItem.StartAngle = fStartAngle;
                chartItem.SweepAngle = fSweepAngle;

                fStartAngle += fSweepAngle;
            }
        }

        public override void Draw(int Width, int Height, Rectangle rectangle, Graphics graphics, Graphics graphicsHitTest)
        {
            //Don't try drawing anything if area is too small.
            if ((rectangle.Width <= 1) || (rectangle.Height <= 1))
            {
                return;
            }

            Rectangle rectangleShape;
            Rectangle rectangleShadow;
            int iWidthLegend = 0;

            if (this.ParentCharts.ShowLegend)
            {
                iWidthLegend = DrawLegend(graphics, rectangle);
            }

            IEnumerator enumerator = null;
            enumerator = this.ParentCharts.ChartItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ChartItem chartItem = (ChartItem)enumerator.Current;

                rectangleShadow = new Rectangle();
                rectangleShadow.Y = rectangle.Location.Y + (iWidthLegend / 2);
                rectangleShadow.X = rectangle.Location.X;
                rectangleShadow.Width = rectangle.Width - iWidthLegend;
                rectangleShadow.Height = rectangle.Width - iWidthLegend;

                rectangleShadow.Offset(Chart.ShadowSize);
                if (chartItem.IsExpanded)
                {
                    rectangleShadow.Offset(chartItem.ExpandingOffset);
                }

                SolidBrush brush = new SolidBrush(chartItem.ShadowColor);
                DrawShape(graphics, rectangleShadow, brush, chartItem);
                brush.Dispose();
            }

            enumerator = this.ParentCharts.ChartItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ChartItem chartItem = (ChartItem)enumerator.Current;

                rectangleShape = new Rectangle();
                rectangleShape.Y = rectangle.Location.Y + (iWidthLegend / 2);
                rectangleShape.X = rectangle.Location.X;
                rectangleShape.Width = rectangle.Width - iWidthLegend;
                rectangleShape.Height = rectangle.Height - iWidthLegend;

                if (chartItem.IsExpanded)
                {
                    rectangleShape.Offset(chartItem.ExpandingOffset);
                }

                Brush brushShape = null;
                if (chartItem.MouseOver)
                {
                    brushShape = new SolidBrush(chartItem.HighlightColor);
                }
                else
                {
                    brushShape = new LinearGradientBrush(rectangleShape, chartItem.Color, chartItem.HighlightColor, LinearGradientMode.Horizontal);
                }
                DrawShape(graphics, rectangleShape, brushShape, chartItem);
                DrawShape(graphicsHitTest, rectangleShape, new SolidBrush(chartItem.Color), chartItem);
                brushShape.Dispose();
            }
        }

        public override void DrawShape(Graphics graphics, Rectangle rectangle, Brush brush, ChartItem chartItem)
        {
            //Make sure we have a valid area to draw on
            if ((rectangle.Width > 1) && (rectangle.Height > 1))
            {
                graphics.FillPie(brush, rectangle, chartItem.StartAngle, chartItem.SweepAngle);
            }
        }

        public override void DrawEmptyChart(Graphics graphics, Rectangle rectangle)
        {
            if ((rectangle.Width > 1) && (rectangle.Height > 1))
            {
                graphics.DrawEllipse(new Pen(SystemColors.ControlDarkDark), rectangle);
            }
        }

        #endregion

        #region MethodsPrivate

        //Return point on circle edge given an angle.
        private static Point GetPoint(float fAngle, int iWidth, int iHeight)
        {
            Point pointTopCenter = new Point((iWidth / 2), 0);
            double rad = Math.PI * 2 * fAngle / 360;
            Point point = new Point();
            point.X = (int)((Math.Cos(rad) * pointTopCenter.X - Math.Sin(rad) * pointTopCenter.Y) + iWidth / 2);
            point.Y = (int)((Math.Sin(rad) * pointTopCenter.X + Math.Cos(rad) * pointTopCenter.Y) + iHeight / 2);

            return point;
        }

        #endregion
    }
}
