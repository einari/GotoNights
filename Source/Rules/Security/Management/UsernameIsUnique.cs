using System.Linq;
using Bifrost.Read;
using Concepts.Security;
using Read.Security;

namespace Rules.Security.Management
{
    public delegate bool UsernameIsUnique(Username username);

    public class UsernameIsUniqueImp : IProvideARuleImplementation<UsernameIsUnique>
    {
        readonly IReadModelRepositoryFor<User> _repository;

        public UsernameIsUniqueImp(IReadModelRepositoryFor<User> repository)
        {
            _repository = repository;
        }

        public UsernameIsUnique GetImplementation()
        {
            return username => !_repository.Query.Any(u => u.Name == username);
        }
    }
}