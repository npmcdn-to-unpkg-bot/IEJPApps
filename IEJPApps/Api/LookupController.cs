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
            var periods = new List<PayPeriodViewModel>();
            var currentPeriod = TimeService.GetCurrentPayPeriod();

            for (int i = -before; i < after; i++)
            {
                var weekStartDate = currentPeriod.StartDate.AddDays(7 * i);

                periods.Add(new PayPeriodViewModel
                {
                    StartDate = weekStartDate,
                    EndDate = weekStartDate.AddDays(7),
                    WeekNumber = TimeService.GetIso8601WeekOfYear(weekStartDate),
                    IsCurrent = weekStartDate == currentPeriod.StartDate
                });
            }

            return periods;
        }

        [Route("periods/current")]
        public PayPeriodViewModel GetPeriodsCurrent()
        {
            return TimeService.GetCurrentPayPeriod();
        }
    }
}