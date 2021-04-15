using OriginFinancial.CodingChallenge.Domain.Entity;
using System.Collections.Generic;

namespace OriginFinancial.CodingChallenge.Domain.Interface.Service
{
    public interface IRiskQuestionService
    {
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
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestion"/> objects for the registered questions.</returns>
        List<RiskQuestion> List(int status);
    }
}
