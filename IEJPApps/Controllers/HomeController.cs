using System.Web.Mvc;
using IEJPApps.Services;

namespace IEJPApps.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICookieService _cookieService;

        public HomeController(ICookieService cookieService)
        {
            _cookieService = cookieService;
        }

        public ActionResult Index()
        {
            ViewBag.Language = _cookieService.Language;
            ViewBag.SessionId = _cookieService.SessionId;

            return View();
        }
    }
}