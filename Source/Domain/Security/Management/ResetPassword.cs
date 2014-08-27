using Bifrost.Commands;
using Concepts;
using Concepts.Security;

namespace Domain.Security.Management
{
    public class ResetPassword : Command
    {
        public UserId UserId { get; set; }
        public Password NewPassword { get; set; }
    }
}