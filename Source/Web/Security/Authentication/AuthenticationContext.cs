using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Infrastructure.Security;

namespace Web.Security.Authentication
{
    public class AuthenticationContext : IAuthenticationContext
    {
        HttpSessionState _session;

        public AuthenticationContext(Guid userId, string username, bool isUserNameValid, bool isPasswordValid, bool isAdmin)
        {
            _session = HttpContext.Current.Session;
            _session.UserNotLoggedIn();

            UserId = userId;
            IsUsernameValid = isUserNameValid;
            IsPasswordValid = isPasswordValid;
            Username = username;
            IsAdmin = isAdmin;

            InitializeRoles();

            Ticket = new FormsAuthenticationTicket(1, Username,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(30),
                                false, GetRolesAsString());
            CookieAsString = FormsAuthentication.Encrypt(Ticket);
        }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public bool IsUsernameValid { get; private set; }
        public bool IsPasswordValid { get; private set; }
        public bool IsAdmin { get; private set; }

        public string[] Roles { get; private set; }

        public FormsAuthenticationTicket Ticket { get; private set; }
        public string CookieAsString { get; private set; }

        public void LoggedIn()
        {
            _session.UserLoggedIn();
        }

        void InitializeRoles()
        {
            var roles = new List<string>();
            roles.Add("user");
            if (IsAdmin) roles.Add("admin");

            Roles = roles.ToArray();
        }

        string GetRolesAsString()
        {
            var roleString = string.Empty;
            foreach (var role in Roles)
            {
                if (roleString != string.Empty)
                    roleString += ";";

                roleString += role;
            }
            return roleString;
        }

    }
}