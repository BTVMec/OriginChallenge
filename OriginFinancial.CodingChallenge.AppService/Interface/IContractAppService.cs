using OriginFinancial.CodingChallenge.AppService.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.AppService.Interface
{
    public interface IContractAppService
    {
        /// <summary>
        /// The asynchronous method for registering a new customer's contract.
        /// </summary>
        /// <param name="customer">The customer data for the new contract.</param>
        /// <param name="lstRiskQuestions">The customer's risk question's asnwers.</param>
        /// <returns>A <see cref="ContractViewModel"/> object for the registered new contract.</returns>
        Task<ContractViewModel> CreateAsync(CustomerViewModel customer, List<RiskQuestionViewModel> lstRiskQuestions);
    }
}
