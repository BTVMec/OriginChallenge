using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.AppService;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using OriginFinancial.CodingChallenge.Domain.Service;
using OriginFinancial.CodingChallenge.Infra.Data.Context;
using System;

namespace OriginFinancial.CodingChallenge.Infra.IoC
{
    /// <summary>
    /// The class containing all of the dependency injection methods' registration.
    /// </summary>
    public class NativeInjector
    {
        private static readonly string EnvironmentName = "ORIGIN_ENVIRONMENT";
        private static readonly string ConnStringsName = "CONN_STRINGS";
        private static readonly string MainDatabaseContextName = "ORIGIN_MAIN_DATABASE";

        /// <summary>
        /// The method for registering the dependency injection of contexts.
        /// </summary>
        /// <param name="services">The interface for specifying contracts for multiple layers of services.</param>
        /// <param name="configuration">The interface for the configuration builder contract specification.</param>
        public static void RegisterContexts(IServiceCollection services, IConfiguration configuration)
        {
            //Registering the main database context.
            services.AddDbContext<MainDatabaseContext>(
                    options => options.UseMySql
                    (
                        configuration
                        .GetSection($"{EnvironmentName}")
                        .GetSection($"{ConnStringsName}")
                        .GetSection($"{MainDatabaseContextName}")
                        .Value
                    ),
                    ServiceLifetime.Scoped
                );
        }

        /// <summary>
        /// The method for registering the dependency injection of multiple classes of services.
        /// </summary>
        /// <param name="services">The interface for specifying contracts for multiple layers of services;</param>
        public static void RegisterServices(IServiceCollection services)
        {
            //Registering the appService layer.
            services.AddScoped<IContractAppService, ContractAppService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IRiskQuestionAppService, RiskQuestionAppService>();

            //Registering the domain layer.
            services.AddScoped<IContractService, ContractService>();

            //Registering the infra, and the data layer.
            services.AddScoped<IMainDatabaseContext, MainDatabaseContext>();
        }

        /// <summary>
        /// The method for running contexts' migrations.
        /// </summary>
        /// <param name="builder">Interface that allows a configuration of the application's request pipeline.</param>
        public static void MigrateContexts(IApplicationBuilder builder)
        {
            try
            {
                //Creating scope for service and running migrations - Braidan Capital Quotes Context.
                using (var scope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<MainDatabaseContext>().Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
