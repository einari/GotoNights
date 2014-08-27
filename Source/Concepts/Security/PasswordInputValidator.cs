using Bifrost.Validation;
using FluentValidation;

namespace Concepts.Security
{
    public class PasswordInputValidator : InputValidator<Password>
    {
        public PasswordInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.Value)
                .NotEmpty().WithMessage(validationMessages.PasswordMustBeSpecified);
        }
    }
}
