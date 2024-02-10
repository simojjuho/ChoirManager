using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Services;

public class ChoirUserService : ServiceProps<ChoirUser>, IChoirUserService
{
    private IChoirUserRepository _repository;
    
    public ChoirUserService(IChoirUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
    }

    public async Task<ChoirUserGetDto> GetOneAsync(string altKey)
    {
        return _mapper.Map<ChoirUserGetDto>(await _repository.GetOneAsync(altKey));
    }

    public async Task<ChoirUserGetDto[]> GetManyAsync(IQueryOptions queryOptions)
    {
        return _mapper.Map<ChoirUserGetDto[]>(await _repository.GetAllAsync(queryOptions));
    }

    public async Task<ChoirUserGetDto> CreateOneAsync(ChoirUserCreateDto createDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ChoirUserGetDto> UpdateOneAsync(ChoirUserUpdateDto updateDto, string altKey)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveOne(string altKey)
    {
        throw new NotImplementedException();
    }
}