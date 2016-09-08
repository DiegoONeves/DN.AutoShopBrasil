using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Validation.Abstract;
using DN.AutoShopBrasil.Domain.Validation.AnuncianteValidation;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Domain.Entities
{
    public class Anunciante: ISelfValidator
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

            var fiscal = new AnuncianteAptoParaCadastroValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }

        public Guid AnuncianteId { get; protected set; }
        public string Nome { get;  protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
        public string Telefone { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
        public ValidationResult ResultadoValidacao { get; private set; }
    
        public override string ToString()
        {
            return Nome;
        }

        public void AlterarSenha(string novaSenha)
        {
            Senha = novaSenha;

            var fiscal = new AnuncianteAptoParaAlterarSenhaValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }

        public void AlterarAnunciante(string nome, string email, string telefone)
        {          
            Nome = nome;
            Email = email;
            Telefone = telefone;

            var fiscal = new AnuncianteAptoParaEditarValidation();
            ResultadoValidacao = fiscal.Validar(this);
        }
        public void CriptografarSenha()
        {
            Senha = Senha.Encrypt();
        }

        public bool IsValid()
        {
            return ResultadoValidacao.IsValid;
        }
    }
}
