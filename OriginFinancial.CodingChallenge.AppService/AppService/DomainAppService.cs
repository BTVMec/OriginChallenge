using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriginFinancial.CodingChallenge.AppService.AppService
{
    public class DomainAppService : IDomainAppService
    {
        /// <summary>
        /// The method that retrieves the static values for properties across the system's entities.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="DomainViewModel"/> containing the values for static properties in the system.</returns>
        public List<DomainViewModel> List()
        {
            //Instantiating the list for the domain values.
            List<DomainViewModel> domainsViewModel = new List<DomainViewModel>();

            //Retrieving the properties from entities - Customer - House ownership status.
            var ownershipStatuses = Enum.GetValues(typeof(CustomerViewModel.HouseOwnershipStatus));
            DomainViewModel houseDomainViewModel = new DomainViewModel
            {
                Property = "House Ownership Status",
                Definitions = new List<DomainKeyValuesPair>()
            };
            for (int i = 1; i <= ownershipStatuses.Length; i++)
            {
                DomainKeyValuesPair keyValuePair = new DomainKeyValuesPair
                {
                    Key = i,
                    Value = ownershipStatuses.GetValue(i - 1).ToString()
                };
                houseDomainViewModel.Definitions.Add(keyValuePair);
            }
            domainsViewModel.Add(houseDomainViewModel);

            //Retrieving the properties from entities - Customer - Marital status.
            var maritalStatuses = Enum.GetValues(typeof(CustomerViewModel.MaritalStatus));
            DomainViewModel maritalDomainViewModel = new DomainViewModel
            {
                Property = "Marital Status",
                Definitions = new List<DomainKeyValuesPair>()
            };
            for (int i = 1; i <= maritalStatuses.Length; i++)
            {
                DomainKeyValuesPair domainKeyValuesPair = new DomainKeyValuesPair
                {
                    Key = i,
                    Value = maritalStatuses.GetValue(i - 1).ToString()
                };
                maritalDomainViewModel.Definitions.Add(domainKeyValuesPair);
            }
            domainsViewModel.Add(maritalDomainViewModel);

            //Retrieving the properties from entities - Risk questions - Status.
            var riskQuestionStatuses = Enum.GetValues(typeof(RiskQuestionViewModel.Status));
            DomainViewModel riskDomainViewModel = new DomainViewModel
            {
                Property = "Risk Question Status",
                Definitions = new List<DomainKeyValuesPair>()
            };
            for (int i = 1; i <= riskQuestionStatuses.Length; i++)
            {
                DomainKeyValuesPair domainKeyValuesPair = new DomainKeyValuesPair
                {
                    Key = i,
                    Value = riskQuestionStatuses.GetValue(i - 1).ToString()
                };
                riskDomainViewModel.Definitions.Add(domainKeyValuesPair);
            }
            domainsViewModel.Add(riskDomainViewModel);

            //Retrieving the properties from entities - Insurance Policies.
            var insurancePoliciesValues = Enum.GetValues(typeof(ContractViewModel.Insurance));
            DomainViewModel insuranceDomainViewModel = new DomainViewModel
            {
                Property = "Insurance Policies",
                Definitions = new List<DomainKeyValuesPair>()
            };
            for (int i = 1; i <= insurancePoliciesValues.Length; i++)
            {
                DomainKeyValuesPair domainKeyValuesPair = new DomainKeyValuesPair
                {
                    Key = i,
                    Value = insurancePoliciesValues.GetValue(i - 1).ToString()
                };
                insuranceDomainViewModel.Definitions.Add(domainKeyValuesPair);
            }
            domainsViewModel.Add(insuranceDomainViewModel);

            return domainsViewModel;
        }
    }
}
