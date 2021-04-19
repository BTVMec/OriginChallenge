using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using OriginFinancial.CodingChallenge.Infra.Data.Context;

namespace OriginFinancial.CodingChallenge.Infra.Data.Repository
{
    public class RiskQuestionRepository : BaseRepository<RiskQuestion>, IRiskQuestionRepository
    {
        public RiskQuestionRepository(IMainDatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = (MainDatabaseContext)dbContext;
        }
    }
}
