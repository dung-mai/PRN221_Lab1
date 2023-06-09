using FluentValidation;
using SalesWFPApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.Validator
{
    public class OrderViewModelValidator : AbstractValidator<ViewOrderDetailViewModel>
    {
        public OrderViewModelValidator()
        {
            RuleFor(vm => vm.OrderDate).NotEmpty().WithMessage("OrderDate is required.");
            RuleFor(vm => vm.ShippedDate).GreaterThan(vm => vm.OrderDate).WithMessage("Shipped date must be after order date.");
            RuleFor(vm => vm.OrderDate).LessThan(vm => vm.ShippedDate).WithMessage("Order date must be before Shipped date.");
            RuleFor(vm => vm.Freight).GreaterThanOrEqualTo(0).WithMessage("Freight cannot < 0.");
        }
    }
}
