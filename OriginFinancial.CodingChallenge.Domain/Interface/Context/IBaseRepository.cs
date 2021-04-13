using System;

namespace OriginFinancial.CodingChallenge.Domain.Interface.Context
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
    }
}
