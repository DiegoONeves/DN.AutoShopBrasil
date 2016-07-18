using DN.AutoShopBrasil.Domain.ValueObjects;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace DN.AutoShopBrasil.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void AddModelError(IEnumerable<ValidationError> errors)
        {
            foreach (var item in errors)
                ModelState.AddModelError("", item.Message);
        }

        protected string ObterEmailTicket()
        {
            var ticket = ObterTicket();

            return ticket.UserData;
        }

        protected FormsAuthenticationTicket ObterTicket()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticketInfo = FormsAuthentication.Decrypt(cookie.Value);
            return ticketInfo;
        }
    }
}