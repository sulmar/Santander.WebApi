using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.Sender
{
    // Install-Package Microsoft.AspNet.SignalR.Client
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

       static async Task MainAsync(string[] args)
        {
            string url = "http://localhost:5000";


            Console.BackgroundColor = ConsoleColor.Blue;

            Console.WriteLine("Signal-R Client starting...");

            var connection = new HubConnection(url);
            connection.TraceLevel = TraceLevels.All;
            connection.TraceWriter = Console.Out;

            IHubProxy proxy = connection.CreateHubProxy("JobsHub");

            Console.WriteLine("connecting...");

            await connection.Start();

            Console.WriteLine("connected.");

           

            string message;
            int index = 0;

            do
            {

                message = String.Format("Hello {0}", index++);

              //  message = Console.ReadLine();

                Console.WriteLine("sending...");
                await proxy.Invoke<string>("Send", message);
                Console.WriteLine("sent.");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            while (message != "q");


            Console.ResetColor();
;

        }
    }
}
