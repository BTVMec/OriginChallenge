using Microsoft.Extensions.DependencyInjection;
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
        private readonly IRiskQuestionService _riskQuestionService;

        public ContractService(IServiceProvider services)
        {
            _riskQuestionService = services.GetRequiredService<IRiskQuestionService>();
        }

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

            //Checking the received risk questions' answers - retrieving the registered active questions for comparison.
            List<RiskQuestion> riskQuestionsDB = _riskQuestionService.List(1);

            //Checking if there's as many received answers as there are active questions.
            if (riskQuestions.Count().Equals(riskQuestionsDB.Count()))
            {
                //Setting the ID of the questions.
                for (int i = 0; i < riskQuestionsDB.Count(); i++)
                    riskQuestions[i].ID = riskQuestionsDB[i].ID;

                //Creating the list of customer-risk questions object.
                List<CustomerRiskQuestion> customerRiskQuestions = riskQuestions.Select(x => new CustomerRiskQuestion
                {
                    ID = x.ID,
                    RiskQuestionAnswer = x.Answer,
                    RiskQuestionID = x.ID,
                    Customer = customer,
                    Contract = contract,
                    Created = DateTime.Now
                }).OrderBy(x => x.ID).ToList();

                //Setting the contract's total risk points.
                SetContractRiskPoints(customer, customerRiskQuestions, ref contract);

                //Setting the auto insurance.
                SetAutoInsurance(customer, ref contract);

                //Setting the disability insurance.
                SetDesabilityInsurance(customer, ref contract);

                //Setting the home insurance.
                SetHomeInsurance(customer, ref contract);

                //Setting the life insurance.
                SetLifeInsurance(customer, ref contract);
            }
            else
                throw new Exception("The submitted answers do not correspond to the active questions registered in database.");

            return null;
        }

        /// <summary>
        /// The method for setting the risk points by global parameters.
        /// </summary>
        /// <param name="customer">The customer under evaluation.</param>
        /// <param name="riskQuestions">The customer's risk questions' answers.</param>
        /// <param name="contract">The contract under construction.</param>
        private void SetContractRiskPoints(Customer customer, List<CustomerRiskQuestion> riskQuestions, ref Contract contract)
        {
            //Setting the risk points for the risk questions.
            contract.GlobalRiskPoints = riskQuestions.Where(x => x.RiskQuestionAnswer).Count();

            //Adjusting the risk points for the customer's age.
            if (customer.Age < 30)
                contract.GlobalRiskPoints -= 2;
            else if (customer.Age > 30 && customer.Age < 40)
                contract.GlobalRiskPoints -= 1;

            //Adjusting the risk points for the customer's income.
            if (customer.Income > 200000)
                contract.GlobalRiskPoints -= 1;

            //Setting the specific risk points.
            contract.AutoInsurancePoints = contract.DisabilityInsurancePoints = contract.HomeInsurancePoints = contract.LifeInsurancePoints = contract.GlobalRiskPoints;
        }

        /// <summary>
        /// The method for determining and setting the auto insurance policy for a customer's contract.
        /// </summary>
        /// <param name="customer">The customer under evaluation.</param>
        /// <param name="contract">The contract under construction.</param>
        private void SetAutoInsurance(Customer customer, ref Contract contract)
        {
            //If the customer doesn't own a car.
            if (customer.Vehicle.Equals(0))
                contract.AutoInsuranceID = 1;
            //If the customer owns a car, evaluate the complementary information.
            else
            {
                //Checking the customer's vehicle "age".
                if (DateTime.Today.Year - customer.VehicleYear.Value <= 5)
                    contract.AutoInsurancePoints += 1;

                //Setting the final score for this insurance line.
                contract.AutoInsuranceID = SetInsurance(contract.AutoInsurancePoints);
            }
        }

        /// <summary>
        /// The method for determining and setting the disability insurance policy for a customer's contract.
        /// </summary>
        /// <param name="customer">The customer under evaluation.</param>
        /// <param name="contract">The contract under construction.</param>
        private void SetDesabilityInsurance(Customer customer, ref Contract contract)
        {
            //If the customer doesn't have income or is older than 60 years old.
            if (customer.Income.Equals(0) || customer.Age > 60)
                contract.DisabilityInsuranceID = 1;
            //If the customer has income and is younger than 60, evaluate de the complementary information.
            else
            {
                //Checking for the customer's house information.
                if (customer.House.Equals(1) && customer.HouseOwnershipStatusID.Value.Equals(2))
                    contract.DisabilityInsurancePoints += 1;

                //Checking for the customer's dependents information.
                if (customer.Dependents > 0)
                    contract.DisabilityInsurancePoints += 1;

                //Checking for the user's marital status.
                if (customer.MaritalStatusID.Equals(1))
                    contract.DisabilityInsurancePoints -= 1;

                //Setting the final score for this insurance line.
                contract.DisabilityInsuranceID = SetInsurance(contract.DisabilityInsurancePoints);
            }
        }

        /// <summary>
        /// The method for determining and setting the home insurance policy for a customer's contract.
        /// </summary>
        /// <param name="customer">The customer under evaluation.</param>
        /// <param name="contract">The contract under construction.</param>
        private void SetHomeInsurance(Customer customer, ref Contract contract)
        {
            //If the customer doesn't own a house.
            if (customer.House.Equals(0))
                contract.HomeInsuranceID = 1;
            //If the customer owns a house, evaluate the complementary information.
            else
            {
                //Checking for the customer's house information.
                if (customer.HouseOwnershipStatusID.Value.Equals(2))
                    contract.HomeInsurancePoints += 1;

                //Setting the final score for this insurance line.
                contract.HomeInsuranceID = SetInsurance(contract.HomeInsurancePoints);
            }
        }

        /// <summary>
        /// The method for determining and setting the life insurance policy for a customer's contract.
        /// </summary>
        /// <param name="customer">The customer under evaluation.</param>
        /// <param name="contract">The contract under construction.</param>
        private void SetLifeInsurance(Customer customer, ref Contract contract)
        {
            //If the customer is older than 60 years old.
            if (customer.Age > 60)
                contract.LifeInsuranceID = 1;
            //If the customer is under 60 years old, evaluate the complementary information.
            else
            {
                //Checking for dependents.
                if (customer.Dependents > 0)
                    contract.LifeInsurancePoints += 1;

                //Checking if the customer's marital status.
                if (customer.MaritalStatusID.Equals(1))
                    contract.LifeInsurancePoints += 1;

                //Setting the final score for this insurance line.
                contract.LifeInsuranceID = SetInsurance(contract.LifeInsurancePoints);
            }
        }

        /// <summary>
        /// The method that sets the final value for any of the insurances' lines.
        /// </summary>
        /// <param name="specificRiskPoints">The specific risk points for each line of insurance.</param>
        /// <returns>An <see cref="int"/> for the result of the insurance score.</returns>
        private int SetInsurance(int specificRiskPoints)
        {
            //Checking the risk points and setting the final insurance result.
            if (specificRiskPoints <= 0)
                return 2;
            else if (specificRiskPoints.Equals(1) || specificRiskPoints.Equals(2))
                return 3;
            else
                return 4;
        }
    }
}
