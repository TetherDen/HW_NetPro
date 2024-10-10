using System.Net.Sockets;
using System.Text;
internal class Program
{
    static async Task Main()
    {

        // Task 1
        //Разработайте набор консольных приложений. 
        //Первое приложение: серверное приложение, которое на запросы клиента возвращает текущее время или дату на сервере. 
        //Второе приложение: клиентское приложение, запрашивающее дату или время.
        //Пользователь с клавиатуры определяет, что нужно запросить. После отсылки даты или времени сервер разрывает соединение. Клиентское приложение отображает полученные данные.

        //==================================

        //  Task 2
        //Создайте сервер, который принимает запрос от клиента, вычисляет квадратный корень числа, отправленного клиентом, и возвращает результат


        while (true)
        {
            Console.WriteLine($"\nRequest to server: (time,date, (int)number or exit)");
            string request = Console.ReadLine();
            if(request.ToLower() == "exit")
                break;
            ConnectToServer(request);   // Будет постоянно коннектиться и передавать запрос, надо будет сделать решение.

        }
    }
    static void ConnectToServer(string request)
    {
        try
        {
            TcpClient client = new TcpClient("127.0.0.1", 8888);
            Console.WriteLine("Подключено к серверу...");

            NetworkStream stream = client.GetStream();

            byte[] data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);


            data = new byte[512];
            StringBuilder response = new StringBuilder();
            int bytes;

            do
            {
                bytes = stream.Read(data, 0, data.Length);
                response.Append(Encoding.UTF8.GetString(data, 0, bytes));
            } while (stream.DataAvailable);

            Console.WriteLine($"Server response: {response}");

            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}

