using System;
using Bifrost.Commands;
using Concepts.Security;

namespace Domain.Security.Authentication
{
    public class Login : Command
    {
        public Guid Context { get; set; }
        public Username Username { get; set; }
        public Password Password { get; set; }
    }
}
