using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IEJPApps.Models.Interfaces;
using IEJPApps.Resources;

namespace IEJPApps.Models
{
    public partial class Period : IEntityVisibility
    {
        [Key]
        public Guid Id { get; set; }

        [DefaultValue(true)]
        [Display(ResourceType = typeof (Strings), Name = "Period_Active", AutoGenerateFilter = false)]
        public bool Active { get; set; }

        [DefaultValue(true)]
        [Display(ResourceType = typeof (Strings), Name = "Period_Visible", AutoGenerateFilter = false)]
        public bool Visible { get; set; }

        [Display(ResourceType = typeof (Strings), Name = "Period_StartDate", AutoGenerateFilter = false)]
        public DateTime StartDate { get; set; }

        [Display(ResourceType = typeof (Strings), Name = "Period_EndDate", AutoGenerateFilter = false)]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Period_OpenedDate", AutoGenerateFilter = false)]
        public DateTime? OpenedDate { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Period_ClosedDate", AutoGenerateFilter = false)]
        public DateTime? ClosedDate { get; set; }
    }
}