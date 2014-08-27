using System;
using Bifrost.Events;

namespace Events.HumanResources.Employees
{
    public class Hired : Event
    {
        public Hired(Guid eventSourceId) : base(eventSourceId) { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime HiredDate { get; set; }
        public string Department { get; set; }
    }
}
