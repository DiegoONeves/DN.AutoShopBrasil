using DN.AutoShopBrasil.Domain.Validation.Abstract;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System.Collections.Generic;

namespace DN.AutoShopBrasil.Domain.Validation.Concrete
{
    public class FiscalBase<TEntity> : IFiscal<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRegra<TEntity>> _validations = new Dictionary<string, IRegra<TEntity>>();

        protected virtual void AdicionarRegra(string nomeRegra, IRegra<TEntity> rule)
        {
            _validations.Add(nomeRegra, rule);
        }

        protected virtual void RemoverRegra(string nomeRegra)
        {
            _validations.Remove(nomeRegra);
        }

        protected IRegra<TEntity> ObterRegra(string nomeRegra)
        {
            IRegra<TEntity> rule;
            _validations.TryGetValue(nomeRegra, out rule);
            return rule;
        }

        public ValidationResult Validar(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var x in _validations.Keys)
            {
                var rule = _validations[x];
                if (!rule.Validar(entity))
                    result.AdicionarErro(new ValidationError(rule.MensagemErro));
            }

            return result;
        }


    }
}
