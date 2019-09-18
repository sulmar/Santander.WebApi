using Bogus;
using Santander.WebApi.IRepositories;
using Santander.WebApi.Models;
using System;
using System.Collections.Generic;

namespace Santander.WebApi.FakeRepositories
{
    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ICollection<TEntity> entities;
        private Faker<TEntity> entityFaker;

        public FakeEntityRepository()
        {
            entityFaker = new Faker<TEntity>();

            entities = entityFaker.Generate(100);
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual ICollection<TEntity> Get()
        {
            return entities;
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
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
