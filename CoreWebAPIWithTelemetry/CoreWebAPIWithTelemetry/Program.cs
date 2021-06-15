using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPIWithTelemetry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.ClearProviders();
                    builder.AddConsole();

                    bool useLogging = context.Configuration.GetValue<bool>("UseLogging");
                    if(useLogging)
                    {
                        builder.AddOpenTelemetry(options =>
                        {
                            options.IncludeScopes = true;
                            options.ParseStateValues = true;
                            options.IncludeFormattedMessage = true;
                            options.AddConsoleExporter();
                        });
                    }
                });

    }
}
