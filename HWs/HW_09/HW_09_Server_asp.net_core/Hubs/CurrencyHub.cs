using HW_09_Server_asp.net_core.Currencys;
using Microsoft.AspNetCore.SignalR;

namespace HW_09_Server_asp.net_core.Hubs
{
    public class CurrencyHub : Hub
    {
        public async Task Send(IHubContext<CurrencyHub> hubContext)
        {
            while (true)
            {
                foreach (var pair in CurrencyService.CurrencyPairs)
                {
                    await hubContext.Clients.All.SendAsync("Receive", pair.ToString());
                }
                await Task.Delay(1000);
            }
        }
    }

}
