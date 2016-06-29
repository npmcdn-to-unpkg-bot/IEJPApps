using System;
using IEJPApps.Models;
using IEJPApps.Models.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Extensions;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/expenditures")]
    public class ExpendituresController : ApiController
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ExpendituresController(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        [Route("")]
        public List<ExpenditureTransaction> GetAll()
        {
            var query = _db.ExpenditureTransactions
                .OrderByDescending(x => x.TransactionDate)
                .Include(x => x.Project)
                .Include(x => x.Employee);

            //var employeeId = _applicationUserManager.GetEmployeeId();
            var employeeId = new Guid(User.GetEmployeeId());
            if (!User.IsAdmin())
            {
                query = query.Where(x => x.EmployeeId == employeeId);
            }

            return query.ToList();
        }

        [Route("{id}")]
        public ExpenditureTransaction GetById(Guid id)
        {
            return _db.ExpenditureTransactions.Find(id);
        }

        [HttpPost]
        [Route("")]
        public ExpenditureTransaction Create([FromBody] ExpenditureTransaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.Id = Guid.NewGuid();
                transaction.Created = DateTime.Now;

                _db.ExpenditureTransactions.Add(transaction);
                _db.SaveChanges();

                return transaction;
            }

            throw new Exception("Invalid Expenditure Transaction Model");
        }

        [HttpPut]
        [Route("")]
        public ExpenditureTransaction Update([FromBody] ExpenditureTransaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();

                return transaction;
            }

            throw new Exception("Invalid Expenditure Transaction Model");
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var transaction = _db.ExpenditureTransactions.Find(id);

            if (transaction == null)
                throw new Exception("Expenditure Transaction Not Found");

            _db.ExpenditureTransactions.Remove(transaction);
            _db.SaveChanges();
        }
    }
}