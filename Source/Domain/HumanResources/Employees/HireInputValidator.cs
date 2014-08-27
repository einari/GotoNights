using Bifrost.Validation;
using FluentValidation;

namespace Domain.HumanResources.Employees
{
    public class HireInputValidator : CommandInputValidator<Hire>
    {
        public HireInputValidator()
        {
            RuleFor(h => h.FirstName).NotEmpty();
            RuleFor(h => h.LastName).NotEmpty();
            RuleFor(h => h.SocialSecurityNumber).NotEmpty();
        }
    }
}
