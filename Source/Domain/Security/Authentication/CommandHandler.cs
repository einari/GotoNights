using Bifrost.Commands;
using Bifrost.Domain;
using Infrastructure.Security;

namespace Domain.Security.Authentication
{
    public class CommandHandler : IHandleCommands
    {
        IAggregateRootRepository<User> _userRepository;
        IAuthenticationManager _authenticationManager;

        public CommandHandler(IAggregateRootRepository<User> userRepository, IAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
        }

        public void Handle(Login command)
        { 
            var context = _authenticationManager.EstablishFor(command.Context, command.Username, command.Password);
            if (!context.IsUsernameValid) throw new WrongUserNameOrPasswordException();

            var account = _userRepository.Get(context.UserId);
            if (context.IsPasswordValid)
                account.Login(command.Context);
            else
            {
                account.Fail();
                throw new WrongUserNameOrPasswordException();
            }
        }
    }
}
