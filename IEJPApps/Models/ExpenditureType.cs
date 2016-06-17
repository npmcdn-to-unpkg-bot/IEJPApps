using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IEJPApps.Models.Interfaces;

namespace IEJPApps.Models
{
    public partial class ExpenditureType : IEntityVisibility
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Name", AutoGenerateFilter = false)]
        public string Name { get; set; }

        [Display(Name = "Description", AutoGenerateFilter = false)]
        public string Description { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Active", AutoGenerateFilter = false)]
        public bool Active { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Visible", AutoGenerateFilter = false)]
        public bool Visible { get; set; }        
    }
}