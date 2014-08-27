using Bifrost.Validation;
using Concepts.Security;
using FluentValidation;
using Rules.Security.Management;

namespace Domain.Security.Management
{
    public class CreateUserBusinessValidator : CommandBusinessValidator<CreateUser>
    {
        readonly UsernameIsUnique _usernameIsUnique;

        public CreateUserBusinessValidator(ValidationMessages validationMessages, UsernameIsUnique usernameIsUnique)
        {
            _usernameIsUnique = usernameIsUnique;
            RuleFor(u => u.Username).Must(BeAUniqueUsername).WithMessage(validationMessages.UserNameMustBeUnique);
        }

        bool BeAUniqueUsername(Username username)
        {
            return _usernameIsUnique(username);
        }
    }
}