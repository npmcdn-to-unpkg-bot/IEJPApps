using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IEJPApps.Models
{
    public partial class Project
    {
        [Key]
        public Guid Id { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Active", AutoGenerateFilter = false)]
        public bool Active { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Visible", AutoGenerateFilter = false)]
        public bool Visible { get; set; }

        [Display(Name = "Number", AutoGenerateFilter = false)]
        public string ProjectNumber { get; set; }

        [Display(Name = "Customer", AutoGenerateFilter = false)]
        public string Customer { get; set; }

        [Display(Name = "Description", AutoGenerateFilter = false)]
        public string Description { get; set; }
        
        [Display(Name = "TimeTransactions", AutoGenerateFilter = false)]
        public virtual ICollection<TimeTransaction> TimeTransactions { get; set; }

        [Display(Name = "ExpenditureTransactions", AutoGenerateFilter = false)]
        public virtual ICollection<ExpenditureTransaction> ExpenditureTransactions { get; set; }

        [Display(Name = "Created", AutoGenerateFilter = false)]
        public DateTime? Created { get; set; }

        [Display(Name = "Updated", AutoGenerateFilter = false)]
        public DateTime? Updated { get; set; }

        [Display(Name = "Started", AutoGenerateFilter = false)]
        public DateTime? Started { get; set; }

        [Display(Name = "Completed", AutoGenerateFilter = false)]
        public DateTime? Completed { get; set; }
    }
}