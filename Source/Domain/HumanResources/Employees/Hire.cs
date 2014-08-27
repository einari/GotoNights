using System;
using Bifrost.Commands;

namespace Domain.HumanResources.Employees
{
    public class Hire : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}
