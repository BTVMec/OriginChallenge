using OriginFinancial.CodingChallenge.Domain.Entity;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using System.Collections.Generic;

namespace OriginFinancial.CodingChallenge.Domain.Interface.Repository
{
    public interface IContractRepository : IBaseRepository<Contract>
    {
        /// <summary>
        /// The method that lists the existing contracts in the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="Contract"/> objects for the registered contracts.</returns>
        List<Contract> List();
    }
}
