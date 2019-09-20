using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.Receiver
{
    // Microsoft.AspNet.SignalR.Client
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string url = "http://localhost:5000";


            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("Signal-R Client starting...");

            var connection = new HubConnection(url);
            connection.TraceLevel = TraceLevels.All;
            connection.TraceWriter = Console.Out;

            IHubProxy proxy = connection.CreateHubProxy("JobsHub");

            Console.WriteLine("connecting...");

            await connection.Start();

            Console.WriteLine("connected.");


            proxy.On<string>("SendMessage", message => Console.WriteLine(message));


            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();

            Console.ResetColor();
        

        }
    }
}
