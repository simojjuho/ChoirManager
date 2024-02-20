using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Controllers.Controllers;

public class ChoirUserController : ControllerProperties<ChoirUserGetDto, ChoirUserCreateDto, ChoirUserUpdateDto>, IChoirUserRepository
{
    public ChoirUserController(IBaseService<ChoirUserGetDto, ChoirUserCreateDto, ChoirUserUpdateDto> service) : base(service)
    {
    }

    public Task<ChoirUser?> GetOneAsync(string altKey)
    {
        throw new NotImplementedException();
    }
    
    public Task<ChoirUser[]> GetAllAsync(IQueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public Task<ChoirUser> GetOneByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ChoirUser> CreateOneAsync(ChoirUser entity)
    {
        throw new NotImplementedException();
    }

    public Task<ChoirUser> UpdateAsync(ChoirUser entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(ChoirUser entity)
    {
        throw new NotImplementedException();
    }
}