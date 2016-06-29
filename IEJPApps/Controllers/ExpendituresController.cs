using System.Web.Mvc;

namespace IEJPApps.Controllers
{
    public class ExpendituresController : Controller
    {
        // GET: Expenditures
        public ActionResult Index()
        {
            return PartialView("IndexPartial");
        }

        // GET: Expenditures/Edit
        public ActionResult Edit()
        {
            return PartialView("EditPartial");
        }
    }
}