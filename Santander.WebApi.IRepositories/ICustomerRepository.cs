using Santander.WebApi.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Customer Get(string username);
    }
}
