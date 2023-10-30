using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Core.Abstractions.QueryOptions;
using Microsoft.AspNetCore.Mvc;

namespace ChoirManager.Controllers.Abstractions;

public interface IChoirController : IBaseController<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto>
{
    Task<ActionResult<ChoirGetDto[]>> GetManyAsync(IChoirQueryOptions queryOptions);
}