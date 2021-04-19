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
        /// <summary>
        /// The method that lists the existing contracts in the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="ContractViewModel"/> objects for the registered contracts.</returns>
        List<ContractViewModel> List();
        /// <summary>
        /// The method that retrieves the existing contract in the database by its seria number.
        /// </summary>
        /// <param name="contractSerialNumber">The contract serial number.</param>
        /// <returns>A <see cref="ContractViewModel"/> object for the registered contract.</returns>
        ContractViewModel Get(string contractSerialNumber);
    }
}
