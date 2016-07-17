using DN.AutoShopBrasil.Data.Context;
using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Entities;
using System.Linq;

namespace DN.AutoShopBrasil.Data.Repositories
{
    public class AnuncianteRepository : RepositoryBase<Anunciante>, IAnuncianteRepository
    {
        public AnuncianteRepository(AutoShopBrasilContext context) 
            : base(context)
        {

        }

        public Anunciante GetByEmail(string email)
        {
            return DataContext.Anunciantes.FirstOrDefault(x => x.Email == email);
        }
    }
}
