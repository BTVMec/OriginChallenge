using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// The method that converts the properties values from the data model to the view model.
        /// </summary>
        /// <param name="contract">The object as data model.</param>
        /// <returns>A <see cref="ContractViewModel"/> object created from the data model.</returns>
        public ContractViewModel DataToView(Contract contract)
        {
            try
            {
                //Retrieving the customer object.
                Customer customer = contract.CustomerRiskQuestions.FirstOrDefault().Customer;

                return new ContractViewModel
                {
                    ID = contract.ID,
                    CustomerInfo = _customerAppService.DataToView(customer),
                    RiskQuestions = _customerAppService.ListDataToListView(contract.CustomerRiskQuestions),
                    GlobalRiskPoints = contract.GlobalRiskPoints,
                    InsurancePolicies = new InsurancePolicies
                    {
                        AutoID = contract.AutoInsuranceID,
                        AutoPoints = contract.AutoInsurancePoints,
                        DisabilityID = contract.DisabilityInsuranceID,
                        DisabilityPoints = contract.DisabilityInsurancePoints,
                        HomeID = contract.HomeInsuranceID,
                        HomePoints = contract.HomeInsurancePoints,
                        LifeID = contract.LifeInsuranceID,
                        LifePoints = contract.LifeInsurancePoints,
                    },
                    Created = contract.Created,
                    Modified = contract.Modified
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
        /// <param name="contract">The list as data model.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="ContractViewModel"/> objects created from the list as data model.</returns>
        public List<ContractViewModel> ListDataToListView(List<Contract> contracts)
        {
            try
            {
                return contracts.Select(x => new ContractViewModel
                {
                    ID = x.ID,
                    CustomerInfo = _customerAppService.DataToView(x.CustomerRiskQuestions.FirstOrDefault().Customer),
                    RiskQuestions = _customerAppService.ListDataToListView(x.CustomerRiskQuestions),
                    GlobalRiskPoints = x.GlobalRiskPoints,
                    InsurancePolicies = new InsurancePolicies
                    {
                        AutoID = x.AutoInsuranceID,
                        AutoPoints = x.AutoInsurancePoints,
                        DisabilityID = x.DisabilityInsuranceID,
                        DisabilityPoints = x.DisabilityInsurancePoints,
                        HomeID = x.HomeInsuranceID,
                        HomePoints = x.HomeInsurancePoints,
                        LifeID = x.LifeInsuranceID,
                        LifePoints = x.LifeInsurancePoints,
                    },
                    Created = x.Created,
                    Modified = x.Modified
                }).ToList();
            }
            catch
            {
                throw;
            }
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

                //Transforming from data model to view model.
                ContractViewModel contractViewModel = DataToView(contract);

                return contractViewModel;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The method that lists the existing contracts in the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="ContractViewModel"/> objects for the registered contracts.</returns>
        public List<ContractViewModel> List()
        {
            try
            {
                //Retrieving the contracts from the database.
                List<Contract> contracts = _contractService.List();

                //Checking the result.
                if (contracts?.Count() > 0)
                    //Transforming the data from the database model to the view model.
                    return ListDataToListView(contracts);
                else
                    return new List<ContractViewModel>();
            }
            catch
            {
                throw;
            }
        }
    }
}