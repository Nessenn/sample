using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace CustomerManager
{
    using System.Security.Principal;

    using CustomerManager.Data;
    using CustomerManager.Services.Contracts;
    using CustomerManager.Services.Implementation;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<IRepository, GenericRepository<NorthwindDbContext>>();
            container.RegisterType<ICustomerService, CustomerService>();
        }
    }
}