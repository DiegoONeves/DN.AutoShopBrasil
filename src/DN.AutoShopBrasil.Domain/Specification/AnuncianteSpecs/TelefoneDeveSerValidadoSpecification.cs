using DN.AutoShopBrasil.Domain.Entities;

namespace DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs
{
    public class TelefoneDeveSerValidadoSpecification : ISpecification<Anunciante>
    {
        public bool IsSatisfiedBy(Anunciante anunciante)
        {
            return anunciante.Telefone.Length == 10 || anunciante.Telefone.Length == 11;
        }
    }
}
