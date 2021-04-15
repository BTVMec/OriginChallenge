using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Domain.Service
{
    public class ContractService : IContractService
    {
        /// <summary>
        /// The asynchronous method for registering a new customer's contract.
        /// </summary>
        /// <param name="customer">The customer data for the new contract.</param>
        /// <param name="riskQuestions">The customer's risk question's asnwers.</param>
        /// <returns>A <see cref="Customer"/> object for the registered new contract.</returns>
        public Task<Contract> CreateAsync(Customer customer, List<RiskQuestion> riskQuestions)
        {
            //Instantiating the new contract.
            Contract contract = new Contract();

            //Setting the questions objects' IDs in the riskQuestions list.
            for (int i = 1; i <= riskQuestions.Count(); i++)
                riskQuestions[i].ID = i;

            //Creating the list of customer-risk questions object.
            List<CustomerRiskQuestion> customerRiskQuestions = riskQuestions.Select(x => new CustomerRiskQuestion
            {
                ID = x.ID,
                RiskQuestionAnswer = x.Answer,
                Customer = customer,
                RiskQuestion = x,
                Contract = contract,
                Created = DateTime.Now
            }).ToList();
        }
    }
}
