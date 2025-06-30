namespace DateCoreApp.Factories
{
    public static class DateFormatFactory
    {
        public static IDateFormatter GetFormatter(string type)
        {
            return type.ToLower() switch
            {
                "iso" => new ISOFormatter(),
                "readable" => new ReadableFormatter(),
                _ => new ISOFormatter()
            };
        }
    }
}
