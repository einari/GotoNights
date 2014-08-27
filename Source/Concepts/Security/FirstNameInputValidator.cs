using Bifrost.Validation;
using FluentValidation;

namespace Concepts.Security
{
    public class FirstNameInputValidator : InputValidator<FirstName>
    {
        public FirstNameInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.Value)
                .NotEmpty().WithMessage(validationMessages.FirstNameMustBeSpecified);
        }
    }
}
