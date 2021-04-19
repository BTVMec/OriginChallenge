using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using OriginFinancial.CodingChallenge.Infra.Data.Environment;
using System;
using System.Linq;

namespace OriginFinancial.CodingChallenge.Infra.Data.Context
{
    /// <summary>
    /// The customized implementation of the EF Core DbContext.
    /// </summary>
    public class MainDatabaseContext : DbContext, IMainDatabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly EnvironmentConfiguration _envOptions;

        private readonly string EnvironmentName;
        private readonly string ConnStringsName;
        private readonly string MainDatabaseContextName;

        /// <summary>
        /// Constructor of the application's context.
        /// </summary>
        /// <param name="options">Options configured when registering this context for dependency injection.</param>
        /// <param name="configuration">Interface for the configuration builder contract specification.</param>
        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options, IConfiguration configuration, IOptions<EnvironmentConfiguration> envOptions) : base(options)
        {
            _configuration = configuration;
            _envOptions = envOptions.Value;
            EnvironmentName = _envOptions.EnvironmentVariables.FirstOrDefault(x => x.EnvironmentName.Contains("ORIGIN")).EnvironmentName;
            ConnStringsName = _envOptions.EnvironmentVariables.FirstOrDefault(x => x.EnvironmentName.Contains("ORIGIN")).Contexts.ConnStringsName;
            MainDatabaseContextName = _envOptions.EnvironmentVariables.FirstOrDefault(x => x.EnvironmentName.Contains("ORIGIN")).Contexts.DatabaseNames.FirstOrDefault(x => x.Contains("MAIN")).ToString();
        }

        /// <summary>
        /// The method that overrides the configuration for the DbContextOptions.
        /// </summary>
        /// <param name="optionsBuilder">API surface for configurtion the DbContextOptions.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //If the options for building context isn't set, set here.
                if (optionsBuilder.IsConfigured)
                {
                    var config = _configuration
                        .GetSection($"{EnvironmentName}")
                        .GetSection($"{ConnStringsName}")
                        .GetSection($"{MainDatabaseContextName}")
                        .Value;
                    optionsBuilder.UseMySql(config);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The method for configuring entities further from the properties discovered by EF.
        /// </summary>
        /// <param name="modelBuilder">API surface for configurtion the entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //Setting the database's context entities.
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerRiskQuestion> CustomerRiskQuestion { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<RiskQuestion> RiskQuestion { get; set; }
    }
}
