using BusinessLayer.BusinessObject;
using FluentValidation;
using SalesWFPApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.Validator
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(vm => vm.ProductName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(vm => vm.Weight).NotEmpty().WithMessage("Weight is required.");
            RuleFor(vm => vm.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
            RuleFor(vm => vm.UnitsInStock).GreaterThanOrEqualTo(0).WithMessage("Units in stock must be a non-negative number.");
            RuleFor(vm => vm.CategoryId).NotNull().WithMessage("CategoryId is required.");
        }
    }
}
