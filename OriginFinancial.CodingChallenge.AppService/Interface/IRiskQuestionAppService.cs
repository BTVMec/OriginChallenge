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
        /// <summary>
        /// The method that converts the properties values from the data model list to the the model list.
        /// </summary>
        /// <param name="riskQuestions">The object as data model list.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestionViewModel"/> objects created from the data model.</returns>
        List<RiskQuestionViewModel> ListDataToListView(List<RiskQuestion> riskQuestions);
        /// <summary>
        /// The method that lists questions that are registered in the database.
        /// </summary>
        /// <param name="status">The parameter for filtering the questions to be listed:
        /// <list type="bullet">
        /// <item>
        /// <description><see langword="0"/> lists all of the questions;</description>
        /// </item>
        /// <item>
        /// <description><see langword="1"/> lists only the active questions;</description>
        /// </item>
        /// <item>
        /// <description><see langword="2"/> lists only the inactive questions.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestionViewModel"/> objects for the registered questions.</returns>
        List<RiskQuestionViewModel> List(int status);
    }
}
