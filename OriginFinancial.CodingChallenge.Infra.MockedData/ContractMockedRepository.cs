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

                //Accounting for possible delay while adding object to the database.
                Task.Delay(500);

                return Task.FromResult(contract);
            }
            else
                return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Contract Get(string contractSerialNumber)
        {
            Customer customer = new Customer
            {
                ID = 1,
                FullName = "Bruno de Mello Tavares Lima",
                Age = 31,
                Dependents = 1,
                House = 0,
                HouseOwnershipStatusID = null,
                Income = 120000,
                MaritalStatusID = 2,
                Vehicle = 1,
                VehicleYear = 2008,
                Created = DateTime.Now
            };
            RiskQuestion riskQuestion = new RiskQuestion
            {
                ID = 1,
                Answer = true,
                Question = "Testing question",
                StatusID = 1,
                Created = DateTime.Now
            };
            Contract contract = new Contract
            {
                ID = new Guid("08d902dc-1b9a-4f37-8a46-270fdc92e61f"),
                GlobalRiskPoints = 2,
                AutoInsurancePoints = 2,
                AutoInsuranceID = 3,
                DisabilityInsurancePoints = 3,
                DisabilityInsuranceID = 4,
                HomeInsurancePoints = 2,
                HomeInsuranceID = 1,
                LifeInsurancePoints = 3,
                LifeInsuranceID = 4,
                CustomerRiskQuestions = new List<CustomerRiskQuestion>
                {
                    new CustomerRiskQuestion
                    {
                        Customer = customer,
                        RiskQuestion = riskQuestion
                    },
                    new CustomerRiskQuestion
                    {
                        Customer = customer,
                        RiskQuestion = riskQuestion
                    },
                    new CustomerRiskQuestion
                    {
                        Customer = customer,
                        RiskQuestion = riskQuestion
                    }
                }
            };

            if (contract.ID.ToString().Equals(contractSerialNumber))
                return contract;
            else
                return null;
        }

        public List<Contract> List()
        {
            Customer customer = new Customer
            {
                ID = 1,
                FullName = "Bruno de Mello Tavares Lima",
                Age = 31,
                Dependents = 1,
                House = 0,
                HouseOwnershipStatusID = null,
                Income = 120000,
                MaritalStatusID = 2,
                Vehicle = 1,
                VehicleYear = 2008,
                Created = DateTime.Now
            };
            RiskQuestion riskQuestion = new RiskQuestion
            {
                ID = 1,
                Answer = true,
                Question = "Testing question",
                StatusID = 1,
                Created = DateTime.Now
            };
            Contract contract = new Contract
            {
                ID = new Guid("08d902dc-1b9a-4f37-8a46-270fdc92e61f"),
                GlobalRiskPoints = 2,
                AutoInsurancePoints = 2,
                AutoInsuranceID = 3,
                DisabilityInsurancePoints = 3,
                DisabilityInsuranceID = 4,
                HomeInsurancePoints = 2,
                HomeInsuranceID = 1,
                LifeInsurancePoints = 3,
                LifeInsuranceID = 4,
                CustomerRiskQuestions = new List<CustomerRiskQuestion>
                {
                    new CustomerRiskQuestion
                    {
                        Customer = customer,
                        RiskQuestion = riskQuestion
                    },
                    new CustomerRiskQuestion
                    {
                        Customer = customer,
                        RiskQuestion = riskQuestion
                    },
                    new CustomerRiskQuestion
                    {
                        Customer = customer,
                        RiskQuestion = riskQuestion
                    }
                }
            };

            List<Contract> contracts = new List<Contract>
            {
                contract,
                contract,
                contract
            };

            //Accounting for possible delay while adding object to the database.
            Task.Delay(500);

            return contracts;
        }

        public IEnumerable<Contract> List(Expression<Func<Contract, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
