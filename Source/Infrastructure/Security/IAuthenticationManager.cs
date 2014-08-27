using System;

namespace Infrastructure.Security
{
    public interface IAuthenticationManager
    {
        string Hash(Guid id, string password);
        IAuthenticationContext EstablishFor(Guid id, string username, string password);
        IAuthenticationContext GetFor(Guid id);
    }
}
