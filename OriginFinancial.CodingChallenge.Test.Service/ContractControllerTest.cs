using Microsoft.AspNetCore.Mvc;
using OriginFinancial.CodingChallenge.Service.Areas.Customer.Controllers;
using OriginFinancial.CodingChallenge.Service.Areas.Customer.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OriginFinancial.CodingChallenge.Test.Service
{
    public class ContractControllerTest
    {
        private readonly IServiceProvider serviceProvider;

        public ContractControllerTest()
        {
            serviceProvider = TestMainConfiguration.GetServiceProviderInstance();
        }

        [Fact]
        public void CreateAsync_ContractShouldBeCreatedAsync()
        {
            ContractDataRequest contractDataRequest = new ContractDataRequest
            {
                FullName = "Bruno de Mello Tavares Lima",
                Email = "bmtl.enm@gmail.com",
                Age = 31,
                Dependents=1,
                Income = 120000,
                MaritalStatusID = 2,
                Vehicle =new Vehicle { VehicleYear = 2008},
                RiskQuestions = new List<RiskQuestion>
                {
                    new RiskQuestion{Answer= true},
                    new RiskQuestion{Answer= true},
                    new RiskQuestion{Answer= true},
                }
            };

            Type type = typeof(CreatedResult);

            Assert.IsType(type, new ContractController(serviceProvider).CreateAsync(contractDataRequest).GetAwaiter().GetResult());
        }
    }
}
