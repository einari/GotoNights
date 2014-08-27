using Bifrost.Configuration;
using Bifrost.Execution;
using Bifrost.Ninject;
using Ninject;

namespace Web
{
    public class ContainerCreator : ICanCreateContainer
    {
        //TEMP expose Ninject Kernel until we can implement a better method of controlling when modules are loaded.
        public static StandardKernel Kernel { get; private set; }

        public IContainer CreateContainer()
        {
            Kernel = new StandardKernel(new HumanResources.Employees.Module(), new Security.Module());
            var container = new Container(Kernel);
            return container;
        }
    }
}