using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OriginFinancial.CodingChallenge.AppService.AppService
{
    public class RiskQuestionAppService : IRiskQuestionAppService
    {
        private readonly IRiskQuestionService _riskQuestionService;

        public RiskQuestionAppService(IServiceProvider services)
        {
            _riskQuestionService = services.GetRequiredService<IRiskQuestionService>();
        }

        /// <summary>
        /// The method that converts the properties values from the view model list to the data model list.
        /// </summary>
        /// <param name="riskQuestions">The object as view model list.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestion"/> objects created from the view model.</returns>
        public List<RiskQuestion> ListViewToListData(List<RiskQuestionViewModel> riskQuestions)
        {
            try
            {
                return riskQuestions.Select(x => new RiskQuestion
                {
                    Question = x.Question,
                    Answer = x.Answer
                }).ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The method that converts the properties values from the data model list to the the model list.
        /// </summary>
        /// <param name="riskQuestions">The object as data model list.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestionViewModel"/> objects created from the data model.</returns>
        public List<RiskQuestionViewModel> ListDataToListView(List<RiskQuestion> riskQuestions)
        {
            try
            {
                return riskQuestions.Select(x => new RiskQuestionViewModel
                {
                    ID = x.ID,
                    Question = x.Question,
                    Created = x.Created,
                    Modified = x.Modified,
                    StatusID = x.StatusID
                }).ToList();
            }
            catch
            {
                throw;
            }
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
        /// <returns>A <see cref="List{T}"/> of <see cref="RiskQuestionViewModel"/> objects for the registered questions.</returns>
        public List<RiskQuestionViewModel> List(int status)
        {
            try
            {
                //Retrieving the risk questions as data model.
                List<RiskQuestion> riskQuestions = _riskQuestionService.List(status);

                //Checking the results.
                if (riskQuestions?.Count() > 0)
                    //Transforming from data model to view model and returning it.
                    return ListDataToListView(riskQuestions);
                else
                    return new List<RiskQuestionViewModel>();
            }
            catch
            {
                throw;
            }
        }
    }
}
