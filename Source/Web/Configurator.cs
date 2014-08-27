using System.Web.Routing;
using Bifrost.Configuration;
using Bifrost.Web.Services;
using Ninject.Modules;
using Web.Security.Authentication;

namespace Web
{
    public class Configurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            var connectionString = "mongodb://localhost:27017";
            configure
                .UsingSignalR()
                .Serialization
                    .UsingJson()
                .Events
                    .UsingMongoDB(e=>e.WithUrl(connectionString).WithDefaultDatabase("Goto"))
                    //.UsingRavenDB(e=>e.WithUrl("http://localhost:8080").WithDefaultDatabase("Goto"))
                .Events
                    .Synchronous() //.Asynchronous(e => e.UsingSignalR())
                .DefaultStorage
                    .UsingMongoDB(e => e.WithUrl(connectionString).WithDefaultDatabase("Goto"))
                    //.UsingRavenDB(e => e.WithUrl("http://localhost:8080").WithDefaultDatabase("Goto"))
                .Frontend
                    .Web(w=> {
                        w.AsSinglePageApplication();

                        w.ScriptsToInclude.JQuery = false;

                        w.PathsToNamespaces.Clear();
                        w.PathsToNamespaces.Add("Visualizer/**/", "Bifrost.Visualizer.**.");
                        w.PathsToNamespaces.Add("Bifrost/Visualizer/**/", "Bifrost.Visualizer.**.");
                        w.PathsToNamespaces.Add("/Visualizer/**/", "Bifrost.Visualizer.**.");
                        w.PathsToNamespaces.Add("/Bifrost/Visualizer/**/", "Bifrost.Visualizer.**.");

                        w.PathsToNamespaces.Add("Visualizer", "Bifrost.Visualizer");
                        w.PathsToNamespaces.Add("Bifrost/Visualizer", "Bifrost.Visualizer");
                        w.PathsToNamespaces.Add("/Visualizer", "Bifrost.Visualizer");
                        w.PathsToNamespaces.Add("/Bifrost/Visualizer", "Bifrost.Visualizer");

                        w.PathsToNamespaces.Add("Visualizer/**/", "Bifrost.Visualizer.**.");
                        w.PathsToNamespaces.Add("/Visualizer/**/", "Bifrost.Visualizer.**.");
                        w.PathsToNamespaces.Add("Bifrost/Visualizer/**/", "Bifrost.Visualizer.**.");
                        w.PathsToNamespaces.Add("/Bifrost/Visualizer/**/", "Bifrost.Visualizer.**.");

                        var baseNamespace = global::Bifrost.Configuration.Configure.Instance.EntryAssembly.GetName().Name;
                        var @namespace = string.Format("{0}.**.", baseNamespace);

                        w.PathsToNamespaces.Add("**/", @namespace);
                        w.PathsToNamespaces.Add("/**/", @namespace);
                        w.PathsToNamespaces.Add("", baseNamespace);

                        w.NamespaceMapper.Add("Web.**.", "Web.**.");
                        w.NamespaceMapper.Add("Web.**.", "Domain.**.");
                        w.NamespaceMapper.Add("Web.**.", "Read.**.");
					})
                .WithMimir();

            RouteTable.Routes.AddService<UserService>();

            ContainerCreator.Kernel.Load(new INinjectModule[] { new RulesModule() });
        }
    }
}