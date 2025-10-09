using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows;
using BSE.Platten.Audio;

namespace BSE.CoverFlow.WPFLib.PlayerPanel
{
    public class PlayModeRandomToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bIsPlayModeRandom = false;
            PlayMode playMode = (PlayMode)value;
            if (playMode == PlayMode.Random)
            {
                bIsPlayModeRandom = true;
            }
            return bIsPlayModeRandom;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
