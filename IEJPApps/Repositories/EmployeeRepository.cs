using System;
using System.Collections.Generic;
using System.Linq;
using IEJPApps.Models;

namespace IEJPApps.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public List<Employee> LookupAll()
        {
            return Set.ToList();
        }

        public Employee GetEmployee(Guid userId)
        {
            return Set.FirstOrDefault(x => x.AspNetUserId == userId);
        }

        public Guid? GetEmployeeId(Guid userId)
        {
            var employee = GetEmployee(userId);
            if (employee != null)
                return employee.Id;
            return null;
        }
    }
}
