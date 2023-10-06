using System;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    T GetAll(IQueryOptions queryOptions);
    T GetOneById(Guid id);
    T CreateOne(T entity);
    T Update(T entity);
    T Remove(T entity);
}