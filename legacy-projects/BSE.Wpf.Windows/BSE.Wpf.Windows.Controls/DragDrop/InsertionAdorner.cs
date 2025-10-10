using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace BSE.Wpf.Windows.Controls.DragDrop
{
    public class InsertionAdorner : Adorner
    {
        #region FieldsPrivate
        private bool m_bIsSeparatorHorizontal;
        private AdornerLayer m_adornerLayer;
        private static Pen m_pen;
        private static PathGeometry m_triangle;
        #endregion

        #region Properties
        public bool IsInFirstHalf
        {
            get;
            set;
        }
        #endregion

        #region MethodsPublic
        public InsertionAdorner(bool isSeparatorHorizontal, bool isInFirstHalf, UIElement adornedElement, AdornerLayer adornerLayer)
            : base(adornedElement)
        {
            this.m_bIsSeparatorHorizontal = isSeparatorHorizontal;
            this.IsInFirstHalf = isInFirstHalf;
            this.m_adornerLayer = adornerLayer;
            this.IsHitTestVisible = false;

            this.m_adornerLayer.Add(this);
        }
        // Create the pen and triangle in a static constructor and freeze them to improve performance.
        static InsertionAdorner()
        {
            m_pen = new Pen { Brush = Brushes.Gray, Thickness = 2 };
            m_pen.Freeze();

            LineSegment firstLine = new LineSegment(new Point(0, -5), false);
            firstLine.Freeze();
            LineSegment secondLine = new LineSegment(new Point(0, 5), false);
            secondLine.Freeze();

            PathFigure figure = new PathFigure { StartPoint = new Point(5, 0) };
            figure.Segments.Add(firstLine);
            figure.Segments.Add(secondLine);
            figure.Freeze();

            m_triangle = new PathGeometry();
            m_triangle.Figures.Add(figure);
            m_triangle.Freeze();
        }
        public void Detach()
        {
            this.m_adornerLayer.Remove(this);
        }
        #endregion

        #region MethodsProtected
        // This draws one line and two triangles at each end of the line.
        protected override void OnRender(DrawingContext drawingContext)
        {
            Point startPoint;
            Point endPoint;

            CalculateStartAndEndPoint(out startPoint, out endPoint);
            drawingContext.DrawLine(m_pen, startPoint, endPoint);

            if (this.m_bIsSeparatorHorizontal)
            {
                DrawTriangle(drawingContext, startPoint, 0);
                DrawTriangle(drawingContext, endPoint, 180);
            }
            else
            {
                DrawTriangle(drawingContext, startPoint, 90);
                DrawTriangle(drawingContext, endPoint, -90);
            }
        }
        #endregion

        #region MethodsPrivate

        private void DrawTriangle(DrawingContext drawingContext, Point origin, double angle)
        {
            drawingContext.PushTransform(new TranslateTransform(origin.X, origin.Y));
            drawingContext.PushTransform(new RotateTransform(angle));

            drawingContext.DrawGeometry(m_pen.Brush, null, m_triangle);

            drawingContext.Pop();
            drawingContext.Pop();
        }

        private void CalculateStartAndEndPoint(out Point startPoint, out Point endPoint)
        {
            startPoint = new Point();
            endPoint = new Point();

            double width = this.AdornedElement.RenderSize.Width;
            double height = this.AdornedElement.RenderSize.Height;

            if (this.m_bIsSeparatorHorizontal)
            {
                endPoint.X = width;
                if (!this.IsInFirstHalf)
                {
                    startPoint.Y = height;
                    endPoint.Y = height;
                }
            }
            else
            {
                endPoint.Y = height;
                if (!this.IsInFirstHalf)
                {
                    startPoint.X = width;
                    endPoint.X = width;
                }
            }
        }

        #endregion
    }
}
