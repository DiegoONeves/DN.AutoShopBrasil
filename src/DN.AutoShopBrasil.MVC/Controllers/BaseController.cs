using DN.AutoShopBrasil.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DN.AutoShopBrasil.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void AddModelError(IEnumerable<ValidationError> errors)
        {
            foreach (var item in errors)
                ModelState.AddModelError("", item.Message);
        }
    }
}