using Bifrost.Events;
using Bifrost.Read;
using Events.HumanResources.Employees;

namespace Read.HumanResources.Employees
{
    public class Subscribers : IProcessEvents
    {
        IReadModelRepositoryFor<Employee> _repository;
        EmployeeHired _employeeHired;

        public Subscribers(IReadModelRepositoryFor<Employee> repository, EmployeeHired employeeHired)
        {
            _repository = repository;
            _employeeHired = employeeHired;
        }

        public void Process(Hired @event)
        {
            var employee = new Employee 
            { 
                Id = @event.EventSourceId, 
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                SocialSecurityNumber = @event.SocialSecurityNumber,
                HiredDate = @event.HiredDate
            };
            _repository.Insert(employee);
            _employeeHired(employee);
        }
    }
}
