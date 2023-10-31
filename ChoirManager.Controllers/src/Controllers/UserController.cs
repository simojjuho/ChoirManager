using Microsoft.AspNetCore.Mvc;
using ChoirManager.Business.Abstractions;
using ChoirManager.Business.DTOs.UserDtos;
using ChoirManager.Controllers.Abstractions;
using ChoirManager.Core.Abstractions.QueryOptions;
using ChoirManager.Core.QueryOptions;

namespace ChoirManager.Controllers.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class UserController : ControllerProperties<UserGetDto, UserCreateDto, UserUpdateDto>, IUserController
{
    public UserController(IUserService service) : base(service)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult<UserGetDto[]>> GetManyAsync([FromQuery ]QueryOptions queryOptions)
    {
        return await _service.GetManyAsync(queryOptions);
    }

    [HttpGet("{altKey}")]
    public async Task<ActionResult<UserGetDto>> GetOneAsync([FromRoute]string altKey)
    {
        return await _service.GetOneAsync(altKey);
    }
    
    [HttpPost]
    public async Task<ActionResult<UserGetDto>> CreateOneAsync(UserCreateDto userCreateDto)
    {
        return await _service.CreateOneAsync(userCreateDto);
    }
    
    [HttpPatch]
    public async Task<ActionResult<UserGetDto>> UpdateOneAsync(string altKey, UserUpdateDto userUpdateDto)
    {
        return await _service.UpdateOneAsync(userUpdateDto, altKey);
    }
    
    [HttpDelete]
    public async Task<ActionResult<bool>> RemoveOneAsync(string altKey)
    {
        return await _service.RemoveOne(altKey);
    }
}