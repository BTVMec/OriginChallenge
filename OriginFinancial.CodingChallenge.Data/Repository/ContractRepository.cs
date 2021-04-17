using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using OriginFinancial.CodingChallenge.Infra.Data.Context;

namespace OriginFinancial.CodingChallenge.Infra.Data.Repository
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(IMainDatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = (MainDatabaseContext)dbContext;
        }
    }
}
