using System.Collections.Generic;
using System.Web.Http;
using IEJPApps.ViewModels;
using IEJPApps.Services;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/lookup")]
    public class LookupController : ApiController
    {
        [Route("periods/list/{before}/{after}")]
        public List<PayPeriodViewModel> GetPeriodsList(int before, int after)
        {
            return TimeService.GetPeriodsFromCurrentPayPeriod(before, after);
        }

        [Route("periods/current")]
        public PayPeriodViewModel GetPeriodsCurrent()
        {
            return TimeService.GetCurrentPayPeriod();
        }
    }
}