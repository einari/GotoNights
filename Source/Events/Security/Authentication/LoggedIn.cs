using System;
using Bifrost.Events;

namespace Events.Security.Authentication
{
    public class LoggedIn : Event
    {
        public LoggedIn(Guid eventSourceId) : base(eventSourceId) { }
        public Guid Context { get; set; }
    }
}
