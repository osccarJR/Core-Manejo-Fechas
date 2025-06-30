using System;

namespace DateCoreApp.Services.Interfaces
{
    public interface ISystemDateProvider
    {
        DateTime Now { get; }
    }
}
