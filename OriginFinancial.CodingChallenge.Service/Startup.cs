using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using OriginFinancial.CodingChallenge.Service.Utils.Extensions;
using OriginFinancial.CodingChallenge.Service.Utils.Middleware;
using System.Globalization;

namespace OriginFinancial.CodingChallenge.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The Startup configurations and services registration for host lifetime and applications'
        /// running environment.
        /// </summary>
        /// <param name="hostEnvironment">Web host environment interface.</param>
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(hostEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Service collection injected interface.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Adds the MVC service with its middleware (configuring the MVC compatibility version, and the JSON binding/culture options).
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest)
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                options.SerializerSettings.Culture = new CultureInfo("en-US");
                options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateFormatString = "yyyy/MM/dd HH:mm:ss";
            });

            //Adding the custom DI services.
            services.AddDIConfigurations(Configuration);

            //Adding authorization.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Master", policy => policy.RequireClaim("Origin Roles", new string[] { "Master" }));
                options.AddPolicy("Admin", policy => policy.RequireClaim("Origin Roles", new string[] { "Master", "Admin" }));
                options.AddPolicy("Customer", policy => policy.RequireClaim("Origin Roles", new string[] { "Master", "Admin", "Customer" }));
            });

            //Adding Swagger.
            services.AddSwaggerDocument(configurations =>
            {
                configurations.Version = "v 1.0";
                configurations.DocumentName = $"OIAService - {configurations.Version}";
                configurations.Title = "Origin's Insurance Advisor Service";
                configurations.Description = $"Insurance selection microservice - {configurations.Version}";
                configurations.UseRouteNameAsOperationId = false;
                configurations.GenerateXmlObjects = true;
                configurations.UseControllerSummaryAsTagDescription = true;
                configurations.GenerateExamples = true;
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Interface that allows a configuration of the application's request pipeline.</param>
        /// <param name="env">Web host environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Setting the exception handler.
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }

            //Setting the usage of authorization.
            app.UseAuthentication();

            //Checking/running the available migrations.
            app.MigrateContexts();

            //Checking/running the initial database's seed.
            app.SeedDatabase();

            //Setting the usage of static files.
            app.UseStaticFiles();

            //Setting the usage of routing.
            app.UseRouting();

            //Setting the usage of authorization.
            app.UseAuthorization();

            //Adding Open API to the requests' pipeline.
            app.UseOpenApi();

            //Adding Swagger to the requests' pipeline.
            app.UseSwaggerUi3();

            //Setting the usage of mapped endpoints.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
