using System.Linq;
using Bifrost.Read;
using Concepts;


namespace Read.Security.Management
{
    public class Users : IQueryFor<User>
    {
        IReadModelRepositoryFor<User> _repository;

        public Users(IReadModelRepositoryFor<User> repository)
        {
            _repository = repository;
        }
        public IQueryable<User> Query
        {
            get
            {
                return _repository.Query;
            }
        }
    }
}