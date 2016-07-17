using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Validations;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Domain.Entities
{
    public class Anunciante
    {
        protected Anunciante() { }
        public Anunciante(string nome, string email, string senha, string telefone)
        {
            AnuncianteId = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            DataCadastro = DateTime.Now;

            ValidationResult = new ValidationResult();
        }

        public Guid AnuncianteId { get; protected set; }
        public string Nome { get;  protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
        public string Telefone { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public ValidationResult ValidationResult { get; private set; }

        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object obj)
        {
            Anunciante anunciante = (Anunciante)obj;

            return AnuncianteId == anunciante.AnuncianteId; 
        }
        public void AlterarAnunciante(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
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
