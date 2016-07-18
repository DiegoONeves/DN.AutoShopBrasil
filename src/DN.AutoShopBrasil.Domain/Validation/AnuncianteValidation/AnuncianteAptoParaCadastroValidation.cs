using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.Specification.AnuncianteSpecs;
using DN.AutoShopBrasil.Domain.Validation.Concrete;

namespace DN.AutoShopBrasil.Domain.Validation.AnuncianteValidation
{
    public class AnuncianteAptoParaCadastroValidation : FiscalBase<Anunciante>
    {
        public AnuncianteAptoParaCadastroValidation()
        {
            base.AdicionarRegra("01", new Regra<Anunciante>(new NomeDeveTerEntre3E30CaracteresSpecification(), "O nome do anunciante deve ter entre 3 e 30 caracteres"));
            base.AdicionarRegra("02", new Regra<Anunciante>(new EmailDeveSerValidoSpecification(), "O e-mail do anunciante deve ser válido"));
            base.AdicionarRegra("03", new Regra<Anunciante>(new SenhaDeveTerEntre6E20CaracteresSpecification(), "A senha do anunciante deve ter entre 6 e 20 caracteres"));
            base.AdicionarRegra("04", new Regra<Anunciante>(new TelefoneDeveSerValidadoSpecification(), "O telefone informado é inválido"));
        }
    }
}
