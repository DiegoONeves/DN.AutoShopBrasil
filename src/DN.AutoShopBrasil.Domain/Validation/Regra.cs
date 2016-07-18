using DN.AutoShopBrasil.Domain.Specification;
using DN.AutoShopBrasil.Domain.Validation.Abstract;

namespace DN.AutoShopBrasil.Domain.Validation
{
    public class Regra<TEntity> : IRegra<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string MensagemErro { get; private set; }

        public Regra(ISpecification<TEntity> regra, string mensagemErro)
        {
            _specificationRule = regra;
            MensagemErro = mensagemErro;
        }

        public bool Validar(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}