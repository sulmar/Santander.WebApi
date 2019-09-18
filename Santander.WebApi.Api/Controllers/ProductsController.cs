using Santander.WebApi.FakeRepositories;
using Santander.WebApi.Fakers;
using Santander.WebApi.IRepositories;
using Santander.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Santander.WebApi.Api.Controllers
{
    public class ProductsController :  ApiController
    {
        private readonly IProductRepository productRepository;

        public ProductsController()
            : this(new FakeProductRepository(new ProductFaker()))
        {

        }

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var products = productRepository.Get();

            return Ok(products);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Product product)
        {
            productRepository.Add(product);

            return Ok();
        }
    }
}