using System;

namespace HelloAspNetCoreTagHelpers.Site.Infrastructure
{
    public interface ITimeSinceService
    {
        string TimeSince(DateTime from);
    }
}
