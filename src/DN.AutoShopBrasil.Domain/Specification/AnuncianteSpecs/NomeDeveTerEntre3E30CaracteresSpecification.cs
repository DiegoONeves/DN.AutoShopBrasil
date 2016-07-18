using DN.AutoShopBrasil.Domain.Entities;

namespace DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs
{
    public class NomeDeveTerEntre3E30CaracteresSpecification : ISpecification<Anunciante>
    {
        public bool IsSatisfiedBy(Anunciante anunciante)
        {
            if (string.IsNullOrWhiteSpace(anunciante.Nome))
                return false;

            return anunciante.Nome.Length >= 3 && anunciante.Nome.Length <= 30;
        }
    }
}
