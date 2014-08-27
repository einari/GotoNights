using Bifrost.Validation;
using Concepts.Security;

namespace Domain.Security.Authentication
{
    public class LoginInputValidator : CommandInputValidator<Login>
    {
        public LoginInputValidator(Concepts.Security.ValidationMessages validationMessages)
        {
            RuleFor(l => l.Username).SetValidator(new UsernameInputValidator(validationMessages));
            RuleFor(l => l.Password).SetValidator(new PasswordInputValidator(validationMessages));
        }
    }
}
