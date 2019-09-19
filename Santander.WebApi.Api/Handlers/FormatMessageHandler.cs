using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Santander.WebApi.Api.Handlers
{

    // api/customers?format=aplication/xml
    public class FormatMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var parameters = request.GetQueryNameValuePairs();

            var keyvalue = parameters.FirstOrDefault(s => s.Key == "format");

            if (keyvalue.Value != null)
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(keyvalue.Value, 1));
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}