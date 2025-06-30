using System;

namespace DateCoreApp.Factories
{
    public class ISOFormatter : IDateFormatter
    {
        public string Format(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss");
        }
    }
}
