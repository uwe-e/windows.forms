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
    public class PlayModeCdToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bIsPlayMode = false;
            PlayMode playMode = (PlayMode)value;
            if (playMode == PlayMode.CD)
            {
                bIsPlayMode = true;
            }
            return bIsPlayMode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
