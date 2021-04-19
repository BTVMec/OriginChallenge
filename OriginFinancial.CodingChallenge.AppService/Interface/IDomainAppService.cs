using OriginFinancial.CodingChallenge.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriginFinancial.CodingChallenge.AppService.Interface
{
    public interface IDomainAppService
    {
        /// <summary>
        /// The method that retrieves the static values for properties across the system's entities.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="DomainViewModel"/> containing the values for static properties in the system.</returns>
        List<DomainViewModel> List();
    }
}
