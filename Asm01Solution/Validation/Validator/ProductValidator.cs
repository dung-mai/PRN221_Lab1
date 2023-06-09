using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validator
{
    public class ProductValidator : Abstact
    {
        RuleFor(vm => vm.ProductName).NotEmpty().WithMessage("Product name is required.");
        RuleFor(vm => vm.Weight).GreaterThanOrEqualTo(0).WithMessage("Weight must be a non-negative number.");
        RuleFor(vm => vm.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        RuleFor(vm => vm.UnitsInStock).GreaterThanOrEqualTo(0).WithMessage("Units in stock must be a non-negative number.");

        RuleFor(vm => vm.StartDate).NotNull().WithMessage("Start date is required.");
        RuleFor(vm => vm.EndDate).NotNull().WithMessage("End date is required.");
        RuleFor(vm => vm.EndDate).GreaterThan(vm => vm.StartDate).WithMessage("End date must be after start date.");
    }
}
