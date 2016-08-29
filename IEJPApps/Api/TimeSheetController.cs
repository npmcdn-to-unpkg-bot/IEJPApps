using System;
using System.Collections.Generic;
using System.Web.Http;
using IEJPApps.Exceptions;
using IEJPApps.Models;
using IEJPApps.Repositories;
using IEJPApps.ViewModels;
using Microsoft.Ajax.Utilities;

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
        public TimeTransactionViewModel Create([FromBody] TimeTransactionViewModel transaction)
        {
            if (!ModelState.IsValid)
                throw new HttpApiException("Invalid Time Transaction Model");

            var entity = _timesheets.Create(new TimeTransaction
            {
                Active = transaction.Active,
                Visible = transaction.Visible,
                TransactionDate = transaction.TransactionDate,
                ProjectId = transaction.Project.IfNotNull(x => x.Id),
                EmployeeId = transaction.Employee.IfNotNull(x => x.Id),
                Time = transaction.Time,
                Comment = transaction.Comment
            });

            return AutoMapper.Mapper.Map<TimeTransactionViewModel>(entity);
            //return GetById(entity.Id); // reload newly updated transaction to get all values
        }

        [HttpPut]
        [Route("")]
        public TimeTransactionViewModel Update([FromBody] TimeTransactionViewModel transaction)
        {
            if (!ModelState.IsValid)
                throw new HttpApiException("Invalid Time Transaction Model");
            
            var entity = _timesheets.GetByID(transaction.Id);
            if (entity != null)
            {
                entity.Active = transaction.Active;
                entity.Visible = transaction.Visible;
                entity.TransactionDate = transaction.TransactionDate;
                entity.ProjectId = transaction.Project.IfNotNull(x => x.Id);
                entity.EmployeeId = transaction.Employee.IfNotNull(x => x.Id);
                entity.Time = transaction.Time;
                entity.Comment = transaction.Comment;

                entity = _timesheets.Update(entity); // entity => updated value
            }
            
            return GetById(transaction.Id); // reload newly updated transaction to get all values
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