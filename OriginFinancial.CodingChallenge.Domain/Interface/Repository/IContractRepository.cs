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
        Contract Get(string contractSerialNumber);
    }
}
