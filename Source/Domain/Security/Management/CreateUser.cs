using Bifrost.Commands;
using Concepts;
using Concepts.Security;

namespace Domain.Security.Management
{
    public class CreateUser : Command
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Username Username { get; set; }
        public Password Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
