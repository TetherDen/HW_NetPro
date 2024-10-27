using HW_09_Server_asp.net_core.Hubs;
using HW_09_Server_asp.net_core.Currencys;
using Microsoft.AspNetCore.SignalR;


namespace HW_09_Server_asp.net_core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSignalR();
            var app = builder.Build();

            app.MapHub<CurrencyHub>("/rate");

            Currency BTC = new Currency("BTC", 60000);
            Currency ETH = new Currency("ETH", 2500);

            CurrencyService.AddCurrencyPair(BTC, ETH);
            CurrencyService.AddCurrencyPair(ETH, BTC);
            CurrencyService.StartUpdatingPrices();

            var hubContext = app.Services.GetRequiredService<IHubContext<CurrencyHub>>();

            Task.Run(async () =>
            {
                var currencyHub = new CurrencyHub();
                await currencyHub.Send(hubContext);
            });




            app.Run();
        }
    }
}
