using ChoirManager.Business.DTOs.ChoirUserDtos;

namespace ChoirManager.Controllers.Abstractions;

public interface IChoirUserController : IWithRegularGetMany<ChoirUserGetDto, ChoirUserCreateDto, ChoirUserUpdateDto>
{
    
}