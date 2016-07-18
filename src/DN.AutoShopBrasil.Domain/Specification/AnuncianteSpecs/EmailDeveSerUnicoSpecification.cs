using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Entities;

namespace DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs
{
    public class EmailDeveSerUnicoSpecification : ISpecification<Anunciante>
    {
        private readonly IAnuncianteRepository _anuncianteRepository;
        public EmailDeveSerUnicoSpecification(IAnuncianteRepository anuncianteRepository)
        {
            _anuncianteRepository = anuncianteRepository;
        }

        public bool IsSatisfiedBy(Anunciante anunciante)
        {
            var anuncianteDb = _anuncianteRepository.GetByEmail(anunciante.Email);

            if (anuncianteDb == null)
                return true;

            return anuncianteDb.AnuncianteId == anuncianteDb.AnuncianteId;
        }
    }
}
