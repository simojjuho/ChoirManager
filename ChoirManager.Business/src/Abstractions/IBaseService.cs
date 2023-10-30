using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Business.Abstractions;

public interface IBaseService<TGetDto, TCreateDto, TUpdateDto>
{
    Task<TGetDto> GetOneAsync(string altKey);
    Task<TGetDto[]> GetManyAsync(IQueryOptions queryOptions);
    Task<TGetDto> CreateOneAsync(TCreateDto createDto);
    Task<TGetDto> UpdateOneAsync(TUpdateDto updateDto);
    Task<bool> RemoveOne(string altKey);

}