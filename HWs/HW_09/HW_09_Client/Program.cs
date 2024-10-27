using static HW_09_Client.Program;
using Microsoft.AspNetCore.SignalR.Client;

namespace HW_09_Client;

internal class Program
{
    HubConnection connection;
    static async Task Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");

        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7134/rate")
            .WithAutomaticReconnect()
            .Build();


        connection.On<string>("Receive", (message) =>
        {
            Console.WriteLine($"Received update: {message}");
        });

        Console.WriteLine("Starting...");
        await connection.StartAsync();



        Console.ReadLine();

    }

}
