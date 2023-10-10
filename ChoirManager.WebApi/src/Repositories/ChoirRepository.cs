using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;

namespace ChoirManager.WebApi.Repositories;

public class ChoirRepository : IChoirRepository
{
    public async Task<IChoir> GetAllAsync(IQueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public async Task<IChoir> GetOneAsync(string altKey)
    {
        throw new NotImplementedException();
    }

    public async Task<IChoir> GetOneByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IChoir> CreateOneAsync(IChoir entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IChoir> UpdateAsync(IChoir entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IChoir> RemoveAsync(IChoir entity)
    {
        throw new NotImplementedException();
    }
}