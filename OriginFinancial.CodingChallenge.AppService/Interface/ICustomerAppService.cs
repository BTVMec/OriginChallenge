using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;
using System.Collections.Generic;

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
        /// <summary>
        /// The method that converts the properties values from the data model to the view model.
        /// </summary>
        /// <param name="customer">The object as data model.</param>
        /// <returns>A <see cref="CustomerViewModel"/> object created from the data model.</returns>
        CustomerViewModel DataToView(Customer customer);
        /// <summary>
        /// The method that converts the properties values from the list as data model to the list as view model.
        /// </summary>
        /// <param name="customerRiskQuestions">The object as data model list.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="CustomerRiskQuestionViewModel"/> objects created from the data model.</returns>
        List<CustomerRiskQuestionViewModel> ListDataToListView(List<CustomerRiskQuestion> customerRiskQuestions);
    }
}
