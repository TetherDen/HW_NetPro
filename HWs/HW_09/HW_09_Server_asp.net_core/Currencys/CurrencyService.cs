using HW_09_Server_asp.net_core.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace HW_09_Server_asp.net_core.Currencys
{
    public static class CurrencyService
    {
        public static List<CurrencyPair> CurrencyPairs = new List<CurrencyPair>();

        private static Random _random = new();

        public static void AddCurrencyPair(Currency currency1, Currency currency2)
        {
            CurrencyPairs.Add(new CurrencyPair(currency1, currency2));
        }

        public static async Task StartUpdatingPrices()
        {
            while (true)
            {
                UpdatePrices();
                await Task.Delay(1000);
            }
        }

        private static async Task UpdatePrices()
        {
            foreach (var pair in CurrencyPairs)
            {
                decimal changePercentage = (decimal)(_random.NextDouble() * 0.06) - 0.03m;
                decimal changePercentage2 = (decimal)(_random.NextDouble() * 0.06) - 0.03m;

                pair.Currency1.Price *= (1 + changePercentage);
                pair.Currency2.Price *= (1 + changePercentage2);

            }
        }

    }
}
