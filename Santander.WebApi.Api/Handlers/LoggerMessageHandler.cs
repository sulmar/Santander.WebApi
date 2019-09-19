using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Santander.WebApi.Api.Handlers
{
    public class LoggerMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            Trace.WriteLine(string.Format("request: {0} - {1}", request.Method, request.RequestUri));

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Trace.WriteLine(string.Format("response: {0}", response.StatusCode));

            return response;
        }
    }
}