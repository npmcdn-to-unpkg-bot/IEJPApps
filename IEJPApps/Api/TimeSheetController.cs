using System;
using IEJPApps.Models;
using IEJPApps.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Exceptions;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/timesheet")]
    public class TimeSheetController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Route("")]
        public List<TimeTransaction> GetAll()
        {
            return _db.TimeTransactions
                .OrderByDescending(x => x.TransactionDate)
                .Include(x => x.Project)
                .Include(x => x.Employee)
                .ToList();
        }

        [Route("{id}")]
        public TimeTransaction GetById(Guid id)
        {
            return _db.TimeTransactions.Find(id);
        }

        [HttpPost]
        [Route("")]
        public TimeTransaction Create([FromBody] TimeTransaction transaction)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid Time Transaction Model");

            transaction.Id = Guid.NewGuid();
            transaction.Created = DateTime.Now;

            _db.TimeTransactions.Add(transaction);
            _db.SaveChanges();

            return transaction;
        }

        [HttpPut]
        [Route("")]
        public TimeTransaction Update([FromBody] TimeTransaction transaction)
        {
            if (!ModelState.IsValid) throw new HttpApiException("Invalid Time Transaction Model");

            _db.Entry(transaction).State = EntityState.Modified;
            _db.SaveChanges();

            return transaction;
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var transaction = _db.TimeTransactions.Find(id);

            if (transaction == null)
                throw new HttpApiException("Time Transaction Not Found");

            _db.TimeTransactions.Remove(transaction);
            _db.SaveChanges();
        }
    }
}