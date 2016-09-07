namespace DN.AutoShopBrasil.Application.Interfaces
{
    public interface IAppServiceBase
    {
        void BeginTransaction();
        void Commit();
    }
}
