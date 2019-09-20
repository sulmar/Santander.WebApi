using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.SignalRSelfHost
{
    class Program
    {
        // Install-Package Microsoft.AspNet.WebApi.OwinSelfHost
        // Install-Package Microsoft.AspNet.SignalR
        static void Main(string[] args)
        {

            string url = "http://localhost:5000";

            Console.WriteLine("Starting hub {0}", url);

            using (WebApp.Start<Startup>(url: url))
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

        }
    }

}
