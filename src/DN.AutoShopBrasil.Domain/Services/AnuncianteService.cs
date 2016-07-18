using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.Validation.AnuncianteValidation;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Domain.Services
{
    public class AnuncianteService : IAnuncianteService
    {
        private ValidationResult validationResult = null;
        private readonly IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService(IAnuncianteRepository anuncianteRepository)
        {
            _anuncianteRepository = anuncianteRepository;
        }
        public ValidationResult CadastrarNovoAnunciante(Anunciante anuncianteNovo)
        {
            if (!anuncianteNovo.IsValid())
                return anuncianteNovo.ResultadoValidacao;

            validationResult = new AnuncianteEstaConsistenteValidation(_anuncianteRepository).Validar(anuncianteNovo);

            if (validationResult.IsValid)
            {
                anuncianteNovo.CriptografarSenha();
                _anuncianteRepository.Add(anuncianteNovo);
            }
            return validationResult;
        }

        public ValidationResult EditarAnunciante(Anunciante anuncianteParaEditar)
        {
            if (!anuncianteParaEditar.IsValid())
                return anuncianteParaEditar.ResultadoValidacao;

            validationResult = new AnuncianteEstaConsistenteValidation(_anuncianteRepository).Validar(anuncianteParaEditar);

            if (validationResult.IsValid)
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
