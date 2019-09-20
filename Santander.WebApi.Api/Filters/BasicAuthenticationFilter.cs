using Santander.WebApi.Api.ActionResults;
using Santander.WebApi.IRepositories;
using Santander.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace Santander.WebApi.Api.Filters
{
    public class BasicAuthenticationFilter : IAuthenticationFilter
    {

        private readonly ICustomerRepository customerRepository;

        public BasicAuthenticationFilter(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public bool AllowMultiple
        {
            get { return false; }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authorization = context.Request.Headers.Authorization;

            if (authorization == null)
                return;

            if (authorization.Scheme != "Basic")
                return;


            var credentialBytes = Convert.FromBase64String(authorization.Parameter);

            string[] credentials = Encoding.ASCII.GetString(credentialBytes).Split(':');


            Customer customer = customerRepository.Authorize(credentials[0], credentials[1]);

            if (customer==null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Username or  password is invalid", context.Request);
                return;
            }


            //IIdentity identity = new GenericIdentity(customer.FullName);

            //IPrincipal principal = new GenericPrincipal(identity, null);


            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim(ClaimTypes.Name, customer.FullName),

                new Claim(ClaimTypes.Role, "Developer"),
                new Claim(ClaimTypes.Role, "Administrator")

            };

            IIdentity identity = new ClaimsIdentity(claims, "Basic");
            IPrincipal principal = new ClaimsPrincipal(identity);

            context.Principal = principal;

        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);

            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic"));
            }

            context.Result = new ResponseMessageResult(result);
        }
    }
}