using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Domain.Services
{
    public class AnuncianteService : IAnuncianteService
    {
        private ValidationResult validationResult = new ValidationResult();
        private readonly IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService(IAnuncianteRepository anuncianteRepository)
        {
            _anuncianteRepository = anuncianteRepository;
        }
        public ValidationResult AlterarAnunciante(Anunciante anunciante)
        {
            return null;

        }

        public ValidationResult CadastrarNovoAnunciante(Anunciante anunciante)
        {
            if (!anunciante.IsValid())
                return anunciante.ValidationResult;

            if (_anuncianteRepository.GetByEmail(anunciante.Email) != null)
                validationResult.AdicionarErro(new ValidationError($"O e-mail {anunciante.Email} já foi cadastrado."));

            anunciante.CriptografarSenha();
            _anuncianteRepository.Add(anunciante);

            return validationResult;
        }

        public void Dispose()
        {
            _anuncianteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
