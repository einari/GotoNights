using System;
using System.Web.Security;
using Web.Security.Authentication;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {                
                var userInfo = UserInfo.GetFromCurrentContext();
                Context.User = userInfo.Principal;
            }
        }
    }
}