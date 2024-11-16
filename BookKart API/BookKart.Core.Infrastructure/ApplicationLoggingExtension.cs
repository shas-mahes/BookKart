using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace BookKart.Core.Infrastructure;

public static class ApplicationLoggingExtension
{
    public static void AddNLogger(this ILoggingBuilder logger, IHostBuilder host)
    {
        // NLog: Setup NLog for Dependency injection
        logger.ClearProviders();
        host.UseNLog();
    }
}
