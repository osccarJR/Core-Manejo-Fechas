using System;
using DateCoreApp.Services.Interfaces;

namespace DateCoreApp.Services.Implementations
{
    public class SystemDateProvider : ISystemDateProvider
    {
        private static readonly Lazy<SystemDateProvider> _instance = 
            new Lazy<SystemDateProvider>(() => new SystemDateProvider());

        public static SystemDateProvider Instance => _instance.Value;

        private SystemDateProvider() { }

        public DateTime Now => DateTime.Now;
    }
}
