using Bifrost.Events;
using Bifrost.Read;
using Events.Security.Management;
using Infrastructure.Security;

namespace Read.Security.Management
{
    public class Subscriber : IProcessEvents
    {
        IReadModelRepositoryFor<User> _userRepository;

        public Subscriber(IReadModelRepositoryFor<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Process(UserCreated @event)
        {
            _userRepository.Insert(new User
            {
                Id = @event.EventSourceId,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Name = @event.Username,
                Password =@event.Password,
                IsAdmin = @event.IsAdmin
            });
        }

        public void Process(PasswordReset @event)
        {
            var user = _userRepository.GetById(@event.EventSourceId);
            user.Password = @event.Password;
            _userRepository.Update(user);
        }
    }
}
