using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Exporter;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CoreWebAPIWithTelemetry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen();

            var shipOption = Configuration.GetValue<string>("ShipOption").ToLowerInvariant();
            switch(shipOption)
            {
                case "jaeger":
                    //Jaeger Exporter
                    services.AddOpenTelemetryTracing((builder) => builder
                       .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(this.Configuration.GetValue<string>("Jaeger:ServiceName")))
                       .AddAspNetCoreInstrumentation()
                       .AddHttpClientInstrumentation()
                       .AddJaegerExporter());

                    services.Configure<JaegerExporterOptions>(this.Configuration.GetSection("Jaeger"));
                    break;
                case "newrelic":
                    //NewRelic Exporter
                    services.AddOpenTelemetryTracing((tracerBuilder) =>
                    {

                        // Adds the New Relic Exporter loading settings from the appsettings.json
                        tracerBuilder
                            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(this.Configuration.GetValue<string>("NewRelic:ServiceName")))
                            .AddNewRelicExporter(options =>
                            {
                                options.ApiKey = this.Configuration.GetValue<string>("NewRelic:ApiKey");
                            })
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation();
                    });
                    break;
                default:
                    services.AddOpenTelemetryTracing((builder) => builder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddConsoleExporter());

                    services.Configure<AspNetCoreInstrumentationOptions>(this.Configuration.GetSection("AspNetCoreInstrumentation"));
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
