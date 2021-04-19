using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OriginFinancial.CodingChallenge.Domain.Service
{
    public class RiskQuestionService : IRiskQuestionService
    {
        private readonly IRiskQuestionRepository _riskQuestionRepository;

        public RiskQuestionService(IServiceProvider services)
        {
            _riskQuestionRepository = services.GetRequiredService<IRiskQuestionRepository>();
        }

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
        public List<RiskQuestion> List(int status)
        {
            return _riskQuestionRepository.List(x => x.StatusID == status)?.OrderBy(x => x.ID).ToList();
        }
    }
}
