using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Entities;
using System;

namespace DN.AutoShopBrasil.Domain.Contracts.Infra
{
    public interface IUnityOfWork: IDisposable
    {    
        void BeginTransaction();
        void Commit();
    }
}
