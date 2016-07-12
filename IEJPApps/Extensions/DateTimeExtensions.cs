using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IEJPApps.Extensions
{
    public static class DateTimeExtensions
    {
        internal class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
        
        public static int GetWeekOfYear(this DateTime dateTime, DayOfWeek startDay)
        {
            var calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

            return calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, startDay);
        }

        /// <summary>
        /// Voir pour les spécifications ISO: http://www.epochconverter.com/weeks/2016
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="startDay"></param>
        /// <returns></returns>
        public static int GetISOWeekOfYear(this DateTime dateTime, DayOfWeek startDay)
        {
            var cal = CultureInfo.InvariantCulture.Calendar;
            var day = (int)cal.GetDayOfWeek(dateTime);

            dateTime = dateTime.AddDays(4 - (day == 0 ? 7 : day));

            return cal.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, startDay);
        }
        
        public static bool IsInCurrentPeriod(this DateTime dateTime, DayOfWeek startDay)
        {
            var firstDateOfWeek = dateTime.StartOfWeek(startDay);
            var lastDayOfWeek = firstDateOfWeek.AddDays(6);
            var current = DateTime.Now.Date;

            return current >= firstDateOfWeek.Date && current <= lastDayOfWeek.Date;
        }

        public static string ToJsonShortDate(this DateTime dateTime)
        {
            return JsonConvert.SerializeObject(dateTime, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            });
        }

        public static string ToJsonLongDate(this DateTime dateTime)
        {
            return JsonConvert.ToString(dateTime, DateFormatHandling.IsoDateFormat);
        }
    }
}