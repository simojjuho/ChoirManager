using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Core.Abstractions.QueryOptions;

namespace ChoirManager.Controllers.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class ChoirController : BaseController<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto>
{
    public ChoirController(IBaseService<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto> service) : base(service)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<ChoirGetDto[]>> GetManyAsync(IChoirQueryOptions queryOptions)
    {
        return await _service.GetManyAsync(queryOptions);
    }

    [HttpGet("{altKey}")]
    public async Task<ActionResult<ChoirGetDto>> GetOneAsync(string altKey)
    {
        return await _service.GetOneAsync(altKey);
    }

    [HttpPost]
    public async Task<ActionResult<ChoirGetDto>> CreateOneAsync(ChoirCreateDto choirCreateDto)
    {
        return await _service.CreateOneAsync(choirCreateDto);
    }

    [HttpPatch("{altKey}")]
    public async Task<ActionResult<ChoirGetDto>> UpdateOneAsync(ChoirUpdateDto choirUpdateDto)
    {
        return await _service.UpdateOneAsync(choirUpdateDto);
    }

    [HttpDelete("{altKey}")]
    public async Task<ActionResult<bool>> RemoveOneAsync([FromRoute]string altKey)
    {
        return await _service.RemoveOne(altKey);
    }
}