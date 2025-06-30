using System;

namespace DateCoreApp.Factories
{
    public class ReadableFormatter : IDateFormatter
    {
        public string Format(DateTime date)
        {
            return date.ToString("dddd, dd MMMM yyyy");
        }
    }
}
