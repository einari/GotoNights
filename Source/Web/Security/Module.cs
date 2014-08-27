using System.Linq;
using Bifrost.Read;
using Concepts.Security;
using Infrastructure.Security;
using Ninject;
using Ninject.Modules;
using Read.Security;
using Web.Security.Authentication;

namespace Web.Security
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IAuthenticationManager>().To<AuthenticationManager>();
        }
    }
}