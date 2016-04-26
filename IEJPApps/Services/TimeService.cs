using System;
using IEJPApps.ViewModels;
using System.Globalization;
using System.Collections.Generic;

namespace IEJPApps.Services
{
    public class TimeService
    {
        public static DayOfWeek GetWeekStartDay()
        {
            return DayOfWeek.Monday; // TODO : Devrait etre configurable
        }

        public static PayPeriodViewModel GetCurrentPayPeriod()
        {
            return GetPayPeriod(DateTime.Now);
        }

        public static PayPeriodViewModel GetPayPeriod(DateTime dateTime)
        {
            var weekNumber = GetIso8601WeekOfYear(dateTime);
            var firstDateOfWeek = FirstDateOfWeek(dateTime.Year, weekNumber);
            var lastDayOfWeek = firstDateOfWeek.AddDays(7);

            return new PayPeriodViewModel
            {
                StartDate = firstDateOfWeek,
                EndDate = lastDayOfWeek,
                WeekNumber = weekNumber,
                IsCurrent = dateTime >= firstDateOfWeek && dateTime <= lastDayOfWeek
            };
        }

        public static int GetIso8601WeekOfYear(DateTime dateTime)
        {
            //DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
            //if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            //{
            //    dateTime = dateTime.AddDays(3);
            //}
            //return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var cal = CultureInfo.InvariantCulture.Calendar;
            var day = (int)cal.GetDayOfWeek(dateTime);

            dateTime = dateTime.AddDays(4 – (day == 0 ? 7 : day));

            return cal.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, GetWeekStartDay());
        }

        public static int GetWeekOfYear(DateTime dateTime)
        {
            var weekStart = GetWeekStartDay();
            var weekNumber = new GregorianCalendar(GregorianCalendarTypes.Localized)
                .GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, weekStart);
            return weekNumber;
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

                periods.Add(new PayPeriodViewModel
                {
                    StartDate = weekStartDate,
                    EndDate = weekStartDate.AddDays(7),
                    WeekNumber = GetIso8601WeekOfYear(weekStartDate),
                    IsCurrent = weekStartDate == currentPeriod.StartDate
                });
            }

            return periods;
        }
    }
}