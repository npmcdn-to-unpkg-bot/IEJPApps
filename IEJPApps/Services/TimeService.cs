using System;
using IEJPApps.ViewModels;
using System.Globalization;

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
            var firstDateOfWeek = FirstDateOfWeek(dateTime.Year, weekNumber, CultureInfo.InvariantCulture);

            return new PayPeriodViewModel
            {
                StartDate = firstDateOfWeek,
                EndDate = firstDateOfWeek.AddDays(7),
                WeekNumber = weekNumber
            };
        }

        public static int GetIso8601WeekOfYear(DateTime dateTime)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                dateTime = dateTime.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static int GetWeekOfYear(DateTime dateTime)
        {
            var weekStart = GetWeekStartDay();
            var weekNumber = new GregorianCalendar(GregorianCalendarTypes.Localized)
                .GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, weekStart);
            return weekNumber;
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1 || firstWeek > 50)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
    }
}