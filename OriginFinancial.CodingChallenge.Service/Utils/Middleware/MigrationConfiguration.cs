using Microsoft.AspNetCore.Builder;
using OriginFinancial.CodingChallenge.Infra.IoC;

namespace OriginFinancial.CodingChallenge.Service.Utils.Middleware
{
    /// <summary>
    /// The class for running migrations, when available.
    /// </summary>
    public static class MigrationConfigurations
    {
        /// <summary>
        /// The method for running contexts' migrations.
        /// </summary>
        /// <param name="builder">Interface that allows a configuration of the application's request pipeline.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> after configuring migrations.</returns>
        public static IApplicationBuilder MigrateContexts(this IApplicationBuilder builder)
        {
            try
            {
                //Migrating the databases.
                NativeInjector.MigrateContexts(builder);

                return builder;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The method for running the database's initial data seed.
        /// </summary>
        /// <param name="builder">Interface that allows a configuration of the application's request pipeline.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> after configuring migrations.</returns>
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
        {
            try
            {
                //Seeding the databases.
                NativeInjector.SeedDatabase(builder);

                return builder;
            }
            catch
            {
                throw;
            }
        }
    }
}
