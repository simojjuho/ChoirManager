using Microsoft.AspNetCore.Mvc;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.ChoirUserDtos;
using ChoirManager.Controllers.Abstractions;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.Abstractions.Repositories;
using ChoirManager.Core.CoreEntities;
using ChoirManager.Core.QueryOptions;

namespace ChoirManager.Controllers.Controllers;

[Route("api/v1/[controller]s")]
public class ChoirUserController : ControllerProperties<ChoirUserGetDto, ChoirUserCreateDto, ChoirUserUpdateDto>, IChoirUserController
{
    public ChoirUserController(IChoirUserService service) : base(service)
    {
    }

    [HttpGet("{altKey}")]
    public async Task<ActionResult<ChoirUserGetDto>> GetOneAsync([FromRoute] string altKey)
    {
        return await _service.GetOneAsync(altKey);
    }
    
    [HttpGet]
    public async Task<ActionResult<ChoirUserGetDto[]>> GetManyAsync([FromQuery] QueryOptions queryOptions)
    {
        return await _service.GetManyAsync(queryOptions);
    }

    [HttpPost]
    public async Task<ActionResult<ChoirUserGetDto>> CreateOneAsync([FromBody] ChoirUserCreateDto choirCreateDto)
    {
        return await _service.CreateOneAsync(choirCreateDto);
    }

    [HttpPatch("{altKey}")]
    public async Task<ActionResult<ChoirUserGetDto>> UpdateOneAsync([FromRoute] string altKey, ChoirUserUpdateDto choirUpdateDto)
    {
        return await _service.UpdateOneAsync(choirUpdateDto, altKey);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> RemoveOneAsync([FromRoute] string altKey)
    {
        return await _service.RemoveOne(altKey);
    }
}