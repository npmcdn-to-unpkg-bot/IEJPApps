using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IEJPApps.Models
{
    public partial class Period
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "StartDate", AutoGenerateFilter = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate", AutoGenerateFilter = false)]
        public DateTime EndDate { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Active", AutoGenerateFilter = false)]
        public bool Active { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Visible", AutoGenerateFilter = false)]
        public bool Visible { get; set; }        
    }
}