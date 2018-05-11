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
            var isCurrency = parameter is Currency;
            if (isFloat && isCurrency)
            {
                var price = (float)value;
                var currency = (Currency) parameter;
                var symbol = CurrencyToSymbolConverter.Convert(currency);

                return $"{symbol} {price:0.##}";
            }
            else
            {
                return "Price: N/A";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
