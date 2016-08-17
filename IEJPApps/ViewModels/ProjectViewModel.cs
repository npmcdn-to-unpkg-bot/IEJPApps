using IEJPApps.Models;
using System;
using System.Collections.Generic;

namespace IEJPApps.ViewModels
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string ProjectNumber { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public List<TimeTransactionViewModel> TimeTransactions { get; set; }
        public List<ExpenditureTransaction> ExpenditureTransactions { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Completed { get; set; }
    }

    public class ProjectLookupViewModel
    {
        public Guid Id { get; set; }
        public string ProjectNumber { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
    }
}