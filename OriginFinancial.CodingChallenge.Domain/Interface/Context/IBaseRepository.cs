using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Domain.Interface.Context
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// The generic method for listing filtered items from the database.
        /// </summary>
        /// <param name="predicate">The filtering expression for listing the entries from database.</param>
        /// <returns>A<see cref="IEnumerable{T}"/> of the <see cref="TEntity"/> type of objects.</returns>
        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity, bool commit);
    }
}
