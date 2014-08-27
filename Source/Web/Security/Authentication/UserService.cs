using System.Web;
using System.Web.Security;
using Bifrost.Commands;
using Bifrost.Configuration;
using Domain.Security.Management;
namespace Web.Security.Authentication
{
    public class UserService
    {
        public object GetCurrent()
        {
            var userInfo = UserInfo.GetFromCurrentContext();
            return new
            {
                Name = userInfo.Name,
                IsLoggedIn = userInfo.IsLoggedIn,
                Roles = userInfo.Roles,
                Cookie = userInfo.Cookie,
                CookieName = userInfo.CookieName
            };
        }

        public void Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
            FormsAuthentication.SignOut();
        }

        public void InsertDefault()
        {
            var commandCoordinator = Configure.Instance.Container.Get<ICommandCoordinator>();
            var command = new CreateUser {
                FirstName = "Einar",
                LastName = "Ingebrigtsen",
                Username = "einar@dolittle.com",
                Password = "1234Abcd",
                IsAdmin = true
            };
            var result = commandCoordinator.Handle(command);

        }
    }
}