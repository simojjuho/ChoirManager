using System;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    Task<T> GetAllAsync(IQueryOptions queryOptions);
    Task<T> GetOneAsync(string altKey);
    Task<T> GetOneByIdAsync(Guid id);
    Task<T> CreateOneAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
}