using System.Web.Mvc;

namespace OwnersPets.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}