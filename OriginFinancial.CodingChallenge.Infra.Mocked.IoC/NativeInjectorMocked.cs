using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.AppService;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using OriginFinancial.CodingChallenge.Domain.Service;
using OriginFinancial.CodingChallenge.Infra.Mocked.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriginFinancial.CodingChallenge.Infra.Mocked.IoC
{
    public class NativeInjectorMocked
    {
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
            ContractMockedRepository contractMockedRepository = new ContractMockedRepository();
            services.AddSingleton<IContractRepository>(contractMockedRepository);
            RiskQuestionsMockedRepository riskQuestionsMockedRepository = new RiskQuestionsMockedRepository();
            services.AddSingleton<IRiskQuestionRepository>(riskQuestionsMockedRepository);
        }
    }
}
