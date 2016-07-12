using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IEJPApps.Extensions;

namespace IEJPApps.Models.Repositories
{
    public class ExpenditureRepository : Repository<ExpenditureTransaction>
    {
        public new List<ExpenditureTransaction> GetAll()
        {
            var query = Set
                .OrderByDescending(x => x.TransactionDate)
                .Include(x => x.Project)
                .Include(x => x.Employee);

            if (CurrentUser.IsAdmin()) return query.ToList();
            
            var employeeId = new Guid(CurrentUser.GetEmployeeId());
            query = query.Where(x => x.EmployeeId == employeeId);

            return query.ToList();
        }

        public new ExpenditureTransaction GetByID(Guid id)
        {
            var transaction = Set.Find(id);

            if (transaction != null && !CurrentUser.IsAdmin())
            {
                var employeeId = new Guid(CurrentUser.GetEmployeeId());
                if (transaction.EmployeeId != employeeId)
                    return null;
            }

            return transaction;
        }

        /*        
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

        public ExpenditureTransaction Update([FromBody] ExpenditureTransaction transaction)
        {
            // TODO : Validate if admin vs emplyeeId ?
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
            // TODO : Validate if admin vs emplyeeId ?
            var transaction = _db.ExpenditureTransactions.Find(id);

            if (transaction == null)
                throw new Exception("Expenditure Transaction Not Found");

            _db.ExpenditureTransactions.Remove(transaction);
            _db.SaveChanges();
        }
        */
    }
}