using ChoirManager.Core.Abstractions.CoreEntities;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;

namespace ChoirManager.WebApi.Repositories;

public class ChoirRepository : IChoirRepository
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

    public IChoir Remove(IChoir entity)
    {
        throw new NotImplementedException();
    }
}