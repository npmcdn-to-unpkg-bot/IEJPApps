using System;
using IEJPApps.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Exceptions;
using IEJPApps.Extensions;
using IEJPApps.Models.Extensions;
using IEJPApps.ViewModels;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/payperiods")]
    public class PayPeriodsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        
        [Route("")]
        public List<PayPeriodViewModel> GetAll()
        {
            var viewModel = _db.Periods
                .OrderByDescending(x => x.StartDate)
                .ToList()
                .Select(x => x.ToViewModel());

            return viewModel.ToList();
        }

        [Route("{id}")]
        public PayPeriodViewModel GetById(Guid id)
        {
            var viewModel = _db.Periods.Find(id).ToViewModel();

            return viewModel;
        }

        [HttpPost]
        [Route("")]
        public PayPeriodViewModel Create([FromBody] PayPeriodViewModel viewModel)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid period model");

            if (_db.Periods.Any(x => x.StartDate == viewModel.StartDate))
            {
                throw new HttpApiException(string.Format("Pay period starting on {0} already exists", viewModel.StartDate.ToJsonShortDate()));
            }

            var model = viewModel.ToModel();
            model.Id = Guid.NewGuid();
                
            _db.Periods.Add(model);
            _db.SaveChanges();
                
            return model.ToViewModel(); // will grab extra fields
        }

        [HttpPut]
        [Route("")]
        public PayPeriodViewModel Update([FromBody] PayPeriodViewModel viewModel)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid period model");

            var model = viewModel.ToModel();

            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return model.ToViewModel();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var period = _db.Periods.Find(id);

            if (period == null)
                throw new HttpApiException("Period not found");

            _db.Periods.Remove(period);
            _db.SaveChanges();
        }
    }
}