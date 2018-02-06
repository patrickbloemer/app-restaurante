using System.Web.Mvc;

namespace Harvin.Controllers
{
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            return View();
        }

        // GET: Pizzaria
        public ActionResult Pizzaria() {
            return View();
        }
    }
}