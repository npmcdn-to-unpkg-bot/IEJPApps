using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IEJPApps.Extensions;
using IEJPApps.Models;

namespace IEJPApps.Repositories
{
    public class ExpenditureRepository : Repository<ExpenditureTransaction>
    {
        public new List<ExpenditureTransaction> GetAll()
        {
            var query = Set
                .OrderByDescending(x => x.TransactionDate)
                .Include(x => x.Project)
                .Include(x => x.Employee);

            if (CurrentUser.IsAdmin())
            {
                return query.ToList(); // return for all employees
            }
            
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
                {
                    return null;
                }
            }

            return transaction;
        }
        
        public new ExpenditureTransaction Create(ExpenditureTransaction transaction)
        {
            transaction.Id = Guid.NewGuid();
            transaction.Created = DateTime.Now;

            if (!CurrentUser.IsAdmin())
            {
                // make sure we set the employee id to the one from the current employee
                transaction.EmployeeId = new Guid(CurrentUser.GetEmployeeId());
            }

            return base.Create(transaction);
        }
    }
}