using System;

namespace Infrastructure.Security
{
    public interface IAuthenticationContext
    {
        Guid UserId { get; }
        string Username { get; }
        bool IsUsernameValid { get; }
        bool IsPasswordValid { get; }
        bool IsAdmin { get; }

        void LoggedIn();
    }
}
