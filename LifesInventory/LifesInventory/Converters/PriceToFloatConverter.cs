using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LifesInventory.Converters
{
    public class PriceToFloatConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var number = (float) value;
                return number.ToString();
            }
            else
                return "";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float result = 0.0f;
            var isString = value is String;

            if (isString)
            {
                var asString = value as string;
                var canConvert = float.TryParse(asString, out result);
                if (!canConvert) result = 0.0f;
            }

            return result;
        }
    }
}
