using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Santander.WebApi.RawApi
{

    // Install-Package  Microsoft.Owin.Host.SystemWeb
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Use(async (context, next) =>
            {
                Trace.WriteLine(String.Format("request: {0} - {1}", context.Request.Method, context.Request.Path));

                await next();

                Trace.WriteLine(String.Format("response: {0}", context.Response.StatusCode));

            });


           //  app.Use(typeof(LoggerMiddleware));


          app.Use<LoggerMiddleware>();

           

            // sensors/temp
            // sensors/humidity


            app.Map("/sensors", node =>
            {
                node.Map("/temp", TempDelegate);
                node.Map("/humidity", HumidityDelegate);
                node.Map(string.Empty, SensorsDelegate);
            });


            app.MapWhen(context => context.Request.Headers.Get("Host").StartsWith("localhost"), LocalHostDelegate);


           // app.Map("/sensors", SensorsDelegate);
            //app.Use(async (context, next) =>
            //{
            //    Trace.WriteLine(String.Format("request 2 : {0} - {1}", context.Request.Method, context.Request.Path));


            //    if (false)
            //    {
            //        await next();

            //    }
            //    else
            //    {
            //        context.Response.StatusCode = 404;

            //    }


            //    Trace.WriteLine(String.Format("response 2 : {0}", context.Response.StatusCode));

            //});

            app.Run(async context => await context.Response.WriteAsync("Hello World"));
        }

        private void LocalHostDelegate(IAppBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("localhost"));
        }

        private void HumidityDelegate(IAppBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("1024 hPa"));
        }

        private void TempDelegate(IAppBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Temp 23C"));
        }

        private void SensorsDelegate(IAppBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Hello Sensors"));
        }
    }
}