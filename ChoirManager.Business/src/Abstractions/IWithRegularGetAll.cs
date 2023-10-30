using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Business.Abstractions;

public interface IWithRegularGetAll<TGetDto, TCreateDto, TUpdateDto> : IBaseService<TGetDto, TCreateDto, TUpdateDto>
{
    Task<TGetDto[]> GetManyAsync(IQueryOptions queryOptions)
}