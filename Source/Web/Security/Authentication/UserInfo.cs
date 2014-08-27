using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Web.Security.Authentication
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string[] Roles { get; set; }
        public bool IsLoggedIn { get; set; }
        public IPrincipal Principal { get; set; }
        public string Cookie { get; set; }
        public string CookieName { get; set; }
        

        public static UserInfo GetFromCurrentContext()
        {
            var userInfo = new UserInfo
            {
                Name = "Not logged in",
                Roles = new string[0],
                IsLoggedIn = false,
                Principal = null,
                Cookie = string.Empty
            };


            FormsAuthenticationTicket ticket;

            var isLoggedIn = false;

            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                userInfo.Cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                ticket = FormsAuthentication.Decrypt(userInfo.Cookie);
                isLoggedIn = true;
            }
            else
            {
                var context = HttpContext.Current.Session.GetContext();
                ticket = context.Ticket;
                userInfo.Cookie = context.CookieAsString;
                if( HttpContext.Current.Session.IsUserLoggedIn() ) isLoggedIn = true;
            }

            if (isLoggedIn)
            {
                var id = new FormsIdentity(ticket);
                userInfo.CookieName = FormsAuthentication.FormsCookieName;
                userInfo.Roles = ticket.UserData.Split(';');
                userInfo.IsLoggedIn = true;
                userInfo.Principal = new GenericPrincipal(id, userInfo.Roles);
                userInfo.Name = userInfo.Principal.Identity.Name;
            }

            return userInfo;
        }
    }
}