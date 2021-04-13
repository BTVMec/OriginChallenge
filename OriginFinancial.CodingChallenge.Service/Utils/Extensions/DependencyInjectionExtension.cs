using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.Infra.IoC;

namespace OriginFinancial.CodingChallenge.Service.Utils.Extensions
{
    /// <summary>
    /// Extension class for calling the dependency injection methods out of the IoC layer.
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// The static method that calls for the configurations of the dependency injections.
        /// </summary>
        /// <param name="services">Interface for specifying contracts for multiple layers of services;</param>
        /// <param name="configuration">Interface for the configuration builder contract specification.</param>
        public static void AddDIConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            //Registering dependency injection for contexts.
            NativeInjector.RegisterContexts(services, configuration);
            //Registering dependency injection for multiple classes of services.
            NativeInjector.RegisterServices(services);
        }
    }
}
