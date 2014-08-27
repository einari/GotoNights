using Bifrost.Validation;
using FluentValidation;

namespace Concepts.Security
{
    public class LastNameInputValidator : InputValidator<LastName>
    {
        public LastNameInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.Value)
                .NotEmpty().WithMessage(validationMessages.LastNameMustBeSpecified);
        }
    }
}
