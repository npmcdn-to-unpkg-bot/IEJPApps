using System;
using System.Globalization;
using System.Collections.Generic;
using IEJPApps.Extensions;
using IEJPApps.ViewModels;

namespace IEJPApps.Services
{
    public class TimeService
    {
        public static DayOfWeek GetWeekStartDay()
        {
            // TODO : Devrait etre configurable
            return DayOfWeek.Monday;
            //return DayOfWeek.Sunday;
        }

        public static PayPeriodViewModel GetCurrentPayPeriod()
        {
            return GetPayPeriod(DateTime.Now);
        }

        public static PayPeriodViewModel GetPayPeriod(DateTime dateTime)
        {
            var firstDateOfWeek = dateTime.StartOfWeek(GetWeekStartDay());
            var weekNumber = dateTime.GetISOWeekOfYear(GetWeekStartDay());
            var lastDayOfWeek = firstDateOfWeek.AddDays(6);

            return new PayPeriodViewModel
            {
                StartDate = firstDateOfWeek,
                EndDate = lastDayOfWeek,
                WeekNumber = weekNumber,
                IsCurrent = DateTime.Now >= firstDateOfWeek && DateTime.Now <= lastDayOfWeek
            };
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            var ci = CultureInfo.InvariantCulture;
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            var firstWeekDay = jan1.AddDays(daysOffset);

            var firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1 || firstWeek > 50)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }

        public static List<PayPeriodViewModel> GetPeriodsFromCurrentPayPeriod(int before, int after)
        {
            var periods = new List<PayPeriodViewModel>();
            var currentPeriod = GetCurrentPayPeriod();

            for (int i = -before; i < after; i++)
            {
                var weekStartDate = currentPeriod.StartDate.AddDays(7 * i);

                periods.Add(GetPayPeriod(weekStartDate));
            }

            return periods;
        }
    }
}