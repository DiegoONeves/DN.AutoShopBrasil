using DN.AutoShopBrasil.IoC;
using DN.AutoShopBrasil.MVC.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace DN.AutoShopBrasil.MVC.App_Start
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}