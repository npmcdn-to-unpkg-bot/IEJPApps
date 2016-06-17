namespace IEJPApps.Services
{
    using System;
    using System.Collections.Generic;
    using ViewModels;

    public interface ITimeService
    {
        DayOfWeek GetWeekStartDay();
        PayPeriodViewModel GetCurrentPayPeriod();
        PayPeriodViewModel GetPayPeriod(DateTime dateTime);
        DateTime FirstDateOfWeek(int year, int weekOfYear);
        List<PayPeriodViewModel> GetPeriodsFromCurrentPayPeriod(int before, int after);
    }
}