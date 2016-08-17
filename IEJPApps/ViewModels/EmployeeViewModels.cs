using System;

namespace IEJPApps.ViewModels
{
    public class EmployeeViewModel
    {
    }

    public class EmployeeLookupViewModel
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}