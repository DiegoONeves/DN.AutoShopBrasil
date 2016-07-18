using DN.AutoShopBrasil.Common.ExtensionMethods;
using DN.AutoShopBrasil.Domain.Contracts.Repositories;
using DN.AutoShopBrasil.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DN.AutoShopBrasil.MVC.Controllers
{
    public class AutenticacaoController : BaseController
    {
        private readonly IAnuncianteRepository _anuncianteRepository;
        public AutenticacaoController(IAnuncianteRepository anuncianteRepository)
        {
            _anuncianteRepository = anuncianteRepository;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var anunciante = _anuncianteRepository.GetByEmail(loginModel.Email);
                if (anunciante != null)
                {
                    if (anunciante.Senha == loginModel.Senha.Encrypt())
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, anunciante.Nome, DateTime.Now, DateTime.Now.AddDays(5), loginModel.ManterLogado, loginModel.Email);
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Usuário ou senha inválidos");
            }

            return View(loginModel);
        }
    }
}