using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.AppService.AppService
{
    public class ContractAppService : IContractAppService
    {
        private readonly IContractService _contractService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IRiskQuestionAppService _riskQuestionAppService;

        public ContractAppService(IServiceProvider services)
        {
            _contractService = services.GetRequiredService<IContractService>();
            _customerAppService = services.GetRequiredService<ICustomerAppService>();
            _riskQuestionAppService = services.GetRequiredService<IRiskQuestionAppService>();
        }

        /// <summary>
        /// The asynchronous method for registering a new customer's contract.
        /// </summary>
        /// <param name="customerViewModel">The customer data for the new contract.</param>
        /// <param name="riskQuestionsViewModel">The customer's risk question's asnwers.</param>
        /// <returns>A <see cref="ContractViewModel"/> object for the registered new contract.</returns>
        public async Task<ContractViewModel> CreateAsync(CustomerViewModel customerViewModel, List<RiskQuestionViewModel> riskQuestionsViewModel)
        {
            try
            {
                //Transforming the customer's view model to data model.
                Customer customer = _customerAppService.ViewToData(customerViewModel);

                //Transforming the risk question's view model to data model.
                List<RiskQuestion> riskQuestions = _riskQuestionAppService.ListViewToListData(riskQuestionsViewModel);

                //Registering the new contract.
                Contract contract = await _contractService.CreateAsync(customer, riskQuestions);

                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}