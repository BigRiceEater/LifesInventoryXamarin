using System;
using System.Collections.Generic;
using System.Text;
using LifesInventory.Enums;

namespace LifesInventory.Converters
{
    public static class CurrencyToSymbolConverter
    {
        public static string Convert(Currency currency)
        {
            var symbol = "??";
            switch (currency)
            {
                case Currency.HongKongDollar:
                    symbol = "HKD";
                    break;
                case Currency.AmericanDollar:
                    symbol = "USD";
                    break;
                case Currency.ChineseYuen:
                    symbol = "RMB";
                    break;
            }

            return symbol;
        }
    }
}