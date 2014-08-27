using System;
using System.Linq;
using Bifrost.Read;

namespace Read.HumanResources.Employees
{
    public class Employees : IQueryFor<Employee>
    {
        IReadModelRepositoryFor<Employee> _repository;
        public Employees(IReadModelRepositoryFor<Employee> repository)
        {
            _repository = repository;
        }

        public IQueryable<Employee> Query
        {
            get
            {
                return _repository.Query;
            }
        }
    }
}
