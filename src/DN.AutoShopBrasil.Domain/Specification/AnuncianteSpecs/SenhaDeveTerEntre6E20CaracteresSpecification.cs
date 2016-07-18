using DN.AutoShopBrasil.Domain.Entities;

namespace DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs
{
    public class SenhaDeveTerEntre6E20CaracteresSpecification : ISpecification<Anunciante>
    {
        public bool IsSatisfiedBy(Anunciante anunciante)
        {
            if (string.IsNullOrWhiteSpace(anunciante.Senha))
                return false;

            return anunciante.Senha.Length >= 6 && anunciante.Senha.Length <= 20;
        }
    }
}
