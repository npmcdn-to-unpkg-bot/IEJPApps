using System;
using IEJPApps.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using IEJPApps.Exceptions;
using IEJPApps.Infrastructure;

namespace IEJPApps.Api
{
    [Authorize]
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [Route("")]
        public List<Employee> GetAll()
        {
            return _db.Employees
                .Include(x => x.TimeTransactions)
                .OrderBy(x => x.Number)
                .ToList();
        }

        [Route("{id}")]
        public Employee GetById(Guid id)
        {
            return _db.Employees
                .Include(x => x.TimeTransactions)
                .Include(x => x.ExpenditureTransactions)
                .SingleOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("")]
        public Employee Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = Guid.NewGuid();

                _db.Employees.Add(employee);
                _db.SaveChanges();

                return employee;
            }

            throw new HttpApiException("Invalid Employee Model");
        }

        [HttpPut]
        [Route("")]
        public Employee Update([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();

                return employee;
            }

            throw new HttpApiException("Invalid Employee Model");
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            var employee = _db.Employees.Find(id);

            if (employee == null)
                throw new HttpApiException("Employee Not Found");

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}