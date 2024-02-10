using AutoMapper;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.Abstractions.Shared;
using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Business.Shared;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.QueryOptions;

namespace ChoirManager.Business.Services;

public class ChoirService : ServiceProps<Choir>, IChoirService
{
    private readonly IChoirRepository _repository;
    private readonly IEntityHelper<Choir> _entityHelper;
    public ChoirService(IChoirRepository repository, IMapper mapper, IEntityHelper<Choir> entityHelper) : base(repository, mapper)
    {
        _repository = repository;
        _entityHelper = entityHelper;
    }
    public async Task<ChoirGetDto> GetOneAsync(string altKey)
    {
        return _mapper.Map<ChoirGetDto>(await _repository.GetOneAsync(altKey));
    }

    public async Task<ChoirGetDto[]> GetManyAsync(IQueryOptions queryOptions)
    {
        var choirQueryOptions = (ChoirQueryOptions)queryOptions;
        return _mapper.Map<ChoirGetDto[]>(await _repository.GetAllAsync(choirQueryOptions));
    }

    public async Task<ChoirGetDto> CreateOneAsync(ChoirCreateDto createDto)
    {
        var choirEntity = _mapper.Map<Choir>(createDto);
        return _mapper.Map<ChoirGetDto>(await _repository.CreateOneAsync(choirEntity));
    }

    public async Task<ChoirGetDto> UpdateOneAsync(ChoirUpdateDto updateDto, string altKey)
    {
        var updateEntity = _mapper.Map<Choir>(updateDto);
        var original = await _repository.GetOneAsync(altKey);
        updateEntity.Id = original.Id;
        _entityHelper.CheckNullValues(original, updateEntity);
        _entityHelper.ReplacePropertyValues(original, updateEntity);
        return _mapper.Map<ChoirGetDto>(await _repository.UpdateAsync(original));
    }

    public async Task<bool> RemoveOne(string altKey)
    {
        var entity = await _repository.GetOneAsync(altKey);
        return await _repository.RemoveAsync(entity);
    }
}