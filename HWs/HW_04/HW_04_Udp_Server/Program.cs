using System.Dynamic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace HW_04_Udp_Server;

internal class Program
{
    private static UdpClient _server;
    private static readonly IPAddress ip = IPAddress.Parse("127.0.0.1");
    private const int _PORT = 8888;
    private const short _MAX_CLIENTS = 500;
    private const short _MAX_HOURLY_REQUESTS = 10;
    private static Dictionary<IPEndPoint, ClientInfo> clients = new();
    private static object _lock = new object();
    private static Dictionary<string,string> components = new()
    {
        { "processor", "300$" },
        { "videocard", "700$" },
        { "ram", "200$" }
    };



    static async Task Main(string[] args)
    {
        _server = new UdpClient(new IPEndPoint(ip, _PORT));
        Console.WriteLine($"Server started: {((IPEndPoint)_server.Client.LocalEndPoint).Address}: {((IPEndPoint)_server.Client.LocalEndPoint).Port}, {_server.Client.LocalEndPoint.AddressFamily}");

        Task.Run(CheckInactiveClients); // 

        while (true)
        {
            var receiveResult = await _server.ReceiveAsync();
            IPEndPoint clientEndPoint = receiveResult.RemoteEndPoint;
            string request = Encoding.UTF8.GetString(receiveResult.Buffer);


            lock (_lock)
            {
                if (!clients.ContainsKey(clientEndPoint))
                {
                    clients[clientEndPoint] = new ClientInfo();
                    Console.WriteLine($"New client connected: {clientEndPoint.Address}:{clientEndPoint.Port}");
                    if (clients.Count >= _MAX_CLIENTS)
                    {
                        Console.WriteLine($"Current clients on server: {clients.Count}/{_MAX_CLIENTS}. Maximum client limit reached. Please wait...");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Current clients on server: {clients.Count}/{_MAX_CLIENTS}.");
                    }
                    
                }
                Console.WriteLine($"Request {clientEndPoint.Port}: {request}");
                var clientInfo = clients[clientEndPoint];
                if (clientInfo.RequestsLastHour >= _MAX_HOURLY_REQUESTS)
                {
                    Console.WriteLine($"Cleint {clientEndPoint} reached request limit per houer.");
                    continue;
                }
                clientInfo.RequestsLastHour++;
                clientInfo.LastRequestTime = DateTime.Now;
            }
            Response(ProcessRequest(request),clientEndPoint);
        }
    }


    private static async Task Response(string response, IPEndPoint clientEndPoint )
    {
        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
        await _server.SendAsync(responseBytes, responseBytes.Length, clientEndPoint);
    }

    private static string ProcessRequest(string request)
    {

        if (components.ContainsKey(request.ToLower()))
        {
            return components[request.ToLower()];
        }

        return "No component in current list.";
    }

    private static async Task CheckInactiveClients()
    {
        while (true)
        {
            lock (_lock)
            {
                var inactiveClients = clients.Where(c => (DateTime.Now - c.Value.LastRequestTime).TotalMinutes > 10).ToList();
                foreach (var client in inactiveClients)
                {
                    Console.WriteLine($"Client {client.Key} is inactive and will be removed.");
                    clients.Remove(client.Key);
                }
            }
            await Task.Delay(60000);
        }
    }
}



class ClientInfo
{
    public DateTime LastRequestTime { get; set; } = DateTime.Now;
    public int RequestsLastHour { get; set; } = 0;
}

