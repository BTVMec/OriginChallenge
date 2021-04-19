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
        /// <summary>
        /// The method that lists the existing contracts in the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Contract"/> objects for the registered contracts.</returns>
        List<Contract> List();
        /// <summary>
        /// The method that retrieves the existing contract in the database by its seria number.
        /// </summary>
        /// <param name="contractSerialNumber">The contract serial number.</param>
        /// <returns>A <see cref="Contract"/> object for the registered contract.</returns>
        Contract Get(string contractSerialNumber);
    }
}
