using FluentValidation;
using SalesWFPApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.Validator
{
    public class MemberViewModelValidator : AbstractValidator<MemberViewModel>
    {
        public MemberViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(vm => vm.Email).EmailAddress().WithMessage("Not a valid email.");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(vm => vm.Password).Length(6,20).WithMessage("Password length must be from 6 to 20 character.");
            RuleFor(vm => vm.City).NotEmpty().WithMessage("City is required.");
            RuleFor(vm => vm.CompanyName).NotEmpty().WithMessage("CompanyName is required.");
            RuleFor(vm => vm.Country).NotEmpty().WithMessage("Country is required.");
        }
    }
}
