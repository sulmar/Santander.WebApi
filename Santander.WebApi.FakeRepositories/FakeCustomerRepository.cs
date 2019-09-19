using Santander.WebApi.Fakers;
using Santander.WebApi.IRepositories;
using Santander.WebApi.Models;
using Santander.WebApi.Models.SearchCriterias;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.FakeRepositories
{

    public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
    {
        public FakeCustomerRepository(CustomerFaker faker) : base(faker)
        {
        }

        private IQueryable<Customer> ActiveCustomers
        {
            get
            {
                return entities.Where(c => !c.IsRemoved).AsQueryable();
            }
        }

        public override ICollection<Customer> Get()
        {
            return ActiveCustomers.ToList();
        }

        public override Customer Get(int id)
        {
            return ActiveCustomers.SingleOrDefault(c => c.Id == id);
        }

        public Customer Get(string username)
        {
            return entities.SingleOrDefault(e => e.UserName == username);
        }

        public ICollection<Customer> Get(CustomerSearchCriteria criteria)
        {
            IQueryable<Customer> results = ActiveCustomers;

            if (!string.IsNullOrEmpty(criteria.City))
                results = results.Where(c => c.City == criteria.City);

            if (!string.IsNullOrEmpty(criteria.Street))
                results = results.Where(c => c.Street == criteria.Street);

            return results.ToList();

        }

        public override void Remove(int id)
        {
            Customer customer = Get(id);

            customer.IsRemoved = true;
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
