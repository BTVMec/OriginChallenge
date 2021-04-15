using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;

namespace OriginFinancial.CodingChallenge.AppService.Interface
{
    public interface ICustomerAppService
    {
        /// <summary>
        /// The method that converts the properties values from the view model to the data model.
        /// </summary>
        /// <param name="customer">The object as view model.</param>
        /// <returns>A <see cref="Customer"/> object created from the view model.</returns>
        Customer ViewToData(CustomerViewModel customer);
    }
}
