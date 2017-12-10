using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Harvin.Controllers
{
    public class InicialController : Controller {
        // GET: Inicial
        public ActionResult Index() {
            return View();
        }

        // GET: Configurações
        public ActionResult Configuracoes() {
            return View();
        }

        // GET: Configurações
        public ActionResult AcessoNegado() {
            return View();
        }


    }


}