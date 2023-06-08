using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.CommunityToolkit.Converters;
using Xamarin.Forms;

namespace App20.Converters
{
    public class InvertedBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
            //throw new NotImplementedException();
        }
    }
}
