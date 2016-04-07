using System;

namespace IEJPApps.ViewModels
{
    public class PayPeriodViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }
        public bool IsCurrent { get; set; }
    }
}