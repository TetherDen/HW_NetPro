namespace HW_09_Server_asp.net_core.Currencys
{
    public class Currency(string name, decimal price)
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
    }

}
