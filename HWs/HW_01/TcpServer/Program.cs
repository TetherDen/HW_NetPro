using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        StartServer();
        Console.ReadLine();
    }

    public static void StartServer()
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8888;
        TcpListener listener = new TcpListener(ipAddress, port);

        try
        {
            listener.Start();
            Console.WriteLine("Сервер запущен...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Новый клиент подключен.");

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[512];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer,0,bytesRead).ToLower();


                // Достаем EndPoint Клиента
                IPEndPoint clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                string clientInfo = clientEndPoint != null ? $"{clientEndPoint.Address}:{clientEndPoint.Port}" : "Неизвестный клиент";


                Console.WriteLine($"From client: {clientInfo} \nRequest: {request}");   // Надо сделать красиво


                string response = null;

                if(request == "time")
                {
                    response = DateTime.Now.ToLongTimeString();
                }
                else if (request == "date")
                {
                    response= DateTime.Now.ToLongDateString();
                }
                else if (double.TryParse(request, out double num ))
                {
                    response = Math.Sqrt(num).ToString();
                }
                else
                {
                    response = "Invalid request";
                }

                byte[] data = Encoding.UTF8.GetBytes(response);
                stream.Write(data, 0, data.Length);

                client.Close();   
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        finally
        {
            listener.Stop();
        }
    }
}
