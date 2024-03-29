﻿using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace PointOfSale.Api.LoggingConfigurations
{
    public static class Logging
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
           (hostingContext, loggerConfiguration) =>
           {
               var env = hostingContext.HostingEnvironment;

               loggerConfiguration.MinimumLevel.Information()
                   .Enrich.FromLogContext()
                   .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                   .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                   .Enrich.WithExceptionDetails()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                   .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                   .WriteTo.Console();

               if (hostingContext.HostingEnvironment.IsDevelopment())
               {
                   loggerConfiguration.MinimumLevel.Override("PointOfSale", LogEventLevel.Debug);
               }
           };
    }
}
