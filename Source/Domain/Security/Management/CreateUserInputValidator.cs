using Bifrost.Validation;
using Concepts.Security;
using FluentValidation;

namespace Domain.Security.Management
{
    public class CreateUserInputValidator : CommandInputValidator<CreateUser>
    {
        public CreateUserInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.FirstName)
                .NotNull()
                .SetValidator(new FirstNameInputValidator(validationMessages));
            RuleFor(l => l.LastName)
                .NotNull()
                .SetValidator(new LastNameInputValidator(validationMessages));
            RuleFor(l => l.Username)
                .NotNull()
                .SetValidator(new UsernameInputValidator(validationMessages));
            RuleFor(l => l.Password)
                .NotNull()
                .SetValidator(new PasswordInputValidator(validationMessages));
        }
    }
}
