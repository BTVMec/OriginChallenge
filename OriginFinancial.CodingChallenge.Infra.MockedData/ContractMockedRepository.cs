using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Infra.Mocked.Data
{
    public class ContractMockedRepository : IContractRepository
    {
        public Task<Contract> AddAsync(Contract contract, bool commit)
        {
            if (contract != null)
            {
                List<RiskQuestion> riskQuestions = new List<RiskQuestion>(){
                new RiskQuestion
                {
                    Answer=false,
                    Created = DateTime.Now,
                    ID = 1,
                    Modified=null,
                    Question = "First question",
                    StatusID = 1
                },
                new RiskQuestion
                {
                    Answer=false,
                    Created = DateTime.Now,
                    ID = 2,
                    Modified=null,
                    Question = "Second question",
                    StatusID = 1
                },
                new RiskQuestion
                {
                    Answer=false,
                    Created = DateTime.Now,
                    ID = 3,
                    Modified=null,
                    Question = "Third question",
                    StatusID = 1
                }
            };

                for (int i = 0; i < contract.CustomerRiskQuestions.Count(); i++)
                {
                    contract.CustomerRiskQuestions[i].RiskQuestion = riskQuestions[i];
                }

                return Task.FromResult(contract);
            }
            else
                return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> List(Expression<Func<Contract, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
