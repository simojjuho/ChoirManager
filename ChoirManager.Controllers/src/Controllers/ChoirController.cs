using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirDtos;
using ChoirManager.Controllers.Abstractions;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.QueryOptions;
using Microsoft.AspNetCore.Http;

namespace ChoirManager.Controllers.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class ChoirController : ControllerProperties<ChoirGetDto, ChoirCreateDto, ChoirUpdateDto>, IChoirController
{
    public ChoirController(IChoirService service) : base(service)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<ChoirGetDto[]>> GetManyAsync([FromQuery] ChoirQueryOptions queryOptions)
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
    public async Task<ActionResult<ChoirGetDto>> UpdateOneAsync([FromRoute] string altKey, ChoirUpdateDto choirUpdateDto)
    {
        return await _service.UpdateOneAsync(choirUpdateDto, altKey);
    }

    [HttpDelete("{altKey}")]
    public async Task<ActionResult<bool>> RemoveOneAsync([FromRoute]string altKey)
    {
        return await _service.RemoveOne(altKey);
    }
}