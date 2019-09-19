using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Santander.WebApi.RawApi
{
    public class LoggerMiddleware : OwinMiddleware
    {
        public LoggerMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            Trace.WriteLine(String.Format("request: {0} - {1}", context.Request.Method, context.Request.Path));

            await this.Next.Invoke(context);

            Trace.WriteLine(String.Format("response: {0}", context.Response.StatusCode));

        }
    }
}