using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Dtos.ProductDtos
{
    public class ProductEditDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
    }

    public class ProductEditDtoValidator:AbstractValidator<ProductEditDto>
    {
        public ProductEditDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).MinimumLength(2);
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BrandId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(x => x.CostPrice);
        }
    }
}
