using Microsoft.EntityFrameworkCore;
using OriginFinancial.CodingChallenge.Domain.Interface.Context;

namespace OriginFinancial.CodingChallenge.Infra.Data.Context
{
    /// <summary>
    /// The generic implementation of common repository methods.
    /// </summary>
    /// <typeparam name="TEntity">The generic type for the entity that is been used during the scoped action.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MainDatabaseContext _dbContext;
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

        /// <summary>
        /// The implementation of the IDisposable interface, disposing the system of the scoped context.
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
