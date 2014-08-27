using System;
using Bifrost.Commands;
using Bifrost.Domain;

namespace Domain.HumanResources.Employees
{
    public class CommandHandlers : IHandleCommands
    {
        IAggregateRootRepository<Employee> _repository;
        public CommandHandlers(IAggregateRootRepository<Employee> repository)
        {
            _repository = repository;
        }

        public void Handle(Hire register)
        {
            var employee = _repository.Get(Guid.NewGuid());
            employee.Register(
                register.FirstName,
                register.LastName,
                register.SocialSecurityNumber,
                DateTime.UtcNow
            );
        }
    }
}
