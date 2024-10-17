using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HW_03_Server;

internal class Program
{


    static async Task Main(string[] args)
    {

        var Server = new RestaurantServer(8888);
        await Server.StartAsync();




    }
}

public class RestaurantServer
{
    private object _lock = new object();
    private TcpListener _tcpListener;
    private Queue<Order> _orders = new();

    public List<Dish> menu = new()
    {
        new Dish { Name = "Steak", TimeCook = TimeSpan.FromSeconds(5) },
        new Dish { Name = "Soup", TimeCook = TimeSpan.FromSeconds(5) },
        new Dish { Name = "Salad", TimeCook = TimeSpan.FromSeconds(3) },
        new Dish { Name = "Juice", TimeCook = TimeSpan.FromSeconds(2) },
    };

    public RestaurantServer(IPAddress ip, int port)
    {
        IPEndPoint endPoint = new IPEndPoint(ip, port);
        _tcpListener = new TcpListener(endPoint);
    }

    public RestaurantServer(int port)
    {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        //IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
        _tcpListener = new TcpListener(endPoint);
    }

    public async Task StartAsync()
    {
        try
        {
            _tcpListener.Start();
            Console.WriteLine($"Server started: {((IPEndPoint)_tcpListener.LocalEndpoint).Address}, {((IPEndPoint)_tcpListener.LocalEndpoint).Port}");

            Task.Run(() => ProcessOrdersAsync());  // Повар ждет заказа и готовит )))))

            while (true)
            {
                var tcpClient = await _tcpListener.AcceptTcpClientAsync();
                Console.WriteLine($"Connected: {tcpClient.Client.RemoteEndPoint}");
                Task.Run(async () => await ProcessClientAsync(tcpClient));

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            _tcpListener.Stop();
        }
    }

    private async Task ProcessClientAsync(TcpClient tcpClient)
    {
        using NetworkStream stream = tcpClient.GetStream();
        try
        {
            while (true)
            {
                // Считываем размер строки запроса
                byte[] sizeBuffer = new byte[4];
                int bytesRead = await stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);

                int size = BitConverter.ToInt32(sizeBuffer, 0);

                // Читаем сам запрос
                byte[] request = new byte[size];
                bytesRead = await stream.ReadAsync(request, 0, size);
                string message = Encoding.UTF8.GetString(request, 0, bytesRead);
                Console.WriteLine($"Request from {tcpClient.Client.RemoteEndPoint}: {message}");

                // Обработка запроса
                if (!string.IsNullOrEmpty(message))
                {
                    string response = RequestHandler(message);
                    Console.WriteLine($"Log Response: { response}");  // вывод ответа на сервере, мб убрать потом
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                    // отправка длины
                    byte[] responseSize = BitConverter.GetBytes(responseBytes.Length);
                    await stream.WriteAsync(responseSize, 0, responseSize.Length);

                    // отправляем ответ
                    await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                }

                if (message.ToLower() == "exit") break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error ProcessClientAsync {ex.Message}");
        }
        finally
        {
            // клиент закрывает соединение
            Console.WriteLine($"Client disconnected: {tcpClient.Client.RemoteEndPoint}");
            tcpClient.Close();
        }
    }

    // Обрабатывает запросы клиентов
    private string RequestHandler(string message)
    {
        if (message.ToLower() == "exit")
        {
            return "Disconnecting...";
        }

        else if (message.ToLower().StartsWith("status"))
        {
            var msgSplit = message.Split(' ');
            if (msgSplit.Length > 1 && int.TryParse(msgSplit[1], out int orderId))
            {
                return GetOrderStatus(orderId);
            }
            else
            {
                return "Invalid Status Request.";
            }
        }

        else if (message.ToLower().StartsWith("cancel"))
        {
            var msgSplit = message.Split(' ');
            if (msgSplit.Length > 1 && int.TryParse(msgSplit[1], out int orderId))
            {
                return CancelOrder(orderId);
            }
            else
            {
                return "Invalid Cancelleation Request.";
            }
        }

        else
        {
            return CreateOrder(message);
        }

    }

    private string CreateOrder(string message)
    {
        string[] dishNames = message.Split(',');
        List<Dish> dishOrderList = new();
        foreach (string el in dishNames)
        {
            Dish dish = menu.FirstOrDefault(e => e.Name.ToLower() == el.ToLower());
            if (dish != null)
            {
                dishOrderList.Add(dish);
            }
            else
            {
                return $"Dish '{el}' not found on the menu.";
            }
        }
        if (dishOrderList.Count == 0)
        {
            return "No valid dishes to order.";
        }

        Order order = new Order(dishOrderList.ToArray());
        order.EstimatedTime = TimeSpan.FromSeconds(dishOrderList.Sum(d => d.TimeCook.TotalSeconds));
        lock(_lock)
        {
            _orders.Enqueue(order);
        }
        return $"Order created. OrderId = {order.Id},  ";
    }


    private string GetOrderStatus(int orderId)
    {
        foreach (var order in _orders)
        {
            if (order.Id == orderId)
            {
                return $"Order {order.Id}: , Status: {order.Status}, Estimated Time: {order.EstimatedTime}, Dishes: {string.Join(", ", order.Dishes.Select(d => d.Name))}";
            }
        }
        return $"Order with ID '{orderId}' not found to check status.";
    }

    private string CancelOrder(int orderId)
    {
        lock (_lock)
        {
            foreach(var order in _orders)
            {
                if(order.Id == orderId)
                {
                    if(order.Status == OrderStatus.InProgress)
                    {
                        return $"Order {orderId} status is {order.Status} you cant cancel it.";
                    }
                    order.Status = OrderStatus.Cancelled;
                    return $"Order {orderId}  cancelled";
                }
            }
            return $"Order with ID '{orderId}' not found to cancel.";
        }
    }

    // Тут повар ждет и готовит заказы
    private async Task ProcessOrdersAsync()
    {
        while (true)
        {
            if (_orders.Count > 0)
            {
                var currentOrder = _orders.Peek();
                if (currentOrder.Status == OrderStatus.Cancelled)
                {
                    _orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Preparing order {currentOrder.Id}, EstimatedTime:{currentOrder.EstimatedTime}");
                    currentOrder.Status = OrderStatus.InProgress;
                    // Приготовление Ордера по вермени
                    await Task.Delay(currentOrder.EstimatedTime);
                    currentOrder.Status = OrderStatus.Completed;
                    Console.WriteLine($"Order {currentOrder.Id}: is ready: ");
                    foreach (var dish in currentOrder.Dishes)
                    {
                        Console.WriteLine(dish.Name);
                    }
                    Console.WriteLine();
                    _orders.Dequeue();
                }
            }
            else
            {
                await Task.Delay(1000);
            }
        }
    }

}