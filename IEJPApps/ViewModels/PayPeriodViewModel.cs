using System;

namespace IEJPApps.ViewModels
{
    public class PayPeriodViewModel
    {
        public Guid? Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int WeekNumber { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
    }
}