using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.AppService;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using OriginFinancial.CodingChallenge.Domain.Service;
using OriginFinancial.CodingChallenge.Infra.Data.Context;
using OriginFinancial.CodingChallenge.Infra.Data.Environment;
using OriginFinancial.CodingChallenge.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OriginFinancial.CodingChallenge.Infra.IoC
{
    /// <summary>
    /// The class containing all of the dependency injection methods' registration.
    /// </summary>
    public class NativeInjector
    {
        /// <summary>
        /// The method for registering the data the comes from static external data.
        /// </summary>
        /// <param name="services">The interface for specifying contracts for multiple layers of services.</param>
        /// <param name="configuration">The interface for the configuration builder contract specification.</param>
        public static void RegisterExternalConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                //Registering the environment variables for the contexts.
                services.Configure<EnvironmentConfiguration>(configuration.GetSection("EnvironmentConfiguration"));
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The method for registering the dependency injection of contexts.
        /// </summary>
        /// <param name="services">The interface for specifying contracts for multiple layers of services.</param>
        /// <param name="configuration">The interface for the configuration builder contract specification.</param>
        public static void RegisterContexts(IServiceCollection services, IConfiguration configuration)
        {
            string EnvironmentName = configuration.GetValue<string>("EnvironmentConfiguration:EnvironmentVariables:0:EnvironmentName");
            string ConnStringsName = configuration.GetValue<string>("EnvironmentConfiguration:EnvironmentVariables:0:Contexts:ConnStringsName");
            string MainDatabaseContextName = configuration.GetValue<string>("EnvironmentConfiguration:EnvironmentVariables:0:Contexts:DatabaseNames:0");

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
            services.AddScoped<IDomainAppService, DomainAppService>();
            services.AddScoped<IRiskQuestionAppService, RiskQuestionAppService>();

            //Registering the domain layer.
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IRiskQuestionService, RiskQuestionService>();

            //Registering the infra, and the data layer.
            services.AddScoped<IMainDatabaseContext, MainDatabaseContext>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IRiskQuestionRepository, RiskQuestionRepository>();
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

        /// <summary>
        /// The method for inserting inital data into the database.
        /// </summary>
        /// <param name="builder">Interface that allows a configuration of the application's request pipeline.</param>
        public static void SeedDatabases(IApplicationBuilder builder)
        {
            try
            {
                //Creating the scope for service factory.
                using (var scope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    //Creating the scope for context service.
                    using (var context = scope.ServiceProvider.GetRequiredService<MainDatabaseContext>())
                    {
                        //Ensuring that the database is created before seeding it.
                        context.Database.EnsureCreated();

                        //Risk questions.
                        if (context.RiskQuestion.Count().Equals(0))
                        {
                            context.RiskQuestion.Add(new RiskQuestion { Question = "First question", StatusID = 1, Created = DateTime.Now });
                            context.RiskQuestion.Add(new RiskQuestion { Question = "Second question", StatusID = 1, Created = DateTime.Now });
                            context.RiskQuestion.Add(new RiskQuestion { Question = "Third question", StatusID = 1, Created = DateTime.Now });
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The static method for retrieving the JWT base key for auth.
        /// </summary>
        /// <param name="services">The interface for specifying contracts for multiple layers of services;</param>
        /// <param name="configuration">The interface for the configuration builder contract specification.</param>
        /// <returns></returns>
        public static string RetrieveSecurityKey(IServiceCollection services, IConfiguration configuration)
        {
            string EnvironmentName = configuration.GetValue<string>("EnvironmentConfiguration:EnvironmentVariables:0:EnvironmentName");
            string SecName = configuration.GetValue<string>("EnvironmentConfiguration:EnvironmentVariables:0:Security:SecurityName");
            string SecValue = configuration.GetValue<string>("EnvironmentConfiguration:EnvironmentVariables:0:Security:SecurityValue");

            return configuration.GetSection($"{EnvironmentName}").GetSection($"{SecName}").GetSection($"{SecValue}").Value;
        }
    }
}
