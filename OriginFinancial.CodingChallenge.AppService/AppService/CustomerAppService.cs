using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OriginFinancial.CodingChallenge.AppService.AppService
{
    public class CustomerAppService : ICustomerAppService
    {
        /// <summary>
        /// The method that converts the properties values from the view model to the data model.
        /// </summary>
        /// <param name="customer">The object as view model.</param>
        /// <returns>A <see cref="Customer"/> object created from the view model.</returns>
        public Customer ViewToData(CustomerViewModel customer)
        {
            try
            {
                return new Customer
                {
                    Age = customer.Age,
                    Dependents = customer.Dependents,
                    Email = customer.Email,
                    FullName = customer.FullName,
                    House = customer.House,
                    HouseOwnershipStatusID = customer.HouseOwnershipStatusID,
                    MaritalStatusID = customer.MaritalStatusID,
                    Income = customer.Income,
                    Vehicle = customer.Vehicle,
                    VehicleYear = customer.VehicleYear
                };
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The method that converts the properties values from the data model to the view model.
        /// </summary>
        /// <param name="customer">The object as data model.</param>
        /// <returns>A <see cref="CustomerViewModel"/> object created from the data model.</returns>
        public CustomerViewModel DataToView(Customer customer)
        {
            try
            {
                return new CustomerViewModel
                {
                    ID = customer.ID,
                    Age = customer.Age,
                    Dependents = customer.Dependents,
                    Email = customer.Email,
                    House = customer.House,
                    HouseOwnershipStatusID = customer.HouseOwnershipStatusID,
                    FullName = customer.FullName,
                    Income = customer.Income,
                    MaritalStatusID = customer.MaritalStatusID,
                    Vehicle = customer.Vehicle,
                    VehicleYear = customer.VehicleYear,
                    Created = customer.Created,
                    Modified = customer.Modified
                };
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The method that converts the properties values from the list as data model to the list as view model.
        /// </summary>
        /// <param name="customerRiskQuestions">The object as data model list.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="CustomerRiskQuestionViewModel"/> objects created from the data model.</returns>
        public List<CustomerRiskQuestionViewModel> ListDataToListView(List<CustomerRiskQuestion> customerRiskQuestions)
        {
            try
            {
                return customerRiskQuestions.Select(x => new CustomerRiskQuestionViewModel
                {
                    ID = x.ID,
                    Question = x.RiskQuestion.Question,
                    Answer = x.RiskQuestionAnswer,
                    Created = x.Created,
                    Modified = x.Modified
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
