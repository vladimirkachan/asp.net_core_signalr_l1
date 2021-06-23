using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalR_Client
{
    class Program
    {
        static HubConnection connection;

        static async Task Main(string[] args)
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:27310/notification").Build();
            connection.On<string>("Send", message => Console.WriteLine($"Message from server: {message}"));
            await connection.StartAsync();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q") return;
                await connection.SendAsync("SendMessage", input);
            }
        }
    }
}
