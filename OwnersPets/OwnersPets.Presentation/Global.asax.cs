using System.Web.Http;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using OwnersPets.Data;
using Unity.WebApi;
using StorageModel.Data;

namespace OwnersPets.Presentation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterServices();
        }

        private static void RegisterServices()
        {
            var container = new UnityContainer();
            
            OwnerPetsPresentationRegistration.Register(container);
            OwnersPetsRegistration.Register(container);
            OwnerPetsDataRegistration.Register(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            MigrationAdapter.CreateIfNotExistsDatabase();
        }
    }
}
