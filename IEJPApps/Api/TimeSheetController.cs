using System;
using System.Collections.Generic;
using System.Web.Http;
using IEJPApps.Exceptions;
using IEJPApps.Models;
using IEJPApps.Repositories;
using IEJPApps.ViewModels;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/timesheet")]
    public class TimeSheetController : ApiController
    { 
        private readonly TimeSheetRepository _timesheets = new TimeSheetRepository();

        [Route("")]
        public List<TimeTransaction> GetAll()
        {
            return _timesheets.GetAll();
        }

        [Route("{id}")]
        public TimeTransactionViewModel GetById(Guid id)
        {
            var entity = _timesheets.GetByID(id);
            
            return AutoMapper.Mapper.Map<TimeTransactionViewModel>(entity);
        }
        
        [HttpPost]
        [Route("")]
        public TimeTransaction Create([FromBody] TimeTransaction transaction)
        {
            if (!ModelState.IsValid)
                throw new HttpApiException("Invalid Time Transaction Model");

            return _timesheets.Create(transaction);
        }

        [HttpPut]
        [Route("")]
        public TimeTransactionViewModel Update([FromBody] TimeTransactionViewModel transaction)
        {
            if (!ModelState.IsValid)
                throw new HttpApiException("Invalid Time Transaction Model");
            
            var entity = _timesheets.GetByID(transaction.Id);

            //// prevent these from beeing changed
            //entity.Employee = null;
            //entity.Project = null;

            AutoMapper.Mapper.Map<TimeTransactionViewModel, TimeTransaction>(transaction, entity);

            var updated = _timesheets.Update(entity);

            return AutoMapper.Mapper.Map<TimeTransactionViewModel>(updated);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var transaction = _timesheets.GetByID(id);

            if (transaction == null)
                throw new HttpApiException("Time Transaction Not Found");

            _timesheets.Delete(transaction);
        }
    }
}