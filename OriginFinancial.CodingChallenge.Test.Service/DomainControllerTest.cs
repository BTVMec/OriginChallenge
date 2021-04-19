using Microsoft.AspNetCore.Mvc;
using OriginFinancial.CodingChallenge.Service.Areas.General.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OriginFinancial.CodingChallenge.Test.Service
{
    public class DomainControllerTest
    {
        private readonly IServiceProvider serviceProvider;

        public DomainControllerTest()
        {
            serviceProvider = TestMainConfiguration.GetServiceProviderInstance();
        }

        [Fact]
        public void List_Load()
        {
            DateTime startDate = DateTime.Now;
            bool flag = false;
            long count = 0;
            Type type = typeof(OkResult);

            while (!flag)
            {
                flag = type.Equals(new DomainController(serviceProvider).List()) || count > 50000;
                count++;
            }

            DateTime endDate = DateTime.Now;

            Assert.True(count > 50000 && (endDate - startDate).TotalSeconds < 5);
        }
    }
}
