using System;
using Bifrost.Commands;
using Bifrost.Domain;
using Infrastructure.Security;

namespace Domain.Security.Management
{
    public class CommandHandler : IHandleCommands
    {
        IAggregateRootRepository<User> _userRepository;
        readonly IAuthenticationManager _authenticationManager;

        public CommandHandler(IAggregateRootRepository<User> userRepository, IAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
        }

        public void Handle(CreateUser command)
        {
            var id = Guid.NewGuid();
            var user = _userRepository.Get(id);
            user.Create(command.FirstName, command.LastName, command.Username, _authenticationManager.Hash(id,command.Password), command.IsAdmin);
        }

        public void Handle(ResetPassword reset)
        {
            var user = _userRepository.Get(reset.UserId);
            user.ResetPassword(_authenticationManager.Hash(reset.UserId, reset.NewPassword));
        }
    }
}
