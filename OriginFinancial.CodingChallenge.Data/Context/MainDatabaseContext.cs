using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using System;

namespace OriginFinancial.CodingChallenge.Infra.Data.Context
{
    /// <summary>
    /// The customized implementation of the EF Core DbContext.
    /// </summary>
    public class MainDatabaseContext : DbContext, IMainDatabaseContext
    {
        private static readonly string EnvironmentName = "ORIGIN_ENVIRONMENT";
        private static readonly string ConnStringsName = "CONN_STRINGS";
        private static readonly string MainDatabaseContextName = "ORIGIN_MAIN_DATABASE";

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor of the application's context.
        /// </summary>
        /// <param name="options">Options configured when registering this context for dependency injection.</param>
        /// <param name="configuration">Interface for the configuration builder contract specification.</param>
        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
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
        public DbSet<InsuranceContract> InsuranceContract { get; set; }
        public DbSet<RiskQuestion> RiskQuestion { get; set; }
    }
}
