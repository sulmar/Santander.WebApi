using Bogus;
using Santander.WebApi.Fakers;
using Santander.WebApi.IRepositories;
using Santander.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Santander.WebApi.FakeRepositories
{
    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(ProductFaker faker) : base(faker)
        {
        }

        public Product Get(string name)
        {
            return entities.SingleOrDefault(p => p.Name == name);
        }

        public ICollection<Product> GetByColor(string color)
        {
            return entities.Where(e => e.Color == color).ToList();
        }
    }
    

    /*

    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly ICollection<Customer> customers;

        private readonly CustomerFaker customerFaker;

        public FakeCustomerRepository()
        {

            customerFaker = new CustomerFaker();

            customers = customerFaker.Generate(100);
        }

        public void Add(Customer entity)
        {
            customers.Add(entity);
        }

        private IQueryable<Customer> ActiveCustomers
        {
            get
            {
                return customers.Where(c => !c.IsRemoved).AsQueryable();
            }
        }

        public ICollection<Customer> Get()
        {
            return ActiveCustomers.OrderBy(c=>c.FirstName).ToList();
        }

        public Customer Get(int id)
        {
            return ActiveCustomers.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string username)
        {
            return ActiveCustomers.SingleOrDefault(c => c.UserName == username);
        }
    }

    */
}
