using System;
using DateCoreApp.Services.Interfaces;
using DateCoreApp.Factories;

namespace DateCoreApp.Services.Implementations
{
    public class DateService : IDateService
    {
        private readonly ISystemDateProvider _dateProvider;

        public DateService(ISystemDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }

        public DateTime GetCurrentDate()
        {
            return _dateProvider.Now;
        }

        public double GetDaysBetween(DateTime from, DateTime to)
        {
            return (to - from).TotalDays;
        }

        public string FormatDate(DateTime date, string formatType)
        {
            var formatter = DateFormatFactory.GetFormatter(formatType);
            return formatter.Format(date);
        }

        public DateTime ConvertToTimeZone(DateTime date, string timeZoneId)
        {
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return TimeZoneInfo.ConvertTime(date, tz);
        }
    }
}
