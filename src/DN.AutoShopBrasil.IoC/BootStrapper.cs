using DN.AutoShopBrasil.Application;
using DN.AutoShopBrasil.Application.Interfaces;
using DN.AutoShopBrasil.Data.Context;
using DN.AutoShopBrasil.Data.Interfaces;
using DN.AutoShopBrasil.Data.Repositories;
using DN.AutoShopBrasil.Data.UnityOfWork;
using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Services;
using SimpleInjector;

namespace DN.AutoShopBrasil.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IAppServiceBase, AppServiceBase>(Lifestyle.Scoped);
            container.Register<IAnuncianteAppService, AnuncianteAppService>(Lifestyle.Scoped);

            container.Register<IAnuncianteService, AnuncianteService>(Lifestyle.Scoped);
            container.Register<IAnuncianteRepository, AnuncianteRepository>(Lifestyle.Scoped);

            container.Register<AutoShopBrasilContext>(Lifestyle.Scoped);
            container.Register<IUnityOfWork, EFUnityOfWork>(Lifestyle.Scoped);
        }
    }
}
