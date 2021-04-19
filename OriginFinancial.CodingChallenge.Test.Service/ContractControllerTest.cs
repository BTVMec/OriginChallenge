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

        /// <summary>
        /// The method that tests the creation of a new contract. As it receives a valid contract, the contract should be successfully created.
        /// </summary>
        [Fact]
        public void CreateAsync_ContractShouldBeCreated()
        {
            //Arrange.
            Type type = typeof(CreatedResult);

            //Asset an act.
            Assert.IsType(type, new ContractController(serviceProvider).CreateAsync(validContractDataRequest).GetAwaiter().GetResult());
        }

        /// <summary>
        /// The method that tests the consistency of the method during several requests.
        /// </summary>
        [Fact]
        public void CreateAsync_Load()
        {
            //Arranging.
            DateTime startDate = DateTime.Now;
            bool flag = false;
            long count = 0;
            Type type = typeof(CreatedResult);

            //Acting.
            while (!flag)
            {
                flag = type.Equals(new ContractController(serviceProvider).CreateAsync(validContractDataRequest).GetAwaiter().GetResult()) || count > 50000;
                count++;
            }

            //Final arranging.
            DateTime endDate = DateTime.Now;

            //Assert.
            Assert.True(count > 50000 && (endDate - startDate).TotalSeconds < 30);
        }

        /// <summary>
        /// The method that tests the only parameters that is out of the data annotations validations scope: questions quantity.
        /// </summary>
        [Fact]
        public void CreateAsync_ContractShouldFail_QuestionsQuantity()
        {
            //Arrange.
            Type type = typeof(BadRequestObjectResult);

            //Acting.
            validContractDataRequest.RiskQuestions.RemoveAt(2);

            //Asset an act.
            Assert.IsType(type, new ContractController(serviceProvider).CreateAsync(validContractDataRequest).GetAwaiter().GetResult());
        }
    }
}

