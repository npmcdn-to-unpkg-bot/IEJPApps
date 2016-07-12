using System;
using IEJPApps.Models;
using IEJPApps.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Exceptions;
using IEJPApps.Extensions;
using IEJPApps.Models.Repositories;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/expenditures")]
    public class ExpendituresController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly ExpenditureRepository _expenditures = new ExpenditureRepository();

        [Route("")]
        public List<ExpenditureTransaction> GetAll()
        {
            return _expenditures.GetAll();
        }

        [Route("{id}")]
        public ExpenditureTransaction GetById(Guid id)
        {
            return _expenditures.GetByID(id);

            //var transaction = _db.ExpenditureTransactions.Find(id);

            //if (transaction != null && !User.IsAdmin())
            //{
            //    var employeeId = new Guid(User.GetEmployeeId());
            //    if (transaction.EmployeeId != employeeId)
            //        return null;
            //}

            //return transaction;
        }

        [HttpPost]
        [Route("")]
        public ExpenditureTransaction Create([FromBody] ExpenditureTransaction transaction)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid Expenditure Transaction Model");

            transaction.Id = Guid.NewGuid();
            transaction.Created = DateTime.Now;

            _db.ExpenditureTransactions.Add(transaction);
            _db.SaveChanges();

            return transaction;
        }

        [HttpPut]
        [Route("")]
        public ExpenditureTransaction Update([FromBody] ExpenditureTransaction transaction)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid Expenditure Transaction Model");

            // TODO : Validate if admin vs emplyeeId ?
            _db.Entry(transaction).State = EntityState.Modified;
            _db.SaveChanges();

            return transaction;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            // TODO : Validate if admin vs emplyeeId ?
            var transaction = _db.ExpenditureTransactions.Find(id);

            if (transaction == null)
                throw new HttpApiException("Expenditure Transaction Not Found");

            _db.ExpenditureTransactions.Remove(transaction);
            _db.SaveChanges();
        }
    }
}