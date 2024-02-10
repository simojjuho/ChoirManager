using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.Abstractions.Shared;
using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Services;

public class UserService : ServiceProps<User>, IUserService
{
    private readonly IUserRepository _repository;
    private readonly IEntityHelper<User> _entityHelper;
    public UserService(IUserRepository repository, IMapper mapper, IEntityHelper<User> entityHelper) : base(repository, mapper)
    {
        _repository = repository;
        _entityHelper = entityHelper;
    }
    
    public async Task<UserGetDto> GetOneAsync(string altKey)
    {
        return _mapper.Map<UserGetDto>(await _repository.GetOneAsync(altKey));
    }

    public async Task<UserGetDto[]> GetManyAsync(IQueryOptions queryOptions)
    {
        return _mapper.Map<UserGetDto[]>(await _repository.GetAllAsync(queryOptions));
    }

    public async Task<UserGetDto> CreateOneAsync(UserCreateDto createDto)
    {
        var newUser = _mapper.Map<User>(createDto);
        return _mapper.Map<UserGetDto>(await _repository.CreateOneAsync(newUser));
    }

    public async Task<UserGetDto> UpdateOneAsync(UserUpdateDto updateDto, string altKey)
    {
        var updateEntity = _mapper.Map<User>(updateDto);
        var original = await _repository.GetOneAsync(altKey);
        updateEntity.Id = original.Id;
        _entityHelper.CheckNullValues(original, updateEntity);
        _entityHelper.ReplacePropertyValues(original, updateEntity);
        return _mapper.Map<UserGetDto>(await _repository.UpdateAsync(original));
    }

    public async Task<bool> RemoveOne(string altKey)
    {
        var entity = await _repository.GetOneAsync(altKey);
        return await _repository.RemoveAsync(entity);
    }
}