using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;
using System.Collections.Generic;

namespace OriginFinancial.CodingChallenge.AppService.Interface
{
    public interface IRiskQuestionAppService
    {
        /// <summary>
        /// The method that converts the properties values from the view model list to the data model list.
        /// </summary>
        /// <param name="riskQuestions">The object as view model list.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestion"/> objects created from the view model.</returns>
        List<RiskQuestion> ListViewToListData(List<RiskQuestionViewModel> riskQuestions);
    }
}
