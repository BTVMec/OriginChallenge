using OriginFinancial.CodingChallenge.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Domain.Interface.Service
{
    public interface IContractService
    {
        /// <summary>
        /// The asynchronous method for registering a new customer's contract.
        /// </summary>
        /// <param name="customer">The customer data for the new contract.</param>
        /// <param name="riskQuestions">The customer's risk question's asnwers.</param>
        /// <returns>A <see cref="Customer"/> object for the registered new contract.</returns>
        Task<Contract> CreateAsync(Customer customer, List<RiskQuestion> riskQuestions);
    }
}
