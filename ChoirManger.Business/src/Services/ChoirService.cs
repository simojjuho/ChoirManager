using AutoMapper;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManger.Business.Abstractions;
using ChoirManger.Business.DTOs.ChoirDtos;

namespace ChoirManger.Business.Services;

public class ChoirService : IChoirService
{
    private readonly IChoirRepository _choirRepository;
    private readonly IMapper _mapper;

    public ChoirService(IChoirRepository repository, IMapper mapper)
    {
        _choirRepository = repository;
        _mapper = mapper;
    }
    
    public async Task<ChoirGetDto> GetOneAsync(string altKey)
    {
        return _mapper.Map<ChoirGetDto>(await _choirRepository.GetOneAsync(altKey));
    }

    public Task<List<ChoirGetDto>> GetManyAsync(IQueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public Task<ChoirGetDto> CreateOneAsync(ChoirCreateDto createDto)
    {
        throw new NotImplementedException();
    }

    public Task<ChoirGetDto> UpdateOneAsync(ChoirUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveOne(string altKey)
    {
        throw new NotImplementedException();
    }
}