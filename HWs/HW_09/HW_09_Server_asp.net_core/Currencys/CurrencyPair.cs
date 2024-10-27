namespace HW_09_Server_asp.net_core.Currencys
{
    public class CurrencyPair(Currency currency1, Currency currency2)
    {
        public Currency Currency1 { get; set; } = currency1;
        public Currency Currency2 { get; set; } = currency2;
        public decimal ExchangeRate
        {
            get
            {
                return Currency1.Price / Currency2.Price;
            }
        }
        public override string ToString()
        {
            return $"{Currency1.Name}/{Currency2.Name} - ExchangeRate: {ExchangeRate:F8}";
        }
    }
}
