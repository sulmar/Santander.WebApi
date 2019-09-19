using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.Models
{

    public class Customer : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsRemoved { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }
}
