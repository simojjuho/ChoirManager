using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.QueryOptions;
using Microsoft.AspNetCore.Mvc;

namespace ChoirManager.Controllers.Abstractions;

public interface IChoirController : IBaseController<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto>
{
    Task<ActionResult<ChoirGetDto[]>> GetManyAsync(ChoirQueryOptions queryOptions);
}