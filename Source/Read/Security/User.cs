using Bifrost.Read;
using Concepts;
using Concepts.Security;

namespace Read.Security
{
    public class User : IReadModel
    {
        public UserId Id { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Username Name { get; set; }
        public Password Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
