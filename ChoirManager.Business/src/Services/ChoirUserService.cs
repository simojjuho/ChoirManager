using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.Abstractions.Shared;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Services;

public class ChoirUserService : ServiceProps<ChoirUser>, IChoirUserService
{
    private readonly IChoirUserRepository _repository;
    private readonly IChoirRepository _choirRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEntityHelper<ChoirUser> _helper;
    
    public ChoirUserService(IChoirUserRepository repository, IUserRepository userRepository, IChoirRepository choirRepository, IEntityHelper<ChoirUser> helper, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _userRepository = userRepository;
        _choirRepository = choirRepository;
        _helper = helper;
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
        var existingUser = await _userRepository.GetOneAsync(createDto.UserEmail);
        var existingChoir = await _choirRepository.GetOneAsync(createDto.ChoirName);
        if (existingChoir is null)
        {
            throw CustomException.NotFoundException("Choir does not exist");
        }
        
        var entity = _mapper.Map<ChoirUser>(createDto);
        if (existingUser is not null)
        {
            entity.UserId = existingUser.Id;
            entity.ChoirId = existingChoir.Id;
        }

        var newEntity = await _repository.CreateOneAsync(entity);
        return _mapper.Map<ChoirUserGetDto>(newEntity);
    }

    public async Task<ChoirUserGetDto> UpdateOneAsync(ChoirUserUpdateDto updateDto, string altKey)
    {
        var original = await _repository.GetOneAsync(altKey);
        var update = _mapper.Map<ChoirUser>(updateDto);
        _helper.CheckNullValues(original!, update);
        _helper.ReplacePropertyValues(original!, update);
        var updatedEntity = await _repository.UpdateAsync(update);
        return _mapper.Map<ChoirUserGetDto>(updatedEntity);
    }

    public async Task<bool> RemoveOne(string altKey)
    {
        var entity = await _repository.GetOneAsync(altKey);
        return await _repository.RemoveAsync(entity!);
    }
}