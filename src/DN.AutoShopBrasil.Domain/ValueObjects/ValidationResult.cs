using System.Collections.Generic;
using System.Linq;

namespace DN.AutoShopBrasil.Domain.ValueObjects
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        internal string Mensagem { get; set; }
        public bool IsValid { get { return _errors.Count == 0; } }

        public IEnumerable<ValidationError> Erros { get { return _errors; } }
        internal void AdicionarErro(ValidationError error)
        {
            _errors.Add(error);
        }
        internal void RemoverErro(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }

        internal void AdicionarErro(params ValidationResult[] resultadoValidacao)
        {
            if (resultadoValidacao == null) return;

            foreach (var validationResult in resultadoValidacao.Where(result => result != null))
                _errors.AddRange(validationResult.Erros);
        }
    }
}
