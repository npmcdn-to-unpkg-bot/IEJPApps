using System;
using IEJPApps.Models;
using IEJPApps.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/time")]
    public class TimeTransactionsController : ApiController
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
            if (ModelState.IsValid)
            {
                transaction.Id = Guid.NewGuid();
                transaction.Created = DateTime.Now;

                _db.TimeTransactions.Add(transaction);
                _db.SaveChanges();

                return transaction;
            }

            throw new Exception("Invalid Time Transaction Model");
        }

        [HttpPut]
        [Route("")]
        public TimeTransaction Update([FromBody] TimeTransaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();

                return transaction;
            }

            throw new Exception("Invalid Time Transaction Model");
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var transaction = _db.TimeTransactions.Find(id);

            if (transaction == null)
                throw new Exception("Time Transaction Not Found");

            _db.TimeTransactions.Remove(transaction);
            _db.SaveChanges();
        }
    }
}