using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEJPApps.Models.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
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
