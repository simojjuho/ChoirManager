using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;

namespace ChorManager.WebApi.Repositories;

public class UserRepository : IUserRepository
{
    public IChoir GetAll(IQueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public IChoir GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IChoir CreateOne(IChoir entity)
    {
        throw new NotImplementedException();
    }

    public IChoir Update(IChoir entity)
    {
        throw new NotImplementedException();
    }

    public Task<IChoir> RemoveAsync(IChoir entity)
    {
        throw new NotImplementedException();
    }
}