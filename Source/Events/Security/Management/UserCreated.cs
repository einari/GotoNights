using System;
using Bifrost.Events;

namespace Events.Security.Management
{
    public class UserCreated : Event
    {
        public UserCreated(Guid eventSourceId) : base(eventSourceId) { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class PasswordReset : Event
    {
        public PasswordReset(Guid eventSourceId) : base(eventSourceId) { }
        public string Password { get; set; }
    }
}
