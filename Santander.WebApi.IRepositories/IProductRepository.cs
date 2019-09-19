using Santander.WebApi.Models;
using System.Collections;
using System.Collections.Generic;

namespace Santander.WebApi.IRepositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        ICollection<Product> GetByColor(string color);
        Product Get(string name);
    }
}
