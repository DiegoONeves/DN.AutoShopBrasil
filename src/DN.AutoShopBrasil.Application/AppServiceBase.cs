using DN.AutoShopBrasil.Application.Interfaces;
using DN.AutoShopBrasil.Data.Interfaces;
using DN.AutoShopBrasil.Domain.ValueObjects;

namespace DN.AutoShopBrasil.Application
{
    public class AppServiceBase : IAppServiceBase
    {
        private readonly IUnityOfWork _unityOfWork;
        public AppServiceBase(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public void BeginTransaction()
        {
            _unityOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unityOfWork.Commit();
        }

      
    }
}
