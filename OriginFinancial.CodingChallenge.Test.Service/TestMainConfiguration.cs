using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.Infra.Mocked.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriginFinancial.CodingChallenge.Test.Service
{
    public static class TestMainConfiguration
    {
        public static IServiceProvider GetServiceProviderInstance()
        {
            IServiceCollection services = new ServiceCollection();

            NativeInjectorMocked.RegisterServices(services);

            return services.BuildServiceProvider();
        }
    }
}
