using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Web.Security.Authentication
{
    public class AuthenticationHub : Hub
    {
        public Task LoggingIn(Guid context)
        {
            return Groups.Add(Context.ConnectionId, context.ToString());
        }
    }
}