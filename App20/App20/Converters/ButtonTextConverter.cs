using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App20.Converters
{
    public class ButtonTextConverter :IValueConverter
    {
        readonly string TextAdd = "ADD";
        readonly string TextUpdate = "UPDATE";
   
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            if (!string.IsNullOrEmpty(s))
                return TextUpdate;

            else
                return TextAdd;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
