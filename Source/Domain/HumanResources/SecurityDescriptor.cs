using Bifrost.Security;
using Bifrost.Commands;

namespace Domain.HumanResources
{
    public class SecurityDescriptor : BaseSecurityDescriptor
    {
        public SecurityDescriptor()
        {
            When.Handling().Commands().InNamespace("Domain.HumanResources", n => n.User().MustBeInRole("admin"));
        }
    }
}
