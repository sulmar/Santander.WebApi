﻿using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Santander.WebApi.SelfHostApi
{
    // Install-Package Microsoft.AspNet.WebApi.OwinSelfHost
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:5000";

            Console.WriteLine("Starting service {0}", url);

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
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
                );


            app.UseWebApi(config);
        }
    }
}
