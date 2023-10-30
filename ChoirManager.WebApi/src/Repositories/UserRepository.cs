using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.WebApi.Repositories;

public class UserRepository : IUserRepository
{
    public Task<Choir[]> GetAllAsync(IChoirQueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public Task<Choir?> GetOneAsync(string altKey)
    {
        throw new NotImplementedException();
    }

    public Task<Choir> GetOneByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Choir> CreateOneAsync(Choir entity)
    {
        throw new NotImplementedException();
    }

    public Task<Choir> UpdateAsync(Choir entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Choir entity)
    {
        throw new NotImplementedException();
    }
}