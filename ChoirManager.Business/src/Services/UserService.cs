using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Services;

public class UserService : ServiceProps<User>, IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
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

    public Task<UserGetDto> UpdateOneAsync(UserUpdateDto updateDto, string altKey)
    {
        
    }

    public Task<bool> RemoveOne(string altKey)
    {
        throw new NotImplementedException();
    }
}