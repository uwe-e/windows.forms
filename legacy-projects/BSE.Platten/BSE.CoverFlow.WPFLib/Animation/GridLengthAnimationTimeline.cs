using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;

namespace BSE.CoverFlow.WPFLib.Animation
{
    internal class GridLengthAnimationTimeline : AnimationTimeline
    {
        #region FieldsPublic
        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(GridLength),
                   typeof(GridLengthAnimationTimeline));
        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(GridLength),
                   typeof(GridLengthAnimationTimeline));
        #endregion

        #region Properties
        public GridLength From
        {
            get
            {
                return (GridLength)GetValue(GridLengthAnimationTimeline.FromProperty);
            }
            set
            {
                SetValue(GridLengthAnimationTimeline.FromProperty, value);
            }
        }
        public GridLength To
        {
            get
            {
                return (GridLength)GetValue(GridLengthAnimationTimeline.ToProperty);
            }
            set
            {
                SetValue(GridLengthAnimationTimeline.ToProperty, value);
            }
        }
        #endregion

        #region MethodsPublic
        public override Type TargetPropertyType
        {
            get
            {
                return typeof(GridLength);
            }
        }
        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            GridLength gridLengthDestination = (GridLength)GetValue(GridLengthAnimationTimeline.ToProperty);
            if (gridLengthDestination.IsAuto == true)
            {
                return gridLengthDestination;
            }

            double fromValue = ((GridLength)GetValue(GridLengthAnimationTimeline.FromProperty)).Value;
            double toValue = gridLengthDestination.Value;
            if (fromValue > toValue)
            {
                return new GridLength((1 - animationClock.CurrentProgress.Value) * (fromValue - toValue) + toValue, GridUnitType.Star);
            }
            else
            {
                return new GridLength(animationClock.CurrentProgress.Value * (toValue - fromValue) + fromValue, GridUnitType.Star);
            }
        }
        #endregion

        #region MethodsProtected
        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimationTimeline();
        }
        #endregion
    }
}
