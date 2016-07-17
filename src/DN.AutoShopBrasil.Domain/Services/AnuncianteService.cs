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
        public ValidationResult CadastrarNovoAnunciante(Anunciante anunciante)
        {
            if (!anunciante.IsValid())
                return anunciante.ValidationResult;

            if (_anuncianteRepository.GetByEmail(anunciante.Email) != null)
                validationResult.AdicionarErro(new ValidationError("Este e-mail já foi cadastrado por outro anunciante."));

            anunciante.CriptografarSenha();
            _anuncianteRepository.Add(anunciante);

            return validationResult;
        }

        public ValidationResult EditarAnunciante(Anunciante anuncianteParaEditar)
        {
            if (!anuncianteParaEditar.IsValid())
                return anuncianteParaEditar.ValidationResult;

            var anuncianteDb = _anuncianteRepository.GetByEmail(anuncianteParaEditar.Email);

            if (!anuncianteParaEditar.Equals(anuncianteDb))
                validationResult.AdicionarErro(new ValidationError("Este e-mail já foi cadastrado por outro anunciante."));

            _anuncianteRepository.Update(anuncianteParaEditar);

            return validationResult;

        }

        public void Dispose()
        {
            _anuncianteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
