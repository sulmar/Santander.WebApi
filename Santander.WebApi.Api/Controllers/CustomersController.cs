using Santander.WebApi.FakeRepositories;
using Santander.WebApi.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Santander.WebApi.Api.Controllers
{

    // Install-Package Microsoft.AspNet.WebApi

    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController()
            : this(new FakeCustomerRepository())
        {

        }

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Route()]
        public IHttpActionResult Get()
        {
            var customers = customerRepository.Get();

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