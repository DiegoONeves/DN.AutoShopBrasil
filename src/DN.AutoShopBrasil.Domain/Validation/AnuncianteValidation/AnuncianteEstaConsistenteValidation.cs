using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs;
using DN.AutoShopBrasil.Domain.Validation.Concrete;

namespace DN.AutoShopBrasil.Domain.Validation.AnuncianteValidation
{
    public class AnuncianteEstaConsistenteValidation : FiscalBase<Anunciante>
    {
        public AnuncianteEstaConsistenteValidation(IAnuncianteRepository anuncianteRepository)
        {
            base.AdicionarRegra("01", new Regra<Anunciante>(new EmailDeveSerUnicoSpecification(anuncianteRepository), "Este e-mail já foi cadastrado"));
        }
    }
}
