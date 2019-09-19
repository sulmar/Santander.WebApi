using FluentValidation.Attributes;
using Santander.WebApi.Models.Validators;

namespace Santander.WebApi.Models
{
    // Install-Package FluentValidation.ValidatorAttribute
    [Validator(typeof(ProductValidator))]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public string Barcode { get; set; }
    }
}
