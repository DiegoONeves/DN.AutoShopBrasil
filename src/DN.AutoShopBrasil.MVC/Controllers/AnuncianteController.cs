using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Contracts.Infra;
using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.Domain.Contracts.Services;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.MVC.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace DN.AutoShopBrasil.MVC.Controllers
{
    [Authorize]
    public class AnuncianteController : BaseController
    {
        private readonly IAnuncianteService _anuncianteService;
        private readonly IAnuncianteRepository _anuncianteRepository;
        private readonly IUnityOfWork _unityOfWork;
        public AnuncianteController(IUnityOfWork unityOfWork,
            IAnuncianteService anuncianteService,
            IAnuncianteRepository anuncianteRepository)
        {
            _unityOfWork = unityOfWork;
            _anuncianteService = anuncianteService;
            _anuncianteRepository = anuncianteRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
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

                var anuncianteDomain = new Anunciante(anuncianteModel.Nome, anuncianteModel.Email, anuncianteModel.Senha, anuncianteModel.Telefone.ClearPhoneNumber());
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

        public ActionResult Editar()
        {
            var anuncianteParaEditar = _anuncianteRepository.GetByEmail(ObterEmailTicket());

            var model = new AnuncianteEdicaoModel
            {
                AnuncianteId = anuncianteParaEditar.AnuncianteId,
                Nome = anuncianteParaEditar.Nome,
                Email = anuncianteParaEditar.Email,
                Telefone = anuncianteParaEditar.Telefone
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AnuncianteEdicaoModel anuncianteEdicaoModel)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.BeginTransaction();

                var anuncianteDomain = _anuncianteRepository.GetById(anuncianteEdicaoModel.AnuncianteId);
                anuncianteDomain.AlterarAnunciante(anuncianteEdicaoModel.Nome, anuncianteEdicaoModel.Email, anuncianteEdicaoModel.Telefone.ClearPhoneNumber());

                var result = _anuncianteService.EditarAnunciante(anuncianteDomain);

                if (result.IsValid)
                {
                    _unityOfWork.Commit();
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Login", "Autenticacao");
                }

                AddModelError(result.Erros);
            }
            return View(anuncianteEdicaoModel);
        }
    }
}