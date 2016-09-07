using System;

namespace DN.AutoShopBrasil.Data.Interfaces
{
    public interface IUnityOfWork: IDisposable
    {    
        void BeginTransaction();
        void Commit();
    }
}
