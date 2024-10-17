using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress adr = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(adr, 8888);

            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    await tcpClient.ConnectAsync(endPoint);
                    if(tcpClient.Connected)
                    {
                        Console.WriteLine($"Connected to server {endPoint}");
                    }
                   
                    using NetworkStream stream = tcpClient.GetStream();
                    while (true)
                    {
                        Console.WriteLine($"Enter request: ");
                        string request = Console.ReadLine();

                        // отправляем длину запроса и запрос
                        byte[] requestBytes = Encoding.UTF8.GetBytes(request);
                        byte[] sizeBuffer = BitConverter.GetBytes(requestBytes.Length);
                        await stream.WriteAsync(sizeBuffer, 0, sizeBuffer.Length);
                        await stream.WriteAsync(requestBytes, 0, requestBytes.Length);



                        // читаем длину ответа и ответ
                        byte[] responseSizeBuffer = new byte[4];
                        await stream.ReadAsync(responseSizeBuffer, 0, responseSizeBuffer.Length);
                        int responseSize = BitConverter.ToInt32(responseSizeBuffer, 0);

                        byte[] responseBytes = new byte[responseSize];
                        await stream.ReadAsync(responseBytes, 0, responseSize);
                        string response = Encoding.UTF8.GetString(responseBytes);
                        Console.WriteLine($"Response: {response}");

                        if (request == "exit")
                        {
                            Thread.Sleep(1000);
                            break;
                        }

                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"SocketException: {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error {ex.Message}");
                }
                finally
                {
                    tcpClient.Close();
                }
            }

        }
    }
}
