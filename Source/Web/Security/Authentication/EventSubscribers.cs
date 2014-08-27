using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Bifrost.Events;
using Events.Security.Authentication;
using Infrastructure.Security;
using Microsoft.AspNet.SignalR;

namespace Web.Security.Authentication
{
    public class EventSubscribers : IProcessEvents
    {
        IAuthenticationManager _authenticationManager;

        public EventSubscribers(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }


        public void Process(LoggedIn @event)
        {
            var context = _authenticationManager.GetFor(@event.Context);
            context.LoggedIn();

            //var hub = GlobalHost.ConnectionManager.GetHubContext<AuthenticationHub>();
            //var groupName = @event.Context.ToString();

            //hub.Clients.Group(groupName).loggedIn(FormsAuthentication.FormsCookieName, cookieString, roles.ToArray());
        }
    }
}