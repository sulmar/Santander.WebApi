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
    [RoutePrefix("api/products")]
    [Authorize]
    public class ProductsController :  ApiController
    {
        private readonly IProductRepository productRepository;

        //public ProductsController()
        //    : this(new FakeProductRepository(new ProductFaker()))
        //{

        //}

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [Route]
        public IHttpActionResult Get()
        {
            var products = productRepository.Get();

            return Ok(products);
        }

        //[HttpGet]
        //[Route("{id:color}")]
        //public IHttpActionResult GetByColor(string id)
        //{
        //    var product = productRepository.GetByColor(id);

        //    return Ok(product);
        //}

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetByName(string id)
        {
            var product = productRepository.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Product product)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(ModelState);

            productRepository.Add(product);

            return Ok();
        }
    }
}