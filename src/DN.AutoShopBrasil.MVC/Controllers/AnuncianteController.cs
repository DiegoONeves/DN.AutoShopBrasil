using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Contracts.Infra;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.MVC.Models;
using System.Web.Mvc;

namespace DN.AutoShopBrasil.MVC.Controllers
{
    public class AnuncianteController : BaseController
    {
        private readonly IAnuncianteService _anuncianteService;
        private readonly IUnityOfWork _unityOfWork;
        public AnuncianteController(IUnityOfWork unityOfWork, IAnuncianteService anuncianteService)
        {
            _unityOfWork = unityOfWork;
            _anuncianteService = anuncianteService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AnuncianteModel anuncianteModel)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.BeginTransaction();

                var anuncianteDomain = new Anunciante
                {
                    Nome = anuncianteModel.Nome,
                    Email = anuncianteModel.Email,
                    Senha = anuncianteModel.Senha,
                    Telefone = anuncianteModel.Telefone.ClearPhoneNumber()
                };
                var result = _anuncianteService.CadastrarNovoAnunciante(anuncianteDomain);

                if (result.IsValid)
                {      
                    _unityOfWork.Commit();
                    return RedirectToAction("Index");
                }

                AddModelError(result.Erros);
            }
            return View(anuncianteModel);
        }
    }
}