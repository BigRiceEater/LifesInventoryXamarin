using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using LifesInventory.Enums;
using Xamarin.Forms;

namespace LifesInventory.Converters
{
    public class PriceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isFloat = value is float;
            if (isFloat)
            {
                var price = (float)value;
                return $"HKD {price:0.##}";
            }
            else
            {
                return "HKD N/A";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
