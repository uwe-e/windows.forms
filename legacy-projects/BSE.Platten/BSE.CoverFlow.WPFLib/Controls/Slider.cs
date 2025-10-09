using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace BSE.CoverFlow.WPFLib.Controls
{
    [TemplatePart(Name = "IsProgressVisible", Type = typeof(bool))]
    public class Slider : System.Windows.Controls.Slider
    {
        #region Events
        public static readonly RoutedEvent DragCompletedEvent = EventManager.RegisterRoutedEvent("DragCompleted", RoutingStrategy.Bubble, typeof(DragCompletedEventHandler), typeof(Slider));
        /// <summary>
        /// Occurs when the Thumb control within a Slider loses mouse capture.
        /// </summary>
        [Category("Behavior")]
        public event DragCompletedEventHandler DragCompleted
        {
            add
            {
                base.AddHandler(DragCompletedEvent, value);
            }
            remove
            {
                base.RemoveHandler(DragCompletedEvent, value);
            }
        }

        public static readonly RoutedEvent DragStartedEvent = EventManager.RegisterRoutedEvent("DragStarted", RoutingStrategy.Bubble, typeof(DragStartedEventHandler), typeof(Slider));
        /// <summary>
        /// Occurs when a Thumb control within the slider receives logical focus and mouse capture.
        /// </summary>
        [Category("Behavior")]
        public event DragStartedEventHandler DragStarted
        {
            add
            {
                base.AddHandler(DragStartedEvent, value);
            }
            remove
            {
                base.RemoveHandler(DragStartedEvent, value);
            }
        }

        #endregion

        #region FieldsPublic
        public static readonly DependencyProperty IsProgressVisibleProperty;
        #endregion

        #region Properties
        [Category("Appearance"), Bindable(true)]
        public bool IsProgressVisible
        {
            get
            {
                return (bool)base.GetValue(IsProgressVisibleProperty);
            }
            set
            {
                base.SetValue(IsProgressVisibleProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var track = this.GetTemplateChild("PART_Track") as Track;
            if (track != null)
            {
                Thumb thumb = track.Thumb;
                if (thumb != null)
                {
                    thumb.DragStarted += ((sender, routedEventArgs) =>
                    {
                        this.RaiseEvent(new DragStartedEventArgs(routedEventArgs.HorizontalOffset, routedEventArgs.VerticalOffset)
                        {
                            RoutedEvent = Slider.DragStartedEvent
                        });
                    });
                    thumb.DragCompleted += ((sender, routedEventArgs) =>
                    {
                        this.RaiseEvent(new DragCompletedEventArgs(routedEventArgs.HorizontalChange, routedEventArgs.VerticalChange, routedEventArgs.Canceled)
                        {
                            RoutedEvent = Slider.DragCompletedEvent
                        });
                    });
                }
            }
        }
        #endregion

        #region MethodsPrivate
        static Slider()
		{
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(Slider), new FrameworkPropertyMetadata(typeof(Slider)));
            
            IsProgressVisibleProperty = DependencyProperty.Register(
                "IsProgressVisible",
                typeof(bool),
                typeof(Slider),
                new FrameworkPropertyMetadata(false));
		}
        #endregion

    }
}
