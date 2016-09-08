using DN.AutoShopBrasil.Application.DTO;
using DN.AutoShopBrasil.Application.Interfaces;
using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Data.Interfaces;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Application
{
    public class AnuncianteAppService : AppServiceBase, IAnuncianteAppService
    {
        private readonly IAnuncianteService _anuncianteService;

        public AnuncianteAppService(IUnityOfWork unityOfWork, IAnuncianteService anuncianteService)
            : base(unityOfWork)
        {
            _anuncianteService = anuncianteService;
        }

        public Anunciante Autenticar(string email, string senha)
        {
            return null;
        }

        public ValidationResult CadastrarAnunciante(AnuncianteNovoDTO anuncianteNovo)
        {
            var anuncianteDomain = new Anunciante(anuncianteNovo.Nome, anuncianteNovo.Email, anuncianteNovo.Senha, anuncianteNovo.Telefone.ClearPhoneNumber());

            BeginTransaction();

            var result = _anuncianteService.CadastrarNovoAnunciante(anuncianteDomain);

            if (result.IsValid)
                Commit();

            return result;
        }
    }
}
