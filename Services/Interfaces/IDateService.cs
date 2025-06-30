using System;

namespace DateCoreApp.Services.Interfaces
{
    public interface IDateService
    {
        DateTime GetCurrentDate();
        double GetDaysBetween(DateTime from, DateTime to);
        string FormatDate(DateTime date, string formatType);
        DateTime ConvertToTimeZone(DateTime date, string timeZoneId);
    }
}
