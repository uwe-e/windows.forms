using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BSE.Charts
{
    interface IDrawCharts
    {
        void Draw(int Width, int Height, Rectangle rectangle, Graphics graphics, Graphics HitTest);
        void DrawEmptyChart(Graphics graphics, Rectangle rectangle);
		void DrawShape(Graphics graphics, Rectangle rectangle, Brush b, ChartItem chartItem);
		int DrawLegend(Graphics graphics, Rectangle rectangle);
		void LayoutItems(Rectangle rectangle, float fTotalValue);
        Rectangle GetChartRectangle(int iWidth, int iHeight);
		float GetValueTotal();
    }
}
