using Microsoft.EntityFrameworkCore;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Infra.Data.Context
{
    /// <summary>
    /// The generic implementation of common repository methods.
    /// </summary>
    /// <typeparam name="TEntity">The generic type for the entity that is been used during the scoped action.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected MainDatabaseContext _dbContext;
        protected DbSet<TEntity> DbSet;

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="dbContext">The DI registered interface of the main database context.</param>
        public BaseRepository(IMainDatabaseContext dbContext)
        {
            _dbContext = (MainDatabaseContext)dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, bool commit)
        {
            try
            {
                DbSet.Add(entity);

                if (commit)
                    await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                string trace = !string.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace.Split("at").LastOrDefault().Split("\\").LastOrDefault() : "";
                ex.HelpLink += $"DATABASE ERROR - {ex?.InnerException?.Message}|{trace}";
                throw;
            }
        }

        /// <summary>
        /// The generic method for listing filtered items from the database.
        /// </summary>
        /// <param name="predicate">The filtering expression for listing the entries from database.</param>
        /// <returns>A<see cref="IEnumerable{T}"/> of the <see cref="TEntity"/> type of objects.</returns>
        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return DbSet.Where(predicate);
            }
            catch (Exception ex)
            {
                string trace = !string.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace.Split("at").LastOrDefault().Split("\\").LastOrDefault() : "";
                ex.HelpLink += $"DATABASE ERROR - {ex?.InnerException?.Message}|{trace}";
                throw;
            }
        }

        /// <summary>
        /// The implementation of the IDisposable interface, disposing the system of the scoped context.
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
