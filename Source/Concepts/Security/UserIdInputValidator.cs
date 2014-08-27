using Bifrost.Validation;
using FluentValidation;

namespace Concepts.Security
{
    public class UserIdInputValidator : InputValidator<UserId>
    {
        public UserIdInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.Value)
                .NotEmpty().WithMessage(validationMessages.UserIdCannotBeEmpty);

        }
    }
}