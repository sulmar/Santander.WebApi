using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Santander.WebApi.Api.Constraints
{
    public class ColorConstraint : IHttpRouteConstraint
    {

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;

            if (values.TryGetValue(parameterName, out value))
            {
                string color = (string)value;

                return System.Drawing.Color.FromName(color).IsKnownColor;

            }

            return false;
        }
    }
}