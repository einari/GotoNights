using System;
using Bifrost.Domain;
using Concepts;
using Concepts.Security;
using Events.Security.Management;

namespace Domain.Security.Management
{
    public class User : AggregateRoot
    {
        public User(Guid id) : base(id) { }

        public void Create(FirstName firstName, LastName lastName, Username username, Password password, bool isAdmin)
        {
            Apply(new UserCreated(Id)
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                IsAdmin = isAdmin
            });
        }

        public void ResetPassword(Password password)
        {
            Apply(new PasswordReset(Id)
            {
                Password = password
            });
        }
    }
}
