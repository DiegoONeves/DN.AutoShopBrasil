using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Validations;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Domain.Entities
{
    public class Anunciante
    {
        public Anunciante()
        {
            AnuncianteId = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public Guid AnuncianteId { get; set; }
        public string Nome { get;  set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public override string ToString()
        {
            return Nome;
        }

        public void CriptografarSenha()
        {
            Senha = Senha.Encrypt();
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                ValidationResult.AdicionarErro(new ValidationError("O nome do anunciante não pode ser vazio."));

            if (!EmailValidation.IsValid(Email))
                ValidationResult.AdicionarErro(new ValidationError("O e-mail é inválido."));

            if (string.IsNullOrWhiteSpace(Senha) || Senha.Length < 6 || Senha.Length > 20)
                ValidationResult.AdicionarErro(new ValidationError("A senha deve ter entre 6 e 20 caracteres."));

            return ValidationResult.IsValid;
        }
    }
}
