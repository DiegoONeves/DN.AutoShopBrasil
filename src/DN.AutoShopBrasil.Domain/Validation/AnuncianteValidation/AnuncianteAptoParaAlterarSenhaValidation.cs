using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs;
using DN.AutoShopBrasil.Domain.Validation.Concrete;

namespace DN.AutoShopBrasil.Domain.Validation.AnuncianteValidation
{
    public class AnuncianteAptoParaAlterarSenhaValidation : FiscalBase<Anunciante>
    {
        public AnuncianteAptoParaAlterarSenhaValidation()
        {
            base.AdicionarRegra("01", new Regra<Anunciante>(new SenhaDeveTerEntre6E20CaracteresSpecification(), "A senha do anunciante deve ter entre 6 e 20 caracteres"));
        }
    }
}
