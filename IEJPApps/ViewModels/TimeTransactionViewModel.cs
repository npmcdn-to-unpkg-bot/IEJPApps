using System;
using System.ComponentModel.DataAnnotations;

namespace IEJPApps.Models
{
    public class TimeTransactionViewModel
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid ProjectId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Time { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
    }
}