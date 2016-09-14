using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Entities;
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
            return validationResult;
        }

        public ValidationResult EditarAnunciante(Anunciante anuncianteParaEditar)
        {                 
            return validationResult;
        }

        public void Dispose()
        {
            _anuncianteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
