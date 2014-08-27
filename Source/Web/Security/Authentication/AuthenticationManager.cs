using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Bifrost.Read;
using Infrastructure.Security;
using Read.Security;

namespace Web.Security.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        

        IReadModelRepositoryFor<User> _userRepository;

        public AuthenticationManager(IReadModelRepositoryFor<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IAuthenticationContext EstablishFor(Guid id, string username, string password)
        {
            var user = _userRepository.Query.Where(u => u.Name == username).FirstOrDefault();
            var isUserNameValid = user != null;
            var isAdmin = false;
            var isPasswordValid = false;
            if (user != null)
            {
                var hashedPassword = Hash(user.Id, password);
                isPasswordValid = hashedPassword == user.Password;

                isAdmin = user.IsAdmin;
            }

            var context = new AuthenticationContext(id, username, isUserNameValid, isPasswordValid, isAdmin);
            HttpContext.Current.Session.SetContext(context);

            return context;
        }

        public IAuthenticationContext GetFor(Guid id)
        {
            return HttpContext.Current.Session.GetContext();
        }

        public string Hash(Guid id, string password)
        {
            var passwordAsBytes = UTF8Encoding.UTF8.GetBytes(password);
            var saltAsBytes = id.ToByteArray();
            var passwordAndSaltAsBytes = new byte[passwordAsBytes.Length + saltAsBytes.Length];

            Buffer.BlockCopy(passwordAsBytes, 0, passwordAndSaltAsBytes, 0, passwordAsBytes.Length);
            Buffer.BlockCopy(saltAsBytes, 0, passwordAndSaltAsBytes, passwordAsBytes.Length, saltAsBytes.Length);

            var sha = new SHA256Managed();
            var hashAsBytes = sha.ComputeHash(passwordAndSaltAsBytes);
            var hashAsString = Convert.ToBase64String(hashAsBytes);
            return hashAsString;
        }
    }
}
