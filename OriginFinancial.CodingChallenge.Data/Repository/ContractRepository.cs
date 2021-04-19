using Microsoft.EntityFrameworkCore;
using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using OriginFinancial.CodingChallenge.Domain.Interface.Repository;
using OriginFinancial.CodingChallenge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OriginFinancial.CodingChallenge.Infra.Data.Repository
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository(IMainDatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = (MainDatabaseContext)dbContext;
        }

        /// <summary>
        /// The method that lists the existing contracts in the database.
        /// </summary>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// <description>A <see cref="SuccessResponse"/> if the process is successful;</description>
        /// </item>
        /// <item>
        /// <description>A <see cref="ErrorResponse"/> if the process fails.</description>
        /// </item>
        /// </list>
        /// </returns>
        public Contract Get(string contractSerialNumber)
        {
            try
            {
                return _dbContext.Contract
                    ?.Include(x => x.CustomerRiskQuestions)
                       ?.ThenInclude(y => y.Customer)
                    ?.Include(x => x.CustomerRiskQuestions)
                        ?.ThenInclude(y => y.RiskQuestion)
                    ?.FirstOrDefault(x=>x.ID.ToString().Equals(contractSerialNumber));
            }
            catch (Exception ex)
            {
                string trace = !string.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace.Split("at").LastOrDefault().Split("\\").LastOrDefault() : "";
                ex.HelpLink += $"DATABASE ERROR - {ex?.InnerException?.Message}|{trace}";
                throw;
            }
        }

        /// <summary>
        /// The method that lists the existing contracts in the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Contract"/> objects for the registered contracts.</returns>
        public List<Contract> List()
        {
            try
            {
                return _dbContext.Contract
                    ?.Include(x => x.CustomerRiskQuestions)
                       ?.ThenInclude(y => y.Customer)
                    ?.Include(x => x.CustomerRiskQuestions)
                        ?.ThenInclude(y => y.RiskQuestion)
                    ?.ToList();
            }
            catch (Exception ex)
            {
                string trace = !string.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace.Split("at").LastOrDefault().Split("\\").LastOrDefault() : "";
                ex.HelpLink += $"DATABASE ERROR - {ex?.InnerException?.Message}|{trace}";
                throw;
            }
        }
    }
}
