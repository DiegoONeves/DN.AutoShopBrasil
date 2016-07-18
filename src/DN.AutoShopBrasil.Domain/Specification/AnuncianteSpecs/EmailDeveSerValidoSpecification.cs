using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Entities;

namespace DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs
{
    public class EmailDeveSerValidoSpecification : ISpecification<Anunciante>
    {

        public bool IsSatisfiedBy(Anunciante anunciante)
        {
            return anunciante.Email.IsEmail();
        }

       
    }
}
