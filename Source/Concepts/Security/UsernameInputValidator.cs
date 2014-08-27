using Bifrost.Validation;
using FluentValidation;

namespace Concepts.Security
{
    public class UsernameInputValidator : InputValidator<Username>
    {
        public UsernameInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.Value)
                .NotEmpty().WithMessage(validationMessages.UsernameMustBeSpecified)
                .EmailAddress().WithMessage(validationMessages.UsernameMustBeEMail);

        }
    }
}
