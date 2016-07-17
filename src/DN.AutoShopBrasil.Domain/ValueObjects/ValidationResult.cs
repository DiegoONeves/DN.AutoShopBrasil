using System.Collections.Generic;
using System.Linq;

namespace DN.AutoShopBrasil.Domain.ValueObjects
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public string Mensagem { get; set; }
        public bool IsValid { get { return _errors.Count == 0; } }

        public IEnumerable<ValidationError> Erros { get { return _errors; } }
        public void AdicionarErro(ValidationError error)
        {
            _errors.Add(error);
        }
        public void RemoverErro(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }

        public void AdicionarErro(params ValidationResult[] resultadoValidacao)
        {
            if (resultadoValidacao == null) return;

            foreach (var validationResult in resultadoValidacao.Where(result => result != null))
                _errors.AddRange(validationResult.Erros);
        }
    }
}
