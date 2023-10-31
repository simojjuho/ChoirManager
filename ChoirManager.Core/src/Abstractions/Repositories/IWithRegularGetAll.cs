using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Core.Abstractions.Repositories;

public interface IWithRegularGetAll<T> : IBaseRepository<T>
{
    Task<T[]> GetAllAsync(IQueryOptions queryOptions);
}