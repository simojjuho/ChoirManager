using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.QueryOptions;
using Microsoft.AspNetCore.Mvc;

namespace ChoirManager.Controllers.Abstractions;

public interface IWithRegularGetMany<TGetDto, TCreateDto, TUpdateDto> : IBaseController<TGetDto, TCreateDto, TUpdateDto>
{
    Task<ActionResult<TGetDto[]>> GetManyAsync(QueryOptions queryOptions);
}