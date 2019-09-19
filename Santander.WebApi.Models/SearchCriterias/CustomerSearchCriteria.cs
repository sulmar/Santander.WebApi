using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.WebApi.Models.SearchCriterias
{
    public abstract class SearchCriteria
    {

    }

    public class CustomerSearchCriteria : SearchCriteria
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
