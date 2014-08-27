using Microsoft.AspNet.SignalR;
using Ninject.Modules;
using Read.HumanResources.Employees;

namespace Web.HumanResources.Employees
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<EmployeeHired>().ToMethod(c=>EmployeeHired);
        }


        void EmployeeHired(Employee employee)
        {
            GlobalHost.ConnectionManager.GetHubContext<EmployeeHub>().Clients.All.hired(employee);
        }
    }
}