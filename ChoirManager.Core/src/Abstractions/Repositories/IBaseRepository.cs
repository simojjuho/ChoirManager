using System;
using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    Task<T[]> GetAllAsync(IChoirQueryOptions queryOptions);
    Task<T?> GetOneAsync(string altKey);
    Task<T> GetOneByIdAsync(Guid id);
    Task<T> CreateOneAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> RemoveAsync(T entity);
}