using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Core.Abstractions.Repositories;

public interface IChoirRepository : IBaseRepository<Choir>
{
    Task<Choir[]> GetAllAsync(IChoirQueryOptions queryOptions);
}