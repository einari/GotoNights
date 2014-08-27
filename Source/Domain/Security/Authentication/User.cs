using System;
using Bifrost.Domain;
using Events.Security.Authentication;

namespace Domain.Security.Authentication
{
    public class User : AggregateRoot
    {
        public User(Guid id)
            : base(id)
        {
        }

        public void Login(Guid context)
        {
            Apply(new LoggedIn(Id) { Context = context });
        }

        public void Fail()
        {
        }

    }
}
