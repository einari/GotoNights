using System;
using System.Web.SessionState;
using Infrastructure.Security;

namespace Web.Security.Authentication
{
    public static class SessionSecurityExtensions
    {
        const string UserLoggedInKey = "UserLoggedIn";
        const string SecurityContextKey = "Security Context Key";

        public static void UserNotLoggedIn(this HttpSessionState session)
        {
            session[UserLoggedInKey] = false;
        }

        public static void UserLoggedIn(this HttpSessionState session)
        {
            session[UserLoggedInKey] = true;
        }

        public static bool IsUserLoggedIn(this HttpSessionState session)
        {
            var loggedIn = session[UserLoggedInKey];
            if (loggedIn == null) return false;

            if (((bool)loggedIn) == true) return true;

            return false;
        }

        public static void SetContext(this HttpSessionState session, IAuthenticationContext context)
        {
            session[SecurityContextKey] = context;
        }

        public static AuthenticationContext GetContext(this HttpSessionState session)
        {
            var context = session[SecurityContextKey] as AuthenticationContext;
            if (context == null) throw new ArgumentException("No authentication context in session");
            return context;
        }
    }
}
