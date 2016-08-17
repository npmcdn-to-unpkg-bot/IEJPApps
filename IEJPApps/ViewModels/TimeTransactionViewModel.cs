using System;

namespace IEJPApps.ViewModels
{
    public class TimeTransactionViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public bool Visible { get; set; }
        public DateTime TransactionDate { get; set; }
        public ProjectLookupViewModel Project { get; set; }
        public EmployeeLookupViewModel Employee { get; set; }
        public decimal Time { get; set; }
        public string Comment { get; set; }
    }
}