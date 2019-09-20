using Santander.WebApi.Models;
using Santander.WebApi.Models.SearchCriterias;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Customer Get(string username);

        // ICollection<Customer> Get(string city, string street);

        ICollection<Customer> Get(CustomerSearchCriteria criteria);
        Customer Authorize(string username, string hashpassword);
    }
}
