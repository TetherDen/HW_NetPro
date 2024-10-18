using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HW_04_Udp_Client;

internal class Program
{

    static async Task Main(string[] args)
    {
        UdpClient client = new UdpClient();
        IPAddress address = IPAddress.Parse("127.0.0.1");
        const int PORT = 8888;
        IPEndPoint endPoint = new IPEndPoint(address, PORT);

        try
        {
            client.Connect(endPoint);
            while (true)
            {
                Console.WriteLine($"Enter Request or exit:");
                string request = Console.ReadLine();
                if (request.ToLower() == "exit") break;

                // Отправляем
                byte[] data = Encoding.UTF8.GetBytes(request);
                await client.SendAsync(data, data.Length);

                //Получаем 
                var result = await client.ReceiveAsync();
                var message = Encoding.UTF8.GetString(result.Buffer);
                Console.WriteLine($"Server response: {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client?.Close();
        }
    }
}
