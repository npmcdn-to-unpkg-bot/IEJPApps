using System.Collections.Generic;
using System.Web.Http;
using IEJPApps.Repositories;
using IEJPApps.ViewModels;
using IEJPApps.Services;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/lookup")]
    public class LookupController : ApiController
    {
        private readonly ITimeService _timeService;
        private readonly EmployeeRepository _employees = new EmployeeRepository();
        private readonly ProjectRepository _projects = new ProjectRepository();

        public LookupController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [Route("periods/list/{before}/{after}")]
        public List<PayPeriodViewModel> GetPeriodsList(int before, int after)
        {
            return _timeService.GetPeriodsFromCurrentPayPeriod(before, after);
        }

        [Route("periods/current")]
        public PayPeriodViewModel GetPeriodsCurrent()
        {
            return _timeService.GetCurrentPayPeriod();
        }

        [Route("employees")]
        public List<EmployeeLookupViewModel> GetEmployees()
        {
            return AutoMapper.Mapper.Map<List<EmployeeLookupViewModel>>(_employees.LookupAll());
        }

        [Route("projects")]
        public List<ProjectLookupViewModel> GetProjects()
        {
            return AutoMapper.Mapper.Map<List<ProjectLookupViewModel>>(_projects.LookupAll());
        }
    }
}