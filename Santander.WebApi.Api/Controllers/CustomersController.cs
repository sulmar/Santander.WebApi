using Santander.WebApi.FakeRepositories;
using Santander.WebApi.Fakers;
using Santander.WebApi.IRepositories;
using Santander.WebApi.Models;
using Santander.WebApi.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Santander.WebApi.Api.Controllers
{

    // Install-Package Microsoft.AspNet.WebApi

    [Authorize(Roles = "Administrator,Developer")]
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository customerRepository;

        //public CustomersController()
        //    : this(new FakeCustomerRepository(new CustomerFaker()))
        //{

        //}

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Route()]
        public IHttpActionResult Get([FromUri] CustomerSearchCriteria criteria)
        {

            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            if (this.User.IsInRole("Administrator"))
            {

            }

            var claim =  ((ClaimsIdentity)this.User.Identity).FindFirst(ClaimTypes.Email);

            if (claim != null)
            {
               string email = claim.Value;

                // TODO: send email
                Trace.WriteLine(String.Format("Sending email to {0}", email));
            }

            ICollection<Customer> customers;

            if (criteria != null)
                customers = customerRepository.Get(criteria);
            else
                customers = customerRepository.Get();

            return Ok(customers);

        }
        

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var customer = customerRepository.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            var customer = customerRepository.Get(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);

        }



    }
}