using DN.AutoShopBrasil.Domain.Entities;

namespace DN.AutoShopBrasil.Domain.Contracts.Repositories
{
    public interface IAnuncianteRepository: IRepositoryBase<Anunciante>
    {
        Anunciante GetByEmail(string email);
    }
}
