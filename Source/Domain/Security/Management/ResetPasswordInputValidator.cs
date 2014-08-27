using Bifrost.Validation;
using Concepts.Security;
using FluentValidation;

namespace Domain.Security.Management
{
    public class ResetPasswordInputValidator : CommandInputValidator<ResetPassword>
    {
        public ResetPasswordInputValidator(ValidationMessages validationMessages)
        {
            RuleFor(l => l.UserId)
                .NotEmpty();
            RuleFor(l => l.NewPassword)
                .NotNull()
                .SetValidator(new PasswordInputValidator(validationMessages));
        }
    }
}