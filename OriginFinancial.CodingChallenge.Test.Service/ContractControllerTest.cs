using Microsoft.AspNetCore.Mvc;
using OriginFinancial.CodingChallenge.Service.Areas.General.Controllers;
using OriginFinancial.CodingChallenge.Service.Areas.General.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OriginFinancial.CodingChallenge.Test.Service
{
    public class ContractControllerTest
    {
        private readonly IServiceProvider serviceProvider;

        public ContractDataRequest validContractDataRequest = new ContractDataRequest
        {
            FullName = "Bruno de Mello Tavares Lima",
            Email = "bmtl.enm@gmail.com",
            Age = 31,
            Dependents = 1,
            Income = 120000,
            MaritalStatusID = 2,
            Vehicle = new Vehicle { VehicleYear = 2008 },
            RiskQuestions = new List<RiskQuestion>
                {
                    new RiskQuestion{Answer= true},
                    new RiskQuestion{Answer= true},
                    new RiskQuestion{Answer= true},
                }
        };

        public ContractControllerTest()
        {
            serviceProvider = TestMainConfiguration.GetServiceProviderInstance();
        }

        [Fact]
        public void CreateAsync_ContractShouldBeCreated()
        {
            Type type = typeof(CreatedResult);

            Assert.IsType(type, new ContractController(serviceProvider).CreateAsync(validContractDataRequest).GetAwaiter().GetResult());
        }

        [Fact]
        public void CreateAsync_Load()
        {
            DateTime startDate = DateTime.Now;
            bool flag = false;
            long count = 0;
            Type type = typeof(CreatedResult);

            while (!flag)
            {
                flag = type.Equals(new ContractController(serviceProvider).CreateAsync(validContractDataRequest).GetAwaiter().GetResult()) || count > 50000;
                count++;
            }

            DateTime endDate = DateTime.Now;

            Assert.True(count > 50000 && (endDate - startDate).TotalSeconds < 30);
        }

        [Fact]
        public void CreateAsync_ContractShouldFail_QuestionsQuantity()
        {
            Type type = typeof(BadRequestObjectResult);

            validContractDataRequest.RiskQuestions.RemoveAt(2);

            Assert.IsType(type, new ContractController(serviceProvider).CreateAsync(validContractDataRequest).GetAwaiter().GetResult());
        }
    }
}

