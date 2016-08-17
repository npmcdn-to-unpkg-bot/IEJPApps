using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IEJPApps.Models.Interfaces;

namespace IEJPApps.Models
{
    public class TimeTransaction : IEntityVisibility
    {
        [Key]
        public Guid Id { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Active", AutoGenerateFilter = false)]
        public bool Active { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Visible", AutoGenerateFilter = false)]
        public bool Visible { get; set; }
        
        [Display(Name = "TransactionDate", AutoGenerateFilter = false)]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "ProjectId", AutoGenerateFilter = false)]
        public Guid ProjectId { get; set; }

        [Display(Name = "Project", AutoGenerateFilter = false)]
        public virtual Project Project { get; set; }

        [Display(Name = "EmployeeId", AutoGenerateFilter = false)]
        public Guid EmployeeId { get; set; }

        [Display(Name = "Employee", AutoGenerateFilter = false)]
        public virtual Employee Employee { get; set; }

        [Display(Name = "Time", AutoGenerateFilter = false)]
        public decimal Time { get; set; }

        [Display(Name = "Comment", AutoGenerateFilter = false)]
        public string Comment { get; set; }

        [Display(Name = "Created", AutoGenerateFilter = false)]
        public DateTime Created { get; set; }
    }
}