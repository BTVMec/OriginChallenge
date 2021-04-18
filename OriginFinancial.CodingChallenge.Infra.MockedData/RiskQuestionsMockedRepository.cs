using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Infra.Mocked.Data
{
    public class RiskQuestionsMockedRepository : IRiskQuestionRepository
    {
        public Task<RiskQuestion> AddAsync(RiskQuestion entity, bool commit)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RiskQuestion> List(Expression<Func<RiskQuestion, bool>> predicate)
        {
            IQueryable<RiskQuestion> riskQuestions = new List<RiskQuestion>()
            {
                new RiskQuestion
                {
                    Answer=false,
                    Created = DateTime.Now,
                    ID = 1,
                    Modified=null,
                    Question = "First question",
                    StatusID = 1
                },
                new RiskQuestion
                {
                    Answer=false,
                    Created = DateTime.Now,
                    ID = 2,
                    Modified=null,
                    Question = "Second question",
                    StatusID = 1
                },
                new RiskQuestion
                {
                    Answer=false,
                    Created = DateTime.Now,
                    ID = 3,
                    Modified=null,
                    Question = "Third question",
                    StatusID = 1
                }
            }.AsQueryable();

            return riskQuestions.Where(predicate);
        }
    }
}
