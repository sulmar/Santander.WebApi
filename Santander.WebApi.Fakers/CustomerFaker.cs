using Bogus;
using Santander.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.Fakers
{

    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            StrictMode(true);
            UseSeed(1);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => Convert.ToDecimal(f.Commerce.Price()));
            RuleFor(p => p.Barcode, f => f.Commerce.Ean8());
        }
    }

    // Install-Package Bogus
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            StrictMode(true);
            UseSeed(1);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
            // Ignore(p => p.UserName);
            RuleFor(p => p.UserName, f => f.Person.UserName);
            RuleFor(p => p.Email, (f, c) => String.Format("{0}.{1}@santander.pl", c.FirstName, c.LastName));
        }
    }
}
