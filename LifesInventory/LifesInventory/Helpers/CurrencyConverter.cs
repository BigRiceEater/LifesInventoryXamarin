using System;
using System.Collections.Generic;
using System.Text;
using LifesInventory.Enums;

namespace LifesInventory.Helpers
{
    using CurrencyPair = KeyValuePair<Currency,Currency>;
    public static class CurrencyConverter
    {

        private static Dictionary<CurrencyPair, float> ExchangeRateByCurrency =
            new Dictionary<CurrencyPair, float>()
            {
                { new CurrencyPair(Currency.HongKongDollar,Currency.AmericanDollar), 7.8f}
            };

        public static float Convert(Currency from, Currency to)
        {
            return 0.0f;
        }
    }
}
