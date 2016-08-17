using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using IEJPApps.Extensions;
using IEJPApps.Models;

namespace IEJPApps.Repositories
{
    public class TimeSheetRepository : Repository<TimeTransaction>
    {
        public new List<TimeTransaction> GetAll()
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

        public new TimeTransaction GetByID(Guid id)
        {
            var transaction = Set
                .Where(x => x.Id == id)
                .Include(x => x.Project)
                .Include(x => x.Employee)
                .FirstOrDefault();

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
        
        public new TimeTransaction Create(TimeTransaction transaction)
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