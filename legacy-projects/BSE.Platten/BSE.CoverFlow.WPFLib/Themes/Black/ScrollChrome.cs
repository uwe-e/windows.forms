using System.Windows;
using System.Windows.Media;
using System;
using System.Windows.Media.Animation;

namespace BSE.CoverFlow.WPFLib.Themes.Black
{
    public sealed class ScrollChrome : FrameworkElement
    {
        // Fields
        private static LinearGradientBrush _commonButtonEnabledGlyph;
        private static LinearGradientBrush _commonButtonGlyph;
        private static LinearGradientBrush _commonButtonHoverGlyph;
        private static LinearGradientBrush _commonButtonPressedGlyph;
        private static LinearGradientBrush _commonHorizontalThumbEnabledGlyph;
        private static LinearGradientBrush _commonHorizontalThumbFill;
        private static LinearGradientBrush _commonHorizontalThumbHoverFill;
        private static LinearGradientBrush _commonHorizontalThumbHoverGlyph;
        private static LinearGradientBrush _commonHorizontalThumbPressedFill;
        private static LinearGradientBrush _commonHorizontalThumbPressedGlyph;
        private static SolidColorBrush _commonThumbEnabledGlyphShadow;
        private static Pen _commonThumbHoverOuterBorder;
        private static Pen _commonThumbInnerBorder;
        private static Pen _commonThumbOuterBorder;
        private static Pen _commonThumbPressedOuterBorder;
        private static Pen _commonThumbShadow;
        private static LinearGradientBrush _commonVerticalThumbEnabledGlyph;
        private static LinearGradientBrush _commonVerticalThumbFill;
        private static LinearGradientBrush _commonVerticalThumbHoverFill;
        private static LinearGradientBrush _commonVerticalThumbHoverGlyph;
        private static LinearGradientBrush _commonVerticalThumbPressedFill;
        private static LinearGradientBrush _commonVerticalThumbPressedGlyph;
        private static Geometry _downArrowGeometry;
        private static object _glyphAccess = new object();
        private static Geometry _leftArrowGeometry;
        private LocalResources _localResources;
        private static object _resourceAccess = new object();
        private static Geometry _rightArrowGeometry;
        private ScrollGlyph _scrollGlyph;
        private ScrollButton m_scrollButton;
        private MatrixTransform _transform;
        private static Geometry _upArrowGeometry;
        public static readonly DependencyProperty RenderMouseOverProperty = DependencyProperty.Register("RenderMouseOver", typeof(bool), typeof(ScrollChrome), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ScrollChrome.OnRenderMouseOverChanged)));
        public static readonly DependencyProperty RenderPressedProperty = DependencyProperty.Register("RenderPressed", typeof(bool), typeof(ScrollChrome), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ScrollChrome.OnRenderPressedChanged)));
        public static readonly DependencyProperty ScrollGlyphProperty = DependencyProperty.RegisterAttached("ScrollGlyph", typeof(ScrollGlyph), typeof(ScrollChrome), new FrameworkPropertyMetadata(ScrollGlyph.None, FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ScrollChrome.IsValidScrollGlyph));
        public static readonly DependencyProperty ScrollButtonProperty = DependencyProperty.RegisterAttached("ScrollButton", typeof(ScrollButton), typeof(ScrollChrome), new FrameworkPropertyMetadata(ScrollButton.None, FrameworkPropertyMetadataOptions.AffectsRender), new ValidateValueCallback(ScrollChrome.IsValidScrollButton));
        // Methods
        static ScrollChrome()
        {
            UIElement.IsEnabledProperty.OverrideMetadata(typeof(ScrollChrome), new FrameworkPropertyMetadata(new PropertyChangedCallback(ScrollChrome.OnEnabledChanged)));
        }

        private void AnimateToHover()
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(0.3));
            ColorAnimation animation = new ColorAnimation(Color.FromRgb(98, 98, 98), duration);
            this.OuterBorder.Brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            animation = new ColorAnimation(Color.FromRgb(102, 102, 102), duration);
            this.Fill.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
            animation = new ColorAnimation(Color.FromRgb(77, 77, 77), duration);
            this.Fill.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
            animation = new ColorAnimation(Color.FromRgb(19, 19, 19), duration);
            this.Fill.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
            animation = new ColorAnimation(Color.FromRgb(19, 19, 19), duration);
            this.Fill.GradientStops[3].BeginAnimation(GradientStop.ColorProperty, animation);
            if ((this._scrollGlyph == ScrollGlyph.HorizontalGripper) || (this._scrollGlyph == ScrollGlyph.VerticalGripper))
            {
                animation = new ColorAnimation(Color.FromRgb(0x15, 0x30, 0x3e), duration);
                this.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                animation = new ColorAnimation(Color.FromRgb(60, 0x7f, 0xb1), duration);
                this.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                animation = new ColorAnimation(Color.FromRgb(0x9c, 0xce, 0xe9), duration);
                this.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
            }
            else
            {
                animation = new ColorAnimation(Color.FromRgb(13, 0x2a, 0x3a), duration);
                this.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                animation = new ColorAnimation(Color.FromRgb(0x1f, 0x63, 0x8a), duration);
                this.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                animation = new ColorAnimation(Color.FromRgb(0x2e, 0x97, 0xcf), duration);
                this.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this._transform = null;
            return finalSize;
        }

        private void DrawArrow(DrawingContext dc, Brush brush, Rect bounds)
        {
            if (this._transform == null)
            {
                double num = 7.0;
                double num2 = 4.0;
                if ((this._scrollGlyph == ScrollGlyph.LeftArrow) || (this._scrollGlyph == ScrollGlyph.RightArrow))
                {
                    num = 4.0;
                    num2 = 7.0;
                }
                Matrix matrix = new Matrix();
                if ((bounds.Width < num) || (bounds.Height < num2))
                {
                    double d = Math.Min(num, bounds.Width) / num;
                    double num4 = Math.Min(num2, bounds.Height) / num2;
                    double num5 = ((bounds.X + (bounds.Width * 0.5)) / d) - (num * 0.5);
                    double num6 = ((bounds.Y + (bounds.Height * 0.5)) / num4) - (num2 * 0.5);
                    if (((double.IsNaN(d) || double.IsInfinity(d)) || (double.IsNaN(num4) || double.IsInfinity(num4))) || ((double.IsNaN(num5) || double.IsInfinity(num5)) || (double.IsNaN(num6) || double.IsInfinity(num6))))
                    {
                        return;
                    }
                    matrix.Translate(num5, num6);
                    matrix.Scale(d, num4);
                }
                else
                {
                    double offsetX = (bounds.X + (bounds.Width * 0.5)) - (num * 0.5);
                    double offsetY = (bounds.Y + (bounds.Height * 0.5)) - (num2 * 0.5);
                    matrix.Translate(offsetX, offsetY);
                }
                this._transform = new MatrixTransform();
                this._transform.Matrix = matrix;
            }
            dc.PushTransform(this._transform);
            switch (this._scrollGlyph)
            {
                case ScrollGlyph.LeftArrow:
                    dc.DrawGeometry(brush, null, LeftArrowGeometry);
                    break;

                case ScrollGlyph.RightArrow:
                    dc.DrawGeometry(brush, null, RightArrowGeometry);
                    break;

                case ScrollGlyph.UpArrow:
                    dc.DrawGeometry(brush, null, UpArrowGeometry);
                    break;

                case ScrollGlyph.DownArrow:
                    dc.DrawGeometry(brush, null, DownArrowGeometry);
                    break;
            }
            dc.Pop();
        }

        private void DrawBorders(DrawingContext dc, ref Rect bounds)
        {
            if ((bounds.Width >= 2.0) && (bounds.Height >= 2.0))
            {
                Brush fill = this.Fill;
                Pen outerBorder = this.OuterBorder;
                if (outerBorder != null)
                {
                    dc.DrawRoundedRectangle(fill, outerBorder, new Rect(bounds.X, bounds.Y, bounds.Width, bounds.Height), 1.0, 1.0);
                    fill = null;
                }
            }
        }

        private void DrawGlyph(DrawingContext dc, ref Rect bounds)
        {
            if ((bounds.Width > 0.0) && (bounds.Height > 0.0))
            {
                Brush glyph = this.Glyph;
                if (glyph != null)
                {
                    switch (this._scrollGlyph)
                    {
                        case ScrollGlyph.LeftArrow:
                        case ScrollGlyph.RightArrow:
                        case ScrollGlyph.UpArrow:
                        case ScrollGlyph.DownArrow:
                            this.DrawArrow(dc, glyph, bounds);
                            return;

                        case ScrollGlyph.VerticalGripper:
                            this.DrawVerticalGripper(dc, glyph, bounds);
                            return;

                        case ScrollGlyph.HorizontalGripper:
                            this.DrawHorizontalGripper(dc, glyph, bounds);
                            return;

                        case ScrollGlyph.None:
                            return;
                    }
                }
            }
        }

        private void DrawHorizontalGripper(DrawingContext dc, Brush brush, Rect bounds)
        {
            if ((bounds.Width > 15.0) && (bounds.Height > 2.0))
            {
                Brush glyphShadow = this.GlyphShadow;
                double height = Math.Min(7.0, bounds.Height);
                double num2 = height + 1.0;
                double num3 = bounds.X + ((bounds.Width * 0.5) - 4.0);
                double y = bounds.Y + ((bounds.Height - height) * 0.5);
                for (int i = 0; i < 9; i += 3)
                {
                    if (glyphShadow != null)
                    {
                        dc.DrawRectangle(glyphShadow, null, new Rect((num3 + i) - 0.5, y - 0.5, 3.0, num2));
                    }
                    dc.DrawRectangle(brush, null, new Rect(num3 + i, y, 2.0, height));
                }
            }
        }

        private void DrawShadow(DrawingContext dc, ref Rect bounds)
        {
            if ((bounds.Width > 0.0) && (bounds.Height > 2.0))
            {
                Pen shadow = this.Shadow;
                if (shadow != null)
                {
                    dc.DrawRoundedRectangle(null, shadow, new Rect(bounds.X, bounds.Y + 2.0, bounds.Width, bounds.Height - 2.0), 3.0, 3.0);
                }
                bounds.Height--;
                bounds.Width = Math.Max((double)0.0, (double)(bounds.Width - 1.0));
            }
        }

        private void DrawVerticalGripper(DrawingContext dc, Brush brush, Rect bounds)
        {
            if ((bounds.Width > 2.0) && (bounds.Height > 15.0))
            {
                Brush glyphShadow = this.GlyphShadow;
                double width = Math.Min(7.0, bounds.Width);
                double num2 = width + 1.0;
                double x = bounds.X + ((bounds.Width - width) * 0.5);
                double num4 = bounds.Y + ((bounds.Height * 0.5) - 4.0);
                for (int i = 0; i < 9; i += 3)
                {
                    if (glyphShadow != null)
                    {
                        dc.DrawRectangle(glyphShadow, null, new Rect(x - 0.5, (num4 + i) - 0.5, num2, 3.0));
                    }
                    dc.DrawRectangle(brush, null, new Rect(x, num4 + i, width, 2.0));
                }
            }
        }

        public static ScrollGlyph GetScrollGlyph(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return (ScrollGlyph)element.GetValue(ScrollGlyphProperty);
        }

        private static bool IsValidScrollGlyph(object o)
        {
            ScrollGlyph glyph = (ScrollGlyph)o;
            if ((((glyph != ScrollGlyph.None) && (glyph != ScrollGlyph.LeftArrow)) && ((glyph != ScrollGlyph.RightArrow) && (glyph != ScrollGlyph.UpArrow))) && ((glyph != ScrollGlyph.DownArrow) && (glyph != ScrollGlyph.VerticalGripper)))
            {
                return (glyph == ScrollGlyph.HorizontalGripper);
            }
            return true;
        }

        public static void SetScrollButton(DependencyObject element, ScrollButton value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(ScrollButtonProperty, value);
        }

        public static ScrollButton GetScrollButton(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            return (ScrollButton)element.GetValue(ScrollButtonProperty);
        }

        private static bool IsValidScrollButton(object o)
        {
            ScrollButton button = (ScrollButton)o;
            if ((((button == ScrollButton.None) || (button == ScrollButton.LeftButton)) || ((button == ScrollButton.RightButton) || (button == ScrollButton.UpButton))) || ((button == ScrollButton.DownButton)))
            {
                return true;
            }
            return false;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            this._transform = null;
            return new Size(0.0, 0.0);
        }

        private static void OnEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ScrollChrome chrome = (ScrollChrome)o;
            if (chrome.Animates)
            {
                if ((bool)e.NewValue)
                {
                    if (chrome._localResources == null)
                    {
                        chrome._localResources = new LocalResources();
                        chrome.InvalidateVisual();
                    }
                    Duration duration = new Duration(TimeSpan.FromSeconds(0.3));
                    if ((chrome._scrollGlyph == ScrollGlyph.HorizontalGripper) || (chrome._scrollGlyph == ScrollGlyph.VerticalGripper))
                    {
                        DoubleAnimation animation = new DoubleAnimation(1.0, duration);
                        chrome.Glyph.BeginAnimation(Brush.OpacityProperty, animation);
                        animation = new DoubleAnimation(0.63, duration);
                        chrome.GlyphShadow.BeginAnimation(Brush.OpacityProperty, animation);
                    }
                    else
                    {
                        DoubleAnimation animation2 = new DoubleAnimation(1.0, duration);
                        chrome.Fill.BeginAnimation(Brush.OpacityProperty, animation2);
                        chrome.OuterBorder.Brush.BeginAnimation(Brush.OpacityProperty, animation2);
                        animation2 = new DoubleAnimation(0.63, duration);
                        chrome.InnerBorder.Brush.BeginAnimation(Brush.OpacityProperty, animation2);
                        animation2 = new DoubleAnimation(0.5, duration);
                        chrome.Shadow.Brush.BeginAnimation(Brush.OpacityProperty, animation2);
                        ColorAnimation animation3 = new ColorAnimation(Color.FromRgb(0x21, 0x21, 0x21), duration);
                        chrome.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation3);
                        animation3 = new ColorAnimation(Color.FromRgb(0x57, 0x57, 0x57), duration);
                        chrome.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation3);
                        animation3 = new ColorAnimation(Color.FromRgb(0xb3, 0xb3, 0xb3), duration);
                        chrome.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation3);
                    }
                }
                else if (chrome._localResources == null)
                {
                    chrome.InvalidateVisual();
                }
                else
                {
                    Duration duration2 = new Duration(TimeSpan.FromSeconds(0.2));
                    if ((chrome._scrollGlyph == ScrollGlyph.HorizontalGripper) || (chrome._scrollGlyph == ScrollGlyph.VerticalGripper))
                    {
                        DoubleAnimation animation4 = new DoubleAnimation
                        {
                            Duration = duration2
                        };
                        chrome.Glyph.BeginAnimation(Brush.OpacityProperty, animation4);
                        chrome.GlyphShadow.BeginAnimation(Brush.OpacityProperty, animation4);
                    }
                    else
                    {
                        DoubleAnimation animation5 = new DoubleAnimation
                        {
                            Duration = duration2
                        };
                        chrome.Fill.BeginAnimation(Brush.OpacityProperty, animation5);
                        chrome.OuterBorder.Brush.BeginAnimation(Brush.OpacityProperty, animation5);
                        chrome.InnerBorder.Brush.BeginAnimation(Brush.OpacityProperty, animation5);
                        chrome.Shadow.Brush.BeginAnimation(Brush.OpacityProperty, animation5);
                        ColorAnimation animation6 = new ColorAnimation
                        {
                            Duration = duration2
                        };
                        chrome.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation6);
                        chrome.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation6);
                        chrome.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation6);
                    }
                }
            }
            else
            {
                chrome._localResources = null;
                chrome.InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect bounds = new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight);
            this._scrollGlyph = this.ScrollGlyph;
            this.m_scrollButton = this.ScrollButton;
            if ((bounds.Width >= 1.0) && (bounds.Height >= 1.0))
            {
                bounds.X += 0.5;
                bounds.Y += 0.5;
                bounds.Width--;
                bounds.Height--;
            }
            switch (this._scrollGlyph)
            {
                case ScrollGlyph.LeftArrow:
                case ScrollGlyph.RightArrow:
                case ScrollGlyph.HorizontalGripper:
                    if (bounds.Height >= 1.0)
                    {
                        bounds.Y++;
                        bounds.Height--;
                    }
                    break;

                case ScrollGlyph.UpArrow:
                case ScrollGlyph.DownArrow:
                case ScrollGlyph.VerticalGripper:
                    if (bounds.Width >= 1.0)
                    {
                        bounds.X++;
                        bounds.Width--;
                    }
                    break;
            }
            //this.DrawShadow(drawingContext, ref bounds);
            //this.DrawBorders(drawingContext, ref bounds);
            switch (m_scrollButton)
            {
                case Themes.Black.ScrollButton.LeftButton:
                    break;
                case Themes.Black.ScrollButton.RightButton:
                    break;
                case Themes.Black.ScrollButton.UpButton:
                    break;
                case Themes.Black.ScrollButton.DownButton:
                    break;
                default:
                    //this.DrawShadow(drawingContext, ref bounds);
                    this.DrawBorders(drawingContext, ref bounds);
                    break;
            }
            this.DrawGlyph(drawingContext, ref bounds);
        }

        private static void OnRenderMouseOverChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ScrollChrome chrome = (ScrollChrome)o;
            if (chrome.Animates)
            {
                if (chrome._localResources == null)
                {
                    chrome._localResources = new LocalResources();
                    chrome.InvalidateVisual();
                }
                if ((bool)e.NewValue)
                {
                    chrome.AnimateToHover();
                }
                else
                {
                    Duration duration = new Duration(TimeSpan.FromSeconds(0.2));
                    ColorAnimation animation = new ColorAnimation
                    {
                        Duration = duration
                    };
                    chrome.OuterBorder.Brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                    chrome.Fill.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                    chrome.Fill.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                    chrome.Fill.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
                    chrome.Fill.GradientStops[3].BeginAnimation(GradientStop.ColorProperty, animation);
                    chrome.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                    chrome.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                    chrome.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
                }
            }
            else
            {
                chrome._localResources = null;
                chrome.InvalidateVisual();
            }
        }

        private static void OnRenderPressedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ScrollChrome chrome = (ScrollChrome)o;
            if (chrome.Animates)
            {
                if (chrome._localResources == null)
                {
                    chrome._localResources = new LocalResources();
                    chrome.InvalidateVisual();
                }
                if ((bool)e.NewValue)
                {
                    Duration duration = new Duration(TimeSpan.FromSeconds(0.3));
                    ColorAnimation animation = new ColorAnimation(Color.FromRgb(0x15, 0x59, 0x8a), duration);
                    chrome.OuterBorder.Brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                    //animation = new ColorAnimation(Color.FromRgb(0xca, 0xec, 0xf9), duration);
                    animation = new ColorAnimation(Color.FromRgb(139, 164, 254), duration);
                    chrome.Fill.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                    //animation = new ColorAnimation(Color.FromRgb(0xaf, 0xe1, 0xf7), duration);
                    animation = new ColorAnimation(Color.FromRgb(104, 125, 254), duration);
                    chrome.Fill.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                    //animation = new ColorAnimation(Color.FromRgb(0x6f, 0xca, 240), duration);
                    animation = new ColorAnimation(Color.FromRgb(80, 98, 254), duration);
                    chrome.Fill.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
                    //animation = new ColorAnimation(Color.FromRgb(0x66, 0xba, 0xdd), duration);
                    animation = new ColorAnimation(Color.FromRgb(80, 98, 254), duration);
                    chrome.Fill.GradientStops[3].BeginAnimation(GradientStop.ColorProperty, animation);
                    if ((chrome._scrollGlyph == ScrollGlyph.HorizontalGripper) || (chrome._scrollGlyph == ScrollGlyph.VerticalGripper))
                    {
                        animation = new ColorAnimation(Color.FromRgb(15, 0x24, 0x30), duration);
                        chrome.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                        animation = new ColorAnimation(Color.FromRgb(0x2e, 0x73, 0x97), duration);
                        chrome.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                        animation = new ColorAnimation(Color.FromRgb(0x8f, 0xb8, 0xce), duration);
                        chrome.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
                    }
                    else
                    {
                        animation = new ColorAnimation(Color.FromRgb(14, 0x22, 0x2d), duration);
                        chrome.Glyph.GradientStops[0].BeginAnimation(GradientStop.ColorProperty, animation);
                        animation = new ColorAnimation(Color.FromRgb(0x2f, 0x79, 0x9e), duration);
                        chrome.Glyph.GradientStops[1].BeginAnimation(GradientStop.ColorProperty, animation);
                        animation = new ColorAnimation(Color.FromRgb(0x6b, 160, 0xbc), duration);
                        chrome.Glyph.GradientStops[2].BeginAnimation(GradientStop.ColorProperty, animation);
                    }
                }
                else
                {
                    chrome.AnimateToHover();
                }
            }
            else
            {
                chrome._localResources = null;
                chrome.InvalidateVisual();
            }
        }

        public static void SetScrollGlyph(DependencyObject element, ScrollGlyph value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            element.SetValue(ScrollGlyphProperty, value);
        }

        // Properties
        private bool Animates
        {
            get
            {
                return (SystemParameters.ClientAreaAnimation && (RenderCapability.Tier > 0));
            }
        }

        private LinearGradientBrush CommonButtonEnabledGlyph
        {
            get
            {
                if (_commonButtonEnabledGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonButtonEnabledGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                MappingMode = BrushMappingMode.Absolute,
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(4.0, 4.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0x21, 0x21, 0x21), 0.5), new GradientStop(Color.FromRgb(0x57, 0x57, 0x57), 0.7), new GradientStop(Color.FromRgb(0xb3, 0xb3, 0xb3), 1.0) }
                            };
                            brush.Freeze();
                            _commonButtonEnabledGlyph = brush;
                        }
                    }
                }
                return _commonButtonEnabledGlyph;
            }
        }

        private LinearGradientBrush CommonButtonGlyph
        {
            get
            {
                if (_commonButtonGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonButtonGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                MappingMode = BrushMappingMode.Absolute,
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(4.0, 4.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0x70, 0x70, 0x70), 0.5), new GradientStop(Color.FromRgb(0x76, 0x76, 0x76), 0.7), new GradientStop(Color.FromRgb(0xcb, 0xcb, 0xcb), 1.0) }
                            };
                            brush.Freeze();
                            _commonButtonGlyph = brush;
                        }
                    }
                }
                return _commonButtonGlyph;
            }
        }

        private LinearGradientBrush CommonButtonHoverGlyph
        {
            get
            {
                if (_commonButtonHoverGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonButtonHoverGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                MappingMode = BrushMappingMode.Absolute,
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(4.0, 4.0),
                                GradientStops = { new GradientStop(Color.FromRgb(13, 0x2a, 0x3a), 0.5), new GradientStop(Color.FromRgb(0x1f, 0x63, 0x8a), 0.7), new GradientStop(Color.FromRgb(0x2e, 0x97, 0xcf), 1.0) }
                            };
                            brush.Freeze();
                            _commonButtonHoverGlyph = brush;
                        }
                    }
                }
                return _commonButtonHoverGlyph;
            }
        }

        private static LinearGradientBrush CommonButtonPressedGlyph
        {
            get
            {
                if (_commonButtonPressedGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonButtonPressedGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                MappingMode = BrushMappingMode.Absolute,
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(4.0, 4.0),
                                GradientStops = { new GradientStop(Color.FromRgb(14, 0x22, 0x2d), 0.5), new GradientStop(Color.FromRgb(0x2f, 0x79, 0x9e), 0.7), new GradientStop(Color.FromRgb(0x6b, 160, 0xbc), 1.0) }
                            };
                            brush.Freeze();
                            _commonButtonPressedGlyph = brush;
                        }
                    }
                }
                return _commonButtonPressedGlyph;
            }
        }

        private LinearGradientBrush CommonHorizontalThumbEnabledGlyph
        {
            get
            {
                if (_commonHorizontalThumbEnabledGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonHorizontalThumbEnabledGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(1.0, 0.05),
                                GradientStops = { new GradientStop(Color.FromRgb(0, 0, 0), 0.5), new GradientStop(Color.FromRgb(0x97, 0x97, 0x97), 0.7), new GradientStop(Color.FromRgb(0xca, 0xca, 0xca), 1.0) }
                            };
                            brush.Freeze();
                            _commonHorizontalThumbEnabledGlyph = brush;
                        }
                    }
                }
                return _commonHorizontalThumbEnabledGlyph;
            }
        }

        private static LinearGradientBrush CommonHorizontalThumbFill
        {
            get
            {
                if (_commonHorizontalThumbFill == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonHorizontalThumbFill == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(0.0, 1.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0xf3, 0xf3, 0xf3), 0.0), new GradientStop(Color.FromRgb(0xe8, 0xe8, 0xe9), 0.5), new GradientStop(Color.FromRgb(0xd6, 0xd6, 0xd8), 0.5), new GradientStop(Color.FromRgb(0xbc, 0xbd, 0xc0), 1.0) }
                            };
                            brush.Freeze();
                            _commonHorizontalThumbFill = brush;
                        }
                    }
                }
                return _commonHorizontalThumbFill;
            }
        }

        private static LinearGradientBrush CommonHorizontalThumbHoverFill
        {
            get
            {
                if (_commonHorizontalThumbHoverFill == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonHorizontalThumbHoverFill == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(0.0, 1.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0xe3, 0xf4, 0xfc), 0.0), new GradientStop(Color.FromRgb(0xd6, 0xee, 0xfb), 0.5), new GradientStop(Color.FromRgb(0xa9, 0xdb, 0xf6), 0.5), new GradientStop(Color.FromRgb(0xa4, 0xd5, 0xef), 1.0) }
                            };
                            brush.Freeze();
                            _commonHorizontalThumbHoverFill = brush;
                        }
                    }
                }
                return _commonHorizontalThumbHoverFill;
            }
        }

        private LinearGradientBrush CommonHorizontalThumbHoverGlyph
        {
            get
            {
                if (_commonHorizontalThumbHoverGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonHorizontalThumbHoverGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(1.0, 0.05),
                                GradientStops = { new GradientStop(Color.FromRgb(0x15, 0x30, 0x3e), 0.5), new GradientStop(Color.FromRgb(60, 0x7f, 0xb1), 0.7), new GradientStop(Color.FromRgb(0x9c, 0xce, 0xe9), 1.0) }
                            };
                            brush.Freeze();
                            _commonHorizontalThumbHoverGlyph = brush;
                        }
                    }
                }
                return _commonHorizontalThumbHoverGlyph;
            }
        }

        private static LinearGradientBrush CommonHorizontalThumbPressedFill
        {
            get
            {
                if (_commonHorizontalThumbPressedFill == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonHorizontalThumbPressedFill == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(0.0, 1.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0xca, 0xec, 0xf9), 0.0), new GradientStop(Color.FromRgb(0xaf, 0xe1, 0xf7), 0.5), new GradientStop(Color.FromRgb(0x6f, 0xca, 240), 0.5), new GradientStop(Color.FromRgb(0x66, 0xba, 0xdd), 1.0) }
                            };
                            brush.Freeze();
                            _commonHorizontalThumbPressedFill = brush;
                        }
                    }
                }
                return _commonHorizontalThumbPressedFill;
            }
        }

        private LinearGradientBrush CommonHorizontalThumbPressedGlyph
        {
            get
            {
                if (_commonHorizontalThumbPressedGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonHorizontalThumbPressedGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(1.0, 0.05),
                                GradientStops = { new GradientStop(Color.FromRgb(15, 0x24, 0x30), 0.5), new GradientStop(Color.FromRgb(0x2e, 0x73, 0x97), 0.7), new GradientStop(Color.FromRgb(0x8f, 0xb8, 0xce), 1.0) }
                            };
                            brush.Freeze();
                            _commonHorizontalThumbPressedGlyph = brush;
                        }
                    }
                }
                return _commonHorizontalThumbPressedGlyph;
            }
        }

        private static SolidColorBrush CommonThumbEnabledGlyphShadow
        {
            get
            {
                if (_commonThumbEnabledGlyphShadow == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonThumbEnabledGlyphShadow == null)
                        {
                            SolidColorBrush brush = new SolidColorBrush(Colors.White)
                            {
                                Opacity = 0.63
                            };
                            brush.Freeze();
                            _commonThumbEnabledGlyphShadow = brush;
                        }
                    }
                }
                return _commonThumbEnabledGlyphShadow;
            }
        }

        private static Pen CommonThumbHoverOuterBorder
        {
            get
            {
                if (_commonThumbHoverOuterBorder == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonThumbHoverOuterBorder == null)
                        {
                            Pen pen = new Pen
                            {
                                Thickness = 1.0,
                                Brush = new SolidColorBrush(Color.FromRgb(60, 0x7f, 0xb1))
                            };
                            pen.Freeze();
                            _commonThumbHoverOuterBorder = pen;
                        }
                    }
                }
                return _commonThumbHoverOuterBorder;
            }
        }

        private static Pen CommonThumbInnerBorder
        {
            get
            {
                if (_commonThumbInnerBorder == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonThumbInnerBorder == null)
                        {
                            Pen pen = new Pen
                            {
                                Thickness = 1.0,
                                //Brush = new SolidColorBrush(Colors.White)
                                Brush = new SolidColorBrush(Color.FromRgb(102,102,102))
                            };
                            pen.Brush.Opacity = 0.63;
                            pen.Freeze();
                            _commonThumbInnerBorder = pen;
                        }
                    }
                }
                return _commonThumbInnerBorder;
            }
        }

        private static Pen CommonThumbOuterBorder
        {
            get
            {
                if (_commonThumbOuterBorder == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonThumbOuterBorder == null)
                        {
                            Pen pen = new Pen
                            {
                                Thickness = 1.0,
                                //Brush = new SolidColorBrush(Color.FromRgb(0x95, 0x95, 0x95))
                                Brush = new SolidColorBrush(Color.FromRgb(102, 102, 102))
                            };
                            pen.Freeze();
                            _commonThumbOuterBorder = pen;
                        }
                    }
                }
                return _commonThumbOuterBorder;
            }
        }

        private static Pen CommonThumbPressedOuterBorder
        {
            get
            {
                if (_commonThumbPressedOuterBorder == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonThumbPressedOuterBorder == null)
                        {
                            Pen pen = new Pen
                            {
                                Thickness = 1.0,
                                Brush = new SolidColorBrush(Color.FromRgb(0x15, 0x59, 0x8a))
                            };
                            pen.Freeze();
                            _commonThumbPressedOuterBorder = pen;
                        }
                    }
                }
                return _commonThumbPressedOuterBorder;
            }
        }

        private static Pen CommonThumbShadow
        {
            get
            {
                if (_commonThumbShadow == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonThumbShadow == null)
                        {
                            Pen pen = new Pen
                            {
                                Thickness = 1.0,
                                Brush = new SolidColorBrush(Color.FromRgb(0xcf, 0xcf, 0xcf))
                            };
                            pen.Brush.Opacity = 0.5;
                            pen.Freeze();
                            _commonThumbShadow = pen;
                        }
                    }
                }
                return _commonThumbShadow;
            }
        }

        private LinearGradientBrush CommonVerticalThumbEnabledGlyph
        {
            get
            {
                if (_commonVerticalThumbEnabledGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonVerticalThumbEnabledGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(0.05, 1.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0, 0, 0), 0.5), new GradientStop(Color.FromRgb(0x97, 0x97, 0x97), 0.7), new GradientStop(Color.FromRgb(0xca, 0xca, 0xca), 1.0) }
                            };
                            brush.Freeze();
                            _commonVerticalThumbEnabledGlyph = brush;
                        }
                    }
                }
                return _commonVerticalThumbEnabledGlyph;
            }
        }

        private static LinearGradientBrush CommonVerticalThumbFill
        {
            get
            {
                if (_commonVerticalThumbFill == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonVerticalThumbFill == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(1.0, 0.0),
                                //GradientStops = { new GradientStop(Color.FromRgb(0xf3, 0xf3, 0xf3), 0.0), new GradientStop(Color.FromRgb(0xe8, 0xe8, 0xe9), 0.5), new GradientStop(Color.FromRgb(0xd6, 0xd6, 0xd8), 0.5), new GradientStop(Color.FromRgb(0xbc, 0xbd, 0xc0), 1.0) }
                                //GradientStops = { new GradientStop(Color.FromRgb(0x77, 0x77, 0x77), 0.0), new GradientStop(Color.FromRgb(0x3f, 0x3f, 0x3f), 0.5), new GradientStop(Color.FromRgb(0x0, 0x0, 0x0), 0.5), new GradientStop(Color.FromRgb(0x0, 0x0, 0x0), 1.0) }
                                GradientStops = { new GradientStop(Color.FromRgb(77, 77, 77), 0.0), new GradientStop(Color.FromRgb(39, 39, 39), 0.5), new GradientStop(Color.FromRgb(19, 19, 19), 0.5), new GradientStop(Color.FromRgb(19, 19, 19), 1.0) }
                            };
                            brush.Freeze();
                            _commonVerticalThumbFill = brush;
                        }
                    }
                }
                return _commonVerticalThumbFill;
            }
        }

        private static LinearGradientBrush CommonVerticalThumbHoverFill
        {
            get
            {
                if (_commonVerticalThumbHoverFill == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonVerticalThumbHoverFill == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(1.0, 0.0),
                                //GradientStops = { new GradientStop(Color.FromRgb(0xe3, 0xf4, 0xfc), 0.0), new GradientStop(Color.FromRgb(0xd6, 0xee, 0xfb), 0.5), new GradientStop(Color.FromRgb(0xa9, 0xdb, 0xf6), 0.5), new GradientStop(Color.FromRgb(0xa4, 0xd5, 0xef), 1.0) }
                                GradientStops = { new GradientStop(Color.FromRgb(156, 163, 254), 0.0), new GradientStop(Color.FromRgb(80, 98, 254), 0.5), new GradientStop(Color.FromRgb(139, 164, 254), 0.5), new GradientStop(Color.FromRgb(139, 164, 254), 1.0) }
                            };
                            brush.Freeze();
                            _commonVerticalThumbHoverFill = brush;
                        }
                    }
                }
                return _commonVerticalThumbHoverFill;
            }
        }

        private LinearGradientBrush CommonVerticalThumbHoverGlyph
        {
            get
            {
                if (_commonVerticalThumbHoverGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonVerticalThumbHoverGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(0.05, 1.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0x15, 0x30, 0x3e), 0.5), new GradientStop(Color.FromRgb(60, 0x7f, 0xb1), 0.7), new GradientStop(Color.FromRgb(0x9c, 0xce, 0xe9), 1.0) }
                            };
                            brush.Freeze();
                            _commonVerticalThumbHoverGlyph = brush;
                        }
                    }
                }
                return _commonVerticalThumbHoverGlyph;
            }
        }

        private static LinearGradientBrush CommonVerticalThumbPressedFill
        {
            get
            {
                if (_commonVerticalThumbPressedFill == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonVerticalThumbPressedFill == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(1.0, 0.0),
                                GradientStops = { new GradientStop(Color.FromRgb(0xca, 0xec, 0xf9), 0.0), new GradientStop(Color.FromRgb(0xaf, 0xe1, 0xf7), 0.5), new GradientStop(Color.FromRgb(0x6f, 0xca, 240), 0.5), new GradientStop(Color.FromRgb(0x66, 0xba, 0xdd), 1.0) }
                                //GradientStops = { new GradientStop(Color.FromRgb(139, 164, 254), 0.0), new GradientStop(Color.FromRgb(139, 164, 254), 0.5), new GradientStop(Color.FromRgb(80, 98, 254), 0.5), new GradientStop(Color.FromRgb(80, 98, 254), 1.0) }
                            };
                            brush.Freeze();
                            _commonVerticalThumbPressedFill = brush;
                        }
                    }
                }
                return _commonVerticalThumbPressedFill;
            }
        }

        private LinearGradientBrush CommonVerticalThumbPressedGlyph
        {
            get
            {
                if (_commonVerticalThumbPressedGlyph == null)
                {
                    lock (_resourceAccess)
                    {
                        if (_commonVerticalThumbPressedGlyph == null)
                        {
                            LinearGradientBrush brush = new LinearGradientBrush
                            {
                                StartPoint = new Point(0.0, 0.0),
                                EndPoint = new Point(0.05, 1.0),
                                GradientStops = { new GradientStop(Color.FromRgb(15, 0x24, 0x30), 0.5), new GradientStop(Color.FromRgb(0x2e, 0x73, 0x97), 0.7), new GradientStop(Color.FromRgb(0x8f, 0xb8, 0xce), 1.0) }
                            };
                            brush.Freeze();
                            _commonVerticalThumbPressedGlyph = brush;
                        }
                    }
                }
                return _commonVerticalThumbPressedGlyph;
            }
        }

        private static Geometry DownArrowGeometry
        {
            get
            {
                if (_downArrowGeometry == null)
                {
                    lock (_glyphAccess)
                    {
                        if (_downArrowGeometry == null)
                        {
                            PathFigure figure = new PathFigure
                            {
                                StartPoint = new Point(0.0, 0.0),
                                Segments = { new LineSegment(new Point(3.5, 4.0), true), new LineSegment(new Point(7.0, 0.0), true) },
                                IsClosed = true
                            };
                            figure.Freeze();
                            PathGeometry geometry = new PathGeometry
                            {
                                Figures = { figure }
                            };
                            geometry.Freeze();
                            _downArrowGeometry = geometry;
                        }
                    }
                }
                return _downArrowGeometry;
            }
        }

        //internal override int EffectiveValuesInitialSize
        internal int EffectiveValuesInitialSize
        {
            get
            {
                return 0x13;
            }
        }

        private LinearGradientBrush Fill
        {
            get
            {
                if (!this.Animates)
                {
                    if (((this._scrollGlyph == ScrollGlyph.HorizontalGripper) || (this._scrollGlyph == ScrollGlyph.LeftArrow)) || (this._scrollGlyph == ScrollGlyph.RightArrow))
                    {
                        if (this.RenderPressed)
                        {
                            return CommonHorizontalThumbPressedFill;
                        }
                        if (this.RenderMouseOver)
                        {
                            return CommonHorizontalThumbHoverFill;
                        }
                        if (!base.IsEnabled && (this._scrollGlyph != ScrollGlyph.HorizontalGripper))
                        {
                            return null;
                        }
                        return CommonHorizontalThumbFill;
                    }
                    if (this.RenderPressed)
                    {
                        return CommonVerticalThumbPressedFill;
                    }
                    if (this.RenderMouseOver)
                    {
                        return CommonVerticalThumbHoverFill;
                    }
                    if (!base.IsEnabled && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                    {
                        return null;
                    }
                    return CommonVerticalThumbFill;
                }
                if (this._localResources != null)
                {
                    if (this._localResources.Fill == null)
                    {
                        if (this._scrollGlyph == ScrollGlyph.HorizontalGripper)
                        {
                            this._localResources.Fill = CommonHorizontalThumbFill.Clone();
                        }
                        else if (this._scrollGlyph == ScrollGlyph.VerticalGripper)
                        {
                            this._localResources.Fill = CommonVerticalThumbFill.Clone();
                        }
                        else
                        {
                            if ((this._scrollGlyph == ScrollGlyph.LeftArrow) || (this._scrollGlyph == ScrollGlyph.RightArrow))
                            {
                                this._localResources.Fill = CommonHorizontalThumbFill.Clone();
                            }
                            else
                            {
                                this._localResources.Fill = CommonVerticalThumbFill.Clone();
                            }
                            this._localResources.Fill.Opacity = 0.0;
                        }
                    }
                    return this._localResources.Fill;
                }
                if (this._scrollGlyph == ScrollGlyph.HorizontalGripper)
                {
                    return CommonHorizontalThumbFill;
                }
                if (this._scrollGlyph == ScrollGlyph.VerticalGripper)
                {
                    return CommonVerticalThumbFill;
                }
                return null;
            }
        }

        private LinearGradientBrush Glyph
        {
            get
            {
                if (!this.Animates)
                {
                    if (this._scrollGlyph == ScrollGlyph.HorizontalGripper)
                    {
                        if (this.RenderPressed)
                        {
                            return this.CommonHorizontalThumbPressedGlyph;
                        }
                        if (this.RenderMouseOver)
                        {
                            return this.CommonHorizontalThumbHoverGlyph;
                        }
                        return this.CommonHorizontalThumbEnabledGlyph;
                    }
                    if (this._scrollGlyph == ScrollGlyph.VerticalGripper)
                    {
                        if (this.RenderPressed)
                        {
                            return this.CommonVerticalThumbPressedGlyph;
                        }
                        if (this.RenderMouseOver)
                        {
                            return this.CommonVerticalThumbHoverGlyph;
                        }
                        return this.CommonVerticalThumbEnabledGlyph;
                    }
                    if (this.RenderPressed)
                    {
                        return CommonButtonPressedGlyph;
                    }
                    if (this.RenderMouseOver)
                    {
                        return this.CommonButtonHoverGlyph;
                    }
                    if (base.IsEnabled)
                    {
                        return this.CommonButtonEnabledGlyph;
                    }
                    return this.CommonButtonGlyph;
                }
                if (this._localResources != null)
                {
                    if (this._localResources.Glyph == null)
                    {
                        if ((this._scrollGlyph == ScrollGlyph.HorizontalGripper) || (this._scrollGlyph == ScrollGlyph.VerticalGripper))
                        {
                            this._localResources.Glyph = new LinearGradientBrush();
                            this._localResources.Glyph.StartPoint = new Point(0.0, 0.0);
                            if (this._scrollGlyph == ScrollGlyph.HorizontalGripper)
                            {
                                this._localResources.Glyph.EndPoint = new Point(1.0, 0.05);
                            }
                            else
                            {
                                this._localResources.Glyph.EndPoint = new Point(0.05, 1.0);
                            }
                            //this._localResources.Glyph.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 0), 0.5));
                            //this._localResources.Glyph.GradientStops.Add(new GradientStop(Color.FromRgb(0x97, 0x97, 0x97), 0.7));
                            //this._localResources.Glyph.GradientStops.Add(new GradientStop(Color.FromRgb(0xca, 0xca, 0xca), 1.0));
                            this._localResources.Glyph.GradientStops.Add(new GradientStop(Color.FromRgb(19, 19, 19), 0.5));
                            this._localResources.Glyph.GradientStops.Add(new GradientStop(Color.FromRgb(0x97, 0x97, 0x97), 0.7));
                            this._localResources.Glyph.GradientStops.Add(new GradientStop(Color.FromRgb(0xca, 0xca, 0xca), 1.0));
                        }
                        else
                        {
                            this._localResources.Glyph = this.CommonButtonGlyph.Clone();
                        }
                    }
                    return this._localResources.Glyph;
                }
                if (this._scrollGlyph == ScrollGlyph.HorizontalGripper)
                {
                    return this.CommonHorizontalThumbEnabledGlyph;
                }
                if (this._scrollGlyph == ScrollGlyph.VerticalGripper)
                {
                    return this.CommonVerticalThumbEnabledGlyph;
                }
                return this.CommonButtonGlyph;
            }
        }

        private SolidColorBrush GlyphShadow
        {
            get
            {
                if (!this.Animates)
                {
                    if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                    {
                        return null;
                    }
                    return CommonThumbEnabledGlyphShadow;
                }
                if (this._localResources == null)
                {
                    return null;
                }
                if ((this._localResources.GlyphShadow == null) && ((this._scrollGlyph == ScrollGlyph.HorizontalGripper) || (this._scrollGlyph == ScrollGlyph.VerticalGripper)))
                {
                    this._localResources.GlyphShadow = new SolidColorBrush(Colors.White);
                }
                return this._localResources.GlyphShadow;
            }
        }

        private Pen InnerBorder
        {
            get
            {
                if (!this.Animates)
                {
                    if ((!base.IsEnabled && (this._scrollGlyph != ScrollGlyph.HorizontalGripper)) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                    {
                        return null;
                    }
                    return CommonThumbInnerBorder;
                }
                if (this._localResources != null)
                {
                    if (this._localResources.InnerBorder == null)
                    {
                        this._localResources.InnerBorder = CommonThumbInnerBorder.Clone();
                        if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                        {
                            this._localResources.InnerBorder.Brush.Opacity = 0.0;
                        }
                    }
                    return this._localResources.InnerBorder;
                }
                if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                {
                    return null;
                }
                return CommonThumbInnerBorder;
            }
        }

        private static Geometry LeftArrowGeometry
        {
            get
            {
                if (_leftArrowGeometry == null)
                {
                    lock (_glyphAccess)
                    {
                        if (_leftArrowGeometry == null)
                        {
                            PathFigure figure = new PathFigure
                            {
                                StartPoint = new Point(4.0, 0.0),
                                Segments = { new LineSegment(new Point(0.0, 3.5), true), new LineSegment(new Point(4.0, 7.0), true) },
                                IsClosed = true
                            };
                            figure.Freeze();
                            PathGeometry geometry = new PathGeometry
                            {
                                Figures = { figure }
                            };
                            geometry.Freeze();
                            _leftArrowGeometry = geometry;
                        }
                    }
                }
                return _leftArrowGeometry;
            }
        }

        private Pen OuterBorder
        {
            get
            {
                if (!this.Animates)
                {
                    if (this.RenderPressed)
                    {
                        return CommonThumbPressedOuterBorder;
                    }
                    if (this.RenderMouseOver)
                    {
                        return CommonThumbHoverOuterBorder;
                    }
                    if ((!base.IsEnabled && (this._scrollGlyph != ScrollGlyph.HorizontalGripper)) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                    {
                        return null;
                    }
                    return CommonThumbOuterBorder;
                }
                if (this._localResources != null)
                {
                    if (this._localResources.OuterBorder == null)
                    {
                        this._localResources.OuterBorder = CommonThumbOuterBorder.Clone();
                        if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                        {
                            this._localResources.OuterBorder.Brush.Opacity = 0.0;
                        }
                    }
                    return this._localResources.OuterBorder;
                }
                if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                {
                    return null;
                }
                return CommonThumbOuterBorder;
            }
        }

        public bool RenderMouseOver
        {
            get
            {
                return (bool)base.GetValue(RenderMouseOverProperty);
            }
            set
            {
                base.SetValue(RenderMouseOverProperty, value);
            }
        }

        public bool RenderPressed
        {
            get
            {
                return (bool)base.GetValue(RenderPressedProperty);
            }
            set
            {
                base.SetValue(RenderPressedProperty, value);
            }
        }

        private static Geometry RightArrowGeometry
        {
            get
            {
                if (_rightArrowGeometry == null)
                {
                    lock (_glyphAccess)
                    {
                        if (_rightArrowGeometry == null)
                        {
                            PathFigure figure = new PathFigure
                            {
                                StartPoint = new Point(0.0, 0.0),
                                Segments = { new LineSegment(new Point(4.0, 3.5), true), new LineSegment(new Point(0.0, 7.0), true) },
                                IsClosed = true
                            };
                            figure.Freeze();
                            PathGeometry geometry = new PathGeometry
                            {
                                Figures = { figure }
                            };
                            geometry.Freeze();
                            _rightArrowGeometry = geometry;
                        }
                    }
                }
                return _rightArrowGeometry;
            }
        }

        private ScrollGlyph ScrollGlyph
        {
            get
            {
                return (ScrollGlyph)base.GetValue(ScrollGlyphProperty);
            }
        }
        private ScrollButton ScrollButton
        {
            get
            {
                return (ScrollButton)base.GetValue(ScrollButtonProperty);
            }
        }
        private Pen Shadow
        {
            get
            {
                if (!this.Animates)
                {
                    if ((!base.IsEnabled && (this._scrollGlyph != ScrollGlyph.HorizontalGripper)) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                    {
                        return null;
                    }
                    return CommonThumbShadow;
                }
                if (this._localResources != null)
                {
                    if (this._localResources.Shadow == null)
                    {
                        this._localResources.Shadow = CommonThumbShadow.Clone();
                        if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                        {
                            this._localResources.Shadow.Brush.Opacity = 0.0;
                        }
                    }
                    return this._localResources.Shadow;
                }
                if ((this._scrollGlyph != ScrollGlyph.HorizontalGripper) && (this._scrollGlyph != ScrollGlyph.VerticalGripper))
                {
                    return null;
                }
                return CommonThumbShadow;
            }
        }

        private static Geometry UpArrowGeometry
        {
            get
            {
                if (_upArrowGeometry == null)
                {
                    lock (_glyphAccess)
                    {
                        if (_upArrowGeometry == null)
                        {
                            PathFigure figure = new PathFigure
                            {
                                StartPoint = new Point(0.0, 4.0),
                                Segments = { new LineSegment(new Point(3.5, 0.0), true), new LineSegment(new Point(7.0, 4.0), true) },
                                IsClosed = true
                            };
                            figure.Freeze();
                            PathGeometry geometry = new PathGeometry
                            {
                                Figures = { figure }
                            };
                            geometry.Freeze();
                            _upArrowGeometry = geometry;
                        }
                    }
                }
                return _upArrowGeometry;
            }
        }

        // Nested Types
        private class LocalResources
        {
            // Fields
            public LinearGradientBrush Fill;
            public LinearGradientBrush Glyph;
            public SolidColorBrush GlyphShadow;
            public Pen InnerBorder;
            public Pen OuterBorder;
            public Pen Shadow;
        }
    }
}