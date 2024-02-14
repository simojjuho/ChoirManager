using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Business.Shared;

using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;

namespace ChoirManager.Business.Services;

public class ChoirUserService : ServiceProps<ChoirUser>, IChoirUserService
{
    private IChoirUserRepository _repository;

    private IChoirRepository _choirRepository;
    private IUserRepository _userRepository;
    
    public ChoirUserService(IChoirUserRepository repository, IUserRepository userRepository, IChoirRepository choirRepository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _userRepository = userRepository;
        _choirRepository = choirRepository;
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
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveOne(string altKey)
    {
        throw new NotImplementedException();
    }
}