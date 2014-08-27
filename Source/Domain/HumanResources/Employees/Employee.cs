using System;
using Bifrost.Domain;
using Events.HumanResources.Employees;

namespace Domain.HumanResources.Employees
{
    public class Employee : AggregateRoot
    {
        public Employee(Guid id) : base(id) { }
        public void Register(string firstName, string lastName, string socialSecurityNumber, DateTime hired)
        {
            Apply(new Hired(Id) 
            { 
                FirstName = firstName,
                LastName = lastName,
                SocialSecurityNumber = socialSecurityNumber,
                HiredDate = hired,
            });
        }
    }
}
