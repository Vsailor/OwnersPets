using System.Web.Mvc;

namespace OwnersPets.Presentation.Controllers
{
    [RoutePrefix("Owners")]
    public class OwnersController : Controller
    {
        [Route("{ownerId}")]
        public ActionResult Index(int ownerId)
        {
            ViewData["ownerId"] = ownerId;
            return View("OwnerDetails");
        }
    }
}