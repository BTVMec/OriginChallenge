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

            //Retrieving the properties from entities - Customer.
            var values = Enum.GetValues(typeof(CustomerViewModel.HouseOwnershipStatus));

            return null;
        }
    }
}
